<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnConstruccion.aspx.cs" Inherits="WebCenter.EnConstruccion" %>

<%@ Register TagPrefix="MsgBox" Src="UCMessageBox.ascx" TagName="UCMessageBox" %>
<%@ Register TagPrefix="uc1" TagName="UCNavigation" Src="UCNavigation.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">

<html>
<head>
    <title>| Sistema Call Center | En Construcci�n|</title>
	
	<link rel="stylesheet" href="Styles/estilo.css" type="text/css"/>
    <link rel="stylesheet" href="Styles/estilos.css" type="text/css"/>
	<script src="Util.js" type="text/javascript"></script>
    <script src="js/jquery.js"></script>
 

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
</style></head>
    <script>


        function Confirmacion() {

            return confirm("�Realmente desea eliminar este servicio?");
        }
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
	          <td colspan="3" valign="top"><img src="Images/pagina_en_construccion.jpg" width="800" height="80"></td>

    </tr>
    <tr>
      <td width="10" height="350" valign="top">&nbsp;</td>
      <td width="770" valign="top" colspan="3">
      <!-- Contenido Aqui -->


          <h2>Pronto</h2>
          
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

