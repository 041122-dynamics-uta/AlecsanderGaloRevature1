
document.getElementById("firstnum").addEventListener("keypress", function(e){ //this eventlistener and parameter function lets user press enter as an alternative to clicking submit
    if (e.key === "Enter")
    {
        
        document.getElementById("btn1").click();
        e.preventDefault();
        
    }
    
})
document.getElementById("secondnum").addEventListener("keypress", function(e){ 
    if (e.key === "Enter")
    {
       
        document.getElementById("btn2").click();
        e.preventDefault();
    }
   
}) 



function startGame()
{
    document.getElementById("begin1").style.display = "block" //sets display from "none" to "block" to show elements after button press
    document.getElementById("begin2").style.display = "block"
    
}

var input1, input2; //declare but don't assign yet; assign in function to avoid error with values coming out null or undefined
function buttonFunc()

{   
    input1 = document.getElementById("firstnum").value;
    console.log(input1);
    var inp1 = parseInt(input1);
    if (input1 >= 0 && isNaN(inp1) == false)
    {
    document.getElementById("err1").innerHTML = '';
    //firstinput1 = document.getElementById("firstnum");
    document.getElementById("secondPrompt").style.display = "block"
    }
    else
    {   
        document.getElementById("err1").innerHTML = '';
        document.getElementById("err1").append('Input must be a number and cannot be negative');
    }
    //errmessage.push("Number cannot be negative")
    //console.log(input1);

}

function buttonFunc2()
{   
    input2 = document.getElementById("secondnum").value
    var in1 = parseInt(input1);
    var in2 = parseInt(input2);
    //console.log(input2-input1);
    if (in2 > in1 && in2-in1>200 && in2-in1<10000)
    {
        document.getElementById("err2").innerHTML = '';
        document.getElementById("thirdPrompt").style.display = "block"
        //console.log(in2)

    }
    else document.getElementById("err2").append('Your inputs must be at least 200 apart and no more than 10000 apart. Your second input must be greater than your first.')

}

function startFunc()
{ 
    //console.log("success");

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

    for (var i = 0; i < arrayLength; i++) { 
            
        var twentypoint = new Array(40); 
         for (var k = 0; k<40; k++, i++) 

         {   
             if (MultipleOf(array[i], 3) == true && MultipleOf(array[i], 5) == false) 
             {  
                 
                 twentypoint[k] = '<span class="color">Sweet</span>';                                 
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
             else if (i<arrayLength)
             {  var parse = array[i];
                var comma = parseInt(parse);
                var formatted = comma.toLocaleString('en-US');
                twentypoint[k] = formatted; }  //else -- if not a multiple of 3 or 5, we just assign the regular number in points[i] to twentypoint[j] in this case
             
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


        

 }
var p = document.createElement("p");
p.innerText = `There were ${swtCount} instances of Sweet, ${sltCount} instances of Salty, ${swtnsltCount} instances of Sweet'nSalty`;
var finalDiv = document.getElementById("finalcounts");
finalDiv.appendChild(p);


function reset()
{
    location.reload();
}
var ireset = document.createElement("button");
var finalForm = document.getElementById("reset");
ireset.setAttribute("type", "button");
ireset.setAttribute("name", "Reset");
ireset.onclick = reset;
ireset.innerText = 'Reset Game';
finalForm.appendChild(ireset);


 console.log(`There were ${swtCount} instances of Sweet `); 
 console.log(`There were ${sltCount} instances of Salty`);
 console.log(`There were ${swtnsltCount} instances of Sweet'nSalty`);
}


