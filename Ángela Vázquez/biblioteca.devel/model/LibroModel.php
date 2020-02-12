<?php


class LibroModel implements JsonSerializable
{
    private $titulo;
    private $codigo;
    private $arrayFormatos;
    //private $numpag;

    public function __construct($cod,$tit, $arrayFormatos)
    {
        $this->codigo=$cod;
        $this->titulo=$tit;
        $this->arrayFormatos = $arrayFormatos;

        //$this->numpag=$pag;
    }

    /**
     * Specify data which should be serialized to JSON
     * @link http://php.net/manual/en/jsonserializable.jsonserialize.php
     * @return mixed data which can be serialized by <b>json_encode</b>,
     * which is a value of any type other than a resource.
     * @since 5.4.0
     */

    //Needed if the properties of the class are private.
    //Otherwise json_encode will encode blank objects
    function jsonSerialize()
    {
        return array(
            'titulo' => $this->titulo,
            'codigo' => $this->codigo,
            'arrayFormatos' => $this->arrayFormatos
            //,'numpag' => $this->numpag
        );
    }

    public function __sleep(){
        return array('titulo' , 'codigo' , 'arrayFormatos');
    }


    /**
     * @return mixed
     */
    public function getTitulo()
    {
        return $this->titulo;
    }

    /**
     * @param mixed $titulo
     */
    public function setTitulo($titulo)
    {
        $this->titulo = $titulo;
    }

    /**
     * @return mixed
     */
    public function getCodigo()
    {
        return $this->codigo;
    }

    /**
     * @param mixed $codigo
     */
    public function setCodigo($codigo)
    {
        $this->codigo = $codigo;
    }


    public function getArrayFormatos()
    {
        return $this->arrayFormatos;
    }

    public function setArrayFormatos($arrayFormatos){
        $this->arrayFormatos=$arrayFormatos;
    }


    /**
     * @return mixed
     */
    /*
    public function getNumpag()
    {
        return $this->numpag;
    }
*/
    /**
     * @param mixed $numpag
     */
  /*
    public function setNumpag($numpag)
    {
        $this->numpag = $numpag;
    }
*/
}