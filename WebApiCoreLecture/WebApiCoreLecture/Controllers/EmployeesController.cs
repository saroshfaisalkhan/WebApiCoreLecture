using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCoreLecture.Models;

namespace WebApiCoreLecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeContext _context;

        public EmployeesController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblEmployee>>> GettblEmployees()
        {
          if (_context.tblEmployees == null)
          {
              return NotFound();
          }
            return await _context.tblEmployees.ToListAsync();
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblEmployee>> GetTblEmployee(int id)
        {
          if (_context.tblEmployees == null)
          {
              return NotFound();
          }
            var tblEmployee = await _context.tblEmployees.FindAsync(id);

            if (tblEmployee == null)
            {
                return NotFound();
            }

            return tblEmployee;
        }

        // PUT: api/Employees/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblEmployee(int id, TblEmployee tblEmployee)
        {
            if (id != tblEmployee.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblEmployee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblEmployeeExists(id))
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

        // POST: api/Employees
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblEmployee>> PostTblEmployee(TblEmployee tblEmployee)
        {
          if (_context.tblEmployees == null)
          {
              return Problem("Entity set 'EmployeeContext.tblEmployees'  is null.");
          }
            _context.tblEmployees.Add(tblEmployee);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblEmployee", new { id = tblEmployee.Id }, tblEmployee);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblEmployee(int id)
        {
            if (_context.tblEmployees == null)
            {
                return NotFound();
            }
            var tblEmployee = await _context.tblEmployees.FindAsync(id);
            if (tblEmployee == null)
            {
                return NotFound();
            }

            _context.tblEmployees.Remove(tblEmployee);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblEmployeeExists(int id)
        {
            return (_context.tblEmployees?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
