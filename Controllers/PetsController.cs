using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClivoVetApi.Data;
using ClivoVetApi.Models;

namespace ClivoVetApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PetsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PetsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/pets (200 OK)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pet>>> GetAll()
        {
            return Ok(await _context.Pets.ToListAsync());
        }

        // GET: api/pets/{id} (Rota Parametrizada 1 - 200 OK ou 404)
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Pet>> GetById(int id)
        {
            var pet = await _context.Pets.FindAsync(id);
            if (pet == null) return NotFound();
            return Ok(pet);
        }

        // GET: api/pets/especie/{especie} (Rota Parametrizada 2)
        [HttpGet("especie/{especie}")]
        public async Task<ActionResult<IEnumerable<Pet>>> GetByEspecie(string especie)
        {
            var pets = await _context.Pets
                .Where(p => p.Especie.ToLower() == especie.ToLower())
                .ToListAsync();
            return Ok(pets);
        }

        // POST: api/pets (201 Created)
        [HttpPost]
        public async Task<ActionResult<Pet>> Create([FromBody] Pet pet)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = pet.Id }, pet);
        }

        // PUT: api/pets/{id} (204 NoContent)
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Pet pet)
        {
            if (id != pet.Id) return BadRequest("ID incompatível");
            _context.Entry(pet).State = EntityState.Modified;
            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!_context.Pets.Any(e => e.Id == id)) return NotFound();
                throw;
            }
            return NoContent();
        }

        // DELETE: api/pets/{id} (204 NoContent)
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var pet = await _context.Pets.FindAsync(id);
            if (pet == null) return NotFound();
            _context.Pets.Remove(pet);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
