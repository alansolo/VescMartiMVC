﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VescENT.Entities;

namespace VescENT.Response
{
    public class EditNivelResponseDTO
    {
        public List<CatNivel> ListaNivel { get; set; }
        public string Mensaje { get; set; }
    }
}
