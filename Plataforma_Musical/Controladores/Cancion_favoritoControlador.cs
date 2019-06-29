using Plataforma_Musical.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_Musical.Controladores
{
    public class Cancion_favoritoControlador
    {
        public void almacenar(int cancion, int usuario)
        {
            Cancion_favoritoModelo cancion_favorito = new Cancion_favoritoModelo();
            cancion_favorito.Cancion = cancion;
            cancion_favorito.Usuario = usuario;
            cancion_favorito.guardar();
        }

        public bool existe(int cancion, int usuario)
        {
            bool validar = false;
            Cancion_favoritoModelo cancion_favorito = new Cancion_favoritoModelo();
            cancion_favorito.Cancion = cancion;
            cancion_favorito.Usuario = usuario;
            DataSet datos = cancion_favorito.existe();
            if (datos.Tables["CANCION_FAVORITO"].Rows.Count > 0)
            {
                validar = true;
            }
            return validar;
        }

        public void eliminar(int cancion, int usuario)
        {
            Cancion_favoritoModelo cancion_favorito = new Cancion_favoritoModelo();
            cancion_favorito.Cancion = cancion;
            cancion_favorito.Usuario = usuario;
            cancion_favorito.borrar();
        }

        public DataSet obtenerfavoritas(int id_usuario) {
            Cancion_favoritoModelo cancion = new Cancion_favoritoModelo();
            cancion.Usuario = id_usuario;
            DataSet canciones_favoritas = cancion.buscar();
            return canciones_favoritas;
        }
    }
}