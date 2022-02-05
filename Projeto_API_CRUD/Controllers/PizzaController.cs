using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto_API_CRUD.Models;
using Projeto_API_CRUD.Models.Data;

namespace Projeto_API_CRUD.Controllers
{
    [Route("api/pizza")]
    [ApiController]
    public class PizzaController : ControllerBase {

        private readonly DataBaseContext _context;

        public PizzaController(DataBaseContext context) {
            _context = context;
        }

        private bool PizzaExists(int id) {
            return _context.Pizzas.Any(e => e.PizzaId == id);
        }


        /* -------------------------------------------------- GET - Read -------------------------------------------------- */
        // GET: api/pizza
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pizza>>> GetPizzas() {
            return await _context.Pizzas.ToListAsync();
        }
        // GET: api/pizza/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pizza>> GetPizza(int id) {
            var pizza = await _context.Pizzas.FindAsync(id);
            if (pizza == null) {
                return NotFound();
            }
            return pizza;
        }


        /* -------------------------------------------------- POST - Create -------------------------------------------------- */
        // POST: api/pizza
        [HttpPost]
        public async Task<ActionResult<Pizza>> PostPizza(Pizza pizza) {
            _context.Pizzas.Add(pizza);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetPizza), new { id = pizza.PizzaId }, pizza);
        }


        /* -------------------------------------------------- PUT - Edit -------------------------------------------------- */
        // PUT: api/pizza/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPizza(int id, Pizza pizza) {
            if (id != pizza.PizzaId) {
                return BadRequest();
            }
            _context.Entry(pizza).State = EntityState.Modified;
            try {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) {
                if (!PizzaExists(id)) {
                    return NotFound();
                }
                else {
                    throw;
                }
            }
            return NoContent();
        }


        /* -------------------------------------------------- DELETE -------------------------------------------------- */
        // DELETE: api/pizza/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePizza(int id) {
            var pizza = await _context.Pizzas.FindAsync(id);
            if (pizza == null) {
                return NotFound();
            }
            _context.Pizzas.Remove(pizza);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
