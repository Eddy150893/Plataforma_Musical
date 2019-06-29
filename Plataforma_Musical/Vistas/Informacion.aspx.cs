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
    public partial class Informacion : System.Web.UI.Page
    {
        int id_artista;
        protected void Page_Load(object sender, EventArgs e)
        {
            id_artista = Convert.ToInt16(Session["Artista"]); 
            if (!IsPostBack)
            {

                PaisControlador paises = new PaisControlador();
                DataSet datospaises = new DataSet();
                datospaises = paises.Mostrar();
                slcpais.DataSource = datospaises.Tables["PAIS"].DefaultView;
                // Asigna el valor a mostrar en el DropDownList
                slcpais.DataTextField = "nombre_pais";
                // Asigna el valor del value en el DropDownList
                slcpais.DataValueField = "id_pais";
                // Llena el DropDownList con los datos
                slcpais.DataBind();

                Genero_musicalControlador generos = new Genero_musicalControlador();
                DataSet datosgeneros = new DataSet();
                datosgeneros = generos.Mostrar();
                ckbgeneros.DataSource = datosgeneros.Tables["GENERO_MUSICAL"].DefaultView;
                ckbgeneros.DataTextField = "nombre_genero";
                ckbgeneros.DataValueField = "id_genero";
                ckbgeneros.DataBind();

               // int id_artista = Convert.ToInt16(Session["Artista"]);
                ArtistaControlador actualizar_eliminar = new ArtistaControlador();
                DataSet datos = actualizar_eliminar.buscarartista(id_artista);
                txtnombreartista.Text = Convert.ToString(datos.Tables["ARTISTA"].Rows[0]["nombre_artista"]);
                txtañoformacion.Text = Convert.ToString(datos.Tables["ARTISTA"].Rows[0]["año_formacion"]);
                slcpais.SelectedIndex = Convert.ToInt16(datos.Tables["ARTISTA"].Rows[0]["pais"])-1;
                txtdescripcion.Text = Convert.ToString(datos.Tables["ARTISTA"].Rows[0]["descripcion"]);
                Imagen_artista.ImageUrl = Convert.ToString(datos.Tables["ARTISTA"].Rows[0]["foto"]);
                txtfacebook.Text = Convert.ToString(datos.Tables["ARTISTA"].Rows[0]["red_social1"]);
                txttwitter.Text = Convert.ToString(datos.Tables["ARTISTA"].Rows[0]["red_social2"]);
                txtyoutube.Text = Convert.ToString(datos.Tables["ARTISTA"].Rows[0]["red_social3"]);
                txtpaginaweb.Text = Convert.ToString(datos.Tables["ARTISTA"].Rows[0]["red_social4"]);
                Genero_artistaControlador generos_artista = new Genero_artistaControlador();
                DataSet datos_generos_artista = generos_artista.Mostrar_generos_artista(id_artista);
                //foreach (DataRow row in datos_generos_artista.Tables["GENERO_ARTISTA"].Rows)
              
                    foreach (ListItem li in ckbgeneros.Items)
                    {
                        for(int i = 0; i < datos_generos_artista.Tables["GENERO_ARTISTA"].Rows.Count; i++)
                    {
                        if (li.Value==Convert.ToString(datos_generos_artista.Tables["GENERO_ARTISTA"].Rows[i]["genero"])) {
                            li.Selected = true;
                        }   
                    } 
                           
                        
                    }
               
            }

           
            

            
        }

        protected void btnsubirconstancia_Click(object sender, EventArgs e)
        {
            Boolean correcto = false;
            if (fuFotoConstancia.HasFile)
            {
                string extensionArchivo = System.IO.Path.GetExtension(fuFotoConstancia.FileName).ToLower();
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
                ViewState["foto"] = System.IO.Path.GetFileName(fuFotoConstancia.FileName);
                fuFotoConstancia.SaveAs(Server.MapPath("~/images/Imagenes_artistas/") + ViewState["foto"]);
                Imagen_artista.ImageUrl = "~/images/Imagenes_artistas/" + ViewState["foto"];

            }
        }

        protected void btnactualizar_Click(object sender, EventArgs e)
        {
            string nombre_artista1 = txtnombreartista.Text.Trim();
            int pais1 = Convert.ToInt16(slcpais.SelectedValue);
            string descripcion1 = txtdescripcion.Text.Trim();
            string foto1 = Imagen_artista.ImageUrl;
            string facebook1 = txtfacebook.Text.Trim();
            string twitter1 = txttwitter.Text.Trim();
            string youtube1 = txtyoutube.Text.Trim();
            string paginaweb1 = txtpaginaweb.Text.Trim();
            int año_formacion1 = Convert.ToInt16(txtañoformacion.Text.Trim());
            int id_artista1 = Convert.ToInt16(Session["Artista"]);
            ArtistaControlador actualizar = new ArtistaControlador();
            txtnombreartista.Text = "";
            txtdescripcion.Text = "";
            txtfacebook.Text = "";
            txttwitter.Text = "";
            txtyoutube.Text = "";
            txtpaginaweb.Text = "";
            txtañoformacion.Text = "";
            slcpais.SelectedValue = null;
            //checkboxlist.ClearSelection()
            actualizar.editar(nombre_artista1, pais1, descripcion1, foto1, facebook1, twitter1, youtube1, paginaweb1, año_formacion1, id_artista1);
            Genero_artistaControlador generos_Artista = new Genero_artistaControlador();
            List<int> generos = new List<int>();
            foreach (ListItem li in ckbgeneros.Items)
            {
                if (li.Selected)
                {
                    generos.Add(Convert.ToInt16(li.Value));
                }
            }
            generos_Artista.Actualizar(generos, id_artista1);
        }

        protected void btneliminar_Click(object sender, EventArgs e)
        {
            AlbumControlador album_b = new AlbumControlador();
            DataSet albumes_borrar=album_b.buscar(id_artista);
            for (int i = 0; i < albumes_borrar.Tables["ALBUM"].Rows.Count; i++) {
                CancionControlador cancion_b = new CancionControlador();
                DataSet cancion_borrar = cancion_b.buscarcanciones(Convert.ToInt16(albumes_borrar.Tables["ALBUM"].Rows[i]["id_Album"]));
                for (int j = 0; j < cancion_borrar.Tables["CANCION"].Rows.Count; j++) {
                    cancion_b.eliminar_cancion(Convert.ToInt16(cancion_borrar.Tables["CANCION"].Rows[j]["id_cancion"]));
                }
                album_b.Eliminar_album(Convert.ToInt16(albumes_borrar.Tables["ALBUM"].Rows[i]["id_album"]));
            }
            ArtistaControlador artista_b = new ArtistaControlador();
            artista_b.eliminar_artista(id_artista);
            UsuarioControlador usuario_c = new UsuarioControlador();
            usuario_c.Actualizar(Convert.ToInt16(Session["Usuario"]),3);
            Session["Artista"] = null;
            Session["Tipo_usuario"] = 3;
            Response.Redirect("Inicio.aspx");
        }
    }
}