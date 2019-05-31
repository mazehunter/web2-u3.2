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
    public partial class productos : System.Web.UI.Page
    {
        private Entidad Ent = new Entidad();
        private NegocioProductos NegProductos = new NegocioProductos();
        private NegocioPedidos NegPedidos = new NegocioPedidos();

        private void RellenarLista()
        {
            try
            {
                DataTable Tabla = new DataTable();
                Tabla = NegProductos.ListaProductos();
                GridView1.DataSource = Tabla;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                LblMensaje.Text = ex.Message;
            }
        }

        private void RellenarComboCategorias()
        {
            try
            {
                DDLCategoria.DataSource = NegProductos.ListaCategorias();
                DDLCategoria.DataValueField = "IdCategoria";
                DDLCategoria.DataTextField = "Nombre";
                DDLCategoria.DataBind();
            }
            catch (Exception ex)
            {
                LblMensaje.Text = ex.Message;
            }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                RellenarComboCategorias();
                RellenarLista();
            }
        }

        protected void BtnNuevoProducto_Click(object sender, EventArgs e)
        {
            TxtIdItem.Text = "";
            TxtNombre.Text = "";
            TxtPrecio.Text = "";
            TxtIdItem.Focus();
        }

        protected void BtnGrabarProducto_Click(object sender, EventArgs e)
        {

            if (TxtNombre.Text == "")
            {
                LblMensaje.Text = "Ingrese Nombre";
                return;
            }
            if (TxtPrecio.Text.Trim() == "")
            {
                LblMensaje.Text = "Ingrese Precio";
                return;
            }
            if (DDLCategoria.Text == "")
            {
                LblMensaje.Text = "Seleccione Categoría";
                return;
            }

            try
            {
                Ent.Iditem = int.Parse(0 + TxtIdItem.Text);
                Ent.Nombre = TxtNombre.Text.Trim();
                Ent.Idcategoria = int.Parse(DDLCategoria.SelectedValue);
                Ent.Precio = Double.Parse(0 + TxtPrecio.Text);
                Ent.Tipodeitem = "P";
                int filas;
                filas = NegProductos.GrabarItem(Ent);
                if (filas > 0)
                {
                    RellenarLista();
                    BtnNuevoProducto_Click(sender, e);
                    LblMensaje.Text = "Producto Agregado";
                }
            }
            catch (Exception ex)
            {
                LblMensaje.Text = ex.Message;
            }
        }

        protected void BtnEliminarProducto_Click(object sender, EventArgs e)
        {
            if (TxtIdItem.Text == "")
            {
                LblMensaje.Text = "Seleccione Producto";
                return;
            }

            Ent.Iditem = int.Parse(0 + TxtIdItem.Text);
            try
            {
                int filas;
                filas = NegProductos.EliminarItem(Ent);
                if (filas > 0)
                {
                    RellenarLista();
                    BtnNuevoProducto_Click(sender, e);
                    LblMensaje.Text = "Producto Eliminado";
                }
            }
            catch (Exception ex)
            {
                LblMensaje.Text = ex.Message;
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            RellenarLista();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable Tabla = new DataTable();
                Ent.Iditem=int.Parse(GridView1.SelectedRow.Cells[1].Text);
                Tabla = NegPedidos.ListaItemXId(Ent);
                if (Tabla.Rows.Count > 0)
                {
                    TxtIdItem.Text = Tabla.Rows[0]["IdItem"].ToString();
                    TxtNombre.Text = Tabla.Rows[0]["Nombre"].ToString();
                    TxtPrecio.Text = Tabla.Rows[0]["Precio"].ToString();
                    DDLCategoria.SelectedValue = Tabla.Rows[0]["IdCategoria"].ToString();
                }
            }
            catch (Exception ex)
            {
                LblMensaje.Text = ex.Message;
            }
        }

        protected void BtnRegistrarse_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        protected void BtnAccederCuenta_Click(object sender, EventArgs e)
        {
            Response.Redirect("accedercuenta.aspx");
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

        protected void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("productos.aspx");
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