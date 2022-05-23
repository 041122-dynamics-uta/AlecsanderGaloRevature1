using RepoLayer;
using ModelsLayer;
using Xunit;
using System.Collections.Generic; 
namespace shopTest.Test
{
    public class RepoTesting
    {   //string connectionString = "Server=tcp:alecgaloserver.database.windows.net,1433;Initial Catalog=AlecGaloDb;Persist Security Info=False;User ID=alecgalodb;Password=Al3c4lec97!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        public AddUser addObject { get; set; } = new AddUser(); //repo object
        public credentialCheck ccObject { get; set; } = new credentialCheck();
        public UpdateAndRetrieval up = new UpdateAndRetrieval();
        public DisplayStore disp = new DisplayStore();
            public RepoTesting()
            {
                this.addObject = new AddUser();
                this.ccObject = new credentialCheck();
                this.up = new UpdateAndRetrieval();
                this.disp = new DisplayStore();
            }
        



        [Fact]
        public void getCustomerIDfromDB()
        {
            //Arrange
            string username = "agalo";

            //Act
            int result = addObject.getID(username); //get ID is used after registration to ensure that the customer 
                                                    //object can obtain the ID assigned by the DB PK

            //Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public void returnCorrectPasswordfromDB()
        {
            //Arrange
            string username = "agalo";


            //Act
            string result = ccObject.password(username);

            //Assert
            Assert.Equal("asdfasdf", result); //asdfasdf if the corresponding password to the username
                                                //that we inputted
        }

        [Fact]
        public void RetrieveHistoryReturnsCorrectInfo()
        {
            //arrange
            Customer c = new Customer(); //method takes customer object as argument, we create that here
            c.CustomerID = 9;
            //act
            List<OrderHistory> oh = up.RetrieveHistory(c);

            //assert
            Assert.Equal("5/22/2022 2:16:55 PM", oh[0].DateOrdered); //date ordered as sample data to compare
            
        }

        [Fact]
        public void RetrieveCorrectCustomer()
        {
            //arrange
            string username = "agalo1";

            //act
            Customer c = ccObject.retreiveCurrentCustomer(username);

            //assert
            Assert.Equal(3, c.CustomerID); //passes if correct customer ID is returned
        }

        [Fact]
        public void DisplayInventoryCorrectly()
        {
            //arrange
            int storeChoice = 1;

            //act
            List<Item> inv = disp.Inventory(storeChoice);

            //assert
            Assert.Equal("Chanterelle", inv[0].ItemName);
            Assert.Equal(100, inv[0].ItemID);

        }

    }

}

