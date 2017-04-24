<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsignacionesTecnico.aspx.cs" Inherits="WebCenter.AsignacionesTecnico" %>


<%@ Register TagPrefix="MsgBox" Src="UCMessageBox.ascx" TagName="UCMessageBox" %>
<%@ Register TagPrefix="uc1" TagName="UCNavigation" Src="UCNavigation.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">

<html>
<head>
    <title>| Sistema Call Center | Asignaciones Técnico|</title>
	
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
                                                                              .auto-style4 {
                                                                                  height: 276px;
                                                                              }
                                                                              .auto-style5 {
                                                                                  height: 21px;
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
      <td width="200" rowspan="3" align="left" valign="top" bgcolor="#37703e"><uc1:UCNavigation id="UserControl2" runat="server"></uc1:UCNavigation></td>
	  <td height="20" colspan="3" valign="top"  >&nbsp; <h2> 
         <asp:Label Text="" ID="lblTituloForma" runat="server" /></h2></td>
    </tr>
    <tr>
      <td width="10" valign="top" class="auto-style4"></td>
      <td width="770" valign="top" colspan="2" class="auto-style4">
      <!-- Contenido Aqui -->

          <table>
                <tr>
                    <td class="auto-style5">
                        <asp:Label Text="" ID="Asignaciones" runat="server" />
                    </td>
                    <td class="auto-style5">
                        <asp:DropDownList ID="ddlAsignaciones" runat="server" AutoPostBack = "true" 
                                     Width="700">
                                    <asp:ListItem Text = "--Seleccione la asignación--" Value = ""></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label Text="Observaciones" ID="Label5" runat="server" />
                    </td>
                    <td class="auto-style2">
                            <asp:TextBox runat="server" ID="txtObservaciones" TextMode="MultiLine" Rows="3" MaxLength="50" Width="700"/>
                     </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label Text="Minutos empleados" ID="Label1" runat="server" />
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox runat="server" ID="txtMinutos" MaxLength="3" Width="40"/> 
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Estatus" ID="Label2" runat="server" />
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlEstatus" runat="server" AutoPostBack = "true" Width="520" >
                        <asp:ListItem Text = "--Selecione el Estatus--" Value = "" ></asp:ListItem>
                        </asp:DropDownList>
                        <%--<ASP:RequiredFieldValidator id="rqrValidaGerencia" runat="server" errormessage="Debe colocar la gerencia" width="132px" controltovalidate="ddlGerencia" display="Dynamic"></ASP:RequiredFieldValidator>--%>
                    </td>
                  <tr>
                      <td class="auto-style3">
                          <asp:Button Text="Guardar" runat="server" ID ="btnGuardar"  CssClass ="boton_formulario" OnClick="btnGuardar_Click"/>
                      </td>
                      <td class="auto-style3">
                        
                      </td>
                  </tr>
                    
          </table>          
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