using ModelsLayer;
using System.Data.SqlClient;
namespace RepoLayer
{
    public class MapperClass
    {   //this "mapper" method takes DB data in List form (sent in from repo layer) and assigns its contents as Customer object attributes
        //this method returns a customer object 'c' to repo layer which will then return it to
        //business layer for manipulation or comparison
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
        internal string DboToPassword(SqlDataReader reader)
        {
           string password = (string)reader[0];
            
            return password;
        }

        // internal string DbotoTableString(SqlDataReader reader)
        // {
        //     string row = (string)reader
        // }
    }
}