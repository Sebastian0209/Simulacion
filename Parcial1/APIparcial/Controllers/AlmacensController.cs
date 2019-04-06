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
using APIparcial.Models;

namespace APIparcial.Controllers
{
    public class AlmacensController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Almacens
        public IQueryable<Almacen> GetAlmacens()
        {
            return db.Almacens;
        }

        // GET: api/Almacens/5
        [ResponseType(typeof(Almacen))]
        public IHttpActionResult GetAlmacen(int id)
        {
            Almacen almacen = db.Almacens.Find(id);
            if (almacen == null)
            {
                return NotFound();
            }

            return Ok(almacen);
        }

        // PUT: api/Almacens/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAlmacen(int id, Almacen almacen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != almacen.IdProducto)
            {
                return BadRequest();
            }

            db.Entry(almacen).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlmacenExists(id))
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

        // POST: api/Almacens
        [ResponseType(typeof(Almacen))]
        public IHttpActionResult PostAlmacen(Almacen almacen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Almacens.Add(almacen);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = almacen.IdProducto }, almacen);
        }

        // DELETE: api/Almacens/5
        [ResponseType(typeof(Almacen))]
        public IHttpActionResult DeleteAlmacen(int id)
        {
            Almacen almacen = db.Almacens.Find(id);
            if (almacen == null)
            {
                return NotFound();
            }

            db.Almacens.Remove(almacen);
            db.SaveChanges();

            return Ok(almacen);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AlmacenExists(int id)
        {
            return db.Almacens.Count(e => e.IdProducto == id) > 0;
        }
    }
}