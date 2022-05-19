var firstinput = document.getElementById("firstnum")
firstinput.addEventListener("keypress", function(e){ //this eventlistener and function lets user press enter as an alternative to clicking submit
    if (e.key === "Enter")
    {
        e.preventDefault();
        document.getElementById("btn1").click();
    }
})
function buttonFunc()
{   firstinput = document.getElementById("firstnum").nodeValue;
    console.log(firstinput);
    let errmessage = []

    if (firstinput >= 0)
    {firstinput = document.getElementById("firstnum");}
    else errmessage.push("Number cannot be negative")

}

function swtSlt()
{
    //let firstnumber = document.getElementById("firstnum");

}


//let firstnum = prompt("Please enter the beginning number of the range");