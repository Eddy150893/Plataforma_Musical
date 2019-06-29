using Plataforma_Musical.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_Musical.Controladores
{
    public class Lista_reproduccionControlador
    {
        public void Almacenar(string nombre_lista, int usuario) {
            Lista_reproduccionModelo nueva_lista = new Lista_reproduccionModelo();
            nueva_lista.Nombre_lista = nombre_lista;
            nueva_lista.Usuario = usuario;
            nueva_lista.guardar();
        }

        public DataSet ultimo() {
            Lista_reproduccionModelo ultimo = new Lista_reproduccionModelo();
            DataSet datos_ultima_lista = ultimo.buscarultimo();
            return datos_ultima_lista;
        }
    }
}