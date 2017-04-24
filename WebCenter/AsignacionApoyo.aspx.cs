using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCenter
{
    public partial class AsignacionApoyo : Admin.paginaBase
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    CargarServicios();
                }
                catch (Exception ex)
                {

                    messageBox.ShowMessage(ex.Message + ex.StackTrace);
                }
            }
        }
        private void CargarServicios()
        {
            try
            {
                DataSet ds = AsignacionApoyo.ObtenerServicios();
                this.gridDetalle.DataSource = ds.Tables[0];
                this.gridDetalle.DataBind();
            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }

        }
        private void EliminarServicio(int solicitudServicioID)
        {
            try
            {
                CAtencionCallCenter objetoAtencionCallCenter = new CAtencionCallCenter();
                objetoAtencionCallCenter.SolicitudServicioID = solicitudServicioID;
                AtencionCallCenter.EliminarServicio(objetoAtencionCallCenter);
                CargarServicios();
            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }

        }
        protected void gridDetalle_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                String solicitudServicioID = e.CommandArgument.ToString();
                if (e.CommandName == "AsignarTecnico")
                {
                    Response.Redirect("AsignarTecnico.aspx?SolicitudServicioID=" + solicitudServicioID);
                }
                else if (e.CommandName == "AsignarEstatus")
                {
                    Response.Redirect("AsignarEstatus.aspx?SolicitudServicioID=" + solicitudServicioID);
                }
                else if (e.CommandName == "EliminarSolicitud")
                {
                    EliminarServicio(Convert.ToInt32(solicitudServicioID));
                }
            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }

        }
    }
}