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
    
    public partial class Renta_Devolucion_Copia
    {
        public int idRentaDevolucion { get; set; }
        public int IdEmpleado { get; set; }
        public int IdVehiculo { get; set; }
        public int IdCliente { get; set; }
        public System.DateTime FechaRenta { get; set; }
        public System.DateTime FechaDevolucion { get; set; }
        public decimal MontoDia { get; set; }
        public string CantidadDias { get; set; }
        public string Comentario { get; set; }
        public string Estado { get; set; }
    
        public virtual Vehiculo Vehiculo { get; set; }
        public virtual Empleado Empleado { get; set; }
        public virtual cliente cliente { get; set; }
    }
}