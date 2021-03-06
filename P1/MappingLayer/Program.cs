using System;
using System.Collections.Generic;
using ModelsLayer;
using System.Diagnostics;
using BusinessLayer;


namespace shop
{
    class Program
    {
        static void Main(string[] args)
        {   //instatiation of all needed objects
            Customer c = new Customer(); 
            Login cc = new Login(); 
            AddToDb add = new AddToDb();
            Inventory ii = new Inventory();
            sendtoRepo sr = new sendtoRepo();
            Retrieve r = new Retrieve();
            Checkout ch = new Checkout();
           


            
            Console.WriteLine("Welcome! Please type login or register");
           
            while(true) //encompassing loop
            {   string choice = Console.ReadLine();
                if(choice != "login" && choice != "register")
                {
                    Console.WriteLine("Incorrect format, please try again");
                    continue;
                }
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
                c.CustomerID = add.retreiveID(c.username); //db assigns ID to new cust, we retrieve and assign locally

                break;
                default: c.Fname = "guest"; break;
            }

            Console.WriteLine($"Welecome {c.Fname}!!");
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
                List<Item> store = ii.storeChoice(storeChoice); //inventory object ii, access storeChoice(), returns list of items to print
                if(storeChoice == 1){Console.WriteLine("WELCOME TO OUR SOCAL INVENTORY");}
                else if(storeChoice == 2){Console.WriteLine("WELCOME TO OUR NORCAL INVENTORY");}
                foreach(Item i in store)
                {   
                    Console.WriteLine($"ID#{i.ItemID}.{i.ItemName} | Cost:${i.ItemCost} | {i.Quantity} in stock | {i.Description} \n");
                }
                string menuChoice;
                while(true)
               {

                    Console.WriteLine("Enter 'shop' to begin shopping");
                    Console.WriteLine("Enter 'v' to view current cart");
                    Console.WriteLine("Enter 'h' to view your purchase history");
                    Console.WriteLine("Enter 'q' to checkout");
                    Console.WriteLine("Enter 'c' to change store location");
                    Console.WriteLine("Enter 'l' to logout");

                    menuChoice = Console.ReadLine();

                    switch(menuChoice)
                    {   
                        case "shop":
                            updateCurrentCart ucc = new updateCurrentCart();
                            ucc.CustomerID = c.CustomerID;
                            Console.WriteLine("Add items to your cart by entering the ID#!");
                            int itemChoice = Convert.ToInt32(Console.ReadLine());
                            if(itemChoice<100 || itemChoice>107)
                            {Console.WriteLine("Invalid input"); 
                            break;}
                            //take ItemID and quantity, query db to populate a an updateCC object, 
                            //send it to the CC table, continue shopping
                            //send inputs to business class, which will contian a repo method that returns the populated object
                            //the same business method uses that returned object to send it to a different repo method for updating the CC Table
                            //ONE business method TWO repo methods
                            //OR the repo method could query the db, map the object, and instead of return, just updates the CC table from there
                            Console.WriteLine("Enter quantity");
                            int itemQuantity = Convert.ToInt32(Console.ReadLine());
                            ucc.ItemID = itemChoice;
                            ucc.Quantity = itemQuantity; //business method must send these both in to get mapped as well
                            sr.sendItem(ucc);
                            break;



                        case "v":
                        while(true)
                        {
                            Console.WriteLine("Your current cart:");
                            List<updateCurrentCart> up =  r.viewCart();
                            int? cartTotal = 0;
                            foreach(updateCurrentCart i in up)
                                {   
                                    Console.WriteLine($"ID#{i.ItemID}.{i.ItemName} | Cost:${i.ItemCost} | Quantity: {i.Quantity} | Item Total: {i.ItemTotal} \n");
                                    cartTotal = cartTotal + i.ItemTotal;
                                }
                            Console.WriteLine($"Your cart total is {cartTotal}");
                            Console.WriteLine("Enter 'd' to choose an item to delete\nEnter 'q' to exit back to menu");
                            string opt = Console.ReadLine();
                            if(opt != "d" && opt != "q" )
                            {
                                break;
                            }
                            if(opt == "d")
                            {
                                Console.WriteLine("Choose an item to delete by ID#");
                                int delete = Convert.ToInt32(Console.ReadLine());
                                r.deleteCartItem(delete);
                            }
                            if (opt == "q") 
                            {   break;
                            }
                        }
                        break;

                        case "h":
                        List<OrderHistory> hist = r.orderHistory(c);
                        Console.WriteLine("SOCAL ORDERS:");
                        int? ordertotal1 = 0;
                        foreach(OrderHistory o in hist)
                        {   if(o.StoreID == 1){
                            Console.WriteLine($"ID#{o.ItemID}.{o.ItemName} | Cost:${o.ItemCost} | Quantity: {o.Quantity} | Date Ordered: {o.DateOrdered}");
                            ordertotal1 = ordertotal1 + o.ItemTotal;
                            }
                            
                        }
                        Console.WriteLine($"Total Cost: {ordertotal1}");

                        
                        Console.WriteLine("NORCAL ORDERS:");
                         int? ordertotal2 = 0;
                        foreach(OrderHistory o in hist)
                        {
                            if(o.StoreID == 2)
                            {
                                Console.WriteLine($"ID#{o.ItemID}.{o.ItemName} | Cost:${o.ItemCost} | Quantity: {o.Quantity} | Date Ordered: {o.DateOrdered}");
                                ordertotal2 = ordertotal2 + o.ItemTotal;
                            }
                        }
                        Console.WriteLine($"Total Cost: {ordertotal2}");
                        break;

                        case "q":
                        ch.pushCart(); //update orders table
                        ch.subtractFromInv(); //subtract item quantities from orders table
                        ch.clearCart(); //truncates the current cart table after checkout
                        break;


                        case "c": //continues to options outside of loop
                        break;


                        case "l":
                        //continues to options outside of loop
                         break;

                    }
                Console.WriteLine("Continue shopping? (Enter 's')\nChange stores? (Enter 'c')\nLogout? (Enter 'l')");
                string cont = Console.ReadLine();
                if(cont == "s"){continue;}
                else if(cont == "c"){break;}
                else if(cont == "l"){System.Environment.Exit(0);}

               }
               
               

                

             
            }
            }
        }
    }
}
