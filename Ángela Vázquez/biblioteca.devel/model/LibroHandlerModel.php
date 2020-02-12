<?php

require_once "ConsLibrosModel.php";
require_once "ConsFormatosModel.php";
require_once  "ConsLibroFormatoModel.php";


class LibroHandlerModel
{

    /*Get por querystring de titulo, devuelve lista de libros que contengan una cadena dada*/

//    public static function getLibroPorTitulo($tituloABuscar){
//        $listaLibros = null;
//        $libro = null;
//        $ret = null;
//
//        $db = DatabaseModel::getInstance();
//        $db_connection = $db->getConnection();
//
//        $query = "SELECT *  from " . \ConstantesDB\ConsLibrosModel::TABLE_NAME .
//            " WHERE " .\ConstantesDB\ConsLibrosModel::TITULO . " LIKE CONCAT('%',?,'%') ";  //asi se pone el LIKE % ? %
//
//
//
//        $prep_query = $db_connection->prepare($query);
//
//
//        $prep_query->bind_param('s', $tituloABuscar);
//            $prep_query->execute();
//            $listaLibros = array();
//
//            $prep_query->bind_result($cod, $tit, $pag);
//            while ($prep_query->fetch()) {
//                $tit = utf8_encode($tit);
//                $libro = new LibroModel($cod, $tit, $pag);
//                $listaLibros[] = $libro;
//            }
//
//
//
//        $db_connection->close();
//        return $listaLibros;
//    }


    public static function getLibro($id)
    {
        $listaLibros = null;
        $listaFormatos = null;
        $idPrev = -1;
        $libro = null;
        $ret = null;
        $isUnLibro = false;
        $db = DatabaseModel::getInstance();
        $db_connection = $db->getConnection();

        //IMPORTANT: we have to be very careful about automatic data type conversions in MySQL.
        //For example, if we have a column named "cod", whose type is int, and execute this query:
        //SELECT * FROM table WHERE cod = "3yrtdf"
        //it will be converted into:
        //SELECT * FROM table WHERE cod = 3
        //That's the reason why I decided to create isValid method,
        //I had problems when the URI was like libro/2jfdsyfsd
        $valid = self::isValid($id);
        //If the $id is valid or the client asks for the collection ($id is null)
        if ($valid === true || $id == null) {
            $query = "SELECT " . \ConstantesDB\ConsLibrosModel::COD . ", "
            . \ConstantesDB\ConsLibrosModel::TITULO . ", "
            . \ConstantesDB\ConsFormatosModel::ID . ", "
            . \ConstantesDB\ConsFormatosModel::NOMBRE . ", "
            . \ConstantesDB\ConsFormatosModel::TAMANO . ", "
            . \ConstantesDB\ConsLibroFormatoModel::PAGS
            . " FROM " . \ConstantesDB\ConsLibrosModel::TABLE_NAME
            . " INNER JOIN " . \ConstantesDB\ConsLibroFormatoModel::TABLE_NAME
            . " ON " . \ConstantesDB\ConsLibroFormatoModel::IDLIBRO . " = "
            . \ConstantesDB\ConsLibrosModel::COD
            . " INNER JOIN " . \ConstantesDB\ConsFormatosModel::TABLE_NAME
            . " ON " . \ConstantesDB\ConsFormatosModel::ID . " = " . \ConstantesDB\ConsLibroFormatoModel::IDFORMATO ;



            if ($id != null) {
                $query = $query . " WHERE " . \ConstantesDB\ConsLibrosModel::COD . " = ?";
                $isUnLibro = true;
            }

            $prep_query = $db_connection->prepare($query);
            if ($id != null) {
                $prep_query->bind_param('s', $id);
            }
            $prep_query->execute();
            $listaLibros = array();
            $listaFormatos = array();
            //IMPORTANT: IN OUR SERVER, I COULD NOT USE EITHER GET_RESULT OR FETCH_OBJECT,
            // PHP VERSION WAS OK (5.4), AND MYSQLI INSTALLED.
            // PROBABLY THE PROBLEM IS THAT MYSQLND DRIVER IS NEEDED AND WAS NOT AVAILABLE IN THE SERVER:
            // http://stackoverflow.com/questions/10466530/mysqli-prepared-statement-unable-to-get-result

            $hayQueGuardar = false;
            $libroPrev = null;
            $prep_query->bind_result($cod, $tit, $idFormato, $nombreFormato, $tamanoFormato, $numPag);
            while ($prep_query->fetch()) {  //Aqui recogemos cada una de las filas (libros)

                $tit = utf8_encode($tit);
                $nombreFormato = utf8_encode($nombreFormato);
                $tamanoFormato = utf8_encode($tamanoFormato);

                $formato = new FormatoModel($idFormato, $nombreFormato, $tamanoFormato);
                $libroFormato = new LibroFormatoModel($cod,$formato->getId(), $numPag);
                $listaFormatos[] = $libroFormato;

                //TODO falta que se quede con el ultimo libro creado que sera el que tenga todos los formatos


                if($idPrev != $cod && $idPrev > 0){
                    $hayQueGuardar = true;
                }
                $idPrev = $cod;

                if($hayQueGuardar) {
                    $listaLibros[] = $libroPrev;
                }else{
                    if($libroPrev != null)
                    $libroPrev->setArrayFormatos($listaFormatos);
                }
                $libro = new LibroModel($cod, $tit,$listaFormatos);
                $libroPrev = $libro;


            }

            
            //$listaLibros = self::eliminarRepetidos($listaLibros);


//            $result = $prep_query->get_result();
//            for ($i = 0; $row = $result->fetch_object(LibroModel::class); $i++) {
//
//                $listaLibros[$i] = $row;
//            }
        }

        if($isUnLibro){

            $ret = $listaLibros[0];

        }else{

            $ret = $listaLibros;
        }
        $db_connection->close();
        return $ret;
    }


