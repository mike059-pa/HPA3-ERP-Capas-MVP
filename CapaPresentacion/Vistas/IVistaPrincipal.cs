namespace CapaPresentacion.Vistas;

/// <summary>Contrato de la Vista principal con menú lateral (MVP).</summary>
public interface IVistaPrincipal
{
    /// <summary>Hora actual mostrada en pantalla.</summary>
    string Hora { set; }

    /// <summary>Fecha actual mostrada en pantalla.</summary>
    string Fecha { set; }

    /// <summary>Usuario que inició sesión (parte inferior del menú).</summary>
    string UsuarioSesion { set; }

    /// <summary>Nombre completo del usuario en sesión.</summary>
    string NombreSesion { set; }

    /// <summary>Se dispara al cargar la vista.</summary>
    event EventHandler Cargar;

    /// <summary>Se dispara cada segundo para refrescar el reloj.</summary>
    event EventHandler TickReloj;

    /// <summary>Se dispara cuando el usuario presiona "Cerrar sesión".</summary>
    event EventHandler CerrarSesion;

    /// <summary>Cierra la vista principal y vuelve al login.</summary>
    void VolverAlLogin();
}
