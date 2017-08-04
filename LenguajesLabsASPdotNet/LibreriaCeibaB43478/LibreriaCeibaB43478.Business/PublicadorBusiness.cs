using LibreriaCeibaB43478.LibreriaCeibaB43478.Common.Domain;
using LibreriaCeibaB43478.LibreriaCeibaB43478.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaCeibaB43478.LibreriaCeibaB43478.Business
{
    public class PublicadorBusiness
    {
        private  PublicadorData publicadorData;

        public PublicadorBusiness(String cadenaConexion)
        {
            publicadorData = new PublicadorData(cadenaConexion);
        }

        public LinkedList<Publicador> GetPublicadores()
        {
            return publicadorData.GetPublicadores();  
        }
    }
}
