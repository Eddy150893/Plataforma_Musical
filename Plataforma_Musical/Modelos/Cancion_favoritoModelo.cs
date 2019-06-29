using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_Musical.Modelos
{
    public class Cancion_favoritoModelo:Conexion
    {
        int id_cancion_favorito, cancion, usuario;
        string tabla = "CANCION_FAVORITO";

        public int Cancion
        {
            get
            {
                return cancion;
            }

            set
            {
                cancion = value;
            }
        }

        public int Id_cancion_favorito
        {
            get
            {
                return id_cancion_favorito;
            }

            set
            {
                id_cancion_favorito = value;
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
            sql += " (cancion,usuario) values ";
            sql += "(";
            sql += "'" + Cancion + "',";
            sql += "'" + Usuario + "'";
            sql += ")";
            Escribir(sql);
        }

        public DataSet existe() {
            string sql = "Select * from " + tabla;
            sql += " Where cancion=" + Cancion;
            sql += " And usuario=" + Usuario;
            DataSet datos = Leer(sql, tabla);
            return datos;
        }

        public void borrar() {
            string sql = "Delete from " + tabla;
            sql += " Where cancion=" + Cancion;
            sql += " And usuario=" + Usuario;
            Escribir(sql);
        }

        public DataSet buscar() {
            string sql = "Select * from " + tabla;
            sql += " Where usuario=" + Usuario;
            DataSet canciones_favoritas = Leer(sql, tabla);
            return canciones_favoritas;
        }
    }
}