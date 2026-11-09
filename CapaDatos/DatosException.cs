namespace CapaDatos
{
    /// <summary>
    /// Error de regla de negocio informado por un procedimiento almacenado (THROW 50000+),
    /// por ejemplo "Stock insuficiente" o "El nombre de usuario ya existe".
    /// Su mensaje es apto para mostrarse al usuario.
    /// </summary>
    public class DatosException(string mensaje, Exception interna) : Exception(mensaje, interna);
}
