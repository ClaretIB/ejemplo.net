using LibreriaCeibaB43478.LibreriaCeibaB43478.Common.Domain;
using LibreriaCeibaB43478.LibreriaCeibaB43478.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaCeibaB43478.LibreriaCeibaB43478.Business
{
    public class AutorBusiness
    {
        private AutorData autorData;

        public AutorBusiness(String cadenaConexion)
        {
            autorData = new AutorData(cadenaConexion);
        }

       public  LinkedList<Autor> GetAutores()
        {
            return autorData.GetAutores();
        }
    }
}
