﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ThanksCardAPI.Models;

namespace ThanksCardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogonController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public LogonController(ApplicationContext context)
        {
            _context = context;

            if (_context.Users.Count() == 0)
            {
                // Usersテーブルが空なら初期データを作成する。
                _context.Users.Add(new User { Name = "admin", Password = "admin", IsAdmin = true });
                _context.Users.Add(new User { Name = "user", Password = "user", IsAdmin = false });
                _context.SaveChanges();
            }
        }

        // POST api/logon
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            var authorizedUser = _context.Users.SingleOrDefault(x => x.Name == user.Name && x.Password == user.Password);
            if (authorizedUser == null)
            {
                return NotFound();
            }
            return authorizedUser;
        }
    }
}
