using CapaPresentacion.Vistas;

namespace CapaPresentacion;

/// <summary>
/// Vista de registro de usuarios. Implementa <see cref="IVistaRegistro"/>;
/// la lógica la ejecuta <see cref="Presentadores.RegistroPresentador"/>.
/// </summary>
public partial class FrmRegistro : Form, IVistaRegistro
{
    public event EventHandler? Registrar;

    public FrmRegistro()
    {
        InitializeComponent();
    }

    public string Usuario => txtUsuario.Text;
    public string Nombre => txtNombre.Text;
    public string Password => txtPassword.Text;
    public string Confirmacion => txtConfirmacion.Text;

    public void MostrarMensaje(string mensaje, bool exito)
    {
        lblMensaje.ForeColor = exito ? Estilo.Exito : Estilo.Error;
        lblMensaje.Text = mensaje;
    }

    public void Limpiar()
    {
        txtUsuario.Clear();
        txtNombre.Clear();
        txtPassword.Clear();
        txtConfirmacion.Clear();
        txtUsuario.Focus();
    }

    private void btnRegistrar_Click(object sender, EventArgs e) => Registrar?.Invoke(this, EventArgs.Empty);
}
