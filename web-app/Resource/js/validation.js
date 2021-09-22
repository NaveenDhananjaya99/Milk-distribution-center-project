function validateFormOarder() {
    var name = document.forms["myForm"]["name"].value;
    var Address = document.forms["myForm"]["Address"].value;
    var Email = document.forms["myForm"]["Email"].value;
    var number = document.forms["myForm"]["number"].value;
    var date = document.forms["myForm"]["date"].value;
    var quantity = document.forms["myForm"]["quantity"].value;
    
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
    if (date == "") {
        alert("date must be filled out");
        return false;
    }

    if (quantity == "") {
        alert("quantity must be filled out");
    } else {

        if (isNaN(quantity)) {
            alert(" please input correct quntity");
            return false;

        }
     
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




