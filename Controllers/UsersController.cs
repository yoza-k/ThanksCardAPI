using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ThanksCardAPI.Models;

namespace ThanksCradAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public UsersController(ApplicationContext context)
        {
            _context = context;
            if (_context.Users.Count() == 0)
            {
                // テーブルが空なら初期データを作成する。
                _context.Users.Add
                    (new User
                    {
                        Id = 000001,
                        Cd = 0001,
                        Name = "比嘉鉄平",
                        KanaName = "ヒガテッペイ",
                        Password = 1234,
                        DepartmentId = 000012
                    });
                _context.Users.Add
                    (new User
                    {
                        Id = 000002,
                        Cd = 0002,
                        Name = "山田慎一",
                        KanaName = "ヤマダシンイチ",
                        Password = 2345,
                        DepartmentId = 000012
                    });
                _context.Users.Add
                    (new User
                    {
                        Id = 000003,
                        Cd = 0003,
                        Name = "金城まゆみ",
                        KanaName = "キンジョウマユミ",
                        Password = 3456,
                        DepartmentId = 000016
                    });
                _context.SaveChanges();
            }
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(long id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var employee = await _context.Users.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(long id, User employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User employee)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'ApplicationContext.Users'  is null.");
            }
            _context.Users.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = employee.Id }, employee);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var employee = await _context.Users.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            _context.Users.Remove(employee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(long id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
