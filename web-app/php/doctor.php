<?php
 include 'db.php';
session_start();
$query = "SELECT * FROM `medical issue` INNER JOIN `dairy farmer` ON`dairy farmer`.`F_ID`=`medical issue`.`F_ID` WHERE V_ID= '" . $_SESSION['V_NIC'] . "' ";
$result = mysqli_query($con, $query);


if (isset($_POST['submit'])) {
    $date = $_POST['date'];
    $note = $_POST['note'];
    $status = $_POST['status'];
    $m_id = $_POST['m_id'];

  

    $query = "INSERT INTO `veterinary report`(`R_ID`, `M_ID`, `R_DATE`, `VETERINARY_NOTE`, `STATUS`) VALUES ('','" . $m_id . "','" .  $date . "','" . $note. "','" .$status. "') ";
    $result = mysqli_query($con, $query);

    if(!$result)
    {
      /*   die("NO query"); */
        echo " <script> alert('PLEASE RE TRY')</script>";
        echo $date,$note ,$status,$m_id ;
    }
	else{

        $update_query = "UPDATE `medical issue` SET `status`='finished' WHERE `M_ID`='" . $m_id . "'";
        $update_result = mysqli_query($con, $update_query);



        echo " <script> alert('SUCESSSFULL')</script>";
        
    header("location:doctor.php"); 
    }
}


if (isset($_POST['hold'])) {
   
    $m_id = $_POST['m_id'];
  

    $update_query = "UPDATE `medical issue` SET `status`='hold' WHERE `M_ID`='" . $m_id . "'";
    $update_result = mysqli_query($con, $update_query);


    if(!$result)
    {
      /*   die("NO query"); */
        echo " <script> alert('PLEASE RETRY')</script>";
        
    }
	else{

    echo " <script> alert('SUCESSSFULL')</script>";
        
    header("location:doctor.php"); 
    }
} 

?>



<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>doctor</title>
    <link rel="stylesheet" href="../vendors/css/normalize.css">
    <link rel="stylesheet" href="resources/css/stylelogin.css">
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Open+Sans&family=Source+Sans+Pro&display=swap" rel="stylesheet">
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Shadows+Into+Light&display=swap" rel="stylesheet">
    <link rel="stylesheet" href="../vendors/css/7.1 Grid.css">
    <link rel="stylesheet" href="../vendors/css/ionicons.min.css">
    <link rel="stylesheet" href="../Resource/css/header.css">
    <link rel="stylesheet" href="../Resource/css/doctor1.css">
    <link rel="stylesheet" href="../Resource/css/commenCssForUSubscribedAndSubscribed.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.1/css/all.min.css">

    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script src="../Resource/js/pieChart.js"></script>
    <script src="../Resource/js/barChart.js"></script>
    <link rel="stylesheet" href="../Resource/css/popup.css">

    <!--   <link rel="stylesheet" href="../sample/s1.css"> -->


</head>

