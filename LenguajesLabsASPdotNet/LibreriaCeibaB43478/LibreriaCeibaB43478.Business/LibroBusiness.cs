using LibreriaCeibaB43478.LibreriaCeibaB43478.Common.Domain;
using LibreriaCeibaB43478.LibreriaCeibaB43478.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaCeibaB43478.LibreriaCeibaB43478.Business
{
   public class LibroBusiness
    {
        private LibroData libroData;
        
        public LibroBusiness(String cadenaConexion)
        {
            libroData = new LibroData(cadenaConexion);
        }

        public LinkedList<Libro> GetLibrosPorPublicador(int idPublicador)
        {
            return libroData.GetLibrosPorPublicador(idPublicador);
        }

        public LinkedList<Autor> getAutoresPorLibro(int codLibro)
        {
            return libroData.getAutoresPorLibro(codLibro);
        }

        public Libro InsertarLibro(Libro libro)
        {
            return libroData.InsertarLibro(libro);

        }
        public void InsertarLibroAutor(int codLibro, int codAutor)
        {

        }
    }
}
