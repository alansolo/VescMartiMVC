﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VescENT.Request;
using VescENT.Response;

namespace VescBL.Interfaces
{
    public interface ILoginEmpresaBL
    {
        GetLoginEmpresaResponseDTO GetLoginEmpresa(GetLoginEmpresaRequestDTO loginEmpresaRequest);
    }
}
