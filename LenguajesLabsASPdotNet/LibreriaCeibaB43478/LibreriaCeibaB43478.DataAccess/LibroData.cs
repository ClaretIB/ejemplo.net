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
    public class LibroData
    {
            private String cadenaConexion;
            private LinkedList<Libro> libros;
            private LinkedList<Autor> autores;

            public LibroData(String cadenaConexion)
            {
                libros = new LinkedList<Libro>();
                autores = new LinkedList<Autor>();
                this.cadenaConexion = cadenaConexion;
            }

            public LinkedList<Libro> GetLibrosPorPublicador(int idPublicador)
            {
                //Paso 1
                SqlConnection conexion = new SqlConnection(cadenaConexion);
                SqlCommand cmdLibro = new SqlCommand("SELECT *  from Libro inner join Publicador on Publicador.id_publicador = Libro.id_publicador where Libro.id_publicador = "+idPublicador, conexion);
                conexion.Open();
                SqlDataReader drLibro = cmdLibro.ExecuteReader();
                LinkedList<Libro> libros = new LinkedList<Libro>();

                while (drLibro.Read())
                {
                    int id = Int32.Parse(drLibro["id_publicador"].ToString());
                    if (id == idPublicador)
                    {
                        Libro libro = new Libro();
                        libro.CodLibro = Int32.Parse(drLibro["cod_libro"].ToString());
                        libro.TituloLibro = drLibro["titulo_libro"].ToString();
                        libro.AnoPublicacion =Int32.Parse(drLibro["ano_publicacion"].ToString());
                        libro.Precio = Int32.Parse(drLibro["precio"].ToString());
                        libro.Publicador = new Publicador(id, drLibro["nombre_publicador"].ToString(), drLibro["url_sitio_web"].ToString());
                        libro.Autores = getAutoresPorLibro(libro.CodLibro);
                        libros.AddLast(libro);
                    }

                }//while
                conexion.Close();

                return libros;
            }
            public LinkedList<Autor> getAutoresPorLibro(int codLibro)
            {

                //Paso 1
                SqlConnection conexion = new SqlConnection(cadenaConexion);
                SqlCommand cmdLibro = new SqlCommand("Select Autor.* from Autor inner join Libro_Autor on Libro_Autor.id_autor = Autor.id_autor where Libro_Autor.cod_libro ="+codLibro, conexion);
                conexion.Open();
                SqlDataReader drLibro = cmdLibro.ExecuteReader();
                LinkedList<Autor> autores = new LinkedList<Autor>();

                while (drLibro.Read())
                {
                
                        Autor autor = new Autor();
                        autor.IdAutor = Int32.Parse(drLibro["id_autor"].ToString());
                        autor.PrimerApellido = drLibro["primer_apellido"].ToString();
                        autor.SegundoApellido = drLibro["segundo_apellido"].ToString();
                        autor.NombreAutor = drLibro["nombre_autor"].ToString();
                        autores.AddLast(autor);


                }//while
                conexion.Close();

                return autores;

            }

        public Libro InsertarLibro(Libro libro)
        {
            SqlConnection conexion = new SqlConnection(this.cadenaConexion);


            String StoreProcedureLibro = "InsertarLibro";
            String StoreProcedureLibro_Autor = "InsertarLibro_Autor";
            conexion.Open();
            SqlTransaction transaccion = conexion.BeginTransaction();

            SqlCommand cmdInsertarLibro = new SqlCommand(StoreProcedureLibro, conexion);
            SqlCommand cmdInsertarLibro_Autor = new SqlCommand(StoreProcedureLibro_Autor, conexion);
            cmdInsertarLibro.Transaction = transaccion;
            cmdInsertarLibro_Autor.Transaction = transaccion;
            try
            {
                cmdInsertarLibro.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter parameter = new SqlParameter("@cod_libro", SqlDbType.Int);
                parameter.Direction = ParameterDirection.Output;
                cmdInsertarLibro.Parameters.Add(parameter);
                cmdInsertarLibro.Parameters.Add(new SqlParameter("@titulo_libro", libro.TituloLibro));
                cmdInsertarLibro.Parameters.Add(new SqlParameter("@ano_publicacion", libro.AnoPublicacion));
                cmdInsertarLibro.Parameters.Add(new SqlParameter("@isbn", libro.Isbn));
                cmdInsertarLibro.Parameters.Add(new SqlParameter("@id_publicador", libro.CodPublicador));
                cmdInsertarLibro.Parameters.Add(new SqlParameter("@precio", libro.Precio));
                cmdInsertarLibro.ExecuteNonQuery();
                //libro.CodLibro = Int32.Parse(cmdInsertarLibro.Parameters["@cod_libro"].Value.ToString());
                transaccion.Commit();
            }
            catch (SqlException e)
            {
                transaccion.Rollback();
                throw e;
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
            return libro;





           /* SqlCommand cmdInsertarLibro = new SqlCommand();
            SqlCommand cmdInsertarLibro_Autor = new SqlCommand();
            conexion.Open();
            try
            {
                cmdInsertarLibro.CommandText = "InsertarLibro";
            cmdInsertarLibro.CommandType = System.Data.CommandType.StoredProcedure;
            cmdInsertarLibro.Connection = conexion;
            
            cmdInsertarLibro_Autor.CommandText = "InsertarLibro_Autor";
            cmdInsertarLibro_Autor.CommandType = System.Data.CommandType.StoredProcedure;
            cmdInsertarLibro_Autor.Connection = conexion;

            //configurar los parametros
            SqlParameter parCodLibro = new SqlParameter("#cod_libro", System.Data.SqlDbType.Int);
            parCodLibro.Direction = System.Data.ParameterDirection.Output;

            cmdInsertarLibro.Parameters.Add(parCodLibro);
            cmdInsertarLibro.Parameters.Add(new SqlParameter("@titulo_libro", libro.TituloLibro));
            cmdInsertarLibro.Parameters.Add(new SqlParameter("@ano_publicacion", libro.AnoPublicacion));
            cmdInsertarLibro.Parameters.Add(new SqlParameter("@isbn", libro.Isbn));
            cmdInsertarLibro.Parameters.Add(new SqlParameter("@id_publicador", libro.Publicador.IdPublicador));
            cmdInsertarLibro.Parameters.Add(new SqlParameter("@precio", libro.Precio));

            
            cmdInsertarLibro.ExecuteNonQuery();
            libro.CodLibro = Int32.Parse(cmdInsertarLibro.Parameters["@cod_libro"].Value.ToString());
            cmdInsertarLibro_Autor.ExecuteNonQuery();

            }
            catch (SqlException e)
            {
                SqlTransaction.Rollback();
                throw e;
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }*/
        }


        public void InsertarLibroAutor(int codLibro, int codAutor)
        {
            SqlConnection conexion = new SqlConnection(this.cadenaConexion);

            String StoreProcedureLibro_Autor = "InsertarLibro_Autor";
            conexion.Open();
            SqlTransaction transaccion = conexion.BeginTransaction();
            
            SqlCommand cmdInsertarLibro_Autor = new SqlCommand(StoreProcedureLibro_Autor, conexion);
            cmdInsertarLibro_Autor.Transaction = transaccion;
            try
            {
                cmdInsertarLibro_Autor.CommandType = System.Data.CommandType.StoredProcedure;
                cmdInsertarLibro_Autor.Parameters.Add(new SqlParameter("@cod_libro", codLibro));
                cmdInsertarLibro_Autor.Parameters.Add(new SqlParameter("@id_autor", codAutor));
                cmdInsertarLibro_Autor.ExecuteNonQuery();
                //libro.CodLibro = Int32.Parse(cmdInsertarLibro.Parameters["@cod_libro"].Value.ToString());
                transaccion.Commit();
            }
            catch (SqlException e)
            {
                transaccion.Rollback();
                throw e;
            }
            finally
            {
                if (conexion != null)
                {
                    conexion.Close();
                }
            }
            
        }


        public void getIdPublicador(String idPublicador)
        {

        }

    }
    }

