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
        public IQueryable<Usuario> GetUsuario()
        {
            return db.Usuario;
        }

        // GET: api/Usuarios/5
        [ResponseType(typeof(Usuario))]
        public async Task<UsuarioUnic> GetUsuario(string email)
        {
            Usuario usuario =  db.Usuario.Where(x => x.email == email).FirstOrDefault();

            UsuarioUnic User = new UsuarioUnic();
            User.Id = usuario.usuarioId;
            User.Nombre = usuario.nombre;
            User.Rol = usuario.rolId;
            return User;
        }

        // PUT: api/Usuarios/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usuario.usuarioId)
            {
                return BadRequest();
            }

            db.Entry(usuario).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
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
        public bool PostUsuario(Usuario usuario)
        {
            try
            {
                bool respuesta = false;
                bool existeUsuario = db.Usuario.Any(x => x.email == usuario.email);
                if (!existeUsuario)
                {
                    db.Usuario.Add(usuario);
                    db.SaveChangesAsync();
                    respuesta = true;
                }
                //Si inserto el registro retorna true de lo contrario false 
                return respuesta;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        // DELETE: api/Usuarios/5
        [ResponseType(typeof(Usuario))]
        public async Task<IHttpActionResult> DeleteUsuario(int id)
        {
            Usuario usuario = await db.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            db.Usuario.Remove(usuario);
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