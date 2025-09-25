using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DotnetProject.Data;
using DotnetProject.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ATMMachinesController : ControllerBase
    {
        private readonly ATMDbContext _context;

        public ATMMachinesController(ATMDbContext context)
        {
            _context = context;
        }

        // GET: api/atmmachines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ATMMachine>>> GetATMMachines()
        {
            return await _context.ATMMachines.ToListAsync();
        }

        // GET: api/atmmachines/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ATMMachine>> GetATMMachine(int id)
        {
            var atmMachine = await _context.ATMMachines.FindAsync(id);

            if (atmMachine == null)
            {
                return NotFound();
            }

            return atmMachine;
        }

        // POST: api/atmmachines
        [HttpPost]
        public async Task<ActionResult<ATMMachine>> PostATMMachine(ATMMachine atmMachine)
        {
            _context.ATMMachines.Add(atmMachine);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetATMMachine), new { id = atmMachine.ATMMachineID }, atmMachine);
        }

        // PUT: api/atmmachines/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutATMMachine(int id, ATMMachine atmMachine)
        {
            if (id != atmMachine.ATMMachineID)
            {
                return BadRequest();
            }

            _context.Entry(atmMachine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ATMMachineExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // DELETE: api/atmmachines/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteATMMachine(int id)
        {
            var atmMachine = await _context.ATMMachines.FindAsync(id);
            if (atmMachine == null)
            {
                return NotFound();
            }

            _context.ATMMachines.Remove(atmMachine);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ATMMachineExists(int id)
        {
            return _context.ATMMachines.Any(e => e.ATMMachineID == id);
        }
    }
}
