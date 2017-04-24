using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebCenter.Classes;

namespace WebCenter
{
    public partial class AsignacionApoyo
    {
        public static DataSet ObtenerServicios()
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {

                };

            return DBHelper.ExecuteDataSet("usp_AsignacionApoyo_ObtenerServicios", dbParams);
        }
    }
}