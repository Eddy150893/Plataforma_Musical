using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_Musical.Modelos
{
    public class AlbumModelo:Conexion
    {
        private int id_album, artista, estado;
        private string titulo, reseña, foto_portada;
        private string fecha;
        private string tabla = "ALBUM";

        public int Id_album
        {
            get{return id_album;}
            set{ id_album = value;}
        }

        public int Artista
        {
            get{return artista;}
            set{artista = value;}
        }

        public int Estado
        {
            get{return estado;}
            set{estado = value;}
        }

        public string Titulo
        {
            get{return titulo;}
            set{titulo = value;}
        }

        public string Reseña
        {
            get{return reseña;}
            set{reseña = value;}
        }

        public string Foto_portada
        {
            get{return foto_portada;}
            set{foto_portada = value;}
        }

        public string Fecha
        {
            get{return fecha;}
            set{fecha = value;}
        }

        public void guardar() {
            string sql = "Insert into "+tabla;
                   sql += " (titulo,fecha,reseña,foto_portada,artista,estado) values";
                   sql += " ('"+Titulo+"','";
                   sql += Fecha+"','";
                   sql += Reseña + "','";
                   sql += Foto_portada + "',";
                   sql += Artista + ",";
                   sql += Estado + ")";
            Escribir(sql);
        }
        public DataSet buscar() {
            string sql = "Select * from " + tabla;
            sql += " Where artista=" + Artista;
            sql += " And estado=" + 1;
            DataSet datos_album= Leer(sql, tabla);
            return datos_album;
        }
        public DataSet buscarultimo() {
            string sql = "Select * From " + tabla;
            sql += " Where id_Album=(";
            sql += " Select Max(id_album) From " + tabla+")";
            DataSet datos_Album = Leer(sql, tabla);
            return datos_Album;
        }
        public DataSet buscarporid() {
            string sql = "Select * from " + tabla;
            sql += " Where id_Album=" + Id_album;
            DataSet datos_album = Leer(sql, tabla);
            return datos_album;
        }
        public void actualizar() {
            string sql = "Update " + tabla;
            sql += " Set titulo='" + Titulo + "',";
            sql += " foto_portada='" + Foto_portada + "',";
            sql += " reseña='" + Reseña + "',";
            sql += " fecha='" + Fecha + "' ";
            sql += " Where id_album=" + Id_album;
            Escribir(sql);
        }

        public void actualizar_estado() {
            string sql = "Update " + tabla;
            sql += " Set estado=" + Estado;
            sql += " Where id_album=" + Id_album;
            Escribir(sql);
        }

        public DataSet busqueda() {
            string sql = "Select * from " + tabla;
            sql += " Where titulo Like '%" + Titulo+"%'";
            DataSet albumes_encontrados = Leer(sql, tabla);
            return albumes_encontrados;
        }
    }
}