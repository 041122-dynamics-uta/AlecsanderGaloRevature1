using System;
using System.Collections.Generic;
using System.Linq;

namespace sweetsalty
{
    class Program
    {
        static void Main(string[] args)
        {

           

            //This first block gets the info from users and assigns the respective variables

            Console.WriteLine("Let's set the range. Enter the first number");
            int firstvar = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Now, enter the maximum number of your range");
            int secondvar = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How many numbers per line would you like?");
            int perLine = Convert.ToInt32(Console.ReadLine());

            //Now we establish our variables and list

            int rangeCount = secondvar - firstvar; //we need rangeCount because Enumerable.Range (just below) takes an int argument for how many index spots to create

            IEnumerable<int> x = Enumerable.Range(firstvar, rangeCount); //IEnumerable is used here because I wanted to use .Range(int x, int y) method to define the range

            int perLineChecker = 1; //will get the ++ treatment each time a number is iterated; lets us know when to make new line when compared to user's choice of items per line

            int swtCount = 0; //these three variables will tally++ our instances of each 'Sweet' 'Salty' and 'Sweet'nSalty'
            int sltCount = 0;
            int swtnsltCount = 0;


            //GENERAL LOGIC FROM HERE: we have a switch nested in foreach; switch cases determined by int j being a multiple of 3, 5, both, or neither
            //each iteration will check the current int and send it into the appropriate switch case 


            
            foreach (int j in x) //iterator for all in IEnumerable<int> x
            {   string ss = ""; //this will be assigned a new value based on the following methods and passed into switch statement
                
                
                //CREATE METHOD
                 bool MultipleOf(int x, int n) //method returns a bool, (true)multipleOf or (false)not a multipleOf
                    { if(x == n){ return true; } // int n will either be 3 or 5, the numbers we are checking multiples of.
                                                // So this if x==n statement in the method ensures that int n =3 and =5 can be included as multiples
                                                
                    else return (x % n) == 0;   // else return T/F whether the iteration of list is divisible by the given 3 or 5; this is what will be returned in most cases
                    }   

                if(MultipleOf(j, 3) == true && MultipleOf(j, 5) == false) //if j is a multiple of 3 but not of 5
                {ss = "swt";}                                               //then pass "swt" to switch case
                if(MultipleOf(j, 5) == true && MultipleOf(j, 3) == false) //if j is a multiple of 5 but not of 3
                {ss = "slt";}                                             //then pass "slt" to switch case
                else if (MultipleOf(j, 3) == true && MultipleOf(j, 5) == true && j != 0) //if both, then "swtnslt"
                {ss = "swtnslt";}
                
                switch(ss) //NOTE: most numbers will be run through default case, which will just write the item
                {
                    case "swt": //execute swt logic
                        if(perLine > perLineChecker) //perLine is the user's choice of items per line declared above, perLineChecker keeps track of how many iterations its been since last new line
                        {   
                            Console.Write($"Sweet, "); //we write sweet instead of int j; .Write is used bc it doesn't create a new line; 
                            perLineChecker++;
                            swtCount++;

                        }
                        else 
                            {   Console.Write($"Sweet, "); 
                                perLineChecker = 1; swtCount++; Console.WriteLine(/*blank = new line*/);} // this resets perLineChecker back to 1 once it is no longer < perLine (perLine is user's choice items per line) and then we write a new line
                                                                                    //swtCount++ tallies this instance of sweet
                        break;
                    case "slt": //execute slt logic, works the same as above
                        if(perLine > perLineChecker) 
                        {   
                            Console.Write($"Salty, ");
                            perLineChecker++;
                            sltCount++;

                        }
                        else {
                            Console.Write($"Salty, ");
                            perLineChecker = 1; sltCount++; Console.WriteLine();} 
                        break;
                    
                    case "swtnslt": //execute swtnslt logic, same as above
                        if(perLine > perLineChecker) 
                        {   
                            Console.Write($"Sweet'nSalty, ");
                            perLineChecker++;
                            swtnsltCount++;

                        }
                        else {  
                                Console.Write($"Sweet'nSalty, ");
                                perLineChecker = 1; swtnsltCount++; Console.WriteLine();} 
                        break;

                    default: //most cases we just print the number with a comma and space and move on

                        if(perLine > perLineChecker)
                        {   
                            Console.Write($"{j}, ");
                            perLineChecker++;

                        }
                        else {  //just like above, if perLine is no longer > perLineChecker, we write int j, reset perLineChecker, and make a new line 
                                Console.Write($"{j}, ");
                                perLineChecker = 1; Console.WriteLine();}
                        break;


                }



                     
            }
            Console.WriteLine(); //just making a new line here for better formatting

            //here we present our tallied variables using string interpolation
            Console.WriteLine($"There were {swtCount} 'Sweet' instances");
            Console.WriteLine($"There were {sltCount} 'Salty' instances");
            Console.WriteLine($"There were {swtnsltCount} 'Sweet'nSalty' instances");
            
            
        }
    }
}
