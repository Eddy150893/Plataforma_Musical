using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plataforma_Musical.Modelos
{
    public class Tipo_usuarioModelo:Conexion
    {
        private int id_tipo;
        private string nombre_tipo;
        private string tabla = "TIPO_USUARIO";
        public int Id_tipo
        {
            get{ return id_tipo;}
            set{id_tipo = value;}
        }

        public string Nombre_tipo
        {
            get{return nombre_tipo;}
            set{nombre_tipo = value;}
        }

        public void guardar() { }
        public void buscar(int id) { }

        public void actualizar() { }
    }
}