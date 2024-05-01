using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductSalesWebAPIAssignment.Models;
using ProductSalesWebAPIAssignment.Repository;
using ProductSalesWebAPIAssignment.ViewModel;

namespace ProductSalesWebAPIAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffProductsController : ControllerBase
    {
        //Call repository
        private readonly IStaffProductRepository _repository;

        public StaffProductsController(IStaffProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StaffProduct>>> GetStaffProduct()
        {
            return await _repository.GetStaffProduct();
        }

        [HttpGet]
        [Route("vm")]
        public async Task<ActionResult<IEnumerable<StaffProductViewModel>>> GetViewModelStaffProduct()
        {
            return await _repository.GetViewModelStaffProduct();
        }
        /*
        // GET: api/StaffProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StaffProduct>> GetStaffProduct(int id)
        {
          if (_context.StaffProducts == null)
          {
              return NotFound();
          }
            var staffProduct = await _context.StaffProducts.FindAsync(id);

            if (staffProduct == null)
            {
                return NotFound();
            }

            return staffProduct;
        }

        // PUT: api/StaffProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStaffProduct(int id, StaffProduct staffProduct)
        {
            if (id != staffProduct.StaffId)
            {
                return BadRequest();
            }

            _context.Entry(staffProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StaffProductExists(id))
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

        // POST: api/StaffProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StaffProduct>> PostStaffProduct(StaffProduct staffProduct)
        {
          if (_context.StaffProducts == null)
          {
              return Problem("Entity set 'ProductSalesDbContext.StaffProducts'  is null.");
          }
            _context.StaffProducts.Add(staffProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStaffProduct", new { id = staffProduct.StaffId }, staffProduct);
        }

        // DELETE: api/StaffProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaffProduct(int id)
        {
            if (_context.StaffProducts == null)
            {
                return NotFound();
            }
            var staffProduct = await _context.StaffProducts.FindAsync(id);
            if (staffProduct == null)
            {
                return NotFound();
            }

            _context.StaffProducts.Remove(staffProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StaffProductExists(int id)
        {
            return (_context.StaffProducts?.Any(e => e.StaffId == id)).GetValueOrDefault();
        }
        */
    }
}
