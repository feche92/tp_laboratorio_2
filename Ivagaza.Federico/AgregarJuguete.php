<?php

require_once "clases/Juguete.php";


$juguete=new Juguete($_POST['tipo'],$_POST['precio'],$_POST['pais']);
$lista=$juguete->Traer();
if($juguete->Verificar($lista)) {
    $tipoArchivo = pathinfo($_FILES["archivo"]["name"], PATHINFO_EXTENSION);
    $destino=$_POST['tipo'].".".$_POST['pais'].".".date('His').".".$tipoArchivo;
    move_uploaded_file($_FILES["archivo"]["tmp_name"], "juguetes/imagenes/".$destino);
    $juguete=new Juguete($_POST['tipo'],$_POST['precio'],$_POST['pais'],$destino);
    $juguete->Agregar();
    header('Location: listado.php');
}
else {
    echo "El juguete ya se encuentra en la base de datos";
}
