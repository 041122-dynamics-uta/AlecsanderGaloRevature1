using ModelsLayer;
using RepoLayer;
namespace BusinessLayer
{
public class Login 
    {   public credentialCheck checkObject { get; set; } //repo object

        public Login() //dependency injection;
        {
            this.checkObject = new credentialCheck();
        }

        

        public bool checkUsername(string x) //checkUsername() is a method from our Login class (business layer) that returns T/F if username (x) exists in DB
        {                                     //it does so by calling usernameList() from repo layer which, with the help of a mapper method, returns a list of usernames
          List<string> c1 = checkObject.usernameList(); //instantiate list c1 and set equal the list that usernameList() returns
           return c1.Contains(x); //check if list c1 contains username x, Contains() returns a bool
        }

        public bool checkPassword(string x, string y)
        {
            string check = checkObject.password(x);
            //Console.WriteLine(check);
            return String.Equals(y, check);
        }

        public Customer signUserIn(string username)
        {   
            return checkObject.retreiveCurrentCustomer(username);   
        }

        


    }
public class AddToDb
    {
        public AddUser addObject { get; set; } = new AddUser(); //repo object
        public void Login()
        {
            this.addObject = new AddUser();
        }

        public void AddUsertoRepo(Customer c)
        {
            addObject.customertoDB(c);
        }

        public int retreiveID(string username)
        {
            return addObject.getID(username);
        }

        

    }

}