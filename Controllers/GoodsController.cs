﻿using System;
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
    public class GoodsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public GoodsController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/Goods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Good>>> GetGoods()
        {
          if (_context.Goods == null)
          {
              return NotFound();
          }
            return await _context.Goods.ToListAsync();
        }

        // GET: api/Goods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Good>> GetGood(long id)
        {
          if (_context.Goods == null)
          {
              return NotFound();
          }
            var good = await _context.Goods.FindAsync(id);

            if (good == null)
            {
                return NotFound();
            }

            return good;
        }

        // PUT: api/Goods/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGood(long id, Good good)
        {
            if (id != good.Id)
            {
                return BadRequest();
            }

            _context.Entry(good).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GoodExists(id))
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

        // POST: api/Goods
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Good>> PostGood(Good good)
        {
          if (_context.Goods == null)
          {
              return Problem("Entity set 'ApplicationContext.Goods'  is null.");
          }
            _context.Goods.Add(good);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGood", new { id = good.Id }, good);
        }

        // DELETE: api/Goods/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGood(long id)
        {
            if (_context.Goods == null)
            {
                return NotFound();
            }
            var good = await _context.Goods.FindAsync(id);
            if (good == null)
            {
                return NotFound();
            }

            _context.Goods.Remove(good);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GoodExists(long id)
        {
            return (_context.Goods?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
