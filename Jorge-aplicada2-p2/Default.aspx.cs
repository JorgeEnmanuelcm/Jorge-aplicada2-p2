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
            Utilitarios.ShowToastr(this, "Funciona correctamente", "Mensaje", "success");
        }
    }
}