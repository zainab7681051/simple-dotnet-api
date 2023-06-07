using Microsoft.AspNetCore.Mvc;
using simple_dotnet_api.Dtos;
using simple_dotnet_api.Entity;
// using simple_dotnet_api.Entity; //not used
using simple_dotnet_api.Extensions;
using simple_dotnet_api.Repo;

namespace simple_dotnet_api.Controllers
{
    [ApiController]
    //applyting default core mvc api behavior to our controller class
    [Route("items")] //http://localhost:{port}/items
    public class itemsController : ControllerBase
    // inheriting from mvc controller base
    {
        private readonly IinMemRepo repo;

        /*dependency injection:
        constructor recieves an interface instead of
        instanciating an explicit class
        for achieveing decoupling
        because depending on abstractions
        (interface or base class) is better
        than depending on reuglar classes*/
        public itemsController(IinMemRepo repo)
        {
            this.repo = repo;
        }

        //GET /items
        [HttpGet] //GET action for route /items
        public IEnumerable<ItemDto> GetItems()
        {
            //fo each iteration, take in an 'Item'. return an 'ItemDto'
            var items = repo.GetItems().Select(item => item.AsDto());
            return items; //return the list of ItemDto
        }

        //GET /items/{id}
        [HttpGet("{id}")] //GET by id==> /items/2
        public ActionResult<ItemDto> GetItem(Guid id)
        {
            //get item from items list from inMemItem repo
            var item = repo.GetItem(id);
            if (item is null)
            {
                return NotFound(); //return status code 404. Ok(Item) for 200
                //NOTE: we are allowed to return a type that is not Item thanks to ActionResult type
            }
            return item.AsDto();
        }

        //POST /items
        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto)
        {
            //createItemDto comes in with name and price
            //Item is stored in List<Item>
            //ItemDto and statuc code 201 is returned(the CreatedAtActionResult object)
            Item item = new()
            {
                id = Guid.NewGuid(),
                name = itemDto.name,
                price = itemDto.price,
                createDate = DateTimeOffset.UtcNow
            };//item object created
            //now we need the inMemRepo method to add Item object to Items List
            repo.CreateItem(item);

            //(action name, route parameter value, the return object name)
            return CreatedAtAction(nameof(GetItem), new { id = item.id }, item.AsDto());
            //item is converted into dto when returned from CreateAtAction
            /*
            Created, CreatedAtAction, CreatedAtRoute and their overloads are methods of
            ControllerBase class, they provide convenient ways to return 201 Created
            response from Web API that signifies a successful request completion. 
            Response includes a Location header with an URI that can be used to retrieve newly
            created resource.
            more at https://ochzhen.com/blog/created-createdataction-createdatroute-methods-explained-aspnet-core
            */
        }

        //PUT /items/id
        [HttpPut("{id}")]
        public ActionResult UpdateItem(Guid id, UpdateItemDto itemDto)
        {
            //get "Item item" by id from items List in item repo
            var existingItem = repo.GetItem(id);
            if (existingItem is null)
            {
                return NotFound();
            }
            //Item class is of the type "record" that has
            //the "with" keyword which allows us to copy 
            //records with different properties.
            //here we want to copy the properties of
            //an "Item existingItem" record to another one called
            //"Item UpdatedItem" only with name and price of 
            //"UpdateItemDto itemDto" that was send from the client side
            Item UpdatedItem = existingItem with
            {
                name = itemDto.name,
                price = itemDto.price
            };
            //replaces the old item in the items list
            //with the new updated item
            repo.UpdateItem(UpdatedItem);
            //as per convention, PUT route returns status code 204, no content.
            return NoContent();
        }

        //DELETE /items/id
        [HttpDelete("{id}")]
        public ActionResult DeleteItem(Guid id)
        {
            //find Item item
            var existingItem = repo.GetItem(id);
            //check if item is null
            if (existingItem is null)
            {
                return NotFound();
            }
            //if not null then delete item
            repo.DeleteItem(id);
            //return status code 204, no content
            return NoContent();
        }
    }
}
