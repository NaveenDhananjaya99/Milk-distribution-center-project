<?php ?>
<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>admin</title>
    <link rel="stylesheet" href="../vendors/css/normalize.css">
  
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Open+Sans&family=Source+Sans+Pro&display=swap" rel="stylesheet">
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Shadows+Into+Light&display=swap" rel="stylesheet">
    <link rel="stylesheet" href="../vendors/css/7.1 Grid.css">
    <link rel="stylesheet" href="../vendors/css/ionicons.min.css">
    <link rel="stylesheet" href="../Resource/css/header.css">
    <!-- <link rel="stylesheet" href="../Resource/css/unsubscribedUser.css"> -->
    <link rel="stylesheet" href="../Resource/css/animation.css">
    <link rel="stylesheet" href="../Resource/css/commenCssForUSubscribedAndSubscribed.css">



    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>

    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>


    <!-- ------------------------------------------------------pie chart----------------------------------- -->
    <script type="text/javascript">
        google.charts.load('current', {
            'packages': ['corechart']
        });
        google.charts.setOnLoadCallback(drawChart);

        function drawChart() {

            var data = google.visualization.arrayToDataTable([
                ['Task', 'Hours per Day'],
                ['Work', 11],
                ['Eat', 2],
                ['Commute', 2],
                ['Watch TV', 2],
                ['Sleep', 7]
            ]);

            var options = {
                title: 'My Daily Activities'
            };

            var chart = new google.visualization.PieChart(document.getElementById('piechart'));

            chart.draw(data, options);
        }
    </script>

    <!--    --------------------------------------bar chart------------------------------------------------ -->
    <script type="text/javascript">
        google.charts.load("current", {
            packages: ["corechart"]
        });
        google.charts.setOnLoadCallback(drawChart);

        function drawChart() {
            var data = google.visualization.arrayToDataTable([
                ["Element", "Density", {
                    role: "style"
                }],
                ["baddegama", 8.94, "#b87333"],
                ["labuduwa", 10.49, "silver"],
                ["ambalangoda", 19.30, "gold"],
                ["habaraduwa", 21.45, "color: #e5e4e2"]
            ]);

            var view = new google.visualization.DataView(data);
            view.setColumns([0, 1, {
                    calc: "stringify",
                    sourceColumn: 1,
                    type: "string",
                    role: "annotation"
                },
                2
            ]);

            var options = {
                title: "Density of Precious Metals, in g/cm^3",
                width: 600,
                height: 400,
                bar: {
                    groupWidth: "95%"
                },
                legend: {
                    position: "none"
                },
            };
            var chart = new google.visualization.BarChart(document.getElementById("barchart_values"));
            chart.draw(view, options);
        }
    </script>

    <!-- -------------------calender chart----------------------------------------------------- -->

    <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
    <script type="text/javascript">
        google.charts.load("current", {
            packages: ["calendar"]
        });
        google.charts.setOnLoadCallback(drawChart);

        function drawChart() {
            var dataTable = new google.visualization.DataTable();
            dataTable.addColumn({
                type: 'date',
                id: 'Date'
            });
            dataTable.addColumn({
                type: 'number',
                id: 'Won/Loss'
            });
            dataTable.addRows([
                [new Date(2012, 3, 13), 37032],
                [new Date(2012, 3, 14), 38024],
                [new Date(2012, 3, 15), 38024],
                [new Date(2012, 3, 16), 38108],
                [new Date(2012, 3, 17), 38229],
                // Many rows omitted for brevity.
                /*  [new Date(2013, 9, 4), 38177],
                 [new Date(2013, 9, 5), 38705],
                 [new Date(2013, 9, 12), 38210],
                 [new Date(2013, 9, 13), 38029],
                 [new Date(2013, 9, 19), 38823],
                 [new Date(2013, 9, 23), 38345],
                 [new Date(2013, 9, 24), 38436],
                 [new Date(2013, 9, 30), 38447] */
            ]);

            var chart = new google.visualization.Calendar(document.getElementById('calendar_basic'));

            var options = {
                title: "Red Sox Attendance",
                height: 350,
            };

            chart.draw(dataTable, options);
        }
    </script>
    <link rel="stylesheet" href="../Resource/css/admin.css">

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
                            <li> <a href="#section-city"> add news</a> </li>

                        </ul>
                    </div>
                </nav>
                <div class="hero-text-box">
                    <h1>Goodbye junk food.</h1>

                </div>
            </div>
        </div>

    </header>



    <section class="summry  animation ">

        <div class="row">
            <h2> summery </h2>
        </div>

        <div class="row">
            <div id="piechart" class="piechart"></div>
        </div>






    </section>


    <section class="animation">
        <div class="row">
            <div id="barchart_values" class="barchart_values"></div>
        </div>

    </section>


    <section class="animation">

        <div class="row">
            <div id="calendar_basic" class="calendar_basic"></div>
        </div>
    </section>


    <section class="add-news">
        <div class="row">
            <h2> add news here </h2>
        </div>
        <form action="#" onsubmit="return validateFormlogin()" method="post" class="contact-form" name="myForm">
            <div class="row">
                <div class="col span-1-of-3">
                    <label for="Headding">Headding</label>
                </div>
                <div class="col span-2-of-3">
                    <input type="text" id="Headding" placeholder="Headding" name="Headding">
                </div>
            </div>



            <div class="row">
                <div class="col span-1-of-3">
                    <label for="news-body">News-body</label>
                </div>
                <div class="col span-2-of-3">
                    <textarea type="textarea" name="news-body" placeholder="Add the content"></textarea>
                </div>
            </div>

            <div class="row">
                <div class="col span-1-of-3">
                    <label for="exp-date">expire-date</label>
                </div>
                <div class="col span-2-of-3">
                    <input type="date" name="exp-date" placeholder="exp-date">
                </div>
            </div>

            <div class="row">
                <div class="col span-1-of-3">
                    <label>&nbsp;</label>
                </div>
                <div class="col span-2-of-3">
                    <input type="submit" value="Submit" name="submit" class="submit">
                </div>
            </div>
        </form>

    </section>
    <div id="section-city"></div>

    <section class="add-news">
        <div class="row">
            <h2> change packge deatils here</h2>
        </div>
        <form action="#" onsubmit="return validateFormlogin()" method="post" class="contact-form" name="myForm">
            <div class="row">
                <div class="col span-1-of-3">
                    <label for="Headding">Headding</label>
                </div>
                <div class="col span-2-of-3">
                    <input type="text" id="Headding" placeholder="Headding" name="Headding">
                </div>
            </div>



            <div class="row">
                <div class="col span-1-of-3">
                    <label for="news-body">liter price</label>
                </div>
                <div class="col span-2-of-3">
                    <textarea type="textarea" name="news-body" placeholder="liter price"></textarea>
                </div>
            </div>

            <div class="row">
                <div class="col span-1-of-3">
                    <label for="exp-date">package type</label>
                </div>
                <div class="col span-2-of-3">
                    <input type="text" name="package tpye" placeholder="package tpye">
                </div>
            </div>

            <div class="row">
                <div class="col span-1-of-3">
                    <label>&nbsp;</label>
                </div>
                <div class="col span-2-of-3">
                    <input type="submit" value="Submit" name="submit" class="submit">
                </div>
            </div>
        </form>

    </section>


    <script src="../Resource/js/animationHomeElements.js"></script>

</body>

</html>