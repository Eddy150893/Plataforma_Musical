using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plataforma_Musical.Modelos
{
    public class Lista_cancionModelo:Conexion
    {
       private int id_lista_cancion, lista;
        private string tabla = "LISTA_CANCION";
        private List<int> lista_cancion;


        public int Id_lista_cancion
        {
            get{return id_lista_cancion;}
            set{ id_lista_cancion = value;}
        }

        public int Lista
        {
            get{return lista;}
            set{lista = value;}
        }

        public List<int> Lista_cancion
        {
            get{return lista_cancion;}
            set{lista_cancion = value;}
        }

        public void guardar()
        {
            for (int i = 0; i < Lista_cancion.Count; i++)
            {
                string sql = "Insert into " + tabla;
                sql += " (lista,cancion) values ";
                sql += "(" + Lista + "," + Lista_cancion[i] + ")";
                Escribir(sql);
            }
        }
        public void buscar(int id) { }

        public void actualizar() { }
    }
}