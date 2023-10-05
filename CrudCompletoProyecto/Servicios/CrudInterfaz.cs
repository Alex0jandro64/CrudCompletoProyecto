using CrudCompletoProyecto.Dtos;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCompletoProyecto.Servicios
{
    internal interface CrudInterfaz
    {

        NpgsqlConnection generarConexion();
        List<LibroDto> seccionarTodosLibros(NpgsqlConnection conexion);
        void insertarLibro(NpgsqlConnection conexion, List<LibroDto> listaLibros);
        void eliminarLibro(NpgsqlConnection conexion, List<LibroDto> listaLibros);
        void ModificarLibro(NpgsqlConnection conexion, List<LibroDto> listaLibros, int campo);
    }
}
