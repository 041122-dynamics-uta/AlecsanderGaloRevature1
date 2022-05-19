using System.Data.SqlClient;
using ModelsLayer;
namespace RepoLayer
{

public class credentialCheck //our repo class must return a list; mapper class method
                                //is what makes our list from the data
{ 
    string connectionString = "Server=tcp:alecgaloserver.database.windows.net,1433;Initial Catalog=AlecGaloDb;Persist Security Info=False;User ID=alecgalodb;Password=Al3c4lec97!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

    public MapperClass mapper { get; set; } 

    public credentialCheck()
    {
        this.mapper = new MapperClass();
    }

    public List<Customer> customerList() 
    {
        string myQuery = "SELECT * FROM Customers;";
        using(SqlConnection connect1 = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(myQuery, connect1);
            connect1.Open();
            SqlDataReader results = command.ExecuteReader();

            List<Customer> c1 = new List<Customer>();
            while(results.Read())
            {
                c1.Add(mapper.DboToCustomer(results));

            }
            connect1.Close();
            return c1;
        }
    }
    public List<string> usernameList() 
    {
        string myQuery = "SELECT * FROM Customers;";
        using(SqlConnection connect1 = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(myQuery, connect1);
            connect1.Open();
            SqlDataReader results = command.ExecuteReader();

            List<string> c1 = new List<string>();
            while(results.Read())
            {
                c1.Add(mapper.DboToUsernameList(results));

            }
            connect1.Close();
            return c1;
        }
    }
    public string password(string user)
    {
        string myQuery = $"SELECT password FROM Customers WHERE username = '{user}'";
        using(SqlConnection connect1 = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(myQuery, connect1);
            //command.Parameters.AddWithValue("@x",user);
            connect1.Open();
            SqlDataReader results = command.ExecuteReader();
            if(results.Read())
            {
                return results.GetString(0);
            }
            else throw new Exception("ERROR; password not in database");
            
            // string correctPassword = (string)results[0];
            // connect1.Close();
            // return correctPassword;

        }
    }

    public Customer retreiveCurrentCustomer(string theUsername) //business class's job will be to receive the result customer and assign it to cc (the customer object created in memory at the beginning)
    {
        string myQuery = $"SELECT * FROM Customers WHERE username = '{theUsername}';";
        using(SqlConnection connect1 = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(myQuery, connect1);
            connect1.Open();
            SqlDataReader results = command.ExecuteReader();

            Customer c = new Customer();
            while(results.Read())
            {
               c = mapper.mapCustomer(results);

            }
            connect1.Close();
            return c;
        }
    }

}
public class AddUser
{   
    public void customertoDB(Customer c)
    {
    string connectionString = "Server=tcp:alecgaloserver.database.windows.net,1433;Initial Catalog=AlecGaloDb;Persist Security Info=False;User ID=alecgalodb;Password=Al3c4lec97!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

    string myQuery = $"INSERT INTO Customers (Fname, Lname, username, password) VALUES ('{c.Fname}', '{c.Lname}', '{c.username}', '{c.password}');";
     using(SqlConnection query1 = new SqlConnection(connectionString))
        {
         SqlCommand command = new SqlCommand(myQuery, query1);

            query1.Open();
            SqlDataReader run = command.ExecuteReader();
            query1.Close();
            
        }
   
    }
}

//public class retrieveTable
// {
//     public List<string> table1()
//     {
//         string connectionString = "Server=tcp:alecgaloserver.database.windows.net,1433;Initial Catalog=AlecGaloDb;Persist Security Info=False;User ID=alecgalodb;Password=Al3c4lec97!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

//             string myQuery1 = "SELECT * FROM Inventory WHERE StoreID = 1;";
   
//             using (SqlConnection query1 = new SqlConnection(connectionString))
//             {
//                 SqlCommand command = new SqlCommand(myQuery1, query1);

//                 query1.Open();
//                 SqlDataReader results = command.ExecuteReader();
//                 List<string> table = new List<string>();
//                 while(results.Read())
//                 {   foreach(int i in results)
//                     table.Add(results[i]);
//                 }

//                 query1.Close();

//             }
//     }

// }

}
