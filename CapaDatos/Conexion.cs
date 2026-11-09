using System.Configuration;
using Microsoft.Data.SqlClient;

namespace CapaDatos
{
    /// <summary>
    /// Provee la conexión específica de la aplicación a SQL Server.
    /// La cadena "ConexionApp" (App.config) usa el login <c>app_login_parcial</c>,
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
    }
}
