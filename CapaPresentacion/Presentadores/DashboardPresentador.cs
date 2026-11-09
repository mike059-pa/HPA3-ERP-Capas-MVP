using System.Data;
using CapaEntidades;
using CapaNegocio;
using CapaPresentacion.Vistas;

namespace CapaPresentacion.Presentadores;

/// <summary>
/// Presentador del dashboard: arma las tarjetas del "Sumario del sistema" según el rol,
/// la lista inferior (productos bajo stock o compras recientes) y el reloj grande.
/// </summary>
public class DashboardPresentador
{
    private readonly IVistaDashboard _vista;
    private readonly N_Reporte _reportes;
    private readonly N_Producto _productos;
    private readonly N_Venta _ventas;

    public DashboardPresentador(IVistaDashboard vista, N_Reporte reportes, N_Producto productos, N_Venta ventas)
    {
        _vista = vista;
        _reportes = reportes;
        _productos = productos;
        _ventas = ventas;
        _vista.Cargar += (_, _) => Soporte.Ejecutar(Cargar, _vista.MostrarError);
        _vista.TickReloj += (_, _) => ActualizarReloj();
    }

    private void Cargar()
    {
        ActualizarReloj();
        var actor = Soporte.Actor;

        var resumen = _reportes.Resumen(actor);
        if (!resumen.Exito || resumen.Dato is null)
        {
            _vista.MostrarError(resumen.Mensaje);
            return;
        }
        _vista.MostrarTarjetas(CrearTarjetas(actor.Rol, resumen.Dato));

        if (actor.Rol == Rol.Cliente)
            MostrarComprasRecientes(actor);
        else
            MostrarBajoStock();
    }

    private static List<TarjetaResumen> CrearTarjetas(Rol rol, E_ResumenDashboard r) => rol switch
    {
        Rol.Administrador =>
        [
            new("Usuarios", r.TotalUsuarios.ToString("N0"), Estilo.IconoUsuarios),
            new("Clientes", r.TotalClientes.ToString("N0"), Estilo.IconoClientes),
            new("Productos", r.TotalProductos.ToString("N0"), Estilo.IconoProductos),
            new("Bajo stock", r.ProductosBajoStock.ToString("N0"), Estilo.IconoAlerta),
            new("Ventas hoy", r.VentasHoy.ToString("N0"), Estilo.IconoVentas),
            new("Ingresos mes", Formato.Dinero(r.MontoMes), Estilo.IconoCalendario),
            new("Ingresos totales", Formato.Dinero(r.MontoVentas), Estilo.IconoDinero)
        ],
        Rol.Vendedor =>
        [
            new("Mis ventas", r.NumVentas.ToString("N0"), Estilo.IconoVentas),
            new("Ventas hoy", r.VentasHoy.ToString("N0"), Estilo.IconoVentas),
            new("Vendido hoy", Formato.Dinero(r.MontoHoy), Estilo.IconoDinero),
            new("Vendido mes", Formato.Dinero(r.MontoMes), Estilo.IconoCalendario),
            new("Clientes", r.TotalClientes.ToString("N0"), Estilo.IconoClientes),
            new("Productos", r.TotalProductos.ToString("N0"), Estilo.IconoProductos),
            new("Bajo stock", r.ProductosBajoStock.ToString("N0"), Estilo.IconoAlerta)
        ],
        _ =>
        [
            new("Mis compras", r.NumVentas.ToString("N0"), Estilo.IconoMisCompras),
            new("Total gastado", Formato.Dinero(r.MontoVentas), Estilo.IconoDinero),
            new("Este mes", Formato.Dinero(r.MontoMes), Estilo.IconoCalendario),
            new("Productos", r.TotalProductos.ToString("N0"), Estilo.IconoProductos)
        ]
    };

    private void MostrarBajoStock()
    {
        var resultado = _productos.BajoStock();
        var tabla = new DataTable();
        tabla.Columns.Add("Código");
        tabla.Columns.Add("Producto");
        tabla.Columns.Add("Stock", typeof(int));
        tabla.Columns.Add("Mínimo", typeof(int));
        foreach (var p in resultado.Dato ?? [])
            tabla.Rows.Add(p.Codigo, p.Nombre, p.Stock, p.StockMinimo);
        _vista.MostrarLista("Productos bajo stock:", tabla);
    }

    private void MostrarComprasRecientes(E_Usuario actor)
    {
        var resultado = _ventas.Historial(actor, DateTime.Today.AddYears(-1), DateTime.Today);
        var tabla = new DataTable();
        tabla.Columns.Add("N.º");
        tabla.Columns.Add("Fecha");
        tabla.Columns.Add("Artículos", typeof(int));
        tabla.Columns.Add("Total");
        foreach (var v in (resultado.Dato ?? []).Take(15))
            tabla.Rows.Add(v.Id, v.Fecha.ToString("dd/MM/yyyy hh:mm tt"), v.Articulos, Formato.Dinero(v.Total));
        _vista.MostrarLista("Mis compras recientes:", tabla);
    }

    private void ActualizarReloj()
    {
        var ahora = DateTime.Now;
        _vista.Hora = ahora.ToString("hh:mm:ss");
        _vista.Fecha = Soporte.Fecha(ahora);
    }
}
