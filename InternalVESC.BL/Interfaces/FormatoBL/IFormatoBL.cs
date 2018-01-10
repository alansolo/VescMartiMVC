using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VescENT.Request;
using VescENT.Response;

namespace VescBL.Interfaces
{
    public interface IFormatoBL
    {
        GetFormatoResponseDTO GetFormato(GetFormatoRequestDTO formatoRequest);
        EditFormatoResponseDTO EditFormato(EditFormatoRequestDTO formatoRequest);
        AddFormatoResponseDTO AddFormato(AddFormatoRequestDTO formatoRequest);
    }
}
