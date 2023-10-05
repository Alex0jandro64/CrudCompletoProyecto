using CrudCompletoProyecto.Dtos;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCompletoProyecto.Servicios
{
    /// <summary>
    /// Interfaz que contiene los metodos que funcionan con la base de datos
    /// </summary>
    internal interface CrudInterfaz
    {
        /// <summary>
        /// Metodo que devuelve una conexion de la base de datos
        /// </summary>
        /// <returns></returns>
        NpgsqlConnection generarConexion();
        /// <summary>
        /// Metodo que recibe la conexion a la base de datos que devuelve una lista DTO de todos los libros de la base de datos
        /// </summary>
        /// <param name="conexion"></param>
        /// <returns></returns>
        List<LibroDto> seccionarTodosLibros(NpgsqlConnection conexion);
        /// <summary>
        /// Metodo que recibe la conexion a la base de datos que Inserta todos los libros de una lista de libros
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="listaLibros"></param>
        void insertarLibro(NpgsqlConnection conexion, List<LibroDto> listaLibros);
        /// <summary>
        /// Metodo que recibe la conexion a la base de dato y una lista con un id_libro que la elimina de la base de datos
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="listaLibros"></param>
        void eliminarLibro(NpgsqlConnection conexion, List<LibroDto> listaLibros);
        /// <summary>
        /// Metodo que recibe la conexion a la base de datos, una lista con la informacion que quiere modificar y el id del libro y el campo que quiere modificar
        /// </summary>
        /// <param name="conexion"></param>
        /// <param name="listaLibros"></param>
        /// <param name="campo"></param>
        void ModificarLibro(NpgsqlConnection conexion, List<LibroDto> listaLibros, int campo);
    }
}
