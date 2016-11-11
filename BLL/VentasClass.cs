using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DAL;

namespace BLL
{
    public class VentasClass : ClaseMaestra
    {
        public int VentaId { get; set; }
        public string Fecha { get; set; }
        public int Monto { get; set; }
        public List<VentasDetalle> Detalle { get; set; }

        public VentasClass()
        {
            this.VentaId = 0;
            this.Fecha = "";
            this.Monto = 0;
            this.Detalle = new List<VentasDetalle>();
        }

        public VentasClass(int ventaid)
        {
            this.VentaId = ventaid;
        }

        public void AgregarArticulo(int ArticuloId, int Cantidad, int Precio)
        {
            this.Detalle.Add(new VentasDetalle(ArticuloId, Cantidad, Precio));
        }

        public override bool Buscar(int IdBuscado)
        {
            ConexionDB Conexion = new ConexionDB();
            DataTable dt = new DataTable();
            DataTable dtDetalle = new DataTable();
            try
            {
                dt = Conexion.ObtenerDatos(String.Format("select * from Ventas where VentaId=" + IdBuscado));
                if (dt.Rows.Count > 0)
                {
                    this.VentaId = (int)dt.Rows[0]["VentaId"];
                    this.Fecha = dt.Rows[0]["Fecha"].ToString();
                    this.Monto = (int)dt.Rows[0]["Monto"];
                    dtDetalle = Conexion.ObtenerDatos(String.Format("select * from VentasDetalle where VentaId=" + IdBuscado));
                    dtDetalle.Clear();
                    foreach (DataRow row in dtDetalle.Rows)
                    {
                        AgregarArticulo((int)dtDetalle.Rows[0]["ArticuloId"], (int)dtDetalle.Rows[0]["Cantidad"], (int)dtDetalle.Rows[0]["Precio"]);
                    }
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
            ConexionDB Conexion = new ConexionDB();
            bool Retorno = false;
            try
            {
                Retorno = Conexion.Ejecutar(String.Format("Update Ventas set Fecha='{0}', Monto={1} where VentaId= {2}", this.Fecha, this.Monto, this.VentaId));
                if (Retorno)
                {
                    Conexion.Ejecutar(String.Format("Delete from VentasDetalle Where VentaId= {0}", this.VentaId));
                    foreach (VentasDetalle var in this.Detalle)
                    {
                        Conexion.Ejecutar(string.Format("Insert into VentasDetalle(VentaId, ArticuloId, Cantidad, Precio) Values ({0},{1},{2},{3})", this.VentaId, var.ArticuloId, var.Cantidad, var.Precio));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Retorno;
        }

        public override bool Eliminar()
        {
            ConexionDB Conexion = new ConexionDB();
            bool Retorno = false;
            try
            {
                Retorno = Conexion.Ejecutar(String.Format("Delete from VentasDetalle Where VentaId= {0};" + "Delete from Ventas where VentaId= {0}", this.VentaId));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Retorno;
        }

        public override bool Insertar()
        {
            ConexionDB Conexion = new ConexionDB();
            int Retorno = 0;
            object Identity;
            try
            {
                Identity = Conexion.ObtenerValor(String.Format("Insert Into Ventas(Fecha, Monto) values('{0}', {1}) select @@IDENTITY", this.Fecha, this.Monto));
                int.TryParse(Identity.ToString(), out Retorno);
                this.VentaId = Retorno;
                if (Retorno > 0)
                {
                    foreach (VentasDetalle var in Detalle)
                    {
                        Conexion.Ejecutar(String.Format("Insert into VentasDetalle(VentaId, ArticuloId, Cantidad, Precio) Values ({0}, {1}, {2}, {3})", this.VentaId, var.ArticuloId, var.Cantidad, var.Precio));
                        Conexion.Ejecutar(string.Format("Update Articulos set Existencia = Existencia -" + var.Cantidad + "where ArticuloId=" + var.ArticuloId));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Retorno > 0;
        }

        public override DataTable Listado(string Campos, string Condicion, string Orden)
        {
            ConexionDB Conexion = new ConexionDB();
            string ordenar = "";
            if (!Orden.Equals(""))
                ordenar = " orden by  " + Orden;
            return Conexion.ObtenerDatos(("Select " + Campos + " from Ventas where " + Condicion + ordenar));
        }
    }
}
