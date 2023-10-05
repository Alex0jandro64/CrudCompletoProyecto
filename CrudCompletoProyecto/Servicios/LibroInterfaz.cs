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
        void nuevoLibro(List<LibroDto> listaLibros);
        void eliminarLibro(List<LibroDto> listaLibros);
        int modificarLibro(List<LibroDto> listaLibros);
    }
}
