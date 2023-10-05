using CrudCompletoProyecto.Dtos;
using CrudCompletoProyecto.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCompletoProyecto.Servicios
{
    internal class LibroImplementacion : LibroInterfaz
    {

        public void nuevoLibro(List<LibroDto> listaLibros)
        {
            try
            {

                int opcion = 0;

                do
                {
                    //Muestra el menu y recoge opcion siempre que este dentro del rango
                    Console.Clear();
                    Console.Write("Quiere añadir solo un libro (1) o varios libros (2): ");
                    opcion = Console.ReadKey().KeyChar - '0';
                } while (opcion < 1 || opcion > 2);

                if (opcion == 1)
                {
                    String titulo = Utilidades.pideTitulo();
                    String autor = Utilidades.pideAutor();
                    int edicion = Utilidades.pideEdicion();
                    String isbn = Utilidades.pideIsbn();

                    LibroDto libro1 = new LibroDto(0, titulo, autor, isbn, edicion);
                    listaLibros.Add(libro1);
                }
                else
                {
                    int cantidad = 0;
                    Console.Clear();
                    Console.Write("Cuantos libros quiere añadir (maximo 10): ");
                    cantidad = Utilidades.capturaOpcion(1, 10);

                    for (int i = 0; i < cantidad; i++)
                    {
                        Console.WriteLine("Registro {0}", i);
                        String titulo = Utilidades.pideTitulo();
                        String autor = Utilidades.pideAutor();
                        int edicion = Utilidades.pideEdicion();
                        String isbn = Utilidades.pideIsbn();

                        LibroDto libro1 = new LibroDto(0, titulo, autor, isbn, edicion);
                        listaLibros.Add(libro1);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("[Error-LibroImplementacion-nuevoLibro] - Error al capturar los datos");
            }



        }

        public void eliminarLibro(List<LibroDto> listaLibros)
        {
            try
            {

            int id_libro = Utilidades.pideId();
            LibroDto libro1 = new LibroDto(id_libro);
            listaLibros.Add(libro1);
            }
                catch (Exception ex)
            {
                Console.WriteLine("[Error-LibroImplentacion-eliminarLibro] - Error al capturar el dato");
            }
        }

        public int modificarLibro(List<LibroDto> listaLibros)
        {
            long id_libro = Utilidades.pideId();
            int campo = Utilidades.pideIdCamposAModificar();
            LibroDto libro1 = new LibroDto(id_libro);

            switch (campo)
            {
                case 1:
                    libro1.Titulo = (Utilidades.pideTitulo());
                    break;
                case 2:
                    libro1.Autor = (Utilidades.pideAutor());
                    break;
                case 3:
                    libro1.Isbn = (Utilidades.pideIsbn());
                    break;
                case 4:
                    libro1.Edicion = (Utilidades.pideEdicion());
                    break;
            }

            listaLibros.Add(libro1);
            return campo;
        }
    }
}
