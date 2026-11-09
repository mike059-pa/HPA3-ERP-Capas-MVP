using CapaNegocio;
using CapaNegocio.Servicios;
using CapaPresentacion.Presentadores;

namespace CapaPresentacion;

static class Program
{
    /// <summary>
    /// Lógica de negocio compartida. Se construye una sola vez aquí (raíz de composición):
    /// para cambiar el algoritmo de hash basta con cambiar la clase instanciada.
    /// </summary>
    internal static N_Usuario Negocio { get; private set; } = null!;

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        var passwordService = new Sha512PasswordService();
        Negocio = new N_Usuario(passwordService, passwordService);

        var login = new FrmLogin();
        _ = new LoginPresentador(login, Negocio);
        Application.Run(login);
    }
}
