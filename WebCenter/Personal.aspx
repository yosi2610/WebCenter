<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Personal.aspx.cs" Inherits="WebCenter.Personal" %>

<%@ Register TagPrefix="MsgBox" Src="UCMessageBox.ascx" TagName="UCMessageBox" %>
<%@ Register TagPrefix="uc1" TagName="UCNavigation" Src="UCNavigation.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">

<html>
<head>
    <title>| Sistema Call Center | Personal|</title>
	
	<link rel="stylesheet" href="Styles/estilo.css" type="text/css"/>
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
                identifier: 'Personal'
            }, fnPersonalCallBack);

        });

        function fnPersonalCallBack(par) {
            document.getElementById("hdnPersonalID").value = par[5]; //par[0] id
            document.getElementById("txtNombre").value = par[1];
            document.getElementById("txtExtension").value = par[4];
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
	  <td height="20" colspan="3" valign="top"  >&nbsp; <h2> Agregar/Modificar Personal</h2></td>
    </tr>
    <tr>
      <td width="10" height="350" valign="top">&nbsp;</td>
      <td width="770" valign="top" colspan="3">
      <!-- Contenido Aqui -->
          <table>
                <tr>
                    <td>
                        <asp:Label Text="" ID="lblPersonalID" runat="server" />
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtId" Visible="False" MaxLength="12"/>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label Text="Cedula" ID="Label5" runat="server" />
                    </td>
                    <td class="auto-style2">
                            <asp:TextBox runat="server" ID="txtCedula" onkeypress="return event.keyCode!=13;" MaxLength="12"/> 
                            <asp:HiddenField runat ="server" ID ="hdnPersonalID"  Value="0"/>
                            <ASP:RequiredFieldValidator id="rqrValidaCedula" runat="server" errormessage="Debe colocar la cedula" width="132px" controltovalidate="txtCedula" display="Dynamic"></ASP:RequiredFieldValidator>
                     </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label Text="Nombre" ID="Label1" runat="server" />
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox runat="server" ID="txtNombre" MaxLength="50"/> 
                        <ASP:RequiredFieldValidator id="rqrValidadNombre" runat="server" errormessage="Debe colocar el nombre" width="132px" controltovalidate="txtNombre" display="Dynamic"></ASP:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Gerencia" ID="Label2" runat="server" />
                    </td>
                    <td>
                          <asp:DropDownList ID="ddlGerencia" runat="server" AutoPostBack = "true" 
                            OnSelectedIndexChanged="ddlGerencia_SelectedIndexChanged">
                        <asp:ListItem Text = "--Selecione Gerencia--" Value = ""></asp:ListItem>
                        </asp:DropDownList>
                        <ASP:RequiredFieldValidator id="rqrValidaGerencia" runat="server" errormessage="Debe colocar la gerencia" width="132px" controltovalidate="ddlGerencia" display="Dynamic"></ASP:RequiredFieldValidator>
                    </td>
                <tr>
                    <td class="auto-style1">
                        <asp:Label Text="División" ID="Label3" runat="server" />
                    </td>
                    <td class="auto-style1">
                        
                        <asp:DropDownList ID="ddlDivision" runat="server" AutoPostBack = "true"
                        Enabled = "false" >
                        <asp:ListItem Text = "--Seleccione División--" Value = ""></asp:ListItem>
                        </asp:DropDownList>
                        <ASP:RequiredFieldValidator id="rqrValidaDivision" runat="server" errormessage="Debe colocar la división" width="132px" controltovalidate="ddlDivision" display="Dynamic"></ASP:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label Text="Extensión" ID="Label4" runat="server" />
                    </td>
                    <td class="auto-style2">
                        
                            <asp:TextBox runat="server" ID="txtExtension" MaxLength="5"/> 
                             <ASP:RequiredFieldValidator id="rqrValidaExtension" runat="server" errormessage="Debe colocar el numero de extensión" width="132px" controltovalidate="txtExtension" display="Dynamic"></ASP:RequiredFieldValidator>
                     </td>
                </tr>
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
      <%--<td width="770" bgcolor="#d2d2c6">&nbsp;</td>--%>
      <td width="770" bgcolor="#d2d2c6" align="center" style="font-size: large" >Sistema HelpDesk Usuario: <%:Session["NombreCompletoUsuario"]%>
      <td width="20" bgcolor="#d2d2c6">&nbsp;</td>
    </tr>
  </table>
   
  
    </form>
</body>
</html>

