using System;
using System.Collections.Generic;
using System.Linq;

namespace sweetsalty
{
    class Program
    {
        static void Main(string[] args)
        {

           


            Console.WriteLine("Let's set the range. Enter the first number");
            int firstvar = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Now, enter the maximum number of your range");
            int secondvar = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How many numbers per line would you like?");
            int perLine = Convert.ToInt32(Console.ReadLine());
            int rangeCount = secondvar - firstvar;


            IEnumerable<int> x = Enumerable.Range(firstvar, rangeCount);
            int perLineChecker = 1; //will get the ++ treatment each time a number is iterated; lets us know when to make new line when compared to user's choice of items per line
            int swtCount = 0;
            int sltCount = 0;
            int swtnsltCount = 0;
            //practice code below
            foreach (int j in x) 
            {   string ss = "";
                
                

                 bool MultipleOf(int x, int n) //method returns a bool, (true)multiple or (false)not a multiple
                    { if(x == n){ return true; } // int n will either be 3 or 5, the numbers we are checking multiples of.
                                                // So this if statement in the method ensures that int n =3 and =5 can be included as multiples
                                                
                    else return (x % n) == 0;   // else return T/F whether the iteration of list is divisible by the given 3 or 5
                    }   

                if(MultipleOf(j, 3) == true && MultipleOf(j, 5) == false) //if j is a multiple of 3 but not of 5
                {ss = "swt";} //then give "swt" to switch case
                if(MultipleOf(j, 5) == true && MultipleOf(j, 3) == false)
                {ss = "slt";}
                else if (MultipleOf(j, 3) == true && MultipleOf(j, 5) == true)
                {ss = "swtnslt";}
                
                switch(ss)
                {
                    case "swt": 
                        if(perLine > perLineChecker) //perLine is user's choice of items per line, perLineChecker keeps track of how many iterations its been
                        {   
                            Console.Write($"Sweet, "); //.Write is used bc it doesn't create a new line
                            perLineChecker++;
                            swtCount++;

                        }
                        else 
                            {   Console.Write($"Sweet, "); 
                                perLineChecker = 1; swtCount++; Console.WriteLine();} // this resets perLineChecker once it = perLine and then writes a new line
                        break;
                    case "slt":
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
                    
                    case "swtnslt":
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

                    default:

                        if(perLine > perLineChecker)
                        {   
                            Console.Write($"{j}, ");
                            perLineChecker++;

                        }
                        else {  
                                Console.Write($"{j}, ");
                                perLineChecker = 1; Console.WriteLine();}
                        break;


                }



                     
            }
            Console.WriteLine(); //just making a new line for better formatting

            Console.WriteLine($"There were {swtCount} 'Sweet' instances");
            Console.WriteLine($"There were {sltCount} 'Salty' instances");
            Console.WriteLine($"There were {swtnsltCount} 'Sweet'nSalty' instances");
            
            
        }
    }
}
