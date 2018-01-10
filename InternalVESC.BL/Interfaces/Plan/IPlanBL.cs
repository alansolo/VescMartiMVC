using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using VescENT.Response;
using VescENT.Request;

namespace VescBL.Interfaces
{
    public interface IPlanBL
    {
        GetPlanResponseDTO GetPlan(GetPlanRequestDTO planRequest);
        EditPlanResponseDTO EditPlan(EditPlanRequestDTO planRequest);
        AddPlanResponseDTO AddPlan(AddPlanRequestDTO planRequest);

    }
}
