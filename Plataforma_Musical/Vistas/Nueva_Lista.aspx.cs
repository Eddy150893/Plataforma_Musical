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
    public partial class Nueva_Lista : System.Web.UI.Page
    {
        CheckBoxList lista;
        //int contador;
        //CheckBox check;
      
        protected void Page_Load(object sender, EventArgs e)
        {
            
            lista = new CheckBoxList();
            CancionControlador cancion = new CancionControlador();
            DataSet canciones = cancion.mostrar(1);
            lista.Visible = true;
            lista.DataSource = canciones.Tables["CANCION"].DefaultView;
            //lista.DataTextField = "nombre_cancion";
            lista.DataValueField = "id_cancion";
            lista.DataBind();
            int contador = 0;
            foreach (ListItem li in lista.Items)
            {
                
                string numero = Convert.ToString(contador+1);
                string nombre = Convert.ToString(canciones.Tables["CANCION"].Rows[contador]["nombre_cancion"]);
                string duracion = Convert.ToString(canciones.Tables["CANCION"].Rows[contador]["duracion"]);
                li.Text = numero+nombre+duracion;
                contador += 1;
            }
            lista.Visible = true;
            Canciones.Controls.Add(lista);
        }

        protected void btncrearlista_Click(object sender, EventArgs e)
        {
            
           
            List<int> l_canciones = new List<int>();
            
            foreach (ListItem li in lista.Items) {
                 if (li.Selected) {
                     l_canciones.Add(Convert.ToInt16(li.Selected));
                 }

             if (l_canciones.Count>0) {
                 Lista_reproduccionControlador nueva_lista = new Lista_reproduccionControlador();
                 string nombre_lista = txtnombrelista.Text.Trim();
                 int usuario = Convert.ToInt16(Session["Usuario"]);
                 nueva_lista.Almacenar(nombre_lista, usuario);

                 Lista_cancionControlador canciones_lista = new Lista_cancionControlador();
                 DataSet datos_ultima_l=nueva_lista.ultimo();
                 int id_lista = Convert.ToInt16(datos_ultima_l.Tables["LISTA_REPRODUCCION"].Rows[0]["id_lista_reproduccion"]);
                 canciones_lista.Almacenar(id_lista, l_canciones);   
             } else {
                 ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('La lista debe tener al menos una cancion');", true);
             }
              }
        }
    }
}