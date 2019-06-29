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
    public partial class Artistas_eliminados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArtistaControlador artista = new ArtistaControlador();
            DataSet eliminado = artista.artista_eliminados(2);
            for (int i = 0; i < eliminado.Tables["ARTISTA"].Rows.Count; i++) {
                TableRow tRow = new TableRow();

                TableCell numero = new TableCell();
                numero.Text = Convert.ToString(i);
                tRow.Cells.Add(numero);

                TableCell nombre = new TableCell();
                nombre.Text = Convert.ToString(eliminado.Tables["ARTISTA"].Rows[i]["nombre_artista"]);
                tRow.Cells.Add(nombre);

                TableCell año_formacion = new TableCell();
                año_formacion.Text = Convert.ToString(eliminado.Tables["ARTISTA"].Rows[i]["año_formacion"]);
                tRow.Cells.Add(año_formacion);

                TableCell pais = new TableCell();
                PaisControlador pais_artista = new PaisControlador();
                DataSet nombre_p = pais_artista.buscar(Convert.ToInt16(eliminado.Tables["ARTISTA"].Rows[i]["pais"]));
                pais.Text =Convert.ToString(nombre_p.Tables["PAIS"].Rows[0]["nombre_pais"]);
                tRow.Cells.Add(pais);

                TableCell fecha_eliminacion = new TableCell();
                fecha_eliminacion.Text = Convert.ToString(eliminado.Tables["ARTISTA"].Rows[i]["fecha_eliminacion"]);
                tRow.Cells.Add(fecha_eliminacion);
                tabla_artista_eliminados.Rows.Add(tRow);
            }
        }
    }
}