using Plataforma_Musical.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Plataforma_Musical.Controladores
{
    public class Lista_cancionControlador
    {
        public void Almacenar(int lista, List<int> canciones) {
            Lista_cancionModelo lista_Canciones = new Lista_cancionModelo();
            lista_Canciones.Lista_cancion = canciones;
            lista_Canciones.Lista = lista;
            lista_Canciones.guardar();
        }
    }
}