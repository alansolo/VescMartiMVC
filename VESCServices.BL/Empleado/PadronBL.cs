using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VESCServices.BL.Resource;
using VESCServices.DAL.Empleado;
using VESCServices.ENT.Common;
using VESCServices.ENT.Entities;
using VESCServices.ENT.Enums;
using VESCServices.ENT.Request.Padron;
using VESCServices.ENT.Response.Padron;
using VESCServices.Framework;

namespace VESCServices.BL.Empleado
{
    public class PadronBL : SeguridadAutenticado
    {
        /// <summary>
        /// Consulta del padron
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public ConsultaPadronResponseDTO ObtenerPadron(ConsultaPadronRequestDTO request)
        {
            ConsultaPadronResponseDTO response = new ConsultaPadronResponseDTO();
            try
            {
                response.PadronLista = (new PadronDAL()).ObtenerPadron(request.EmpresaId);
                response.Success = true;
            }

            catch(Exception ex)
            {
                response.Success = false;
                response.ErrorList = new List<ErrorDTO> { new ErrorDTO { Code = ErrorCodeEnum.DesconocidoObtenerPadron.ToString(), Descripction = VescMessages.ErrorDesconocido + ErrorCodeEnum.DesconocidoObtenerPadron.ToString() } };
                Log.WriteException(ErrorCodeEnum.DesconocidoLogin.ToString(), base.idUsuario.ToString(), ex);
            }
            return response;
        }
    }
}
