using CapaNegocio;
using CapaNegocio.Contratos;
using CapaPresentacion.Presentadores;

namespace CapaPresentacion;

/// <summary>
/// Raíz de composición: crea una sola vez los objetos de Negocio y arma cada
/// módulo (Vista + Presentador). Para cambiar el algoritmo de hash basta con
/// pasar otra implementación de las interfaces en <see cref="Inicializar"/>.
/// </summary>
internal static class Servicios
{
    public static N_Usuario Usuarios { get; private set; } = null!;
    public static N_Producto Productos { get; } = new();
    public static N_Cliente Clientes { get; } = new();
    public static N_Venta Ventas { get; } = new();
    public static N_Reporte Reportes { get; } = new();

    public static void Inicializar(IHashService hashService, IVerificarHashService verificarService) =>
        Usuarios = new N_Usuario(hashService, verificarService);

    /// <summary>Crea la ventana de auto‑registro de clientes con su presentador.</summary>
    public static Form CrearRegistro()
    {
        var registro = new FrmRegistro();
        _ = new RegistroPresentador(registro, Usuarios);
        return registro;
    }

    /// <summary>Crea el formulario del módulo y le conecta su presentador.</summary>
    public static Form CrearModulo(Modulo modulo)
    {
        switch (modulo)
        {
            case Modulo.Usuarios:
                var usuarios = new FrmUsuarios();
                _ = new UsuariosPresentador(usuarios, Usuarios);
                return usuarios;
            case Modulo.Productos:
                var productos = new FrmProductos();
                _ = new ProductosPresentador(productos, Productos);
                return productos;
            case Modulo.Clientes:
                var clientes = new FrmClientes();
                _ = new ClientesPresentador(clientes, Clientes);
                return clientes;
            case Modulo.Ventas:
            case Modulo.Comprar:
            case Modulo.MisCompras:
                var ventas = new FrmVentas(abrirHistorial: modulo == Modulo.MisCompras);
                _ = new VentasPresentador(ventas, Ventas, Productos, Clientes);
                return ventas;
            case Modulo.Reportes:
                var reportes = new FrmReportes();
                _ = new ReportesPresentador(reportes, Reportes);
                return reportes;
            case Modulo.Perfil:
                var perfil = new FrmPerfil();
                _ = new PerfilPresentador(perfil, Usuarios);
                return perfil;
            default:
                var dashboard = new FrmDashboard();
                _ = new DashboardPresentador(dashboard, Reportes, Productos, Ventas);
                return dashboard;
        }
    }
}
