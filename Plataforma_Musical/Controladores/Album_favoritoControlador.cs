using Plataforma_Musical.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_Musical.Controladores
{
    public class Album_favoritoControlador
    {
        public void almacenar(int album, int usuario) {
            Album_favoritoModelo album_favorito = new Album_favoritoModelo();
            album_favorito.Album = album;
            album_favorito.Usuario = usuario;
            album_favorito.guardar();
        }

        public bool existe(int album, int usuario) {
            bool validar = false;
            Album_favoritoModelo album_favorito = new Album_favoritoModelo();
            album_favorito.Album = album;
            album_favorito.Usuario = usuario;
            DataSet datos = album_favorito.existe();
            if (datos.Tables["ALBUM_FAVORITO"].Rows.Count > 0) {
                validar = true;
            }
            return validar;
        }

        public void eliminar(int album, int usuario)
        {
            Album_favoritoModelo album_favorito = new Album_favoritoModelo();
            album_favorito.Album = album;
            album_favorito.Usuario = usuario;
            album_favorito.borrar();
        }

        public DataSet Obtenerfavoritos(int id_usuario) {
            Album_favoritoModelo favoritos = new Album_favoritoModelo();
            favoritos.Usuario = id_usuario;
            DataSet albumes_favoritos = favoritos.buscar();
            return albumes_favoritos;
        }
    }
}