using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_Musical.Modelos
{
    public class NovedadesModelo:Conexion
    {
        int id_novedad, usuario, estado;
        string titulo, contenido, foto_portada;
        string tabla = "NOVEDADES";
        public string Contenido
        {
            get
            {
                return contenido;
            }

            set
            {
                contenido = value;
            }
        }

        public string Foto_portada
        {
            get
            {
                return foto_portada;
            }

            set
            {
                foto_portada = value;
            }
        }

        public int Id_novedad
        {
            get
            {
                return id_novedad;
            }

            set
            {
                id_novedad = value;
            }
        }

        public string Titulo
        {
            get
            {
                return titulo;
            }

            set
            {
                titulo = value;
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

        public int Estado
        {
            get
            {
                return estado;
            }

            set
            {
                estado = value;
            }
        }

        public void guardar() {
            string sql = "Insert into " + tabla;
            sql += " (titulo,contenido,foto_portada,usuario,estado) values ";
            sql += " (";
            sql += "'" + Titulo + "',";
            sql += "'" + Contenido + "',";
            sql += "'" + foto_portada + "',";
            sql += Usuario + ",";
            sql += Estado;
            sql += ")";
            Escribir(sql);
        }

        public DataSet mostrar() {
            string sql = "Select * from " + tabla;
            sql += " Where estado=" + Estado;
            DataSet noticias = Leer(sql, tabla);
            return noticias;
        }

        public void cambiar_estado() {
            string sql = "Update " + tabla;
            sql += " Set estado=" + Estado;
            sql += " Where id_novedad=" + Id_novedad;
            Escribir(sql);
        }

        public void actualizar() {
            string sql = "Update " + tabla;
            sql += " Set titulo='" + Titulo + "',";
            sql += " contenido='" + Contenido + "',";
            sql += " foto_portada='" + Foto_portada + "'";
            sql += " Where id_novedad=" + Id_novedad;
            Escribir(sql);
        }

        public DataSet buscar() {
            string sql = "Select * from " + tabla;
            sql += " Where id_novedad=" + Id_novedad;
            DataSet novedad = Leer(sql, tabla);
            return novedad;
        }
    }
}