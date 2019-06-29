using Plataforma_Musical.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Plataforma_Musical.Controladores
{
    public class UsuarioControlador
    {
        public void Almacenar(string nombre, string apellido, string correo, string usuario,string contraseña,string fecha_nacimiento)
        {
            UsuarioModelo usuario_nuevo = new UsuarioModelo();
            usuario_nuevo.Nombre = nombre;
            usuario_nuevo.Apellido = apellido;
            usuario_nuevo.Correo_electronico = correo;
            usuario_nuevo.Fecha_nacimiento = fecha_nacimiento;
            usuario_nuevo.Nombre_usuario = usuario;
            usuario_nuevo.Contraseña = contraseña;
            usuario_nuevo.Estado_usuario = 1;
            usuario_nuevo.Tipo_usuario = 3;
            usuario_nuevo.guardar();
        }
        public DataSet index() {
            UsuarioModelo usuarios = new UsuarioModelo();
            DataSet datos_usuario = usuarios.Mostrar();
            return datos_usuario;
        }
        public Boolean existe(string nombre, string contraseña) {
            UsuarioModelo usuario = new UsuarioModelo();
            usuario.Nombre_usuario = nombre;
            usuario.Contraseña = contraseña;
            Boolean existe = false;
            if (usuario.Buscar().Tables["USUARIO"].Rows.Count > 0) {
                existe = true;
            }
            return existe;
        }

        public DataSet recuperarcontra(string fecha_nacimiento,string correo) {
            UsuarioModelo buscar = new UsuarioModelo();
            buscar.Fecha_nacimiento = fecha_nacimiento;
            buscar.Correo_electronico = correo;
            DataSet datosbuscar = new DataSet();
            datosbuscar = buscar.BuscarporFechaNacimientoyCorreo();
            return datosbuscar;
        }
        public static DataSet Buscar(string nombre) {
            UsuarioModelo buscar = new UsuarioModelo();
            buscar.Nombre_usuario = nombre;
            DataSet datosbuscar = new DataSet();
            datosbuscar = buscar.BuscarporUsuario();
            return datosbuscar;
         }

        public void Actualizar(int id_usuario,int tipo) {
            UsuarioModelo actualizar = new UsuarioModelo();
            actualizar.Id_usuario = id_usuario;
            actualizar.Tipo_usuario = tipo;
            actualizar.CambiarTipo();
        }
        public void eliminar(int id) {

        }

        public DataSet buscar(int id_usuario,int estado) {
            UsuarioModelo buscar = new UsuarioModelo();
            buscar.Id_usuario = id_usuario;
            buscar.Estado_usuario = estado;
            DataSet datos = buscar.BuscarporId();
            return datos;
        }
    }
}