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
    public class ATMCardsController : ControllerBase
    {
        private readonly ATMDbContext _context;

        public ATMCardsController(ATMDbContext context)
        {
            _context = context;
        }

        // GET: api/atmcards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ATMCard>>> GetATMCards()
        {
            return await _context.ATMCards.Include(c => c.User).ToListAsync();
        }

        // GET: api/atmcards/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ATMCard>> GetATMCard(int id)
        {
            var atmCard = await _context.ATMCards.Include(c => c.User).FirstOrDefaultAsync(c => c.ATMCardID == id);

            if (atmCard == null)
            {
                return NotFound();
            }

            return atmCard;
        }

        // POST: api/atmcards
        [HttpPost]
        public async Task<ActionResult<ATMCard>> PostATMCard(ATMCard atmCard)
        {
            _context.ATMCards.Add(atmCard);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetATMCard), new { id = atmCard.ATMCardID }, atmCard);
        }

        // PUT: api/atmcards/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutATMCard(int id, ATMCard atmCard)
        {
            if (id != atmCard.ATMCardID)
            {
                return BadRequest();
            }

            _context.Entry(atmCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ATMCardExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return NoContent();
        }

        // DELETE: api/atmcards/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteATMCard(int id)
        {
            var atmCard = await _context.ATMCards.FindAsync(id);
            if (atmCard == null)
            {
                return NotFound();
            }

            _context.ATMCards.Remove(atmCard);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ATMCardExists(int id)
        {
            return _context.ATMCards.Any(e => e.ATMCardID == id);
        }
    }
}
