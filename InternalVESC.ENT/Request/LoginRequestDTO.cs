using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using VescENT.Common;
using VescENT.Entities;

namespace VescENT.Request
{
    [DataContract]
    public class LoginRequestDTO : RequestBaseDTO
    {
        [DataMember]
        public UserDTO User { get; set; }
    }
}
