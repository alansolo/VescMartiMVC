using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace VESCServices.ENT.Entities
{
    [DataContract]
    public class PadronDTO
    {
        [DataMember]
        public string RazonSocial { get; set; }
        [DataMember]
        public string plan { get; set; }
        [DataMember]
        public int EmpleadoId { get; set; }
        [DataMember]
        public string Empleado { get; set; }
        [DataMember]
        public string Club { get; set; }
        [DataMember]
        public decimal ICSI { get; set; }
        [DataMember]
        public decimal IC { get; set; }
        [DataMember]
        public decimal ITC { get; set; }
        [DataMember]
        public decimal RSI { get; set; }
        [DataMember]
        public decimal IR { get; set; }
        [DataMember]
        public decimal RT { get; set; }
        [DataMember]
        public decimal ESI { get; set; }
        [DataMember]
        public decimal IE { get; set; }
        [DataMember]
        public decimal ET { get; set; }
        [DataMember]
        public decimal Total { get; set; }
        [DataMember]
        public bool Estatus { get; set; }
        [DataMember]
        public string EstatusDescripcion { get; set; } 
    }
}
