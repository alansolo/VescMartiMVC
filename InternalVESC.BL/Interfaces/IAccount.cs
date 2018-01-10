using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VescENT.Entities;
using VescENT.Request;
using VescENT.Response;

namespace VescBL.Interfaces
{
    public interface IAccount
    {
        LoginResponseDTO Login(LoginRequestDTO request);
    }
}
