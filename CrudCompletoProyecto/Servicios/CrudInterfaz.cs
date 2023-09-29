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

        NpgsqlConnection generarConexionPostgresql();
        List<LibroDto> seccionarTodosLibros(NpgsqlConnection conexion);
    }
}
