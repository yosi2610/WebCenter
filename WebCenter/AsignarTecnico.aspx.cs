using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebCenter.Clases;

namespace WebCenter
{
    public partial class AsignarTecnico : Admin.paginaBase
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    CargarTecnicos();
                    if (Request.QueryString["SolicitudServicioID"] != null)
                    {
                        int SolicitudServicioID = Convert.ToInt32(Request.QueryString["SolicitudServicioID"]);
                        CargarSolicitudes(SolicitudServicioID);
                    }
                }
                catch (Exception ex)
                {

                    messageBox.ShowMessage(ex.Message + ex.StackTrace);
                }
            }
        }


        private void CargarSolicitudes(int SolicitudServicioID)
        {
            try
            {
                CAsignarTecnico asignarTecnico = new CAsignarTecnico();
                asignarTecnico.SolicitudServicioID = SolicitudServicioID;
                DataSet ds = AsignarTecnico.ObtenerAsignacionesTecnico(asignarTecnico);
                this.gridDetalle.DataSource = ds.Tables[0];
                this.gridDetalle.DataBind();
            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }

        }
        private void CargarTecnicos()
        {
            this.ddlTecnico.AppendDataBoundItems = true;
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = AsignarTecnico.ObtenerTecnicos();
            SqlConnection con = new SqlConnection(strConnString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;

            try
            {
                con.Open();
                ddlTecnico.DataSource = cmd.ExecuteReader();
                ddlTecnico.DataTextField = "TecnicoCasos";
                ddlTecnico.DataValueField = "SeguridadUsuarioDatosID";
                ddlTecnico.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AsignacionApoyo.aspx");
        }

        protected void btnAsignar_Click(object sender, EventArgs e)
        {
            if(EsTodoCorrecto() == true)
            {
                AsignarCasoTecnico();
            }
        }
        private void AsignarCasoTecnico()
        {
            try
            {
                int SolicitudServicioID = Convert.ToInt32(Request.QueryString["SolicitudServicioID"]);
                if (TecnicoAsignado(SolicitudServicioID, Convert.ToInt32(ddlTecnico.SelectedValue)) == false)
                {
                    CAsignarTecnico asignarTecnico = new CAsignarTecnico();
                    asignarTecnico.SolicitudServicioID = SolicitudServicioID;
                    asignarTecnico.SeguridadUsuarioDatosID = Convert.ToInt32(ddlTecnico.SelectedValue);
                    asignarTecnico.ObservacionTecnico = "N/D";
                    asignarTecnico.MinutosServicioTecnico = 0;
                    asignarTecnico.EstatusSolicitudServicioID = 2;
                    if (AsignarTecnico.InsertarAsignacionTecnico(asignarTecnico) > 0)
                    {
                        messageBox.ShowMessage("Se asignó el técnico correctamente");
                        CargarSolicitudes(SolicitudServicioID);
                        CargarTecnicos();
                    }
                }
                else
                {
                    messageBox.ShowMessage("No es posible asignar mas de 1 vez al técnico a la misma solicitud");
                }
            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }

        }
        private bool TecnicoAsignado(int SolicitudServicioID, int SeguridadUsuarioDatosID)
        {
            try
            {
                DataSet ds = AsignarTecnico.ObtenerAsignacionTecnico(SolicitudServicioID, SeguridadUsuarioDatosID);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                messageBox.ShowMessage(ex.Message + ex.StackTrace);
                return true;
            }
        }
        private bool EsTodoCorrecto()
        {
            bool esTodoCorrecto = true;
            if(this.ddlTecnico.SelectedValue == "")
            {
                esTodoCorrecto = false;
                messageBox.ShowMessage("Debe seleccionar al técnico");
            }
            return esTodoCorrecto;
        }
        protected void gridDetalle_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                String solicitudServicioDetalleID = e.CommandArgument.ToString();
                if (e.CommandName == "EliminarDetalle")
                {
                    int SolicitudServicioID = Convert.ToInt32(Request.QueryString["SolicitudServicioID"]);
                    CAsignarTecnico asignarTecnico = new CAsignarTecnico();
                    asignarTecnico.SolicitudServicioDetalleID = Convert.ToInt32(solicitudServicioDetalleID);
                    AsignarTecnico.EliminarAsignacionesTecnico(asignarTecnico);
                    CargarSolicitudes(SolicitudServicioID);
                }
            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }
        protected void ddlTecnico_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}