using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.SessionState;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Data;

using System.Diagnostics;
using System.Reflection;
using Utils;

using System.Web.Services.Protocols;
using System.Runtime.InteropServices;
using System.Text;
using System.IO;

namespace Admin
{
    public partial  class paginaBase : Page
    {

        protected void Page_Init(object sender, EventArgs e)
        {
            //  Response.Cache.SetCacheability(HttpCacheability.NoCache);
        }
        public paginaBase()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
            this.Load += new EventHandler(Page_Load);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["UserID"] == null)
            {
                Server.Transfer("Login.aspx");
            }
        }
        public void DownloadDocument(HttpResponse Response, int DocumentID, string FileName)
        {
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + FileName);
            //Response.BinaryWrite(Global.DALCRM.GetPermitDocument(DocumentID));
        }

        public static double DALDateTimeOrNull(string aString)
        {
            double Result = -693594.0;
            if (IsValidDate(aString))
            {
                Result = DateTimeToDALDateTime(StringToDateTime(aString));
            }
            return Result;
        }

        public static DateTime DALDateTimeToDateTime(double DALDateTime)
        {
            DateTime Result;
            try
            {
                if (DALDateTime == 0f)
                {
                    return Convert.ToDateTime(-693594.0);
                }
                Result = DateTime.FromOADate(DALDateTime);
            }
            catch (Exception)
            {
                Result = DateTime.MinValue;
            }
            return Result;
        }

        public static double DateTimeToDALDateTime(DateTime ADateTime)
        {
            return ADateTime.ToOADate();

        }

        //public static ClientTypeEnum DBToCustomerType(int aDBValue)
        //{
        //    if (aDBValue == 2)
        //    {
        //        return ClientTypeEnum.ctCompany;
        //    }
        //    return ClientTypeEnum.ctPhysicalPerson;
        //}

        public static void DisableControls(Control Parent)
        {
            enabledControls(Parent, false);
        }

        public static void enabledControls(Control Parent, bool b)
        {

            for (int i = 0; i < Parent.Controls.Count; i++)
            {
                if (Parent.Controls[i] is Button)
                {
                    (Parent.Controls[i] as Button).Enabled = b;
                }
                else if (Parent.Controls[i] is LinkButton)
                {
                    (Parent.Controls[i] as LinkButton).Enabled = b;
                }
                else if (Parent.Controls[i] is TextBox)
                {
                    (Parent.Controls[i] as TextBox).Enabled = b;
                }
                else if (Parent.Controls[i] is DropDownList)
                {
                    (Parent.Controls[i] as DropDownList).Enabled = b;
                }
                else if (Parent.Controls[i] is ListBox)
                {
                    (Parent.Controls[i] as ListBox).Enabled = b;
                }
                else if (Parent.Controls[i] is DataGrid)
                {
                    (Parent.Controls[i] as DataGrid).Enabled = b;
                }
                else if (Parent.Controls[i] is GridView)
                {
                    (Parent.Controls[i] as GridView).Enabled = b;
                }
                else if (Parent.Controls[i] is DataList)
                {
                    (Parent.Controls[i] as DataList).Enabled = b;
                }
                else if (Parent.Controls[i] is HtmlInputButton)
                {
                    (Parent.Controls[i] as HtmlInputButton).Disabled = !b;
                }
                else if (Parent.Controls[i] is HtmlInputFile)
                {
                    (Parent.Controls[i] as HtmlInputFile).Disabled = !b;
                }
                if (Parent.Controls[i].HasControls())
                {
                    if (b)
                    {
                        EnableControls(Parent.Controls[i]);
                    }
                    else
                        DisableControls(Parent.Controls[i]);
                }

            }
        }
        public static void EnableControls(Control Parent)
        {
            enabledControls(Parent, true);
        }



        public static void FillCombo(DropDownList Combo, byte[] aDataset, string ValueField, string DescriptionField, bool InsertGenericElement, string GenericText, string GenericValue)
        {
            Combo.DataSource = XmlUtils.XMLToDataset(aDataset);
            Combo.DataValueField = ValueField;
            Combo.DataTextField = DescriptionField;
            Combo.DataBind();

            //seleccionamos el item default
            if ((Combo.DataSource as DataSet).Tables[0].Columns.Contains("Default"))
            {
                DataRow[] Defaults = (Combo.DataSource as DataSet).Tables[0].Select("Default = 1");
                if (((Defaults != null) ? Defaults.Length : 0) > 0)
                {
                    Combo.SelectedValue = Defaults[0][ValueField].ToString();
                }
            }

            //insertamos el campo any
            if (InsertGenericElement)
            {
                Combo.Items.Insert(0, new ListItem(GenericText, GenericValue));
                Combo.SelectedIndex = 0;
            }

            Combo.Enabled = Combo.Items.Count > 1;
        }



        public static void FillRegionCombo(DropDownList Combo, string CountryCode, bool IncludeAllItem, Page Page)
        {
            if (CountryCode == "")
            {
                Combo.DataSource = null;
                Combo.Items.Clear();
                if (IncludeAllItem)
                {
                    Combo.Items.Insert(0, new ListItem("All", ""));
                    Combo.SelectedIndex = 0;
                    Combo.Enabled = false;
                }
            }
            else
            {
                //FillCombo(Combo,  Global.DALConfig.EnumRegionsCRM(CountryCode, translation.GetCurrentLanguage(Page)), "RegionCode", "Description", IncludeAllItem, "All", "");
            }
        }

        //As GridView
        public void PrepareGridViewForExport(ref System.Web.UI.Control gview)
        {
            //Cleans up grid for exporting.  Takes links and visual elements and turns them into text.
            System.Web.UI.WebControls.LinkButton lb = new System.Web.UI.WebControls.LinkButton();
            System.Web.UI.WebControls.Literal l = new System.Web.UI.WebControls.Literal();
            string name = string.Empty;


            for (Int32 i = 0; i <= gview.Controls.Count - 1; i++)
            {
                if (gview.Controls[i] is System.Web.UI.WebControls.LinkButton)
                {
                    l.Text = ((System.Web.UI.WebControls.LinkButton)gview.Controls[i]).Text;
                    gview.Controls.Remove(gview.Controls[i]);
                    gview.Controls.AddAt(i, l);
                }
                else if (gview.Controls[i] is System.Web.UI.WebControls.ImageButton)
                {
                    l.Text = "";//((System.Web.UI.WebControls.ImageButton)gview.Controls[i]).ToolTip;
                    gview.Controls.Remove(gview.Controls[i]);
                    gview.Controls.AddAt(i, l);
                }
                else if (gview.Controls[i] is System.Web.UI.WebControls.CheckBox)
                {
                    l.Text = "";
                    //CType(gview.Controls(i), System.Web.UI.WebControls.CheckBox).Checked.ToString
                    gview.Controls.Remove(gview.Controls[i]);
                    gview.Controls.AddAt(i, l);
                }
                else if (gview.Controls[i] is UserControl)
                {
                    foreach (Control c in ((UserControl)gview.Controls[i]).Controls)
                    {
                        if ((c) is TextBox)
                        {
                            l.Text = ((TextBox)c).Text;
                        }
                    }
                    gview.Controls.Remove(gview.Controls[i]);
                    gview.Controls.AddAt(i, l);
                }
                //else if (gview.Controls[i] is eWorld.UI.NumericBox)
                //{
                //    l.Text = ((eWorld.UI.NumericBox)gview.Controls[i]).Text;
                //    gview.Controls.Remove(gview.Controls[i]);
                //    gview.Controls.AddAt(i, l);
                //}
                else if (gview.Controls[i] is DropDownList)
                {
                    try
                    {
                        l.Text = ((DropDownList)gview.Controls[i]).SelectedItem.Text;
                    }
                    catch
                    {
                        l.Text = "";
                    }
                    gview.Controls.Remove(gview.Controls[i]);
                    gview.Controls.AddAt(i, l);
                }
                else if (gview.Controls[i] is TextBox)
                {
                    l.Text = ((TextBox)gview.Controls[i]).Text;
                    gview.Controls.Remove(gview.Controls[i]);
                    gview.Controls.AddAt(i, l);
                }
                else if (gview.Controls[i] is ImageButton)
                {
                    l.Text = "";
                    gview.Controls.Remove(gview.Controls[i]);
                    gview.Controls.AddAt(i, l);
                }
                if (gview.Controls[i].HasControls())
                {
                    var control = gview.Controls[i];
                    PrepareGridViewForExport(ref control);
                }
            }

        }


        public void ExportGridView(GridView gridView, string nombreArchivo)
        {
            var control = ((Control)gridView);
            PrepareGridViewForExport(ref control);
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            Page pagina = new Page();
            dynamic form = new HtmlForm();
            gridView.EnableViewState = false;
            pagina.EnableEventValidation = false;
            pagina.DesignerInitialize();
            pagina.Controls.Add(form);
            form.Controls.Add(gridView);
            pagina.RenderControl(htw);
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + nombreArchivo);
            Response.Charset = "UTF-8";
            Response.ContentEncoding = Encoding.Default;
            Response.Write(sb.ToString());
            Response.End();

        }

        public static string GetAppVersion()
        {
            FileVersionInfo ver = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location);
            string[] textArray1 = new string[] { ver.FileMajorPart.ToString(), ".", ver.FileMinorPart.ToString(), ".", ver.FileBuildPart.ToString() };
            return string.Concat(textArray1);
        }



        public static string GetDescription(byte[] aDataset, string SearchField, string DescriptionField, string ValueToFind, string NotFoundDesc)
        {
            DataRow[] aResult = XmlUtils.XMLToDataset(aDataset).Tables[0].Select(SearchField + " = '" + ValueToFind + "'");
            if (((aResult != null) ? aResult.Length : 0) > 0)
            {
                return aResult[0][DescriptionField].ToString();
            }
            return NotFoundDesc;
        }

        public static int GetExceptionErrorCode(Exception e)
        {
            if (e is SoapException)
            {
                SoapException RE = e as SoapException;
                if (RE.Code.ToString().Substring(0, 2).CompareTo("CS") == 0)
                {
                    return (int)IntOrZero(RE.Code.ToString().Substring(3, RE.Code.ToString().Length - 3));
                }
            }
            return 0;
        }

      

        public static string GetExceptionMessage(Page Page, Exception e)
        {
            string Result;
            try
            {
                Result = e.Message; //GetExceptionMessage(translation.GetCurrentLanguage(Page), e);
            }
            catch (Exception ex)
            {
                Result = "";//GetExceptionMessage("ITA", ex);

            }
            return Result;
            //return e.Message;
        }



        public static string GetTempDir(Page Page)
        {
            return (Page.Server.MapPath("/") + @"temp\");
        }



        public static long IntOrZero(string aValue)
        {
            long Result = 0L;
            if (aValue.Trim() != "")
            {
                try
                {
                    Result = Convert.ToInt64(aValue.Trim());
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return Result;
        }

        public static bool IsValidDate(string Date)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(Date, @"(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d");
        }

        public static bool IsValidEmail(string Mail)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(Mail, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");
        }

        public static bool LoggedIn(HttpSessionState Session)
        {
            bool Result = true;
            if (Session["UserName"] == null)
            {
                Result = false;
            }
            if (Session["UserID"] == null)
            {
                Result = false;
            }
            //if (Session["Privileges"] == null)
            //{
            //    Result = false;
            //}
            return Result;
        }

        public static double ObjectToDALDateTime(object O)
        {
            if (Convert.IsDBNull(O))
            {
                return -693594.0;
            }
            return DateTimeToDALDateTime(Convert.ToDateTime(O));
        }

        public static void RestoreViewStates(Page Page, HttpSessionState Session)
        {
            foreach (Control control in Page.Controls)
            {
                if (Session[Page.ID + "_" + control.ID] != null)
                {
                    if (control is Label)
                    {
                        (control as Label).Text = Session[Page.ID + "_" + control.ID].ToString();
                    }
                    else if (control is TextBox)
                    {
                        (control as TextBox).Text = Session[Page.ID + "_" + control.ID].ToString();
                    }
                    else if (control is DropDownList)
                    {
                        (control as DropDownList).SelectedValue = Session[Page.ID + "_" + control.ID].ToString();
                    }
                }
            }
        }

        public static void SaveViewStates(Page Page, HttpSessionState Session)
        {
            foreach (Control control in Page.Controls)
            {
                if (control is Label)
                {
                    Session[Page.ID + "_" + control.ID] = (control as Label).Text;
                }
                else if (control is TextBox)
                {
                    Session[Page.ID + "_" + control.ID] = (control as TextBox).Text;
                }
                else if (control is DropDownList)
                {
                    Session[Page.ID + "_" + control.ID + "_ITEMS"] = (control as DropDownList).Items;
                    Session[Page.ID + "_" + control.ID + "_VALUE"] = (control as DropDownList).SelectedValue;
                }
            }
        }

        public static void SearchCustomer(string RedirectPage, HttpSessionState Session, HttpResponse Response)
        {
            Session["SearchCustomerCommand"] = "REDIRECT";
            Session["SearchCustomerRedirectURL"] = RedirectPage;
            Response.Redirect("SearchCustomer.aspx", false);
        }

        public static void SearchVehicle(string RedirectPage, HttpSessionState Session, HttpResponse Response)
        {
            Session["SearchVehicleCommand"] = "REDIRECT";
            Session["SearchVehicleRedirectURL"] = RedirectPage;
            Response.Redirect("SearchVehicle.aspx", false);
        }

        public static void ShowError(string ErrorDesc, HttpSessionState Session, HttpResponse Response)
        {
            Session["Error"] = ErrorDesc;
            Response.Redirect("Error.aspx", true);
        }

        public static DateTime StringToDateTime(string aString)
        {
            return DateTime.ParseExact(aString, "dd/MM/yyyy", null);
        }

        public static bool VerifyLoggedIn(HttpSessionState Session, HttpResponse Response)
        {
            bool Result = true;
            string language = Convert.ToString(Session["Language"]);
            if (!LoggedIn(Session))
            {
                language = Convert.ToString(Session["Language"]);
                Response.Redirect("SessionExpired.aspx", false);
                Result = false;
            }
            return Result;
        }


        /****************fiscal code***********************************/

        [DllImport("cfCheck.dll", CharSet = CharSet.Auto, EntryPoint = "cfCheck")]
        public extern static int cfCheck([MarshalAs(UnmanagedType.LPArray)] byte[] cfString, char gender);
        //public extern static int InvokeFunc(int funcptr, string cfString, string gender); //esto es para la dll de SyntaxControlForCarina.dll

        public static bool TestFiscalCodeDLL(string texto, char chr)
        {

            int result = 99;
            //habria que ver si necesita el \0 agregado al final de la cadena Encoding.ASCII.GetBytes(texto+"\0")

            result = cfCheck(Encoding.ASCII.GetBytes(texto), chr);

            return result == 1;
        }


        /****************LNP***********************************/
        [DllImport("SyntaxControlPcc.dll", CharSet = CharSet.Unicode, EntryPoint = "SyntaxControlPlate")]
        public extern static bool SyntaxControlPlate(byte[] message, int len, int classification);

        public static bool TestLPNDLL(string texto, string classification)
        {
            bool result = SyntaxControlPlate(Encoding.ASCII.GetBytes(texto), texto.Length, Convert.ToInt32(classification));
            return result;
        }



        public enum MessageType
        {
            Error = 0,
            Information = 1,
            Exclamation = 2,
            Confirm = 3
        }





        public static List<string> BytesToStringList(params byte[] B)
        {
            List<string> Result = new List<string>();
            DataSet dsSL = XmlUtils.XMLToDataset(B);
            int num = dsSL.Tables[0].Rows.Count - 1;
            int i = 0;
            if (num >= i)
            {
                num++;
                do
                {
                    Result.Add(dsSL.Tables[0].Rows[i][0].ToString());
                    i++;
                }
                while (i != num);
            }
            return Result;
        }


        public class Entidad
        {
            public string Iata { get; set; }
            public string Nombre { get; set; }


            /*estos campos son solo para City*/
            public string CountryCode { get; set; }
            public string RegionCode { get; set; }
            public string Country { get; set; }
            public string Region { get; set; }
        }

        public class AutoCompleteResult
        {
            public string id { get; set; }
            public string value { get; set; }
            public string Descripcion { get; set; }
            /*estos campos son solo para City*/
            public string CountryCode { get; set; }
            public string RegionCode { get; set; }
            public string Country { get; set; }
            public string Region { get; set; }

        }

        //public delegate void TSelectionEvent(int SelectedCustomer);
        //public delegate void TSearchEvent();

    }
}