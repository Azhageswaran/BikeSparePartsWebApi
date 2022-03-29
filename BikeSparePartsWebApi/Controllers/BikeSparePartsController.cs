using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BikeSparePartsWebApi.Models;

namespace BikeSparePartsWebApi.Controllers
{
    public class BikeSparePartsController : ApiController
    {
        private AppDBContext db = new AppDBContext();

        // GET: api/BikeSpareParts
        public IQueryable<BikeSpareParts> GetBikeSpares()
        {
            return db.BikeSpares;
        }

        // GET: api/BikeSpareParts/5
        [ResponseType(typeof(BikeSpareParts))]
        public IHttpActionResult GetBikeSpareParts(int id)
        {
            BikeSpareParts bikeSpareParts = db.BikeSpares.Find(id);
            if (bikeSpareParts == null)
            {
                return NotFound();
            }

            return Ok(bikeSpareParts);
        }

        // PUT: api/BikeSpareParts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBikeSpareParts(int id, BikeSpareParts bikeSpareParts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bikeSpareParts.SparePartID)
            {
                return BadRequest();
            }

            db.Entry(bikeSpareParts).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BikeSparePartsExists(id))
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

        // POST: api/BikeSpareParts
        [ResponseType(typeof(BikeSpareParts))]
        public IHttpActionResult PostBikeSpareParts(BikeSpareParts bikeSpareParts)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BikeSpares.Add(bikeSpareParts);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = bikeSpareParts.SparePartID }, bikeSpareParts);
        }

        // DELETE: api/BikeSpareParts/5
        [ResponseType(typeof(BikeSpareParts))]
        public IHttpActionResult DeleteBikeSpareParts(int id)
        {
            BikeSpareParts bikeSpareParts = db.BikeSpares.Find(id);
            if (bikeSpareParts == null)
            {
                return NotFound();
            }

            db.BikeSpares.Remove(bikeSpareParts);
            db.SaveChanges();

            return Ok(bikeSpareParts);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BikeSparePartsExists(int id)
        {
            return db.BikeSpares.Count(e => e.SparePartID == id) > 0;
        }
    }
}