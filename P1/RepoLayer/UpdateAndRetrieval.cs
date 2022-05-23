using System.Data.SqlClient;
using ModelsLayer;
namespace RepoLayer
{
    public class UpdateAndRetrieval
    {
    string connectionString = "Server=tcp:alecgaloserver.database.windows.net,1433;Initial Catalog=AlecGaloDb;Persist Security Info=False;User ID=alecgalodb;Password=Al3c4lec97!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

    public MapperClass mapper { get; set; } 

    public UpdateAndRetrieval()
    {
        this.mapper = new MapperClass();
    }

    public void mapItem(updateCurrentCart ucc)
    {
        string myQuery = $"SELECT * FROM Inventory WHERE ItemID = {ucc.ItemID};";
        //string myQuery2 = $"INSERT INTO CurrentCart (ItemID_FK, ItemName, ItemCost, Quantity, CustomerID_FK, StoreID) VALUES ('{ucc.ItemID}', '{ucc1.ItemName}', '{ucc1.ItemCost}', '{ucc1.Quantity}', '{ucc.CustomerID}', '{ucc.StoreID}')";
        //$"INSERT INTO Customers (Fname, Lname, username, password) VALUES ('{c.Fname}', '{c.Lname}', '{c.username}', '{c.password}');";
        using(SqlConnection connect1 = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(myQuery, connect1);
            connect1.Open();
            SqlDataReader results = command.ExecuteReader();

        updateCurrentCart ucc1 = new updateCurrentCart();
           while(results.Read())
           {
                ucc1 = mapper.mapItem(results);

            }
            connect1.Close();

            string myQuery2 = $"INSERT INTO CurrentCart (ItemID_FK, ItemName, ItemCost, Quantity, CustomerID_FK, StoreID) VALUES ('{ucc.ItemID}', '{ucc1.ItemName}', '{ucc1.ItemCost}', '{ucc.Quantity}', '{ucc.CustomerID}', '{ucc1.StoreID}')";
            //now take that object and send it to CC table

            SqlCommand command1 = new SqlCommand(myQuery2, connect1);
            
            connect1.Open();
            SqlDataReader run = command1.ExecuteReader();
            connect1.Close();
           

        }
    }
    public List<updateCurrentCart> RetreiveCart() 
    {
        string myQuery = $"SELECT * FROM CurrentCart;";
        using(SqlConnection connect1 = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(myQuery, connect1);
            connect1.Open();
            SqlDataReader results = command.ExecuteReader();

            List<updateCurrentCart> up = new List<updateCurrentCart>();
            while(results.Read())
            {
                up.Add(mapper.DboToCurrentCart(results));

            }
            connect1.Close();
            return up;
        }
    }
    public void pushOrder() 
    {
        string myQuery = $"SELECT * FROM CurrentCart;";
        using(SqlConnection connect1 = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(myQuery, connect1);
            connect1.Open();
            SqlDataReader results = command.ExecuteReader();

            List<updateOrders> upO = new List<updateOrders>();
            while(results.Read())
            {
                upO.Add(mapper.DboToOrder(results));

            }
            connect1.Close();
            //return upO;
            Guid IDorder = Guid.NewGuid();
            foreach(updateOrders up in upO)
           { string myQuery2 = $"INSERT INTO Orders (ItemID_FK, ItemName, ItemCost, Quantity, StoreID, CustomerID_FK, OrderID, DateOrdered) VALUES ('{up.ItemID}', '{up.ItemName}', '{up.ItemCost}', '{up.Quantity}', '{up.StoreID}', '{up.CustomerID}', '{IDorder}', '{up.DateOrdered}')";
            //now take that object and send it to CC table

            SqlCommand command1 = new SqlCommand(myQuery2, connect1);
            
            connect1.Open();
            SqlDataReader run = command1.ExecuteReader();
            connect1.Close();
           }

        }
    }
    public void updateInventory() 
    {
        string myQuery = $"SELECT * FROM CurrentCart;";
        using(SqlConnection connect1 = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(myQuery, connect1);
            connect1.Open();
            SqlDataReader results = command.ExecuteReader();

            List<updateOrders> up1 = new List<updateOrders>();
            while(results.Read())
            {
                up1.Add(mapper.DboToInvUpdate(results));

            }
            connect1.Close();
            //Foreach:
                        //UPDATE Inventory SET Quantity = Quantity - @Qty
                        //WHERE ItemID = @ItemID
                        //method takes object
            
            foreach(updateOrders up in up1)
           { string myQuery2 = $"UPDATE Inventory SET QuantityAvailable = QuantityAvailable - {up.Quantity} WHERE ItemID = {up.ItemID}";
            //now take that object and send it to CC table

            SqlCommand command1 = new SqlCommand(myQuery2, connect1);
            
            connect1.Open();
            SqlDataReader run = command1.ExecuteReader();
            connect1.Close();
           }

        }
    }
    public void truncateCart()
    {
    

    string myQuery = "TRUNCATE TABLE CurrentCart";
     using(SqlConnection query1 = new SqlConnection(connectionString))
        {
         SqlCommand command = new SqlCommand(myQuery, query1);

            query1.Open();
            SqlDataReader run = command.ExecuteReader();
            query1.Close();
            
        }
   
    }
    public void deleteItem(int item)
    {
    

    string myQuery = $"DELETE FROM CurrentCart WHERE ItemID_FK = {item}";
     using(SqlConnection query1 = new SqlConnection(connectionString))
        {
         SqlCommand command = new SqlCommand(myQuery, query1);

            query1.Open();
            SqlDataReader run = command.ExecuteReader();
            query1.Close();
            
            
        }
   
    }
    public List<OrderHistory> RetrieveHistory(Customer c) 
    {
        string myQuery = $"SELECT * FROM Orders WHERE CustomerID_FK = '{c.CustomerID}';";
        using(SqlConnection connect1 = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(myQuery, connect1);
            connect1.Open();
            SqlDataReader results = command.ExecuteReader();

            List<OrderHistory> o = new List<OrderHistory>();
            while(results.Read())
            {
                o.Add(mapper.DboToOrderHistory(results));

            }
            connect1.Close();
            return o;
        }
    }
    // public List<OrderHistory> RetrieveOrderTotal(Guid OID) 
    // {
    //     string myQuery = $"SELECT ItemTotal FROM Orders WHERE OrderID = '{OID}';";
    //     using(SqlConnection connect1 = new SqlConnection(connectionString))
    //     {
    //         SqlCommand command = new SqlCommand(myQuery, connect1);
    //         connect1.Open();
    //         SqlDataReader results = command.ExecuteReader();

    //         List<OrderHistory> o = new List<OrderHistory>();
    //         while(results.Read())
    //         {
    //             o.Add(mapper.DboToOrderHistory(results));

    //         }
    //         connect1.Close();
    //         return o;
    //     }
    // }






    }

    }
