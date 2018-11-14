using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiColegios.Models
{
    public class UsuarioUnic
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Nullable<int> Rol { get; set; }
    }
}