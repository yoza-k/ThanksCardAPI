using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThanksCardAPI.Models;

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public TagsController(ApplicationContext context)
        {
            _context = context;
            if (_context.Tags.Count() == 0)
            {
                // テーブルが空なら初期データを作成する。
                _context.Tags.Add(
                    new Tag
                    {
                        Id = 000001,
                        Cd = 0001,
                        Name = "感謝"
                    });
                _context.Tags.Add(
                    new Tag
                    {
                        Id = 000002,
                        Cd = 0002,
                        Name = "相談"
                    });
                _context.SaveChanges();
            }
        }

        // GET: api/Tags
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tag>>> GetTags()
        {
            if (_context.Tags == null)
            {
                return NotFound();
            }
            return await _context.Tags.ToListAsync();
        }

        // GET: api/Tags/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tag>> GetCategory(long id)
        {
            if (_context.Tags == null)
            {
                return NotFound();
            }
            var category = await _context.Tags.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // PUT: api/Tags/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(long id, Tag category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            _context.Entry(category).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoryExists(id))
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

        // POST: api/Tags
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tag>> PostCategory(Tag category)
        {
            if (_context.Tags == null)
            {
                return Problem("Entity set 'ApplicationContext.Tags'  is null.");
            }
            _context.Tags.Add(category);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategory", new { id = category.Id }, category);
        }

        // DELETE: api/Tags/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(long id)
        {
            if (_context.Tags == null)
            {
                return NotFound();
            }
            var category = await _context.Tags.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Tags.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoryExists(long id)
        {
            return (_context.Tags?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
