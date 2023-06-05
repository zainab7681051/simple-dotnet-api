using System.Linq;
using dotnet_core_app.Entity;

namespace dotnet_core_app.Repo
{
    public class inMemRepo
    {
        private readonly List<Item> items =
            new()
            {
                new Item
                {
                    id = Guid.NewGuid(),
                    name = "Potion",
                    price = 9,
                    createDate = DateTimeOffset.UtcNow
                },
                new Item
                {
                    id = Guid.NewGuid(),
                    name = "Iron Sword",
                    price = 20,
                    createDate = DateTimeOffset.UtcNow
                },
                new Item
                {
                    id = Guid.NewGuid(),
                    name = "Bronze Shield",
                    price = 15,
                    createDate = DateTimeOffset.UtcNow
                },
            };

        public IEnumerable<Item> GetItems()
        {
            return items; //IEnumerable is an interface for returning a colletions of items
        }

        public Item GetItem(Guid id)
        {
            return items.Where(item => item.id == id).SingleOrDefault(); //if true return item else return null
        }
    }
}
