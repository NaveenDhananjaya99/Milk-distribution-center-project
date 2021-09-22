<?php
 
$date = date("y/m/d");
/* include  'displayTheplanValues.php'; */ 
function priceForDb($offer){
    $ModifiedPrice=$_SESSION['price']-$offer;
  
    return  number_format($ModifiedPrice, 2, '.', '') ; 
   
}

function package($days,$priceForOneLiter){
    include("db.php");
    
    $date = date("y/m/d");
    // update check krnn ona 

    $query = "UPDATE `logindetails` SET `subscription`='3month' WHERE email='" . $_SESSION['U_email'] . "' limit 1 ";
    $result = mysqli_query($con, $query);
    if ($result) {

        $_SESSION['status'] = "3month";

        $today = date("d");
        $this_month = date("m");
        $year = date("Y");

        for ($i = 0; $i < $days; $i++) {
            $today = $today + 1;
            if ($this_month == 1 || $this_month == 3 || $this_month == 7 || $this_month == 8 || $this_month == 10 || $this_month == 12) {
                if ($today > 31) {
                    $today = 1;

                    $this_month = $this_month + 1;
                }
            } else {
                if ($this_month == 4 || $this_month == 5 || $this_month == 6 || $this_month == 9 || $this_month == 11) {
                    if ($today > 30) {
                        $today = 1;

                        $this_month = $this_month + 1;
                    }
                } else {
                    if ($this_month == 2) {

                        if ($today > 28) {
                            $today = 1;

                            $this_month = $this_month + 1;
                        }
                    } else {
                        $year =  $year + 1;
                        $this_month = 1;
                    }
                }
            }

            $deliverd_date = "$year-$this_month-$today";


            //methnin insert ek 

            $query = "INSERT INTO `orders`(O_ID, O_DATE, O_VOLUME,PRICE, DELEVERY_DATE, CUSTOMER_NAME, CONTACT_NO, ADDRESS, DP_ID,O_STATUS) VALUES ('','" . $date . "','". $_SESSION[' quntityInpackage']."','".$priceForOneLiter."','" . $deliverd_date . "','" . $_SESSION['u_name'] . "','" . $_SESSION['u_mobile'] . "','" . $_SESSION['u_address'] . "','Not Set' ,'pending')";
            $result = mysqli_query($con, $query);
            if (!$result) {
              /*   die("NO query"); */
                echo " <script> alert('email is alredy taken plese try anothe email')</script>";
            }
        }
        $query = "UPDATE `logindetails` SET `Expire_date`='" . $deliverd_date . "' WHERE email='" . $_SESSION['U_email'] . "'
                ";
        $result = mysqli_query($con, $query);
        if (!$result) {
            die("NO query");
        }

        echo " <script> alert('successfully subsribed..')</script>";
       
    }
}

?>
