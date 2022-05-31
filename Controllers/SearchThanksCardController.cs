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
    public class SearchThanksCardController : ControllerBase
    {
        private readonly ApplicationContext _context;
        public SearchThanksCardController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<IEnumerable<ThanksCard>>> Post([FromBody] SearchThanksCard searchThanksCard)
        {
            return await _context.ThanksCards.Include(ThanksCards => ThanksCards.From).Include(ThanksCards => ThanksCards.To).Where(s => s.Body!.Contains(searchThanksCard.SearchWord) || s.Title!.Contains(searchThanksCard.SearchWord) || s.From!.Name.Contains(searchThanksCard.SearchWord) || s.To!.Name.Contains(searchThanksCard.SearchWord)).ToListAsync();
        }
    }
}
