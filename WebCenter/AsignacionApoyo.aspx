<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsignacionApoyo.aspx.cs" Inherits="WebCenter.AsignacionApoyo" %>

<%@ Register TagPrefix="MsgBox" Src="UCMessageBox.ascx" TagName="UCMessageBox" %>
<%@ Register TagPrefix="uc1" TagName="UCNavigation" Src="UCNavigation.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">

<html>
<head>
    <title>| Sistema Call Center | Asignación de Apoyo Técnico|</title>
	
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

            return confirm("¿Realmente desea eliminar este servicio?");
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
	  <td height="20" colspan="3" valign="top"  >&nbsp; <h2></h2></td>
    </tr>
    <tr>
      <td width="10" height="350" valign="top">&nbsp;</td>
      <td width="770" valign="top" colspan="3">
      <!-- Contenido Aqui -->


          <h2>Asignación de Apoyo Técnico</h2>
          
          <asp:GridView ID="gridDetalle" runat="server" CssClass="subtitulo" EmptyDataText="No existen Registros" 
              GridLines="Horizontal" AutoGenerateColumns="False" OnRowCommand="gridDetalle_RowCommand" >
                <HeaderStyle CssClass ="registroTitulo" Font-Size="10px" />
                <AlternatingRowStyle CssClass ="registroNormal" Font-Size="10px" />
                  <RowStyle CssClass ="registroAlternado" Font-Size="10px" />
              <Columns>
                  <asp:TemplateField HeaderText="Fecha Solicitud" HeaderStyle-Width="60">
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

                  <asp:TemplateField HeaderText="Descripcion Servicio" HeaderStyle-Width="150px">
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
                          <asp:Label runat="server" ID="lblEstatus" Text='<%# Eval("EstatusTecnico") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Fecha Estatus" HeaderStyle-Width="100px">
                      <ItemTemplate>
                          <asp:Label runat="server" ID="lblFechaAsignacion" Text='<%# Eval("FechaFinalizacionTecnico") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                   <asp:TemplateField HeaderText="Acciones" HeaderStyle-Width="100px">
                      <ItemTemplate>
                          <asp:ImageButton runat="server" ID="btnAsignar" AlternateText="Asignar Técnico"  ToolTip="Asignar Técnico" CssClass="cBotones" ImageUrl="~/Images/asignar_tecnico_icono.png"  CommandName="AsignarTecnico" CommandArgument='<%# Eval("SolicitudServicioID") %>'/>
                          <asp:ImageButton runat="server" ID="btnEstatus" AlternateText="Asignar Estatus" ToolTip="Asignar Estatus" CssClass="cBotones" ImageUrl="~/Images/asignar_estatus_icono.png"  CommandName="AsignarEstatus" CommandArgument='<%# Eval("SolicitudServicioID") %>'/>
                          <asp:ImageButton runat="server" ID="btnEliminar" AlternateText="Eliminar Solicitud" OnClientClick="return Confirmacion();" ToolTip="Eliminar Solicitud" CssClass="cBotones" ImageUrl="~/Images/eliminar.gif"  CommandName="EliminarSolicitud" CommandArgument='<%# Eval("SolicitudServicioID") %>'/>
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
