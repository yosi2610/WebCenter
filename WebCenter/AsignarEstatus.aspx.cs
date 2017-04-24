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
    public partial class AsignarEstatus : Admin.paginaBase
    {
        private static DataTable dtEstatus = null;
        protected new void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                try
                {
                    dtEstatus = AsignarEstatus.ObtenerTiposEstatus().Tables[0];
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



        protected void gridDetalle_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // ESTO FUNCIONA PERO NO ES POSIBLE ASIGNAR EL VALOR A COMBO QUE VIENE POR DEFECTO EN LA BASE DE DATOS:
                //((DropDownList)e.Row.FindControl("ddlEstatus")).DataValueField = "EstatusSolicitudServicioID";
                //((DropDownList)e.Row.FindControl("ddlEstatus")).DataTextField = "NombreEstatusSolicitudServicio";
                //((DropDownList)e.Row.FindControl("ddlEstatus")).DataSource = dtEstatus;
                //((DropDownList)e.Row.FindControl("ddlEstatus")).DataBind();
                //***************************************************************************************************

                //SE CAMBIO POR ESTE CODIGO EN EL HTML:

                //< ItemTemplate >
                //    < asp:DropDownList runat = "server" ID = "ddlEstatus"
                //          DataSourceID = "SqlDataSource4"
                //          DataTextField = "NombreEstatusSolicitudServicio"
                //          DataValueField = "EstatusSolicitudServicioID"
                //          SelectedValue = '<%# Bind("EstatusSolicitudServicioID") %>'
                //          Width = "180px" >
                //    </ asp:DropDownList >
                //   < asp:SqlDataSource
                //        ID = "SqlDataSource4"
                //      runat = "server" ConnectionString = "<%$ ConnectionStrings:CallCenterConnectionString %>"
                //      SelectCommand = "SELECT *  FROM [EstatusSolicitudServicio]" ></ asp:SqlDataSource >
                //    </ ItemTemplate >
                //***************************************************************************************************
            }
        }
        private string ValidarDatos(ref List<CAsignarEstatus> objetoAsignarEstatus)
        {
            string sResultado = "";
            CAsignarEstatus objetoAsignaEstatus = null;
            int j = 1;

            
            foreach (GridViewRow dr in this.gridDetalle.Rows)
            {
                objetoAsignaEstatus = new CAsignarEstatus();
                objetoAsignaEstatus.EstatusSolicitudServicioID = Utils.utils.ToInt(((DropDownList)dr.FindControl("ddlEstatus")).SelectedValue);
                objetoAsignaEstatus.SeguridadUsuarioDatosID = Utils.utils.ToInt(((TextBox)dr.FindControl("txtCodTecnico")).Text);

                if (objetoAsignaEstatus.EstatusSolicitudServicioID == 0)
                    sResultado = "Estatus <br>";

                objetoAsignarEstatus.Add(objetoAsignaEstatus);

                if (sResultado != "")
                {
                    sResultado = "En la Fila " + j.ToString() + " faltan ingresar los siguientes datos:<br><br>" + sResultado;
                    break;
                }
                j++;
            }

            return sResultado;
        }
        protected void btnAsignar_Click(object sender, EventArgs e)
        {
            try
            {
                int contadorRegistros = 0;
                List<CAsignarEstatus> objetoLista = new List<CAsignarEstatus>();
                string sResultado = ValidarDatos(ref objetoLista);
                int SolicitudServicioID = Convert.ToInt32(Request.QueryString["SolicitudServicioID"]);
                foreach (CAsignarEstatus prod in objetoLista)
                {
                    contadorRegistros = contadorRegistros + 1;
                    prod.SolicitudServicioID = SolicitudServicioID;
                    AsignarEstatus.ActualizarEstatus(prod);
                    CargarSolicitudes(SolicitudServicioID);


                }
                if (contadorRegistros > 0)
                {
                    messageBox.ShowMessage("Registro actualizado");
                }
                else
                {
                    messageBox.ShowMessage("No existen registros por actualizar");
                }
                 

            }
            catch(Exception ex)
            {
                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }

        protected void ddlEstatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("AsignacionApoyo.aspx");
        }
    }
}