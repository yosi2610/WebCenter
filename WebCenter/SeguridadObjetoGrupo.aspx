<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeguridadObjetoGrupo.aspx.cs" Inherits="WebCenter.SeguridadObjetoGrupo" %>

<%@ Register TagPrefix="MsgBox" Src="UCMessageBox.ascx" TagName="UCMessageBox" %>
<%@ Register TagPrefix="uc1" TagName="UCNavigation" Src="UCNavigation.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">

<html>
<head>
    <title>| Sistema Call Center | Asignar Objeto a Grupo|</title>
	
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
        .auto-style3 {
            height: 43px;
        }
                                                                              .auto-style4 {
                                                                                  width: 10px;
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
	  <td height="20" colspan="3" valign="top"  >&nbsp; <h2> Asignar Objeto a Grupo</h2></td>
    </tr>
    <tr>
      <td height="350" valign="top" class="auto-style4">&nbsp;</td>
      <td width="770" valign="top" colspan="3">
      <!-- Contenido Aqui -->
          <table>


                <tr>
                    <td>
                        Grupo
                    </td>
                    <td>
                          <asp:DropDownList ID="ddlGrupo" runat="server" AutoPostBack = "true"  Width="520px" OnSelectedIndexChanged="ddlGrupo_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                    </tr>
                <tr>
                    <td>
                        Objeto
                    </td>
                    <td>
                          <asp:DropDownList ID="ddlObjeto" runat="server" AutoPostBack = "true"   Width="520px" > </asp:DropDownList>
                    </td>
                    </tr>
                  <tr>
                      <td></td>
                      <td class="auto-style3" align ="center" >
                          <asp:Button Text="Asignar Objeto" runat="server" ID ="btnAsignar"  CssClass ="boton_formulario" OnClick="btnAsignar_Click" />
                      </td>
                  </tr>
                    
          </table>

          <h2>Objetos asignados</h2>
          
          <asp:GridView ID="gridDetalle" runat="server" CssClass="subtitulo" EmptyDataText="No existen Registros" 
              GridLines="Horizontal" AutoGenerateColumns="False" OnRowCommand="gridDetalle_RowCommand" >
                <HeaderStyle CssClass ="registroTitulo" Font-Size="10px" />
                <AlternatingRowStyle CssClass ="registroNormal" Font-Size="10px" />
                  <RowStyle CssClass ="registroAlternado" Font-Size="10px" />
              <Columns>
                  <asp:TemplateField HeaderText="Nombre de Grupo" HeaderStyle-Width="200">
                      <ItemTemplate>
                          <asp:Label runat="server" ID="lblNombreGrupo" Text='<%# Eval("NombreGrupo") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Descripción Grupo" HeaderStyle-Width="200">
                      <ItemTemplate>
                          <asp:Label runat="server" ID="lblDesGrupo" Text='<%# Eval("DescripcionGrupo") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Nombre Objeto" HeaderStyle-Width="200px">
                      <ItemTemplate>
                          <asp:Label runat="server" ID="lblNombreObjeto" Text='<%# Eval("NombreObjeto") %>'></asp:Label>
                      </ItemTemplate>
                  </asp:TemplateField>

                   <asp:TemplateField HeaderText="Acciones" HeaderStyle-Width="100px">
                      <ItemTemplate>
                          <asp:ImageButton runat="server" ID="btnEliminar" AlternateText="Eliminar Detalle" OnClientClick="return Confirmacion();" ToolTip="Eliminar Detalle" CssClass="cBotones" ImageUrl="~/Images/eliminar.gif"  CommandName="EliminarDetalle" CommandArgument='<%# Eval("SeguridadObjetoAccesoID") %>'/>
                      </ItemTemplate>
                  </asp:TemplateField>
              </Columns>
          </asp:GridView>



      </td>

    </tr>
    <tr>
      <td width="200" height="30" bgcolor="#d2d2c6">&nbsp;</td>
      <td bgcolor="#d2d2c6" class="auto-style4">&nbsp;</td>
      <td width="770" bgcolor="#d2d2c6">&nbsp;</td>
      <td width="20" bgcolor="#d2d2c6">&nbsp;</td>
    </tr>
  </table>
   
  
    </form>
</body>
</html>
