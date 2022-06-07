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
    public class RankController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public RankController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rank>>> GetRanks()
        {
            return await _context.ThanksCards.Include(Card => Card.To)
                                 .GroupBy(Card => Card.To.Name)
                                 .Select(Card => new Rank { Name = Card.Key, Count = Card.Count() })
                                 .Take(3)
                                 .OrderByDescending(Send => Send.Count)
                                 .ToListAsync();
        }
    }
}