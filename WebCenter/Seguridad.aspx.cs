using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCenter
{
    public partial class Seguridad : Admin.paginaBase
    {
        protected new void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("SeguridadUsuario.aspx");
        }

        protected void btnAgregarGrupo_Click(object sender, EventArgs e)
        {
            Response.Redirect("SeguridadGrupo.aspx");
        }

        protected void btnAgregarObjeto_Click(object sender, EventArgs e)
        {
            Response.Redirect("SeguridadObjeto.aspx");
        }

        protected void btmAgregarGrupoObjeto_Click(object sender, EventArgs e)
        {
            Response.Redirect("SeguridadObjetoGrupo.aspx");
        }
    }
}