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
    public partial class Personal
    {
        public static int InsertarPersonal(CPersonal personal)
        {
            SqlParameter[] dbParams = new SqlParameter[]
            {
                    DBHelper.MakeParam("@Id", SqlDbType.VarChar, 0, personal.PersonalID),
                    DBHelper.MakeParam("@Cedula", SqlDbType.VarChar, 0, personal.Cedula),
                    DBHelper.MakeParam("@NombrePersonal", SqlDbType.VarChar, 0, personal.NombrePersonal),
                    DBHelper.MakeParam("@DivisionID", SqlDbType.VarChar, 0, personal.DivisionID),
                    DBHelper.MakeParam("@NumeroExtension", SqlDbType.VarChar, 0, personal.NumeroExtension),
                    DBHelper.MakeParam("@EstatusPersonal", SqlDbType.VarChar, 0, personal.EstatusPersonal)
            };

            if(personal.PersonalID == 0) 
            {
                return Convert.ToInt32(DBHelper.ExecuteScalar("usp_Personal_Insertar", dbParams));
            }
            else
            {
                return Convert.ToInt32(DBHelper.ExecuteScalar("usp_Personal_Actualizar", dbParams));
            }
         }
        public static DataSet ObtenerPersonal(CPersonal personal)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@Cedula", SqlDbType.Int, 0, personal.Cedula),
                };

            return DBHelper.ExecuteDataSet("usp_Personal_ObtenerPersonal", dbParams);
        }
        public static DataSet ObtenerPersonal(int cedulaPersonal)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@Cedula", SqlDbType.Int, 0, cedulaPersonal),
                };

            return DBHelper.ExecuteDataSet("usp_Personal_ObtenerPersonal", dbParams);
        }
    }


}