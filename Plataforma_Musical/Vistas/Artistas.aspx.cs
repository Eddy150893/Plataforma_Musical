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
    public partial class Artistas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ImageButton imagen;
            Label nombre_a;
            Table tabla_a;
            int id_genero= Convert.ToInt16(Request.QueryString["id_genero"]);
            Genero_artistaControlador artistas = new Genero_artistaControlador();
            DataSet datos_artistas = artistas.buscar_Artistas(id_genero);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('"+ datos_artistas.Tables["GENERO_ARTISTA"].Rows.Count + "');", true);
            for (int i = 0; i < datos_artistas.Tables["GENERO_ARTISTA"].Rows.Count; i++) {
                ArtistaControlador artista = new ArtistaControlador();
                DataSet datos_artista = artista.buscarartista(Convert.ToInt16(datos_artistas.Tables["GENERO_ARTISTA"].Rows[i]["artista"]));
                if (datos_artista.Tables["ARTISTA"].Rows.Count>0) {
                    //#
                    tabla_a = new Table();
                    TableRow tRow1 = new TableRow();
                    TableCell etiqueta = new TableCell();
                    nombre_a = new Label();
                    nombre_a.Text = Convert.ToString(datos_artista.Tables["ARTISTA"].Rows[0]["nombre_artista"]);
                    nombre_a.Visible = true;
                    etiqueta.Controls.Add(nombre_a);
                    tRow1.Cells.Add(etiqueta);
                    tabla_a.Rows.Add(tRow1);

                    TableRow tRow2 = new TableRow();
                    TableCell portada = new TableCell();
                    imagen = new ImageButton();
                    imagen.ID = Convert.ToString(datos_artista.Tables["ARTISTA"].Rows[0]["id_artista"]);
                    imagen.Click += Imagen_Click;
                    imagen.Visible = true;
                    imagen.Width = 640 / 3;
                    imagen.Height = 480 / 3;
                    imagen.ImageUrl = Convert.ToString(datos_artista.Tables["ARTISTA"].Rows[0]["foto"]);
                    portada.Controls.Add(imagen);
                    tRow2.Cells.Add(portada);
                    tabla_a.Rows.Add(tRow2);
                    Contenido_a.Controls.Add(tabla_a);
                    //#
                }


            }
        }

        private void Imagen_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton clickedButton = (ImageButton)sender;
            string id_artista = Convert.ToString(clickedButton.ID);
            Response.Redirect("Albumes_Artistas.aspx?id_artista=" + id_artista);
        }
    }
}