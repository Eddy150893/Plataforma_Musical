using Plataforma_Musical.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_Musical.Controladores
{
    public class AlbumControlador
    {
        public void almacenar(string titulo, string fecha, string reseña, string foto_portada, int artista) {
            AlbumModelo nuevo = new AlbumModelo();
            nuevo.Titulo = titulo;
            nuevo.Fecha = fecha;
            nuevo.Reseña = reseña;
            nuevo.Foto_portada = foto_portada;
            nuevo.Artista = artista;
            nuevo.Estado = 1;
            nuevo.guardar();
        }

        public DataSet buscar(int id_artista) {
            AlbumModelo buscar = new AlbumModelo();
            buscar.Artista = id_artista;
            DataSet datos_buscar = buscar.buscar();
            return datos_buscar;
        }
        public DataSet buscar()
        {
            AlbumModelo buscar = new AlbumModelo();
            DataSet datos_buscar = buscar.buscarultimo();
            return datos_buscar;
        }
        public DataSet buscarporid(int id_album)
        {
            AlbumModelo buscar = new AlbumModelo();
            buscar.Id_album = id_album;
            DataSet datos_buscar = buscar.buscarporid();
            return datos_buscar;
        }

        public void Editar(string titulo, string fecha, string reseña, string foto_portada, int id_album) {
            AlbumModelo editar = new AlbumModelo();
            editar.Titulo = titulo;
            editar.Fecha = fecha;
            editar.Reseña = reseña;
            editar.Foto_portada = foto_portada;
            editar.Id_album = id_album;
            editar.actualizar();
        }

        public void Eliminar_album(int id_album) {
            AlbumModelo borrar = new AlbumModelo();
            borrar.Id_album = id_album;
            borrar.Estado = 2;
            borrar.actualizar_estado();
        }

        public DataSet busqueda(string titulo) {
            AlbumModelo busqueda_albumes = new AlbumModelo();
            busqueda_albumes.Titulo = titulo;
            DataSet albumes = busqueda_albumes.busqueda();
            return albumes;
        }
    }
}