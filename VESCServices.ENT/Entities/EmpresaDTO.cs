using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VESCServices.ENT.Entities
{
    public class EmpresaDTO
    {
        public int idEmpresa { get; set; }
        public string empresa1 { get; set; }
        public string nombreContacto { get; set; }
        public string apellidoPContacto { get; set; }
        public string apellidoMContacto { get; set; }
        public string puestoContacto { get; set; }
        public string telefonoContacto { get; set; }
        public string telefono2Contacto { get; set; }
        public string correoContacto { get; set; }
        public bool estatus { get; set; }
        public System.DateTime fechaInsert { get; set; }
        public string usuarioInsert { get; set; }
        public Nullable<System.DateTime> fechaUpdate { get; set; }
        public string usuarioUpdate { get; set; }
        public int idLogin { get; set; }
        public string mensaje { get; set; }
    }
}
