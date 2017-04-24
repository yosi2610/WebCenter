using Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Teach
{
    public partial class UCMessageBox : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

                scripts.Text = @"<link href='http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css' rel='stylesheet' type='text/css'/>
             <script src='http://ajax.googleapis.com/ajax/libs/jquery/1.4/jquery.min.js' type='text/javascript'></script>
              <script src='http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js' type='text/javascript'></script>
             <script src='js/simpleAutoComplete.js' type='text/javascript'></script>

";
                //                scripts.Visible = false;    
            }

        }

        public void SetEnableRegisters(bool enabled)
        {
            scripts.Visible = true;
        }

        public void ShowMessage(string mesagge)
        {
            miLiteral.Text = mesagge;
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "Mario Gros", "showMessage('" + this.ClientID + "',0);", true);
            return;
        }
        /// <summary>
        ///  ShowMessage
        /// </summary>
        /// <param name="mesagge">Mensaje a mostrar por pantalla</param>
        /// <param name="type">Tipo de mensaje Error,Exclamation, Information</param>
        public void ShowMessage(string mesagge, paginaBase.MessageType type)
        {
            miLiteral.Text = mesagge;
            switch (type)
            {
                case paginaBase.MessageType.Error:
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "Gros", "showMessage('" + this.ClientID + "',0);", true);

                    break;
                case paginaBase.MessageType.Exclamation:
                    break;
                case paginaBase.MessageType.Information:
                    break;
                case paginaBase.MessageType.Confirm:
                    break;

            }
            return;
        }
        /// <summary>
        ///  ShowMessage
        /// </summary>
        /// <param name="mesagge">Mensaje a mostrar por pantalla</param>
        /// <param name="type">Tipo de mensaje Error,Exclamation, Information</param>
        /// <param name="type">Solo True para paginas que no sean EDITPERMIT,EDITVEHICLES,EDITCUSTOMER</param>

        public void ShowMessage(string mesagge, paginaBase.MessageType type, bool enabledRegisters)
        {
            scripts.Text = @"<link href='http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css' rel='stylesheet' type='text/css'/>
 <script src='http://ajax.googleapis.com/ajax/libs/jquery/1.4/jquery.min.js' type='text/javascript'></script>
  <script src='http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js' type='text/javascript'></script>";

            this.scripts.Visible = enabledRegisters;
            ShowMessage(mesagge, type);
        }

        private string formatearMensaje(string msge)
        {
            return msge.Replace("'", "").Replace("/", "").Replace("<html>", "").Replace("<head>", "").Replace("body", "").Replace("--", "").Replace("\\", "");
        }
        protected void botoncito_Click(object sender, EventArgs e)
        {

        }
    }
}