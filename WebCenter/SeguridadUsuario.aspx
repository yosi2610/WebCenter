<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeguridadUsuario.aspx.cs" Inherits="WebCenter.SeguridadUsuario" %>

<%@ Register TagPrefix="MsgBox" Src="UCMessageBox.ascx" TagName="UCMessageBox" %>
<%@ Register TagPrefix="uc1" TagName="UCNavigation" Src="UCNavigation.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">

<html>
<head>
    <title>| Sistema Call Center | Usuarios|</title>
	
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
        .auto-style2 {
            height: 21px;
        }
        .auto-style3 {
            height: 43px;
        }
    </style>
    <script>

        $(function () {
            $('#txtNombre').simpleAutoComplete('Autocomplete.aspx', {
                autoCompleteClassName: 'autocomplete',
                selectedClassName: 'sel',
                attrCallBack: 'rel',
                identifier: 'Usuarios'
            }, fnPersonalCallBack);

        });

        function fnPersonalCallBack(par) {
            document.getElementById("chkTecnico").checked = false;
            document.getElementById("chkEstatus").checked = false;
            document.getElementById("hdnSeguridadUsuarioDatosID").value = par[0]; //par[0] id
            document.getElementById("txtNombre").value = par[1];
            document.getElementById("txtLogin").value = par[2];
            document.getElementById("txtClave").value = par[3];
            document.getElementById("txtDescripion").value = par[4];
            document.getElementById("hdnTecnico").value = par[6];
            document.getElementById("hdnEstatus").value = par[7];

            if (document.getElementById("hdnTecnico").value == "True") {
                document.getElementById("chkTecnico").checked = true;
            }
            if (document.getElementById("hdnEstatus").value == "Activo") {
                document.getElementById("chkEstatus").checked = true;
            }
            $("#ddlGrupo").val(par[5]);
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
	  <td height="20" colspan="3" valign="top"  >&nbsp; <h2> Agregar/Modificar Usuario</h2></td>
    </tr>
    <tr>
      <td width="10" height="350" valign="top">&nbsp;</td>
      <td width="770" valign="top" colspan="3">
      <!-- Contenido Aqui -->
          <table>
                <tr>
                    <td class="auto-style2">
                        <asp:Label Text="Nombre Completo" ID="Label6" runat="server" />
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox runat="server" ID="txtNombre" MaxLength="100" onkeypress="return event.keyCode!=13;" Width ="300"/> 
                        <asp:HiddenField runat ="server" ID ="hdnSeguridadUsuarioDatosID"  Value="0"/>
                        <ASP:RequiredFieldValidator id="rqrValidaNombre" runat="server" errormessage="Debe colocar el nombre completo" width="132px" controltovalidate="txtNombre" display="Dynamic"></ASP:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label Text="Login" ID="Label5" runat="server" />
                    </td>
                    <td class="auto-style2">
                            <asp:TextBox runat="server" ID="txtLogin"  MaxLength="50"/> 
                            <ASP:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" errormessage="Debe colocar el login" width="132px" controltovalidate="txtLogin" display="Dynamic"></ASP:RequiredFieldValidator>
                      </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label Text="Clave" ID="Label1" runat="server" />
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox runat="server" ID="txtClave" MaxLength="50" /> 
                        <ASP:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" errormessage="Debe colocar la clave" width="132px" controltovalidate="txtClave" display="Dynamic"></ASP:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label Text="Descripción" ID="Label7" runat="server" />
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox runat="server" ID="txtDescripion" MaxLength="200" Width ="300"/> 
                        <ASP:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" errormessage="Debe colocar la descripción del usuario" width="132px" controltovalidate="txtDescripion" display="Dynamic"></ASP:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label Text="Grupo" ID="Label2" runat="server" />
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlGrupo" runat="server" AutoPostBack = "true" Width="300" ></asp:DropDownList>
                    </td>

                <tr>
                    <td class="auto-style2">
                        <asp:Label Text="Usuario Tecnico" ID="Label4" runat="server" />
                    </td>
                    <td class="auto-style2">
                        <asp:CheckBox runat="server" ID="chkTecnico"/> 
                        <asp:HiddenField runat ="server" ID ="hdnTecnico"  Value=""/>
                     </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <asp:Label Text="Activo" ID="Label3" runat="server" />
                    </td>
                    <td class="auto-style2">
                        <asp:CheckBox runat="server" ID="chkEstatus" Checked="True"/> 
                        <asp:HiddenField runat ="server" ID ="hdnEstatus"  Value=""/>
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
      <td width="770" bgcolor="#d2d2c6">&nbsp;</td>
      <td width="20" bgcolor="#d2d2c6">&nbsp;</td>
    </tr>
  </table>
   
  
    </form>
</body>
</html>

