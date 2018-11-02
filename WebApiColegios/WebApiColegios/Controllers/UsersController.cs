using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApiColegios.Models;

namespace WebApiColegios.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "X-My-Header")]

    public class UsersController : ApiController
    {
        [AcceptVerbs("GET", "POST")]
        [System.Web.Http.HttpPost]
        public bool POST([FromBody]User user)
        {
            try
            {
                bool respuesta = false;
                using (DrogadiccionEntities context = new DrogadiccionEntities())
                {
                    //context.Configuration.ProxyCreationEnabled = false;
                    var data = context.Usuario.Where(x => x.email == user.Name).Select(s => new { s.contrasena, s.email }).ToList();

                    if (data.Count > 0)
                    {
                        foreach (var item in data)
                        {
                            if (user.password == item.contrasena)
                            {
                                respuesta = true;
                            }
                        }
                    }
                    return respuesta;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        // POST: api/Users


        // PUT: api/Users/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Users/5
        public void Delete(int id)
        {
        }
    }
}
