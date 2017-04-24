<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsignarTecnico.aspx.cs" Inherits="WebCenter.AsignarTecnico" %>

<%@ Register TagPrefix="MsgBox" Src="UCMessageBox.ascx" TagName="UCMessageBox" %>
<%@ Register TagPrefix="uc1" TagName="UCNavigation" Src="UCNavigation.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">

<html>
<head>
    <title>| Sistema Call Center | Asignar Técnico|</title>
	
	<link rel="stylesheet" href="Styles/estilo.css" type="text/css"/>
    <link rel="stylesheet" href="Styles/estilos.css" type="text/css"/>
	<script src="js/Util.js" type="text/javascript"></script>
    <script src="js/jquery.js"></script>
    <script src="js/jquery-ui-1.8rc3.custom.min.js"></script>
    <link href="Styles/simpleAutoComplete.css" rel="stylesheet" />
    <link href="Styles/jquery-ui-1.8rc3.custom.css" rel="stylesheet" />


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
            height: 22px;
        }
        .auto-style2 {
            height: 21px;
        }
        .auto-style3 {
            height: 43px;
        }
    </style>
    <script>


        function Confirmacion() {

            return confirm("¿Realmente desea eliminar este servicio?");
        }
    </script>

</head>
  
  <body>
 <MsgBox:UCMessageBox ID="messageBox" runat="server" ></MsgBox:UCMessageBox>
  <form id="form1" runat="server">
<table width="1000" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#ffffff">
    <tr>
      <td colspan="4"><img src="Images/top_cc.png" width="1000" height="160"></td>
    </tr>
    <tr>
      <td width="200" rowspan="2" align="left" valign="top" bgcolor="#37703e"><uc1:UCNavigation id="UserControl2" runat="server"></uc1:UCNavigation></td>
	  <td height="20" colspan="3" valign="top"  >&nbsp; <h2> Asignar Técnico</h2></td>
    </tr>
    <tr>
      <td width="10" height="350" valign="top">&nbsp;</td>
      <td width="770" valign="top" colspan="3">
      <!-- Contenido Aqui -->
          <table>


                <tr>
                    <td>
                        Técnico</td>
                    <td>
                          <asp:DropDownList ID="ddlTecnico" runat="server" AutoPostBack = "true" 
                            OnSelectedIndexChanged="ddlTecnico_SelectedIndexChanged" Width="520px">
                        <asp:ListItem Text = "--Seleccione el técnico--" Value = ""></asp:ListItem>
                        </asp:DropDownList>
                    </td>

                  <tr>
                      <td></td>
                      <td class="auto-style3" align ="center" >
                          <asp:Button Text="Asignar técnico" runat="server" ID ="btnAsignar"  CssClass ="boton_formulario" OnClick="btnAsignar_Click"/>
                          <asp:Button Text="<< Regresar" runat="server" ID ="btnRegresar"  CssClass ="boton_formulario" OnClick="btnRegresar_Click" />
                      </td>
                  </tr>
                    
          </table>

          <h2>Técnico asignados</h2>
          
          <asp:GridView ID="gridDetalle" runat="server" CssClass="subtitulo" EmptyDataText="No existen Registros" 
              GridLines="Horizontal" AutoGenerateColumns="False" OnRowCommand="gridDetalle_RowCommand" >
                <HeaderStyle CssClass ="registroTitulo" Font-Size="10px" />
                <AlternatingRowStyle CssClass ="registroNormal" Font-Size="10px" />
                  <RowStyle CssClass ="registroAlternado" Font-Size="10px" />
              <Columns>
                  <asp:TemplateField HeaderText="Fecha Asignación" HeaderStyle-Width="100">
                      <ItemTemplate>
                          <asp:Label runat="server" ID="lblFechaAsig" Text='<%# Eval("FechaAsignacionTecnico") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Técnico Asignado" HeaderStyle-Width="100">
                      <ItemTemplate>
                          <asp:Label runat="server" ID="lblTecnico" Text='<%# Eval("Tecnico") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Solicitante" HeaderStyle-Width="200px">
                      <ItemTemplate>
                          <asp:Label runat="server" ID="lblSolicitante" Text='<%# Eval("NombrePersonal") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Descripcion Servicio" HeaderStyle-Width="200px">
                      <ItemTemplate>
                          <asp:Label runat="server" ID="lblDescripcion" Text='<%# Eval("DescripcionSolicitudServicio") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Gerencia" HeaderStyle-Width="200px">
                      <ItemTemplate>
                          <asp:Label runat="server" ID="lblGerencia" Text='<%# Eval("NombreGerencia") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Fecha Solicitud" HeaderStyle-Width="200px">
                      <ItemTemplate>
                          <asp:Label runat="server" ID="lblFechaSol" Text='<%# Eval("FechaSolicitudServicio") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Extensión" HeaderStyle-Width="200px">
                      <ItemTemplate>
                          <asp:Label runat="server" ID="lblExtension" Text='<%# Eval("NumeroExtension") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Atención Teléfonica" HeaderStyle-Width="100px">
                      <ItemTemplate>
                          <asp:Label runat="server" ID="lblAtencion" Text='<%# Eval("AtencionTelefonica") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField HeaderText="Acciones" HeaderStyle-Width="100px">
                      <ItemTemplate>
                          <asp:ImageButton runat="server" ID="btnEliminar" AlternateText="Eliminar Detalle" OnClientClick="return Confirmacion();" ToolTip="Eliminar Detalle" CssClass="cBotones" ImageUrl="~/Images/eliminar.gif"  CommandName="EliminarDetalle" CommandArgument='<%# Eval("SolicitudServicioDetalleID") %>'/>
                      </ItemTemplate>
                  </asp:TemplateField>
              </Columns>
          </asp:GridView>



      </td>

    </tr>
    <tr>
      <td width="200" height="30" bgcolor="#d2d2c6">&nbsp;</td>
      <td width="10" bgcolor="#d2d2c6">&nbsp;</td>
      <td width="770" bgcolor="#d2d2c6" align="center" style="font-size: large" >Sistema HelpDesk Usuario: <%:Session["NombreCompletoUsuario"]%>
      <td width="20" bgcolor="#d2d2c6">&nbsp;</td>
    </tr>
  </table>
   
  
    </form>
</body>
</html>