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
    public partial class AsignarTecnico
    {
        public static int InsertarAsignacionTecnico(CAsignarTecnico asignarTecnico)
        {
            SqlParameter[] dbParams = new SqlParameter[]
            {
                    DBHelper.MakeParam("@SolicitudServicioID", SqlDbType.Int, 0, asignarTecnico.SolicitudServicioID),
                    DBHelper.MakeParam("@SeguridadUsuarioDatosID", SqlDbType.Int, 0, asignarTecnico.SeguridadUsuarioDatosID),
                    DBHelper.MakeParam("@ObservacionTecnico", SqlDbType.VarChar, 0, asignarTecnico.ObservacionTecnico),
                    DBHelper.MakeParam("@MinutosServicioTecnico", SqlDbType.Int, 0, asignarTecnico.MinutosServicioTecnico),
                    DBHelper.MakeParam("@EstatusSolicitudServicioID", SqlDbType.Int, 0, asignarTecnico.EstatusSolicitudServicioID)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("usp_AsignarTecnico_Insertar", dbParams));
        }
        public static DataSet ObtenerAsignacionesTecnico(CAsignarTecnico asignarTecnico)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@SolicitudServicioID", SqlDbType.Int, 0, asignarTecnico.SolicitudServicioID),
                };

            return DBHelper.ExecuteDataSet("usp_AsignarTecnico_ObtenerAsignacionesTecnicos", dbParams);
        }
        public static DataSet ObtenerAsignacionTecnico(int SolicitudServicioID, int SeguridadUsuarioDatosID)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@SolicitudServicioID", SqlDbType.Int, 0, SolicitudServicioID),
                    DBHelper.MakeParam("@SeguridadUsuarioDatosID", SqlDbType.Int, 0, SeguridadUsuarioDatosID)
                };

            return DBHelper.ExecuteDataSet("[usp_AsignarTecnico_ObtenerAsignacionTecnico]", dbParams);
        }
        public static DataSet EliminarAsignacionesTecnico(CAsignarTecnico asignarTecnico)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@SolicitudServicioDetalleID", SqlDbType.Int, 0, asignarTecnico.SolicitudServicioDetalleID),
                };

            return DBHelper.ExecuteDataSet("usp_AsignarTecnico_EliminarAsignacion", dbParams);
        }


        public static string ObtenerTecnicos()
        {
            string claseSQL;
            claseSQL = "SELECT SeguridadUsuarioDatosID, NombreCompleto + ' [Casos Asignados:  ' + CONVERT(varchar, SUM(CasosAsignados)) + ']' AS TecnicoCasos, SUM(CasosAsignados) AS CasosTotales " +
                        " FROM dbo.CasosPorTecnico GROUP BY SeguridadUsuarioDatosID, NombreCompleto ORDER BY SUM(CasosAsignados)";
            return claseSQL;
        }
    }
}