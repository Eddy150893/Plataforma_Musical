using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_Musical.Modelos
{
    public class CancionModelo:Conexion
    {
       private int id_cancion, album, estado;
       private string nombre_cancion, duracion,url_cancion;
        private string tabla = "CANCION"; 
        public int Album
        {
            get{return album;}
            set{album = value;}
        }

        public string Duracion
        {
            get{return duracion;}
            set{duracion = value;}
        }

        public int Estado
        {
            get{return estado;}
            set{estado = value;}
        }

        public int Id_cancion
        {
            get{return id_cancion;}
            set{ id_cancion = value;}
        }

        public string Nombre_cancion
        {
            get{ return nombre_cancion;}
            set{nombre_cancion = value;}
        }

        public string Url_cancion
        {
            get{return url_cancion;}
            set{url_cancion = value;}
        }

        public void guardar() {
            string sql = "Insert into " + tabla;
            sql += " (nombre_cancion,duracion,album,estado,url_cancion) values";
            sql += " ('" + Nombre_cancion + "','";
            sql += Duracion + "',";
            sql += Album + ",";
            sql += Estado + ",'";
            sql += Url_cancion + "')";
            Escribir(sql);
        }
        public DataSet buscar() {
            string sql = "Select * from " + tabla;
            sql += " Where album=" + Album;
            sql += " And estado=" + 1;
            DataSet canciones = Leer(sql, tabla);
            return canciones;
        }

        public void actualizar() {
            string sql = "Update " + tabla;
            sql += " Set nombre_cancion='" + Nombre_cancion+"'";
            sql += " Where id_cancion=" + Id_cancion;
            Escribir(sql);
        }

        public void actualizar_estado() {
            string sql = "Update " + tabla;
            sql += " Set estado=" + Estado;
            sql += " Where id_cancion=" + Id_cancion;
            Escribir(sql);
        }

        public DataSet busqueda() {
            string sql = "Select * from " + tabla;
            sql += " Where nombre_cancion Like '%" + Nombre_cancion + "%'";
            DataSet canciones = Leer(sql, tabla);
            return canciones;
        }

        public DataSet mostrar() {
            string sql = "Select * from " + tabla;
            sql += " Where estado=" + Estado;
            DataSet canciones = Leer(sql, tabla);
            return canciones;
        }

        public DataSet obtener() {
            string sql = "Select * from " + tabla;
            sql += " Where id_cancion=" + Id_cancion;
            DataSet cancion = Leer(sql, tabla);
            return cancion;
        }

        public DataSet favoritos()
        {
            string sql = "select count(Distinct cancion) from " + tabla;
            DataSet canciones_favoritos = Leer(sql, tabla);
            return canciones_favoritos;
        }
    }
}