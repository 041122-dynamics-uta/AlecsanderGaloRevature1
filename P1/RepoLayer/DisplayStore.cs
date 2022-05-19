using System.Data.SqlClient;
using ModelsLayer;
namespace RepoLayer
{
    public class DisplayStore
    {
    string connectionString = "Server=tcp:alecgaloserver.database.windows.net,1433;Initial Catalog=AlecGaloDb;Persist Security Info=False;User ID=alecgalodb;Password=Al3c4lec97!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

    public MapperClass mapper { get; set; } 

    public DisplayStore()
    {
        this.mapper = new MapperClass();
    }
    public List<Item> Inventory(int i) 
    {
        string myQuery = $"SELECT * FROM Inventory WHERE StoreID = {i};";
        using(SqlConnection connect1 = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(myQuery, connect1);
            connect1.Open();
            SqlDataReader results = command.ExecuteReader();

            List<Item> inv = new List<Item>();
            while(results.Read())
            {
                inv.Add(mapper.DboToInventory(results));

            }
            connect1.Close();
            return inv;
        }
    }



    }
}