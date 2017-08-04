using LibreriaCeibaB43478.LibreriaCeibaB43478.Common.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaCeibaB43478.LibreriaCeibaB43478.DataAccess
{
    public class PublicadorData
    {
        private String connectionString;

        public PublicadorData(String connectionString)
        {
            this.connectionString = connectionString;
        }

        public LinkedList<Publicador> GetPublicadores()
        {
            /*DIFERENTES MANERAS DE HACERLO*/
            //PASO 1
            SqlConnection conexion = new SqlConnection(connectionString);
            /*   SqlDataAdapter daGeneros = 
                 new SqlDataAdapter(
                     new SqlCommand("SELECT * FROM Genero ORDER BY nombre_genero", conexion));*/
            //PASO 2
            SqlDataAdapter daPublicador = new SqlDataAdapter();
            daPublicador.SelectCommand = new SqlCommand();
            daPublicador.SelectCommand.Connection = conexion;
            daPublicador.SelectCommand.CommandText = "SELECT * FROM Publicador ORDER BY nombre_publicador";

            //PASO 3
            DataSet dsPublicador = new DataSet();
            //llenar el DataSet //el DataAdapter se encarga de abrir la conexion
            daPublicador.Fill(dsPublicador, "Publicador");

            LinkedList<Publicador> publicadores = new LinkedList<Publicador>();
            //recorrer las filas de un DataTable en el DataSet
            foreach (DataRow fila in dsPublicador.Tables["Publicador"].Rows)
            {
                int idPublicador = Int32.Parse(fila["id_publicador"].ToString());
                String nombrePublicador = fila["nombre_publicador"].ToString();
                String urlSitioWeb = fila["url_sitio_web"].ToString();

                publicadores.AddLast(new Publicador(idPublicador, nombrePublicador, urlSitioWeb));
            }//foreach
            return publicadores;
        }
    }

}
