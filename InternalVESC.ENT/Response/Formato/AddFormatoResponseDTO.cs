using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VescENT.Entities;

namespace VescENT.Response
{
    public class AddFormatoResponseDTO
    {
        public List<CatFormato> ListaFormato { get; set; }
        public string Mensaje { get; set; }
    }
}
