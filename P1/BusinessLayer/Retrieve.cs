using ModelsLayer;
using RepoLayer;
namespace BusinessLayer
{
    public class Retrieve
    {
        public UpdateAndRetrieval updateOject { get; set; }
        public Retrieve()
        {
            this.updateOject = new UpdateAndRetrieval();
        }

        public List<updateCurrentCart> viewCart() 
        {
            return updateOject.RetreiveCart();
        }

        public void deleteCartItem(int item)
        {
            updateOject.deleteItem(item);
        }
        public List<OrderHistory> orderHistory(Customer c)
        {
            return updateOject.RetrieveHistory(c);
        }
    }
    
}