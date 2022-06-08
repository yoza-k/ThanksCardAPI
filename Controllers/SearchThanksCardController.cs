
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
        public async Task<ActionResult<IEnumerable<ThanksCard>>> Text([FromBody] SearchThanksCard searchtextThanksCard)
        {

            return await _context.ThanksCards
                                    .Include(Card => Card.To).ThenInclude(User => User.Department)
                                    .Include(Card => Card.From).ThenInclude(User => User.Department)
                                    .Include(Card => Card.Tag)
                                    .Where(s => s.Body.Contains(searchtextThanksCard.SearchWord) || s.Title.Contains(searchtextThanksCard.SearchWord) || s.To.Name.Contains(searchtextThanksCard.SearchWord) || s.From.Name.Contains(searchtextThanksCard.SearchWord)).ToListAsync();
        }
        [HttpPut]
        public async Task<ActionResult<IEnumerable<ThanksCard>>> Card(string? Cardtitle, string? TagName, string? DepName, string? UserName, DateTime CardTime)
        {
            string? title = (Cardtitle);
            int? year = CardTime.Year;
            int? month = CardTime.Month;
            string? dep = (DepName);
            string? user = (UserName);
            string? tag = (TagName);
            if (_context.ThanksCards == null || (title == null && year == null && month==null && dep == null && User == null && tag == null))
            {
                return NotFound();
            }
            return await _context.ThanksCards.Include(Card => Card.From).ThenInclude(Employee => Employee.Department)
                                 .Include(Card => Card.To).ThenInclude(Employee => Employee.Department)
                                 .Include(Card => Card.Tag)
                                 .Where(s => s.Title.Contains(title) || (s.CreatedDateTime.Year.Equals(year)&& s.CreatedDateTime.Month.Equals(month)) || s.To.Department.Name.Contains(dep) || s.From.Department.Name.Contains(dep) || s.To.Name.Contains(user) || s.From.Name.Contains(user) || s.Tag.Name.Contains(tag)).ToListAsync();
        }

    }
}
