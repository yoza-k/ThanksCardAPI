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
    public class testController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public testController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<test>>> GetCount()
        {
            return await _context.Goods
                                 .Include(Good => Good.ThanksCard)
                                 .GroupBy(Good => Good.ThanksCard.Id)
                                 .Select(Card => new test { Count = Card.Count() })
                                 .OrderByDescending(top => top.Count)
                                 .ToListAsync();
            
        }
    /*    [HttpPut]
        public async Task<ActionResult<IEnumerable<ThanksCard>>> PutCards()
        {

            return await _context.ThanksCards
                                 .Include(Card => Card.To).ThenInclude(User => User.Department)
                                 .Include(Card => Card.From).ThenInclude(User => User.Department)
                                 .Include(Card => Card.Tag)
                                 .Where(c => c.)
                                 .ToListAsync();
        }*/


    }
}