using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;

namespace SistemaWebEntidades
{
    public class Entidad
    {
        private CheckBox chk;

        public CheckBox Chk
        {
            get { return chk; }
            set { chk = value; }
        }
 
        private string tipodeitem;

        public string Tipodeitem
        {
            get { return tipodeitem; }
            set { tipodeitem = value; }
        }

        private int idcategoria;

        public int Idcategoria
        {
            get { return idcategoria; }
            set { idcategoria = value; }
        }


        private int idperfil;

        public int Idperfil
        {
            get { return idperfil; }
            set { idperfil = value; }
        }

        private string descripción;

        public string Descripción
        {
            get { return descripción; }
            set { descripción = value; }
        }
        private int idpreferencia;

        public int Idpreferencia
        {
            get { return idpreferencia; }
            set { idpreferencia = value; }
        }
        private string tipopreferencia;

        public string Tipopreferencia
        {
            get { return tipopreferencia; }
            set { tipopreferencia = value; }
        }
        private int idpreferenciaxUsuario;

        public int IdpreferenciaxUsuario
        {
            get { return idpreferenciaxUsuario; }
            set { idpreferenciaxUsuario = value; }
        }
        private int idusuario;

        public int Idusuario
        {
            get { return idusuario; }
            set { idusuario = value; }
        }
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        private string apepat;

        public string Apepat
        {
            get { return apepat; }
            set { apepat = value; }
        }
        private string apemmat;

        public string Apemmat
        {
            get { return apemmat; }
            set { apemmat = value; }
        }
        private string login;

        public string Login
        {
            get { return login; }
            set { login = value; }
        }
        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        private string email;

        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        private string celular;

        public string Celular
        {
            get { return celular; }
            set { celular = value; }
        }
        private string telefono;

        public string Telefono
        {
            get { return telefono; }
            set { telefono = value; }
        }
        private string direccion;

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        private int idpedido;

        public int Idpedido
        {
            get { return idpedido; }
            set { idpedido = value; }
        }

        private DateTime fechaReg;

        public DateTime FechaReg
        {
            get { return fechaReg; }
            set { fechaReg = value; }
        }
        private string formapago;

        public string Formapago
        {
            get { return formapago; }
            set { formapago = value; }
        }
        private string formaenvio;

        public string Formaenvio
        {
            get { return formaenvio; }
            set { formaenvio = value; }
        }
        private string estado;

        public string Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        private int iditem;

        public int Iditem
        {
            get { return iditem; }
            set { iditem = value; }
        }

        private double cantidad;

        public double Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }


        private double precio;

        public double Precio
        {
            get { return precio; }
            set { precio = value; }
        }


        private double importe;

        public double Importe
        {
            get { return importe; }
            set { importe = value; }
        }


    }
}
