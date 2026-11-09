using CapaNegocio;

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

    /// <summary>Rol del usuario en sesión.</summary>
    string RolSesion { set; }

    /// <summary>Teléfono y correo del usuario en sesión.</summary>
    string ContactoSesion { set; }

    /// <summary>Se dispara al cargar la vista.</summary>
    event EventHandler Cargar;

    /// <summary>Se dispara cada segundo para refrescar el reloj.</summary>
    event EventHandler TickReloj;

    /// <summary>Se dispara cuando el usuario elige una opción del menú.</summary>
    event EventHandler<Modulo> ModuloSeleccionado;

    /// <summary>Se dispara cuando el usuario presiona "Cerrar sesión".</summary>
    event EventHandler CerrarSesion;

    /// <summary>Crea los botones del menú lateral para los módulos permitidos.</summary>
    void MostrarModulos(IReadOnlyList<Modulo> modulos);

    /// <summary>Abre el módulo dentro del panel contenedor.</summary>
    void AbrirModulo(Modulo modulo);

    /// <summary>Muestra un aviso al usuario.</summary>
    void MostrarAviso(string mensaje);

    /// <summary>Cierra la vista principal y vuelve al login.</summary>
    void VolverAlLogin();
}
