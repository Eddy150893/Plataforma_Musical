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
    public partial class Novedades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ImageButton imagen;
            Label titulo;
            Label contenido;
            Table tabla_n;
            
            NovedadesControlador novedades = new NovedadesControlador();
            DataSet noticias = novedades.Index(1);
            for (int i = 0; i < noticias.Tables["NOVEDADES"].Rows.Count; i++)
            {
                tabla_n = new Table();
                TableRow fila1 = new TableRow();
                TableRow fila2 = new TableRow();
                TableRow fila3 = new TableRow();
              

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

              
                Contenedor_novedades.Controls.Add(tabla_n);
            }
        }
    }
}