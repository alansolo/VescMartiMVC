using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VESCServices.ENT.Common;

namespace VESCServices.ENT.Request.RazonSocial
{
    public class GetRazonSocialRequestDTO: RequestBaseDTO
    {
        public int IdRazonSocial { get; set; }
        public string RazonSocial { get; set; }
    }
}
