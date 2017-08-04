
using LibreriaCeibaB43478.LibreriaCeibaB43478.Business;
using LibreriaCeibaB43478.LibreriaCeibaB43478.Common.Domain;
using LibreriaCeibaB43478.LibreriaCeibaB43478.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace LibreriaCeibaWebAppB43478
{
    public partial class LibrosPorPublicador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Page.IsPostBack == false)
            {
                
                PublicadorBusiness publicadorBusiness =
                     new PublicadorBusiness(WebConfigurationManager.ConnectionStrings["LibreriaCeibaBD"].ConnectionString);


                 LinkedList<Publicador> publicadores = publicadorBusiness.GetPublicadores();

                 //como llenar el DropDownList al agregar varios ListItem
                 foreach (Publicador publicadorActual in publicadores)
                 {//recordar ejemplo de que muestro el nombre pero mando el carne
                     ddl_publicadores.Items.Add(new ListItem(publicadorActual.NombrePublicador, publicadorActual.IdPublicador.ToString()));
                 }
                 //como llenar el ListBox
                 lbPublicadores.DataSource = publicadores;
                 lbPublicadores.DataTextField = "NombrePublicador";
                 lbPublicadores.DataValueField = "IdPublicador";
                 lbPublicadores.DataBind();

                ddl_publicadores.SelectedIndex = ddl_publicadores.Items.Count - 1;

                lbPublicadores.SelectedIndex = lbPublicadores.Items.Count - 1;


                
            }//if
        }

       

        protected void ddl_publicadores_SelectedIndexChanged(object sender, EventArgs e)
        {
            // lbl_test.Text = ddl_publicadores.SelectedItem.Value + " " + ddl_publicadores.SelectedItem.Text;

             LibroBusiness libroBusiness =
                     new LibroBusiness(WebConfigurationManager.ConnectionStrings["LibreriaCeibaBD"].ConnectionString);
               LinkedList<Libro> libros = libroBusiness.GetLibrosPorPublicador(Int32.Parse(ddl_publicadores.SelectedItem.Value));
            /*String aux = "";
            foreach (Libro libroActual in libros)
            {
                 aux += libroActual.CodLibro + " " + libroActual.TituloLibro + " " + libroActual.Precio+"\n  ";
            }
          Lb_libros.Text = aux;*/

            //Para pornerle nombre a las columnas 

            /*DataTable dt = new DataTable("Libros");
            dt.Columns.Add("codLibro");
            dt.Columns.Add("Titulo");

            foreach (Libro libroAux in libros)
            {
                DataRow dr = dt.NewRow();
                dr["codLibro"] = libroAux.CodLibro;
                dr["Titulo"] = libroAux.TituloLibro;

                dt.Rows.Add(dr);
            }*/

            /*puedo omitir el paso anterior y toma los nombres de la base de datos por medio de lista 
            y en lugar de dt pondria la lista para que funcione
            acordar ir a las propiedades y cambiar el evento(rayito )por pageLoad*/
            grv_autores.DataSource = libros;
            grv_autores.DataBind();


        }

        protected void grv_autores_SelectedIndexChanged(object sender, EventArgs e)
        {

            GridViewRow row = grv_autores.SelectedRow;
            String codigo =Convert.ToString(row.Cells[0].Text);

            LibroBusiness libroBusiness =
                    new LibroBusiness(WebConfigurationManager.ConnectionStrings["LibreriaCeibaBD"].ConnectionString);
            LinkedList<Autor> autores = libroBusiness.getAutoresPorLibro(Int32.Parse(codigo));

            gv_autor.DataSource = autores;
            gv_autor.DataBind();

        }

        protected void grv_autores_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow) {
                e.Row.Attributes.Add("onMouseOver", "this.style.cursor = 'pointer' ");
                e.Row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventRefere­nce(grv_autores, "select$"+e.Row.RowIndex.ToString()));
            } 

        }

 
    }
}