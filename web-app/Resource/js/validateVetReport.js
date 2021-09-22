function validateReport() {
    
    var status = document.forms["myForm"]["status"].value;
    var note = document.forms["myForm"]["note"].value;
    var date = document.forms["myForm"]["date"].value;


    if (date == "") {
        alert("date must be filled out");
        return false;
    }
   

  

    if (status == "") {
        alert("Status must be filled out");
        return false;
    }
    if (note == "") {
        alert("Note must be filled out");
        return false;
    }

}