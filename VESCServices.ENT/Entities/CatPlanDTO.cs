using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VESCServices.ENT.Entities
{
    class CatPlanDTO
    {
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
    }
}
