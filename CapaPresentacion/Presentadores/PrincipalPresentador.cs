using System.Globalization;
using CapaPresentacion.Sesion;
using CapaPresentacion.Vistas;

namespace CapaPresentacion.Presentadores;

/// <summary>
/// Presentador de la ventana principal: muestra la hora actual,
/// el usuario en sesión y gestiona el cierre de sesión.
/// </summary>
public class PrincipalPresentador
{
    private static readonly CultureInfo Cultura = new("es-PA");
    private readonly IVistaPrincipal _vista;

    public PrincipalPresentador(IVistaPrincipal vista)
    {
        _vista = vista;
        _vista.Cargar += (_, _) => Cargar();
        _vista.TickReloj += (_, _) => ActualizarReloj();
        _vista.CerrarSesion += (_, _) => CerrarSesion();
    }

    private void Cargar()
    {
        var usuario = SesionUsuario.Actual;
        _vista.UsuarioSesion = usuario?.Usuario ?? "(sin sesión)";
        _vista.NombreSesion = usuario?.Nombre ?? string.Empty;
        ActualizarReloj();
    }

    private void ActualizarReloj()
    {
        var ahora = DateTime.Now;
        _vista.Hora = ahora.ToString("hh:mm:ss tt", CultureInfo.InvariantCulture);
        _vista.Fecha = Cultura.TextInfo.ToTitleCase(ahora.ToString("dddd, dd 'de' MMMM yyyy", Cultura));
    }

    private void CerrarSesion()
    {
        SesionUsuario.Cerrar();
        _vista.VolverAlLogin();
    }
}
