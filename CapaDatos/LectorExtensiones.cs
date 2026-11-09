using Microsoft.Data.SqlClient;

namespace CapaDatos
{
    /// <summary>
    /// Métodos de ayuda para leer columnas por nombre del <see cref="SqlDataReader"/>.
    /// Usan los métodos tipados (GetInt32, GetString...) y validan NULL con IsDBNull.
    /// </summary>
    internal static class LectorExtensiones
    {
        public static int Entero(this SqlDataReader lector, string columna) =>
            lector.GetInt32(lector.GetOrdinal(columna));

        public static int? EnteroNulo(this SqlDataReader lector, string columna)
        {
            int i = lector.GetOrdinal(columna);
            return lector.IsDBNull(i) ? null : lector.GetInt32(i);
        }

        public static string Texto(this SqlDataReader lector, string columna)
        {
            int i = lector.GetOrdinal(columna);
            return lector.IsDBNull(i) ? string.Empty : lector.GetString(i);
        }

        public static decimal Decimal(this SqlDataReader lector, string columna) =>
            lector.GetDecimal(lector.GetOrdinal(columna));

        public static bool Booleano(this SqlDataReader lector, string columna) =>
            lector.GetBoolean(lector.GetOrdinal(columna));

        public static DateTime Fecha(this SqlDataReader lector, string columna) =>
            lector.GetDateTime(lector.GetOrdinal(columna));

        public static byte[] Bytes(this SqlDataReader lector, string columna) =>
            (byte[])lector[columna];

        /// <summary>Convierte un texto vacío en DBNull para guardar NULL en la base de datos.</summary>
        public static object NuloSiVacio(string? valor) =>
            string.IsNullOrWhiteSpace(valor) ? DBNull.Value : valor.Trim();
    }
}
