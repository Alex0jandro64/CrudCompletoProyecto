﻿using CrudCompletoProyecto.Dtos;
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
                        crud1.insertarLibro(crud1.generarConexion(),libroImpl.nuevoLibro(listaLibros));
                        break;

                    case 3:
                        Console.Clear();
                        break;

                    case 4:
                        Console.Clear();
                        crud1.eliminarLibro(crud1.generarConexion(),libroImpl.eliminarLibro(listaLibros));
                        break;
                }
            } while (opcion != 0);

        }
    }
}
