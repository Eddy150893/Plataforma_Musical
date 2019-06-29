using Plataforma_Musical.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Plataforma_Musical.Controladores
{
    public class PaisControlador
    {
        public DataSet Mostrar() {
            PaisModelo pais = new PaisModelo();
            DataSet datos_pais = new DataSet();
            datos_pais = pais.obtenertodos();
            return datos_pais;
        }

        public DataSet buscar(int id_pais) {
            PaisModelo pais = new PaisModelo();
            pais.Id_pais = id_pais;
            DataSet nombre_pais = pais.buscarporid();
            return nombre_pais;
        }
    }
}