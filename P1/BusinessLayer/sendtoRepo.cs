using ModelsLayer;
using RepoLayer;
namespace BusinessLayer
{
    public class sendtoRepo
    {
        public UpdateAndRetrieval updateOject { get; set; }
        public sendtoRepo()
        {
            this.updateOject = new UpdateAndRetrieval();
        }

        public void sendItem(updateCurrentCart ucc) //sends item, quantity, and mapped data to
                                                    //the CurrentCart table
        {
            updateOject.mapItem(ucc);
        }


    }
}