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
    public partial class pedidosnuevo : System.Web.UI.Page
    {
        private Entidad Ent = new Entidad();
        private NegocioPedidos NegPedidos = new NegocioPedidos();

        private void PrecioItem()
        {
            try
            {
                DataTable Tabla = new DataTable();
                Ent.Iditem = int.Parse(DDLItem.SelectedValue);
                Tabla = NegPedidos.ListaItemXId(Ent);
                if (Tabla.Rows.Count > 0)
                {
                    TxtPrecio.Text =Tabla.Rows[0]["Precio"].ToString();
                }
            }
            catch (Exception ex)
            {
                LblMensaje.Text = ex.Message;
            }
        }

        private void GrabarCabecera()
        {
            if (Session.Count == 0)
            {
                LblMensaje.Text = "Debe Acceder Cuenta con su Usuario y Contraseña";
                return;
            }
            if (TxtFechaReg.Text.Trim() == "")
            {
                LblMensaje.Text = "Ingrese Fecha de Pedido";
                TxtFechaReg.Focus();
                return;
            }
            if (TxtFormaPago.Text.Trim() == "")
            {
                LblMensaje.Text = "Ingrese Forma de Pago";
                TxtFormaPago.Focus();
                return;
            }
            if (TxtFormaEnvio.Text.Trim() == "")
            {
                LblMensaje.Text = "Ingrese Forma de Envio";
                TxtFormaEnvio.Focus();
                return;
            }
            if (TxtDireccion.Text.Trim() == "")
            {
                LblMensaje.Text = "Ingrese Dirección";
                TxtDireccion.Focus();
                return;
            }
            if (TxtTelefono.Text.Trim() == "")
            {
                LblMensaje.Text = "Ingrese Teléfono";
                TxtTelefono.Focus();
                return;
            }
            try
            {
                Ent.Idpedido = int.Parse(0 + TxtIdPedido.Text);
                Ent.Idusuario = int.Parse(0 + Session["IdUsuario"].ToString());
                Ent.FechaReg = Convert.ToDateTime(TxtFechaReg.Text);
                Ent.Formapago = TxtFormaPago.Text.Trim();
                Ent.Formaenvio = TxtFormaEnvio.Text.Trim();
                Ent.Direccion = TxtDireccion.Text.Trim();
                Ent.Telefono = TxtTelefono.Text.Trim();

                int filas;
                filas = NegPedidos.GrabarPedido(Ent);
                if (filas > 0)
                {
                    TxtIdPedido.Text = Convert.ToString(filas);
                    LblMensaje.Text = "Pedido Registrado";
                }
            }
            catch (Exception ex)
            {
                LblMensaje.Text = ex.Message;
            }
        }

        private void CalculoImporte()
        {
            Double Cantidad=Double.Parse(0 + TxtCantidad.Text);
            Double Precio = Double.Parse(0 + TxtPrecio.Text);
            Double Importe = Cantidad * Precio;
            TxtImporte.Text = Importe.ToString();
        }

        private void NuevoPedido()
        {
            TxtIdPedido.Text = "";
            TxtFechaReg.Text = "";
            TxtFormaPago.Text = "";
            TxtFormaEnvio.Text = "";
            TxtDireccion.Text = "";
            TxtTelefono.Text = "";
            TxtCantidad.Text = "";
            TxtPrecio.Text = "";
            TxtImporte.Text = "";
            GridView1.DataSource = null;
            GridView1.DataBind();
        }

        private void NuevoItem()
        {
            TxtCantidad.Text = "";
            TxtPrecio.Text = "";
            TxtImporte.Text = "";
            GridView1.DataSource = null;
            GridView1.DataBind();
        }

        private void RellenarComboItem()
        {
            try
            {
                DataTable Tabla = new DataTable();
                Tabla=NegPedidos.ListaItem();
                DDLItem.DataSource = Tabla;
                DDLItem.DataTextField = "Nombre";
                DDLItem.DataValueField = "IdItem";
                DDLItem.DataBind();
            }
            catch (Exception ex)
            {
                LblMensaje.Text = ex.Message;
            }
        }

        private void RellenarPedidoDetalle()
        {
            try
            {
                DataTable Tabla = new DataTable();
                Ent.Idpedido = int.Parse(TxtIdPedido.Text);
                Tabla = NegPedidos.ListaPedidoDetalle(Ent);
                GridView1.DataSource = Tabla;
                GridView1.DataBind();
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
                RellenarComboItem();
                if (Session.Count > 0)
                {
                    BtnCerrarSesion.Visible = true;
                    PrecioItem();
                    CalculoImporte();
                    LblSesion.Text = "Usuario: " + Session["Login"].ToString();
                }
                else
                {
                    BtnCerrarSesion.Visible = false;
                }
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

        protected void BtnNuevoPedido_Click(object sender, EventArgs e)
        {
            if (Session.Count==0)
            {
                LblMensaje.Text = "Debe Acceder Cuenta con su Usuario y Contraseña";
                return;
            }
            NuevoPedido();
        }

        protected void TxtCantidad_TextChanged(object sender, EventArgs e)
        {
            CalculoImporte();
        }

        protected void TxtPrecio_TextChanged(object sender, EventArgs e)
        {
            CalculoImporte();
        }

        protected void BtnGrabarPedido_Click(object sender, EventArgs e)
        {
            if (Session.Count == 0)
            {
                LblMensaje.Text = "Debe Acceder Cuenta con su Usuario y Contraseña";
                return;
            }
            if (TxtCantidad.Text.Trim() == "")
            {
                LblMensaje.Text = "Ingrese Cantidad";
                TxtCantidad.Focus();
                return;
            }
            if (TxtPrecio.Text.Trim() == "")
            {
                LblMensaje.Text = "Ingrese Precio";
                TxtPrecio.Focus();
                return;
            }

            GrabarCabecera();
            try
            {
                Ent.Idpedido = int.Parse(0 + TxtIdPedido.Text);
                Ent.Iditem = int.Parse(DDLItem.SelectedValue);
                Ent.Cantidad = Double.Parse(0 + TxtCantidad.Text);
                Ent.Precio = Double.Parse(0 + TxtPrecio.Text);
                Ent.Importe =Double.Parse(0 + TxtCantidad.Text) * Double.Parse(0 + TxtPrecio.Text);

                int filas;
                filas = NegPedidos.GrabarPedidoDetalle(Ent);
                if (filas > 0)
                {
                    RellenarPedidoDetalle();
                }
            }
            catch (Exception ex)
            {
                LblMensaje.Text = ex.Message;
            }
        }

        protected void DDLItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrecioItem();
        }

        protected void BtnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("pedidosnuevo.aspx");
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