using CapaPresentacion.Vistas;

namespace CapaPresentacion;

/// <summary>Vista "Mi perfil": datos del usuario en sesión y cambio de contraseña.</summary>
public partial class FrmPerfil : Form, IVistaPerfil
{
    public event EventHandler? Cargar;
    public event EventHandler? CambiarPassword;

    public FrmPerfil()
    {
        InitializeComponent();
        Estilo.BotonPrimario(btnCambiar);
        lblAvatar.Image = Estilo.CrearIcono(Estilo.IconoUsuario, Estilo.Acento, 64);
    }

    public string PasswordActual => txtActual.Text;
    public string PasswordNueva => txtNueva.Text;
    public string Confirmacion => txtConfirmacion.Text;

    public void MostrarDatos(string usuario, string nombre, string rol, string correo, string telefono, string creado)
    {
        lblNombre.Text = nombre;
        lblRol.Text = rol;
        lblDatos.Text = string.Join("\n",
            $"{"Usuario:",-10} @{usuario}",
            $"{"Correo:",-10} {correo}",
            $"{"Teléfono:",-10} {telefono}",
            $"{"Creado:",-10} {creado}");
    }

    public void MostrarMensaje(string mensaje, bool exito)
    {
        lblMensaje.ForeColor = exito ? Estilo.Exito : Estilo.Error;
        lblMensaje.Text = mensaje;
    }

    public void LimpiarPasswords()
    {
        txtActual.Clear();
        txtNueva.Clear();
        txtConfirmacion.Clear();
    }

    private void FrmPerfil_Load(object sender, EventArgs e) => Cargar?.Invoke(this, EventArgs.Empty);

    private void btnCambiar_Click(object sender, EventArgs e) => CambiarPassword?.Invoke(this, EventArgs.Empty);
}
