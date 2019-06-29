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
    public partial class Registro_novedades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ImageButton imagen;
            Label titulo;
            Label contenido;
            Table tabla_n;
            ImageButton borrar;
            ImageButton actualizar;
            NovedadesControlador novedades = new NovedadesControlador();
            DataSet noticias = novedades.Index(1);
            for (int i = 0; i < noticias.Tables["NOVEDADES"].Rows.Count; i++) {
                tabla_n = new Table();
                TableRow fila1 = new TableRow();
                TableRow fila2 = new TableRow();
                TableRow fila3 = new TableRow();
                TableRow fila4 = new TableRow();

                TableCell t_novedad = new TableCell();
                t_novedad.ColumnSpan = 2;
                titulo = new Label();
                titulo.Text = Convert.ToString(noticias.Tables["NOVEDADES"].Rows[i]["titulo"]);
                t_novedad.Controls.Add(titulo);
                fila1.Controls.Add(t_novedad);
                tabla_n.Rows.Add(fila1);

                TableCell portada = new TableCell();
                portada.ColumnSpan = 2;
                imagen = new ImageButton();
                imagen.Visible = true;
                imagen.Width = 640 / 3;
                imagen.Height = 480 / 3;
                imagen.ImageUrl = Convert.ToString(noticias.Tables["NOVEDADES"].Rows[i]["foto_portada"]);
                portada.Controls.Add(imagen);
                fila2.Controls.Add(portada);
                tabla_n.Rows.Add(fila2);

                TableCell t_contenido = new TableCell();
                t_contenido.ColumnSpan = 2;
                contenido = new Label();
                contenido.Text = Convert.ToString(noticias.Tables["NOVEDADES"].Rows[i]["contenido"]);
                t_contenido.Controls.Add(contenido);
                fila3.Controls.Add(t_contenido);
                tabla_n.Rows.Add(fila3);

                TableCell eliminar = new TableCell();
                borrar = new ImageButton();
                borrar.Visible = true;
                borrar.ID = Convert.ToString(noticias.Tables["NOVEDADES"].Rows[i]["id_novedad"]);
                borrar.Click += Borrar_Click;
                borrar.Width = 100/ 3;
                borrar.Height = 100 / 3;
                borrar.ImageUrl = "~/Vistas/images/botebasura.jpg";
                eliminar.Controls.Add(borrar);
                fila4.Controls.Add(eliminar);
                tabla_n.Rows.Add(fila4);

                TableCell editar = new TableCell();
                actualizar = new ImageButton();
                actualizar.Visible = true;
                actualizar.ID = Convert.ToString(noticias.Tables["NOVEDADES"].Rows[i]["id_novedad"])+"a";
                actualizar.Click += Actualizar_Click;
                actualizar.Width = 100 / 3;
                actualizar.Height = 100 / 3;
                actualizar.ImageUrl = "~/Vistas/images/engrane.png";
                editar.Controls.Add(actualizar);
                fila4.Controls.Add(editar);
                tabla_n.Rows.Add(fila4);
                Contenedor_novedades.Controls.Add(tabla_n);
            }
        }

        private void Actualizar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton clickedButton = (ImageButton)sender;
            string id_noticia = Convert.ToString(clickedButton.ID).Replace('a', ' ');
            int numero_noticia = Convert.ToInt16(id_noticia.Trim());
            Response.Redirect("Editar_noticia.aspx?id_noticia="+numero_noticia);
        }

        private void Borrar_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton clickedButton = (ImageButton)sender;
            string id_noticia = Convert.ToString(clickedButton.ID);
            int numero_noticia = Convert.ToInt16(id_noticia.Trim());
            NovedadesControlador borrar = new NovedadesControlador();
            borrar.eliminar(numero_noticia, 2);
            Response.Redirect("Registro_novedades.aspx");
        }

        protected void btnpublicar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Publicar_novedad.aspx");
        }
    }
}