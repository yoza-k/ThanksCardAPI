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
    public class DepartmentUsersController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public DepartmentUsersController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: api/DepartmentUsers/5
        [HttpGet("{DepartmentId?}")]
        public async Task<ActionResult<IEnumerable<User>>> GetDepartmentUsers(long? DepartmentId = null)
        {
            if (DepartmentId == null)
            {
                return await _context.Users
                                        .ToListAsync();
            }
            else
            {
                return await _context.Users
                                        .Where(u => u.DepartmentId == DepartmentId)
                                        .ToListAsync();
            }
        }
    }
}