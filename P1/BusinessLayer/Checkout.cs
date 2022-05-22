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

        public void pushCart()
        {
            updateOject.pushOrder();
            
        }

        public void subtractFromInv()
        {
            updateOject.updateInventory();
        }
        
        public void clearCart()
        {
            updateOject.truncateCart();
        }
    }


}