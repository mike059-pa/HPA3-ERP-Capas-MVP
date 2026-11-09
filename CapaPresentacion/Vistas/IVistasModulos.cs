using CapaEntidades;
using CapaNegocio;

namespace CapaPresentacion.Vistas;

/// <summary>Vista del mantenimiento de usuarios: agrega la contraseña al CRUD.</summary>
public interface IVistaUsuarios : IVistaCrud<E_Usuario>
{
    /// <summary>Contraseña escrita (obligatoria al crear, opcional al editar).</summary>
    string Password { get; }

    /// <summary>Confirmación de la contraseña.</summary>
    string Confirmacion { get; }
}

/// <summary>Vista del mantenimiento de productos.</summary>
public interface IVistaProductos : IVistaCrud<E_Producto>
{
    /// <summary>false = modo solo consulta (oculta el panel de edición).</summary>
    bool PermitirEdicion { set; }
}

/// <summary>Vista del mantenimiento de clientes.</summary>
public interface IVistaClientes : IVistaCrud<E_Cliente>;

/// <summary>Vista de ventas: nueva venta (carrito) e historial.</summary>
public interface IVistaVentas
{
    E_Producto? ProductoSeleccionado { get; }
    int Cantidad { get; }
    int? ClienteSeleccionado { get; }
    int? IndiceLineaSeleccionada { get; }
    DateTime Desde { get; }
    DateTime Hasta { get; }
    int? VentaSeleccionada { get; }

    event EventHandler Cargar;
    event EventHandler ProductoCambiado;
    event EventHandler AgregarProducto;
    event EventHandler QuitarProducto;
    event EventHandler LimpiarCarrito;
    event EventHandler RegistrarVenta;
    event EventHandler FiltrarHistorial;
    event EventHandler VentaCambiada;

    /// <summary>Modo cliente: oculta la selección de cliente y renombra las pestañas.</summary>
    void ConfigurarModoCliente(string nombreCliente);

    void CargarClientes(List<E_Cliente> clientes);
    void CargarProductos(List<E_Producto> productos);
    void MostrarInfoProducto(string informacion);
    void MostrarCarrito(List<E_DetalleVenta> carrito, TotalesVenta totales);
    void MostrarHistorial(List<E_Venta> ventas, decimal totalPeriodo);
    void MostrarDetalle(List<E_DetalleVenta> detalle);
    void MostrarMensaje(string mensaje, bool exito);
    void MostrarMensajeHistorial(string mensaje, bool exito);
}

/// <summary>Vista de reportes.</summary>
public interface IVistaReportes
{
    TipoReporte Tipo { get; }
    DateTime Desde { get; }
    DateTime Hasta { get; }

    event EventHandler Cargar;
    event EventHandler Generar;

    /// <summary>Muestra las filas, el gráfico de barras y el total general.</summary>
    void MostrarReporte(List<E_FilaReporte> filas, string encabezadoCantidad, string total);
    void MostrarMensaje(string mensaje);
}

/// <summary>Vista del perfil del usuario y cambio de contraseña.</summary>
public interface IVistaPerfil
{
    string PasswordActual { get; }
    string PasswordNueva { get; }
    string Confirmacion { get; }

    event EventHandler Cargar;
    event EventHandler CambiarPassword;

    /// <summary>Muestra los datos del usuario en sesión.</summary>
    void MostrarDatos(string usuario, string nombre, string rol, string correo, string telefono, string creado);
    void MostrarMensaje(string mensaje, bool exito);
    void LimpiarPasswords();
}
