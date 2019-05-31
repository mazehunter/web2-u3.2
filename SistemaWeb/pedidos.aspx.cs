using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using SistemaWebNegocio;
using SistemaWebEntidades;
using System.Data;

namespace SistemaWeb
{
    public partial class pedidos : System.Web.UI.Page
    {
        private Entidad Ent = new Entidad();
        private NegocioPedidos NegPedidos = new NegocioPedidos();

        private void RellenarPedidosXUsuario()
        {
            try
            {
                if (Session.Count > 0)
                {
                    DataTable Tabla = new DataTable();
                    Ent.Idusuario = int.Parse(Session["IdUsuario"].ToString());
                    Tabla = NegPedidos.ListaPedidoXUsuario(Ent);
                    GridView1.DataSource = Tabla;
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                LblMensaje.Text = ex.Message;
            }
        }

        private int PedidoComprado()
        {
            int Retorno = 0;
            DataTable Tabla = new DataTable();
            try
            {           
                Ent.Idpedido = int.Parse(GridView1.SelectedRow.Cells[1].Text);
                Tabla = NegPedidos.ListaPedidoXIdPedido(Ent);
                if (Tabla.Rows.Count > 0)
                {
                    if (Tabla.Rows[0]["Estado"].ToString().ToUpper() == "COMPRADO")
                    {
                        Retorno = Tabla.Rows.Count;
                    }
                }
            }
            catch (Exception ex)
            {
                LblMensaje.Text = ex.Message;
            }
            return Retorno;
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                RellenarPedidosXUsuario();
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

        protected void BtnPedidos_Click(object sender, EventArgs e)
        {
            Response.Redirect("pedidos.aspx");
        }

        protected void BtnNuevoPedido_Click(object sender, EventArgs e)
        {
            Response.Redirect("pedidosnuevo.aspx");
        }

        protected void BtnProductos_Click(object sender, EventArgs e)
        {
            Response.Redirect("productos.aspx");
        }

        protected void BtnServicios_Click(object sender, EventArgs e)
        {
            Response.Redirect("servicios.aspx");
        }

        protected void BtnRegistrarse_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        protected void BtnAccederCuenta_Click(object sender, EventArgs e)
        {
            Response.Redirect("accedercuenta.aspx");
        }

        protected void BtnEliminarPedido_Click(object sender, EventArgs e)
        {
            int indice = GridView1.SelectedIndex;
            if (indice >= 0)
            {
                int Pedi=PedidoComprado();
                if (Pedi > 0)
                {
                    LblMensaje.Text = "El Estado del Pedido es Comprado, No puede realizar esta operación";
                    return;
                }

                Ent.Idpedido =int.Parse(GridView1.SelectedRow.Cells[1].Text);
                int filas=NegPedidos.EliminarPedido(Ent);
                if (filas > 0)
                {
                    RellenarPedidosXUsuario();
                    LblMensaje.Text = "Pedido Eliminado";
                }
            }
            else
            {
                LblMensaje.Text = "Seleccione un Pedido";
            }
        }

        protected void BtnComprar_Click(object sender, EventArgs e)
        {
            int indice = GridView1.SelectedIndex;
            if (indice >= 0)
            {
                Ent.Idpedido = int.Parse(GridView1.SelectedRow.Cells[1].Text);
                int Pedi = PedidoComprado();
                if (Pedi > 0)
                {
                    LblMensaje.Text = "El Estado del Pedido es Comprado, No puede realizar esta operación";
                    return;
                }
                Ent.Idpedido = int.Parse(GridView1.SelectedRow.Cells[1].Text);
                int filas = NegPedidos.ComprarPedido(Ent);
                if (filas > 0)
                {
                    RellenarPedidosXUsuario();
                    LblMensaje.Text = "Pedido Comprado";
                }
            }
            else
            {
                LblMensaje.Text = "Seleccione un Pedido";
            }
        }

        protected void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("pedidos.aspx");
        }

        protected void BtnPreferencias_Click(object sender, EventArgs e)
        {
            Response.Redirect("preferencias.aspx");
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='hand';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(GridView1, "Select$" + e.Row.RowIndex);
            }
        }

        protected void BtnPrincipal_Click(object sender, EventArgs e)
        {

        }
    }
}