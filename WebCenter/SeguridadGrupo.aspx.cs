using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebCenter.Clases;

namespace WebCenter
{
    public partial class SeguridadGrupo : Admin.paginaBase
    {
        protected new void Page_Load(object sender, EventArgs e)
        {

        }
        private void ActualizarRegistros()
        {
                try
                {
                    CSeguridad objetoSeguridad = new CSeguridad();
                    objetoSeguridad.SeguridadGrupoID = Convert.ToInt32(hdnSeguridadGrupoID.Value);
                    objetoSeguridad.NombreGrupo = this.txtNombre.Text.ToUpper();
                    objetoSeguridad.DescripcionGrupo = this.txtDescripcion.Text.ToUpper();
                    if (SeguridadGrupo.InsertarGrupo(objetoSeguridad) > 0)
                    {
                        messageBox.ShowMessage("El grupo se ingresó correctamente");
                        LimpiarPantalla();
                    }
                }
                catch (Exception)
                {

                    throw;
                }
        }

        private void LimpiarPantalla()
        {
            this.txtNombre.Text = "";
            this.txtDescripcion.Text = "";
            this.hdnSeguridadGrupoID.Value = "0";
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ActualizarRegistros();
        }
    }
}