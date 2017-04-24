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
    public partial class SeguridadUsuario : Admin.paginaBase
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGrupos();
            }
        }

        private void CargarGrupos()
        {
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "select * from SeguridadGrupo";
            SqlConnection con = new SqlConnection(strConnString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;

            try
            {
                con.Open();
                ddlGrupo.DataSource = cmd.ExecuteReader();
                ddlGrupo.DataTextField = "NombreGrupo";
                ddlGrupo.DataValueField = "SeguridadGrupoID";
                ddlGrupo.DataBind();
                ddlGrupo.Items.Insert(0, new ListItem("--Seleccione el Grupo--", "0"));
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
        private void ActualizarRegistros()
        {
            if (EsTodoCorrecto()== true)
            {

                try
                {
                    CSeguridad objetoSeguridad = new CSeguridad();
                    objetoSeguridad.SeguridadUsuarioDatosID = Convert.ToInt32(hdnSeguridadUsuarioDatosID.Value);
                    objetoSeguridad.NombreCompleto = this.txtNombre.Text.ToUpper();
                    objetoSeguridad.LoginUsuario = this.txtLogin.Text;
                    objetoSeguridad.ClaveUsuario = this.txtClave.Text;
                    objetoSeguridad.DescripcionUsuario = this.txtDescripion.Text.ToUpper();
                    objetoSeguridad.SeguridadGrupoID = Convert.ToInt32(ddlGrupo.SelectedValue);
                    objetoSeguridad.UsuarioTecnico = Convert.ToInt32(this.chkTecnico.Checked);
                    objetoSeguridad.EstatusUsuario = this.chkEstatus.Checked ? "Activo" : "Inactivo";
                    if (SeguridadUsuario.InsertarUsuario(objetoSeguridad) > 0)
                    {
                        messageBox.ShowMessage("El usuario se ingresó correctamente");
                        LimpiarPantalla();
                    }
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        private void LimpiarPantalla()
        {
            this.txtNombre.Text = "";
            this.txtLogin.Text = "";
            this.txtDescripion.Text = "";
            this.txtClave.Text = "";
            this.hdnEstatus.Value = "";
            this.hdnSeguridadUsuarioDatosID.Value = "0";
            this.hdnTecnico.Value = "";
            this.chkTecnico.Checked = false;
            this.chkEstatus.Checked = true;
            CargarGrupos();
        }

        private bool EsTodoCorrecto()
        {
            bool esCorrecto = true;
            if (Convert.ToInt32(ddlGrupo.SelectedValue) < 1)
            {
                esCorrecto = false;
                messageBox.ShowMessage("Debe seleccionar el grupo");
            }
            if (Convert.ToInt32(hdnSeguridadUsuarioDatosID.Value) < 1)
            {
                if (EsLoginRegistrado() == true)
                {
                    esCorrecto = false;
                    messageBox.ShowMessage("El nombre de usuario o login que está colocando ya lo tiene otro usuario");
                }
            }

            return esCorrecto;
        }
        private bool EsLoginRegistrado()
        {
            DataSet ds = SeguridadUsuario.ObtenerLogin(this.txtLogin.Text);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //this.ddlGrupo.SelectedValue = "10";
            ActualizarRegistros();
        }

    }
}