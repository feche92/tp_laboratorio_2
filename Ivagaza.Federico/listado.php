<?php

require_once "clases/Juguete.php";

$juguete=new Juguete("algo",15,"lala");
$lista=$juguete->Traer();
$tabla="<table border='1'>";
$tabla.="<tr><td>ID</td><td>Tipo</td><td>Precio</td><td>Pais</td><td>Foto</td></tr>";
foreach($lista as $value)
{
    $tabla.="<tr>";
    $tabla.="<td>".$value['id']."</td>";
    $tabla.="<td>".$value['tipo']."</td>";
    $tabla.="<td>".$value['precio']."</td>";
    $tabla.="<td>".$value['pais']."</td>";
    $tabla.="<td><img src='juguetes/imagenes/".$value['foto']."' width='90px' heigth='90px' ></td>";
    $tabla.="</tr>";
}
$tabla.="</table>";

echo $tabla;
//echo json_encode($array);

?>