using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCenter
{
    public partial class AtencionCallCenter : Admin.paginaBase
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            this.txtCedula.Focus();
            if (!IsPostBack)
            {

                CargarAreaServicio();
            }
        }

        private void CargarAreaServicio()
        {
            this.ddlArea.AppendDataBoundItems = true;
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "select * from AreaServicio";
            SqlConnection con = new SqlConnection(strConnString);
            SqlCommand cmd = new SqlCommand();

            strQuery = "select * from AreaServicio ";
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;

            try
            {
                con.Open();
                ddlArea.DataSource = cmd.ExecuteReader();
                ddlArea.DataTextField = "NombreAreaServicio";
                ddlArea.DataValueField = "AreaServicioID";
                ddlArea.DataBind();
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
        private void CargarComboAreaDetalle(int codigoArea)
        {
            this.ddlAreaDetalle.Items.Add(new ListItem("--Seleccione el area de servicio--", ""));
            this.ddlAreaDetalle.Items.Clear();
            ddlAreaDetalle.AppendDataBoundItems = true;
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "select * from AreaServicioDetalle " +
            "where AreaServicioID=@AreaServicioID";
            SqlConnection con = new SqlConnection(strConnString);
            SqlCommand cmd = new SqlCommand(); cmd.Parameters.AddWithValue("@AreaServicioID", codigoArea);
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;
            try
            {
                con.Open();
                ddlAreaDetalle.DataSource = cmd.ExecuteReader();
                ddlAreaDetalle.DataTextField = "NombreAreaServicioDetalle";
                ddlAreaDetalle.DataValueField = "AreaServicioDetalleID";
                ddlAreaDetalle.DataBind();
                if (ddlAreaDetalle.Items.Count > 1)
                {
                    ddlAreaDetalle.Enabled = true;
                }
                else
                {
                    ddlAreaDetalle.Enabled = false;

                }
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
        protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarComboAreaDetalle(Convert.ToInt32(this.ddlArea.SelectedItem.Value));
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            IngresarServicio(false);
 
        }
        private void IngresarServicio(bool esResuelto)
        {
            if(EsTodoCorrecto() == true)
            {
                try
                {
                    CAtencionCallCenter atencionCallCenter = new CAtencionCallCenter();

                    atencionCallCenter.PersonalID = Convert.ToInt32(hdnPersonalID.Value);
                    atencionCallCenter.DescripcionSolicitudServicio = this.txtDescripcion.Text;
                    atencionCallCenter.AreaServicioDetalleID = Convert.ToInt32(this.ddlAreaDetalle.SelectedValue);
                    atencionCallCenter.SeguridadUsuarioDatosID = Convert.ToInt32(this.Session["UserId"].ToString());
                    if (esResuelto == true)
                    {
                        atencionCallCenter.EstatusSolicitudServicioID = 5;
                        atencionCallCenter.FechaFinalizacionSolicitudServicio = Convert.ToString(DateTime.Now);
                    }
                    else
                    {
                        atencionCallCenter.EstatusSolicitudServicioID = 1;
                    }

                    if (AtencionCallCenter.InsertarServicio(atencionCallCenter) > 0)
                    {
                        messageBox.ShowMessage("El servicio se ingresó correctamente");
                        LimpiarControles();

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
            if(hdnPersonalID.Value == "")
            {
                resultado = false;
            }

            if(this.txtCedula.Text == "")
            {
                resultado = false;
            }
            if (this.txtDescripcion.Text == "")
            {
                resultado = false;
            }
            if (this.ddlArea.SelectedValue =="")
            {
                resultado = false;
            }
            if (this.ddlAreaDetalle.SelectedValue == "")
            {
                resultado = false;
            }
            return resultado;
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            CargarDetalleServicios(Convert.ToInt32(this.hdnPersonalID.Value));
        } 
        public void CargarDetalleServicios(int PersonalID)
        {
            try
            {
                CAtencionCallCenter atencionCallCenter = new CAtencionCallCenter();
                atencionCallCenter.PersonalID = PersonalID;

                DataSet ds = AtencionCallCenter.ObtenerServicios(atencionCallCenter);
                DataTable dt = ds.Tables[0];
                int x = ds.Tables[0].Rows.Count;
                gridDetalle.DataSource = dt;
                gridDetalle.DataBind();
                this.imgPersonal.ImageUrl = "http://172.16.7.240/fotos/" + this.hdnCedula.Value + ".jpg";
            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }

        }
        private void LimpiarControles()
        {
            this.txtCedula.Text = "";
            this.txtDescripcion.Text = "";
            this.hdnPersonalID.Value = "0";
            gridDetalle.DataSource = null;
            gridDetalle.DataBind();
            this.imgPersonal.ImageUrl = "Images/crm.gif";

        }
        protected void gridDetalle_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "EliminarDetalle")
                {
                    CAtencionCallCenter atencionCallCenter = new CAtencionCallCenter();
                    atencionCallCenter.SolicitudServicioID = Convert.ToInt32(e.CommandArgument.ToString());

                    if (AtencionCallCenter.EliminarServicio(atencionCallCenter) > 0)
                    {
                        CargarDetalleServicios(Convert.ToInt32(this.hdnPersonalID.Value));
                    }
                    else
                    {
                        messageBox.ShowMessage("No se pudo eliminar el detalle. Intente nuevamente.");
                    }
                }
            }
            catch (Exception ex)
            {
                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }

        }

        protected void btnResuelto_Click(object sender, EventArgs e)
        {
            IngresarServicio(true);
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
        }
    }
}