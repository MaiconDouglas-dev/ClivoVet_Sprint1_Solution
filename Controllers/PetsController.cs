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

        // GET: api/pets/{id} 
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Pet>> GetById(int id)
        {
            var pet = await _context.Pets.FindAsync(id);
            if (pet == null) return NotFound();
            return Ok(pet);
        }

        // GET: api/pets/especie/{especie} 
        [HttpGet("especie/{especie}")]
        public async Task<ActionResult<IEnumerable<Pet>>> GetByEspecie(string especie)
        {
            var pets = await _context.Pets
                .Where(p => p.Especie.ToLower() == especie.ToLower())
                .ToListAsync();
            return Ok(pets);
        }

        // GET: api/pets/status/{status}
        [HttpGet("status/{status}")]
        public async Task<ActionResult<IEnumerable<Pet>>> GetByStatus(string status)
        {
            var pets = await _context.Pets
                .Where(p => p.StatusAtividade.ToLower() == status.ToLower())
                .ToListAsync();

            return Ok(pets);
        }

        // GET: api/pets/peso/min/{min}/max/{max}
        [HttpGet("peso/min/{min:double}/max/{max:double}")]
        public async Task<ActionResult<IEnumerable<Pet>>> GetByPesoRange(double min, double max)
        {
            if (min < 0 || max < 0 || min > max)
                return BadRequest("Intervalo de peso inválido.");

            var pets = await _context.Pets
                .Where(p => p.Peso >= min && p.Peso <= max)
                .ToListAsync();

            return Ok(pets);
        }

        // POST: api/pets
        [HttpPost]
        public async Task<ActionResult<Pet>> Create([FromBody] Pet pet)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = pet.Id }, pet);
        }

        // PUT: api/pets/{id}
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Pet pet)
        {
            if (id != pet.Id) return BadRequest("ID incompatível");
            _context.Entry(pet).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Pets.Any(e => e.Id == id)) return NotFound();
                throw;
            }
            return NoContent();
        }

        // DELETE: api/pets/{id}
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
