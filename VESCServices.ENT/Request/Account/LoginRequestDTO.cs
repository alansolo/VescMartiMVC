using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using VESCServices.ENT.Common;

namespace VESCServices.ENT.Request.Account
{
    [DataContract]
    public class LoginRequestDTO : RequestBaseDTO
    {
        [DataMember]
        public string usuario { get; set; }
        [DataMember]
        public string contrasena { get; set; }
    }
}
