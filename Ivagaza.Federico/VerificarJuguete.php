<?php


require_once "clases/Juguete.php";

$juguete=new Juguete($_GET['tipo'],6,$_GET['pais']);
$lista=$juguete->Traer();
$mensaje="No existe el tipo ni el pais";
foreach($lista as $value)
{
    if($value['tipo']==$_GET['tipo'] && $value['pais']==$_GET['pais'])
    {
        $lamparita=new Juguete($value['tipo'],$value['precio'],$value['pais'],$value['foto']);
        $mensaje=$lamparita->ToString()." precio total=".$lamparita->CalcularIva();
        break;
    }
    else{
        if($value['tipo']==$_GET['tipo']) {
            $mensaje="Existe tipo pero no pais";
        }
        if($value['pais']==$_GET['pais']) {
            $mensaje="Existe pais pero no tipo";
        }
    }
}
echo $mensaje;