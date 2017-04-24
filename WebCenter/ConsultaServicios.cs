using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebCenter.Classes;

namespace WebCenter
{
    public partial class ConsultaServicios
    {
        public static DataSet ObtenerServicios(string fechaDesde, string fechaHasta, string estatusSolicitud)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@FechaDesde", SqlDbType.VarChar, 0, fechaDesde),
                    DBHelper.MakeParam("@FechaHasta", SqlDbType.VarChar, 0, fechaHasta),
                    DBHelper.MakeParam("@DescripcionEstatus", SqlDbType.VarChar, 0, estatusSolicitud),
                };

            return DBHelper.ExecuteDataSet("usp_ConsultaServicio_ObtenerServicios", dbParams);
        }
        public static DataSet ObtenerEstatusTodos()
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {

                };

            return DBHelper.ExecuteDataSet("usp_ConsultaServicios_ObtenerEstatusTodos", dbParams);
        }
    }
}