<?php

require_once "clases/Juguete.php";

$juguete=new Juguete($_POST['tipo'],$_POST['precio'],$_POST['pais'],"undefined");
if($juguete->Agregar()) {
    $ar=fopen("archivos/juguetes_sin_foto.txt","a");
    fwrite($ar,date("Y/m/d H:i:s")."-".$juguete->ToString()."\n");
    fclose($ar);
    echo "juguete agregado";
}
else {
    echo "no se pudo agregar";
}

?>