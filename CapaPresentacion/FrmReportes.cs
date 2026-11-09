using CapaEntidades;
using CapaNegocio;
using CapaPresentacion.Vistas;

namespace CapaPresentacion;

/// <summary>Vista de reportes: tabla y gráfico de barras horizontales de los totales.</summary>
public partial class FrmReportes : Form, IVistaReportes
{
    private const int MaximoBarras = 8;
    private List<E_FilaReporte> _filas = [];

    public event EventHandler? Cargar;
    public event EventHandler? Generar;

    public FrmReportes()
    {
        InitializeComponent();
        Estilo.EstilizarGrid(gridReporte);
        Estilo.BotonPrimario(btnGenerar);
        cboTipo.Items.AddRange(["Ventas por producto", "Ventas por vendedor"]);
        cboTipo.SelectedIndex = 0;
        dtpDesde.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(-1);
        dtpHasta.Value = DateTime.Today;
    }

    public TipoReporte Tipo => cboTipo.SelectedIndex == 1 ? TipoReporte.VentasPorVendedor : TipoReporte.VentasPorProducto;
    public DateTime Desde => dtpDesde.Value.Date;
    public DateTime Hasta => dtpHasta.Value.Date;

    public void MostrarReporte(List<E_FilaReporte> filas, string encabezadoCantidad, string total)
    {
        _filas = filas;
        gridReporte.DataSource = filas.Select(f => new
        {
            Descripción = f.Descripcion,
            Cantidad = f.Cantidad,
            Total = Formato.Dinero(f.Total)
        }).ToList();
        if (gridReporte.Columns["Cantidad"] is { } columna)
            columna.HeaderText = encabezadoCantidad;
        Estilo.AlinearDerecha(gridReporte, "Cantidad", "Total");
        lblTotal.Text = $"Total general: {total}";
        panelGrafico.Invalidate();
    }

    public void MostrarMensaje(string mensaje)
    {
        lblMensaje.ForeColor = Estilo.Error;
        lblMensaje.Text = mensaje;
    }

    /// <summary>Dibuja barras horizontales proporcionales al total de cada fila.</summary>
    private void panelGrafico_Paint(object sender, PaintEventArgs e)
    {
        var g = e.Graphics;
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        using var fuenteTitulo = new Font("Segoe UI", 11F, FontStyle.Bold);
        using var fuente = new Font("Segoe UI", 9F);
        using var pincelTexto = new SolidBrush(Estilo.TextoOscuro);
        g.DrawString($"Top {MaximoBarras} por total vendido", fuenteTitulo, pincelTexto, 15, 12);

        var datos = _filas.OrderByDescending(f => f.Total).Take(MaximoBarras).ToList();
        if (datos.Count == 0)
            return;

        decimal maximo = Math.Max(datos.Max(f => f.Total), 0.01m);
        int anchoDisponible = panelGrafico.Width - 30;
        int y = 48;
        for (int i = 0; i < datos.Count; i++)
        {
            var fila = datos[i];
            g.DrawString(fila.Descripcion, fuente, pincelTexto, 15, y);
            int ancho = (int)(anchoDisponible * (float)(fila.Total / maximo));
            using var pincelBarra = new SolidBrush(Estilo.ColoresTarjeta[i % Estilo.ColoresTarjeta.Length]);
            g.FillRectangle(pincelBarra, 15, y + 18, Math.Max(ancho, 2), 14);
            g.DrawString(Formato.Dinero(fila.Total), fuente, pincelTexto, 15, y + 33);
            y += 58;
        }
    }

    private void panelGrafico_Resize(object sender, EventArgs e) => panelGrafico.Invalidate();

    private void FrmReportes_Load(object sender, EventArgs e) => Cargar?.Invoke(this, EventArgs.Empty);

    private void btnGenerar_Click(object sender, EventArgs e)
    {
        lblMensaje.Text = string.Empty;
        Generar?.Invoke(this, EventArgs.Empty);
    }
}