<body>
    <header>
        <div class="slider">
            <div class="load">
            </div>
            <div class="containt">
                <nav>
                    <div class="row">
                        <div class="Hlogo">
                            <a href="home.php">
                                <img src="../Resource/image/logo.png" alt="logo" class="logo" width="200px">
                            </a>
                        </div>
                        <ul class="main-nav">

                            <li> <a href="../php/login.php"> log out</a> </li>
                            <li> <a href=""> account</a> </li>

                        </ul>
                    </div>
                </nav>
                <div class="hero-text-box">
                    <h1>We care for them all, great and small.</h1>


                </div>


    </header>
    <div class="second-nav">
        <ul class="secondd-nav-ul">

            <li> <a href="#">pending</a> </li>
            <li> <a href="../php/doctorHoldReport.php"> hold</a> </li>
            <li> <a href="../php/doctorFinishedReport.php"> finishd</a> </li>
        </ul>
    </div>

    <section class="to-dos">
        <div class="row">
            <h2> summery </h2>
        </div>
        <div class="row">
            <div class="col span-1-of-2">


                <div id="piechart_3d" class="piechart"></div>

            </div>
            <div class="col span-1-of-2">


                <div id="columnchart_values" class="columnchart"></div>


            </div>
        </div>


    </section>





    <div class="row">
        <h2> Active medical issues </h2>
    </div>


    <section>



        <?php

        if ($result) {

            while ($row = mysqli_fetch_assoc($result)) {

if($row['status']==''){





                echo "

                            

        <div class='col span-1-of-2 row '>
                <div class='detail-box'>
                    <div class='hedding'>
                        <h4>date </h4> 
                        <p> " . $row['M_DATE'] . "</p>
                    </div>
                    <div class='hedding'>
                        <h4>discription </h4>
                    </div>
                    <div>
                        <p>
                        " . $row['M_DESCRIPTION'] . "
                        </p>
                       
                    </div>
                    <div class='hedding'>
                        <h4>vanue </h4>
                    </div>

                    <div>

                    <p>
                    " . $row['F_ADDRESS'] . "
                    </p>
                    </div>

                    <div class='hedding'>
                        <h4>famer name </h4>
                        <p>
                        " .    $row['F_Name'] . "
                        </p>
                    </div>
                    <div class='hedding'>
                        <h4>contact number</h4>
                        <p>
                        " . $row['MOBILE_NO'] . "
                        </p>
                        <p>
                        " .    $row['TP_NO'] . " 
                        </p>
                    </div>
                    <form action='#' method='POST'><input type='submit' name='hold' class='btn btn-full' value='set as a hold'>
                       <input type='hidden' id='m_id'  name='m_id'  value= '" . $row['M_ID'] . "'> </form>
                    <div class='btn-in-vet'>

                        <a class='btn popup-btn'>Submit report</a>

                    </div>




                    <div class='popup-view'>
                        <div class='popup-card'>
                            <a><i class='btn fas fa-times close-btn'></i></a>

                            <div class='info'>
                                <h2>Submit the report<br></h2>



                                <div class='row'>


                                    <form action='#' onsubmit='return validateReport()' method='post' class='contact-form' name='myForm'>





                                        <div class='row'>
                                            <div class='col span-1-of-2'>
                                                <label for='date'>DATE</label>
                                            </div>
                                            <div class='col span-1-of-2'>
                                                <input type='date' id='date' placeholder='date' name='date' required>
                                            </div>
                                        </div>


                                        <div class='row'>
                                            <div class='col span-1-of-2'>
                                                <label for='note'>VETERINARY_NOTE</label>
                                            </div>
                                            <div class='col span-1-of-2'>

                                                <textarea type='textarea' name='note' id='note' placeholder='note' required>        </textarea>
                                            </div>
                                        </div>



                                        <div class='row'>
                                            <div class='col span-1-of-2 status'>
                                                <label for='status'>STATUS</label>
                                            </div>
                                            <div class='col span-1-of-2'>
                                                <input type='text' id='status' placeholder='current status' name='status'>
                                            </div>
                                        </div>




                                        <input type='hidden' id='m_id'  name='m_id'  value= '" . $row['M_ID'] . "'>
                                       



                                        <div class='row'>
                                            <div class='col span-1-of-3'>
                                                <label>&nbsp;</label>
                                            </div>
                                            <div class='col span-2-of-3'>
                                                <input type='submit' name='submit' class='btn btn-full' value='submit'>
                                            </div>
                                        </div>



                                    </form>


                                </div>





                                <!--  <a href='#' class='add-cart-btn'>Submit</a> -->

                                        </div>
                                          </div>
                                   </div>


                                </div>

                             </div>
                            </div>   

                            </div>  


        ";
    }
}
        } else {
            echo " <script> alert('result set wel na ')</script>";
        }

 

        ?>
    </section>


    <script src="../Resource/js/popup.js"></script>
    <script src="../Resource/js/validateVetReport.js"></script>
</body>

</html>