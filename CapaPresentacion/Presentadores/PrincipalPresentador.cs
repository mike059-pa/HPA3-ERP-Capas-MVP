using CapaNegocio;
using CapaPresentacion.Sesion;
using CapaPresentacion.Vistas;

namespace CapaPresentacion.Presentadores;

/// <summary>
/// Presentador de la ventana principal: arma el menú según el rol, muestra la hora,
/// el usuario en sesión y gestiona la navegación y el cierre de sesión.
/// </summary>
public class PrincipalPresentador
{
    private readonly IVistaPrincipal _vista;

    public PrincipalPresentador(IVistaPrincipal vista)
    {
        _vista = vista;
        _vista.Cargar += (_, _) => Cargar();
        _vista.TickReloj += (_, _) => ActualizarReloj();
        _vista.ModuloSeleccionado += (_, modulo) => Abrir(modulo);
        _vista.CerrarSesion += (_, _) => CerrarSesion();
    }

    private void Cargar()
    {
        var usuario = Soporte.Actor;
        _vista.UsuarioSesion = usuario.Usuario;
        _vista.NombreSesion = usuario.Nombre;
        _vista.RolSesion = Soporte.NombreRol(usuario.Rol);
        _vista.ContactoSesion = string.Join("\n",
            new[] { usuario.Telefono, usuario.Correo }.Where(t => !string.IsNullOrWhiteSpace(t)));

        _vista.MostrarModulos(Permisos.ModulosVisibles(usuario.Rol));
        ActualizarReloj();
        Abrir(Modulo.Dashboard);
    }

    /// <summary>Verifica el permiso antes de abrir el módulo.</summary>
    private void Abrir(Modulo modulo)
    {
        if (Permisos.PuedeVer(Soporte.Actor.Rol, modulo))
            _vista.AbrirModulo(modulo);
        else
            _vista.MostrarAviso("No tiene permiso para abrir este módulo.");
    }

    private void ActualizarReloj()
    {
        var ahora = DateTime.Now;
        _vista.Hora = Soporte.Hora(ahora);
        _vista.Fecha = Soporte.Fecha(ahora);
    }

    private void CerrarSesion()
    {
        SesionUsuario.Cerrar();
        _vista.VolverAlLogin();
    }
}
