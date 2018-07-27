<?php

require_once "clases/Juguete.php";

$objetoAccesoDato = AccesoDatos::dameUnObjetoAcceso();
$consulta = $objetoAccesoDato->RetornarConsulta("SELECT * FROM `juguetes` WHERE id=:id");
$consulta->bindValue(':id',  $_POST['id'], PDO::PARAM_INT);
$consulta->execute();
$datos=$consulta->fetch();
$foto=explode(".",$datos['foto']);
copy("juguetes/imagenes/".$datos['foto'],"juguetes/juguetesModificados/".$foto[0].".".$foto[1].".modificado.".date('His').".".$foto[3]);
unlink("juguetes/imagenes/".$datos['foto']);
$tipoArchivo = pathinfo($_FILES["archivo"]["name"], PATHINFO_EXTENSION);
$destino=$_POST['tipo'].".".$_POST['pais'].".".date('His').".".$tipoArchivo;
move_uploaded_file($_FILES["archivo"]["tmp_name"], "juguetes/imagenes/".$destino);
$juguete=new Juguete($_POST['tipo'],$_POST['precio'],$_POST['pais'],$destino);
$juguete->Modificar();
header('Location: listado.php');

?>