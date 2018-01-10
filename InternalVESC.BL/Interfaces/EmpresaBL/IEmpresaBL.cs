using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VescENT.Request;
using VescENT.Response;

namespace VescBL.Interfaces
{
    public interface IEmpresaBL
    {
        GetEmpresaResponseDTO GetEmpresa(GetEmpresaRequestDTO empresaRequest);
        EditEmpresaResponseDTO EditEmpresa(EditEmpresaRequestDTO empresaRequest);
        AddEmpresaResponseDTO AddEmpresa(AddEmpresaRequestDTO empresaRequest);
    }
}
