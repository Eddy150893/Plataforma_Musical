using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Plataforma_Musical.Modelos
{
    public class UsuarioModelo:Conexion
    {
        private int id_usuario, estado_usuario, tipo_usuario;
        private string nombre_usuario, contraseña,nombre, apellido, correo_electronico;
        private DateTime fecha_creacion=DateTime.Now;
        
        string fecha_nacimiento;
        private  string tabla = "USUARIO";
        public string Apellido
        {
            get{return apellido;}
            set{apellido = value;}
        }

        public string Contraseña
        {
            get{return contraseña;}
            set{contraseña = value;}
        }

        public int Estado_usuario
        {
            get{return estado_usuario;}
            set{estado_usuario = value;}
        }

        public int Id_usuario
        {
            get{return id_usuario;}
            set {id_usuario = value;}
        }

        public string Nombre
        {
            get{return nombre;}
            set{nombre = value;}
        }

        public string Nombre_usuario
        {
            get{return nombre_usuario;}
            set{nombre_usuario = value;}
        }

        public int Tipo_usuario
        {
            get{return tipo_usuario;}
            set{tipo_usuario = value;}
        }

        public DateTime Fecha_creacion
        {
            get{return fecha_creacion;}
            set{fecha_creacion = value;}
        }

        public string Correo_electronico
        {
            get { return correo_electronico; }
            set {correo_electronico = value;}
        }

        public string Fecha_nacimiento
        {
            get{ return fecha_nacimiento;}
            set{ fecha_nacimiento = value;}
        }

        public void guardar()
        {
            string fecha_creacion_usuario = fecha_creacion.ToString("dd/MM/yyyy");
            string sql = "Insert into USUARIO (nombre_usuario,contraseña,estado_usuario,tipo_usuario,nombre,apellido,correo_electronico,fecha_nacimiento,fecha_creacion)";
            sql += "values ('";
            sql += this.nombre_usuario + "','";
            sql += this.contraseña + "',";
            sql += this.estado_usuario + ",";
            sql += this.tipo_usuario + ",'";
            sql += this.nombre + "','";
            sql += this.apellido + "','";
            sql += this.correo_electronico + "','";
            sql += this.fecha_nacimiento + "','";
            sql += fecha_creacion_usuario + "')";
            Escribir(sql);
        }

        public void actualizar() {
            
            string sql = "Update USUARIO ";
            sql += "Set nombre_usuario='" + this.Nombre_usuario+"',";
            sql += "tipo_usuario=" + this.Tipo_usuario + ",";
            sql += "contraseña=" + this.contraseña + ",";
            sql += "nombre="+this.Nombre+",";
            sql += "apellido="+this.Apellido+",";
            sql += "correo_electronico="+this.Correo_electronico+",";
            sql += "fecha_nacimiento=" + this.fecha_nacimiento;
            sql += " Where id_usuario=" + this.Id_usuario;

        }
        public DataSet Buscar()
        {
            
            string sql = "Select * From USUARIO ";
            sql += " Where nombre_usuario='" + this.Nombre_usuario + "'";
            sql += " And contraseña='" + this.contraseña + "'";
            DataSet datos=Leer(sql, this.tabla);
            return datos;
        }

        public DataSet BuscarporUsuario()
        {

            string sql = "Select * From USUARIO ";
            sql += "Where nombre_usuario='" + this.Nombre_usuario + "'";
            DataSet datos = Leer(sql, this.tabla);
            return datos;
        }

        public DataSet BuscarporFechaNacimientoyCorreo()
        {

            string sql = "Select * From USUARIO ";
            sql += "Where fecha_nacimiento='" + this.Fecha_nacimiento + "' ";
            sql += "And correo_electronico='" + this.Correo_electronico + "'";
            DataSet datos = Leer(sql, this.tabla);
            return datos;
        }

        public void CambiarEstado() {
            string sql = "Update " + tabla;
            sql += " set estado_usuario=" +Estado_usuario;
            sql += " Where id_usuario=" + Id_usuario;
            Escribir(sql);
        }

        public void CambiarTipo()
        {
            string sql = "Update " + tabla;
            sql += " set tipo_usuario=" + Tipo_usuario;
            sql += " Where id_usuario=" + Id_usuario;
            Escribir(sql);
        }

        public DataSet BuscarporId()
        {
            string sql = "Select * From " + tabla;
            sql += " Where id_usuario="+Id_usuario;
            sql += " And estado_usuario=" + Estado_usuario;
            DataSet datos_usuario = Leer(sql, tabla);
            return datos_usuario;
        }

        public DataSet Mostrar() {
            string sql = "Select * from " + tabla;
            DataSet todos_usuarios = Leer(sql, tabla);
            return todos_usuarios;
        }
    }
}