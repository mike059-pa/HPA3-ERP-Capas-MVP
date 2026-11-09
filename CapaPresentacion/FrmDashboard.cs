using System.Data;
using CapaPresentacion.Vistas;

namespace CapaPresentacion;

/// <summary>
/// Vista del dashboard: tarjetas "Sumario del sistema", lista inferior y reloj grande.
/// Las tarjetas se generan según los datos que envía <see cref="Presentadores.DashboardPresentador"/>.
/// </summary>
public partial class FrmDashboard : Form, IVistaDashboard
{
    public event EventHandler? Cargar;
    public event EventHandler? TickReloj;

    public FrmDashboard()
    {
        InitializeComponent();
        Estilo.EstilizarGrid(gridLista);
    }

    string IVistaDashboard.Hora { set => lblHoraGrande.Text = value; }
    string IVistaDashboard.Fecha { set => lblFechaGrande.Text = value; }

    public void MostrarTarjetas(IReadOnlyList<TarjetaResumen> tarjetas)
    {
        flowTarjetas.SuspendLayout();
        flowTarjetas.Controls.Clear();
        for (int i = 0; i < tarjetas.Count; i++)
            flowTarjetas.Controls.Add(CrearTarjeta(tarjetas[i], Estilo.ColoresTarjeta[i % Estilo.ColoresTarjeta.Length]));
        flowTarjetas.ResumeLayout();
    }

    public void MostrarLista(string titulo, DataTable datos)
    {
        lblLista.Text = titulo;
        gridLista.DataSource = datos;
    }

    public void MostrarError(string mensaje)
    {
        lblLista.Text = mensaje;
        lblLista.ForeColor = Estilo.Error;
    }

    /// <summary>Tarjeta con encabezado oscuro, icono al centro y cifra de color abajo.</summary>
    private static Panel CrearTarjeta(TarjetaResumen datos, Color color)
    {
        var tarjeta = new Panel
        {
            Size = new Size(128, 140),
            Margin = new Padding(0, 0, 14, 14),
            BackColor = Color.White,
            BorderStyle = BorderStyle.FixedSingle
        };
        var encabezado = new Label
        {
            Text = datos.Titulo,
            Dock = DockStyle.Top,
            Height = 30,
            BackColor = Estilo.BarraTitulo,
            ForeColor = Color.White,
            Font = new Font("Segoe UI", 9.5F),
            TextAlign = ContentAlignment.MiddleCenter
        };
        var valor = new Label
        {
            Text = datos.Valor,
            Dock = DockStyle.Bottom,
            Height = 32,
            ForeColor = color,
            Font = new Font("Segoe UI", 11F, FontStyle.Bold),
            TextAlign = ContentAlignment.MiddleCenter
        };
        var icono = new Label
        {
            Dock = DockStyle.Fill,
            Image = Estilo.CrearIcono(datos.Icono, Estilo.TextoOscuro, 40),
            ImageAlign = ContentAlignment.MiddleCenter
        };
        tarjeta.Controls.Add(icono);
        tarjeta.Controls.Add(valor);
        tarjeta.Controls.Add(encabezado);
        return tarjeta;
    }

    private void FrmDashboard_Load(object sender, EventArgs e)
    {
        Cargar?.Invoke(this, EventArgs.Empty);
        timerReloj.Start();
    }

    private void timerReloj_Tick(object sender, EventArgs e) => TickReloj?.Invoke(this, EventArgs.Empty);
}
