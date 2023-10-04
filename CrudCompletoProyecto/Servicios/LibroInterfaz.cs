using CrudCompletoProyecto.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCompletoProyecto.Servicios
{
    internal interface LibroInterfaz
    {
        List<LibroDto> nuevoLibro(List<LibroDto> listaLibros);
        List<LibroDto> eliminarLibro(List<LibroDto> listaLibros);
    }
}
