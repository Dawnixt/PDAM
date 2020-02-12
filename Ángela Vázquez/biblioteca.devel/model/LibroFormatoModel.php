<?php


class LibroFormatoModel implements JsonSerializable
{

    private $idLibro;

    private $idFormato;
    private $numPag;

    /**
     * LibroFormatoModel constructor.
     * @param $idLibro
     * @param $idFormato
     * @param $numPag
     */
    public function __construct($idLibro,$idFormato, $numPag)
    {
        $this->idLibro = $idLibro;
        $this->idFormato = $idFormato;
        $this->numPag = $numPag;
    }

    /**
     * @return mixed
     */
    public function getIdLibro()
    {
        return $this->idLibro;
    }

    /**
     * @param mixed $idLibro
     */
    public function setIdLibro($idLibro)
    {
        $this->idLibro = $idLibro;
    }

    /**
     * @return mixed
     */
    public function getIdFormato()
    {
        return $this->idFormato;
    }

    /**
     * @param mixed $idFormato
     */
    public function setIdFormato($idFormato)
    {
        $this->idFormato = $idFormato;
    }

    /**
     * @return mixed
     */
    public function getNumPag()
    {
        return $this->numPag;
    }

    /**
     * @param mixed $numPag
     */
    public function setNumPag($numPag)
    {
        $this->numPag = $numPag;
    }



    /**
     * @inheritDoc
     */
    public function jsonSerialize()
    {
        // TODO: Implement jsonSerialize() method.
        return array(
            'idLibro' => $this->idLibro,
            'idFormato' => $this->idFormato,

            'numPag'=>$this->numPag

            //,'numpag' => $this->numpag
        );
    }
}