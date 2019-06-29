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
    public partial class Editar_noticia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            int id_noticia= Convert.ToInt16(Request.QueryString["id_noticia"]);
            if (!IsPostBack)
            {
                NovedadesControlador novedad = new NovedadesControlador();
                DataSet datos = novedad.buscar(id_noticia);


                if (Convert.ToInt16(datos.Tables["NOVEDADES"].Rows.Count) > 0)
                {
                    txttitulo.Text = Convert.ToString(datos.Tables["NOVEDADES"].Rows[0]["titulo"]);
                    txtcontenido.Text = Convert.ToString(datos.Tables["NOVEDADES"].Rows[0]["Contenido"]);
                    Imagen_artista.ImageUrl = Convert.ToString(datos.Tables["NOVEDADES"].Rows[0]["foto_portada"]);
                }
            }
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
            int id_noticia = Convert.ToInt16(Request.QueryString["id_noticia"]);
            txttitulo.Text = "";
            txtcontenido.Text = "";
            Imagen_artista.ImageUrl = "";
            NovedadesControlador editar_novedad = new NovedadesControlador();
            editar_novedad.Actualizar(titulo, contenido, foto_portada,id_noticia);
            Response.Redirect("Registro_novedades.aspx");
        }
    }
}