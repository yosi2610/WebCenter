<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AtencionCallCenter.aspx.cs" Inherits="WebCenter.AtencionCallCenter" %>

<%@ Register TagPrefix="MsgBox" Src="UCMessageBox.ascx" TagName="UCMessageBox" %>
<%@ Register TagPrefix="uc1" TagName="UCNavigation" Src="UCNavigation.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">

<html>
<head>
    <title>| Sistema Call Center | Solicitud Apoyo Técnico|</title>
	
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

        $(function () {
            $('#txtCedula').simpleAutoComplete('Autocomplete.aspx', {
                autoCompleteClassName: 'autocomplete',
                selectedClassName: 'sel',
                attrCallBack: 'rel',
                identifier: 'AtencionCallCenter'
            }, fnPersonalCallBack);

        });

        function fnPersonalCallBack(par) {
            document.getElementById("hdnPersonalID").value = par[5]; //par[0] id
            document.getElementById("hdnCedula").value = par[6]
            var bt = document.getElementById("Button2");

            bt.click();
        }

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
      <td width="200" rowspan="3" align="left" valign="top" bgcolor="#37703e"><uc1:UCNavigation id="UserControl2" runat="server"></uc1:UCNavigation></td>
	  <td height="20" colspan="3" valign="top"  >&nbsp; <h2> Solicitud de Apoyo Técnico</h2></td>
        
    </tr>
    <tr>
        <td><asp:Image  runat="server" ID="imgPersonal" width="80" height="80" ImageUrl="Images/crm.gif" onerror="this.onload = null; this.src='Images/crm.gif';" /></td>
    </tr>
    <tr>
      <td width="10" height="350" valign="top">&nbsp;</td>
      <td width="770" valign="top" colspan="3">
      <!-- Contenido Aqui -->
          <table>
                <tr>
                    <td class="auto-style2">
                        <asp:Label Text="Usuario" ID="Label5" runat="server" AssociatedControlID="txtCedula" />
                    </td>
                    <td class="auto-style2">
                            <asp:TextBox runat="server" ID="txtCedula" onkeypress="return event.keyCode!=13;" MaxLength="12" Width="520px"/>

                            <asp:HiddenField runat ="server" ID ="hdnPersonalID"  Value="0"/> 
                             <asp:HiddenField runat ="server" ID ="hdnCedula"  Value="0"/> 
                     </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label Text="Descripción del Problema" ID="Label1" runat="server" />
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox runat="server" ID="txtDescripcion" TextMode="MultiLine" Rows="3" MaxLength="50" Width="520px"/> 
                    </td>
                </tr>
                <tr>
                    <td>
                        Area de servicio</td>
                    <td>
                          <asp:DropDownList ID="ddlArea" runat="server" AutoPostBack = "true" 
                            OnSelectedIndexChanged="ddlArea_SelectedIndexChanged" Width="520px">
                        <asp:ListItem Text = "--Seleccione el area de servicio--" Value = ""></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                <tr>
                    <td class="auto-style1">
                        Detalle area de servicio</td>
                    <td class="auto-style1">
                        
                        <asp:DropDownList ID="ddlAreaDetalle" runat="server" AutoPostBack = "true"
                        Enabled = "false"  Width="520px">
                        <asp:ListItem Text = "--Seleccione el detalle del area--" Value = ""></asp:ListItem>
                        </asp:DropDownList>
                        <!-- <ASP:RequiredFieldValidator id="rqrValidaAreaDetalle" runat="server" errormessage="Debe colocar el detalle del area" width="132px" controltovalidate="ddlAreaDetalle" display="Dynamic"></ASP:RequiredFieldValidator> -->
                    </td>
                </tr>
                  <tr>
                      <td></td>
                      <td class="auto-style3" align ="center" >
                          <asp:Button Text="Enviar a cola" runat="server" ID ="btnGuardar"  CssClass ="boton_formulario" OnClick="btnGuardar_Click"/>
                          <asp:Button Text="Resuelto" runat="server" ID ="btnResuelto"  CssClass ="boton_formulario" OnClick="btnResuelto_Click" />
                          <asp:Button Text="Limpiar" runat="server" ID ="btnLimpiar"  CssClass ="boton_formulario" OnClick="btnLimpiar_Click" />
                          <asp:Button Text="TEST" runat="server" ID ="Button2" style="display:none" CssClass ="boton_formulario" OnClick="Button2_Click" />
                      </td>
                  </tr>
                    
          </table>

          <h2>Detalle de servicios</h2>
          
          <asp:GridView ID="gridDetalle" runat="server" CssClass="subtitulo" EmptyDataText="No existen Registros" 
              GridLines="Horizontal" AutoGenerateColumns="False" OnRowCommand="gridDetalle_RowCommand" >
                <HeaderStyle CssClass ="registroTitulo" Font-Size="10px" />
                <AlternatingRowStyle CssClass ="registroNormal" Font-Size="10px" />
                  <RowStyle CssClass ="registroAlternado" Font-Size="10px" />
              <Columns>
                  <asp:TemplateField HeaderText="Fecha Solicitud" HeaderStyle-Width="100    ">
                      <ItemTemplate>
                          <asp:Label runat="server" ID="lblFechaSol" Text='<%# Eval("FechaSolicitudServicio") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Descripcion Servicio" HeaderStyle-Width="200px">
                      <ItemTemplate>
                          <asp:Label runat="server" ID="lblDescripcion" Text='<%# Eval("DescripcionSolicitudServicio") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField HeaderText="Estatus" HeaderStyle-Width="50">
                      <ItemTemplate>
                          <asp:Label runat="server" ID="lblEstatus" Text='<%# Eval("NombreEstatusSolicitudServicio") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField HeaderText="Fecha Finalización" HeaderStyle-Width="100px">
                      <ItemTemplate>
                          <asp:Label runat="server" ID="lblFechaFinal" Text='<%# Eval("FechaFinalizacionSolicitudServicio") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Atención Teléfonica" HeaderStyle-Width="100px">
                      <ItemTemplate>
                          <asp:Label runat="server" ID="lblAtencion" Text='<%# Eval("AtencionTelefonica") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField HeaderText="Acciones" HeaderStyle-Width="100px">
                      <ItemTemplate>
                          <asp:ImageButton runat="server" ID="btnEliminar" AlternateText="Eliminar Detalle" OnClientClick="return Confirmacion();" ToolTip="Eliminar Detalle" CssClass="cBotones" ImageUrl="~/Images/eliminar.gif"  CommandName="EliminarDetalle" CommandArgument='<%# Eval("SolicitudServicioID") %>'/>
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
