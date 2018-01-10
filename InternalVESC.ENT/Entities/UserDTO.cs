using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace VescENT.Entities
{
    [DataContract]
    public class UserDTO
    {
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Name { get; set; }

    }
}
