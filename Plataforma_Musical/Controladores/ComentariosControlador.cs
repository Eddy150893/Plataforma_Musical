using Plataforma_Musical.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_Musical.Controladores
{
    public class ComentariosControlador
    {
        public void almacenar(int usuario, int album, string comentario) {
            ComentarioModelo comentarios = new ComentarioModelo();
            comentarios.Usuario = usuario;
            comentarios.Album = album;
            comentarios.Comentario = comentario;
            comentarios.guardar();
        }

        public DataSet mostrar(int id_album) {
            ComentarioModelo comentarios = new ComentarioModelo();
            comentarios.Album = id_album;
            DataSet datos_comentarios = comentarios.obtenerComentario();
            return datos_comentarios;
        }
    }
}