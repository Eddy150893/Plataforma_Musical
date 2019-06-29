using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_Musical.Modelos
{
    public class Genero_artistaModelo:Conexion
    {
        private int  artista, genero;
        private string tabla = "GENERO_ARTISTA";
        private List<int> artista_generos;
        public int Artista
        {
            get{return artista;}
            set{artista = value;}
        }

        public int Genero
        {
            get{return genero;}
            set{genero = value;}
        }

        public List<int> Artista_generos
        {
            get{return artista_generos;}
            set{artista_generos = value;}
        }

        public void guardar() {
            for (int i = 0; i < Artista_generos.Count; i++) {
                string sql = "Insert into " + tabla;
                sql += " (artista,genero) values ";
                sql += "(" + Artista + "," + Artista_generos[i] + ")";
                Escribir(sql);
            }
        }
        public DataSet buscar_artistas() {
            string sql = "Select * from " + tabla;
            sql += " Where genero=" + Genero;
            DataSet datos_artista = Leer(sql, tabla);
            return datos_artista;
        }
        public DataSet obtener() {
            string sql = "Select * from " + tabla;
            sql += " Where artista=" + Artista;
            DataSet datos = Leer(sql, tabla);
            return datos;
        }
        public void actualizar() {
            string sql = "Delete from " + tabla;
            sql += " where artista=" + Artista;
            Escribir(sql);
            guardar();
        }

       
    }
}