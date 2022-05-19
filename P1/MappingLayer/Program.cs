using System;
using System.Collections.Generic;
using ModelsLayer;
using BusinessLayer;


namespace shop
{
    class Program
    {
        static void Main(string[] args)
        {   Customer c = new Customer(); //object customer from Models
            Login cc = new Login(); //object of login from Business
            AddToDb add = new AddToDb(); //object of addtodb from Repo
            Inventory ii = new Inventory();
            


            
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
                        c = cc.signUserIn(c.username);
                        break;
                    }
                    else {Console.WriteLine("does not match"); continue;}

                }
                else {Console.WriteLine("That username does not exist"); //if checkUsername returns false
                continue;}
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

            Console.WriteLine($"Welecome {c.Fname} {c.CustomerID}");
            while(true)
            {
                Console.WriteLine("Please choose a store location");
                
                Console.WriteLine("'1' for Southern California and '2' for Northern California");
                int storeChoice = Convert.ToInt32(Console.ReadLine());
                if (storeChoice != 1 && storeChoice != 2)
                {
                    Console.WriteLine("Choice must be 1 or 2, please try again");
                    continue;
                }
                //Console.WriteLine(ii.storeChoice(storeChoice));
                List<Item> store = ii.storeChoice(storeChoice);
                foreach(Item i in store)
                {
                    Console.WriteLine($"ID#{i.ItemID}.{i.ItemName} | Cost:${i.ItemCost} | {i.Quantity} in stock | {i.Description} \n");
                }

                //businessmethod(storeChoice);
                //print store inventory based on decision
                //options presented: view cart, view history, add item, delete item

                //storeChoice sent to business method, which sends it to repo
                //repo returns list<items> to business which will return it to UI to be printed
            }
            }
        }
    }
}
