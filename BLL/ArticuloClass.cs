using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class ArticuloClass : ClaseMaestra
    {
        public int ArticuloId { get; set; }
        public string Descripcion { get; set; }
        public int Exsitencia { get; set; }

        public ArticuloClass()
        {
            this.ArticuloId = 0;
            this.Descripcion = "";
            this.Exsitencia = 0;
        }

        public ArticuloClass(int articuloid, string descripcion, int existencia)
        {
            this.ArticuloId = articuloid;
            this.Descripcion = descripcion;
            this.Exsitencia = existencia;
        }

        public override bool Buscar(int IdBuscado)
        {
            ConexionDB Conexion = new ConexionDB();
            DataTable dt = new DataTable();
            DataTable dtDetalle = new DataTable();
            try
            {
                dt = Conexion.ObtenerDatos(String.Format("select * from Articulos where ArticuloId=" + IdBuscado));
                if (dt.Rows.Count > 0)
                {
                    this.ArticuloId = (int)dt.Rows[0]["ArticuloId"];
                    this.Descripcion = dt.Rows[0]["Descripcion"].ToString();
                    this.Exsitencia = (int)dt.Rows[0]["Existencia"];
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt.Rows.Count > 0;
        }

        public override bool Editar()
        {
            throw new NotImplementedException();
        }

        public override bool Eliminar()
        {
            ConexionDB Conexion = new ConexionDB();
            bool retorno = false;
            try
            {
                Conexion.Ejecutar(String.Format("Delete From Articulos where ArticuloId = {0} ", this.ArticuloId));
                retorno = true;
            }
            catch (Exception ex) { throw ex; }
            return retorno;
        }

        public override bool Insertar()
        {
            throw new NotImplementedException();
        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            ConexionDB Conexion = new ConexionDB();
            string OrdenFinal = "";
            if (!Orden.Equals(""))
                OrdenFinal = " Order by " + Orden;
            return Conexion.ObtenerDatos("Select " + Campos + "From Articulos where " + Condicion + " " + OrdenFinal);
        }
    }
}

