using Newtonsoft.Json;
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
using WebApiColegios.Models;

namespace WebApiColegios.Controllers
{
    public class PreguntasController : ApiController
    {
        private DrogadiccionEntities db = new DrogadiccionEntities();

        // GET: api/Preguntas
        [AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpGet]
        public IEnumerable<Pregunta> GetPregunta()
        {
            List<Pregunta> pregunta = new List<Pregunta>();
            pregunta = db.Pregunta.ToList();
       
            return pregunta;
        }

        public IEnumerable<Respuesta> GetRespuesta()
        {
            List<Respuesta> pregunta = new List<Respuesta>();
            pregunta = db.Respuesta.ToList();
            return pregunta;
        }

        // GET: api/Preguntas/5
        [ResponseType(typeof(Pregunta))]
        public IHttpActionResult GetPregunta(int id)
        {
            Pregunta pregunta = db.Pregunta.Find(id);
            if (pregunta == null)
            {
                return NotFound();
            }

            return Ok(pregunta);
        }

        // PUT: api/Preguntas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPregunta(int id, Pregunta pregunta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pregunta.preguntaId)
            {
                return BadRequest();
            }

            db.Entry(pregunta).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreguntaExists(id))
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

        // POST: api/Preguntas
        [ResponseType(typeof(Pregunta))]
        public IHttpActionResult PostPregunta(Pregunta pregunta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Pregunta.Add(pregunta);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pregunta.preguntaId }, pregunta);
        }

        // DELETE: api/Preguntas/5
        [ResponseType(typeof(Pregunta))]
        public IHttpActionResult DeletePregunta(int id)
        {
            Pregunta pregunta = db.Pregunta.Find(id);
            if (pregunta == null)
            {
                return NotFound();
            }

            db.Pregunta.Remove(pregunta);
            db.SaveChanges();

            return Ok(pregunta);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PreguntaExists(int id)
        {
            return db.Pregunta.Count(e => e.preguntaId == id) > 0;
        }
    }
}