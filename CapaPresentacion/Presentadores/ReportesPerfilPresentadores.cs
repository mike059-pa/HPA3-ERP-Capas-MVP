using CapaNegocio;
using CapaPresentacion.Vistas;

namespace CapaPresentacion.Presentadores;

/// <summary>Presentador de reportes (solo Administrador).</summary>
public class ReportesPresentador
{
    private readonly IVistaReportes _vista;
    private readonly N_Reporte _negocio;

    public ReportesPresentador(IVistaReportes vista, N_Reporte negocio)
    {
        _vista = vista;
        _negocio = negocio;
        _vista.Cargar += (_, _) => Soporte.Ejecutar(Generar, _vista.MostrarMensaje);
        _vista.Generar += (_, _) => Soporte.Ejecutar(Generar, _vista.MostrarMensaje);
    }

    private void Generar()
    {
        var resultado = _negocio.Generar(Soporte.Actor, _vista.Tipo, _vista.Desde, _vista.Hasta);
        if (!resultado.Exito || resultado.Dato is null)
        {
            _vista.MostrarMensaje(resultado.Mensaje);
            return;
        }

        string encabezado = _vista.Tipo == TipoReporte.VentasPorProducto ? "Unidades" : "N.º de ventas";
        _vista.MostrarReporte(resultado.Dato, encabezado, Formato.Dinero(resultado.Dato.Sum(f => f.Total)));
        _vista.MostrarMensaje(resultado.Dato.Count == 0 ? "No hay ventas en el período seleccionado." : string.Empty);
    }
}

/// <summary>
/// Presentador del perfil: muestra los datos del usuario y cambia su contraseña
/// (Negocio verifica la actual con IVerificarHashService y genera la nueva con IHashService).
/// </summary>
public class PerfilPresentador
{
    private readonly IVistaPerfil _vista;
    private readonly N_Usuario _negocio;

    public PerfilPresentador(IVistaPerfil vista, N_Usuario negocio)
    {
        _vista = vista;
        _negocio = negocio;
        _vista.Cargar += (_, _) => Cargar();
        _vista.CambiarPassword += (_, _) => Soporte.Ejecutar(CambiarPassword, m => _vista.MostrarMensaje(m, false));
    }

    private void Cargar()
    {
        var u = Soporte.Actor;
        _vista.MostrarDatos(u.Usuario, u.Nombre, Soporte.NombreRol(u.Rol),
            string.IsNullOrEmpty(u.Correo) ? "—" : u.Correo,
            string.IsNullOrEmpty(u.Telefono) ? "—" : u.Telefono,
            $"{u.FechaCreacion:dd/MM/yyyy} por {u.UsuarioCreacion}");
    }

    private void CambiarPassword()
    {
        var resultado = _negocio.CambiarPassword(Soporte.Actor, _vista.PasswordActual, _vista.PasswordNueva, _vista.Confirmacion);
        _vista.MostrarMensaje(resultado.Mensaje, resultado.Exito);
        if (resultado.Exito)
            _vista.LimpiarPasswords();
    }
}
