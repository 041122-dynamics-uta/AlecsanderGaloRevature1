
document.getElementById("firstnum").addEventListener("keypress", function(e){ //this eventlistener and function lets user press enter as an alternative to clicking submit
    if (e.key === "Enter")
    {
        e.preventDefault();
        document.getElementById("btn1").click();
    }
})
document.getElementById("secondnum").addEventListener("keypress", function(e){ //this eventlistener and function lets user press enter as an alternative to clicking submit
    if (e.key === "Enter")
    {
        e.preventDefault();
        document.getElementById("btn2").click();
    }
})
document.getElementById("btn3").addEventListener("keypress", function(e){ //this eventlistener and function lets user press enter as an alternative to clicking submit
    if (e.key === "Enter")
    {
        e.preventDefault();
        document.getElementById("btn3").click();
    }
})

var input1, input2;
function buttonFunc()

{   
    
    let errmessage = []
    input1 = document.getElementById("firstnum").value;
    console.log(input1);
    if (input1 >= 0)
    {
    document.getElementById("err1").innerHTML = '';
    //firstinput1 = document.getElementById("firstnum");
    document.getElementById("secondPrompt").style.display = "block"
    }
    else document.getElementsById("err1").append('Number cannot be negative');
    //errmessage.push("Number cannot be negative")
    //console.log(input1);

}

function buttonFunc2()
{
    input2 = document.getElementById("secondnum").value
    //console.log(input2-input1);
    if (input2 > input1 && input2-input1>200 && input2-input1<10000)
    {
        document.getElementById("err2").innerHTML = '';


    }
    else document.getElementById("err2").append('Your inputs must be at least 200 and no more than 10000 apart. Your second input must be greater than your first.')

}

function startFunc()
{ //LEFT OFF: just need to add hide a things and color by class; then we can work on the function itself
    //also working on the press enter to start function issue
    console.log("success");

}


//let firstnum = prompt("Please enter the beginning number of the range");