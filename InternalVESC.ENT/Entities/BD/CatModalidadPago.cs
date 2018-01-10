using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VescENT.Entities
{
    public partial class CatModalidadPago
    {
        public int idModalidadPago { get; set; }
        public string modalidadPago { get; set; }
        public string descripcion { get; set; }
        public System.DateTime fechaInsert { get; set; }
        public string usuarioInsert { get; set; }
        public Nullable<System.DateTime> fechaUpdate { get; set; }
        public string usuarioUpdate { get; set; }
        public string mensaje { get; set; }
    }
}
