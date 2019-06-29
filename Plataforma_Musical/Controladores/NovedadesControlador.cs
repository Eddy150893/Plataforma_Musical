using Plataforma_Musical.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_Musical.Controladores
{
    public class NovedadesControlador
    {
        public void Almacenar(string titulo, string contenido, string foto_portada, int usuario,int estado) {
            NovedadesModelo novedad = new NovedadesModelo();
            novedad.Titulo = titulo;
            novedad.Contenido = contenido;
            novedad.Foto_portada = foto_portada;
            novedad.Usuario = usuario;
            novedad.Estado = estado;
            novedad.guardar();
        }
        public DataSet Index(int estado) {
            NovedadesModelo novedad = new NovedadesModelo();
            novedad.Estado = estado;
            DataSet novedades = novedad.mostrar();
            return novedades;
        }
        public void Actualizar(string titulo, string contenido,string foto_portada, int id_novedad) {
            NovedadesModelo novedad = new NovedadesModelo();
            novedad.Titulo = titulo;
            novedad.Contenido = contenido;
            novedad.Foto_portada = foto_portada;
            novedad.Id_novedad = id_novedad;
            novedad.actualizar();
        }
        public void eliminar(int id_novedad, int estado) {
            NovedadesModelo novedad = new NovedadesModelo();
            novedad.Id_novedad = id_novedad;
            novedad.Estado = estado;
            novedad.cambiar_estado();
        }

        public DataSet buscar(int id_novedad) {
            NovedadesModelo noticia = new NovedadesModelo();
            noticia.Id_novedad = id_novedad;
            DataSet datos_novedad = noticia.buscar();
            return datos_novedad;
        }
    }
}