namespace ModelsLayer
{ // objects: customer, cart

    public class Customer
    {
        public string? Fname { get; set; }
        public string? Lname { get; set; }
        public string? username { get; set; } //fix G&S setup here later
        // {
        //     get {return username;}
        //     set {
        //     if (value.Length < 21 && value.Length > 3)
        //     {
        //         username = value;
        //     }
        //     else Console.WriteLine("Invalid Input");
        // }
        // }
        public string? password { get; set; }
       // {
        // get {return password;}
        // set 
        //     {
        //     if (value.Length < 21 && value.Length > 4)
        //     {
        //         password = value;
        //     }
        //     else Console.WriteLine("Invalid Input");
        //     }
        //}


        //to figure out what else the cust table needs, we have to solve
        //the order history problem
    }
    public class Class1
    {

    }
}
