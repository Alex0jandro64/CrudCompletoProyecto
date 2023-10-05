using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCompletoProyecto.Dtos
{
    /// <summary>
    /// Clase de el objeto libro
    /// </summary>
    internal class LibroDto
    {
        //Atributos
        long id_libro;
        int edicion;
        String autor, titulo, isbn;

        //Constructores
        public LibroDto(long id_libro, string titulo, string autor, string isbn, int edicion)
        {
            this.id_libro = id_libro;
            this.edicion = edicion;
            this.autor = autor;
            this.titulo = titulo;
            this.isbn = isbn;
        }

        public LibroDto(long id_libro)
        {
            this.id_libro = id_libro;
        }

        //Contructores
        public long Id_libro { get => id_libro; set => id_libro = value; }
        public int Edicion { get => edicion; set => edicion = value; }
        public string Autor { get => autor; set => autor = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Isbn { get => isbn; set => isbn = value; }
    }
}
