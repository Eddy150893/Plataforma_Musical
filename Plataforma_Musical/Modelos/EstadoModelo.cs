using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plataforma_Musical.Modelos
{
    public class EstadoModelo:Conexion
    {
        private int id_estado;
        private string nombre_estado;
        private string tabla = "ESTADO";
        public int Id_estado
        {
            get{return id_estado;}
            set{id_estado = value;}
        }

        public string Nombre_estado
        {
            get{return nombre_estado;}
            set{nombre_estado = value;}
        }
        public void guardar() { }
        public void buscar(int id) { }

        public void actualizar() { }
    }
}