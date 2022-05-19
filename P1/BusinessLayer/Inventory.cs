using ModelsLayer;
using RepoLayer;
namespace BusinessLayer
{   
    public class Inventory
    {
        public DisplayStore displayObject { get; set; }
        public Inventory()
        {
            this.displayObject = new DisplayStore();
        }

        public List<Item> storeChoice(int i)
        {
            return displayObject.Inventory(i);
        }
    }
}