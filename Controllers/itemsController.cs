using dotnet_core_app.Entity;
using dotnet_core_app.Repo;
using Microsoft.AspNetCore.Mvc;

namespace dotnet_core_app.Controllers
{
    [ApiController]
    //applyting default core mvc api behavior to our controller class
    [Route("items")] //http://localhost:{port}/items
    public class itemsController : ControllerBase
    // inheriting from controller base
    {
        private readonly inMemRepo repo;

        public itemsController()
        {
            repo = new inMemRepo();
        }

        [HttpGet] //GET action for route items
        public IEnumerable<Item> GetItems()
        {
            var items = repo.GetItems();
            return items;
        }
    }
}
