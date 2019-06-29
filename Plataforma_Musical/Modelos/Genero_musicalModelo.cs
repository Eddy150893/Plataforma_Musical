using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_Musical.Modelos
{
    public class Genero_musicalModelo:Conexion
    {
       private int id_genero;
       private string nombre_genero,imagen_genero;
       private string tabla = "GENERO_MUSICAL"; 
        public int Id_genero
        {
            get{ return id_genero;}
            set{id_genero = value;}
        }

        public string Nombre_genero
        {
            get{return nombre_genero;}
            set{nombre_genero = value;}
        }

        public string Imagen_genero
        {
            get
            {
                return imagen_genero;
            }

            set
            {
                imagen_genero = value;
            }
        }

        public void guardar() {
            string sql = "Insert into " + tabla;
            sql += " (nombre_genero,imagen_genero) values ";
            sql += " (";
            sql += "'" + Nombre_genero + "',";
            sql += "'" + Imagen_genero + "'";
            sql += ")";
            Escribir(sql);
        }
        public void buscar(int id) { }

        public void actualizar() { }
        public DataSet obtenertodos()
        {
            string sql = "SELECT * from " + this.tabla;
            DataSet datos = Leer(sql, this.tabla);
            return datos;
        }

    }
}