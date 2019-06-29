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
    public partial class Registro_album : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ImageButton imagen;
            Label nombre_A;
            Table tabla_A;
            int id_artista = Convert.ToInt16(Session["Artista"]);
            AlbumControlador albumes = new AlbumControlador();
            DataSet todos_albumes=albumes.buscar(id_artista);
            for(int i=0;i<todos_albumes.Tables["ALBUM"].Rows.Count;i++)
            {
                if (Convert.ToString(todos_albumes.Tables["ALBUM"].Rows[i]["estado"])=="1") {
                    tabla_A = new Table();
                    TableRow tRow1 = new TableRow();
                    TableCell etiqueta = new TableCell();
                    nombre_A = new Label();
                    nombre_A.Text = Convert.ToString(todos_albumes.Tables["ALBUM"].Rows[i]["titulo"]);
                    nombre_A.Visible = true;
                    etiqueta.Controls.Add(nombre_A);
                    tRow1.Cells.Add(etiqueta);
                    tabla_A.Rows.Add(tRow1);

                    TableRow tRow2 = new TableRow();
                    TableCell portada = new TableCell();
                    imagen = new ImageButton();
                    imagen.ID = Convert.ToString(todos_albumes.Tables["ALBUM"].Rows[i]["id_album"]);
                    imagen.Click += Imagen_Click;
                    imagen.Visible = true;
                    imagen.Width = 640 / 3;
                    imagen.Height = 480 / 3;
                    imagen.ImageUrl = Convert.ToString(todos_albumes.Tables["ALBUM"].Rows[i]["foto_portada"]);
                    portada.Controls.Add(imagen);
                    tRow2.Cells.Add(portada);
                    tabla_A.Rows.Add(tRow2);
                    Contenedor_Album.Controls.Add(tabla_A);
                }
                
            }
        }

        private void Imagen_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton clickedButton = (ImageButton)sender;
            string id =Convert.ToString(clickedButton.ID);
            string artista = Convert.ToString(Session["Artista"]);
            string pagina = "album";
            Response.Redirect("Informacion_album.aspx?id_artista=" + artista + "&pagina=" + pagina+"&id_album="+id);
        }

        protected void btnpublicar_Click(object sender, EventArgs e)
        {
            string artista = Convert.ToString(Session["Artista"]);
            string pagina = "album";
            if (Session["canciones"] != null)
            {
                Session["canciones"] = null;
            }
            Response.Redirect("Publicar_album.aspx?id_artista=" + artista + "&pagina=" + pagina);
        }
    }
}