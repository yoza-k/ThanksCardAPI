using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThanksCardAPI.Models;

namespace ThanksCardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public UserController(ApplicationContext context)
        {
            _context = context;
        }

        #region GetUsers
        // GET: api/user
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }
        #endregion

        // POST api/user
        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            // TODO: Error Handling
            return user;
        }

        // PUT api/user/1
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Put(long id, [FromBody] User user)
        {
            try
            {
                _context.Users.Attach(user);
                _context.Entry(user).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                //TODO: Error Handling
                return null;
            }

            User User = _context.Users.Find(id);
            return User;
        }

        // DELETE api/user/1
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(long id)
        {
            var User = _context.Users.Find(id);
            if (User == null)
            {
                return null;
            }
            _context.Users.Remove(User);
            await _context.SaveChangesAsync();
            return User;
        }
    }       
}
