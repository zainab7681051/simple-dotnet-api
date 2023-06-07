using simple_dotnet_api.Entity;

namespace simple_dotnet_api.Repo
{
    public class inMemRepo : IinMemRepo
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

        public IEnumerable<Item> GetItems() //return items since items list is private
        {
            return items; //IEnumerable is an interface for returning a colletions of items in a List<T>
        }

        public Item GetItem(Guid id) // return one item if not then null
        {
            var item = items.Where(item => item.id == id).SingleOrDefault(); //if true return item else return null
            return item;
        }

        public void CreateItem(Item item)
        {
            items.Add(item);//add Item item to List<Item>
        }

        public void UpdateItem(Item item)
        {
            //finds and returns the item in the list with the same id as the argument item 
            var index = items.FindIndex(existingItem => existingItem.id == item.id);
            //replaces the old item with new item
            items[index] = item;
        }
        public void DeleteItem(Guid id)
        {
            //find the item whose id equals to id in argument
            var index = items.FindIndex(existingItem => existingItem.id == id);
            //deletes the item with "int index"
            items.RemoveAt(index);
        }
    }
}
