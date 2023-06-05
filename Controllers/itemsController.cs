using dotnet_core_app.Entity;
using dotnet_core_app.Repo;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_core_app.Controllers
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
        because depending on abstraction is better
        than depending on classes*/
        public itemsController(IinMemRepo repo)
        {
            this.repo = repo;
        }

        [HttpGet] //GET action for route /items
        public IEnumerable<Item> GetItems()
        {
            var items = repo.GetItems();
            return items;
        }

        [HttpGet("{id}")] //GET by id==> /items/2
        public ActionResult<Item> GetItem(Guid id)
        {
            var item = repo.GetItem(id);
            if (item is null)
            {
                return NotFound(); //return status code 404. Ok(Item) for 200
                //NOTE: we are allowed to return a type that is not Item thanks to ActionResult type
            }
            return item;
        }
    }
}
