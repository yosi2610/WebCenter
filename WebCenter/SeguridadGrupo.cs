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
    public partial class SeguridadGrupo
    {
        public static int InsertarGrupo(CSeguridad objetoSeguridad)
        {
            SqlParameter[] dbParams = new SqlParameter[]
            {
                    DBHelper.MakeParam("@SeguridadGrupoID", SqlDbType.Int, 0, objetoSeguridad.SeguridadGrupoID),
                    DBHelper.MakeParam("@NombreGrupo", SqlDbType.VarChar, 0, objetoSeguridad.NombreGrupo),
                    DBHelper.MakeParam("@DescripcionGrupo", SqlDbType.VarChar, 0, objetoSeguridad.DescripcionGrupo)
            };
            if (objetoSeguridad.SeguridadGrupoID == 0)
            {
                return Convert.ToInt32(DBHelper.ExecuteScalar("[usp_SeguridadGrupo_Insertar]", dbParams));
            }
            else
            {
                return Convert.ToInt32(DBHelper.ExecuteScalar("[usp_SeguridadGrupo_Actualizar]", dbParams));
            }
        }
    }
}