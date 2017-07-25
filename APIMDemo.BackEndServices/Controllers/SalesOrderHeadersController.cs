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
using APIMDemo.BackEndServices.Models;

namespace APIMDemo.BackEndServices.Controllers
{
    public class SalesOrderHeadersController : ApiController
    {
        private AdventureWorksModel db = new AdventureWorksModel();

        // GET: api/SalesOrderHeaders
        public IQueryable<SalesOrderHeader> GetSalesOrderHeaders()
        {
            return db.SalesOrderHeaders;
        }

        // GET: api/SalesOrderHeaders/5
        [ResponseType(typeof(SalesOrderHeader))]
        public IHttpActionResult GetSalesOrderHeader(int id)
        {
            SalesOrderHeader salesOrderHeader = db.SalesOrderHeaders.Find(id);
            if (salesOrderHeader == null)
            {
                return NotFound();
            }

            return Ok(salesOrderHeader);
        }

        // PUT: api/SalesOrderHeaders/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSalesOrderHeader(int id, SalesOrderHeader salesOrderHeader)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != salesOrderHeader.SalesOrderID)
            {
                return BadRequest();
            }

            db.Entry(salesOrderHeader).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SalesOrderHeaderExists(id))
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

        // POST: api/SalesOrderHeaders
        [ResponseType(typeof(SalesOrderHeader))]
        public IHttpActionResult PostSalesOrderHeader(SalesOrderHeader salesOrderHeader)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SalesOrderHeaders.Add(salesOrderHeader);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SalesOrderHeaderExists(salesOrderHeader.SalesOrderID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = salesOrderHeader.SalesOrderID }, salesOrderHeader);
        }

        // DELETE: api/SalesOrderHeaders/5
        [ResponseType(typeof(SalesOrderHeader))]
        public IHttpActionResult DeleteSalesOrderHeader(int id)
        {
            SalesOrderHeader salesOrderHeader = db.SalesOrderHeaders.Find(id);
            if (salesOrderHeader == null)
            {
                return NotFound();
            }

            db.SalesOrderHeaders.Remove(salesOrderHeader);
            db.SaveChanges();

            return Ok(salesOrderHeader);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SalesOrderHeaderExists(int id)
        {
            return db.SalesOrderHeaders.Count(e => e.SalesOrderID == id) > 0;
        }
    }
}