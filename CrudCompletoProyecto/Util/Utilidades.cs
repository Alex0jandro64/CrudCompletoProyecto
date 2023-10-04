using CrudCompletoProyecto.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CrudCompletoProyecto.Util
{
    internal class Utilidades
    {

        public void imprimirListaLibros(List<LibroDto> listaLibros)
        {
            Console.WriteLine("\n\n");
            foreach (LibroDto libro in listaLibros)
            {
                Console.WriteLine("{0}, {1}, {2}, {3}, {4}", libro.Id_libro,libro.Titulo,libro.Autor,libro.Edicion,libro.Isbn);
            }
        }
        public void imprimirMenu()
        {
            Console.WriteLine("1.-Ver Libros");
            Console.WriteLine("2.-Añadir Libro");
            Console.WriteLine("3.-Modificar Libro");
            Console.WriteLine("4.-Eliminar Libro");
            Console.WriteLine("0.-Salir del programa");
        }
        public static String pideTitulo()
        {
            String titulo;

            do
            {
                //Compruebo que los tipos de datos son los correctos
                Console.Write("\nTitulo: ");
                titulo = Console.ReadLine();
                if (estaVacio(titulo))
                {
                    Console.WriteLine("El titulo no puede estar vacio");
                }
            } while (estaVacio(titulo));

            //Si sale del bucle es que esta correcto entonces devuelvo el dato
            return titulo;
        }
        public static bool estaVacio(String txt)
        {
            return (txt.Length == 0);
        }
        public static bool tieneNumeros(String txt)
        {
            Regex regex = new Regex(@"\d+");
            return regex.IsMatch(txt);
        }
        public static String pideAutor()
        {
            String autor;

            do
            {
                //Compruebo que los tipos de datos son los correctos
                Console.Write("\nAutor: ");
                autor = Console.ReadLine();
                if (estaVacio(autor))
                {
                    Console.WriteLine("El autor no puede estar vacio");
                }
                else if (tieneNumeros(autor))
                {
                    Console.WriteLine("El autor no puede contener numero");
                }
            } while (estaVacio(autor) || tieneNumeros(autor));

            //Si sale del bucle es que esta correcto entonces devuelvo el dato
            return autor;
        }
        public static int pideEdicion()
        {
            bool ok;
            int edicion;
            do
            {
                Console.Write("\nEdicion: ");
                ok = int.TryParse(Console.ReadLine(), out edicion);
                if (!ok)
                {
                    Console.WriteLine("La edicion no puede tener caracteres no numericos");
                }
                else if (estaVacio(edicion.ToString()))
                {
                    Console.WriteLine("La edicion no puede estar vacio");
                }
            } while (!ok || estaVacio(edicion.ToString()));

            return edicion;
        }
        public static String pideIsbn()
        {
            String isbn;

            do
            {
                //Compruebo que los tipos de datos son los correctos
                Console.Write("\nIsbn: ");
                isbn = Console.ReadLine();
                if (estaVacio(isbn))
                {
                    Console.WriteLine("El Isbn no puede estar vacio");
                }
            } while (estaVacio(isbn));

            //Si sale del bucle es que esta correcto entonces devuelvo el dato
            return isbn;
        }
        public static int capturaOpcion(int min, int max)
        {
            int num;
            do
            {
                if (int.TryParse(Console.ReadLine(), out num))
                {
                    if (num < min || num > max)
                    {
                        Console.WriteLine("El número está fuera del rango permitido.");
                    }
                }
                else
                {
                    Console.WriteLine("Entrada no válida. Por favor, ingrese un número entero.");
                }
            } while (num < min || num > max);
            return num;
        }
        public static int pideId()
        {
            bool ok;
            int id;
            do
            {
                Console.Write("\nID del libro: ");
                ok = int.TryParse(Console.ReadLine(), out id);
                if (!ok)
                {
                    Console.WriteLine("El id no puede tener caracteres no numericos");
                }
                else if (estaVacio(id.ToString()))
                {
                    Console.WriteLine("El id no puede estar vacio");
                }
            } while (!ok || estaVacio(id.ToString()));

            return id;
        }
    }
}
