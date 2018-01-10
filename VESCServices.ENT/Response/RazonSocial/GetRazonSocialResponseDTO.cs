using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VESCServices.ENT.Entities;

namespace VESCServices.ENT.Request.RazonSocial
{
    public class GetRazonSocialResponseDTO
    {
        public List<RazonSocialDTO> ListaRazonSocial { get; set; }
        public string Mensaje { get; set; }
    }
}
