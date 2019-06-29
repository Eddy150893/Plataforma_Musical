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
    public partial class Consulta_usuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioControlador usuarios = new UsuarioControlador();
            DataSet datos_usuario = usuarios.index();
            for (int i = 0;i<datos_usuario.Tables["USUARIO"].Rows.Count; i++) {
                TableRow tRow = new TableRow();
               
                TableCell numero = new TableCell();
                numero.Text = Convert.ToString(datos_usuario.Tables["USUARIO"].Rows[i]["id_usuario"]);
                tRow.Cells.Add(numero);

                TableCell nombre = new TableCell();
                nombre.Text = Convert.ToString(datos_usuario.Tables["USUARIO"].Rows[i]["nombre"]);
                tRow.Cells.Add(nombre);

                TableCell apellido = new TableCell();
                apellido.Text = Convert.ToString(datos_usuario.Tables["USUARIO"].Rows[i]["apellido"]);
                tRow.Cells.Add(apellido);

                TableCell usuario = new TableCell();
                usuario.Text = Convert.ToString(datos_usuario.Tables["USUARIO"].Rows[i]["nombre_usuario"]);
                tRow.Cells.Add(usuario);

                TableCell fecha_creacion = new TableCell();
                fecha_creacion.Text = Convert.ToString(datos_usuario.Tables["USUARIO"].Rows[i]["fecha_creacion"]);
                tRow.Cells.Add(fecha_creacion);

                TableCell estado = new TableCell();
                if (Convert.ToInt16(datos_usuario.Tables["USUARIO"].Rows[i]["estado_usuario"]) == 1)
                {
                    estado.Text = "Activo";
                    
                }
                else {
                    estado.Text = "Eliminado";
                }
                tRow.Cells.Add(estado);

                TableCell acciones = new TableCell();
                ImageButton imagen = new ImageButton();
                imagen.ID = Convert.ToString(datos_usuario.Tables["USUARIO"].Rows[i]["id_usuario"]);
                imagen.Width = 100 / 3;
                imagen.Height = 100 / 3;
                imagen.Visible = true;
                imagen.ImageUrl = "~/Vistas/images/botebasura.jpg";
                acciones.Controls.Add(imagen);

                
                ImageButton imagen1 = new ImageButton();
                imagen1.ID = Convert.ToString(datos_usuario.Tables["USUARIO"].Rows[i]["nombre_usuario"]);
                imagen1.Width = 100 / 3;
                imagen1.Height = 100 / 3;
                imagen1.Visible = true;
                imagen1.ImageUrl = "~/Vistas/images/engrane.png";
                acciones.Controls.Add(imagen1);
                tRow.Cells.Add(acciones);

                tabla_usuario.Rows.Add(tRow);
            }
        }
    }
}