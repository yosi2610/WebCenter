<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultaServicios.aspx.cs" Inherits="WebCenter.ConsultaServicios" %>

<%@ Register TagPrefix="MsgBox" Src="UCMessageBox.ascx" TagName="UCMessageBox" %>
<%@ Register TagPrefix="uc1" TagName="UCNavigation" Src="UCNavigation.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">

<html>
<head>
    <title>| Sistema Call Center | Consulta de Servicios |</title>
	
	<link rel="stylesheet" href="Styles/estilo.css" type="text/css"/>
    <link rel="stylesheet" href="Styles/estilos.css" type="text/css"/>
	<script src="Util.js" type="text/javascript"></script>
    <script src="js/jquery.js"></script>
    <link href="Styles/jquery-ui-1.8rc3.custom.css" rel="stylesheet" />
    <script src="js/jquery-ui-1.8rc3.custom.min.js"></script>
  <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1"><style type="text/css">BODY {
	FONT-SIZE: 8.5pt
}
TD {
	FONT-SIZE: 8.5pt
}
TH {
	FONT-SIZE: 8.5pt
}
BODY {
	BACKGROUND-IMAGE: url(Images/fondo.jpg); BACKGROUND-COLOR: #ffffff
}
                                                                              .auto-style1 {
                                                                                  height: 20px;
                                                                              }
                                                                          </style></head>
    <script>
        $(function () {

            //Array para dar formato en español
            $.datepicker.regional['es'] =
            {
                closeText: 'Cerrar',
                prevText: 'Previo',
                nextText: 'Próximo',

                monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio',
                'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
                monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun',
                'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
                monthStatus: 'Ver otro mes', yearStatus: 'Ver otro año',
                dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
                dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mie', 'Jue', 'Vie', 'Sáb'],
                dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sa'],
                dateFormat: 'dd/mm/yy', firstDay: 0,
                initStatus: 'Selecciona la fecha', isRTL: false
            };
            $.datepicker.setDefaults($.datepicker.regional['es']);

            $("#txtFechaDesde").datepicker({
                dateFormat: 'dd/mm/yy', showOn: 'button', buttonImage: 'images/Calendar_scheduleHS.png', buttonImageOnly: true, changeMonth: true,
                changeYear: true, gotoCurrent: true
            });

            $("#txtFechaHasta").datepicker({
                dateFormat: 'dd/mm/yy', showOn: 'button', buttonImage: 'images/Calendar_scheduleHS.png', buttonImageOnly: true, changeMonth: true,
                changeYear: true, gotoCurrent: true
            });
        });
    </script>  
 <body>
 <MsgBox:UCMessageBox ID="messageBox" runat="server" ></MsgBox:UCMessageBox>
  <form id="form1" runat="server">
