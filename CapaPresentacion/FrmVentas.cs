using CapaEntidades;
using CapaNegocio;
using CapaPresentacion.Vistas;

namespace CapaPresentacion;

/// <summary>
/// Vista de ventas con dos pestañas: nueva venta (carrito) e historial con detalle.
/// Para el rol Cliente se muestra como "Comprar" y "Mis compras".
/// </summary>
public partial class FrmVentas : Form, IVistaVentas
{
    private readonly bool _abrirHistorial;
    private List<E_Venta> _ventas = [];

    public event EventHandler? Cargar;
    public event EventHandler? ProductoCambiado;
    public event EventHandler? AgregarProducto;
    public event EventHandler? QuitarProducto;
    public event EventHandler? LimpiarCarrito;
    public event EventHandler? RegistrarVenta;
    public event EventHandler? FiltrarHistorial;
    public event EventHandler? VentaCambiada;

    /// <param name="abrirHistorial">true para iniciar en la pestaña del historial.</param>
    public FrmVentas(bool abrirHistorial = false)
    {
        InitializeComponent();
        _abrirHistorial = abrirHistorial;
        Estilo.EstilizarGrid(gridCarrito);
        Estilo.EstilizarGrid(gridVentas);
        Estilo.EstilizarGrid(gridDetalle);
        Estilo.BotonPrimario(btnAgregar);
        Estilo.BotonSecundario(btnQuitar);
        Estilo.BotonSecundario(btnLimpiar);
        Estilo.BotonPrimario(btnRegistrar);
        Estilo.BotonSecundario(btnFiltrar);
        dtpDesde.Value = DateTime.Today.AddDays(-30);
        dtpHasta.Value = DateTime.Today;
    }

    public E_Producto? ProductoSeleccionado => cboProducto.SelectedItem as E_Producto;
    public int Cantidad => (int)nudCantidad.Value;
    public int? ClienteSeleccionado => (cboCliente.SelectedItem as E_Cliente)?.Id;
    public int? IndiceLineaSeleccionada => gridCarrito.SelectedRows.Count == 1 ? gridCarrito.SelectedRows[0].Index : null;
    public DateTime Desde => dtpDesde.Value.Date;
    public DateTime Hasta => dtpHasta.Value.Date;
    public int? VentaSeleccionada => gridVentas.SelectedRows.Count == 1 ? _ventas[gridVentas.SelectedRows[0].Index].Id : null;

    public void ConfigurarModoCliente(string nombreCliente)
    {
        cboCliente.Visible = false;
        lblClienteFijo.Visible = true;
        lblClienteFijo.Text = nombreCliente;
        tabNueva.Text = "Comprar";
        tabHistorial.Text = "Mis compras";
        btnRegistrar.Text = "Comprar";
    }

    public void CargarClientes(List<E_Cliente> clientes)
    {
        cboCliente.DataSource = clientes;
        cboCliente.SelectedIndex = -1;
    }

    public void CargarProductos(List<E_Producto> productos)
    {
        cboProducto.DataSource = productos;
        cboProducto.SelectedIndex = -1;
    }

    public void MostrarInfoProducto(string informacion) => lblInfoProducto.Text = informacion;

    public void MostrarCarrito(List<E_DetalleVenta> carrito, TotalesVenta totales)
    {
        gridCarrito.DataSource = carrito.Select(l => new
        {
            Código = l.Codigo,
            Producto = l.Producto,
            Cantidad = l.Cantidad,
            Precio = Formato.Dinero(l.PrecioUnitario),
            Subtotal = Formato.Dinero(l.Subtotal)
        }).ToList();
        Estilo.AlinearDerecha(gridCarrito, "Cantidad", "Precio", "Subtotal");
        lblSubtotal.Text = $"Subtotal: {Formato.Dinero(totales.Subtotal)}";
        lblItbms.Text = $"ITBMS (7 %): {Formato.Dinero(totales.Itbms)}";
        lblTotal.Text = $"Total: {Formato.Dinero(totales.Total)}";
    }

    public void MostrarHistorial(List<E_Venta> ventas, decimal totalPeriodo)
    {
        _ventas = ventas;
        gridVentas.DataSource = ventas.Select(v => new
        {
            N_º = v.Id,
            Fecha = v.Fecha.ToString("dd/MM/yyyy hh:mm tt"),
            Cliente = v.Cliente,
            Vendedor = v.Vendedor,
            Artículos = v.Articulos,
            Subtotal = Formato.Dinero(v.Subtotal),
            ITBMS = Formato.Dinero(v.Itbms),
            Total = Formato.Dinero(v.Total)
        }).ToList();
        if (gridVentas.Columns["N_º"] is { } columnaNumero)
            columnaNumero.HeaderText = "N.º";
        Estilo.AlinearDerecha(gridVentas, "Artículos", "Subtotal", "ITBMS", "Total");
        gridVentas.ClearSelection();
        lblTotalPeriodo.Text = $"{ventas.Count} venta(s) · Total: {Formato.Dinero(totalPeriodo)}";
    }

    public void MostrarDetalle(List<E_DetalleVenta> detalle)
    {
        gridDetalle.DataSource = detalle.Select(l => new
        {
            Código = l.Codigo,
            Producto = l.Producto,
            Cantidad = l.Cantidad,
            Precio = Formato.Dinero(l.PrecioUnitario),
            Subtotal = Formato.Dinero(l.Subtotal)
        }).ToList();
        Estilo.AlinearDerecha(gridDetalle, "Cantidad", "Precio", "Subtotal");
    }

    public void MostrarMensaje(string mensaje, bool exito)
    {
        lblMensaje.ForeColor = exito ? Estilo.Exito : Estilo.Error;
        lblMensaje.Text = mensaje;
    }

    public void MostrarMensajeHistorial(string mensaje, bool exito)
    {
        lblMensajeHistorial.ForeColor = exito ? Estilo.Exito : Estilo.Error;
        lblMensajeHistorial.Text = mensaje;
    }

    private void FrmVentas_Load(object sender, EventArgs e)
    {
        Cargar?.Invoke(this, EventArgs.Empty);
        if (_abrirHistorial)
            tabVentas.SelectedTab = tabHistorial;
    }

    private void cboProducto_SelectedIndexChanged(object sender, EventArgs e) => ProductoCambiado?.Invoke(this, EventArgs.Empty);

    private void btnAgregar_Click(object sender, EventArgs e) => AgregarProducto?.Invoke(this, EventArgs.Empty);

    private void btnQuitar_Click(object sender, EventArgs e) => QuitarProducto?.Invoke(this, EventArgs.Empty);

    private void btnLimpiar_Click(object sender, EventArgs e) => LimpiarCarrito?.Invoke(this, EventArgs.Empty);

    private void btnRegistrar_Click(object sender, EventArgs e) => RegistrarVenta?.Invoke(this, EventArgs.Empty);

    private void btnFiltrar_Click(object sender, EventArgs e) => FiltrarHistorial?.Invoke(this, EventArgs.Empty);

    private void gridVentas_SelectionChanged(object sender, EventArgs e) => VentaCambiada?.Invoke(this, EventArgs.Empty);
}
