using Plataforma_Musical.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_Musical.Controladores
{
    public class Genero_musicalControlador
    {
         public DataSet Mostrar()
        {
            Genero_musicalModelo genero = new Genero_musicalModelo();
            DataSet datos_genero = new DataSet();
            datos_genero = genero.obtenertodos();
            return datos_genero;
        }

        public void almacenar(string nombre_genero, string imagen_genero) {
            Genero_musicalModelo nuevo = new Genero_musicalModelo();
            nuevo.Nombre_genero = nombre_genero;
            nuevo.Imagen_genero = imagen_genero;
            nuevo.guardar();
        }
    }
}