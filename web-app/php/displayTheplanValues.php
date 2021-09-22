<?php

//session_start();
$ModifiedPrice;

function dbforPrice(){
    include("db.php");
    $query = " SELECT * FROM `prices` WHERE CATEGORY ='Selling' limit 1 ";
    $result = mysqli_query($con, $query);
    
    if (mysqli_num_rows($result) == 1) {
        $row = mysqli_fetch_assoc($result);
        $_SESSION['price'] = $row['PRICE'];
      
    }else{
    
    }
    
}


function plan($offer){
    dbforPrice();
    
    $ModifiedPrice=$_SESSION['price']-$offer;
    echo $ModifiedPrice;
    //use for disply the plans  price in unsubscribed user.php
}




function planCalcaculation($offer,$days){
    dbforPrice();
    $ModifiedPrice=$_SESSION['price']-$offer;
     $total=$ModifiedPrice*$days;
     echo  $total;
     //this use for calcultate the plan's total price in the unsubscribed user.php
}


?>