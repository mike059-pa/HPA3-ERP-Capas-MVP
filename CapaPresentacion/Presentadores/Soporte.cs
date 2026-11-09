using System.Globalization;
using CapaEntidades;
using CapaPresentacion.Sesion;

namespace CapaPresentacion.Presentadores;

/// <summary>Utilidades compartidas por los presentadores.</summary>
internal static class Soporte
{
    private static readonly CultureInfo Cultura = new("es-PA");

    /// <summary>Usuario en sesión (los módulos solo se abren con una sesión iniciada).</summary>
    public static E_Usuario Actor =>
        SesionUsuario.Actual ?? throw new InvalidOperationException("No hay una sesión iniciada.");

    /// <summary>Hora con segundos, por ejemplo "06:46:14 PM".</summary>
    public static string Hora(DateTime momento) => momento.ToString("hh:mm:ss tt", CultureInfo.InvariantCulture);

    /// <summary>Fecha larga en español, por ejemplo "Domingo, 08 de noviembre de 2026".</summary>
    public static string Fecha(DateTime momento)
    {
        var texto = momento.ToString("dddd, dd 'de' MMMM 'de' yyyy", Cultura);
        return char.ToUpper(texto[0], Cultura) + texto[1..];
    }

    /// <summary>Nombre legible del rol.</summary>
    public static string NombreRol(Rol rol) => rol switch
    {
        Rol.Administrador => "Administrador",
        Rol.Vendedor => "Vendedor",
        Rol.Cliente => "Cliente",
        _ => rol.ToString()
    };

    /// <summary>
    /// Ejecuta una acción del presentador; si falla la conexión con la base de datos
    /// muestra el error en la vista en lugar de cerrar la aplicación.
    /// </summary>
    public static void Ejecutar(Action accion, Action<string> mostrarError)
    {
        try
        {
            accion();
        }
        catch (Exception ex)
        {
            mostrarError("No se pudo conectar con la base de datos: " + ex.Message);
        }
    }
}
