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
using PruebaToken.Models;

namespace PruebaToken.Controllers
{
    public class PersonaDatosController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/PersonaDatos
        [Authorize]
        public IQueryable<PersonaDatos> GetPersonaDatos()
        {
            return db.PersonaDatos;
        }

        // GET: api/PersonaDatos/5
        [Authorize]
        [ResponseType(typeof(PersonaDatos))]
        public IHttpActionResult GetPersonaDatos(int id)
        {
            PersonaDatos personaDatos = db.PersonaDatos.Find(id);
            if (personaDatos == null)
            {
                return NotFound();
            }

            return Ok(personaDatos);
        }

        // PUT: api/PersonaDatos/5
        [Authorize]
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPersonaDatos(int id, PersonaDatos personaDatos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != personaDatos.PersonId)
            {
                return BadRequest();
            }

            db.Entry(personaDatos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonaDatosExists(id))
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

        // POST: api/PersonaDatos
        [Authorize]
        [ResponseType(typeof(PersonaDatos))]
        public IHttpActionResult PostPersonaDatos(PersonaDatos personaDatos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PersonaDatos.Add(personaDatos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = personaDatos.PersonId }, personaDatos);
        }

        // DELETE: api/PersonaDatos/5
        [Authorize]
        [ResponseType(typeof(PersonaDatos))]
        public IHttpActionResult DeletePersonaDatos(int id)
        {
            PersonaDatos personaDatos = db.PersonaDatos.Find(id);
            if (personaDatos == null)
            {
                return NotFound();
            }

            db.PersonaDatos.Remove(personaDatos);
            db.SaveChanges();

            return Ok(personaDatos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonaDatosExists(int id)
        {
            return db.PersonaDatos.Count(e => e.PersonId == id) > 0;
        }
    }
}