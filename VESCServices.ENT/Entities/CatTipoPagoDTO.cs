using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VESCServices.ENT.Entities
{
    public class CatTipoPagoDTO
    {
        public int idTipoPago { get; set; }
        public string tipoPago { get; set; }
        public string descripcion { get; set; }
        public decimal porcentajeDescuento { get; set; }
        public System.DateTime fechaInsert { get; set; }
        public string usuarioInsert { get; set; }
        public Nullable<System.DateTime> fechaUpdate { get; set; }
        public string usuarioUpdate { get; set; }
  
    }
}
