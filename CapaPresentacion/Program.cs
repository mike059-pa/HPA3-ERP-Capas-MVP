using CapaNegocio.Servicios;
using CapaPresentacion.Presentadores;

namespace CapaPresentacion;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        // Una sola clase implementa los dos contratos de hash
        var passwordService = new Sha512PasswordService();
        Servicios.Inicializar(passwordService, passwordService);

        var login = new FrmLogin();
        _ = new LoginPresentador(login, Servicios.Usuarios);
        Application.Run(login);
    }
}
