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
    public class OrderItemsController : ControllerBase
    {
        //Call repository
        private readonly IOrderItemRepository _repository;

        public OrderItemsController(IOrderItemRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderItem>>> GetOrderItem()
        {
            return await _repository.GetOrderItem();
        }
     
        [HttpGet]
        [Route("vm")]
        public async Task<ActionResult<IEnumerable<OrderItemViewModel>>> GetViewModelOrderItem()
        {
            return await _repository.GetViewModelOrderItem();
        }
      
        /*
        // GET: api/OrderItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderItem>> GetOrderItem(int id)
        {
          if (_context.OrderItems == null)
          {
              return NotFound();
          }
            var orderItem = await _context.OrderItems.FindAsync(id);

            if (orderItem == null)
            {
                return NotFound();
            }

            return orderItem;
        }

        // PUT: api/OrderItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderItem(int id, OrderItem orderItem)
        {
            if (id != orderItem.ItemId)
            {
                return BadRequest();
            }

            _context.Entry(orderItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderItemExists(id))
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

        // POST: api/OrderItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderItem>> PostOrderItem(OrderItem orderItem)
        {
          if (_context.OrderItems == null)
          {
              return Problem("Entity set 'ProductSalesDbContext.OrderItems'  is null.");
          }
            _context.OrderItems.Add(orderItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderItem", new { id = orderItem.ItemId }, orderItem);
        }

        // DELETE: api/OrderItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderItem(int id)
        {
            if (_context.OrderItems == null)
            {
                return NotFound();
            }
            var orderItem = await _context.OrderItems.FindAsync(id);
            if (orderItem == null)
            {
                return NotFound();
            }

            _context.OrderItems.Remove(orderItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderItemExists(int id)
        {
            return (_context.OrderItems?.Any(e => e.ItemId == id)).GetValueOrDefault();
        }
        */
    }
}
