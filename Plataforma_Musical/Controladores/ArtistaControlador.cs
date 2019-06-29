using Plataforma_Musical.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_Musical.Controladores
{
    public class ArtistaControlador
    {
        public void Almacenar(string nombre_artista, int pais, string descripcion, string foto, int usuario, int estado, string red_social1, string red_social2, string red_social3, string red_social4, int año_formacion) {
            ArtistaModelo nuevo_artista = new ArtistaModelo();
            nuevo_artista.Nombre_artista = nombre_artista;
            nuevo_artista.Pais = pais;
            nuevo_artista.Descripcion = descripcion;
            nuevo_artista.Foto = foto;
            nuevo_artista.Usuario = usuario;
            nuevo_artista.Estado_artista = estado;
            nuevo_artista.Red_social1 = red_social1;
            nuevo_artista.Red_social2 = red_social2;
            nuevo_artista.Red_social3 = red_social3;
            nuevo_artista.Red_social4 = red_social4;
            nuevo_artista.Año_formacion = año_formacion;
            nuevo_artista.guardar();
        }

        public DataSet buscar(int id_usuario) {
            ArtistaModelo buscar = new ArtistaModelo();
            buscar.Usuario = id_usuario;
            DataSet datosbuscar = new DataSet();
            datosbuscar = buscar.buscarArtista();
            return datosbuscar;
        }
        public DataSet buscarartista(int id_artista)
        {
            ArtistaModelo buscar = new ArtistaModelo();
            buscar.Id_artista = id_artista;
            DataSet datosbuscar = new DataSet();
            datosbuscar = buscar.buscarArtistaporid();
            return datosbuscar;
        }

        public void editar(string nombre_artista, int pais, string descripccion, string foto, string facebook,string twitter, string youtube, string paginaweb,int año_formacion, int id_artista) {
            ArtistaModelo actualizar = new ArtistaModelo();
            actualizar.Nombre_artista = nombre_artista;
            actualizar.Pais = pais;
            actualizar.Descripcion = descripccion;
            actualizar.Foto = foto;
            actualizar.Red_social1 = facebook;
            actualizar.Red_social2 = twitter;
            actualizar.Red_social3 = youtube;
            actualizar.Red_social4 = paginaweb;
            actualizar.Año_formacion = año_formacion;
            actualizar.Id_artista = id_artista;
            actualizar.actualizar();
           
        }

        public void eliminar_artista(int id_artista) {
            ArtistaModelo borrar = new ArtistaModelo();
            borrar.Id_artista = id_artista;
            borrar.Estado_artista = 2;
            borrar.actualizar_estado();
           }
        public DataSet artista_eliminados(int estado) {
            ArtistaModelo artistas = new ArtistaModelo();
            artistas.Estado_artista = estado;
            DataSet eliminados = artistas.MostrarArtistasporEstado();
            return eliminados;
        }

        public DataSet busqueda(string nombre_artista) {
            ArtistaModelo busqueda_artistas = new ArtistaModelo();
            busqueda_artistas.Nombre_artista = nombre_artista;
            DataSet artistas = busqueda_artistas.busqueda();
            return artistas;
        }
    }
}
