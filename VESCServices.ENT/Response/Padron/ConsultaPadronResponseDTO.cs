using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using VESCServices.ENT.Common;
using VESCServices.ENT.Entities;

namespace VESCServices.ENT.Response.Padron
{
    [DataContract]
    public class ConsultaPadronResponseDTO : ResponseBaseDTO
    {
        [DataMember]
        public List<PadronDTO> PadronLista { get; set; }
    }
}
