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
    public partial class Registrar_Usuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btncrear_Click(object sender, EventArgs e)
        {

            bool error = false;
            string nombre = txtnombre.Text.Trim();
            string apellido = txtapellido.Text.Trim();
            string correo_electronico = txtcorreo.Text.Trim();
            string nombre_usuario = txtusuario.Text.Trim();
            string contraseña = txtcontraseña.Text.Trim();
            string contraseña_repetir = txtconfirmar.Text.Trim();
            string fecha_nacimiento = HiddenField1.Value;
            if (contraseña != contraseña_repetir)
            {
                error = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('Las contraseñas no son iguales');", true);
                
            }
            if (UsuarioControlador.Buscar(nombre_usuario).Tables["Usuario"].Rows.Count > 0)
            {
                error = true;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('El nombre de usuario ya existe');", true);
            }
            if (!error)
            {
                UsuarioControlador usuario_nuevo = new UsuarioControlador();
                usuario_nuevo.Almacenar(nombre, apellido, correo_electronico, nombre_usuario, contraseña, fecha_nacimiento);
                DataSet datos= UsuarioControlador.Buscar(nombre_usuario);
                
                Session["Usuario"] = Convert.ToString(datos.Tables["USUARIO"].Rows[0]["id_usuario"]);
                Session["Tipo_usuario"]= Convert.ToString(datos.Tables["USUARIO"].Rows[0]["tipo_usuario"]);
                txtnombre.Text = "";
                txtapellido.Text = "";
                txtcorreo.Text = "";
                txtusuario.Text = "";
                txtcontraseña.Text = "";
                Response.Redirect("Inicio.aspx");
            }




        }
    }
}