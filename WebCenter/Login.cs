using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebCenter.Classes;

namespace WebCenter
{
    public partial class Login
    {
        public static DataSet  ValidarLogin(string sUserName, string sPassword)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@LoginUsuario", SqlDbType.VarChar, 0, sUserName),
                    DBHelper.MakeParam("@ClaveUsuario", SqlDbType.VarChar, 0, sPassword)
                };
            return DBHelper.ExecuteDataSet("usp_Login_ValidarLogin", dbParams);
        }
    }
}