<table width="1000" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#ffffff">
    <tr>
      <td colspan="4"><img src="Images/top_cc.png" width="1000" height="160"></td>
    </tr>
    <tr>
      <td width="200" rowspan="2" align="left" valign="top" bgcolor="#37703e"><uc1:UCNavigation id="UserControl2" runat="server"></uc1:UCNavigation></td>
	  <td colspan="3" valign="top" class="auto-style1"  ></td>
    </tr>
    <tr>
      <td width="10" height="350" valign="top">&nbsp;</td>
      <td width="770" valign="top" colspan="3">
      <!-- Contenido Aqui -->

          <table>
              <tr>
                  <td class="auto-style2">
                      <asp:Label Text="Fecha Desde" ID="Label1" runat="server" />
                  </td>
                  <td class="auto-style2">
                      <asp:TextBox runat="server" ID="txtFechaDesde"  Width="100"/> 
                  </td>
                 <td class="auto-style2">
                      <asp:Label Text="Fecha Hasta" ID="Label2" runat="server" />
                  </td>
                  <td class="auto-style2">
                      <asp:TextBox runat="server" ID="txtFechaHasta"  Width="100"/> 
                  </td>
                  <td class ="auto-style2">
                      <asp:Label Text="Estatus" ID="Label3" runat="server" />
                  </td>
                  <td = class ="auto-style2">
                    <asp:DropDownList ID="ddlEstatus" runat="server" Width="150"> </asp:DropDownList>
                  </td>
                  <td class="auto-style2">
                      <asp:Button Text="Consultar" runat="server" ID ="btnConsultar"  CssClass ="boton_formulario" OnClick="btnConsultar_Click"/>
                  </td>
              </tr>
              <tr>
                    <td>

                    </td>
                    <td>

                    </td>
                    <td>

                    </td>
                    <td>

                    </td>
                    <td>

                    </td>
                    <td>

                    </td>
                  <td>
                     <asp:Button ID="btnExport" runat="server" CssClass ="boton_formulario" Text="Exportar a Excel" OnClick = "ExportToExcel" />
                  </td>
              </tr>

          </table>
          
          <asp:GridView ID="gridDetalle" runat="server" CssClass="subtitulo" EmptyDataText="No existen Registros" 
              GridLines="Horizontal" AutoGenerateColumns="False" >
                <HeaderStyle CssClass ="registroTitulo" Font-Size="10px" />
                <AlternatingRowStyle CssClass ="registroNormal" Font-Size="10px" />
                  <RowStyle CssClass ="registroAlternado" Font-Size="10px" />
              <Columns>
                  <asp:TemplateField HeaderText="Fecha Solicitud" HeaderStyle-Width="100">
                      <ItemTemplate>
                          <asp:Label runat="server" ID="lblFechaSol" Text='<%# Eval("FechaSolicitudServicio") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="N° Caso" HeaderStyle-Width="40">
                      <ItemTemplate>
                          <asp:Label runat="server" ID="lblCaso" Text='<%# Eval("SolicitudServicioID") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Solicitante" HeaderStyle-Width="130 ">
                      <ItemTemplate>
                          <asp:Label runat="server" ID="lblSolicitante"  Text= '<%# Eval("NombrePersonal") %>' Font-Bold ="true" ForeColor = '<%# Eval("EstatusTecnico").ToString() == ""?System.Drawing.Color.Red:System.Drawing.Color.Blue %>' ></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Gerencia" HeaderStyle-Width="130 ">
                      <ItemTemplate>
                          <asp:Label runat="server" ID="lblGerencia"  Text= '<%# Eval("NombreGerencia") %>' Font-Bold ="true" ForeColor = '<%# Eval("EstatusTecnico").ToString() == ""?System.Drawing.Color.Red:System.Drawing.Color.Blue %>' ></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Descripcion Solicitud" HeaderStyle-Width="150px">
                      <ItemTemplate>
                          <asp:Label runat="server" ID="lblDescripcion" Text='<%# Eval("DescripcionSolicitudServicio")  %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField HeaderText="Técnico Asignado" HeaderStyle-Width="50">
                      <ItemTemplate>
                          <asp:Label runat="server" ID="lblTecnico"   Text='<%# Eval("TecnicoAsignado") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>

                  <asp:TemplateField HeaderText="Observaciones Tecnico" HeaderStyle-Width="100px">
                      <ItemTemplate>
                          <asp:Label runat="server" ID="lblObservacion" Text='<%# Eval("ObservacionTecnico") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Estatus" HeaderStyle-Width="100px">
                      <ItemTemplate>
                          <asp:Label runat="server" ID="lblEstatus" Text='<%# Eval("DescripcionEstatus") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Finalización" HeaderStyle-Width="100px">
                      <ItemTemplate>
                          <asp:Label runat="server" ID="lblFechaFinal" Text='<%# Eval("FechaFinalizacionTecnico") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
              </Columns>
          </asp:GridView>
      </td>

    </tr>
    <tr>
      <td width="200" height="30" bgcolor="#d2d2c6">&nbsp;</td>
      <td width="10" bgcolor="#d2d2c6">&nbsp;</td>
      <td width="770" bgcolor="#d2d2c6">&nbsp;</td>
      <td width="20" bgcolor="#d2d2c6">&nbsp;</td>
    </tr>
  </table>
   
  
    </form>
</body>
</html>