    //returns true if $id is a valid id for a book
    //In this case, it will be valid if it only contains
    //numeric characters, even if this $id does not exist in
    // the table of books
    public static function isValid($id)
    {
        $res = false;

        if (ctype_digit($id)) {
            $res = true;
        }
        return $res;
    }

    /* Borrar libro
    borra libro con id indicada
    Devuelve filas afectadas
     * */
//    public static function deleteLibro($id)
//    {
//        $db = DatabaseModel::getInstance();
//        $db_connection = $db->getConnection();
//        $filasAfectadas = 0;
//
//        //IMPORTANT: we have to be very careful about automatic data type conversions in MySQL.
//        //For example, if we have a column named "cod", whose type is int, and execute this query:
//        //SELECT * FROM table WHERE cod = "3yrtdf"
//        //it will be converted into:
//        //SELECT * FROM table WHERE cod = 3
//        //That's the reason why I decided to create isValid method,
//        //I had problems when the URI was like libro/2jfdsyfsd
//
//        $valid = self::isValid($id);
//
//        //If the $id is valid
//        // id no puede ser null porque el cliente no puede borrar la coleccion
//        if ($valid === true ) {
//            $query = "DELETE FROM " . \ConstantesDB\ConsLibrosModel::TABLE_NAME
//                . " WHERE " . \ConstantesDB\ConsLibrosModel::COD . " = ?";
//
//
//            $prep_query = $db_connection->prepare($query);
//            $prep_query->bind_param('s', $id);
//
//
//            $prep_query->execute();
//
//            //IMPORTANT: IN OUR SERVER, I COULD NOT USE EITHER GET_RESULT OR FETCH_OBJECT,
//            // PHP VERSION WAS OK (5.4), AND MYSQLI INSTALLED.
//            // PROBABLY THE PROBLEM IS THAT MYSQLND DRIVER IS NEEDED AND WAS NOT AVAILABLE IN THE SERVER:
//            // http://stackoverflow.com/questions/10466530/mysqli-prepared-statement-unable-to-get-result
//
//
//            $db_connection->close();
//            $filasAfectadas = $prep_query->affected_rows;
//
//        }
//        return $filasAfectadas;
//    }


