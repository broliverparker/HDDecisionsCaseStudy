<?php  
//PDO is a extension which  defines a lightweight, consistent interface for accessing databases in PHP.  
$db = new PDO('mysql:host=mysql.pipeten.co.uk;dbname=oliverx_finalyearproject', 'oliverx_user1', 'Parker118');
//here prepare the query for analyzing, prepared statements use less resources and thus run faster  
$row=$db->prepare('SELECT * FROM hddecisions');  
  
$row->execute();//execute the query  
$json_data=array();//create the array  
foreach($row as $rec)//foreach loop  
{  
    $json_array['ID']=$rec['ID'];  
    $json_array['Name']=$rec['Name'];  
    $json_array['Result']=$rec['Result'];
    $json_array['Outcome']=$rec['Outcome'];
//here pushing the values in to an array  
    array_push($json_data,$json_array);  
  
}  
  
//built in PHP function to encode the data in to JSON format  
echo json_encode($json_data);  
  
  
?>  