using System;
using ModelsLayer;
using BusinessLayer;


namespace shop
{
    class Program
    {
        static void Main(string[] args)
        {   Customer c = new Customer();
            Login cc = new Login();
            AddToDb add = new AddToDb();
            


            
            Console.WriteLine("Welcome! Please type login or register");
            string choice = Console.ReadLine();
            while(true) //encompassing login/registation loop
            {
            switch (choice) //login or register
            {
                case "login":
                Console.WriteLine("Please enter your username");
                c.username = Console.ReadLine(); // customer object c assign username 
                if (cc.checkUsername(c.username) == true) //checkUsername busniess class method 
                {
                    Console.WriteLine("Please enter your password");
                    c.password = Console.ReadLine();
                    if (cc.checkPassword(c.username, c.password) == true) //checkPassword is supposed to compare (x, y) and return a bool
                    {
                        //Console.WriteLine("it worked"); 
                        break;
                    }
                    else Console.WriteLine("does not match");

                }
                else Console.WriteLine("That username does not exist"); //if checkUsername returns false
                break;
                case "register": 
                Console.WriteLine("Enter your first name");
                c.Fname = Console.ReadLine();
                Console.WriteLine("Enter your last name");
                c.Lname = Console.ReadLine();
                Console.WriteLine("Enter a username");
                c.username = Console.ReadLine(); // customer object c assign username 
                if (cc.checkUsername(c.username) == true) 
                {
                    Console.WriteLine("That username already exists");
                }
                else Console.WriteLine("Enter a password");
                c.password = Console.ReadLine();
                //business method that takes Customer and adds their attributes to database
                add.AddUsertoRepo(c);

                break;
                default: c.username = "guest"; break;
            }
            Console.WriteLine($"Welecome {c.Fname}");
            Console.WriteLine("Please choose a store location");
            
            Console.WriteLine("'1' for California ad '2' for Texas");
            
            string storeChoice = Console.ReadLine();
            // switch(storeChoice)
            // {
            //     case "1": 
            // }

            
            }
        }
    }
}
