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
            if (_context.ThanksCards == null)
            {
                return NotFound();
            }
            return await _context.ThanksCards.ToListAsync();
        }

        // GET: api/ThanksCards/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ThanksCard>> GetCard(long id)
        {
            if (_context.ThanksCards == null)
            {
                return NotFound();
            }
            var card = await _context.ThanksCards.FindAsync(id);

            if (card == null)
            {
                return NotFound();
            }

            return card;
        }

        // PUT: api/ThanksCards/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCard(long id, ThanksCard card)
        {
            if (id != card.Id)
            {
                return BadRequest();
            }

            _context.Entry(card).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardExists(id))
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
        public async Task<ActionResult<ThanksCard>> PostCard(ThanksCard card)
        {
            if (_context.ThanksCards == null)
            {
                return Problem("Entity set 'ApplicationContext.ThanksCards'  is null.");
            }
            _context.ThanksCards.Add(card);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCard", new { id = card.Id }, card);
        }

        // DELETE: api/ThanksCards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCard(long id)
        {
            if (_context.ThanksCards == null)
            {
                return NotFound();
            }
            var card = await _context.ThanksCards.FindAsync(id);
            if (card == null)
            {
                return NotFound();
            }

            _context.ThanksCards.Remove(card);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CardExists(long id)
        {
            return (_context.ThanksCards?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
