using CapaEntidades;

namespace CapaPresentacion.Sesion;

/// <summary>Guarda el usuario que inició sesión mientras la aplicación está abierta.</summary>
public static class SesionUsuario
{
    /// <summary>Usuario actual o <c>null</c> si no hay sesión.</summary>
    public static E_Usuario? Actual { get; private set; }

    /// <summary>Hora en que se inició la sesión.</summary>
    public static DateTime Inicio { get; private set; }

    /// <summary>Registra el inicio de sesión.</summary>
    public static void Iniciar(E_Usuario usuario)
    {
        Actual = usuario;
        Inicio = DateTime.Now;
    }

    /// <summary>Elimina la sesión actual.</summary>
    public static void Cerrar() => Actual = null;
}
