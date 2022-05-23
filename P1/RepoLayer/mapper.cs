using ModelsLayer;
using System.Data.SqlClient;
namespace RepoLayer
{
    public class MapperClass
    {   //this "mapper" method takes DB data in List form (sent in from a repo class) and assigns its contents as Customer object attributes
        //this method returns a customer object 'c' to repo layer which will then return it to
        
        internal Customer DboToCustomer(SqlDataReader reader)
        {
            Customer c = new Customer
            {
                Fname = (string)reader[1],
                Lname = (string)reader[2],
                username = (string)reader[3],
                password = (string)reader[4],

            };
            return c;
        }
        internal string DboToUsernameList(SqlDataReader reader)
        {
           string username = (string)reader[3];
            
            return username;
        }
        internal Customer mapCustomer(SqlDataReader reader)
        {   
            Customer c1 = new Customer(){
            CustomerID = (int)reader[0],
            Fname = (string)reader[1],
            Lname = (string)reader[2],
            username = (string)reader[3],
            password = (string)reader[4]
            };
            
            return c1;
        }
        internal Item DboToInventory(SqlDataReader reader)
        {
            Item i = new Item
            {
                ItemID = (int)reader[0],
                ItemName = (string)reader[1],
                StoreID = (int)reader[2],
                ItemCost = (int)reader[3],
                Quantity = (int)reader[4],
                Description = (string)reader[5]

            };
            return i;
        }
        internal updateCurrentCart mapItem(SqlDataReader reader)
        {
            updateCurrentCart ucc = new updateCurrentCart
            {
                ItemID = (int)reader[0],
                ItemName = (string)reader[1],
                ItemCost = (int)reader[3],
                StoreID = (int)reader[2]
            };
            return ucc;
        }
         internal updateCurrentCart DboToCurrentCart(SqlDataReader reader)
        {
            updateCurrentCart up = new updateCurrentCart
            {
                ItemID = (int)reader[1],
                ItemName = (string)reader[2],
                StoreID = (int)reader[7],
                ItemCost = (int)reader[3],
                Quantity = (int)reader[4],
                ItemTotal = (int)reader[5]

            };
            return up;
        }
        internal updateOrders DboToOrder(SqlDataReader reader)
        {
            updateOrders upO = new updateOrders
            {
                ItemID = (int)reader[1],
                ItemName = (string)reader[2],
                StoreID = (int)reader[7],
                ItemCost = (int)reader[3],
                Quantity = (int)reader[4],
                //ItemTotal = (int)reader[5],
                CustomerID = (int)reader[6]

            };
            return upO;
        }
        internal updateOrders DboToInvUpdate(SqlDataReader reader)
        {
            updateOrders o = new updateOrders()
            {   
                ItemID = (int)reader[1],
                Quantity = (int)reader[4]
            };
            return o;
        }
        internal OrderHistory DboToOrderHistory(SqlDataReader reader)
        {
            OrderHistory o = new OrderHistory()
            {
                ItemID = (int)reader[1],
                ItemName = (string)reader[2],
                StoreID = (int)reader[6],
                ItemCost = (int)reader[3],
                Quantity = (int)reader[4],
                ItemTotal = (int)reader[5],
                CustomerID = (int)reader[7],
                OrderID = (Guid)reader[8],
                DateOrdered = (string)reader[9]

            };
            return o;
        }
        // internal string (SqlDataReader reader)
        // {
        //    string password = (string)reader[0];
            
        //     return password;
        // }

        // internal string DbotoTableString(SqlDataReader reader)
        // {
        //     string row = (string)reader
        // }
    }
}