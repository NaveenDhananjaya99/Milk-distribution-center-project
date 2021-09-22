
<?php 
 include("db.php");
 session_start();


 


if (isset($_POST['submit']) )
{
   
     $uname=$_POST['name'];
    $Password=$_POST['pwd'];
    $Email=$_POST['Email'];
    $Adress= $_POST['Adress']; 
    $Number= $_POST['number']; 
    

    $query = "select * from logindetails where email='" .  $Email . "' limit 1 ";
    $resultq = mysqli_query($con, $query);
   
      
       
       
      
        $query = "INSERT INTO logindetails (email,password,name,address,mobile) VALUES ('".$Email."', '".$Password."','".$uname."','".$Adress."', '".$Number."')";
        $result = mysqli_query($con,$query);

        if(!$result)
        {
         
           echo " <script> alert('connection faild')</script>";
           header("location:createNewAccount.php");
        }
       else{
           echo " <script> alert('email is alredy taken plese try another email')</script>";
         
        header("location:login.php"); 
         }  mysqli_close($connection);	 
    

 
}else{
 
}



?>


<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>food</title>
    <link rel="stylesheet" href="vendors/css/normalize.css">
    <link rel="stylesheet" type="text/css" href="resources/css/style.css">
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Open+Sans&family=Source+Sans+Pro&display=swap" rel="stylesheet">
    <link rel="stylesheet" href="vendors/css/7.1 Grid.css">
    <link rel="stylesheet" href="vendors/css/ionicons.min.css">
    <link rel="stylesheet" href="../Resource/css/header.css">
    <link rel="stylesheet" href="../Resource/css/createNewUser.css">


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

                            <li> <a href="../php/login.php"> log in</a> </li>
                            <li> <a href="../Html/index.html"> home</a> </li>

                        </ul>
                    </div>
                </nav>

            </div>
        </div>


        <div class="row">
            <div class="row">
                <h1>Sign Up</h1>
            </div>


        </div>


        <form action="#" onsubmit="validateNewUser()" method="post" class="contact-form" name="myForm">
            <div class="row">
                <div class="col span-1-of-3">
                    <label for="name">Name</label>
                </div>
                <div class="col span-2-of-3">
                    <input type="text" id="name" placeholder="Your name" name="name">
                </div>
            </div>

            <div class="row">
                <div class="col span-1-of-3">
                    <label for="Password">Password</label>
                </div>
                <div class="col span-2-of-3">
                    <input type="Password" name="pwd" id="pp" placeholder="Passwords">
                </div>
            </div>

            <div class="row">
                <div class="col span-1-of-3">
                    <label for="Email">Email</label>
                </div>
                <div class="col span-2-of-3">
                    <input type="Email" name="Email" placeholder="Email">
                </div>
            </div>

            <div class="row">
                <div class="col span-1-of-3">
                    <label for="message">Address</label>
                </div>
                <div class="col span-2-of-3">
                    <textarea type="Adress" name="Adress" placeholder="Adress"></textarea>
                </div>
            </div>

            <div class="row">
                <div class="col span-1-of-3">
                    <label for="phone num">Mobile Number</label>
                </div>
                <div class="col span-2-of-3">
                    <input type="Mobile" name="number" placeholder="Mobile Number">
                </div>
            </div>

            <h4>* Don't Use Your Real Details</h4>
            <div class="row">
                <div class="col span-1-of-3">
                    <label>&nbsp;</label>
                </div>
                <div class="col span-2-of-3">
                    <input type="submit" value="Submit" name="submit" class="submit">
                </div>
            </div>
        </form>

    </header>

    <section class="form"></section>


    <footer>
        <div class="row">
            <div class="col span-1-of-2">
                <ul class="footer-nav">
                    <li><a href="#"> About us </a></li>
                    <li><a href="#"> Blog </a></li>
                    <li><a href="#"> Press </a></li>
                    <li><a href="#"> iOS App </a></li>
                    <li><a href="#"> Android App </a></li>
                </ul>
            </div>

            <div class="col span-1-of-2">
                <ul class="social-links">
                    <li>
                        <a href="#"> <i class="ion-social-facebook"></i></a>
                    </li>
                    <li>
                        <a href="#"> <i class="ion-social-twitter"></i></a>
                    </li>
                    <li>
                        <a href="#"> <i class="ion-social-googleplus"></i></a>
                    </li>
                    <li>
                        <a href="#"> <i class="ion-social-instagram"></i></a>
                    </li>
                </ul>
            </div>
        </div>

        <div class="row">
            <p>
                copyright &copy; 2020 by fooddil. All right reserved.
            </p>
        </div>
    </footer>


    
    <script src="../Resource/js/newUserValidation.js"></script>
</body>

</html>

