using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_Musical.Modelos
{
    public class ArtistaModelo:Conexion
    {
       private int id_artista, pais, usuario, estado_artista,año_formacion;
       private string nombre_artista, descripcion, foto, red_social1,
            red_social2, red_social3, red_social4, red_social5;
        private string tabla = "ARTISTA";
        private DateTime fecha_eliminacion = DateTime.Now;
        public int Año_formacion
        {
            get{return año_formacion;}
            set{año_formacion = value;}
        }

        public string Descripcion
        {
            get{return descripcion;}
            set{descripcion = value;}
        }

        public int Estado_artista
        {
            get{return estado_artista;}
            set{estado_artista = value;}
        }

        public string Foto
        {
            get{return foto;}
            set{foto = value;}
        }

        public int Id_artista
        {
            get{return id_artista;}
            set{id_artista = value;}
        }

        public string Nombre_artista
        {
            get{return nombre_artista;}
            set{nombre_artista = value;}
        }

        public int Pais
        {
            get{return pais;}
            set{pais = value;}
        }

        public string Red_social1
        {
            get{return red_social1;}
            set{red_social1 = value;}
        }

        public string Red_social2
        {
            get{return red_social2;}
            set{ red_social2 = value;}
        }

        public string Red_social3
        {
            get{return red_social3;}
            set{red_social3 = value;}
        }

        public string Red_social4
        {
            get{return red_social4;}
            set{red_social4 = value;}
        }

        public string Red_social5
        {
            get{return red_social5;}
            set{red_social5 = value;}
        }

        public int Usuario
        {
            get{return usuario;}
            set{usuario = value;}
        }

        public DateTime Fecha_eliminacion
        {
            get
            {
                return fecha_eliminacion;
            }

            set
            {
                fecha_eliminacion = value;
            }
        }

        public void guardar() {
            string sql = "Insert Into "+tabla+" (nombre_artista,pais,descripcion,foto,usuario,estado_artista,red_social1,red_social2,red_social3,red_social4,año_formacion)";
            sql += " values ('";
            sql +=Nombre_artista+"',";
            sql +=Pais+ ",'";
            sql +=Descripcion+ "','";
            sql += Foto+"',";
            sql += Usuario+",";
            sql += Estado_artista+",'";
            sql += Red_social1 + "','";
            sql += Red_social2 + "','";
            sql += Red_social3 + "','";
            sql += Red_social4 + "',";
            sql += Año_formacion + ")";
            Escribir(sql);
        }
        public DataSet buscarArtista() {
            string sql = "Select * From "+tabla;
            sql += " Where usuario=" + Usuario ;
            sql += " And estado_artista="+1;
            DataSet datos = Leer(sql, this.tabla);
            return datos;
        }

        public DataSet MostrarArtistasporEstado()
        {
            string sql = "Select * From " + tabla;
            sql += " Where estado_artista=" + Estado_artista;
            DataSet datos = Leer(sql, this.tabla);
            return datos;
        }
        public DataSet buscarArtistaporid()
        {
            Estado_artista = 1;
            string sql = "Select * From " + tabla;
            sql += " Where id_artista=" + Id_artista;
            sql += " And estado_artista=" + Estado_artista;
            DataSet datos = Leer(sql, this.tabla);
            return datos;
        }
        public void buscar(int id) { }

        public void actualizar() {
            string sql = "Update " + tabla;
            sql += " Set nombre_artista='" + Nombre_artista+"',";
            sql += " pais=" + Pais+",";
            sql += " descripcion='" + Descripcion + "',";
            sql += " foto='" + Foto + "',";
            sql += " red_social1='" + Red_social1 + "',";
            sql += " red_social2='" + Red_social2 + "',";
            sql += " red_social3='" + Red_social3 + "',";
            sql += " red_social4='" + Red_social4 + "',";
            sql += " año_formacion=" + Año_formacion + " ";
            sql += " Where id_artista=" + Id_artista + " ";

            Escribir(sql);

        }

        public void actualizar_estado() {
            string fecha_eliminacion_artista = fecha_eliminacion.ToString("dd/MM/yyyy");
            string sql = "Update " + tabla;
            sql += " Set estado_artista=" + Estado_artista+", ";
            sql += " fecha_eliminacion='" + fecha_eliminacion_artista+"'";
            sql += " Where id_artista=" + Id_artista;
            Escribir(sql);
        }

        public DataSet busqueda() {
            string sql = "Select * from " + tabla;
            sql += " Where nombre_artista Like '%" + Nombre_artista + "%'";
            DataSet artistas = Leer(sql, tabla);
            return artistas;
        }
    }
}