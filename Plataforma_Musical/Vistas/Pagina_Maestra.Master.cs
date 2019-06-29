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
    public partial class Pagina_Maestra : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["Usuario"]) == "Por defecto") {
                Response.Redirect("Iniciar_Sesion.aspx");
            }
            if (Convert.ToString(Session["Tipo_usuario"]) == "3")
            {
                artista.NavigateUrl = "~/Vistas/Registrar_Artista.aspx";
                menu_admin.Visible = false;
            }
            else if (Convert.ToString(Session["Tipo_usuario"]) == "2")
            {
                ArtistaControlador artistareg = new ArtistaControlador();
                DataSet datos_Artista = artistareg.buscarartista(Convert.ToInt16(Session["Artista"]));
                artista.Text = Convert.ToString(datos_Artista.Tables["Artista"].Rows[0]["nombre_Artista"]);
                string pagina = "info";
                string id_artista = Convert.ToString(Session["Artista"]);
                artista.NavigateUrl = "/Vistas/Informacion.aspx?id_artista=" + id_artista + "&pagina=" + pagina;
                menu_admin.Visible = false;
            }
            else if (Convert.ToString(Session["Tipo_usuario"]) == "1") {
                //artista.Text = "Administrador";
                UsuarioControlador nombre = new UsuarioControlador();
                DataSet datos=nombre.buscar(Convert.ToInt16(Session["Usuario"]),1);
                menu_admin.InnerText = Convert.ToString(datos.Tables["Usuario"].Rows[0]["nombre_usuario"]);
                menu_admin.Visible = true;
                artista.Visible = false;
                //artista.NavigateUrl = "/Vistas/Agregar_generos.aspx";
            }
        }
    }
}