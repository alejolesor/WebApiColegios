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
    
    public partial class Fundacion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Fundacion()
        {
            this.Actividad = new HashSet<Actividad>();
        }
    
        public int fundacionId { get; set; }
        public Nullable<int> usuarioId { get; set; }
        public string identificacion { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public Nullable<int> telefono { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Actividad> Actividad { get; set; }
    }
}
