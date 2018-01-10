using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VescENT.Entities;

namespace VescENT.Response
{
    public class GetPlanResponseDTO
    {
        public List<CatPlan> ListaEmpresa { get; set; }

        public string Mensaje { get; set; }
    }
}
