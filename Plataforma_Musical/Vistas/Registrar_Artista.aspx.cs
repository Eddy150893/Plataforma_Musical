using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Plataforma_Musical.Controladores;
using System.Data;

namespace Plataforma_Musical.Vistas
{
    public partial class Registrar_Artista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                PaisControlador paises = new PaisControlador();
                DataSet datospaises = new DataSet();
                datospaises = paises.Mostrar();
                selectpaises.DataSource = datospaises.Tables["PAIS"].DefaultView;
                // Asigna el valor a mostrar en el DropDownList
                selectpaises.DataTextField = "nombre_pais";
                // Asigna el valor del value en el DropDownList
                selectpaises.DataValueField = "id_pais";
                // Llena el DropDownList con los datos
                selectpaises.DataBind();

                Genero_musicalControlador generos = new Genero_musicalControlador();
                DataSet datosgeneros = new DataSet();
                datosgeneros = generos.Mostrar();
                ckbgeneros.DataSource = datosgeneros.Tables["GENERO_MUSICAL"].DefaultView;
                ckbgeneros.DataTextField = "nombre_genero";
                ckbgeneros.DataValueField = "id_genero";
                ckbgeneros.DataBind();

            }
            

            
           
            
        }

        protected void btnsubirconstancia_Click(object sender, EventArgs e)
        {
            Boolean correcto = false;
            if (fuFotoConstancia.HasFile) {
                string extensionArchivo = System.IO.Path.GetExtension(fuFotoConstancia.FileName).ToLower();
                string[] extensionesPermitidas = { ".png", ".jpg", ".jpeg" };
                for (int i = 0; i < extensionesPermitidas.Length; i++) {
                    if (extensionArchivo == extensionesPermitidas[i]) {
                        correcto = true;
                    }
                }
            }
            if (correcto == true) {
                ViewState["foto"] = System.IO.Path.GetFileName(fuFotoConstancia.FileName);
                fuFotoConstancia.SaveAs(Server.MapPath("~/images/Imagenes_artistas/") + ViewState["foto"]);
                Imagen_artista.ImageUrl = "~/images/Imagenes_artistas/" + ViewState["foto"];
                
            }
        }

        protected void btncrearartista_Click(object sender, EventArgs e)
        {
            string nombre_artista = txtnombreartista.Text.Trim();
            int pais =Convert.ToInt16(selectpaises.SelectedValue);
            string descripcion = txtdescripcion.Text.Trim();
            string foto = Imagen_artista.ImageUrl;
            int usuario = Convert.ToInt16(Session["Usuario"]);
            int estado_artista = 1;
            string red_social1 = txtfacebook.Text.Trim();
            string red_social2 = txtyoutube.Text.Trim();
            string red_social3 = txttuitter.Text.Trim();
            string red_social4 = txtpaginaweb.Text.Trim();
            
            int año_formacion = Convert.ToInt16(txtañoformacion.Text.Trim());
            ArtistaControlador nuevo = new ArtistaControlador();
            nuevo.Almacenar(nombre_artista, pais, descripcion, foto, usuario, estado_artista, red_social1, red_social2, red_social3, red_social4, año_formacion);
            UsuarioControlador actualizar = new UsuarioControlador();
            actualizar.Actualizar(usuario,2); 
            List<int> generos = new List<int>();
            DataSet datos=nuevo.buscar(usuario);
            int id_artista = Convert.ToInt16(datos.Tables["ARTISTA"].Rows[0]["id_artista"]);

            foreach (ListItem li in ckbgeneros.Items) {


                if (li.Selected) {
                    generos.Add(Convert.ToInt16(li.Value));
                }
                   
                
        }
            Genero_artistaControlador generos_Artista = new Genero_artistaControlador();
            generos_Artista.almacenar(generos, id_artista);
            string pagina = "info";
            Session["Artista"] = id_artista;
            Response.Redirect("artista/Informacion.aspx?id_artista="+id_artista+"&pagina="+pagina);
            
        }
    }
}