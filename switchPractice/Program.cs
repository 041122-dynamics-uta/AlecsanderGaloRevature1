// See https://aka.ms/new-console-template for more information
//thai american japanese mexican
Console.WriteLine("You tell me what kind of cuisine you want and I'll pick a restaurant for us.");
Console.WriteLine("Enter 'thai' for thai, 'amer' for american, 'mex' for mexican, or 'japan' for japanese");
var x = Console.ReadLine();

switch(x)
    {   case "thai":
            Console.WriteLine("Let's eat at that hole in the wall, Thai Garden!");
            break;
        case "amer":
            Console.WriteLine("Okay, fuck it, let's get McDonald's");
            break;
        case "mex":
            Console.WriteLine("We'll go to Roberto's Birria down the street!");
            break;
        case "japan":
            Console.WriteLine("Oh! We'll go to that new Hibachi Grill!");
            break;
        default:
            Console.WriteLine("That wasn't one of the options.");
            break;
    }