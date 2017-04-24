using Admin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Teach
{
    public partial class UCNavigation : System.Web.UI.UserControl
    {
        private void Page_Load(object sender, EventArgs e)
        {

            bool Logged = paginaBase.LoggedIn(Session);

            if (this.lnkChangePassword.Enabled)
            {
                this.lnkChangePassword.CssClass = "izq";
            }
            else
            {
                this.lnkChangePassword.CssClass = "izqDesactivado";
            }


            Page.ClientScript.RegisterStartupScript(Page.GetType(), "tttt", "ocultarEnlaces(" + Logged.ToString().ToLower() + ");", true);
            this.divLogin.Visible = !Logged;
            if (Logged)
            {
                int codigoDeTecnico = Convert.ToInt32(this.Session["UserId"].ToString());
                WebCenter.Clases.CSeguridad objetoSeguridad = new WebCenter.Clases.CSeguridad();
                objetoSeguridad.SeguridadUsuarioDatosID = codigoDeTecnico;
                this.lnkHome.CssClass = "izq";

                if (objetoSeguridad.EsUsuarioAdministrador() == true)
                {
                    this.lblVentas.CssClass = "izq";
                    this.lnkAtencionCallCenter.CssClass = "izq";
                    this.lnkHelpDesk.CssClass = "izq";
                    this.lblTecnicos.CssClass = "izq";
                    this.lnkAsignacionesTecnico.CssClass = "izq";
                    this.lblConsultas.CssClass = "izq";
                    this.lnkAddProducto.CssClass = "izq";
                    this.lblProveedores.CssClass = "izqDos";
                    this.lnkAddPersonal.CssClass = "izqDos";
                    this.lnkSeguridad.CssClass = "izq";
                    this.lnkConsultaMovimientos.CssClass = "izq";
                }
                else
                {
                     this.lnkSeguridad.Visible = false;
                    //MENU HELP DESK
                    lblVentas.Visible = false;
                    if (objetoSeguridad.EsAccesoPermitido(1) == true)
                    {
                        lblVentas.Visible = true;
                        this.lblVentas.CssClass = "izq";
                        this.lnkAtencionCallCenter.CssClass = "izq";
                    }
                    else
                    {
                        this.lnkAtencionCallCenter.Visible = false;
                    }

                    if (objetoSeguridad.EsAccesoPermitido(2) == true)
                    {
                        this.lblVentas.Visible = true;
                        this.lblVentas.CssClass = "izq";
                        this.lnkHelpDesk.CssClass = "izq";
                    }
                    else
                    {
                        this.lnkHelpDesk.Visible = false;
                    }

                    //MENU TECNICOS
                    lblTecnicos.Visible = false;
                    if (objetoSeguridad.EsAccesoPermitido(3) == true)
                    {
                        lblTecnicos.Visible = true;
                        this.lblTecnicos.CssClass = "izq";
                        this.lnkAsignacionesTecnico.CssClass = "izq";
                    }
                    else
                    {
                        this.lnkAsignacionesTecnico.Visible = false;
                    }

                    //MENU CONSULTAS
                    this.lblConsultas.Visible = false;
                    if (objetoSeguridad.EsAccesoPermitido(4) == true)
                    {
                        this.lblConsultas.Visible = true;
                        this.lblConsultas.CssClass = "izq";
                        this.lnkAddProducto.CssClass = "izq";
                        this.lnkConsultaMovimientos.CssClass = "izq";
                    }
                    else
                    {
                        this.lnkAddProducto.Visible = false;
                    }

                    if (objetoSeguridad.EsAccesoPermitido(9) == true)
                    {
                        this.lblConsultas.Visible = true;
                        this.lblConsultas.CssClass = "izq";
                        this.lnkConsultaMovimientos.CssClass = "izq";
                    }
                    else

                    {
                          this.lnkConsultaMovimientos.Visible = false;
                    }
                    //*****************************************************

                    //MENU OPCIONES ESPECIALES
                    lblProveedores.Visible = false;
                    if (objetoSeguridad.EsAccesoPermitido(5) == true)
                    {
                        lblProveedores.Visible = true;
                        this.lblProveedores.CssClass = "izqDos";
                        this.lnkAddPersonal.CssClass = "izqDos";
                    }
                    else
                    {
                        this.lnkAddPersonal.Visible = false;
                    }
                }

            }
        }



        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }
        private void InitializeComponent()
        {
            base.Load += new EventHandler(this.Page_Load);
        }
    }
}