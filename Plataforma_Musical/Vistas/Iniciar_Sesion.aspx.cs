using Plataforma_Musical.Controladores;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Plataforma_Musical.Vistas
{
    public partial class Iniciar_Sesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["Usuario"] = "Por defecto";


        }

        protected void btncrearcuenta_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registrar_Usuario.aspx");
        }

        protected void btningresar_Click(object sender, EventArgs e)
        {
            UsuarioControlador usuario = new UsuarioControlador();
            string nombre_usuario = txtusuario.Text;
            string contraseña = txtcontraseña.Text;
            if (usuario.existe(nombre_usuario, contraseña))
            {
                DataSet datos_usuario = new DataSet();
                datos_usuario = UsuarioControlador.Buscar(nombre_usuario);
                if (Convert.ToInt16(datos_usuario.Tables["Usuario"].Rows[0]["tipo_usuario"]) == 3)
                {
                    Session["Usuario"] = Convert.ToString(datos_usuario.Tables["Usuario"].Rows[0]["id_usuario"]);
                    Session["Tipo_usuario"]= Convert.ToString(datos_usuario.Tables["Usuario"].Rows[0]["tipo_usuario"]);
                    Response.Redirect("Inicio.aspx");
                }
                else if (Convert.ToInt16(datos_usuario.Tables["Usuario"].Rows[0]["tipo_usuario"]) == 2)
                {
                    ArtistaControlador artista = new ArtistaControlador();
                    int id_usuario = Convert.ToInt16(datos_usuario.Tables["Usuario"].Rows[0]["id_usuario"]);
                    DataSet datos_artista=artista.buscar(id_usuario);
                    Session["Artista"] = Convert.ToString(datos_artista.Tables["ARTISTA"].Rows[0]["id_artista"]);
                    Session["Usuario"] = Convert.ToString(datos_usuario.Tables["Usuario"].Rows[0]["id_usuario"]);
                    Session["Tipo_usuario"] = Convert.ToString(datos_usuario.Tables["Usuario"].Rows[0]["tipo_usuario"]);
                    Response.Redirect("Inicio.aspx");
                }
                else
                {
                    Session["Usuario"] = Convert.ToString(datos_usuario.Tables["Usuario"].Rows[0]["id_usuario"]);
                    Session["Tipo_usuario"] = Convert.ToString(datos_usuario.Tables["Usuario"].Rows[0]["tipo_usuario"]);
                    Response.Redirect("Inicio.aspx");
                }

            }
            else {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Nombre_usuario o Contraseña Incorrectos');", true);
            }
            
               
            }
        }
}
