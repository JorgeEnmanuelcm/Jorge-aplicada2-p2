using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;

namespace Jorge_aplicada2_p2.Registros
{
    public partial class Ventas : System.Web.UI.Page
    {
        VentasClass Venta = new VentasClass();
        DataTable dt = new DataTable();
        ArticuloClass Articulo = new ArticuloClass();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ArticuloIdDropDownList.DataSource = Articulo.Listado(" * ", "1=1", "");
                ArticuloIdDropDownList.DataTextField = "Descripcion";
                ArticuloIdDropDownList.DataValueField = "ArticuloId";
                ArticuloIdDropDownList.DataBind();
                FechaTextBox.Text = DateTime.Now.ToString("dd/MM/yyyy");
                dt.Columns.AddRange(new DataColumn[3] { new DataColumn("ArticuloId"), new DataColumn("Cantidad"), new DataColumn("Precio") });
                ViewState["VentasClass"] = dt;
            }
        }

        private void Limpiar()
        {
            MontoTextBox.Text = string.Empty;
            CantidadTextBox.Text = string.Empty;
            PrecioTextBox.Text = string.Empty;
            VentasGridView.DataSource = string.Empty;
            VentasGridView.DataBind();
        }

        private bool ObtenerDatos()
        {
            bool Retorno = true;
            int id;
            int.TryParse(VentaIdTextBox.Text, out id);
            int monto;
            int.TryParse(MontoTextBox.Text, out monto);
            if (id > 0)
            {
                Venta.VentaId = id;
            }
            else
            {
                Retorno = false;
            }
            if (FechaTextBox.Text.Length > 0)
            {
                Venta.Fecha = FechaTextBox.Text;
            }
            else
            {
                Retorno = false;
            }
            if (MontoTextBox.Text.Length > 0)
            {
                Venta.Monto = monto;
            }
            else
            {
                Retorno = false;
            }
            if (VentasGridView.Rows.Count > 0)
            {
                foreach (GridViewRow var in VentasGridView.Rows)
                {
                    Venta.AgregarArticulo(Convert.ToInt32(var.Cells[0].Text), Convert.ToInt32(var.Cells[1].Text), Convert.ToInt32(var.Cells[2].Text));                
                }
            }
            else
            {
                Retorno = false;
            }
            return Retorno;
        }

        private void DevolverDatos()
        {
            VentaIdTextBox.Text = Venta.VentaId.ToString();
            FechaTextBox.Text = Venta.Fecha.ToString();
            MontoTextBox.Text = Venta.Monto.ToString();
            foreach (var item in Venta.Detalle)
            {
                dt = (DataTable)ViewState["VentasClass"];
                dt.Rows.Add(item.ArticuloId, item.Cantidad, item.Precio);
                ViewState["VentasClass"] = dt;
                VentasGridView.DataSource = (DataTable)ViewState["VentasClass"];
                VentasGridView.DataBind();
                CantidadTextBox.Text = string.Empty;
                PrecioTextBox.Text = string.Empty;
                VentasGridView.DataSource = string.Empty;

            }
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void AgregarButton_Click(object sender, EventArgs e)
        {
            int cant;
            int Pre;
            int.TryParse(CantidadTextBox.Text, out cant);
            int.TryParse(PrecioTextBox.Text, out Pre);
            int mont;
            int.TryParse(MontoTextBox.Text, out mont);
            DataTable dt = (DataTable)ViewState["VentasClass"];
            dt.Rows.Add(ArticuloIdDropDownList.SelectedValue, CantidadTextBox.Text, PrecioTextBox.Text);
            ViewState["VentasClass"] = dt;
            VentasGridView.DataSource = dt;
            VentasGridView.DataBind();
            CantidadTextBox.Text = string.Empty;
            PrecioTextBox.Text = string.Empty;
            MontoTextBox.Text = (mont + (cant * Pre)).ToString();          
        }

        protected void GuardarButton_Click(object sender, EventArgs e)
        {
            if (VentaIdTextBox.Text.Length == 0)
            {
                ObtenerDatos();
                if (Venta.Insertar())
                {
                    Limpiar();
                    Utilitarios.ShowToastr(this, "bien", "Mensaje", "success");
                }
                else
                {
                    Utilitarios.ShowToastr(this, "error", "Mensaje", "error");
                }
            }
            if (VentaIdTextBox.Text.Length > 0)
            {
                ObtenerDatos();
                if (Venta.Editar())
                {
                    Limpiar();
                    Utilitarios.ShowToastr(this, "bien", "Mensaje", "success");
                }
                else
                {
                    Utilitarios.ShowToastr(this, "error", "Mensaje", "error");
                }
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            ObtenerDatos();
            if (Venta.Buscar(Venta.VentaId))
            {
                if (Venta.Eliminar())
                {
                    Limpiar();
                    Utilitarios.ShowToastr(this, "bien", "Mensaje", "success");
                }
                else
                {
                    Utilitarios.ShowToastr(this, "error", "Mensaje", "error");
                }
            }
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            int id;
            int.TryParse(VentaIdTextBox.Text, out id);
            if (id < 0)
            {
                Utilitarios.ShowToastr(this, "error", "Mensaje", "error");
            }
            else
            {
                if (Venta.Buscar(id))
                {
                    DevolverDatos();
                }
                else
                {
                    Utilitarios.ShowToastr(this, "error", "Mensaje", "error");
                }
            }
        }
    }
}