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
    public partial class AsignarEstatus
    {
        public static DataSet ObtenerTiposEstatus ()
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
    
                };

            return DBHelper.ExecuteDataSet("[usp_AsignarEstatus_ObtenerEstatus]", dbParams);
        }
        public static int ActualizarEstatus(CAsignarEstatus objetoEstatus)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@SolicitudServicioID", SqlDbType.Int, 0, objetoEstatus.SolicitudServicioID),
                    DBHelper.MakeParam("@SeguridadUsuarioDatosID", SqlDbType.Int, 0, objetoEstatus.SeguridadUsuarioDatosID),
                    DBHelper.MakeParam("@EstatusSolicitudServicioID", SqlDbType.Int, 0, objetoEstatus.EstatusSolicitudServicioID)
                };

            return Convert.ToInt32(DBHelper.ExecuteScalar("[usp_AsignarEstatus_ActualizarEstatus]", dbParams));
        }
    }
}