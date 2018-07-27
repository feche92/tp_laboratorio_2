<?php

require_once "interfaces.php";
require_once "AccesoDatos.php";

class Juguete implements IParte1 {
    private $_tipo;
    private $_precio;
    private $_paisOrigen;
    private $_pathImagen;

    public function __construct($tipo,$precio,$pais,$imagen=null) {
        $this->_tipo=$tipo;
        $this->_precio=$precio;
        $this->_paisOrigen=$pais;
        $this->_pathImagen=$imagen;
    }

    public function ToString() {
        return $this->_tipo . "-".$this->_precio."-".$this->_paisOrigen."-".$this->_pathImagen;
    }

    public function Agregar() {
        $objetoAccesoDato = AccesoDatos::dameUnObjetoAcceso();
        $consulta = $objetoAccesoDato->RetornarConsulta("INSERT INTO `juguetes` (`id`, `tipo`, `precio`, `pais`, `foto`) VALUES (NULL, :tipo, :precio, :pais, :foto)");
        $consulta->bindValue(':tipo',  $this->_tipo, PDO::PARAM_STR);
        $consulta->bindValue(':precio',  $this->_precio, PDO::PARAM_STR);
        $consulta->bindValue(':pais',  $this->_paisOrigen, PDO::PARAM_STR);
        $consulta->bindValue(':foto',  $this->_pathImagen, PDO::PARAM_STR);
        $consulta->execute();
        return true;
    }

    public function Traer() {
        $objetoAccesoDato = AccesoDatos::dameUnObjetoAcceso();
        $consulta = $objetoAccesoDato->RetornarConsulta("SELECT * FROM juguetes");
        $consulta->execute();
        return $consulta->fetchall();
    }

    public function CalcularIva() {
        return $this->_precio * 1.21;
    }

    public function Verificar($lista) {
        $retorno=true;
        foreach($lista as $value)
        {
            if($value['tipo']==$this->_tipo)
            {
                $retorno=false;
                break;
            }
        }
        return $retorno;
    }

    public function Modificar() {
        $objetoAccesoDato = AccesoDatos::dameUnObjetoAcceso();
        $consulta = $objetoAccesoDato->RetornarConsulta("UPDATE `juguetes` SET `precio` = :precio, `pais` = :pais, `foto` = :foto WHERE `tipo` = :tipo;");
        $consulta->bindValue(':tipo',  $this->_tipo, PDO::PARAM_STR);
        $consulta->bindValue(':precio',  $this->_precio, PDO::PARAM_STR);
        $consulta->bindValue(':pais',  $this->_paisOrigen, PDO::PARAM_STR);
        $consulta->bindValue(':foto',  $this->_pathImagen, PDO::PARAM_STR);
        $consulta->execute();
        return true;
    }

    public static function MostrarLog() {
        $ar=fopen("archivos/juguetes_sin_foto.txt","r");
        $texto=fread($ar,filesize("archivos/juguetes_sin_foto.txt"));
        return $texto;
    }
}


?>