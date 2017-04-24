using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebCenter.Classes;

namespace WebCenter
{
    public partial class AtencionCallCenter
    {

        public static int InsertarServicio(CAtencionCallCenter atencionCallCenter)
        {
            SqlParameter[] dbParams = new SqlParameter[]
            {
                    DBHelper.MakeParam("@PersonalID", SqlDbType.VarChar, 0, atencionCallCenter.PersonalID),
                    DBHelper.MakeParam("@DescripcionSolicitudServicio", SqlDbType.VarChar, 0, atencionCallCenter.DescripcionSolicitudServicio),
                    DBHelper.MakeParam("@AreaServicioDetalleID", SqlDbType.VarChar, 0, atencionCallCenter.AreaServicioDetalleID),
                    DBHelper.MakeParam("@EstatusSolicitudServicioID", SqlDbType.VarChar, 0, atencionCallCenter.EstatusSolicitudServicioID),
                    DBHelper.MakeParam("@SeguridadUsuarioDatosID", SqlDbType.VarChar, 0, atencionCallCenter.SeguridadUsuarioDatosID)
            };

             return Convert.ToInt32(DBHelper.ExecuteScalar("usp_AtencionCliente_Insertar", dbParams));
        }
        public static DataSet ObtenerServicios(CAtencionCallCenter atencionCallCenter)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@PersonalID", SqlDbType.Int, 0, atencionCallCenter.PersonalID),
                };

            return DBHelper.ExecuteDataSet("usp_AtencionCliente_ObtenerServicios", dbParams);
        }
        public static int EliminarServicio(CAtencionCallCenter atencionCallCenter)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                     DBHelper.MakeParam("@SolicitudServicioID", SqlDbType.Int, 0, atencionCallCenter.SolicitudServicioID),
                };
            return Convert.ToInt32(DBHelper.ExecuteScalar("usp_AtencionCliente_EliminarServicio", dbParams));
        }
    }
}