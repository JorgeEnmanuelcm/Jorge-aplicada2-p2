using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Jorge_aplicada2_p2
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ToastrButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Registros/Ventas.aspx");
        }

        protected void ArticulosLinkButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Registros/Articulos.aspx");
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Consultas/ArticulosCForm.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Consultas/VentasCForm.aspx");
        }
    }
}