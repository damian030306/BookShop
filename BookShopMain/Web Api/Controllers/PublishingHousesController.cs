using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Web_Api.Data;
using Web_Api.Models;

namespace Web_Api.Controllers
{
    public class PublishingHousesController : ApiController
    {
        private Web_ApiContext db = new Web_ApiContext();

        // GET: api/PublishingHouses
        public IQueryable<PublishingHouse> GetPublishingHouses()
        {
            return db.PublishingHouses;
        }

        // GET: api/PublishingHouses/5
        [ResponseType(typeof(PublishingHouse))]
        public async Task<IHttpActionResult> GetPublishingHouse(int id)
        {
            PublishingHouse publishingHouse = await db.PublishingHouses.FindAsync(id);
            if (publishingHouse == null)
            {
                return NotFound();
            }

            return Ok(publishingHouse);
        }
        [Route("api/PublishingHouses3")]
        public async Task<List<PublishingHouse>> GetAll2()

        {
            return await db.PublishingHouses.ToListAsync();
        }
        // PUT: api/PublishingHouses/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPublishingHouse(int id, PublishingHouse publishingHouse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != publishingHouse.id)
            {
                return BadRequest();
            }

            db.Entry(publishingHouse).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PublishingHouseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/PublishingHouses
        [ResponseType(typeof(PublishingHouse))]
        public async Task<IHttpActionResult> PostPublishingHouse(PublishingHouse publishingHouse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PublishingHouses.Add(publishingHouse);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = publishingHouse.id }, publishingHouse);
        }

        // DELETE: api/PublishingHouses/5
        [ResponseType(typeof(PublishingHouse))]
        public async Task<IHttpActionResult> DeletePublishingHouse(int id)
        {
            PublishingHouse publishingHouse = await db.PublishingHouses.FindAsync(id);
            if (publishingHouse == null)
            {
                return NotFound();
            }

            db.PublishingHouses.Remove(publishingHouse);
            await db.SaveChangesAsync();

            return Ok(publishingHouse);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PublishingHouseExists(int id)
        {
            return db.PublishingHouses.Count(e => e.id == id) > 0;
        }
    }
}