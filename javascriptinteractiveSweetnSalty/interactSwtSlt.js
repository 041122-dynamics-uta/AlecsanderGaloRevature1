
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

// var el = document.getElementById("start");
// el.addEventListener("keydown", function(e) {
//     if (e.key === "Enter") {
//         e.preventDefault();
//         document.getElementById("btn3").click();
//     }
// });

// document.getElementById("start").addEventListener("keypress", function(e){ //this eventlistener and function lets user press enter as an alternative to clicking submit
//     if (e.key === "Enter")
//     {
//         e.preventDefault();
//         document.getElementById("btn3").click();
//     }
// })

var input1, input2; //declare but don't assign yet; assign in function to avoid error with values coming out null or undefined
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
    else document.getElementById("err1").append('Number cannot be negative');
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
        document.getElementById("thirdPrompt").style.display = "block"
        console.log(input2)

    }
    else document.getElementById("err2").append('Your inputs must be at least 200 and no more than 10000 apart. Your second input must be greater than your first.')

}

function startFunc()
{ //LEFT OFF: now just trying to get enter to work
    console.log("success");

    function MultipleOf(x, n) //method returns a bool, (true)multipleOf or (false)not a multipleOf
{ if(x == n){ return true; } // int n will either be 3 or 5, the numbers we are checking multiples of.
                            // So this if x==n statement in the method ensures that int n =3 and =5 can be included as multiples
                            
else return (x % n) == 0;   // else return T/F whether the iteration of list is divisible by the given 3 or 5; this is what will be returned in most cases
}  


var swtCount = 0; //these three variables will tally++ our instances of each 'Sweet' 'Salty' and 'Sweet'nSalty'
var sltCount = 0;
var swtnsltCount = 0;

var in1 = parseInt(input1);
var in2 = parseInt(input2);
    var array = [];
    arrayLength = in2-in1+1;
    console.log(arrayLength)
    for(var x = 0; x<arrayLength; x++)
    {  
        array[x] = in1 + x;
        console.log(array[x]);
    }

    for (var i = 0; i < arrayLength; i++) { //first iterator
            
        var twentypoint = new Array(40); //second array to count and print 40 point[i]'s at a time
         for (var k = 0; k<40; k++, i++) //nested iterator; NOTE: we increment both j++ and i++ in this iterator to populate twentypoint[j] with items from points[i]

         {   //the following if/elseif statements run our above-declared method to determine multiples and if we are printing sweet/salty/sweetnsalty/just the number 
             if (MultipleOf(array[i], 3) == true && MultipleOf(array[i], 5) == false) 
             {  //var result = {"type" : "text", "content" : "Sweet", "font" : {"color" : "green"}}
                //var json = JSON.stringify(result);
                 
                 twentypoint[k] = '<span class="color">Sweet</span>';                                  //note that the method compares each instance of points[i] to determine twentypoint[j]
                 swtCount++;
             }
             else if (MultipleOf(array[i], 5) == true && MultipleOf(array[i], 3) == false)
             {
                 twentypoint[k] = '<span class="color">Salty</span>';
                 sltCount++;                                                     //also note each condition has a Count++ for the respective instance of sweet/salty/both
             }
             else if(MultipleOf(array[i], 3) == true && MultipleOf(array[i], 5) == true)
             {
                 twentypoint[k] = `<span class="color">Sweet'nSalty</span>`;
                 swtnsltCount++;
             }
             else
             {twentypoint[k] = array[i];}  //else -- if not a multiple of 3 or 5, we just assign the regular number in points[i] to twentypoint[j] in this case
             
         }
             i = (i - 1); //subtract one from i after this second loop completes because i gets iterated a second time when re-entering the main for loop
                         //this is a solution to a side effect of having i++ in both for loops; you exit the second loop and i++ happens again in going back to the original for loop


             
         
         //console.log(twentypoint.join(' ')); //Print concatenated twentyPoint array with join(); thanks to our second for loop, this will have 20 items per console log each time the flow of control reaches this point
                                             //directions say "Use string concatenation to print the 20-number strings to the console at a time" 
                                             //so we aren't making new lines, we are printing 20 and then repeating the process with the next 20 in points[] until complete
         
        var tag = document.createElement("p");
        //var answer = document.createTextNode(twentypoint.join(' '));
        var answer = twentypoint.join(' ');
       
        tag.innerHTML = answer;
        var element = document.getElementById("answer");
        element.appendChild(tag);
        //element.innerHTML = answer;

 }

 console.log(`There were ${swtCount} instances of Sweet `); //present our tallies of each instance; each was incremented in their respective conditional statements
 console.log(`There were ${sltCount} instances of Salty`);
 console.log(`There were ${swtnsltCount} instances of Sweet'nSalty`);
}


//let firstnum = prompt("Please enter the beginning number of the range");