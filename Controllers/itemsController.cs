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
    }
}
