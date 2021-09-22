  const conten = document.getElementsById("content");
  const bttn = document.getElementsByClassName('.btn').onClick;

  function changeContentDiv1() {
      /*  document.getElementById("content").classList.remove("content"); */

      document.getElementById("div1").classList.add("show1");
      document.getElementById("div2").classList.add("show4");
      document.getElementById("div3").classList.add("show4");

  } /* .toggle(".show1"); */


  function changeContentDiv2() {
      /*  document.getElementById("content").classList.remove("content"); */

      document.getElementById("div2").classList.remove("show4");
      document.getElementById("div1").classList.add("show4");
      document.getElementById("div3").classList.add("show4");

  }


  function changeContentDiv3() {
      /*  document.getElementById("content").classList.remove("content"); */

      document.getElementById("div3").classList.remove("show4");
      document.getElementById("div1").classList.add("show4");
      document.getElementById("div2").classList.add("show4");

  }