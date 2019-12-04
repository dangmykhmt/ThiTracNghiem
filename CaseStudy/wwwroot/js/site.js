
// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.




//setTime.js
//var countDownDate = new Date().getTime() + 4.5 * 60200;
var countDownDate = new Date().getTime() + 4.5 * 10200;
var x = setInterval(function () {
    var now = new Date().getTime();
    var distance = countDownDate - now;
    var days = Math.floor(distance / (1000 * 60 * 60 * 24));
    var hours = Math.floor((distance % (1000 * 60 * 60 * 24)) / (1000 * 60 * 60));
    var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
    var seconds = Math.floor((distance % (1000 * 60)) / 1000);
    document.getElementById("demo").innerHTML =
        +minutes + ":" + seconds;
    if (distance < 0) {
        clearInterval(x);
        document.getElementById("myForm").submit();
    }
}, 1000);


//creata table
txt = ""
for (var i = 1; i <= 50; i++) {
    txt += "<button ";
    txt += "id = \"but" + i + "\"" + " onclick = \"changeColor(" + i + ")\">" + i
    txt += "</button>"
}
document.getElementById("right1_3").innerHTML = txt;


//change - color:
function changeColor(value) {
    switch (value) {
        case value:
            document.getElementById("but" + value).style.backgroundColor = "green";

    }
}

//set Color: Dap an nao chon thi doi thanh 1

function setAnswer(value) {
    switch (value) {
        case value:
            // alert(value)
            document.getElementById("but" + value).style.backgroundColor = "red";
            break;
    }

}