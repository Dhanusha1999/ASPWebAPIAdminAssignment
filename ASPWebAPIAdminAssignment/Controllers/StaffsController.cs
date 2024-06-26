﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASPWebAPIAdminAssignment.Model;
using ASPWebAPIAdminAssignment.Repository;
using ASPWebAPIAdminAssignment.ViewModel;

namespace ASPWebAPIAdminAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffsController : ControllerBase
    {
        //Call repository
        private readonly IEmployeeRepository _repository;

        public StaffsController(IEmployeeRepository repository)
        {
            _repository = repository;
        }



        #region  // GET: api/Employees

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Staff>>> GetStaff()
        {
            return await _repository.GetStaff();
        }
        #endregion


        #region GET as ViewModel>> StaffViewModel

        [HttpGet]
        [Route("vm")]
        public async Task<ActionResult<IEnumerable<StaffViewModel>>> GetViewModelStaffs()
        {
            return await _repository.GetViewModelStaffs();
        }
        #endregion

        /*
        // GET: api/Staffs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Staff>> GetStaff(int id)
        {
          if (_context.Staff == null)
          {
              return NotFound();
          }
            var staff = await _context.Staff.FindAsync(id);

            if (staff == null)
            {
                return NotFound();
            }

            return staff;
        }

        // PUT: api/Staffs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStaff(int id, Staff staff)
        {
            if (id != staff.StaffId)
            {
                return BadRequest();
            }

            _context.Entry(staff).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffExists(id))
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

        // POST: api/Staffs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Staff>> PostStaff(Staff staff)
        {
          if (_context.Staff == null)
          {
              return Problem("Entity set 'AdminDbContext.Staff'  is null.");
          }
            _context.Staff.Add(staff);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStaff", new { id = staff.StaffId }, staff);
        }

        // DELETE: api/Staffs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaff(int id)
        {
            if (_context.Staff == null)
            {
                return NotFound();
            }
            var staff = await _context.Staff.FindAsync(id);
            if (staff == null)
            {
                return NotFound();
            }

            _context.Staff.Remove(staff);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StaffExists(int id)
        {
            return (_context.Staff?.Any(e => e.StaffId == id)).GetValueOrDefault();
        }
        */
    }
}
