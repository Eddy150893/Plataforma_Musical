using Plataforma_Musical.Controladores;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;

namespace Plataforma_Musical.Vistas
{
    public partial class Generos : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            ImageButton imagen;
            Label nombre_g;
            Table tabla_g;
            int id_artista = Convert.ToInt16(Session["Artista"]);
            Genero_musicalControlador generos = new Genero_musicalControlador();
            DataSet todos_generos = generos.Mostrar();

            for (int i = 0; i < todos_generos.Tables["GENERO_MUSICAL"].Rows.Count; i++)
            {
                tabla_g = new Table();
                TableRow tRow1 = new TableRow();
                TableCell etiqueta = new TableCell();
                nombre_g = new Label();
                nombre_g.Text = Convert.ToString(todos_generos.Tables["GENERO_MUSICAL"].Rows[i]["nombre_genero"]);
                nombre_g.Visible = true;
                etiqueta.Controls.Add(nombre_g);
                tRow1.Cells.Add(etiqueta);
                tabla_g.Rows.Add(tRow1);

                TableRow tRow2 = new TableRow();
                TableCell portada = new TableCell();
                imagen = new ImageButton();
                imagen.ID = Convert.ToString(todos_generos.Tables["GENERO_MUSICAL"].Rows[i]["id_genero"]);
                imagen.Click += Imagen_Click;
                imagen.Visible = true;
                imagen.Width = 640 / 3;
                imagen.Height = 480 / 3;
                imagen.ImageUrl = Convert.ToString(todos_generos.Tables["GENERO_MUSICAL"].Rows[i]["imagen_genero"]);
                portada.Controls.Add(imagen);
                tRow2.Cells.Add(portada);
                tabla_g.Rows.Add(tRow2);
                Contenedor_generos.Controls.Add(tabla_g);



            }
        }

        private void Imagen_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton clickedButton = (ImageButton)sender;
            string id_genero = Convert.ToString(clickedButton.ID);
            Response.Redirect("Artistas.aspx?id_genero=" + id_genero);
        }
    }
}