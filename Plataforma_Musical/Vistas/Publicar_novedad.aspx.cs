using Plataforma_Musical.Controladores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Plataforma_Musical.Vistas
{
    public partial class Publicar_novedad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Boolean correcto = false;
            if (fuFotoConstancia.HasFile)
            {
                string extensionArchivo = System.IO.Path.GetExtension(fuFotoConstancia.FileName).ToLower();
                string[] extensionesPermitidas = { ".png", ".jpg", ".jpeg" };
                for (int i = 0; i < extensionesPermitidas.Length; i++)
                {
                    if (extensionArchivo == extensionesPermitidas[i])
                    {
                        correcto = true;
                    }
                }
            }
            if (correcto == true)
            {
                ViewState["foto"] = System.IO.Path.GetFileName(fuFotoConstancia.FileName);
                fuFotoConstancia.SaveAs(Server.MapPath("~/images/Imagenes_noticias/") + ViewState["foto"]);
                Imagen_artista.ImageUrl = "~/images/Imagenes_noticias/" + ViewState["foto"];

            }
        }

        protected void btnpublicar_Click(object sender, EventArgs e)
        {
            string titulo = txttitulo.Text.Trim();
            string contenido = txtcontenido.Text.Trim();
            string foto_portada = Imagen_artista.ImageUrl;
            int usuario = Convert.ToInt16(Session["Usuario"]);
            int estado = 1;
            NovedadesControlador nueva_novedad =new NovedadesControlador();
            nueva_novedad.Almacenar(titulo, contenido, foto_portada, usuario, estado);
            Response.Redirect("Registro_novedades.aspx");
        }
    }
}