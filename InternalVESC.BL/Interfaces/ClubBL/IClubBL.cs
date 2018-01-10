using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VescENT.Request;
using VescENT.Response;

namespace VescBL.Interfaces
{
    public interface IClubBL
    {
        GetClubResponseDTO GetClub(GetClubRequestDTO clubRequest);
        EditClubResponseDTO EditClub(EditClubRequestDTO clubRequest);
        AddClubResponseDTO AddClub(AddClubRequestDTO clubRequest);
    }
}
