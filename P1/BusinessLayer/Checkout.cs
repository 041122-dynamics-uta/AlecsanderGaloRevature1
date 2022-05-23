using ModelsLayer;
using RepoLayer;
namespace BusinessLayer
{
    public class Checkout
    {
         public UpdateAndRetrieval updateOject { get; set; }
        public Checkout()
        {
            this.updateOject = new UpdateAndRetrieval();
        }

        public void pushCart() //get CurrentCart table data and use it to update Orders
        {
            updateOject.pushOrder();
            
        }

        public void subtractFromInv() //get CurrentCart quantities to subtract from 
                                        //Inventory table by ID
        {
            updateOject.updateInventory();
        }
        
        public void clearCart()        //truncate the CurrentCart table once all other
                                        //checkout operations complete
        {
            updateOject.truncateCart();
        }
    }


}