using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazingPizza.Data;
using BlazingPizza.Model;

namespace BlazingPizza.Controllers
{
    [Route("/pizzas")]
    [ApiController]
    public class PizzaController : Controller
    {
        private readonly PizzaStoreContext _dbContext;
        public PizzaController(PizzaStoreContext dbContext) 
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<PizzaSpecial>>> GetPizzas() 
        { 
            return (await _dbContext.Pizzas.ToListAsync()).OrderByDescending(p => p.BasePrice).ToList();
        }
    }
}
