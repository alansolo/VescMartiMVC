using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VESCServices.ENT.Enums
{
    /// <summary>
    /// Enum de errores controlados dentro del sistema, con codigo. En caso de ocurrir un error se guarda estos codigos en el log! Por eso es importante que cada elemento solo 
    /// se utilice en un solo lugar!
    /// </summary>
    public enum ErrorCodeEnum
    {
        #region BL
        #region AccountBL
        UsuarioContrasenaVacia = 1,
        UsarioContrasenaNoValida,
        SesionActiva,
        DesconocidoLogin,
        DesconocidoLogout,
#endregion 
        #region SeguridadBL
        requestNull,
        IpVacia,
        DesconocidoSeguridad,
        SesionNoValida,
        ConstructorVacio,
        #endregion
        #region EmpleadoBL
        CampoObligatorio,
        #endregion
        #endregion
        #region Padron
        DesconocidoObtenerPadron,
        #endregion
        #region DAL
        #endregion
    }
}
