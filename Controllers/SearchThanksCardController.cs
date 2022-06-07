
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
                                    .Include(Card => Card.To).ThenInclude(Employee => Employee.Department)
                                    .Include(Card => Card.From).ThenInclude(Employee => Employee.Department)
                                    .Include(Card => Card.Tag)
                                    .Where(s => s.Body.Contains(searchtextThanksCard.SearchWord) || s.Title.Contains(searchtextThanksCard.SearchWord) || s.To.Name.Contains(searchtextThanksCard.SearchWord) || s.From.Name.Contains(searchtextThanksCard.SearchWord)).ToListAsync();
        }
        [HttpPut]
        public async Task<ActionResult<IEnumerable<ThanksCard>>> Card(string? Cardtitle, string? CategoryName, string? DepName, string? EmpName, string? CardTime = "0000-00")
        {
            string? title = (Cardtitle);
            DateTime? time = DateTime.Parse(CardTime);
            string? dep = (DepName);
            string? emp = (EmpName);
            string? cate = (CategoryName);
            if (_context.ThanksCards == null || (title == null && time == null && dep == null && emp == null && cate == null))
            {
                return NotFound();
            }
            return await _context.ThanksCards.Include(Card => Card.From).ThenInclude(Employee => Employee.Department)
                                 .Include(Card => Card.To).ThenInclude(Employee => Employee.Department)
                                 .Include(Card => Card.Tag)
                                 .Where(s => s.Title.Contains(title) || s.CreatedDateTime.Equals(time) || s.To.Department.Name.Contains(dep) || s.From.Department.Name.Contains(dep) || s.To.Name.Contains(emp) || s.From.Name.Contains(emp) || s.Tag.Name.Contains(cate)).ToListAsync();
        }

    }
}
