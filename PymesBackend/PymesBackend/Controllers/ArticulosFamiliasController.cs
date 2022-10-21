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
using Datos;

namespace PymesBackend.Controllers
{
    public class ArticulosFamiliasController : ApiController
    {
        private PymesEntities db = new PymesEntities();

        // GET: api/ArticulosFamilias
        public IQueryable<ArticulosFamilias> GetArticulosFamilias()
        {
            return db.ArticulosFamilias;
        }

        // GET: api/ArticulosFamilias/5
        [ResponseType(typeof(ArticulosFamilias))]
        public IHttpActionResult GetArticulosFamilias(int id)
        {
            ArticulosFamilias articulosFamilias = db.ArticulosFamilias.Find(id);
            if (articulosFamilias == null)
            {
                return NotFound();
            }

            return Ok(articulosFamilias);
        }

        // PUT: api/ArticulosFamilias/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutArticulosFamilias(int id, ArticulosFamilias articulosFamilias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != articulosFamilias.IdArticuloFamilia)
            {
                return BadRequest();
            }

            db.Entry(articulosFamilias).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticulosFamiliasExists(id))
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

        // POST: api/ArticulosFamilias
        [ResponseType(typeof(ArticulosFamilias))]
        public IHttpActionResult PostArticulosFamilias(ArticulosFamilias articulosFamilias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ArticulosFamilias.Add(articulosFamilias);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = articulosFamilias.IdArticuloFamilia }, articulosFamilias);
        }

        // DELETE: api/ArticulosFamilias/5
        [ResponseType(typeof(ArticulosFamilias))]
        public IHttpActionResult DeleteArticulosFamilias(int id)
        {
            ArticulosFamilias articulosFamilias = db.ArticulosFamilias.Find(id);
            if (articulosFamilias == null)
            {
                return NotFound();
            }

            db.ArticulosFamilias.Remove(articulosFamilias);
            db.SaveChanges();

            return Ok(articulosFamilias);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ArticulosFamiliasExists(int id)
        {
            return db.ArticulosFamilias.Count(e => e.IdArticuloFamilia == id) > 0;
        }
    }
}