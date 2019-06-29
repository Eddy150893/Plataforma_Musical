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
    public partial class Publicar_album : System.Web.UI.Page
    {
        List<CancionModelo> canciones;
        protected void Page_Load(object sender, EventArgs e)
        {
             canciones= new List<CancionModelo>();
            if (Session["canciones"] == null)
            {
            }
            else {
                canciones = (List < CancionModelo >) Session["canciones"];
                for (int i = 0; i < canciones.Count; i++) {
                    TableRow tRow = new TableRow();
                    tabla_canciones.Rows.Add(tRow);
                    TableCell numero = new TableCell();
                    numero.Text = Convert.ToString(i+1);
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
                string url = "~/Canciones/" + ViewState["cancion"];
                HttpPostedFile postedFile = explorador_archivos.PostedFile;
                string fileName = Path.GetFileName(postedFile.FileName);
                int fileSize = postedFile.ContentLength;
                double duracion_c = fileSize * 8;
                duracion_c = duracion_c / 1003.7;
                duracion_c = duracion_c / 128;
                duracion_c = Math.Round(duracion_c, 2);
                double minutos = duracion_c / 60;
                minutos= Math.Round(minutos, 0);
                double segundos = duracion_c % 60;
                segundos= Math.Round(segundos, 0);
                string duracion_cancion = Convert.ToString(minutos)+":"+Convert.ToString(segundos);
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('"+duracion_cancion+"');", true);
                CancionModelo cancion = new CancionModelo();
                cancion.Nombre_cancion = System.IO.Path.GetFileNameWithoutExtension(explorador_archivos.FileName);
                cancion.Url_cancion = url;
                cancion.Duracion = duracion_cancion;
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

        protected void btnfinalizar_Click(object sender, EventArgs e)
        {
            string titulo = txttitulo.Text.Trim();
            string fecha = campo_oculto_fecha_publicacion.Value;
            string reseña = txtreseña.Text.Trim();
            string foto_portada = Imagen_album.ImageUrl;
            int artista = Convert.ToInt16(Session["Artista"]);
            if (this.canciones.Count<1) {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('El album debe tener almenos una cancion');", true);
                
            } else {
                
                AlbumControlador nuevo_album = new AlbumControlador();
                nuevo_album.almacenar(titulo, fecha, reseña, foto_portada, artista);
                DataSet datos_Album = nuevo_album.buscar();
                int id_album = Convert.ToInt16(datos_Album.Tables["ALBUM"].Rows[0]["id_album"]);
                for (int i = 0; i < this.canciones.Count; i++) {
                    CancionControlador nueva = new CancionControlador();
                    nueva.almacenar(canciones[i].Nombre_cancion, canciones[i].Duracion, id_album,canciones[i].Url_cancion);
                }
                Session["canciones"] = null;
                string pagina = "album";
                Response.Redirect("Registro_album.aspx?id_artista=" + artista + "&pagina=" + pagina);
            }
            
        }
    }
    }
