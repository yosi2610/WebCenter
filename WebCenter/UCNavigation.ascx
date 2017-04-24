<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCNavigation.ascx.cs" Inherits="Teach.UCNavigation" %>
<table width="200" border="0" cellspacing="1" cellpadding="0">
    <tr>
      <td height="10" colspan="4"><img src="Images/1.gif" width="198" height="15" /></td>
    </tr>
    <tr id="divLogin" runat="server">
      <td height="20">&nbsp;</td>
      <td bgcolor="#d2d2c6">&nbsp;</td>
      <td height="20" bgcolor="#225628"><asp:HyperLink CssClass="izq" ID="lnkCRM" NavigateUrl="Login.aspx" runat="server">Home</asp:HyperLink></td>
      <td height="20">&nbsp;</td>
    </tr>
    
    <tr id="divlnkHome">
      <td height="20">&nbsp;</td>
      <td bgcolor="#d2d2c6">&nbsp;</td>
      <td height="20" bgcolor="#225628"><ASP:HyperLink CssClass="izq" id="lnkHome"
				 navigateurl="Main.aspx" runat="server">Home</ASP:HyperLink></td>
      <td height="20">&nbsp;</td>
    </tr>
    <tr id="divlblVentas" >
      <td height="20" style="HEIGHT: 21px">&nbsp;</td>
      <td width="4" bgcolor="#d2d2c6" style="HEIGHT: 21px">&nbsp;</td>
      <td height="20" bgcolor="#225628" class="titleBlanco" style="HEIGHT: 21px">
        <ASP:Label id="lblVentas" runat="server">Help Desk:</ASP:Label></td>
      <td height="20" style="HEIGHT: 21px">&nbsp;</td>
    </tr>
    <tr id="divlnkAtencionCallCenter" >
      <td height="20">&nbsp;</td>
      <td width="4" bgcolor="37703e">&nbsp;</td>
      <td height="20" bgcolor="#225628">&nbsp;&nbsp;&nbsp;&nbsp;<ASP:HyperLink id="lnkAtencionCallCenter" runat="server" cssclass="izq2" navigateurl="AtencionCallCenter.aspx">Solicitud Apoyo Técnico</ASP:HyperLink></td>
      <td height="20">&nbsp;</td>
    </tr>
    <tr id="divlnkHelpDesk" >
      <td height="20">&nbsp;</td>
      <td width="4" bgcolor="37703e">&nbsp;</td>
      <td height="20" bgcolor="#225628">&nbsp;&nbsp;&nbsp;&nbsp;<ASP:HyperLink
                       id="lnkHelpDesk" runat="server" cssclass="izq2" navigateurl="AsignacionApoyo.aspx">Asignación de Apoyo </ASP:HyperLink></td>
      <td height="20">&nbsp;</td>
    </tr>

    <tr id="divlblTecnicos" >
      <td height="20">&nbsp;</td>
      <td width="4" bgcolor="#d2d2c6">&nbsp;</td>
      <td height="20" bgcolor="#225628" class="titleBlanco">
        <ASP:Label id="lblTecnicos" runat="server">Técnicos:</ASP:Label></td>
      <td height="20">&nbsp;</td>
    </tr>

    <tr id="divlnkRevisarAsignaciones" >
      <td height="20">&nbsp;</td>
      <td width="4" bgcolor="37703e">&nbsp;</td>
      <td height="20" bgcolor="#225628">&nbsp;&nbsp;&nbsp;&nbsp;
        <ASP:HyperLink id="lnkAsignacionesTecnico" runat="server" cssclass="izq2" navigateurl="AsignacionesTecnico.aspx">Actualizar Asignaciones</ASP:HyperLink></td>
      <td height="20">&nbsp;</td>
    </tr>

    <tr id="divlblProductos" >
      <td height="20">&nbsp;</td>
      <td width="4" bgcolor="#d2d2c6">&nbsp;</td>
      <td height="20" bgcolor="#225628" class="titleBlanco">
        <ASP:Label id="lblConsultas" runat="server">Consultas:</ASP:Label></td>
      <td height="20">&nbsp;</td>
    </tr>
    <tr id="divlnkAddProducto" >
      <td height="20">&nbsp;</td>
      <td width="4" bgcolor="37703e">&nbsp;</td>
      <td height="20" bgcolor="#225628">&nbsp;&nbsp;&nbsp;&nbsp;
        <ASP:HyperLink id="lnkAddProducto" runat="server" cssclass="izq2" navigateurl="ConsultaCola.aspx">Cola de Solicitudes</ASP:HyperLink></td>
      <td height="20">&nbsp;</td>
    </tr>

    <tr id="divlnkConsultaMovimientos" >
      <td height="20">&nbsp;</td>
      <td width="4" bgcolor="37703e">&nbsp;</td>
      <td height="20" bgcolor="#225628">&nbsp;&nbsp;&nbsp;&nbsp;
        <ASP:HyperLink id="lnkConsultaMovimientos" runat="server" cssclass="izq2" navigateurl="ConsultaServicios.aspx">Consulta Servicios</ASP:HyperLink></td>
      <td height="20">&nbsp;</td>
    </tr>

    <tr id="divlblProveedores" >
      <td height="20">&nbsp;</td>
      <td width="4" bgcolor="#d2d2c6">&nbsp;</td>
      <td height="20" bgcolor="#225628" class="titleBlanco">
        <ASP:Label id="lblProveedores" runat="server">Opciones Especiales:</ASP:Label></td>
      <td height="20">&nbsp;</td>
    </tr>
    <tr id="divlnkAddPersonal" >
      <td height="20">&nbsp;</td>
      <td width="4" bgcolor="37703e">&nbsp;</td>
      <td height="20" bgcolor="#225628">&nbsp;&nbsp;&nbsp;&nbsp;
        <ASP:HyperLink id="lnkAddPersonal" runat="server" cssclass="izq2" navigateurl="Personal.aspx">Agregar Personal</ASP:HyperLink></td>
      <td height="20">&nbsp;</td>
    </tr>

    <tr id="divlnkSeguridad" >
      <td height="20">&nbsp;</td>
      <td width="4" bgcolor="#d2d2c6">&nbsp;</td>
      <td height="20" bgcolor="#225628" classname="izq"><ASP:HyperLink id="lnkSeguridad" class="izq"
       runat="server" navigateurl="Seguridad.aspx" cssclass="izq">Seguridad</ASP:HyperLink></td>
      <td height="20">&nbsp;</td>
    </tr>

    <tr id="divlnkChangePassword" >
      <td height="20">&nbsp;</td>
      <td width="4" bgcolor="#d2d2c6">&nbsp;</td>
      <td height="20" bgcolor="#225628" classname="izq"><ASP:HyperLink id="lnkChangePassword" class="izq"
                       runat="server" navigateurl="SeguridadCambiarClave.aspx" cssclass="izq">Cambiar Clave</ASP:HyperLink></td>
      <td height="20">&nbsp;</td>
    </tr>
    <tr id="divlnkLogout" >
      <td width="10" height="20" style="HEIGHT: 20px">&nbsp;</td>
      <td width="4" bgcolor="#d2d2c6" style="HEIGHT: 20px">&nbsp;</td>
      <td height="20" bgcolor="#225628" style="HEIGHT: 20px">
        <p>
          <ASP:HyperLink id="lnkLogout" runat="server" cssclass="izq2" navigateurl="LogOut.aspx">Salir del Sistema</ASP:HyperLink>
        </p></td>
      <td width="10" height="20" style="HEIGHT: 20px">&nbsp;</td>
    </tr>
    <tr style="background:green" runat="server" id="trTipoSitio" visible="false">
      <td width="10">&nbsp;</td>
      <td width="4">&nbsp;</td>
      <td>TESTING...</td>
      <td width="10">&nbsp;</td>
    </tr>
  </table>
  <script language="javascript" type="text/javascript">
      function ocultarEnlaces(b) {
          var cad = 'none';
          if (b) {
              cad = '';
          }

          document.getElementById('divlnkHome').style.display = cad;
          document.getElementById('divlblVentas').style.display = cad;
          document.getElementById('divlnkAtencionCallCenter').style.display = cad;
          document.getElementById('divlnkHelpDesk').style.display = cad;
          document.getElementById('divlnkRevisarAsignaciones').style.display = cad;
          document.getElementById('divlblTecnicos').style.display = cad;
          document.getElementById('divlblProductos').style.display = cad;
          document.getElementById('divlnkAddProducto').style.display = cad;
          document.getElementById('divlnkConsultaMovimientos').style.display = cad;

          document.getElementById('divlblProveedores').style.display = cad;
          document.getElementById('divlnkAddPersonal').style.display = cad;

          
          document.getElementById('divlnkSeguridad').style.display = cad;
          document.getElementById('divlnkChangePassword').style.display = cad;
          document.getElementById('divlnkLogout').style.display = cad;

      }
  </script>
<p></p>
