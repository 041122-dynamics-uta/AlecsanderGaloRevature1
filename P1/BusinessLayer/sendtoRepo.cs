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

        public void sendItem(updateCurrentCart ucc)
        {
            updateOject.mapItem(ucc);
        }


    }
}