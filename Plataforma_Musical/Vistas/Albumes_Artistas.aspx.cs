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
    public partial class Albumes_Artistas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ImageButton imagen;
            Label nombre_a;
            Table tabla_a;
            int id_artista = Convert.ToInt16(Request.QueryString["id_artista"]);
            AlbumControlador album_artista = new AlbumControlador();
            DataSet datos_album = album_artista.buscar(id_artista);
            
            for (int i = 0; i < datos_album.Tables["ALBUM"].Rows.Count; i++)
            {
                
                    //#
                    tabla_a = new Table();
                    TableRow tRow1 = new TableRow();
                    TableCell etiqueta = new TableCell();
                    nombre_a = new Label();
                    nombre_a.Text = Convert.ToString(datos_album.Tables["ALBUM"].Rows[i]["titulo"]);
                    nombre_a.Visible = true;
                    etiqueta.Controls.Add(nombre_a);
                    tRow1.Cells.Add(etiqueta);
                    tabla_a.Rows.Add(tRow1);

                    TableRow tRow2 = new TableRow();
                    TableCell portada = new TableCell();
                    imagen = new ImageButton();
                    imagen.ID = Convert.ToString(datos_album.Tables["ALBUM"].Rows[i]["id_album"]);
                    imagen.Click += Imagen_Click;
                    imagen.Visible = true;
                    imagen.Width = 640 / 3;
                    imagen.Height = 480 / 3;
                    imagen.ImageUrl = Convert.ToString(datos_album.Tables["ALBUM"].Rows[i]["foto_portada"]);
                    portada.Controls.Add(imagen);
                    tRow2.Cells.Add(portada);
                    tabla_a.Rows.Add(tRow2);
                    Contenedor_Albumes.Controls.Add(tabla_a);
                    //#
               


            }

        }

        private void Imagen_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton clickedButton = (ImageButton)sender;
            string id_album = Convert.ToString(clickedButton.ID);
            Response.Redirect("Album_Canciones.aspx?id_album=" + id_album);
        }
    }
}