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
    public partial class Favoritos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ImageButton imagen;
            Label nombre_a;
            Table tabla_a;
          
            int id_usuario = Convert.ToInt16(Session["Usuario"]);
            Album_favoritoControlador albumes_favoritos = new Album_favoritoControlador();
            DataSet datos_albumes_f = albumes_favoritos.Obtenerfavoritos(id_usuario);
            for (int i = 0; i < datos_albumes_f.Tables["ALBUM_FAVORITO"].Rows.Count; i++) {
                AlbumControlador album = new AlbumControlador();
                DataSet datos_album = album.buscarporid(Convert.ToInt16(datos_albumes_f.Tables["ALBUM_FAVORITO"].Rows[i]["album"]));

                tabla_a = new Table();
                TableRow tRow1 = new TableRow();
                TableCell etiqueta = new TableCell();
                nombre_a = new Label();
                nombre_a.Text = Convert.ToString(datos_album.Tables["ALBUM"].Rows[0]["titulo"]);
                nombre_a.Visible = true;
                etiqueta.Controls.Add(nombre_a);
                tRow1.Cells.Add(etiqueta);
                tabla_a.Rows.Add(tRow1);

                TableRow tRow2 = new TableRow();
                TableCell portada = new TableCell();
                imagen = new ImageButton();
                imagen.ID = Convert.ToString(datos_album.Tables["ALBUM"].Rows[0]["id_album"]);
                imagen.Visible = true;
                imagen.Width = 640 / 3;
                imagen.Height = 480 / 3;
                imagen.ImageUrl = Convert.ToString(datos_album.Tables["ALBUM"].Rows[0]["foto_portada"]);
                portada.Controls.Add(imagen);
                tRow2.Cells.Add(portada);
                tabla_a.Rows.Add(tRow2);
                //#
                Albumes_Favoritos.Controls.Add(tabla_a);
            }

            //########################################Imagen de Album con sus Botones#########################################
            /* CancionControlador canciones = new CancionControlador();
             DataSet datos_canciones = canciones.buscarcanciones(id_album);

             for (int i = 0; i < datos_canciones.Tables["CANCION"].Rows.Count; i++)
             {
                 TableRow can = new TableRow();
                 TableCell nombre_c = new TableCell();
                 nombre_c.Text = Convert.ToString(datos_canciones.Tables["CANCION"].Rows[i]["nombre_cancion"]);
                 can.Controls.Add(nombre_c);
                 int id_cancion = Convert.ToInt16(datos_canciones.Tables["CANCION"].Rows[i]["id_cancion"]);


                 acciones_fav_c.Controls.Add(fav_c);
                 can.Controls.Add(acciones_fav_c);

                 tabla_canciones.Rows.Add(can);
             }*/
        }
    }
}