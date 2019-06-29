using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Plataforma_Musical.Modelos
{
    public class Conexion
    {
        protected SqlConnection cn = new SqlConnection("Data Source=DESKTOP-O35ETAP\\SQLEXPRESS;Initial Catalog = Plataforma_Musical;Trusted_Connection=true;");
        public void Escribir(string sql) {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sql;
            cmd.Connection = cn;
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public DataSet Leer(string sql,string nombre_tabla) {
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sql;
            cmd.Connection = cn;

            DataSet datos = new DataSet();
            SqlDataAdapter adaptador = new SqlDataAdapter(cmd);
            adaptador.Fill(datos, nombre_tabla);
            return datos;
        }
    }
}