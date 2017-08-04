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
    class AutorData
    {

        private String connectionString;

        public AutorData(String connectionString)
        {
            this.connectionString = connectionString;
        }

        public LinkedList<Autor> GetAutores()
        {
            /*DIFERENTES MANERAS DE HACERLO*/
            //PASO 1
            SqlConnection conexion = new SqlConnection(connectionString);
            /*   SqlDataAdapter daGeneros = 
                 new SqlDataAdapter(
                     new SqlCommand("SELECT * FROM Genero ORDER BY nombre_genero", conexion));*/
            //PASO 2
            SqlDataAdapter daAutor = new SqlDataAdapter();
            daAutor.SelectCommand = new SqlCommand();
            daAutor.SelectCommand.Connection = conexion;
            daAutor.SelectCommand.CommandText = "SELECT * FROM Autor ORDER BY nombre_autor";

            //PASO 3
            DataSet dsAutor = new DataSet();
            //llenar el DataSet //el DataAdapter se encarga de abrir la conexion
            daAutor.Fill(dsAutor, "Autor");

            LinkedList<Autor> autores = new LinkedList<Autor>();
            //recorrer las filas de un DataTable en el DataSet
            foreach (DataRow fila in dsAutor.Tables["Autor"].Rows)
            {
                int idAutor = Int32.Parse(fila["id_autor"].ToString());
                String nombreAutor = fila["nombre_autor"].ToString();
                String primerApellido = fila["primer_apellido"].ToString();
                String segundoApellido = fila["segundo_apellido"].ToString();

                autores.AddLast(new Autor(idAutor, nombreAutor, primerApellido, segundoApellido));
            }//foreach
            return autores;
        }


    }
}
