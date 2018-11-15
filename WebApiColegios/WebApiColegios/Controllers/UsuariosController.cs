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
using WebApiColegios.Models;

namespace WebApiColegios.Controllers
{
    public class UsuariosController : ApiController
    {
        private DrogadiccionEntities db = new DrogadiccionEntities();

        // GET: api/Usuarios
        public IEnumerable<Usuarios> GetUsuario()
        {
            return db.Usuarios;

        }
        public IEnumerable<Usuarios> GetAcudiente()
        {
            List<Usuarios> acudientes = new List<Usuarios>();
            acudientes  = db.Usuarios.Where(x => x.Rol == "Acudiente").ToList();
            return acudientes;
        }

        // GET: api/Usuarios/5
        [ResponseType(typeof(Usuario))]
        public async Task<Usuarios> GetUsuario(string usuario)
        {
            Usuarios usuariodata =  db.Usuarios.Where(x => x.Usuario.Contains(usuario)).FirstOrDefault();

            return usuariodata;
        }

        // PUT: api/Usuarios/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsuario(int id, Usuarios usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuario.Id)
            {
                return BadRequest();
            }

            db.Entry(usuario).State = EntityState.Modified;

            try
            {
                 db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
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

        // POST: api/Usuarios
        [ResponseType(typeof(bool))]
        //[AcceptVerbs("GET", "POST")]
        //[System.Web.Http.HttpPost]
        public bool PostUsuario(Usuarios usuario)
        {
            try
            {
                bool respuesta = false;
                bool existeUsuario = db.Usuarios.Any(x => x.Usuario == usuario.Usuario);
                if (!existeUsuario)
                {
                    db.Usuarios.Add(usuario);
                    db.SaveChanges();
                    respuesta = true;
                }
                //Si inserto el registro retorna true de lo contrario false 
                return respuesta;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
        }

        // DELETE: api/Usuarios/5
        [ResponseType(typeof(Usuario))]
        public async Task<IHttpActionResult> DeleteUsuario(int id)
        {
            Usuarios usuario = await db.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            db.Usuarios.Remove(usuario);
            await db.SaveChangesAsync();

            return Ok(usuario);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsuarioExists(int id)
        {
            return db.Usuario.Count(e => e.usuarioId == id) > 0;
        }
    }
}