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
    
    public partial class CatNivel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CatNivel()
        {
            //this.CategoriaClub = new HashSet<CategoriaClub>();
        }
    
        public int idNivel { get; set; }
        public string nivel { get; set; }
        public string descripcion { get; set; }
        public System.DateTime fechaInsert { get; set; }
        public string usuarioInsert { get; set; }
        public Nullable<System.DateTime> fechaUpdate { get; set; }
        public string usuarioUpdate { get; set; }
        public string mensaje { get; set; }
    
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<CategoriaClub> CategoriaClub { get; set; }
    }
}
