using CapaPresentacion.Presentadores;
using CapaPresentacion.Vistas;

namespace CapaPresentacion;

/// <summary>
/// Vista principal: formulario plano sin bordes con menú lateral animado,
/// reloj en la barra de título y el usuario en sesión en la parte inferior del menú.
/// </summary>
public partial class FrmPrincipal : Form, IVistaPrincipal
{
    private const int AnchoMenuExpandido = 230;
    private const int AnchoMenuContraido = 55;
    private const int PasoAnimacion = 25;

    private bool _menuExpandido = true;
    private Form? _formularioActivo;

    public event EventHandler? Cargar;
    public event EventHandler? TickReloj;
    public event EventHandler? CerrarSesion;

    /// <summary>Indica si la ventana se cerró por "Cerrar sesión" (volver al login).</summary>
    public bool SesionCerrada { get; private set; }

    public FrmPrincipal()
    {
        InitializeComponent();
        btnMenu.Image = Estilo.CrearIcono(Estilo.IconoMenu, Color.White);
        btnInicio.Image = Estilo.CrearIcono(Estilo.IconoInicio, Estilo.TextoClaro);
        btnRegistrar.Image = Estilo.CrearIcono(Estilo.IconoAgregarUsuario, Estilo.TextoClaro);
        btnCerrarSesion.Image = Estilo.CrearIcono(Estilo.IconoCerrarSesion, Estilo.TextoClaro);
        lblIconoSesion.Image = Estilo.CrearIcono(Estilo.IconoUsuario, Estilo.Acento, 26);
    }

    // Implementación explícita: el Presentador escribe a través de la interfaz
    string IVistaPrincipal.Hora { set => lblHora.Text = value; }
    string IVistaPrincipal.Fecha { set => lblFecha.Text = value; }
    string IVistaPrincipal.UsuarioSesion { set => lblUsuarioSesion.Text = value; }
    string IVistaPrincipal.NombreSesion { set => lblNombreSesion.Text = value; }

    public void VolverAlLogin()
    {
        SesionCerrada = true;
        Close();
    }

    /// <summary>Abre un formulario hijo dentro del panel contenedor.</summary>
    private void AbrirFormEnPanel(Form hijo)
    {
        _formularioActivo?.Close();
        _formularioActivo = hijo;
        hijo.TopLevel = false;
        hijo.FormBorderStyle = FormBorderStyle.None;
        hijo.Dock = DockStyle.Fill;
        panelContenedor.Controls.Add(hijo);
        hijo.Show();
    }

    private void MarcarBotonActivo(Button activo)
    {
        foreach (var boton in new[] { btnInicio, btnRegistrar })
            boton.BackColor = boton == activo ? Estilo.FondoMenuHover : Estilo.FondoMenu;
    }

    private void FrmPrincipal_Load(object sender, EventArgs e)
    {
        // Al maximizar sin bordes, no tapar la barra de tareas
        MaximizedBounds = Screen.FromHandle(Handle).WorkingArea;
        Cargar?.Invoke(this, EventArgs.Empty);
        timerReloj.Start();
        btnInicio_Click(btnInicio, EventArgs.Empty);
    }

    private void timerReloj_Tick(object sender, EventArgs e) => TickReloj?.Invoke(this, EventArgs.Empty);

    private void btnInicio_Click(object sender, EventArgs e)
    {
        MarcarBotonActivo(btnInicio);
        AbrirFormEnPanel(new FrmInicio());
    }

    private void btnRegistrar_Click(object sender, EventArgs e)
    {
        MarcarBotonActivo(btnRegistrar);
        var registro = new FrmRegistro();
        _ = new RegistroPresentador(registro, Program.Negocio);
        AbrirFormEnPanel(registro);
    }

    private void btnCerrarSesion_Click(object sender, EventArgs e) => CerrarSesion?.Invoke(this, EventArgs.Empty);

    // ---- Menú lateral animado ----
    private void btnMenu_Click(object sender, EventArgs e) => timerMenu.Start();

    private void timerMenu_Tick(object sender, EventArgs e)
    {
        if (_menuExpandido)
        {
            panelMenu.Width = Math.Max(AnchoMenuContraido, panelMenu.Width - PasoAnimacion);
            if (panelMenu.Width == AnchoMenuContraido)
            {
                timerMenu.Stop();
                _menuExpandido = false;
            }
        }
        else
        {
            panelMenu.Width = Math.Min(AnchoMenuExpandido, panelMenu.Width + PasoAnimacion);
            if (panelMenu.Width == AnchoMenuExpandido)
            {
                timerMenu.Stop();
                _menuExpandido = true;
            }
        }
    }

    // ---- Barra de título personalizada ----
    private void panelBarraTitulo_MouseDown(object sender, MouseEventArgs e) => Estilo.ArrastrarFormulario(this);

    private void btnCerrar_Click(object sender, EventArgs e) => Close();

    private void btnMinimizar_Click(object sender, EventArgs e) => WindowState = FormWindowState.Minimized;

    private void btnMaximizar_Click(object sender, EventArgs e) =>
        WindowState = WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
}
