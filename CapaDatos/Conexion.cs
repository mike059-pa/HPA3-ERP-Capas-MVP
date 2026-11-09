using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;

namespace CapaDatos
{
    /// <summary>
    /// Provee la conexión específica de la aplicación a SQL Server.
    /// La cadena "ConexionApp" (App.config) usa el login <c>app_login_erp</c>,
    /// que solo tiene permiso EXECUTE sobre los procedimientos almacenados
    /// (principio de privilegios mínimos).
    /// </summary>
    public static class Conexion
    {
        private const string NombreCadena = "ConexionApp";

        /// <summary>Crea una nueva conexión (sin abrir) a la base de datos.</summary>
        /// <exception cref="ConfigurationErrorsException">Si no existe la cadena en App.config.</exception>
        public static SqlConnection ObtenerConexion()
        {
            var cadena = ConfigurationManager.ConnectionStrings[NombreCadena]?.ConnectionString
                ?? throw new ConfigurationErrorsException(
                    $"No se encontró la cadena de conexión '{NombreCadena}' en App.config.");
            return new SqlConnection(cadena);
        }

        /// <summary>Crea un comando que ejecuta el procedimiento almacenado indicado.</summary>
        internal static SqlCommand CrearComando(string procedimiento, SqlConnection conexion) =>
            new(procedimiento, conexion) { CommandType = CommandType.StoredProcedure };

        /// <summary>
        /// Ejecuta una operación de base de datos y convierte los errores de regla
        /// lanzados con THROW 50000+ en los procedimientos en <see cref="DatosException"/>.
        /// </summary>
        internal static T Ejecutar<T>(Func<T> operacion)
        {
            try
            {
                return operacion();
            }
            catch (SqlException ex) when (ex.Number >= 50000)
            {
                throw new DatosException(ex.Message, ex);
            }
        }

        /// <inheritdoc cref="Ejecutar{T}(Func{T})"/>
        internal static void Ejecutar(Action operacion) => Ejecutar(() => { operacion(); return true; });
    }
}
