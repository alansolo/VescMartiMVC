using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VescENT.Entities;

namespace VescENT.Response
{
    public class GetRazonSocialResponseDTO
    {
        public List<RazonSocial> ListaRazonSocial { get; set; }
        public string Mensaje { get; set; }
    }
}
