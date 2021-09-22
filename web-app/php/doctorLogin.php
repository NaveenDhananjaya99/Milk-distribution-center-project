<?php

include("db.php");
session_start();
$today = date("Y-m-d");



if (isset($_POST['submit'])) {
    $uname = $_POST['email'];
    $Password = $_POST['password'];

    $query = "select * from `veterinarian` where email='" . $uname . "'AND password='" . $Password . "' limit 1";
    $result = mysqli_query($con, $query);

    if (mysqli_num_rows($result) == 1) {
        $row = mysqli_fetch_assoc($result);
        $_SESSION['v_email'] = $row['Email'];
        $_SESSION['v_password'] = $row['password'];
        $_SESSION['V_NIC'] = $row['V_NIC'];
        $_SESSION['v_name'] = $row['V_NAME'];
        $_SESSION['v_address'] = $row['ADDRESS'];
        $_SESSION['v_mobile'] = $row['MOBILE_NO'];
      
        header("location: doctor.php");
    
    } else {
        echo " <script> alert(' something went wrong !!!!!   please checked email or password ')</script>";
    }
}



?>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width , initial-scale=1.0">
    <link rel="stylesheet" href="https://pro.fontawesome.com/releases/v5.10.0/css/all.css" integrity="sha384-AYmEC3Yw5cVb3ZcuHtOA93w35dYTsvhLPVnYs9eStHfGJvOvKxVfELGroGkvsg+p" crossorigin="anonymous" />
    <link rel="stylesheet" href="../Resource/css/login.css">
    <link rel="stylesheet" href="../vendors/css/normalize.css">

    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Open+Sans&family=Source+Sans+Pro&display=swap" rel="stylesheet">
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Shadows+Into+Light&display=swap" rel="stylesheet">
    <link rel="stylesheet" href="../vendors/css/7.1 Grid.css">
    <link rel="stylesheet" href="../vendors/css/ionicons.min.css">
    <!--   <link rel="stylesheet" href="/Resource/css/index.css"> -->
    <title>vet_login </title>




</head>

<body>


?>

    <div class="container">
        <div class="signin-sign-up">

            <form action="#" method="POST" name="loginform" onsubmit="validatelogin()" class="sign-in-form">
                <h2 class="title">Sign in </h2>
                <div class="input-field">
                    <i class="fas fa-user"> </i>
                    <input type="email" name="email" placeholder="Email">

                </div>

                <div class="input-field">
                    <i class="fas fa-lock"> </i>
                    <input type="password" placeholder="password" name="password">

                </div>
                <a href="#" class=" frogot-password"> Frogot password </a>
                <input type="submit" name="submit" value="Login " class="btn">

                
                <h2 class="title"><a href="../Html/index.html"> back to home </a> </h2>
            </form>





        </div>
        <script src="app.js"></script>
    </div>


    <section class="section-img">



  


    </section>
</body>

</html>