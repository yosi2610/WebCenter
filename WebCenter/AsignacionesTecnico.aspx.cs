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
    public partial class AsignacionesTecnico : Admin.paginaBase
    {
        int codigoDeTecnico;
        protected new void Page_Load(object sender, EventArgs e)
        {
            codigoDeTecnico = Convert.ToInt32(this.Session["UserId"].ToString());
            this.txtMinutos.Attributes.Add("onkeypress", "javascript:return SoloNumeros(event); ");
            if (!IsPostBack)
            {
                try
                {
                    this.lblTituloForma.Text = "Asignaciones de: " + this.Session["NombreCompletoUsuario"].ToString();
                    CargarAsignaciones();
                    CargarEstatus();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        private void CargarAsignaciones()
        {
            try
            {
                ddlAsignaciones.DataTextField = "Caso";
                ddlAsignaciones.DataValueField = "SolicitudServicioDetalleID";
                this.ddlAsignaciones.DataSource = AsignacionesTecnico.ObtenerAsignaciones(codigoDeTecnico);
                this.ddlAsignaciones.DataBind();
            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }

        }

        private void CargarEstatus()
        {

            this.ddlEstatus.AppendDataBoundItems = true;
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "SELECT  * FROM dbo.EstatusSolicitudServicio WHERE(EstatusSolicitudServicioID <> 1 AND EstatusSolicitudServicioID <> 2 AND EstatusSolicitudServicioID <> 5) ORDER BY EstatusSolicitudServicioID";
            SqlConnection con = new SqlConnection(strConnString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;

            try
            {
                con.Open();
                ddlEstatus.DataSource = cmd.ExecuteReader();
                ddlEstatus.DataTextField = "NombreEstatusSolicitudServicio";
                ddlEstatus.DataValueField = "EstatusSolicitudServicioID";
                ddlEstatus.DataBind();
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

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ActualizarAsignacionTecnico();
        }
        private void ActualizarAsignacionTecnico()
        {
            if (EsTodoCorrecto() == true)
            {
                try
                {
                    CAsignarEstatus objetoAsignarEstatus = new CAsignarEstatus();

                    objetoAsignarEstatus.SolicitudServicioDetalleID = Convert.ToInt32(this.ddlAsignaciones.SelectedValue);
                    objetoAsignarEstatus.ObservacionesTecnico = this.txtObservaciones.Text.ToUpper();
                    objetoAsignarEstatus.MinutosEmpleados = Convert.ToInt32(this.txtMinutos.Text);
                    objetoAsignarEstatus.EstatusSolicitudServicioID = Convert.ToInt32(this.ddlEstatus.SelectedValue);
                    objetoAsignarEstatus.FechaFinalizacionTecnico = Convert.ToString(DateTime.Now);
                    objetoAsignarEstatus.SeguridadUsuarioDatosID = codigoDeTecnico;

                    if (AsignacionesTecnico.ActualizarEstatusAsignacionTecnico(objetoAsignarEstatus) == 0)
                    {
                        CargarAsignaciones();
                        LimpiarControles();
                        messageBox.ShowMessage("El estatus se asignó correctamente");
                    }
                }
                catch (Exception ex)
                {
                    messageBox.ShowMessage(ex.Message + ex.StackTrace);
                }
            }
            else
            {
                messageBox.ShowMessage("Debe colocar todos los datos");
            }
        }

        private bool EsTodoCorrecto()
        {

            bool resultado = true;

            if (this.txtObservaciones.Text == "")
            {
                resultado = false;
            }
            if (this.txtMinutos.Text == "")
            {
                resultado = false;
            }
            if (this.ddlAsignaciones.SelectedValue == "")
            {
                resultado = false;
            }
            if (this.ddlEstatus.SelectedValue == "")
            {
                resultado = false;
            }
            return resultado;
        }
        private void LimpiarControles()
        {
            this.txtObservaciones.Text = "";
            this.txtMinutos.Text = "";
            ddlEstatus.Text = "";
        }
    }
}