using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaCeibaB43478.LibreriaCeibaB43478.Common.Domain
{
    public class Libro
    {
        private int codLibro;
        private String tituloLibro;
        private int anoPublicacion;
        private String isbn;
        private float precio;
        private Publicador publicador;
        private int codPublicador;
        private LinkedList<Autor> autores;
       
        public Libro()
        {
            this.Publicador = new Publicador();
            this.Autores = new LinkedList<Autor>();
        }
        public Libro(int codLibro, String tituloLibro, int anoPublicacion, String isbn, float precio, int codPublicador)
        {
            this.CodLibro = codLibro;
            this.TituloLibro = tituloLibro;
            this.AnoPublicacion = anoPublicacion;
            this.Isbn = isbn;
            this.Precio = precio;
            this.CodPublicador = codPublicador; 
        }



        public int CodLibro
        {
            get
            {
                return codLibro;
            }

            set
            {
                codLibro = value;
            }
        }

        public string TituloLibro
        {
            get
            {
                return tituloLibro;
            }

            set
            {
                tituloLibro = value;
            }
        }

        public int AnoPublicacion
        {
            get
            {
                return anoPublicacion;
            }

            set
            {
                anoPublicacion = value;
            }
        }

        public string Isbn
        {
            get
            {
                return isbn;
            }

            set
            {
                isbn = value;
            }
        }

        public float Precio
        {
            get
            {
                return precio;
            }

            set
            {
                precio = value;
            }
        }

        internal Publicador Publicador
        {
            get
            {
                return publicador;
            }

            set
            {
                publicador = value;
            }
        }

        public LinkedList<Autor> Autores
        {
            get
            {
                return autores;
            }

            set
            {
                autores = value;
            }
        }

        public int CodPublicador
        {
            get
            {
                return codPublicador;
            }

            set
            {
                codPublicador = value;
            }
        }
    }
}
