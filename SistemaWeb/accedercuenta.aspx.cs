using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using SistemaWebNegocio;
using SistemaWebEntidades;

namespace SistemaWeb
{
    public partial class accedercuenta : System.Web.UI.Page
    {
        private NegocioUsuario NegUsuario = new NegocioUsuario();
        private Entidad EntUsuario = new Entidad();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                if (Session.Count > 0)
                {
                    BtnCerrarSesion.Visible = true;
                    LblSesion.Text = "Usuario: " + Session["Login"].ToString();
                }
                else
                {
                    BtnCerrarSesion.Visible = false;
                }
            }
        }
        
        protected void BtnIngresar_Click(object sender, EventArgs e)
        {
            if (TxtLogin.Text.Trim() == "")
            {
                LblMensaje.Text = "Ingrese Nombre de Usuario";
                TxtLogin.Focus();
                return;
            }
            if (TxtPassword.Text.Trim() == "")
            {
                LblMensaje.Text = "Ingrese Contraseña";
                TxtPassword.Focus();
                return;
            }
            EntUsuario.Login = TxtLogin.Text.Trim();
            EntUsuario.Password = TxtPassword.Text.Trim();
            DataTable Tabla = new DataTable();
            Tabla = NegUsuario.Sesion(EntUsuario);
            if (Tabla.Rows.Count > 0)
            {
                Session.RemoveAll();
                Session.Add("IdUsuario", Tabla.Rows[0]["IdUsuario"].ToString());
                Session.Add("Login", Tabla.Rows[0]["Login"].ToString());
                Session.Add("Password", Tabla.Rows[0]["Password"].ToString());
                Session.Add("IdPerfil", Tabla.Rows[0]["IdPerfil"].ToString());
                LblMensaje.Text = "Bienvenido";
                LblSesion.Text = "Usuario: " + Session["Login"].ToString();
                TxtLogin.Text = "";
                TxtPassword.Text = "";
                BtnCerrarSesion.Visible = true;
            }
            else
            {
                LblMensaje.Text = "Incorrecto";
            }
        }
        

        protected void BtnRegistrarse_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        protected void BtnProductos_Click(object sender, EventArgs e)
        {
            Response.Redirect("productos.aspx");
        }

        protected void BtnServicios_Click(object sender, EventArgs e)
        {
            Response.Redirect("servicios.aspx");
        }

        protected void BtnPedidos_Click(object sender, EventArgs e)
        {
            Response.Redirect("pedidos.aspx");
        }

        protected void BtnAccederCuenta_Click(object sender, EventArgs e)
        {
            Response.Redirect("accedercuenta.aspx");
        }

        protected void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("accedercuenta.aspx");
        }

        protected void BtnPreferencias_Click(object sender, EventArgs e)
        {
            Response.Redirect("preferencias.aspx");
        }

        protected void BtnPrincipal_Click(object sender, EventArgs e)
        {

        }
    }
}