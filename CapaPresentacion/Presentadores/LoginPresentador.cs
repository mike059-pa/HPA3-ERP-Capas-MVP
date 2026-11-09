using CapaNegocio;
using CapaPresentacion.Sesion;
using CapaPresentacion.Vistas;

namespace CapaPresentacion.Presentadores;

/// <summary>
/// Presentador del login: recibe la acción de la Vista, pide a la capa de Negocio
/// verificar las credenciales y devuelve el resultado a la Vista.
/// </summary>
public class LoginPresentador
{
    private readonly IVistaLogin _vista;
    private readonly N_Usuario _negocio;

    public LoginPresentador(IVistaLogin vista, N_Usuario negocio)
    {
        _vista = vista;
        _negocio = negocio;
        _vista.IniciarSesion += (_, _) => IniciarSesion();
    }

    private void IniciarSesion()
    {
        _vista.LimpiarErrores();

        // Validaciones de entrada (formato) antes de llamar a Negocio
        bool valido = true;
        if (string.IsNullOrWhiteSpace(_vista.Usuario))
        {
            _vista.MostrarErrorCampo(CampoLogin.Usuario, "Ingrese el usuario.");
            valido = false;
        }
        if (string.IsNullOrEmpty(_vista.Password))
        {
            _vista.MostrarErrorCampo(CampoLogin.Password, "Ingrese la contraseña.");
            valido = false;
        }
        if (!valido)
        {
            _vista.MostrarError("Complete los campos obligatorios.");
            return;
        }

        try
        {
            var resultado = _negocio.Login(_vista.Usuario, _vista.Password);
            if (!resultado.Exito || resultado.Dato is null)
            {
                _vista.MostrarError(resultado.Mensaje);
                return;
            }

            SesionUsuario.Iniciar(resultado.Dato);
            _vista.LoginExitoso();
        }
        catch (Exception ex)
        {
            _vista.MostrarError("No se pudo conectar con la base de datos: " + ex.Message);
        }
    }
}
