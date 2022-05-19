namespace ModelsLayer
{ // objects: customer, cart

    public class Customer
    {
        public int? CustomerID { get; set; }
        public string? Fname { get; set; }
        public string? Lname { get; set; }
        public string? username { get; set; } 
        public string? password { get; set; }
       

        //to figure out what else the cust table needs, we have to solve
        //the order history problem
    }
    public class Item
    {
        public int? ItemID { get; set; }
        public string? ItemName { get; set; }
        public int? StoreID { get; set; }
        public int? ItemCost { get; set; }
        public int? Quantity { get; set; }
        public string? Description { get; set; }
        

    }
}
