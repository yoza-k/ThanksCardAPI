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
    public class DepartmentsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public DepartmentsController(ApplicationContext context)
        {
            _context = context;
            if (_context.Departments.Count() == 0)
            {
                // テーブルが空なら初期データを作成する。
                _context.Departments.Add(new Department
                {
                    Id = 000001,
                    Cd = 0001,
                    Name = "代表取締役社長",
                    ParentId = null,
                    Permission = 0
                });
                _context.Departments.Add(new Department
                {
                    Id = 000002,
                    Cd = 0002,
                    Name = "管理部",
                    ParentId = null,
                    Permission = 1
                });
                _context.Departments.Add(new Department
                {
                    Id = 000003,
                    Cd = 0003,
                    Name = "経理部",
                    ParentId = null,
                    Permission = 0
                });
                _context.Departments.Add(new Department
                {
                    Id = 000004,
                    Cd = 0004,
                    Name = "営業部",
                    ParentId = null,
                    Permission = 0
                });
                _context.Departments.Add(new Department
                {
                    Id = 000005,
                    Cd = 0005,
                    Name = "企画部",
                    ParentId = null,
                    Permission = 0
                });
                _context.Departments.Add(new Department
                {
                    Id = 000006,
                    Cd = 0006,
                    Name = "宿泊部",
                    ParentId = null,
                    Permission = 0
                });
                _context.Departments.Add(new Department
                {
                    Id = 000007,
                    Cd = 0007,
                    Name = "人事課",
                    ParentId = 0002,
                    Permission = 1
                });
                _context.Departments.Add(new Department
                {
                    Id = 000008,
                    Cd = 0008,
                    Name = "経理課",
                    ParentId = 0003,
                    Permission = 0
                });
                _context.Departments.Add(new Department
                {
                    Id = 000009,
                    Cd = 0009,
                    Name = "総務課",
                    ParentId = 0003,
                    Permission = 0
                });
                _context.Departments.Add(new Department
                {
                    Id = 000010,
                    Cd = 0010,
                    Name = "国際営業課",
                    ParentId = 0004,
                    Permission = 0
                });
                _context.Departments.Add(new Department
                {
                    Id = 000011,
                    Cd = 0011,
                    Name = "宴会予約",
                    ParentId = 0004,
                    Permission = 0
                });
                _context.Departments.Add(new Department
                {
                    Id = 000012,
                    Cd = 0012,
                    Name = "企画課",
                    ParentId = 0005,
                    Permission = 0
                });
                _context.Departments.Add(new Department
                {
                    Id = 000013,
                    Cd = 0013,
                    Name = "業務推進課",
                    ParentId = 0006,
                    Permission = 0
                });
                _context.Departments.Add(new Department
                {
                    Id = 000014,
                    Cd = 0014,
                    Name = "海外ホテル予約課",
                    ParentId = 0006,
                    Permission = 0
                });
                _context.Departments.Add(new Department
                {
                    Id = 000015,
                    Cd = 0015,
                    Name = "フロント課",
                    ParentId = 0006,
                    Permission = 0
                });
                _context.Departments.Add(new Department
                {
                    Id = 000016,
                    Cd = 0016,
                    Name = "ベルパーソン課",
                    ParentId = 0006,
                    Permission = 0
                });
                _context.Departments.Add(new Department
                {
                    Id = 000017,
                    Cd = 0017,
                    Name = "ドアマン課",
                    ParentId = 0006,
                    Permission = 0
                });
                _context.Departments.Add(new Department
                {
                    Id = 000018,
                    Cd = 0018,
                    Name = "コンシェルジュ課",
                    ParentId = 0006,
                    Permission = 0
                });
                _context.Departments.Add(new Department
                {
                    Id = 000019,
                    Cd = 0019,
                    Name = "ハウスキーピング課",
                    ParentId = 0006,
                    Permission = 0
                });
                _context.SaveChanges();
            }
        }

        // GET: api/Departments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartments()
        {
            if (_context.Departments == null)
            {
                return NotFound();
            }
            return await _context.Departments.ToListAsync();
        }

        // GET: api/Departments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartment(long id)
        {
            if (_context.Departments == null)
            {
                return NotFound();
            }
            var department = await _context.Departments.FindAsync(id);

            if (department == null)
            {
                return NotFound();
            }

            return department;
        }

        // PUT: api/Departments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(long id, Department department)
        {
            if (id != department.Id)
            {
                return BadRequest();
            }

            _context.Entry(department).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(id))
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

        // POST: api/Departments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Department>> PostDepartment(Department department)
        {
            if (_context.Departments == null)
            {
                return Problem("Entity set 'ApplicationContext.Departments'  is null.");
            }
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDepartment", new { id = department.Id }, department);
        }

        // DELETE: api/Departments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(long id)
        {
            if (_context.Departments == null)
            {
                return NotFound();
            }
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DepartmentExists(long id)
        {
            return (_context.Departments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
