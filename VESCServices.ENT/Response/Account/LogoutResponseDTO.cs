using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VESCServices.ENT.Common;

namespace VESCServices.ENT.Response.Account
{
    public class LogoutResponseDTO
    {
        public bool Success { get; set; }

        public List<ErrorDTO> ErrorList { get; set; }
    }
}
