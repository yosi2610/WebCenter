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
    public partial class SeguridadObjeto
    {

        public static int InsertarObjeto(CSeguridad objetoSeguridad)
        {
            SqlParameter[] dbParams = new SqlParameter[]
            {
                    DBHelper.MakeParam("@SeguridadObjetoID", SqlDbType.Int, 0, objetoSeguridad.SeguridadObjetoID),
                    DBHelper.MakeParam("@NombreObjeto", SqlDbType.VarChar, 0, objetoSeguridad.NombreObjeto)
            };
            if (objetoSeguridad.SeguridadObjetoID == 0)
            {
                return Convert.ToInt32(DBHelper.ExecuteScalar("[usp_SeguridadObjeto_Insertar]", dbParams));
            }
            else
            {
                return Convert.ToInt32(DBHelper.ExecuteScalar("usp_SeguridadObjeto_Actualizar", dbParams));
            }
        }

    }
}