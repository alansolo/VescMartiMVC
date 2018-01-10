using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VescENT.Entities;

namespace VescENT.Response
{
    public class EditPlanResponseDTO
    {
        public List<CatPlan> ListaPlan { get; set; }
        public string Mensaje { get; set; }
    }
}
