//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApiColegios.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Camino
    {
        public int camino1 { get; set; }
        public Nullable<int> respuestaId { get; set; }
        public Nullable<int> salidaId { get; set; }
    
        public virtual Pregunta Pregunta { get; set; }
        public virtual Respuesta Respuesta { get; set; }
    }
}