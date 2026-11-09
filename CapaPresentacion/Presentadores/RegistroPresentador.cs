using CapaNegocio;
using CapaPresentacion.Sesion;
using CapaPresentacion.Vistas;

namespace CapaPresentacion.Presentadores;

/// <summary>
/// Presentador del registro: envía los datos a Negocio, que genera el hash
/// (IHashService) antes de guardar en la capa de Datos.
/// </summary>
public class RegistroPresentador
{
    private readonly IVistaRegistro _vista;
    private readonly N_Usuario _negocio;

    public RegistroPresentador(IVistaRegistro vista, N_Usuario negocio)
    {
        _vista = vista;
        _negocio = negocio;
        _vista.Registrar += (_, _) => Registrar();
    }

    private void Registrar()
    {
        try
        {
            var creadoPor = SesionUsuario.Actual?.Usuario ?? "Sistema";
            var resultado = _negocio.Registrar(_vista.Usuario, _vista.Nombre,
                _vista.Password, _vista.Confirmacion, creadoPor);

            _vista.MostrarMensaje(resultado.Mensaje, resultado.Exito);
            if (resultado.Exito)
                _vista.Limpiar();
        }
        catch (Exception ex)
        {
            _vista.MostrarMensaje("Error al registrar: " + ex.Message, false);
        }
    }
}
