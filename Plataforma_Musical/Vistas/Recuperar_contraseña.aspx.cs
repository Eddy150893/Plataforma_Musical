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
    public partial class Recuperar_contraseña : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string fecha_nacimiento = campo_oculto_fecha.Value;
            string correo_electronico = txtcorreo.Text;
            UsuarioControlador recuperar = new UsuarioControlador();
            if (recuperar.recuperarcontra(fecha_nacimiento,correo_electronico).Tables["USUARIO"].Rows.Count>0) {
                DataSet datos = recuperar.recuperarcontra(fecha_nacimiento, correo_electronico);
                string contraseña= Convert.ToString(datos.Tables["Usuario"].Rows[0]["contraseña"]);
                lblcontraseña.Text = contraseña;
            } else {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertIns", "alert('No existe usuario con fecha de nacimiento y correo que corresponda');", true);
            }
        }
    }
}