<?php

require_once "Controller.php";


class LibroController extends Controller
{
    //TODO Implementa los demás verbos (POST, DELETE, PUT)

    //Verbo Put (para actualizar)
//    public function managePutVerb(Request $request)
//    {
//
//        $response = null;
//        $code = 0;
//        $filasAfectadas = 0;
//        $id = null;
//        if (isset($request->getUrlElements()[2])) {
//            $id = $request->getUrlElements()[2];
//            if($id != null){
//                $filasAfectadas = LibroHandlerModel::putLibro($request->getBodyParameters(), $id);
//            }
//
//
//            if ($filasAfectadas > 0) {
//                $code = '200';
//
//            }
//            else {
//            //TODO aqui tendria que comprobar que si los valores son los mismos que intentas poner de nuevo
//                //MySQL no actualizara porque pa que va a actualizar si ya tiene esos valores, y entonces
//                //las filas afectadas te salen a 0 xddd pero no significa que sea un error ni sé qué codigo ponerle a eso
//                if(LibroHandlerModel::isValid($id)){
//                    $code = '404';
//                }else{
//                    $code = '500';  //internal server error
//                }
//
//                /*Aqui pon casos de error y sus codigos devueltos*/
//            }
//
//
//        }else{
//            $code = '400';  //bad request porque no voy a permitir actualizaciones de colecciones
//        }
//        $response = new Response($code, null, $request->getAccept());
//        $response->generate();
//    }



    //Verbo Post
    /*Modificado para que ahora reciba el objeto creado*/
//    public function managePostVerb(Request $request)
//    {
//
//        $response = null;
//        $code = 0;
//
//        //$filasAfectadas = 0;
//        $libroCreado = null;
//
//        if (!isset($request->getUrlElements()[2])) {
//
//
//            //La URI NO debe hacer referencia a un libro concreto,
//            // porque queremos crear un libro dentro de una colección
//
//                //Le mando los body parameters al postLibro
//
//            //$filasAfectadas = LibroHandlerModel::postLibro($request->getBodyParameters());
//            $libroCreado = LibroHandlerModel::postLibro($request->getBodyParameters());
//
//                //if ($filasAfectadas[0] > 0) {
//                if($libroCreado != null){
//                    $code = '201';  //201 Created
//
//                } else {
//                    $code = '500';  //internal server error
//                    /*Aqui pon casos de error y sus codigos devueltos*/
//                }
//
//
//        }else{
//            $code = '400';
//        }
//        $response = new Response($code, null,$libroCreado, $request->getAccept());
//        $response->generate();
//    }

    //Verbo Delete
//    public function manageDeleteVerb(Request $request)
//    {
//        $filasAfectadas = -1;
//        $id = null;
//        $response = null;
//        $code = null;
//
//        //La URI debe hacer referencia a un libro, porque no vamos a permitir borrar colecciones
//        if (isset($request->getUrlElements()[2])) {
//            $id = $request->getUrlElements()[2];
//            $filasAfectadas = LibroHandlerModel::deleteLibro($id);
//
//            /*Pongo >0 porque no estoy segura de si puedes borrar mas de un libro a la vez en una sola llamada*/
//            if ($filasAfectadas > 0) {
//                $code = '200';
//
//            } else {
//
//                //We could send 404 in any case, but if we want more precission,
//                //we can send 400 if the syntax of the entity was incorrect...
//                if (LibroHandlerModel::isValid($id)) {
//                    $code = '404';
//                } else {
//                    $code = '500';  //server error
//                }
//            }
//        }else{
//            $code = '400';
//        }
//        $response = new Response($code, null, $request->getAccept());
//        $response->generate();
//    }
//

    //Verbo GET
    public function manageGetVerb(Request $request)
    {
        $listaLibros = null;
        $id = null;
        $response = null;
        $code = null;
        //$tituloABuscar = "";
        //$queryString = $request->getQueryString();

        //if the URI refers to a libro entity, instead of the libro collection
        if (isset($request->getUrlElements()[2])) {
            $id = $request->getUrlElements()[2];
        }

//        if(!empty($queryString)){
//            if(($queryString["titulo"]) != null)
//            {
//                $tituloABuscar = $queryString["titulo"];
//
//                $listaLibros = LibroHandlerModel::getLibroPorTitulo($tituloABuscar);
//            }
//        }
//        else{
//            $listaLibros = LibroHandlerModel::getLibro($id);
//        }

        $listaLibros = LibroHandlerModel::getLibro($id);
        if ($listaLibros != null) {
            $code = '200';

        } else {

            //We could send 404 in any case, but if we want more precission,
            //we can send 400 if the syntax of the entity was incorrect...
            if (LibroHandlerModel::isValid($id)) {
                $code = '404';
            }else if(empty($listaLibros)){
                $code = '204';
            } else {
                $code = '400';  //aqui no va a entrar
            }

        }

        $response = new Response($code, null, $listaLibros, $request->getAccept());
        $response->generate();

    }

}