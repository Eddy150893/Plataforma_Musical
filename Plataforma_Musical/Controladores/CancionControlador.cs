using Plataforma_Musical.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_Musical.Controladores
{
    public class CancionControlador
    {
        public void almacenar(string nombre_cancion, string duracion, int album,  string url_cancion) {
            CancionModelo nueva_cancion = new CancionModelo();
            nueva_cancion.Nombre_cancion = nombre_cancion;
            nueva_cancion.Duracion = duracion;
            nueva_cancion.Album = album;
            nueva_cancion.Estado = 1;
            nueva_cancion.Url_cancion = url_cancion;
            nueva_cancion.guardar();
        }

        public DataSet buscarcanciones(int id_album) {
            CancionModelo buscar = new CancionModelo();
            buscar.Album = id_album;
            DataSet canciones_album = buscar.buscar();
            return canciones_album;
        }

        public void eliminar_cancion(int id_cancion) {
            CancionModelo eliminar = new CancionModelo();
            eliminar.Id_cancion = id_cancion;
            eliminar.Estado = 2;
            eliminar.actualizar_estado();
        }

        public DataSet busqueda(string nombre_cancion) {
            CancionModelo busqueda_cancion = new CancionModelo();
            busqueda_cancion.Nombre_cancion = nombre_cancion;
            DataSet canciones = busqueda_cancion.busqueda();
            return canciones;
        }

        public DataSet mostrar(int estado) {
            CancionModelo canciones_mostrar = new CancionModelo();
            canciones_mostrar.Estado = estado;
            DataSet canciones = canciones_mostrar.mostrar();
            return canciones;
        }

        public DataSet buscarporId(int id_cancion) {
            CancionModelo cancion = new CancionModelo();
            cancion.Id_cancion = id_cancion;
            DataSet datos_cancion = cancion.obtener();
            return datos_cancion;
        }
    }
}