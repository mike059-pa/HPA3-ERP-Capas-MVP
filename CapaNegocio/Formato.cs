using System.Globalization;

namespace CapaNegocio
{
    /// <summary>Formatos de presentación de montos, independientes de la configuración regional del equipo.</summary>
    public static class Formato
    {
        /// <summary>Monto en dólares con dos decimales, por ejemplo "$1,234.50".</summary>
        public static string Dinero(decimal monto) => "$" + monto.ToString("N2", CultureInfo.InvariantCulture);
    }
}
