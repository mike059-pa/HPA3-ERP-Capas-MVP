using CapaNegocio;
using CapaPresentacion.Vistas;

namespace CapaPresentacion;

/// <summary>
/// Vista principal: formulario plano sin bordes con menú lateral animado (generado según el rol),
/// reloj en la barra de título y el usuario en sesión en la parte inferior del menú.
/// </summary>
public partial class FrmPrincipal : Form, IVistaPrincipal
{
    // Valores lógicos (a 96 DPI); se escalan según la pantalla con LogicalToDeviceUnits
    private const int AnchoMenuContraidoLogico = 55;
    private const int PasoAnimacionLogico = 25;

    /// <summary>Texto e icono de cada opción del menú.</summary>
    private static readonly Dictionary<Modulo, (string Texto, string Icono)> Opciones = new()
    {
        [Modulo.Dashboard] = ("Dashboard", Estilo.IconoInicio),
        [Modulo.Usuarios] = ("Usuarios", Estilo.IconoUsuarios),
        [Modulo.Productos] = ("Productos", Estilo.IconoProductos),
        [Modulo.Clientes] = ("Clientes", Estilo.IconoClientes),
        [Modulo.Ventas] = ("Ventas", Estilo.IconoVentas),
        [Modulo.Comprar] = ("Comprar", Estilo.IconoComprar),
        [Modulo.MisCompras] = ("Mis compras", Estilo.IconoMisCompras),
        [Modulo.Reportes] = ("Reportes", Estilo.IconoReportes),
        [Modulo.Perfil] = ("Mi perfil", Estilo.IconoPerfil)
    };

    private readonly Dictionary<Modulo, Button> _botones = [];
    private int _anchoMenuExpandido;
    private bool _menuExpandido = true;
    private Form? _formularioActivo;

    public event EventHandler? Cargar;
    public event EventHandler? TickReloj;
    public event EventHandler<Modulo>? ModuloSeleccionado;
    public event EventHandler? CerrarSesion;

    /// <summary>Indica si la ventana se cerró por "Cerrar sesión" (volver al login).</summary>
    public bool SesionCerrada { get; private set; }

    public FrmPrincipal()
    {
        InitializeComponent();
        btnMenu.Image = Estilo.CrearIcono(Estilo.IconoMenu, Color.White);
        btnCerrarSesion.Image = Estilo.CrearIcono(Estilo.IconoCerrarSesion, Estilo.TextoClaro);
        lblIconoSesion.Image = Estilo.CrearIcono(Estilo.IconoUsuario, Estilo.Acento, 40);
    }

    // Implementación explícita: el Presentador escribe a través de la interfaz
    string IVistaPrincipal.Hora { set => lblHora.Text = value; }
    string IVistaPrincipal.Fecha { set => lblFecha.Text = value; }
    string IVistaPrincipal.UsuarioSesion { set => lblUsuarioSesion.Text = "@" + value; }
    string IVistaPrincipal.NombreSesion { set => lblNombreSesion.Text = value; }
    string IVistaPrincipal.RolSesion { set => lblRolSesion.Text = value; }
    string IVistaPrincipal.ContactoSesion { set => lblContactoSesion.Text = value; }

    public void MostrarModulos(IReadOnlyList<Modulo> modulos)
    {
        panelOpciones.Controls.Clear();
        _botones.Clear();

        // Con Dock = Top el último control agregado queda arriba, por eso se recorre al revés
        foreach (var modulo in modulos.Reverse())
        {
            var (texto, icono) = Opciones[modulo];
            var boton = new Button
            {
                Text = "   " + texto,
                Image = Estilo.CrearIcono(icono, Estilo.TextoClaro),
                Dock = DockStyle.Top,
                Height = 48,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 11F),
                ForeColor = Estilo.TextoClaro,
                ImageAlign = ContentAlignment.MiddleLeft,
                TextAlign = ContentAlignment.MiddleLeft,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                Padding = new Padding(14, 0, 0, 0),
                Cursor = Cursors.Hand,
                Tag = modulo
            };
            boton.FlatAppearance.BorderSize = 0;
            boton.FlatAppearance.MouseOverBackColor = Estilo.FondoMenuHover;
            boton.Click += (_, _) => ModuloSeleccionado?.Invoke(this, (Modulo)boton.Tag!);
            panelOpciones.Controls.Add(boton);
            _botones[modulo] = boton;
        }
    }

    public void AbrirModulo(Modulo modulo)
    {
        foreach (var (clave, boton) in _botones)
            boton.BackColor = clave == modulo ? Estilo.FondoMenuHover : Estilo.FondoMenu;
        lblTituloBarra.Text = Opciones[modulo].Texto;
        AbrirFormEnPanel(Servicios.CrearModulo(modulo));
    }

    public void MostrarAviso(string mensaje) =>
        MessageBox.Show(this, mensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

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

    private void FrmPrincipal_Load(object sender, EventArgs e)
    {
        // Al maximizar sin bordes, no tapar la barra de tareas
        MaximizedBounds = Screen.FromHandle(Handle).WorkingArea;
        _anchoMenuExpandido = panelMenu.Width;   // ancho ya escalado al DPI de la pantalla
        timerReloj.Start();
        Cargar?.Invoke(this, EventArgs.Empty);
    }

    private void timerReloj_Tick(object sender, EventArgs e) => TickReloj?.Invoke(this, EventArgs.Empty);

    private void btnCerrarSesion_Click(object sender, EventArgs e) => CerrarSesion?.Invoke(this, EventArgs.Empty);

    // ---- Menú lateral animado ----
    private void btnMenu_Click(object sender, EventArgs e) => timerMenu.Start();

    private void timerMenu_Tick(object sender, EventArgs e)
    {
        int contraido = LogicalToDeviceUnits(AnchoMenuContraidoLogico);
        int paso = LogicalToDeviceUnits(PasoAnimacionLogico);
        if (_menuExpandido)
        {
            panelMenu.Width = Math.Max(contraido, panelMenu.Width - paso);
            if (panelMenu.Width == contraido)
            {
                timerMenu.Stop();
                _menuExpandido = false;
            }
        }
        else
        {
            panelMenu.Width = Math.Min(_anchoMenuExpandido, panelMenu.Width + paso);
            if (panelMenu.Width == _anchoMenuExpandido)
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
