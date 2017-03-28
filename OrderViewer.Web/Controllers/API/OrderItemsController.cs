﻿using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using OrderViewer.Web.Models;

namespace OrderViewer.WebAPI.Controllers
{
    [Route("api/orders/{orderId}/orderItems/{id?}")]
    public class OrderItemsController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/OrderItems
        public IQueryable<OrderItem> GetOrderItems(int orderId)
        {
            return db.OrderItems;
        }

        // GET: api/OrderItems/5
        [ResponseType(typeof(OrderItem))]
        public async Task<IHttpActionResult> GetOrderItem(int orderId, int id)
        {
            OrderItem orderItem = await db.OrderItems.FindAsync(id);
            if (orderItem == null)
            {
                return NotFound();
            }

            return Ok(orderItem);
        }

        //// PUT: api/OrderItems/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutOrderItem(int id, OrderItem orderItem)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != orderItem.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(orderItem).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!OrderItemExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/OrderItems
        //[ResponseType(typeof(OrderItem))]
        //public async Task<IHttpActionResult> PostOrderItem(OrderItem orderItem)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.OrderItems.Add(orderItem);
        //    await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = orderItem.Id }, orderItem);
        //}

        //// DELETE: api/OrderItems/5
        //[ResponseType(typeof(OrderItem))]
        //public async Task<IHttpActionResult> DeleteOrderItem(int id)
        //{
        //    OrderItem orderItem = await db.OrderItems.FindAsync(id);
        //    if (orderItem == null)
        //    {
        //        return NotFound();
        //    }

        //    db.OrderItems.Remove(orderItem);
        //    await db.SaveChangesAsync();

        //    return Ok(orderItem);
        //}

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrderItemExists(int id)
        {
            return db.OrderItems.Count(e => e.Id == id) > 0;
        }
    }
}