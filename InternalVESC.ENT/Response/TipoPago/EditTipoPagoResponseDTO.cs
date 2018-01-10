using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VescENT.Entities;

namespace VescENT.Response
{
    public class EditTipoPagoResponseDTO
    {
        public List<CatTipoPago> ListaTipoPago { get; set; }
        public string Mensaje { get; set; }
    }
}
