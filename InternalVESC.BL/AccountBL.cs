using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VescBL.Interfaces;
using VescENT.Entities;
using VescENT.Request;
using VescENT.Response;
using VescDAL;
using System.Data.SqlClient;
using System.Data;

namespace VescBL
{
    public class AccountBL : IAccount
    {
        public LoginResponseDTO Login(LoginRequestDTO request)
        {
            return new LoginResponseDTO();
        }

    }
}
