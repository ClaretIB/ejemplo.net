using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaCeibaB43478.LibreriaCeibaB43478.Common.Domain
{
   public class Autor
    {
        private int idAutor;//ctrol re
        private String nombreAutor;
        private String primerApellido;
        private String segundoApellido;

        public Autor()
        {
        }

        public Autor(int idAutor, String nombreAutor, String primerApellido,  String segundoApellido)
        {
            this.idAutor = idAutor;
            this.nombreAutor = nombreAutor;
            this.primerApellido = primerApellido;
            this.segundoApellido = segundoApellido;
        }

        public int IdAutor
        {
            get
            {
                return idAutor;
            }

            set
            {
                idAutor = value;
            }
        }

        public string NombreAutor
        {
            get
            {
                return nombreAutor;
            }

            set
            {
                nombreAutor = value;
            }
        }

        public string PrimerApellido
        {
            get
            {
                return primerApellido;
            }

            set
            {
                primerApellido = value;
            }
        }

        public string SegundoApellido
        {
            get
            {
                return segundoApellido;
            }

            set
            {
                segundoApellido = value;
            }
        }
    }
}
