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
    public partial class index : System.Web.UI.Page
    {
        private NegocioPreferencia NegPreferencia = new NegocioPreferencia();
        private NegocioUsuario NegUsuario = new NegocioUsuario();
        private NegocioPreferenciaXUsuario NegPrefxUsu = new NegocioPreferenciaXUsuario();
        
        private Entidad EntUsuario = new Entidad();
        private Entidad EntPrefxUsu = new Entidad();

        private void Limpiar()
        {
            TxtNombre.Text = "";
            TxtApePat.Text = "";
            TxtApeMat.Text = "";
            TxtDireccion.Text = "";
            TxtTelefono.Text = "";
            TxtCelular.Text = "";
            TxtEmail.Text = "";
            TxtLogin.Text = "";
            TxtPassword.Text = "";
        }

        private void RellenarPreferencias()
        {
            try
            {
                DataTable Tabla = new DataTable();
                Tabla = NegPreferencia.ListaPreferencia();
                ChkPreferencias.Items.Clear();
                int f;
                for (f = 0; f < Tabla.Rows.Count; f++)
                {
                    ChkPreferencias.Items.Add(Tabla.Rows[f]["TipoPreferencia"].ToString());
                }
            }
            catch (Exception ex)
            {
                LblMensaje.Text = ex.Message;
            }
        }

        private void CargarUsuario()
        {
            try
            {
                DataTable Tabla = new DataTable();
                EntUsuario.Idusuario = int.Parse(Session["IdUsuario"].ToString());
                Tabla = NegUsuario.UsuarioListado(EntUsuario);
                if (Tabla.Rows.Count > 0)
                {
                    TxtNombre.Text=Tabla.Rows[0]["Nombre"].ToString();
                    TxtApePat.Text=Tabla.Rows[0]["ApePat"].ToString();
                    TxtApeMat.Text=Tabla.Rows[0]["ApeMat"].ToString();
                    TxtLogin.Text=Tabla.Rows[0]["Login"].ToString(); 
                    TxtPassword.Text=Tabla.Rows[0]["Password"].ToString(); 	  
                    TxtEmail.Text=Tabla.Rows[0]["Email"].ToString(); 	 	  
                    TxtCelular.Text=Tabla.Rows[0]["Celular"].ToString(); 	 		 
                    TxtTelefono.Text=Tabla.Rows[0]["Telefono"].ToString(); 	 		   
                    TxtDireccion.Text=Tabla.Rows[0]["Direccion"].ToString();

                    int i, j;
                    for (j = 0; j < Tabla.Rows.Count; j++)
                    {
                        for (i = 0; i < ChkPreferencias.Items.Count; i++)
                        {
                            string Valor = ChkPreferencias.Items[i].Value.ToString();
                            if (Valor == Tabla.Rows[j]["TipoPreferencia"].ToString())
                            {
                                ChkPreferencias.Items[i].Selected = true;
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                LblMensaje.Text = ex.Message;
            }
        }


        private int Existe()
        {            
            int Retorno=0;
            try
            {
                EntUsuario.Login = TxtLogin.Text;
                Retorno = NegUsuario.Existe(EntUsuario);
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
                RellenarPreferencias();
                if (Session.Count > 0)
                {
                    BtnCerrarSesion.Visible = true;
                    CargarUsuario();
                    LblSesion.Text = "Usuario: " + Session["Login"].ToString();
                }
                else
                {
                    BtnCerrarSesion.Visible = false;
                }
            }
        }
        
        protected void BtnRegistrar_Click(object sender, EventArgs e)
        {
            if (Session.Count == 0)
            {
                if (Existe() > 0)
                {
                    LblMensaje.Text = "Login ya Existe, elija otro";
                    LblMensaje.Focus();
                    return;
                }
            }
            if (TxtNombre.Text.Trim() == "")
            {
                LblMensaje.Text = "Ingrese Nombres";
                TxtNombre.Focus();
                return;
            }
            if (TxtApePat.Text.Trim() == "")
            {
                LblMensaje.Text = "Ingrese Apellido Paterno";
                TxtApePat.Focus();
                return;
            }
            if (TxtApeMat.Text.Trim() == "")
            {
                LblMensaje.Text = "Ingrese Apellido Materno";
                TxtApeMat.Focus();
                return;
            }
            if (TxtDireccion.Text.Trim() == "")
            {
                LblMensaje.Text = "Ingrese Direccion";
                TxtDireccion.Focus();
                return;
            }
            if (TxtEmail.Text.Trim() == "")
            {
                LblMensaje.Text = "Ingrese Email";
                TxtEmail.Focus();
                return;
            }
            if (TxtLogin.Text.Trim() == "")
            {
                LblMensaje.Text = "Ingrese Login";
                TxtLogin.Focus();
                return;
            }
            if (TxtPassword.Text.Trim() == "")
            {
                LblMensaje.Text = "Ingrese Password";
                TxtPassword.Focus();
                return;
            }
            if (Session.Count > 0)
            {
                if (TxtLogin.Text.Trim() != Session["Login"].ToString())
                {
                    LblMensaje.Text = "Ingrese Login Igual al que Inicio Sesión";
                    TxtLogin.Focus();
                    return;
                }
            }
            EntUsuario.Nombre = TxtNombre.Text.Trim();
            EntUsuario.Apepat = TxtApePat.Text.Trim();
            EntUsuario.Apemmat = TxtApeMat.Text.Trim();
            EntUsuario.Direccion = TxtDireccion.Text.Trim();
            EntUsuario.Telefono = TxtTelefono.Text.Trim();
            EntUsuario.Celular = TxtCelular.Text.Trim();
            EntUsuario.Email = TxtEmail.Text.Trim();
            EntUsuario.Password = TxtPassword.Text.Trim();
            EntUsuario.Login = TxtLogin.Text.Trim();
            EntUsuario.Idperfil = 2;              
            try
            {
                int filas;
                filas = NegUsuario.Grabar(EntUsuario);
                if (filas > 0)
                {
                    if(Session.Count> 0)
                    {
                        EntUsuario.Idusuario=int.Parse(Session["IdUsuario"].ToString());
                        Session["Password"] = TxtPassword.Text.Trim();
                        NegPrefxUsu.EliminaXIdUsuario(EntUsuario);
                    }
                    List<Entidad> EntPrefxUsuLista=new List<Entidad>();
                    for (filas = 0; filas < ChkPreferencias.Items.Count; filas++)
                    {
                        if (ChkPreferencias.Items[filas].Selected)
                        {
                            Entidad ENT = new Entidad();
                            ENT.Tipopreferencia = ChkPreferencias.Items[filas].Text;
                            ENT.Login = TxtLogin.Text.Trim();
                            EntPrefxUsuLista.Add(ENT);
                        }
                    }
                    NegPrefxUsu.Grabar(EntPrefxUsuLista);                    
                    if (Session.Count > 0)
                    {
                        LblMensaje.Text = "Usuario Actualizado";
                    }
                    else
                    {
                        LblMensaje.Text = "Usuario Registrado";
                        Limpiar();
                    }
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
            Response.Redirect("index.aspx");
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