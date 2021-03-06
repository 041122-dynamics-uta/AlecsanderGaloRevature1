namespace ModelsLayer
{ // objects: customer, cart

    public class Customer
    {
        public int? CustomerID { get; set; }
        public string? Fname { get; set; }
        public string? Lname { get; set; }
        public string? username { get; set; } 
        public string? password { get; set; }
       

        
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
    public class updateCurrentCart
    {
        public int? ItemID { get; set; }
        public string? ItemName { get; set; }
        public int? ItemCost { get; set; }
        public int? Quantity { get; set; }
        public int? StoreID { get; set; }
        public int? CustomerID { get; set; }
        public int? ItemTotal { get; set; }

    }

    public class updateOrders
    {
        public int? ItemID { get; set; }
        public string? ItemName { get; set; }
        public int? ItemCost { get; set; }
        public int? Quantity { get; set; }
        public int? ItemTotal { get; set; }
        public int? StoreID { get; set; }
        public int? CustomerID { get; set; }
        public Guid OrderID { get; set; }
        public DateTime DateOrdered { get ; set; } = DateTime.Now;
    }
    public class OrderHistory
    {
        public int? ItemID { get; set; }
        public string? ItemName { get; set; }
        public int? ItemCost { get; set; }
        public int? Quantity { get; set; }
        public int? ItemTotal { get; set; }
        public int? StoreID { get; set; }
        public int? CustomerID { get; set; }
        public Guid OrderID { get; set; }
        public string? DateOrdered { get ; set; }

    }
}
