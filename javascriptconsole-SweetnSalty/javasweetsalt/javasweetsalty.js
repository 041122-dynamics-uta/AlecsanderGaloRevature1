function MultipleOf(x, n) //method returns a bool, (true)multipleOf or (false)not a multipleOf
{ if(x == n){ return true; } // int n will either be 3 or 5, the numbers we are checking multiples of.
                            // So this if x==n statement in the method ensures that int n =3 and =5 can be included as multiples
                            
else return (x % n) == 0;   // else return T/F whether the iteration of list is divisible by the given 3 or 5; this is what will be returned in most cases
}  


var swtCount = 0; //these three variables will tally++ our instances of each 'Sweet' 'Salty' and 'Sweet'nSalty'
var sltCount = 0;
var swtnsltCount = 0;


var points = new Array(1000); //create our array
        for (var i = 0; i < 1000; i++) {
            points[i] = i + 1; //Populate the array with this initial loop; add +1 to i to compensate for 0 index
        }

        //GENERAL LOGIC: inside of our first iterator for points[i], we establish a second nested array twentypoint[j] with a maximum of 20 to help us print 20 points[i]'s at a time
                            //we will populate this second array using the data from first array points[i] and also make the appropriate conditionals for multiples of 3/5/both
        
        for (var i = 0; i < 1000; i++) { //first iterator
            
               var twentypoint = new Array(20); //second array to count and print 20 point[i]'s at a time
                for (var j = 0; j<20; j++, i++) //nested iterator; NOTE: we increment both j++ and i++ in this iterator to populate twentypoint[j] with items from points[i]

                {   //the following if/elseif statements run our above-declared method to determine multiples and if we are printing sweet/salty/sweetnsalty/just the number 
                    if (MultipleOf(points[i], 3) == true && MultipleOf(points[i], 5) == false) 
                    {
                        twentypoint[j] = "Sweet";                                       //note that the method compares each instance of points[i] to determine twentypoint[j]
                        swtCount++;
                    }
                    else if (MultipleOf(points[i], 5) == true && MultipleOf(points[i], 3) == false)
                    {
                        twentypoint[j] = "Salty";
                        sltCount++;                                                     //also note each condition has a Count++ for the respective instance of sweet/salty/both
                    }
                    else if(MultipleOf(points[i], 3) == true && MultipleOf(points[i], 5) == true)
                    {
                        twentypoint[j] = "Sweet'nSalty"
                        swtnsltCount++;
                    }
                    else
                    {twentypoint[j] = points[i];}  //else -- if not a multiple of 3 or 5, we just assign the regular number in points[i] to twentypoint[j] in this case
                    
                }
                    i = (i - 1); //subtract one from i after this second loop completes because i gets iterated a second time when re-entering the main for loop
                                //this is a solution to a side effect of having i++ in both for loops; you exit the second loop and i++ happens again in going back to the original for loop


                    
                
                console.log(twentypoint.join(' ')); //Print concatenated twentyPoint array with join(); thanks to our second for loop, this will have 20 items per console log each time the flow of control reaches this point
                                                    //directions say "Use string concatenation to print the 20-number strings to the console at a time" 
                                                    //so we aren't making new lines, we are printing 20 and then repeating the process with the next 20 in points[] until complete
                
            
           
        }
        console.log(`There were ${swtCount} instances of Sweet `); //present our tallies of each instance; each was incremented in their respective conditional statements
        console.log(`There were ${sltCount} instances of Salty`);
        console.log(`There were ${swtnsltCount} instances of Sweet'nSalty`);


//DIRECTIONS
//Print the numbers 1 to 1000 to the console. 
// Print the numbers in groups of 20 per line with one space separating each number.  
// HINT: Use string concatenation to print the 20-number strings to the console at a time.  
// When the number is a multiple of three, print “Sweet” instead of the number on the console. 
// If the number is a multiple of five, print “Salty” (instead of the number) to the console.    
// For numbers which are multiples of three and five, print “Sweet’nSalty” to the console (instead of the number).    
// After the numbers have all been printed, print out: 
// How many "Sweet”,  
// how many "Salty”, and  
// how many "Sweet’nSalty".  
// Sweet, Salty, and Sweet’nSalty are three separate groups, so Sweet’nSalty does not increment Sweet or Salty (and vice versa).