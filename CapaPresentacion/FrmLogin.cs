using CapaPresentacion.Presentadores;
using CapaPresentacion.Vistas;

namespace CapaPresentacion;

/// <summary>
/// Vista de inicio de sesión. Implementa <see cref="IVistaLogin"/>;
/// toda la lógica la ejecuta <see cref="Presentadores.LoginPresentador"/>.
/// </summary>
public partial class FrmLogin : Form, IVistaLogin
{
    public event EventHandler? IniciarSesion;

    public FrmLogin()
    {
        InitializeComponent();
        lblIcono.Image = Estilo.CrearIcono(Estilo.IconoUsuario, Estilo.Acento, 48);
    }

    public string Usuario => txtUsuario.Text;
    public string Password => txtPassword.Text;

    public void MostrarError(string mensaje) => lblError.Text = mensaje;

    public void MostrarErrorCampo(CampoLogin campo, string mensaje)
    {
        var control = campo == CampoLogin.Usuario ? txtUsuario : txtPassword;
        errorProvider.SetError(control, mensaje);
    }

    public void LimpiarErrores()
    {
        lblError.Text = string.Empty;
        errorProvider.Clear();
    }

    public void LoginExitoso()
    {
        Hide();
        var principal = new FrmPrincipal();
        _ = new PrincipalPresentador(principal);
        principal.FormClosed += (_, _) =>
        {
            // Si se cerró sesión se vuelve al login; si se cerró la app, se termina
            if (principal.SesionCerrada)
            {
                txtPassword.Clear();
                LimpiarErrores();
                Show();
                txtPassword.Focus();
            }
            else
            {
                Close();
            }
        };
        principal.Show();
    }

    private void btnIngresar_Click(object sender, EventArgs e) => IniciarSesion?.Invoke(this, EventArgs.Empty);

    private void chkMostrar_CheckedChanged(object sender, EventArgs e) =>
        txtPassword.UseSystemPasswordChar = !chkMostrar.Checked;

    private void btnCerrar_Click(object sender, EventArgs e) => Application.Exit();

    private void FrmLogin_MouseDown(object sender, MouseEventArgs e) => Estilo.ArrastrarFormulario(this);
}
