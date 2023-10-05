using CrudCompletoProyecto.Dtos;
using CrudCompletoProyecto.Servicios;
using CrudCompletoProyecto.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCompletoProyecto
{

    internal class Program
    {
        static void Main(string[] args)
        {

            ADto adto = new ADto();
            Utilidades utilidad = new Utilidades();
            CrudInterfaz crud1 = new CrudImplementacion();
            LibroInterfaz libroImpl = new LibroImplementacion();
            int opcion = 1;
            try
            {

                do
                {
                    do
                    {
                        //Muestra el menu y recoge opcion siempre que este dentro del rango
                        Console.Clear();
                        utilidad.imprimirMenu();
                        opcion = Console.ReadKey().KeyChar - '0';
                    } while (opcion < 1 || opcion > 4);

                    List<LibroDto> listaLibros = new List<LibroDto>();

                    switch (opcion)
                    {
                        case 1:
                            Console.Clear();
                            utilidad.imprimirListaLibros(crud1.seccionarTodosLibros(crud1.generarConexion()));
                            Console.WriteLine("\n\nPulse una tecla para continuar");
                            Console.ReadLine();
                            break;

                        case 2:
                            Console.Clear();
                            libroImpl.nuevoLibro(listaLibros);
                            crud1.insertarLibro(crud1.generarConexion(), listaLibros);
                            Console.WriteLine("\n\nPulse una tecla para continuar");
                            Console.ReadLine();
                            break;

                        case 3:
                            Console.Clear();
                            int campo = libroImpl.modificarLibro(listaLibros);
                            crud1.ModificarLibro(crud1.generarConexion(), listaLibros, campo);
                            Console.WriteLine("\n\nPulse una tecla para continuar");
                            Console.ReadLine();
                            break;

                        case 4:
                            Console.Clear();
                            libroImpl.eliminarLibro(listaLibros);
                            crud1.eliminarLibro(crud1.generarConexion(), listaLibros);
                            Console.WriteLine("\n\nPulse una tecla para continuar");
                            Console.ReadLine();
                            break;
                    }
                } while (opcion != 0);

            }
            catch (Exception e)
            {
                Console.WriteLine("Error General");
            }
        }
    }
}
