﻿using System;
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
    public class DesignationsController : ControllerBase
    {
        private readonly EmployeeContext _context;

        public DesignationsController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: api/Designations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblDesignation>>> GettblDesignations()
        {
          if (_context.tblDesignations == null)
          {
              return NotFound();
          }
            return await _context.tblDesignations.ToListAsync();
        }

        // GET: api/Designations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblDesignation>> GetTblDesignation(int id)
        {
          if (_context.tblDesignations == null)
          {
              return NotFound();
          }
            var tblDesignation = await _context.tblDesignations.FindAsync(id);

            if (tblDesignation == null)
            {
                return NotFound();
            }

            return tblDesignation;
        }

        // PUT: api/Designations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblDesignation(int id, TblDesignation tblDesignation)
        {
            if (id != tblDesignation.Id)
            {
                return BadRequest();
            }

            _context.Entry(tblDesignation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblDesignationExists(id))
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

        // POST: api/Designations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblDesignation>> PostTblDesignation(TblDesignation tblDesignation)
        {
          if (_context.tblDesignations == null)
          {
              return Problem("Entity set 'EmployeeContext.tblDesignations'  is null.");
          }
            _context.tblDesignations.Add(tblDesignation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblDesignation", new { id = tblDesignation.Id }, tblDesignation);
        }

        // DELETE: api/Designations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblDesignation(int id)
        {
            if (_context.tblDesignations == null)
            {
                return NotFound();
            }
            var tblDesignation = await _context.tblDesignations.FindAsync(id);
            if (tblDesignation == null)
            {
                return NotFound();
            }

            _context.tblDesignations.Remove(tblDesignation);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TblDesignationExists(int id)
        {
            return (_context.tblDesignations?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
