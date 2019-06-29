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
    public partial class Album_Canciones : System.Web.UI.Page
    {
        
        /*
         Nota: algunos de los id de los componentes tienen agregadas las letras a,b,c,x,y,z 
         esto es aproposito para que no haya conflictos de id
         al momento de hacer click el usuario en cada uno de los componentes se les debe
         quitar esas letras agregadas...
             */
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            //#################################Imagen de Album con sus botones###########################################
            ImageButton imagen;
            Label nombre_a;
            Table tabla_a;
            ImageButton play;
            ImageButton like;
            ImageButton fav;
            int id_album = Convert.ToInt16(Request.QueryString["id_album"]);
            int id_play = id_album;
            int id_like = id_album;
            int id_fav = id_album;
            AlbumControlador album = new AlbumControlador();
            DataSet datos_album = album.buscarporid(id_album);

            tabla_a = new Table();
            TableRow tRow1 = new TableRow();
            TableCell etiqueta = new TableCell();
            etiqueta.ColumnSpan = 3;
            nombre_a = new Label();
            nombre_a.Text = Convert.ToString(datos_album.Tables["ALBUM"].Rows[0]["titulo"]);
            nombre_a.Visible = true;
            etiqueta.Controls.Add(nombre_a);
            tRow1.Cells.Add(etiqueta);
            tabla_a.Rows.Add(tRow1);

            TableRow tRow2 = new TableRow();
            TableCell portada = new TableCell();
            portada.ColumnSpan = 3;
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
            TableRow Acciones = new TableRow();
            

            TableCell acciones_play = new TableCell();
            TableCell acciones_like = new TableCell();
            TableCell acciones_fav = new TableCell();

            play = new ImageButton();
            play.ID = Convert.ToString(id_play)+"a";
            play.Visible = true;
            play.Width = 100 / 3;
            play.Height = 100 / 3;
            play.ImageUrl = "~/Vistas/images/play.jpg";
            play.Click += Play_Click;

            acciones_play.Controls.Add(play);
            Acciones.Controls.Add(acciones_play);

            like = new ImageButton();
            like.ID = Convert.ToString(id_like)+"b";
            like.Visible = true;
            like.Width = 100 / 3;
            like.Height = 100 / 3;
            like.ImageUrl = "~/Vistas/images/me_gusta.jpg";
            like.Click += Like_Click;

            acciones_like.Controls.Add(like);
            Acciones.Controls.Add(acciones_like);

            fav = new ImageButton();
            fav.ID = Convert.ToString(id_fav)+"c";
            fav.Visible = true;
            fav.Width = 100 / 3;
            fav.Height = 100 / 3;
            fav.ImageUrl = "~/Vistas/images/favorito.jpg";
            fav.Click += Fav_Click;

            acciones_fav.Controls.Add(fav);
            Acciones.Controls.Add(acciones_fav);
            //#
            tabla_a.Rows.Add(Acciones);
            Contenedor_Album.Controls.Add(tabla_a);
            //########################################Imagen de Album con sus Botones#########################################
            CancionControlador canciones = new CancionControlador();
            DataSet datos_canciones = canciones.buscarcanciones(id_album);
                
            for (int i = 0; i < datos_canciones.Tables["CANCION"].Rows.Count; i++) {
                TableRow can = new TableRow();
                TableCell nombre_c = new TableCell();
                nombre_c.Text = Convert.ToString(datos_canciones.Tables["CANCION"].Rows[i]["nombre_cancion"]);
                can.Controls.Add(nombre_c);
                int id_cancion = Convert.ToInt16(datos_canciones.Tables["CANCION"].Rows[i]["id_cancion"]);
                ImageButton play_c;
                ImageButton like_c;
                ImageButton fav_c;

                int id_play_c = id_cancion;
                int id_like_c = id_cancion;
                int id_fav_c = id_cancion;

                TableCell acciones_play_c = new TableCell();
                TableCell acciones_like_c = new TableCell();
                TableCell acciones_fav_c = new TableCell();

                play_c = new ImageButton();
                play_c.ID = Convert.ToString(id_play_c)+"x";
                play_c.Visible = true;
                play_c.Width = 100 / 3;
                play_c.Height = 100 / 3;
                play_c.ImageUrl = "~/Vistas/images/play.jpg";
                play_c.Click += Play_c_Click;

                acciones_play_c.Controls.Add(play_c);
                can.Controls.Add(acciones_play_c);

                like_c = new ImageButton();
                like_c.ID = Convert.ToString(id_like_c)+"y";
                like_c.Visible = true;
                like_c.Width = 100 / 3;
                like_c.Height = 100 / 3;
                like_c.ImageUrl = "~/Vistas/images/me_gusta.jpg";
                like_c.Click += Like_c_Click;

                acciones_like_c.Controls.Add(like_c);
                can.Controls.Add(acciones_like_c);

                fav_c = new ImageButton();
                fav_c.ID = Convert.ToString(id_fav_c)+"z";
                fav_c.Visible = true;
                fav_c.Width = 100 / 3;
                fav_c.Height = 100 / 3;
                fav_c.ImageUrl = "~/Vistas/images/favorito.jpg";
                fav_c.Click += Fav_c_Click;

                acciones_fav_c.Controls.Add(fav_c);
                can.Controls.Add(acciones_fav_c);

                tabla_canciones.Rows.Add(can);
            }
            ComentariosControlador comen = new ComentariosControlador();
            DataSet comens = comen.mostrar(id_album);
            TextBox caja;
            Label nombre;
            for (int j = 0; j < comens.Tables["COMENTARIOS"].Rows.Count; j++) {
                caja =new  TextBox();
                caja.Text = Convert.ToString(comens.Tables["COMENTARIOS"].Rows[j]["comentario"]);
                nombre = new Label();
                UsuarioControlador usuario = new UsuarioControlador();
                DataSet datosusuario = usuario.buscar(Convert.ToInt16(comens.Tables["COMENTARIOS"].Rows[j]["usuario"]),1);
                if (datosusuario.Tables["USUARIO"].Rows.Count > 0)
                {
                    nombre.Text = Convert.ToString(datosusuario.Tables["USUARIO"].Rows[0]["nombre_usuario"]);
                }
                else {
                    nombre.Text = "Eliminado";
                }
                Contenedor_Comentarios.Controls.Add(nombre);
                Contenedor_Comentarios.Controls.Add(caja);
            }
        }

        private void Play_c_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton clickedButton = (ImageButton)sender;
            string id_cancion = Convert.ToString(clickedButton.ID).Replace('x',' ');
            int numero_cancion = Convert.ToInt16(id_cancion.Trim());
            CancionControlador cancion = new CancionControlador();
            DataSet datos_Cancion = cancion.buscarporId(numero_cancion);
            string nombre = Convert.ToString(datos_Cancion.Tables["CANCION"].Rows[0]["url_cancion"]);
            Response.Redirect(nombre);
        }

        private void Like_c_Click(object sender, ImageClickEventArgs e)
        {
            
        }

        private void Fav_c_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton clickedButton = (ImageButton)sender;
            string id_cancion = Convert.ToString(clickedButton.ID).Replace('z', ' ');
            int numero_cancion = Convert.ToInt16(id_cancion.Trim());
            int usuario = Convert.ToInt16(Session["Usuario"]);
            Cancion_favoritoControlador cancion_favorito = new Cancion_favoritoControlador();
            if (cancion_favorito.existe(numero_cancion,usuario)) {
                cancion_favorito.eliminar(numero_cancion, usuario);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('La cancion ha sido eliminado de sus Favoritos');", true);
            } else {
                cancion_favorito.almacenar(numero_cancion, usuario);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('La cancion ha sido agregado a sus favoritos');", true);
            }

        }

        private void Fav_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton clickedButton = (ImageButton)sender;
            string id_album = Convert.ToString(clickedButton.ID).Replace('c', ' ');
            int numero_album = Convert.ToInt16(id_album.Trim());
            int usuario = Convert.ToInt16(Session["Usuario"]);
            Album_favoritoControlador album_favorito = new Album_favoritoControlador();
            if (album_favorito.existe(numero_album, usuario))
            {
                album_favorito.eliminar(numero_album, usuario);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('El album ha sido eliminado de sus Favoritos');", true);
            }
            else {
                album_favorito.almacenar(numero_album, usuario);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('El Album ha sido agregado a sus favoritos');", true);
            }
        }

        private void Like_Click(object sender, ImageClickEventArgs e)
        {
           
        }

        private void Play_Click(object sender, ImageClickEventArgs e)
        {
            
        }

        protected void txtagregarcomentario_Click(object sender, EventArgs e)
        {
            ComentariosControlador comentario = new ComentariosControlador();
            string com = txtComentario.Text.Trim();
            int id_usuario = Convert.ToInt16(Session["Usuario"]);
            int id_album = Convert.ToInt16(Request.QueryString["id_album"]);
            comentario.almacenar(id_usuario, id_album, com);
        }
    }
}