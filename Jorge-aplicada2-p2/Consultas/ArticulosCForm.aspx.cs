using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Jorge_aplicada2_p2.Consultas
{
    public partial class ArticulosCForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BuscarButton_Click(object sender, EventArgs e)
        {
            string Condicion = "";
            ArticuloClass Articulo = new ArticuloClass();
            if (string.IsNullOrWhiteSpace(BuscarTextBox.Text))
            {
                Condicion = "1=1";
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(BuscarTextBox.Text))
                {
                    Condicion = CamposDropDownList.SelectedValue + " like '%" + BuscarTextBox.Text + "%'";
                }
            }
            ConsultaGridView.DataSource = Articulo.Listado("Descripcion, Existencia", Condicion, "");
            ConsultaGridView.DataBind();
        }
    }
}