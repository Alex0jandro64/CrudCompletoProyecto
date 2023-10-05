using CrudCompletoProyecto.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCompletoProyecto.Servicios
{
    /// <summary>
    /// Interfaz que contiene todos los metodos sobre modificar la lista de LibroDto
    /// </summary>
    internal interface LibroInterfaz
    {
        /// <summary>
        /// Metodo que recibe la lista de libros y modifica la lista con los libros que quiere añadir en la base de datos
        /// </summary>
        /// <param name="listaLibros"></param>
        void nuevoLibro(List<LibroDto> listaLibros);
        /// <summary>
        /// Metodo que recibe la lista de libros y modifica la lista con el id_libro del libro que quiere eliminar
        /// </summary>
        /// <param name="listaLibros"></param>
        void eliminarLibro(List<LibroDto> listaLibros);
        /// <summary>
        /// Meetodo que recibe la lista de libros y modifica la lista con los datos que quiere modificar y devuelve el campo que quiere modificar 
        /// </summary>
        /// <param name="listaLibros"></param>
        /// <returns></returns>
        int modificarLibro(List<LibroDto> listaLibros);
    }
}
