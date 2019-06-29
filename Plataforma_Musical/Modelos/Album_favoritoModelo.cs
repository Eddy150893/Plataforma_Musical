using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_Musical.Modelos
{
    public class Album_favoritoModelo:Conexion
    {
        int id_album_favorito, album, usuario;
        string tabla = "ALBUM_FAVORITO";

        public int Album
        {
            get
            {
                return album;
            }

            set
            {
                album = value;
            }
        }

        public int Id_album_favorito
        {
            get
            {
                return id_album_favorito;
            }

            set
            {
                id_album_favorito = value;
            }
        }

        public int Usuario
        {
            get
            {
                return usuario;
            }

            set
            {
                usuario = value;
            }
        }
        public void guardar() {
            string sql = "Insert into " + tabla;
            sql += " (album,usuario) values ";
            sql += "(";
            sql += "'" + Album + "',";
            sql += "'" + Usuario + "'";
            sql += ")";
            Escribir(sql);
        }

        public DataSet existe()
        {
            string sql = "Select * from " + tabla;
            sql += " Where album=" + Album;
            sql += " And usuario=" + Usuario;
            DataSet datos = Leer(sql, tabla);
            return datos;
        }

        public void borrar() {
            string sql = "Delete from " + tabla;
            sql += " Where album=" + Album;
            sql += " And usuario=" + Usuario;
            Escribir(sql);
        }

        public DataSet buscar() {
            string sql = "Select * from " + tabla;
            sql += " Where usuario=" + Usuario;
            DataSet Albumes_favoritos = Leer(sql, tabla);
            return Albumes_favoritos;
        }

        public DataSet favoritos() {
            string sql = "select count(Distinct album) from " + tabla;
            DataSet albumes_favoritos = Leer(sql, tabla);
            return albumes_favoritos;
        }
    }
}