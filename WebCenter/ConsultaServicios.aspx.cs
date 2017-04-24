using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebCenter
{
    public partial class ConsultaServicios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.txtFechaDesde.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                this.txtFechaHasta.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                CargarEstatus();
                CargarServicios(this.txtFechaDesde.Text, this.txtFechaHasta.Text, Convert.ToString(this.ddlEstatus.SelectedItem));
 
            }
        }
        private void CargarServicios(string fechaDesdeServicio, string fechaHastaServicio, string codigoDeEstatus)
        {
            try
            {
                DataSet ds = ConsultaServicios.ObtenerServicios(fechaDesdeServicio, fechaHastaServicio, codigoDeEstatus);
                this.gridDetalle.DataSource = ds.Tables[0];
                this.gridDetalle.DataBind();
            }
            catch (Exception ex)
            {
                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }
        private void CargarEstatus()
        {
            try
            {
                ddlEstatus.DataTextField = "NombreEstatusSolicitudServicio";
                ddlEstatus.DataValueField = "EstatusSolicitudServicioID";
                ddlEstatus.DataSource = ConsultaServicios.ObtenerEstatusTodos();
                ddlEstatus.DataBind();
            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }

        }
        protected void ExportToExcel(object sender, EventArgs e)
        {
            string nombreArchivo;
            nombreArchivo = "VisitantesAtendidosentre" + this.txtFechaDesde.Text.Replace("/", "-") + "hasta" + this.txtFechaHasta.Text.Replace("/", "-") + ".xls";
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=" + nombreArchivo);
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                this.gridDetalle.AllowPaging = false;
                this.CargarServicios(this.txtFechaDesde.Text, this.txtFechaHasta.Text, Convert.ToString(this.ddlEstatus.SelectedItem));

                gridDetalle.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in gridDetalle.HeaderRow.Cells)
                {
                    cell.BackColor = gridDetalle.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in gridDetalle.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = gridDetalle.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = gridDetalle.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                gridDetalle.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarServicios(this.txtFechaDesde.Text, this.txtFechaHasta.Text, Convert.ToString(this.ddlEstatus.SelectedItem));
        }
    }
}