using dotnet_core_app.Entity;

namespace dotnet_core_app.Repo
{
    public interface IinMemRepo
    {
        Item GetItem(Guid id);
        IEnumerable<Item> GetItems();
    }
}
