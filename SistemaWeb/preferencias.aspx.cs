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
    public partial class preferencias : System.Web.UI.Page
    {
        private Entidad Ent = new Entidad();
        private NegocioProductos NegProductos = new NegocioProductos();
        private NegocioPedidos NegPedidos = new NegocioPedidos();
        private DataTable Tabla1 = new DataTable();
        private DataTable Tabla2 = new DataTable();

        private int GrabarCabeceraPedido()
        {
            int Retorno = 0;
            try
            {
                Ent.Idpedido = 0;
                Ent.Idusuario = int.Parse(0 + Session["IdUsuario"].ToString());
                Ent.FechaReg = System.DateTime.Now;
                Ent.Formapago = "";
                Ent.Formaenvio = "";
                Ent.Direccion = "";
                Ent.Telefono = "";

                int filas;
                filas = NegPedidos.GrabarPedido(Ent);
                if (filas > 0)
                {
                    Retorno = filas;
                }
            }
            catch (Exception ex)
            {
                LblMensaje.Text = ex.Message;
            }
            return Retorno;
        }

        private Boolean GrabaDetallePedido(int IdPedido,int IdItem,double precio)
        {
            Boolean Retorno = false;
            try
            {
                Ent.Idpedido = IdPedido;
                Ent.Iditem = IdItem;
                Ent.Cantidad = 1;
                Ent.Precio = precio;
                Ent.Importe = 1 * precio;

                int filas;
                filas = NegPedidos.GrabarPedidoDetalle(Ent);
                if (filas > 0)
                {
                    Retorno = true;
                }
            }
            catch (Exception ex)
            {
                LblMensaje.Text = ex.Message;
            }
            return Retorno;
        }
        
        private void RellenarListaProductos()
        {
            try
            {
                Tabla1 = NegProductos.ListaProductosChk();
                GridProductos.DataSource = Tabla1;
                GridProductos.DataBind();
            }
            catch (Exception ex)
            {
                LblMensaje.Text = ex.Message;
            }
        }

        private void RellenarListaServicios()
        {
            try
            {
                Tabla2 = NegProductos.ListaServiciosChk();
                GridServicios.DataSource = Tabla2;
                GridServicios.DataBind();
            }
            catch (Exception ex)
            {
                LblMensaje.Text = ex.Message;
            }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RellenarListaProductos();
                RellenarListaServicios();
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

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            if (Session.Count == 0)
            {
                LblMensaje.Text = "Debe Acceder Cuenta con su Usuario y Contraseña";
                return;
            }
            try
            {
                List<Entidad> ListadoIdProducto = new List<Entidad>();
                List<Entidad> ListadoIdServicio = new List<Entidad>();
                int i;

                for (i = 0; i < GridProductos.Rows.Count; i++)
                {
                    Ent.Iditem = int.Parse(GridProductos.Rows[i].Cells[0].Text);
                    Ent.Precio = Double.Parse(GridProductos.Rows[i].Cells[2].Text);
                    Ent.Chk = (CheckBox)GridProductos.Rows[i].FindControl("ChkProducto");
                    if (Ent.Chk.Checked)
                    {
                        ListadoIdProducto.Add(Ent);
                    }
                }

                for (i = 0; i < GridServicios.Rows.Count; i++)
                {
                    Ent.Iditem = int.Parse(GridServicios.Rows[i].Cells[0].Text);
                    Ent.Precio = Double.Parse(GridServicios.Rows[i].Cells[2].Text);
                    Ent.Chk = (CheckBox)GridServicios.Rows[i].FindControl("ChkServicio");
                    if (Ent.Chk.Checked)
                    {
                        ListadoIdServicio.Add(Ent);
                    }
                }

                if (ListadoIdProducto.Count == 0 && ListadoIdServicio.Count == 0)
                {
                    LblMensaje.Text = "Seleccione uno o mas Productos ó Servicios para su pedido";
                }
                else
                {
                    Ent.Idpedido = GrabarCabeceraPedido();
                    if (Ent.Idpedido>0)
                    {
                        for (i = 0; i < ListadoIdProducto.Count; i++)
                        {
                            GrabaDetallePedido(Ent.Idpedido,ListadoIdProducto.ElementAt(i).Iditem, ListadoIdProducto.ElementAt(i).Precio);
                        }
                        for (i = 0; i < ListadoIdServicio.Count; i++)
                        {
                            GrabaDetallePedido(Ent.Idpedido,ListadoIdServicio.ElementAt(i).Iditem, ListadoIdServicio.ElementAt(i).Precio);
                        }
                    }
                    LblMensaje.Text = "Pedido Grabado";
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
        protected void BtnPreferencias_Click(object sender, EventArgs e)
        {
            Response.Redirect("preferencias.aspx");
        }

        protected void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("preferencias.aspx");
        }

        protected void BtnPrincipal_Click(object sender, EventArgs e)
        {

        }
    }
}