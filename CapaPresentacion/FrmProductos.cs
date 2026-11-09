using CapaEntidades;
using CapaNegocio;
using CapaPresentacion.Vistas;

namespace CapaPresentacion;

/// <summary>
/// Vista del mantenimiento de productos (CRUD). Los productos con stock en el mínimo se resaltan.
/// En modo solo consulta (Vendedor) se oculta el panel de edición.
/// </summary>
public partial class FrmProductos : Form, IVistaProductos
{
    private List<E_Producto> _lista = [];
    private int _idEditando;

    public event EventHandler? Cargar;
    public event EventHandler? Buscar;
    public event EventHandler? SeleccionCambiada;
    public event EventHandler? Nuevo;
    public event EventHandler? Guardar;
    public event EventHandler? Eliminar;

    public FrmProductos()
    {
        InitializeComponent();
        Estilo.EstilizarGrid(gridDatos);
        Estilo.BotonSecundario(btnBuscar);
        Estilo.BotonSecundario(btnNuevo);
        Estilo.BotonPrimario(btnGuardar);
        Estilo.BotonPeligro(btnEliminar);
        CargarFormulario(null);
    }

    public string TextoBusqueda => txtBuscar.Text;

    public E_Producto? Seleccionado =>
        gridDatos.SelectedRows.Count == 1 ? _lista[gridDatos.SelectedRows[0].Index] : null;

    bool IVistaProductos.PermitirEdicion
    {
        set
        {
            panelEditor.Visible = value;
            lblTitulo.Text = value ? "Productos" : "Productos (solo consulta)";
        }
    }

    public void MostrarLista(List<E_Producto> elementos)
    {
        _lista = elementos;
        gridDatos.DataSource = elementos.Select(p => new
        {
            ID = p.Id,
            Código = p.Codigo,
            Producto = p.Nombre,
            Precio = Formato.Dinero(p.Precio),
            Stock = p.Stock,
            Mínimo = p.StockMinimo,
            Activo = p.Estado
        }).ToList();
        Estilo.AlinearDerecha(gridDatos, "Precio", "Stock", "Mínimo");
    }

    public void CargarFormulario(E_Producto? elemento)
    {
        _idEditando = elemento?.Id ?? 0;
        txtCodigo.Text = elemento?.Codigo ?? string.Empty;
        txtNombre.Text = elemento?.Nombre ?? string.Empty;
        txtDescripcion.Text = elemento?.Descripcion ?? string.Empty;
        nudPrecio.Value = elemento?.Precio ?? 0;
        nudStock.Value = elemento?.Stock ?? 0;
        nudStockMinimo.Value = elemento?.StockMinimo ?? 5;
        chkActivo.Checked = elemento?.Estado ?? true;
        lblEditor.Text = elemento is null ? "Nuevo producto" : $"Editando: {elemento.Codigo}";
    }

    public E_Producto LeerFormulario() => new()
    {
        Id = _idEditando,
        Codigo = txtCodigo.Text,
        Nombre = txtNombre.Text,
        Descripcion = txtDescripcion.Text,
        Precio = nudPrecio.Value,
        Stock = (int)nudStock.Value,
        StockMinimo = (int)nudStockMinimo.Value,
        Estado = chkActivo.Checked
    };

    public void MostrarMensaje(string mensaje, bool exito)
    {
        lblMensaje.ForeColor = exito ? Estilo.Exito : Estilo.Error;
        lblMensaje.Text = mensaje;
    }

    public bool Confirmar(string pregunta) =>
        MessageBox.Show(this, pregunta, "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

    private void FrmProductos_Load(object sender, EventArgs e) => Cargar?.Invoke(this, EventArgs.Empty);

    /// <summary>Resalta en rojo los productos activos con stock en el mínimo o por debajo.</summary>
    private void gridDatos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        if (e.RowIndex < 0 || e.RowIndex >= _lista.Count || e.CellStyle is null)
            return;
        var producto = _lista[e.RowIndex];
        if (producto.Estado && producto.Stock <= producto.StockMinimo)
            e.CellStyle.ForeColor = Estilo.Error;
        else if (!producto.Estado)
            e.CellStyle.ForeColor = Color.Gray;
    }

    private void gridDatos_SelectionChanged(object sender, EventArgs e)
    {
        // Solo selecciones hechas por el usuario (grid con el foco), no las automáticas al enlazar datos
        if (gridDatos.Focused && Seleccionado is not null)
            SeleccionCambiada?.Invoke(this, EventArgs.Empty);
    }

    private void btnBuscar_Click(object sender, EventArgs e) => Buscar?.Invoke(this, EventArgs.Empty);

    private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            e.SuppressKeyPress = true;
            Buscar?.Invoke(this, EventArgs.Empty);
        }
    }

    private void btnNuevo_Click(object sender, EventArgs e) => Nuevo?.Invoke(this, EventArgs.Empty);

    private void btnGuardar_Click(object sender, EventArgs e) => Guardar?.Invoke(this, EventArgs.Empty);

    private void btnEliminar_Click(object sender, EventArgs e) => Eliminar?.Invoke(this, EventArgs.Empty);
}
