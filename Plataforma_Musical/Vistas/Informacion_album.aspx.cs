using Plataforma_Musical.Controladores;
using Plataforma_Musical.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Plataforma_Musical.Vistas
{
    public partial class Informacion_album : System.Web.UI.Page
    {
        List<CancionModelo> canciones;
        int id_album;
        protected void Page_Load(object sender, EventArgs e)
        {
            id_album = Convert.ToInt16(Request.QueryString["id_album"]);
            canciones = new List<CancionModelo>();
            if (Request.QueryString["id_album"] != null)
            {
               
                

                AlbumControlador album = new AlbumControlador();
                //int id_album = Convert.ToInt16(Request.QueryString["id_album"]);
                DataSet datos_album = album.buscarporid(id_album);
                txttitulo.Text = Convert.ToString(datos_album.Tables["ALBUM"].Rows[0]["titulo"]);
                Imagen_album.ImageUrl = Convert.ToString(datos_album.Tables["ALBUM"].Rows[0]["foto_portada"]);
                txtreseña.Text = Convert.ToString(datos_album.Tables["ALBUM"].Rows[0]["reseña"]);
                campo_oculto_fecha_publicacion.Value= Convert.ToString(datos_album.Tables["ALBUM"].Rows[0]["fecha"]);
                CancionControlador canciones0 = new CancionControlador();
                DataSet canciones1 = canciones0.buscarcanciones(id_album);
                for (int i = 0; i < canciones1.Tables["CANCION"].Rows.Count; i++)
                {
                    CancionModelo cancion = new CancionModelo();
                    cancion.Nombre_cancion = Convert.ToString(canciones1.Tables["CANCION"].Rows[i]["nombre_cancion"]);
                    cancion.Url_cancion = Convert.ToString(canciones1.Tables["CANCION"].Rows[i]["url_cancion"]);
                    this.canciones.Add(cancion);
                    Session["canciones"] = canciones;
                    TableRow tRow = new TableRow();
                    tabla_canciones.Rows.Add(tRow);
                    TableCell numero = new TableCell();
                    numero.Text = Convert.ToString(i + 1);
                    tRow.Cells.Add(numero);
                    TableCell nombre_Cancion = new TableCell();
                    nombre_Cancion.Text = Convert.ToString(canciones1.Tables["CANCION"].Rows[i]["nombre_cancion"]);
                    tRow.Cells.Add(nombre_Cancion);
                    TableCell duracion = new TableCell();
                    duracion.Text = Convert.ToString(canciones1.Tables["CANCION"].Rows[i]["duracion"]);
                    tRow.Cells.Add(duracion);
                    TableCell acciones = new TableCell();
                    acciones.Text = "acciones";
                    tRow.Cells.Add(acciones);
                }
            }
            else
            {
                //canciones = (List<CancionModelo>)Session["canciones"];
                for (int i = 0; i < canciones.Count; i++)
                {
                    TableRow tRow = new TableRow();
                    tabla_canciones.Rows.Add(tRow);
                    TableCell numero = new TableCell();
                    numero.Text = Convert.ToString(i + 1);
                    tRow.Cells.Add(numero);
                    TableCell nombre_Cancion = new TableCell();
                    nombre_Cancion.Text = canciones[i].Nombre_cancion;
                    tRow.Cells.Add(nombre_Cancion);
                    TableCell duracion = new TableCell();
                    duracion.Text = canciones[i].Duracion;
                    tRow.Cells.Add(duracion);
                    TableCell acciones = new TableCell();
                    acciones.Text = "acciones";
                    tRow.Cells.Add(acciones);
                }
            }
               
        }

        protected void btnsubirportada_Click(object sender, EventArgs e)
        {
            Boolean correcto = false;
            if (foto_album.HasFile)
            {
                string extensionArchivo = System.IO.Path.GetExtension(foto_album.FileName).ToLower();
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
                ViewState["foto"] = System.IO.Path.GetFileName(foto_album.FileName);
                foto_album.SaveAs(Server.MapPath("~/images/Imagenes_albumes/") + ViewState["foto"]);
                Imagen_album.ImageUrl = "~/images/Imagenes_albumes/" + ViewState["foto"];

            }
        }

        protected void btnsubir_Click(object sender, EventArgs e)
        {
            Boolean correcto = false;
            if (explorador_archivos.HasFile)
            {
                string extensionArchivo = System.IO.Path.GetExtension(explorador_archivos.FileName).ToLower();
                string[] extensionesPermitidas = { ".mp3" };
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
                ViewState["cancion"] = System.IO.Path.GetFileName(explorador_archivos.FileName);
                explorador_archivos.SaveAs(Server.MapPath("~/Canciones/") + ViewState["cancion"]);
                string url = System.IO.Path.GetFullPath(explorador_archivos.FileName);
                CancionModelo cancion = new CancionModelo();
                cancion.Nombre_cancion = System.IO.Path.GetFileNameWithoutExtension(explorador_archivos.FileName);
                cancion.Url_cancion = url;
                //#
                HttpPostedFile postedFile = explorador_archivos.PostedFile;
                string fileName = Path.GetFileName(postedFile.FileName);
                int fileSize = postedFile.ContentLength;
                double duracion_c = fileSize * 8;
                duracion_c = duracion_c / 1003.7;
                duracion_c = duracion_c / 128;
                duracion_c = Math.Round(duracion_c, 2);
                double minutos = duracion_c / 60;
                minutos = Math.Round(minutos, 0);
                double segundos = duracion_c % 60;
                segundos = Math.Round(segundos, 0);
                string duracion_cancion = Convert.ToString(minutos) + ":" + Convert.ToString(segundos);
                cancion.Duracion = duracion_cancion;
                //#
                this.canciones.Add(cancion);
                Session["canciones"] = canciones;
                TableRow tRow = new TableRow();
                tabla_canciones.Rows.Add(tRow);
                TableCell numero = new TableCell();
                numero.Text = Convert.ToString(canciones.Count);
                tRow.Cells.Add(numero);
                TableCell nombre_Cancion = new TableCell();
                nombre_Cancion.Text = cancion.Nombre_cancion;
                tRow.Cells.Add(nombre_Cancion);
                TableCell duracion = new TableCell();
                duracion.Text = cancion.Duracion;
                tRow.Cells.Add(duracion);
                TableCell acciones = new TableCell();
                acciones.Text = "acciones";
                tRow.Cells.Add(acciones);

            }

        }

        protected void btnactualizar_Click(object sender, EventArgs e)
        {
            string titulo = txttitulo.Text.Trim();
            string foto = Imagen_album.ImageUrl;
            string reseña = txtreseña.Text.Trim();
            string fecha = campo_oculto_fecha_publicacion.Value;
            int id_album = Convert.ToInt16(Request.QueryString["id_album"]);
            AlbumControlador actualizar = new AlbumControlador();
            actualizar.Editar(titulo, fecha, reseña, foto, id_album);
        }

        protected void btneliminar_Click(object sender, EventArgs e)
        {
            AlbumControlador eliminar = new AlbumControlador();
            eliminar.Eliminar_album(id_album);
            if (Session["canciones"] != null) {
                Session["canciones"] = null;
            }
            CancionControlador canciones_borrar = new CancionControlador();
            DataSet datos_canciones = canciones_borrar.buscarcanciones(id_album);
            for (int i = 0; i < datos_canciones.Tables["CANCION"].Rows.Count; i++) {
                canciones_borrar.eliminar_cancion(Convert.ToInt16(datos_canciones.Tables["CANCION"].Rows[i]["id_cancion"]));
            }
            string artista = Convert.ToString(Session["Artista"]);
            string pagina = "album";
            Response.Redirect("Registro_album.aspx?id_artista=" + artista + "&pagina=" + pagina);
        }
    }
}