    /* Insertar libro
       inserta libro (objeto LibroModel)
       Devuelve filas afectadas que sera un array
        siendo el primer elemento el numero de filas afectadas y, si dicho
        numero es superior a 0, incluira como segundo elemento el ultimo id generado
       Recibo los parametros del body
        */
//    public static function postLibro($bodyParameters)
//    {
//        $db = DatabaseModel::getInstance();
//        $db_connection = $db->getConnection();
//        $libroCreado = null;
//        $filasAfectadas = array();
//
//
//        $titulo = $bodyParameters->titulo; //en teoria esto es el titulo
//        $numPags = $bodyParameters->numpag; //esto el n paginas
//
//
//            $query = "INSERT INTO ".\ConstantesDB\ConsLibrosModel::TABLE_NAME
//                    ."(".
//                    \ConstantesDB\ConsLibrosModel::TITULO .
//                ",".
//                    \ConstantesDB\ConsLibrosModel::PAGS
//                     .")".
//                        "VALUES(?,?)";
//
//
//            $prep_query = $db_connection->prepare($query);
//
//            $prep_query->bind_param('si', $titulo, $numPags);
//
//            $prep_query->execute();
//
//        $filasAfectadas[0] = $prep_query->affected_rows;
//
//        if($filasAfectadas[0] >0){
//            $filasAfectadas[1] = $db_connection->insert_id;
//
//
//            $query2 = "SELECT * FROM ".\ConstantesDB\ConsLibrosModel::TABLE_NAME . " WHERE " . \ConstantesDB\ConsLibrosModel::COD . " = ?"
//                ;
//
//
//            $prep_query2 = $db_connection->prepare($query2);
//
//            $prep_query2->bind_param('s', $filasAfectadas[1]);
//
//            $prep_query2->execute();
//
//            $prep_query2->bind_result($cod, $tit, $pag);
//            while ($prep_query2->fetch()) {
//                $tit = utf8_encode($tit);
//                $libroCreado = new LibroModel($cod, $tit, $pag);
//                $filasAfectadas[1] = $libroCreado;
//            }
//
//
//        }
//
//        $db_connection->close();
//
//
//
//        //return $filasAfectadas;
//        return $libroCreado;
//    }
//

    /* Actualiza libro

       Devuelve filas afectadas
       Recibo los parametros del body
        */
//    public static function putLibro($bodyParameters, $id)
//    {
//        $db = DatabaseModel::getInstance();
//        $db_connection = $db->getConnection();
//        $libroCreado = null;
//        $filasAfectadas = 0;
//
//        $cod = $id;
//        $titulo = $bodyParameters->titulo; //en teoria esto es el titulo
//        $numPags = $bodyParameters->numpag; //esto el n paginas
//
//
//        $query = "UPDATE ".\ConstantesDB\ConsLibrosModel::TABLE_NAME
//            ." SET ".
//            \ConstantesDB\ConsLibrosModel::TITULO .
//            " = ? ,".
//            \ConstantesDB\ConsLibrosModel::PAGS
//            ."= ? " .
//            " WHERE " .
//            \ConstantesDB\ConsLibrosModel::COD .
//            " = ?"
//            ;
//
//
//        $prep_query = $db_connection->prepare($query);
//        // esto es asi ??
//        $prep_query->bind_param('sii', $titulo, $numPags, $cod);
//
//        $prep_query->execute();
//
//        $filasAfectadas = $prep_query->affected_rows;
//
//        $db_connection->close();
//
//
//
//        return $filasAfectadas;
//    }



}