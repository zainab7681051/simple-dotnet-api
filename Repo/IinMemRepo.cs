using simple_dotnet_api.Entity;

namespace simple_dotnet_api.Repo
{
    public interface IinMemRepo
    {
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();
        void CreateItem(Item item);
    }
}
