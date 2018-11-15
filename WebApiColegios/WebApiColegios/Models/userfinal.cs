using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiColegios.Models
{
    public class userfinal
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Usuario { get; set; }
        public string Contrseña { get; set; }
        public Nullable<int> Rol { get; set; }
        public string foto { get; set; }
    }
}