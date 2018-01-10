using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VESCServices.ENT.Common;

namespace VESCServices.ENT.Request.Padron
{
    public class ConsultaPadronRequestDTO : RequestBaseDTO
    {
        public int EmpresaId { get; set; }
    }
}
