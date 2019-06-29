using Plataforma_Musical.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_Musical.Controladores
{
    public class Genero_artistaControlador
    {
        public void almacenar(List<int> generos_artista,int artista) {
            Genero_artistaModelo generos = new Genero_artistaModelo();
            generos.Artista_generos = generos_artista;
            generos.Artista = artista;
            generos.guardar();
        }

        public DataSet Mostrar_generos_artista(int id_artista) {
            Genero_artistaModelo modelo = new Genero_artistaModelo();
            modelo.Artista = id_artista;
            DataSet datosmodelo=modelo.obtener();
            return datosmodelo;
        }

        public void Actualizar(List<int> generos_artista, int artista) {
            Genero_artistaModelo generos = new Genero_artistaModelo();
            generos.Artista_generos = generos_artista;
            generos.Artista = artista;
            generos.actualizar();
        }

        public DataSet buscar_Artistas(int id_genero) {
            Genero_artistaModelo artistas = new Genero_artistaModelo();
            artistas.Genero = id_genero;
            DataSet datos_artista_genero = artistas.buscar_artistas();
            return datos_artista_genero;
        }
    }
}