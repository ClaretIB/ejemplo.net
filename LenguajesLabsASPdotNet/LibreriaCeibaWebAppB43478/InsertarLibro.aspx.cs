using LibreriaCeibaB43478.LibreriaCeibaB43478.Business;
using LibreriaCeibaB43478.LibreriaCeibaB43478.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibreriaCeibaWebAppB43478
{
    public partial class InsertarLibro : System.Web.UI.Page
    {
        int codPublicador =2;

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

                AutorBusiness autorBusiness =
                     new AutorBusiness(WebConfigurationManager.ConnectionStrings["LibreriaCeibaBD"].ConnectionString);
                LinkedList<Autor> autores = autorBusiness.GetAutores();
                //como llenar el ListBox
                lb_autores.DataSource = autores;
                lb_autores.DataValueField = "idAutor";
                lb_autores.DataTextField = "nombreAutor";
                lb_autores.DataBind();

            }//if

        }

        public void Reload()
        {
            string currentPage = this.Page.Request.AppRelativeCurrentExecutionFilePath;
            Response.Redirect(currentPage);
        }

        
        protected void btn_insertarLibro_Click(object sender, EventArgs e)
        {
            LibroBusiness libroBusinness = new LibroBusiness(WebConfigurationManager.ConnectionStrings["LibreriaCeibaBD"].ToString());
            String tituloLibro = tb_titulo.Text;
            int ano = Int32.Parse(tb_ano.Text);
            String isbn = tb_isbn.Text;
            float precio = float.Parse(tb_precio.Text);
            int idpublicador = 2;
            Libro libro = new Libro();
            libro.TituloLibro = tituloLibro;
            libro.AnoPublicacion = ano;
            libro.Isbn = isbn;
            libro.CodPublicador = idpublicador;
            libro.Precio = precio;

            try
            {
                //libroBusinness.InsertarLibro(libro);
                Libro l = libroBusinness.InsertarLibro(libro);
                insertarLA(l.CodLibro);
                String Valor = "Titulo Libro = "+ tituloLibro+ " insertado con exito";
                Response.Redirect("PaginaExito.aspx?valor=" + Valor);
                Response.Write("<script type='text/javascript'>window.open('PaginaExito.aspx','cal','width=700,height=250,left=270,top=180');</script>");

                Reload();
            }
            catch (Exception exp)
            {
                throw exp;
            }
        }

        protected void ddl_publicadores_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label9.Text = ddl_publicadores.SelectedItem.Value;
        }

        protected void btn_agregar_Click(object sender, EventArgs e)
        {

            lb_autores2.Items.Add(lb_autores.SelectedItem);
        }

        protected void btn_extraer_Click(object sender, EventArgs e)
        {
            lb_autores2.Items.Remove(lb_autores2.SelectedItem);
        }

        private void insertarLA(int codLibro)
        {
            LibroBusiness libroBusinness = new LibroBusiness(WebConfigurationManager.ConnectionStrings["LibreriaCeibaBD"].ToString());
           // Console.WriteLine(""+codLibro);

            for (int i=0; i <= lb_autores2.Items.Count-1; i++)
            {

                int codAutor = Int32.Parse(lb_autores2. Items[i].Value);
                libroBusinness.InsertarLibroAutor(codLibro, codAutor);
            }
            
        }
    }
}