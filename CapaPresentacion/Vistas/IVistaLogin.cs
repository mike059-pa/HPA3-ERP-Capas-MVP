namespace CapaPresentacion.Vistas;

/// <summary>Campos de entrada de la vista de login (para marcar errores).</summary>
public enum CampoLogin { Usuario, Password }

/// <summary>
/// Contrato de la Vista de inicio de sesión (MVP).
/// La vista solo expone datos y eventos; no sabe de hash ni de base de datos.
/// </summary>
public interface IVistaLogin
{
    /// <summary>Texto ingresado en el campo usuario.</summary>
    string Usuario { get; }

    /// <summary>Texto ingresado en el campo contraseña.</summary>
    string Password { get; }

    /// <summary>Se dispara cuando el usuario presiona "Ingresar".</summary>
    event EventHandler IniciarSesion;

    /// <summary>Muestra un mensaje de error general.</summary>
    void MostrarError(string mensaje);

    /// <summary>Marca un campo específico como inválido.</summary>
    void MostrarErrorCampo(CampoLogin campo, string mensaje);

    /// <summary>Quita todos los mensajes de error.</summary>
    void LimpiarErrores();

    /// <summary>Se llama cuando las credenciales son correctas.</summary>
    void LoginExitoso();
}
