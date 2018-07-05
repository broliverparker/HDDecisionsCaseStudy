<?php 

$mysqli = mysqli_connect("mysql.pipeten.co.uk","oliverx_user1","Parker118","oliverx_finalyearproject");

$name = $_POST['name'];
$result = $_POST['result'];
$outcome = $_POST['outcome'];

mysqli_query($mysqli,"INSERT INTO hddecisions(name, result, outcome) VALUES ('$name', '$result', '$outcome')")or die(mysqli_error($mysqli));
echo "Insert Successfull";
?>