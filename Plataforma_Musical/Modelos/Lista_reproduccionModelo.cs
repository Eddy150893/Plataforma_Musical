using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_Musical.Modelos
{
    public class Lista_reproduccionModelo:Conexion
    {
       private int id_lista_reproduccion, usuario;
       private string nombre_lista;
       private string tabla = "LISTA_REPRODUCCION";
        public int Id_lista_reproduccion
        {
            get{return id_lista_reproduccion;}
            set{id_lista_reproduccion = value;}
        }

        public string Nombre_lista
        {
            get{return nombre_lista;}
            set{nombre_lista = value;}
        }

        public int Usuario
        {
            get{return usuario;}
            set{usuario = value;}
        }

        public void guardar() {
            string sql = "Insert Into " + tabla;
            sql += " (nombre_lista,usuario) values ";
            sql += " (";
            sql += "'" + Nombre_lista + "',";
            sql += Usuario;
            sql += ")";
            Escribir(sql);
        }
        public void buscar(int id) { }
        public DataSet buscarultimo() {
            string sql = "Select * From " + tabla;
            sql += " Where id_lista_reproduccion=(";
            sql += " Select Max(id_lista_reproduccion) From " + tabla + ")";
            DataSet datos_Lista = Leer(sql, tabla);
            return datos_Lista;
        }
        public void actualizar() { }
    }
}