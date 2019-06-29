using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_Musical.Modelos
{
    public class PaisModelo:Conexion
    {
        private int id_pais;
        private string nombre_pais;
        private string tabla = "PAIS";
        public int Id_pais
        {
            get{ return id_pais;}
            set{id_pais = value;}
        }

        public string Nombre_pais
        {
            get{return nombre_pais;}
            set{nombre_pais = value;}
        }

        public void guardar() { }
        public void buscar(int id) { }

        public void actualizar() { }

        public DataSet obtenertodos() {
            string sql = "SELECT * from "+tabla;
            DataSet datos = Leer(sql, this.tabla);
            return datos;
        }

        public DataSet buscarporid()
        {
            string sql = "Select * From " + tabla;
            sql += " Where id_pais=" + Id_pais;
            DataSet datos_pais = Leer(sql, tabla);
            return datos_pais;
        }
    }
}