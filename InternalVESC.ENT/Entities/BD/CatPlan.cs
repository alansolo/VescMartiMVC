//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VescENT.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class CatPlan
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public CatPlan()
        //{
        //    this.Empleado = new HashSet<Empleado>();
        //    this.PlanEmpresa = new HashSet<PlanEmpresa>();
        //}
    
        public int idPlan { get; set; }
        public string plan { get; set; }
        public string descripcion { get; set; }
        public int idModalidadPago { get; set; }
        public string modalidadPago { get; set; }
        public System.DateTime fechaInsert { get; set; }
        public string usuarioInsert { get; set; }
        public Nullable<System.DateTime> fechaUpdate { get; set; }
        public string usuarioUpdate { get; set; }
        public string mensaje { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Empleado> Empleado { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<PlanEmpresa> PlanEmpresa { get; set; }
    }
}
