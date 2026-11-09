using CapaEntidades;
using CapaPresentacion.Vistas;

namespace CapaPresentacion;

/// <summary>Vista del mantenimiento de clientes (CRUD). La lógica está en <see cref="Presentadores.ClientesPresentador"/>.</summary>
public partial class FrmClientes : Form, IVistaClientes
{
    private List<E_Cliente> _lista = [];
    private E_Cliente? _editando;

    public event EventHandler? Cargar;
    public event EventHandler? Buscar;
    public event EventHandler? SeleccionCambiada;
    public event EventHandler? Nuevo;
    public event EventHandler? Guardar;
    public event EventHandler? Eliminar;

    public FrmClientes()
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

    public E_Cliente? Seleccionado =>
        gridDatos.SelectedRows.Count == 1 ? _lista[gridDatos.SelectedRows[0].Index] : null;

    public void MostrarLista(List<E_Cliente> elementos)
    {
        _lista = elementos;
        gridDatos.DataSource = elementos.Select(c => new
        {
            ID = c.Id,
            Nombre = c.Nombre,
            Cédula = c.Cedula,
            Teléfono = c.Telefono,
            Correo = c.Correo,
            Cuenta = string.IsNullOrEmpty(c.Usuario) ? "—" : "@" + c.Usuario,
            Activo = c.Estado
        }).ToList();
    }

    public void CargarFormulario(E_Cliente? elemento)
    {
        _editando = elemento;
        txtNombre.Text = elemento?.Nombre ?? string.Empty;
        txtCedula.Text = elemento?.Cedula ?? string.Empty;
        txtTelefono.Text = elemento?.Telefono ?? string.Empty;
        txtCorreo.Text = elemento?.Correo ?? string.Empty;
        txtDireccion.Text = elemento?.Direccion ?? string.Empty;
        chkActivo.Checked = elemento?.Estado ?? true;
        lblEditor.Text = elemento is null ? "Nuevo cliente" : $"Editando: {elemento.Nombre}";
    }

    public E_Cliente LeerFormulario() => new()
    {
        Id = _editando?.Id ?? 0,
        IdUsuario = _editando?.IdUsuario,
        Nombre = txtNombre.Text,
        Cedula = txtCedula.Text,
        Telefono = txtTelefono.Text,
        Correo = txtCorreo.Text,
        Direccion = txtDireccion.Text,
        Estado = chkActivo.Checked
    };

    public void MostrarMensaje(string mensaje, bool exito)
    {
        lblMensaje.ForeColor = exito ? Estilo.Exito : Estilo.Error;
        lblMensaje.Text = mensaje;
    }

    public bool Confirmar(string pregunta) =>
        MessageBox.Show(this, pregunta, "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

    private void FrmClientes_Load(object sender, EventArgs e) => Cargar?.Invoke(this, EventArgs.Empty);

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
