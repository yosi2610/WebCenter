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
    public partial class SeguridadUsuario
    {
        public static int InsertarUsuario(CSeguridad objetoSeguridad)
        {
            SqlParameter[] dbParams = new SqlParameter[]
            {
                    DBHelper.MakeParam("SeguridadUsuarioDatosID", SqlDbType.Int, 0, objetoSeguridad.SeguridadUsuarioDatosID),
                    DBHelper.MakeParam("@LoginUsuario", SqlDbType.VarChar, 0, objetoSeguridad.LoginUsuario),
                    DBHelper.MakeParam("@ClaveUsuario", SqlDbType.VarChar, 0, objetoSeguridad.ClaveUsuario),
                    DBHelper.MakeParam("@NombreCompleto", SqlDbType.VarChar, 0, objetoSeguridad.NombreCompleto),
                    DBHelper.MakeParam("@DescripcionUsuario", SqlDbType.VarChar, 0, objetoSeguridad.DescripcionUsuario),
                    DBHelper.MakeParam("@SeguridadGrupoID", SqlDbType.Int, 0, objetoSeguridad.SeguridadGrupoID),
                    DBHelper.MakeParam("@UsuarioTecnico", SqlDbType.Bit, 0, objetoSeguridad.UsuarioTecnico),
                    DBHelper.MakeParam("@EstatusUsuario", SqlDbType.VarChar, 0,objetoSeguridad.EstatusUsuario)
            };
            if (objetoSeguridad.SeguridadUsuarioDatosID == 0)
            {
                return Convert.ToInt32(DBHelper.ExecuteScalar("[usp_SeguridadUsuario_Insertar]", dbParams));
            }
            else
            {
                return Convert.ToInt32(DBHelper.ExecuteScalar("[usp_SeguridadUsuario_Actualizar]", dbParams));
            }
        }
        public static DataSet ObtenerLogin(string loginDeUsuario)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@LoginUsuario", SqlDbType.VarChar, 0, loginDeUsuario),
                };

            return DBHelper.ExecuteDataSet("usp_SeguridadUsuario_ObtenerLogin", dbParams);
        }
    }
}