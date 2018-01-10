using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VescENT.Response;
using VescENT.Request;
using VescENT.Entities;
using VescDAL;
using System.Data;
using VescBL.Interfaces;

namespace VescBL
{
    public class RazonSocialBL: IRazonSocialBL
    {
        public GetRazonSocialResponseDTO GetRazonSocial(GetRazonSocialRequestDTO razonSocialRequest)
        {
            GetRazonSocialResponseDTO razonSocialResponse = new GetRazonSocialResponseDTO();
            List<RazonSocial> listaRazonSocial = new List<RazonSocial>();

            RazonSocialDal razonSocialDal = new RazonSocialDal();
            DataTable dtDatos = new DataTable();

            try
            {
                dtDatos = razonSocialDal.GetRazonSocial(razonSocialRequest.IdRazonSocial, razonSocialRequest.RazonSocial);

                listaRazonSocial = dtDatos.AsEnumerable()
                               .Select(row => new RazonSocial
                               {
                                   idEmpresa = row.Field<int?>("idEmpresa").GetValueOrDefault(),
                                   idRazonSocial = row.Field<int?>("idRazonSocial").GetValueOrDefault(),
                                   razonSocial = string.IsNullOrEmpty(row.Field<string>("razonSocial")) ? "" : row.Field<string>("razonSocial"),
                                   rfc = string.IsNullOrEmpty(row.Field<string>("rfc")) ? "" : row.Field<string>("rfc"),
                                   calle = string.IsNullOrEmpty(row.Field<string>("calle")) ? "" : row.Field<string>("calle"),
                                   numeroExt = string.IsNullOrEmpty(row.Field<string>("numeroExt")) ? "" : row.Field<string>("numeroExt"),
                                   numeroInt = string.IsNullOrEmpty(row.Field<string>("numeroInt")) ? "" : row.Field<string>("numeroInt"),
                                   colonia = string.IsNullOrEmpty(row.Field<string>("colonia")) ? "" : row.Field<string>("colonia"),
                                   municipioDelegacion = string.IsNullOrEmpty(row.Field<string>("municipioDelegacion")) ? "" : row.Field<string>("municipioDelegacion"),
                                   estado = string.IsNullOrEmpty(row.Field<string>("estado")) ? "" : row.Field<string>("estado"),
                                   cp = string.IsNullOrEmpty(row.Field<string>("cp")) ? "" : row.Field<string>("cp"),
                                   vigenciaInicio = row.Field<DateTime?>("vigenciaInicio").GetValueOrDefault(),
                                   stringVigenciaInicio = row.Field<DateTime?>("vigenciaInicio").GetValueOrDefault().ToString("dd/MM/yyyy"),
                                   vigenciaFinal = row.Field<DateTime?>("vigenciaFinal").GetValueOrDefault(),
                                   stringVigenciaFinal = row.Field<DateTime?>("vigenciaFinal").GetValueOrDefault().ToString("dd/MM/yyyy"),
                                   estatus = row.Field<bool?>("estatus").GetValueOrDefault(),
                                   usuarioInsert = string.IsNullOrEmpty(row.Field<string>("usuarioInsert")) ? "" : row.Field<string>("usuarioInsert"),
                                   fechaInsert = row.Field<DateTime?>("fechaInsert").GetValueOrDefault(),
                                   usuarioUpdate = string.IsNullOrEmpty(row.Field<string>("usuarioUpdate")) ? "" : row.Field<string>("usuarioUpdate"),
                                   fechaUpdate = row.Field<DateTime?>("fechaUpdate").GetValueOrDefault(),
                               }).ToList();

                razonSocialResponse.ListaRazonSocial = listaRazonSocial;
                razonSocialResponse.Mensaje = "OK";
            }
            catch (Exception ex)
            {
                razonSocialResponse.ListaRazonSocial = new List<RazonSocial>();
                razonSocialResponse.Mensaje = "ERROR: " + ex.Message;
            }

            return razonSocialResponse;
        }
    }
}
