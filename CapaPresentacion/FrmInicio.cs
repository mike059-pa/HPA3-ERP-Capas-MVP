using CapaPresentacion.Sesion;

namespace CapaPresentacion;

/// <summary>Formulario hijo de bienvenida que se abre dentro del panel contenedor.</summary>
public partial class FrmInicio : Form
{
    public FrmInicio()
    {
        InitializeComponent();
    }

    private void FrmInicio_Load(object sender, EventArgs e)
    {
        var usuario = SesionUsuario.Actual;
        if (usuario is null)
            return;

        lblBienvenida.Text = $"¡Bienvenido, {usuario.Nombre}!";
        lblDetalle.Text =
            $"Usuario: {usuario.Usuario}\n" +
            $"Sesión iniciada: {SesionUsuario.Inicio:dd/MM/yyyy hh:mm:ss tt}\n" +
            $"Cuenta creada: {usuario.FechaCreacion:dd/MM/yyyy} por {usuario.UsuarioCreacion}";
    }
}
