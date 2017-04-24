<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsignarEstatus.aspx.cs" Inherits="WebCenter.AsignarEstatus" %>

<%@ Register TagPrefix="MsgBox" Src="UCMessageBox.ascx" TagName="UCMessageBox" %>
<%@ Register TagPrefix="uc1" TagName="UCNavigation" Src="UCNavigation.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">

<html>
<head>
    <title>| Sistema Call Center | Asignar Estatus|</title>
	
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
      <td width="200" rowspan="2" align="left" valign="top" bgcolor="#37703e"><uc1:UCNavigation id="UserControl2" runat="server"></uc1:UCNavigation></td>
	  <td height="20" colspan="3" valign="top"  >&nbsp; <h2> Asignar Estatus al Servicio</h2></td>
    </tr>
    <tr>
      <td width="10" height="350" valign="top">&nbsp;</td>
      <td width="770" valign="top" colspan="3">
      <!-- Contenido Aqui -->
          <table>

            <tr>
                <td class="auto-style3" align ="center" >
                    <asp:Button Text="Asignar Estatus" runat="server" ID ="btnAsignar"  CssClass ="boton_formulario" OnClick="btnAsignar_Click"/>
                    <asp:Button Text="<< Regresar" runat="server" ID ="btnRegresar"  CssClass ="boton_formulario" OnClick="btnRegresar_Click" />
                </td>
            </tr>

          </table>

          <h2>Asignar Estatus al Servicio</h2>
          
          <asp:GridView ID="gridDetalle" runat="server" CssClass="subtitulo" EmptyDataText="No existen Registros" 
              GridLines="Horizontal" AutoGenerateColumns="False" OnRowDataBound="gridDetalle_RowDataBound" >
                <HeaderStyle CssClass ="registroTitulo" Font-Size="10px" />
                <AlternatingRowStyle CssClass ="registroNormal" Font-Size="10px" />
                  <RowStyle CssClass ="registroAlternado" Font-Size="10px" />
              <Columns>
                  <asp:TemplateField HeaderText="Fecha Asignación" HeaderStyle-Width="100    ">
                      <ItemTemplate>
                          <asp:Label runat="server" ID="lblFechaAsig" Text='<%# Eval("FechaAsignacionTecnico") %>'></asp:Label>
                      </ItemTemplate>

<HeaderStyle Width="100px"></HeaderStyle>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Solicitante" HeaderStyle-Width="200px">
                      <ItemTemplate>
                          <asp:Label runat="server" ID="lblSolicitante" Text='<%# Eval("NombrePersonal") %>'></asp:Label>
                      </ItemTemplate>

<HeaderStyle Width="200px"></HeaderStyle>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Descripcion Servicio" HeaderStyle-Width="200px">
                      <ItemTemplate>
                          <asp:Label runat="server" ID="lblDescripcion" Text='<%# Eval("DescripcionSolicitudServicio") %>'></asp:Label>
                      </ItemTemplate>

<HeaderStyle Width="200px"></HeaderStyle>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Gerencia" HeaderStyle-Width="200px">
                      <ItemTemplate>
                          <asp:Label runat="server" ID="lblGerencia" Text='<%# Eval("NombreGerencia") %>'></asp:Label>
                      </ItemTemplate>

<HeaderStyle Width="200px"></HeaderStyle>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Extensión" HeaderStyle-Width="200px">
                      <ItemTemplate>
                          <asp:Label runat="server" ID="lblExtension" Text='<%# Eval("NumeroExtension") %>'></asp:Label>
                      </ItemTemplate>

<HeaderStyle Width="200px"></HeaderStyle>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Técnico Asignado" HeaderStyle-Width="100px">
                      <ItemTemplate>
                          <asp:Label runat="server" ID="lblTecnico" ForeColor ="Red" Text='<%# Eval("Tecnico") %>' ></asp:Label>
                      </ItemTemplate>

<HeaderStyle Width="100px"></HeaderStyle>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="CodT" HeaderStyle-Width="0" Visible="false">
                      <ItemTemplate>
                          <asp:TextBox runat="server" ID="txtCodTecnico" Visible ="false"   Width="0" ForeColor ="Red" Text='<%# Eval("CodTecnico") %>' ></asp:TextBox>
                      </ItemTemplate>

<HeaderStyle Width="0px"></HeaderStyle>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Observaciones Técnico" HeaderStyle-Width="100px">
                      <ItemTemplate>
                          <asp:Label runat="server" ID="txtObs" ForeColor ="Red" Text='<%# Eval("ObservacionTecnico") %>' ></asp:Label>
                      </ItemTemplate>

<HeaderStyle Width="100px"></HeaderStyle>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Estatus" HeaderStyle-Width="100px">
                      <ItemTemplate>
                          <asp:Label runat="server" ID="lblEstatus" ForeColor ="Red" Text='<%# Eval("NombreEstatusSolicitudServicio") %>'></asp:Label>
                      </ItemTemplate>

<HeaderStyle Width="100px"></HeaderStyle>
                  </asp:TemplateField>
                  <asp:TemplateField HeaderText="Asignar Estatus" HeaderStyle-Width="180">
<%--                      <ItemTemplate>
                          <asp:DropDownList runat="server" ID="ddlEstatus" 
                              DataTextField ="NombreEstatusSolicitudServicio" 
                              DataValueField ="EstatusSolicitudServicioID"
                              Width="180px">
                          </asp:DropDownList>
                      </ItemTemplate>--%>

                      <ItemTemplate>
                          <asp:DropDownList runat="server" ID="ddlEstatus"
                                DataSourceID="SqlDataSource4" 
                                DataTextField ="NombreEstatusSolicitudServicio"
                                DataValueField ="EstatusSolicitudServicioID"
                                SelectedValue ='<%# Bind("EstatusSolicitudServicioID") %>'
                                Width="180px">
                          </asp:DropDownList>
                        <asp:SqlDataSource 
                            ID="SqlDataSource4" 
                            runat="server" ConnectionString="<%$ ConnectionStrings:CallCenterConnectionString %>" 
                            SelectCommand="SELECT *  FROM [EstatusSolicitudServicio]"></asp:SqlDataSource>
                      </ItemTemplate>
                    <HeaderStyle Width="180px"></HeaderStyle>
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
