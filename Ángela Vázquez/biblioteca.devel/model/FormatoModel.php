<?php


class FormatoModel implements JsonSerializable
{
    private $id;
    private $nombre;
    private $tamano;

    /**
     * FormatoModel constructor.
     * @param $id
     * @param $nombre
     * @param $tamano
     */
    public function __construct($id, $nombre, $tamano)
    {
        $this->id = $id;
        $this->nombre = $nombre;
        $this->tamano = $tamano;
    }

    /**
     * @return mixed
     */
    public function getId()
    {
        return $this->id;
    }

    /**
     * @param mixed $id
     */
    public function setId($id)
    {
        $this->id = $id;
    }

    /**
     * @return mixed
     */
    public function getNombre()
    {
        return $this->nombre;
    }

    /**
     * @param mixed $nombre
     */
    public function setNombre($nombre)
    {
        $this->nombre = $nombre;
    }

    /**
     * @return mixed
     */
    public function getTamano()
    {
        return $this->tamano;
    }

    /**
     * @param mixed $tamano
     */
    public function setTamano($tamano)
    {
        $this->tamano = $tamano;
    }




    /**
     * @inheritDoc
     */
    public function jsonSerialize()
    {
        // TODO: Implement jsonSerialize() method.
        return array(
            'id' => $this->id,
            'nombre' => $this->nombre,

            'tamano'=>$this->tamano

            //,'numpag' => $this->numpag
        );
    }
}