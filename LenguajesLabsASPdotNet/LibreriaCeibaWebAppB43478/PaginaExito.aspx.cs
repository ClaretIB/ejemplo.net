using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibreriaCeibaWebAppB43478
{
    public partial class PaginaExito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String Valor = Request.QueryString["Valor"];
            Label1.Text = Valor;
        }
    }
}