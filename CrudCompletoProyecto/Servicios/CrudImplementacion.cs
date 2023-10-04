using CrudCompletoProyecto.Dtos;
using CrudCompletoProyecto.Util;
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

        public NpgsqlConnection generarConexion()
        {
            //Se lee la cadena de conexión a Postgresql del archivo de configuración
            string stringConexionPostgresql = ConfigurationManager.ConnectionStrings["stringConexion"].ConnectionString;
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

                        Console.WriteLine("[INFORMACIÓN-CrudImplementacion-generarConexionPostgresql] Estado conexión: " + estado);

                    }
                    else
                    {
                        conexion = null;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("[ERROR-CrudImplementacion-generarConexionPostgresql] Error al generar la conexión:" + e);
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
                Console.WriteLine("[INFORMACIÓN-CrudImplementacion-seccionarTodosLibros] Número de libros: " + cont);

                Console.WriteLine("[INFORMACIÓN-CrudImplementacion-seccionarTodosLibros] Cierre conexión y conjunto de datos");
                conexion.Close();
                resultadoConsulta.Close();

            }
            catch (Exception e)
            {

                Console.WriteLine("[ERROR-CrudImplementacion-seccionarTodosLibros] Error al ejecutar consulta: " + e);
                conexion.Close();

            }
            return listaLibros;
        }

        public void insertarLibro(NpgsqlConnection conexion, List<LibroDto> listaLibros)
        {
            
            try
            {
                //Se define y ejecuta la consulta Select
                string insertSql = "INSERT INTO gbp_almacen.gbp_alm_cat_libros (titulo, autor, isbn, edicion) VALUES ";
                int auxValor = 1;
                for(int i = 0; i < listaLibros.Count; i++)
                {
                    insertSql = insertSql + "(@valor"+(auxValor++)+ ", @valor"+(auxValor++)+ ", @valor"+(auxValor++)+", @valor"+(auxValor++)+")";
                    if (i != listaLibros.Count-1)
                    {
                        insertSql = insertSql + ",";
                    }
                    
                }




                using (NpgsqlCommand command = new NpgsqlCommand(insertSql, conexion))
                {
                    int aux = 1;
                    // Definir los parámetros y sus valores
                    for (int i = 0; i < listaLibros.Count; i++)
                    {
                        command.Parameters.AddWithValue("@valor"+aux++, listaLibros[i].Titulo);
                        command.Parameters.AddWithValue("@valor"+aux++, listaLibros[i].Autor);
                        command.Parameters.AddWithValue("@valor"+aux++, listaLibros[i].Isbn);
                        command.Parameters.AddWithValue("@valor"+aux++, listaLibros[i].Edicion);
                    }
                    

                    try
                    {
                        // Ejecutar la consulta de inserción
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"Filas afectadas: {rowsAffected}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
                //Paso de DataReader a lista de alumnoDTO
                conexion.Close();

            }
            catch (Exception e)
            {

                Console.WriteLine("[ERROR-CrudImplementacion-seccionarTodosLibros] Error al ejecutar consulta: " + e);
                conexion.Close();

            }
        }

        public void eliminarLibro(NpgsqlConnection conexion, List<LibroDto> listaLibros)
        {

            try
            {
                //Se define y ejecuta la consulta Select
                string insertSql = "DELETE FROM gbp_almacen.gbp_alm_cat_libros WHERE id_libro = @valor1";
              

                using (NpgsqlCommand command = new NpgsqlCommand(insertSql, conexion))
                {
                    // Definir los parámetros y sus valores
                        command.Parameters.AddWithValue("@valor1", listaLibros[0].Id_libro);

                    try
                    {
                        // Ejecutar la consulta de inserción
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine($"Filas afectadas: {rowsAffected}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
                //Paso de DataReader a lista de alumnoDTO
                conexion.Close();

            }
            catch (Exception e)
            {

                Console.WriteLine("[ERROR-CrudImplementacion-seccionarTodosLibros] Error al ejecutar consulta: " + e);
                conexion.Close();

            }
        }
    }
}
