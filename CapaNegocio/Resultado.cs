using CapaDatos;

namespace CapaNegocio
{
    /// <summary>Resultado de una operación de negocio: éxito, mensaje y dato opcional.</summary>
    public record Resultado<T>(bool Exito, string Mensaje, T? Dato = default)
    {
        /// <summary>Resultado fallido por falta de permisos del rol.</summary>
        public static Resultado<T> SinPermiso() => new(false, "No tiene permiso para realizar esta acción.");

        /// <summary>Resultado fallido con un mensaje de validación.</summary>
        public static Resultado<T> Error(string mensaje) => new(false, mensaje);
    }

    /// <summary>Ejecuta llamadas a la capa de Datos traduciendo los errores de regla en resultados.</summary>
    internal static class Operacion
    {
        /// <summary>
        /// Ejecuta la operación; si un procedimiento lanzó un error de regla (THROW 50000+)
        /// devuelve un resultado fallido con ese mensaje. Los errores de conexión se propagan.
        /// </summary>
        public static Resultado<T> Ejecutar<T>(Func<T> operacion, string mensajeExito = "")
        {
            try
            {
                return new(true, mensajeExito, operacion());
            }
            catch (DatosException ex)
            {
                return new(false, ex.Message);
            }
        }
    }
}
