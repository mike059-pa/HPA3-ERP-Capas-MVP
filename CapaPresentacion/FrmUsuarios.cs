using CapaEntidades;
using CapaPresentacion.Vistas;

namespace CapaPresentacion;

/// <summary>Vista del mantenimiento de usuarios (CRUD). La lógica está en <see cref="Presentadores.UsuariosPresentador"/>.</summary>
public partial class FrmUsuarios : Form, IVistaUsuarios
{
    private List<E_Usuario> _lista = [];
    private int _idEditando;

    public event EventHandler? Cargar;
    public event EventHandler? Buscar;
    public event EventHandler? SeleccionCambiada;
    public event EventHandler? Nuevo;
    public event EventHandler? Guardar;
    public event EventHandler? Eliminar;

    public FrmUsuarios()
    {
        InitializeComponent();
        Estilo.EstilizarGrid(gridDatos);
        Estilo.BotonSecundario(btnBuscar);
        Estilo.BotonSecundario(btnNuevo);
        Estilo.BotonPrimario(btnGuardar);
        Estilo.BotonPeligro(btnEliminar);
        cboRol.Items.AddRange(["Administrador", "Vendedor", "Cliente"]);
        CargarFormulario(null);
    }

    public string TextoBusqueda => txtBuscar.Text;
    public string Password => txtPassword.Text;
    public string Confirmacion => txtConfirmacion.Text;

    public E_Usuario? Seleccionado =>
        gridDatos.SelectedRows.Count == 1 ? _lista[gridDatos.SelectedRows[0].Index] : null;

    public void MostrarLista(List<E_Usuario> elementos)
    {
        _lista = elementos;
        // Proyección: el grid nunca recibe el hash ni el salt
        gridDatos.DataSource = elementos.Select(u => new
        {
            ID = u.Id,
            Usuario = u.Usuario,
            Nombre = u.Nombre,
            Rol = u.Rol.ToString(),
            Correo = u.Correo,
            Teléfono = u.Telefono,
            Activo = u.Estado
        }).ToList();
    }

    public void CargarFormulario(E_Usuario? elemento)
    {
        _idEditando = elemento?.Id ?? 0;
        txtUsuario.Text = elemento?.Usuario ?? string.Empty;
        txtUsuario.ReadOnly = elemento is not null;   // el nombre de usuario no se cambia
        txtNombre.Text = elemento?.Nombre ?? string.Empty;
        txtCorreo.Text = elemento?.Correo ?? string.Empty;
        txtTelefono.Text = elemento?.Telefono ?? string.Empty;
        cboRol.SelectedIndex = elemento is null ? 1 : (int)elemento.Rol - 1;
        chkActivo.Checked = elemento?.Estado ?? true;
        txtPassword.Clear();
        txtConfirmacion.Clear();
        lblAyudaPassword.Text = elemento is null
            ? "Obligatoria al crear (mínimo 6 caracteres)."
            : "Déjela en blanco para no cambiarla.";
        lblEditor.Text = elemento is null ? "Nuevo usuario" : $"Editando: {elemento.Usuario}";
    }

    public E_Usuario LeerFormulario() => new()
    {
        Id = _idEditando,
        Usuario = txtUsuario.Text,
        Nombre = txtNombre.Text,
        Correo = txtCorreo.Text,
        Telefono = txtTelefono.Text,
        Rol = (Rol)(cboRol.SelectedIndex + 1),
        Estado = chkActivo.Checked
    };

    public void MostrarMensaje(string mensaje, bool exito)
    {
        lblMensaje.ForeColor = exito ? Estilo.Exito : Estilo.Error;
        lblMensaje.Text = mensaje;
    }

    public bool Confirmar(string pregunta) =>
        MessageBox.Show(this, pregunta, "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;

    private void FrmUsuarios_Load(object sender, EventArgs e) => Cargar?.Invoke(this, EventArgs.Empty);

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
