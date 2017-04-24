using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using WebCenter.Clases;

namespace WebCenter
{
    public partial class Personal : Admin.paginaBase
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            //this.txtCedula.Attributes.Add("onkeypress", "javascript:return SoloNumeros(event); ");
            if (!IsPostBack)
            {
                CargarGerencia();
            }
        }

        private void CargarGerencia()
        {

            this.ddlGerencia.AppendDataBoundItems = true;
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "select * from Gerencia";
            SqlConnection con = new SqlConnection(strConnString);
            SqlCommand cmd = new SqlCommand();

            strQuery = "select * from Gerencia ";
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;

            try
            {
                con.Open();
                ddlGerencia.DataSource = cmd.ExecuteReader();
                ddlGerencia.DataTextField = "NombreGerencia";
                ddlGerencia.DataValueField = "GerenciaID";
                ddlGerencia.DataBind();
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
        protected void ddlGerencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarComboDivision(Convert.ToInt32(this.ddlGerencia.SelectedItem.Value));
        }

        private void CargarComboDivision(int codigoGerencia)
        {
            ddlDivision.Items.Add(new ListItem("--Seleccione División--", ""));
            this.ddlDivision.Items.Clear();
            ddlDivision.AppendDataBoundItems = true;
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "select * from Division " +
            "where GerenciaID=@GerenciaID";
            SqlConnection con = new SqlConnection(strConnString);
            SqlCommand cmd = new SqlCommand(); cmd.Parameters.AddWithValue("@GerenciaID", codigoGerencia);
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;
            try
            {
                con.Open();
                ddlDivision.DataSource = cmd.ExecuteReader();
                ddlDivision.DataTextField = "NombreDivision";
                ddlDivision.DataValueField = "DivisionID";
                ddlDivision.DataBind();
                if (ddlDivision.Items.Count > 1)
                {
                    ddlDivision.Enabled = true;
                }
                else
                {
                    ddlDivision.Enabled = false;

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
        
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                CPersonal personal = new CPersonal();

                personal.PersonalID =  Convert.ToInt32(hdnPersonalID.Value);
                personal.Cedula = Convert.ToInt32(this.txtCedula.Text);
                personal.NombrePersonal = this.txtNombre.Text;
                personal.DivisionID = Convert.ToInt32(ddlDivision.SelectedValue);
                personal.NumeroExtension = this.txtExtension.Text;
                personal.EstatusPersonal = "Activo";

                {

                    if (Personal.InsertarPersonal(personal) > 0)
                    {
                        messageBox.ShowMessage("El personal se ingresó correctamente");
                        this.txtCedula.Text = "";
                        this.txtNombre.Text = "";
                        this.txtExtension.Text = "";
                        this.txtId.Text = "0";
                    }
                }

            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }

        private bool EsPersonalRegistrado()
        {
            DataSet ds = Personal.ObtenerPersonal(Convert.ToInt32(this.txtCedula.Text));
            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

       