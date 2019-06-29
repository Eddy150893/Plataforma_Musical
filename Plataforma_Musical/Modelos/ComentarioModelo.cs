using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_Musical.Modelos
{
    public class ComentarioModelo:Conexion
    {
        int id_comentario, usuario, album;
        string tabla = "COMENTARIOS";
        string comentario;
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

        public int Id_comentario
        {
            get
            {
                return id_comentario;
            }

            set
            {
                id_comentario = value;
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

        public string Comentario
        {
            get
            {
                return comentario;
            }

            set
            {
                comentario = value;
            }
        }

        public void guardar() {
            string sql = "Insert into " + tabla;
            sql += " (usuario,album,comentario) values ";
            sql += "(";
            sql += Usuario + ",";
            sql += Album + ",";
            sql += "'" + Comentario + "'";
            sql += ")";
            Escribir(sql);
        }

        public DataSet obtenerComentario() {
            string sql = "Select * from " + tabla;
            sql += " Where album=" + Album;
            DataSet comentario = Leer(sql, tabla);
            return comentario;
        }
    }
}