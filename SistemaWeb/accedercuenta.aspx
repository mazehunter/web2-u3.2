<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="accedercuenta.aspx.cs" Inherits="SistemaWeb.accedercuenta" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LOGIN</title>
    <link rel="icon" href="css/imagenes/gym-icon.ico"/>
    <style>
        @import url('https://fonts.googleapis.com/css?family=Russo+One');
    </style>
    <link rel="stylesheet" type="text/css" href="css/estilo.css">
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
                <td class="style4" colspan="6" align="center" style="font-size:95px">
                    Sports Store</td>
                
            </tr>
            <tr>
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
                <td class="style10" bgcolor="Black">
                    <asp:Button ID="BtnAccederCuenta" runat="server" BackColor="Black" 
                        Font-Bold="True" ForeColor="#FFFFCC" Text="Acceder Cuenta" Width="140px" 
                        onclick="BtnAccederCuenta_Click" />
                </td>
                <td class="style11" bgcolor="Black">
                    <asp:Button ID="BtnProductos" runat="server" BackColor="Black" Font-Bold="True" 
                        ForeColor="#FFFFCC" Text="Productos" Width="140px" 
                        onclick="BtnProductos_Click" />
                </td>
                <td class="style13" bgcolor="Black">
                    <asp:Button ID="BtnServicios" runat="server" BackColor="Black" Font-Bold="True" 
                        ForeColor="#FFFFCC" Text="Servicios" Width="140px" 
                        onclick="BtnServicios_Click" />
                </td>
                <td class="style2" bgcolor="Black">
                    <asp:Button ID="BtnPedidos" runat="server" BackColor="Black" Font-Bold="True" 
                        ForeColor="#FFFFCC" Text="Pedidos" Width="140px" 
                        onclick="BtnPedidos_Click" />
                </td>
                <td class="style2" bgcolor="Black">
                    <asp:Button ID="BtnPreferencias" runat="server" BackColor="Black" Font-Bold="True" 
                        ForeColor="#FFFFCC" Text="Preferencias" Width="140px" 
                        onclick="BtnPreferencias_Click" />
                </td>
            </tr>
            <tr>
                <td class="style14">
                    <asp:Label ID="LblSesion" runat="server" Font-Size="10pt" 
                        style="color: #0066CC; font-weight: 700"></asp:Label>
                </td>
                <td class="style15" colspan="4">
                    <asp:Label ID="LblMensaje" runat="server" Font-Size="10pt" 
                        style="color: #0066CC; font-weight: 700"></asp:Label>
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
                </td>
                <td class="style10">
                    Nombre Usuario</td>
                <td class="style11">
                    <asp:TextBox ID="TxtLogin" runat="server" MaxLength="30" Width="140px"></asp:TextBox>
                </td>
                <td class="style13">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td class="style10">
                    Contraseña</td>
                <td class="style11">
                    <asp:TextBox ID="TxtPassword" runat="server" MaxLength="15" TextMode="Password" 
                        Width="140px"></asp:TextBox>
                </td>
                <td class="style13">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td class="style10" colspan="4">
                    &nbsp;</td>
                <td class="style10">
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style9">
                    &nbsp;</td>
                <td class="style10">
                    &nbsp;</td>
                <td class="style11">
                    <asp:Button ID="BtnIngresar" runat="server" BackColor="Black" 
                        Font-Bold="True" ForeColor="#FFFFCC" onclick="BtnIngresar_Click" 
                        Text="Ingresar" Width="140px"   
                        
                        />
                </td>
                <td class="style13">
                    &nbsp;</td>
                <td class="style2">
                    &nbsp;</td>
                <td class="style2">
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
