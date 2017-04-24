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
    public partial class AsignacionesTecnico
    {

        public static int ActualizarEstatusAsignacionTecnico(CAsignarEstatus objetoEstatus)
        {

            try
            {
                SqlParameter[] dbParams = new SqlParameter[]
                    {
                    DBHelper.MakeParam("@SolicitudServicioDetalleID", SqlDbType.Int, 0, objetoEstatus.SolicitudServicioDetalleID),
                    DBHelper.MakeParam("@ObservacionTecnico", SqlDbType.VarChar, 0, objetoEstatus.ObservacionesTecnico),
                    DBHelper.MakeParam("@MinutosServicioTecnico", SqlDbType.Int, 0, objetoEstatus.MinutosEmpleados),
                    DBHelper.MakeParam("@EstatusSolicitudServicioID", SqlDbType.Int, 0, objetoEstatus.EstatusSolicitudServicioID),
                    DBHelper.MakeParam("@FechaFinalizacionTecnico", SqlDbType.SmallDateTime, 0, objetoEstatus.FechaFinalizacionTecnico)
                    };
                return Convert.ToInt32(DBHelper.ExecuteScalar("[usp_AsignacionesTecnico_ActualizarEstatus]", dbParams));
            }
            catch (Exception)
            {

                throw;
            }
 
        }
        
        public static SqlDataReader ObtenerAsignaciones(int codigoTecnico)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@CodigoTecnico", SqlDbType.Int, 0, codigoTecnico),
                };

            return DBHelper.ExecuteDataReader("[usp_AsignacionesTecnico_ObtenerAsignacionesTecnico]", dbParams);
        }
    }
}