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
using WebApi_Control_Vacunas_anti_Covid;

namespace WebApi_Control_Vacunas_anti_Covid.Controllers
{
    public class VacunasCiudadanoesController : ApiController
    {
        private Covid_Vacunas_DBEntities db = new Covid_Vacunas_DBEntities();

        // GET: api/VacunasCiudadanoes
        public IQueryable<VacunasCiudadano> GetVacunasCiudadanoes()
        {
            return db.VacunasCiudadanoes;
        }

        // GET: api/VacunasCiudadanoes/5
        [ResponseType(typeof(VacunasCiudadano))]
        public IHttpActionResult GetVacunasCiudadano(DateTime id)
        {
            VacunasCiudadano vacunasCiudadano = db.VacunasCiudadanoes.Find(id);
            if (vacunasCiudadano == null)
            {
                return NotFound();
            }

            return Ok(vacunasCiudadano);
        }

        // PUT: api/VacunasCiudadanoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVacunasCiudadano(DateTime id, VacunasCiudadano vacunasCiudadano)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vacunasCiudadano.fecha)
            {
                return BadRequest();
            }

            db.Entry(vacunasCiudadano).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VacunasCiudadanoExists(id))
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

        // POST: api/VacunasCiudadanoes
        [ResponseType(typeof(VacunasCiudadano))]
        public IHttpActionResult PostVacunasCiudadano(VacunasCiudadano vacunasCiudadano)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VacunasCiudadanoes.Add(vacunasCiudadano);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (VacunasCiudadanoExists(vacunasCiudadano.fecha))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = vacunasCiudadano.fecha }, vacunasCiudadano);
        }

        // DELETE: api/VacunasCiudadanoes/5
        [ResponseType(typeof(VacunasCiudadano))]
        public IHttpActionResult DeleteVacunasCiudadano(DateTime id)
        {
            VacunasCiudadano vacunasCiudadano = db.VacunasCiudadanoes.Find(id);
            if (vacunasCiudadano == null)
            {
                return NotFound();
            }

            db.VacunasCiudadanoes.Remove(vacunasCiudadano);
            db.SaveChanges();

            return Ok(vacunasCiudadano);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VacunasCiudadanoExists(DateTime id)
        {
            return db.VacunasCiudadanoes.Count(e => e.fecha == id) > 0;
        }
    }
}