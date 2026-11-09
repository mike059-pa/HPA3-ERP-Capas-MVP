using CapaNegocio;
using CapaPresentacion.Vistas;

namespace CapaPresentacion.Presentadores;

/// <summary>
/// Presentador del auto‑registro: envía los datos a Negocio, que genera el hash
/// (IHashService) y crea la cuenta con rol Cliente.
/// </summary>
public class RegistroPresentador
{
    private readonly IVistaRegistro _vista;
    private readonly N_Usuario _negocio;

    public RegistroPresentador(IVistaRegistro vista, N_Usuario negocio)
    {
        _vista = vista;
        _negocio = negocio;
        _vista.Registrar += (_, _) => Soporte.Ejecutar(Registrar, m => _vista.MostrarMensaje(m, false));
    }

    private void Registrar()
    {
        var resultado = _negocio.RegistrarCliente(_vista.Usuario, _vista.Nombre, _vista.Correo,
            _vista.Telefono, _vista.Password, _vista.Confirmacion);

        _vista.MostrarMensaje(resultado.Mensaje, resultado.Exito);
        if (resultado.Exito)
            _vista.Limpiar();
    }
}
