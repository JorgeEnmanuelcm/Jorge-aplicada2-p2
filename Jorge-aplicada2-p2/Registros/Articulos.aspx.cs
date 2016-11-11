using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Jorge_aplicada2_p2.Registros
{
    public partial class Articulos : System.Web.UI.Page
    {
        ArticuloClass Articulo = new ArticuloClass();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void DevolverDatos()
        {
            ArticuloIdTextBox.Text = Articulo.ArticuloId.ToString();
            DescripcionTextBox.Text = Articulo.Descripcion.ToString();
            ExistenciaTextBox.Text = Articulo.Exsitencia.ToString();
        }

        private void Limpiar()
        {
            ArticuloIdTextBox.Text = string.Empty;
            DescripcionTextBox.Text = string.Empty;
            ExistenciaTextBox.Text = string.Empty;
        }

        protected void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            int id;
            int.TryParse(ArticuloIdTextBox.Text, out id);
            if (id < 0)
            {
                Utilitarios.ShowToastr(this, "error", "Mensaje", "error");
            }
            else
            {
                if (Articulo.Buscar(id))
                {
                    DevolverDatos();
                }
                else
                {
                    Utilitarios.ShowToastr(this, "error", "Mensaje", "error");
                }
            }
        }

        protected void EliminarButton_Click(object sender, EventArgs e)
        {
            if (Articulo.Buscar(Articulo.ArticuloId))
            {
                if (Articulo.Eliminar())
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
    }
}