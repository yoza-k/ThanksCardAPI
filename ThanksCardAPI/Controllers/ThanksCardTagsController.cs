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
    public class ThanksCardTagsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public ThanksCardTagsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/ThanksCardTags
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ThanksCardTag>>> GetThanksCardTag()
        {
            return await _context.ThanksCardTag.ToListAsync();
        }

        // GET: api/ThanksCardTags/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ThanksCardTag>> GetThanksCardTag(long id)
        {
            var thanksCardTag = await _context.ThanksCardTag.FindAsync(id);

            if (thanksCardTag == null)
            {
                return NotFound();
            }

            return thanksCardTag;
        }

        // PUT: api/ThanksCardTags/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutThanksCardTag(long id, ThanksCardTag thanksCardTag)
        {
            if (id != thanksCardTag.Id)
            {
                return BadRequest();
            }

            _context.Entry(thanksCardTag).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThanksCardTagExists(id))
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

        // POST: api/ThanksCardTags
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ThanksCardTag>> PostThanksCardTag(ThanksCardTag thanksCardTag)
        {
            _context.ThanksCardTag.Add(thanksCardTag);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetThanksCardTag", new { id = thanksCardTag.Id }, thanksCardTag);
        }

        // DELETE: api/ThanksCardTags/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteThanksCardTag(long id)
        {
            var thanksCardTag = await _context.ThanksCardTag.FindAsync(id);
            if (thanksCardTag == null)
            {
                return NotFound();
            }

            _context.ThanksCardTag.Remove(thanksCardTag);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ThanksCardTagExists(long id)
        {
            return _context.ThanksCardTag.Any(e => e.Id == id);
        }
    }
}
