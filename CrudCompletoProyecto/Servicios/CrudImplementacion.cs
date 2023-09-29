using CrudCompletoProyecto.Dtos;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCompletoProyecto.Servicios
{
    internal class CrudImplementacion : CrudInterfaz
    {

        public NpgsqlConnection generarConexionPostgresql()
        {
            //Se lee la cadena de conexión a Postgresql del archivo de configuración
            string stringConexionPostgresql = ConfigurationManager.ConnectionStrings["stringConexion"].ConnectionString;
            Console.WriteLine("[INFORMACIÓN-ConexionPostgresqlImplementacion-generarConexionPostgresql] Cadena conexión: " + stringConexionPostgresql);

            NpgsqlConnection conexion = null;
            string estado = "";

            if (!string.IsNullOrWhiteSpace(stringConexionPostgresql))
            {
                try
                {
                    conexion = new NpgsqlConnection(stringConexionPostgresql);
                    conexion.Open();
                    //Se obtiene el estado de conexión para informarlo por consola
                    estado = conexion.State.ToString();
                    if (estado.Equals("Open"))
                    {

                        Console.WriteLine("[INFORMACIÓN-ConexionPostgresqlImplementacion-generarConexionPostgresql] Estado conexión: " + estado);

                    }
                    else
                    {
                        conexion = null;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("[ERROR-ConexionPostgresqlImplementacion-generarConexionPostgresql] Error al generar la conexión:" + e);
                    conexion = null;
                    return conexion;

                }
            }

            return conexion;

        }
        public List<LibroDto> seccionarTodosLibros(NpgsqlConnection conexion)
        {
            ADto aDto = new ADto();
            List<LibroDto> listaLibros = new List<LibroDto>();
            try
            {
                //Se define y ejecuta la consulta Select
                NpgsqlCommand consulta = new NpgsqlCommand("SELECT * FROM \"gbp_almacen\".\"gbp_alm_cat_libros\"", conexion);
                NpgsqlDataReader resultadoConsulta = consulta.ExecuteReader();

                //Paso de DataReader a lista de alumnoDTO
                listaLibros = aDto.readerALibroDto(resultadoConsulta);
                int cont = listaLibros.Count();
                Console.WriteLine("[INFORMACIÓN-ConsultasPostgresqlImplementacion-seccionarTodosLibros] Número de libros: " + cont);

                Console.WriteLine("[INFORMACIÓN-ConsultasPostgresqlImplementacion-seccionarTodosLibros] Cierre conexión y conjunto de datos");
                conexion.Close();
                resultadoConsulta.Close();

            }
            catch (Exception e)
            {

                Console.WriteLine("[ERROR-ConsultasPostgresqlImplementacion-seccionarTodosLibros] Error al ejecutar consulta: " + e);
                conexion.Close();

            }
            return listaLibros;
        }
    }
}
