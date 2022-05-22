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
    }

    }
