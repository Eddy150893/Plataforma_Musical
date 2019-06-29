using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Plataforma_Musical.Vistas
{
    public partial class Pagina_Maestra_artista : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToString(Session["Usuario"]) == "Por defecto")
            {
                Response.Redirect("Iniciar_Sesion.aspx");
            }
            int id_artista = Convert.ToInt16(Request.QueryString["id_artista"]);
            string pagina = Request.QueryString["pagina"];
            Session["Artista"] = id_artista;
            if (pagina == "info")
            {
                btninformacion.Enabled = false;
            }
            else if (pagina == "album")
            {
                btnalbumes.Enabled = false;
            }
        }

        protected void btnalbumes_Click(object sender, EventArgs e)
        {
            string artista = Convert.ToString(Session["Artista"]);
            string pagina = "album";
           Response.Redirect("Registro_album.aspx?id_artista="+artista+"&pagina="+pagina);
            if (Session["canciones"] != null) {
                Session["canciones"] = null;
            }
        }

        protected void btninformacion_Click(object sender, EventArgs e)
        {
            string artista = Convert.ToString(Session["Artista"]);
            string pagina = "info";
            if (Session["canciones"] != null)
            {
                Session["canciones"] = null;
            }
            Response.Redirect("Informacion.aspx?id_artista=" + artista + "&pagina=" + pagina);
            
        }
    }
}