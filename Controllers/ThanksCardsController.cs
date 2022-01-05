#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThanksCardAPI.Models;

namespace ThanksCardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThanksCardsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ThanksCardsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/ThanksCards
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ThanksCard>>> GetThanksCards()
        {
            return await _context.ThanksCards.ToListAsync();
        }

        // GET: api/ThanksCards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ThanksCard>> GetThanksCard(long id)
        {
            var thanksCard = await _context.ThanksCards.FindAsync(id);

            if (thanksCard == null)
            {
                return NotFound();
            }

            return thanksCard;
        }

        // PUT: api/ThanksCards/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutThanksCard(long id, ThanksCard thanksCard)
        {
            if (id != thanksCard.Id)
            {
                return BadRequest();
            }

            _context.Entry(thanksCard).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThanksCardExists(id))
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

        // POST: api/ThanksCards
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ThanksCard>> PostThanksCard(ThanksCard thanksCard)
        {
            _context.ThanksCards.Add(thanksCard);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetThanksCard", new { id = thanksCard.Id }, thanksCard);
        }

        // DELETE: api/ThanksCards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteThanksCard(long id)
        {
            var thanksCard = await _context.ThanksCards.FindAsync(id);
            if (thanksCard == null)
            {
                return NotFound();
            }

            _context.ThanksCards.Remove(thanksCard);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ThanksCardExists(long id)
        {
            return _context.ThanksCards.Any(e => e.Id == id);
        }
    }
}
