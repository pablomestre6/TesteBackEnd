#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteBackEnd.Model;

namespace TesteBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalModelsController : ControllerBase
    {
        private readonly TesteBackEndContext _context;

        public PersonalModelsController(TesteBackEndContext context)
        {
            _context = context;
        }

        // GET: api/PersonalModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonalModels>>> GetPersonalModels()
        {
            return await _context.PersonalModels.ToListAsync();
        }

        // GET: api/PersonalModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonalModels>> GetPersonalModels(Guid id)
        {
            var personalModels = await _context.PersonalModels.FindAsync(id);

            if (personalModels == null)
            {
                return NotFound();
            }

            return personalModels;
        }

        // PUT: api/PersonalModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonalModels(Guid id, PersonalModels personalModels)
        {
            if (id != personalModels.Id)
            {
                return BadRequest();
            }

            _context.Entry(personalModels).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonalModelsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PersonalModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PersonalModels>> PostPersonalModels(PersonalModels personalModels)
        {
            _context.PersonalModels.Add(personalModels);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonalModels", new { id = personalModels.Id }, personalModels);
        }

        // DELETE: api/PersonalModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonalModels(Guid id)
        {
            var personalModels = await _context.PersonalModels.FindAsync(id);
            if (personalModels == null)
            {
                return NotFound();
            }

            _context.PersonalModels.Remove(personalModels);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonalModelsExists(Guid id)
        {
            return _context.PersonalModels.Any(e => e.Id == id);
        }
    }
}
