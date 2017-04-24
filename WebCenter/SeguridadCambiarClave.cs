using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebCenter.Clases;
using WebCenter.Classes;

namespace WebCenter
{
    public partial class SeguridadCambiarClave
    {
        public static int CambiarClave(CSeguridad objetoSeguridad)
        {
            SqlParameter[] dbParams = new SqlParameter[]
            {
                    DBHelper.MakeParam("SeguridadUsuarioDatosID", SqlDbType.Int, 0, objetoSeguridad.SeguridadUsuarioDatosID),
                    DBHelper.MakeParam("@ClaveUsuario", SqlDbType.VarChar, 0, objetoSeguridad.ClaveUsuario)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("usp_SeguridadUsuario_ActualizarClave", dbParams));
  
        }
    }
}