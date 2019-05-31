<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pedidosnuevo.aspx.cs" Inherits="SistemaWeb.pedidosnuevo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PEDIDO NUEVO</title>
    <link rel="icon" href="css/imagenes/gym-icon.ico"/>
    <style>
        @import url('https://fonts.googleapis.com/css?family=Russo+One');
    </style>
    <link rel="stylesheet" type="text/css" href="css/estilo.css">
    <style type="text/css">
        .style1
        {
            font-weight: bold;
            width: 640px;
        }
        .style2
        {
            font-weight: bold;
            color: #0066CC;
            width: 140px;
        }
        .style3
        {
            color: #0066CC;
            width: 140px;
            height: 23px;
        }
        .style4
        {
            width: 139px;
            height: 108px;
        }
        .style5
        {
            text-align: left;
        }
        .style9
        {}
        .style10
        {
        }
        .style13
        {
            color: #0066CC;
            height: 108px;
        }
        .style15
        {
            width: 74px;
        }
        .style17
        {
            width: 140px;
        }
        .style18
        {
            text-align: left;
            width: 80px;
        }
        .style19
        {
            width: 80px;
        }
        .style20
        {
            height: 23px;
        }
        .style21
        {
            text-align: left;
            height: 23px;
        }
    </style>
</head>
<body id="principal">
      <form id="form1" runat="server">
    <div>
    
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </ContentTemplate>
        </asp:UpdatePanel>
    <br />

            <table class="style1">
            <tr class="ban">
                <td>
                    <img src="css/imagenes/gym-icon.ico" style="height: 104px; width: 90px"/></td>
                <td class="title" colspan="6" align="center" style="font-size:95px">
                    Sports Store</td>
                
            </tr>
            <tr align="center" style="background-color:black">
                <td class="style9" bgcolor="Black">
                    <asp:Button ID="BtnPrincipal" runat="server" BackColor="Black" 
                        Font-Bold="True" ForeColor="#FFFFCC" onclick="BtnPrincipal_Click"
                        Text="Inicio" Width="140px" />
                </td>
                <td class="style9" bgcolor="Black">
                    <asp:Button ID="BtnRegistrarse" runat="server" BackColor="Black" 
                        Font-Bold="True" ForeColor="#FFFFCC" onclick="BtnRegistrarse_Click" 
                        Text="Registrarse" Width="140px" />
                </td>
                <td class="style17" bgcolor="Black">
                    <asp:Button ID="BtnAccederCuenta" runat="server" BackColor="Black" 
                        Font-Bold="True" ForeColor="#FFFFCC" Text="Acceder Cuenta" Width="140px" 
                        onclick="BtnAccederCuenta_Click" />
                </td>
                <td class="style9" bgcolor="Black" colspan="2">
                    <asp:Button ID="BtnProductos" runat="server" BackColor="Black" Font-Bold="True" 
                        ForeColor="#FFFFCC" Text="Productos" Width="173px" 
                        onclick="BtnProductos_Click" />
                </td>
                <td class="style9" bgcolor="Black" colspan="2">
                    <asp:Button ID="BtnServicios" runat="server" BackColor="Black" Font-Bold="True" 
                        ForeColor="#FFFFCC" Text="Servicios" Width="140px" 
                        onclick="BtnServicios_Click" />
                </td>
                <td class="style17" bgcolor="Black">
                    <asp:Button ID="BtnPedidos" runat="server" BackColor="Black" Font-Bold="True" 
                        ForeColor="#FFFFCC" Text="Pedidos" Width="140px" 
                        onclick="BtnPedidos_Click" />
                </td>
                <td class="style17" bgcolor="Black">
                    <asp:Button ID="BtnPreferencias" runat="server" BackColor="Black" Font-Bold="True" 
                        ForeColor="#FFFFCC" Text="Preferencias" Width="140px" 
                        onclick="BtnPreferencias_Click" />
                </td>
            </tr>
            <tr>
                <td class="style17">
                    <asp:Label ID="LblSesion" runat="server" Font-Size="10pt" 
                        style="color: #0066CC; font-weight: 700"></asp:Label>
                </td>
                <td class="style15" colspan="6">
                    <asp:Label ID="LblMensaje" runat="server" Font-Size="10pt" 
                        style="color: #0066CC"></asp:Label>
                </td>
                <td class="style15">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9">
                    <asp:Button ID="BtnCerrarSesion" runat="server" BackColor="Black" 
                        Font-Bold="True" ForeColor="#FFFFCC" onclick="BtnCerrarSesion_Click" 
                        Text="Cerrar Sesión" Width="100px"   
                        
                        OnClientClick="javascript:if (!confirm('¿Desea Cerrar Sesión?')) return false;" />
                    <br />
                </td>
                <td class="style2">
                    Cabecera del Pedido</td>
                <td class="style5" colspan="5">
                    <asp:Button ID="BtnNuevoPedido" runat="server" BackColor="Black" 
                        Font-Bold="True" ForeColor="#FFFFCC" onclick="BtnNuevoPedido_Click" 
                        Text="Nuevo Pedido" Width="140px"   
                        
                        />
                    &nbsp;<asp:Button ID="BtnGrabarPedido" runat="server" BackColor="Black" 
                        Font-Bold="True" ForeColor="#FFFFCC" onclick="BtnGrabarPedido_Click" 
                        Text="Grabar Pedido" Width="140px"   
                        
                        />
                </td>
                <td class="style5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td class="style17">
                    Id Pedido</td>
                <td class="style18">
                    <asp:TextBox ID="TxtIdPedido" runat="server" MaxLength="50" Width="80px" 
                        BackColor="#FFFFCC" ReadOnly="True"></asp:TextBox>
                </td>
                <td class="style5" colspan="4">
                    </td>
                <td class="style5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td class="style17">
                    Fecha Pedido</td>
                <td class="style18">
                    <asp:TextBox ID="TxtFechaReg" runat="server" MaxLength="10" Width="80px" 
                        style="text-align: left"></asp:TextBox>
                </td>
                <td class="style5" colspan="4">
                    </td>
                <td class="style5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td class="style17">
                    Forma de Pago</td>
                <td class="style10" colspan="5">
                    <asp:TextBox ID="TxtFormaPago" runat="server" MaxLength="50" Width="300px"></asp:TextBox>
                </td>
                <td class="style10">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td class="style17">
                    Forma de Envio</td>
                <td class="style10" colspan="5">
                    <asp:TextBox ID="TxtFormaEnvio" runat="server" MaxLength="50" Width="300px"></asp:TextBox>
                </td>
                <td class="style10">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td class="style17">
                    Dirección de Envio</td>
                <td class="style10" colspan="5">
                    <asp:TextBox ID="TxtDireccion" runat="server" MaxLength="200" Width="300px"></asp:TextBox>
                </td>
                <td class="style10">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td class="style17">
                    Teléfono</td>
                <td class="style5" colspan="5">
                    <asp:TextBox ID="TxtTelefono" runat="server" MaxLength="20" Width="140px"></asp:TextBox>
                </td>
                <td class="style5">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style20">
                    </td>
                <td class="style3">
                    Detalle del Pedido</td>
                <td class="style21" colspan="2">
                    </td>
                <td class="style20" colspan="3">
                    </td>
                <td class="style20">
                    </td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td class="style17">
                    Item</td>
                <td class="style10" colspan="5">
                    <asp:DropDownList ID="DDLItem" runat="server" Width="350px" AutoPostBack="True" 
                        onselectedindexchanged="DDLItem_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td class="style10">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td class="style17" rowspan="2">
                    &nbsp;</td>
                <td class="style19" rowspan="2">
                    Cantidad<br />
                    <asp:TextBox ID="TxtCantidad" runat="server" MaxLength="10" Width="80px" 
                        Height="22px" ontextchanged="TxtCantidad_TextChanged" AutoPostBack="True"></asp:TextBox>
                </td>
                <td class="style19" rowspan="2">
                    Precio<br />
                    <asp:TextBox ID="TxtPrecio" runat="server" MaxLength="10" Width="80px" 
                        Height="22px" ontextchanged="TxtPrecio_TextChanged" AutoPostBack="True"></asp:TextBox>
                </td>
                <td class="style17" rowspan="2">
                    Importe<br />
                    <asp:TextBox ID="TxtImporte" runat="server" MaxLength="10" Width="80px" 
                        Height="22px" BackColor="#FFFFCC" 
                        ReadOnly="True"></asp:TextBox>
                </td>
                <td class="style10" colspan="2" rowspan="2">
                    <br />
                </td>
                <td class="style10" rowspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td class="style10" colspan="7" rowspan="5">
                    <asp:GridView ID="GridView1" runat="server" BackColor="White" 
                        BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" 
                        ForeColor="Black" GridLines="Vertical" Width="737px">
                        <AlternatingRowStyle BackColor="#CCCCCC" />
                        <FooterStyle BackColor="#CCCCCC" />
                        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#808080" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#383838" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
            </tr>
            </table>
        <br />
    

    </div>
    </form>
    <footer >
		<b>SIGUENOS EN NUESTRAS REDES SOCIALES:</b>
		<a class="imfo" href="https://www.instagram.com/?hl=es-la" target="_blank"><img src="css/imagenes/instagram.png" height="25px" width="25px"></a>
		<a class="imfo" href="https://www.facebook.com/" target="_blank"><img src="css/imagenes/facebook.png" height="25px" width="25px"></a>
		<a class="imfo" href="https://twitter.com/?lang=es" target="_blank"><img src="css/imagenes/twitter.png" height="25px" width="25px" ></a>
	</footer>
</body>
</html>
