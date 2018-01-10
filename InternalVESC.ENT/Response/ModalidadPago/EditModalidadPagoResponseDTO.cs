using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VescENT.Entities;

namespace VescENT.Response
{
    public class EditModalidadPagoResponseDTO
    {
        public List<CatModalidadPago> ListaModalidadPago { get; set; }
        public string Mensaje { get; set; }
    }
}
