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
using System.Web.Mvc;
using WebApi_Control_Vacunas_anti_Covid;

namespace WebApi_Control_Vacunas_anti_Covid.Controllers
{
    public class CiudadanoesController : ApiController
    {
        private Covid_Vacunas_DBEntities db = new Covid_Vacunas_DBEntities();

        // GET: api/Ciudadanoes
        public IQueryable<Ciudadano> GetCiudadanos()
        {
            return db.Ciudadanos;
        }

        // GET: api/Ciudadanoes/5
        [ResponseType(typeof(Ciudadano))]
        public IHttpActionResult GetCiudadano(string id)
        {
            Ciudadano ciudadano = db.Ciudadanos.Find(id);
            if (ciudadano == null)
            {
                return NotFound();
            }

            return Ok(ciudadano);
        }

        // PUT: api/Ciudadanoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCiudadano(string id, Ciudadano ciudadano)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ciudadano.Identidad)
            {
                return BadRequest();
            }

            db.Entry(ciudadano).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CiudadanoExists(id))
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

        // POST: api/Ciudadanoes
        [ResponseType(typeof(Ciudadano))]
        public IHttpActionResult PostCiudadano(Ciudadano ciudadano)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ciudadanos.Add(ciudadano);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CiudadanoExists(ciudadano.Identidad))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ciudadano.Identidad }, ciudadano);
        }

        // DELETE: api/Ciudadanoes/5
        [ResponseType(typeof(Ciudadano))]
        public IHttpActionResult DeleteCiudadano(string id)
        {
            Ciudadano varciudadano = db.Ciudadanos.Find(id);
            if (varciudadano == null)
            {
                return NotFound();
            }

            db.Ciudadanos.Remove(varciudadano);
            db.SaveChanges();

            return Ok(varciudadano);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CiudadanoExists(string id)
        {
            return db.Ciudadanos.Count(e => e.Identidad == id) > 0;
        }
    }
}