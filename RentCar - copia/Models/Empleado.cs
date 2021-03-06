//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RentCar.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Empleado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Empleado()
        {
            this.Renta_Devolucion = new HashSet<Renta_Devolucion>();
            this.Renta_Devolucion_Copia = new HashSet<Renta_Devolucion_Copia>();
            this.Inspeccion = new HashSet<Inspeccion>();
        }
    
        public int idEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Tanda_Labor { get; set; }
        public Nullable<int> Porciento_comision { get; set; }
        public Nullable<System.DateTime> fecha_ingreso { get; set; }
        public string usuario { get; set; }
        public string password { get; set; }
        public string Estado { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Renta_Devolucion> Renta_Devolucion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Renta_Devolucion_Copia> Renta_Devolucion_Copia { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inspeccion> Inspeccion { get; set; }
    }
}
