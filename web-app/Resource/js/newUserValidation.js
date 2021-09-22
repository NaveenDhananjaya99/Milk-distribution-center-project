function validateNewUser(){
    var name = document.forms["myForm"]["name"].value;
    var Address = document.forms["myForm"]["Adress"].value;
    var Email = document.forms["myForm"]["Email"].value;
    var number = document.forms["myForm"]["number"].value;
  
   
    
    if (name == "") {
        alert("Name must be filled out");
        return false;

    }

    if (Address == "") {
        alert("Address must be filled out");
        return false;
    }
    if (Email == "") {
        alert("Email must be filled out");
        return false;
    }
   

    if (number == "") {

        alert("mobile number must be filled out");
        return false;

    } else {

        if (isNaN(number)) {

            alert("please input valide mobile number");
        }
        if (number.length != 10) {


            alert("Number length is short");
            return false;
        } else {
            var str = number;
            var res = str.charAt(str.length - 10);
            if (res != "0") {

                alert("please start with 0");

                return false;

            }
        }



    }


   
}

function validatelogin() {
    
    var password = document.forms["loginform"]["password"].value;
    var Email = document.forms["loginform"]["email"].value;
   



    if (email == "") {
        alert("Email must be filled out");
        return false;
    }
    if (password == "") {
        alert("password must be filled out");
        return false;
    }
}