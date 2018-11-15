using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiColegios.Models
{
    public class UsuarioUnic
    {
        public int Id { get; set; }
        public string identificacion { get; set; }
        public string TpoDocuemnto { get; set; }
        public string Nombre { get; set; }
        public Nullable<System.DateTime> fechaNacimiento { get; set; }
        public Nullable<int> telefono { get; set; }
        public Nullable<decimal> celular { get; set; }
        public string Genero { get; set; }
        public string Direccion  { get; set; }
        public string email { get; set; }
        public string contraseña { get; set; }
        public Nullable<int> institucionId { get; set; }
        public Nullable<bool> estado { get; set; }
        public Nullable<int> Rol { get; set; }
        public string Foto { get; set; }

    }
}