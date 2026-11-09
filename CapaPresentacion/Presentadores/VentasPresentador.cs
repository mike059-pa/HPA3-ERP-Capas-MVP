using CapaEntidades;
using CapaNegocio;
using CapaPresentacion.Vistas;

namespace CapaPresentacion.Presentadores;

/// <summary>
/// Presentador de ventas: maneja el carrito, registra la venta y muestra el historial.
/// Con el rol Cliente funciona como "Comprar" y "Mis compras".
/// </summary>
public class VentasPresentador
{
    private readonly IVistaVentas _vista;
    private readonly N_Venta _ventas;
    private readonly N_Producto _productos;
    private readonly N_Cliente _clientes;
    private readonly List<E_DetalleVenta> _carrito = [];

    public VentasPresentador(IVistaVentas vista, N_Venta ventas, N_Producto productos, N_Cliente clientes)
    {
        _vista = vista;
        _ventas = ventas;
        _productos = productos;
        _clientes = clientes;

        _vista.Cargar += (_, _) => Ejecutar(Cargar);
        _vista.ProductoCambiado += (_, _) => MostrarInfoProducto();
        _vista.AgregarProducto += (_, _) => Agregar();
        _vista.QuitarProducto += (_, _) => Quitar();
        _vista.LimpiarCarrito += (_, _) => { _carrito.Clear(); MostrarCarrito(); };
        _vista.RegistrarVenta += (_, _) => Ejecutar(Registrar);
        _vista.FiltrarHistorial += (_, _) => Soporte.Ejecutar(CargarHistorial, m => _vista.MostrarMensajeHistorial(m, false));
        _vista.VentaCambiada += (_, _) => Soporte.Ejecutar(MostrarDetalle, m => _vista.MostrarMensajeHistorial(m, false));
    }

    private void Cargar()
    {
        var actor = Soporte.Actor;
        if (actor.Rol == Rol.Cliente)
        {
            _vista.ConfigurarModoCliente(actor.Nombre);
        }
        else
        {
            var clientes = _clientes.Listar(actor, string.Empty, soloActivos: true);
            _vista.CargarClientes(clientes.Dato ?? []);
        }

        CargarProductos();
        MostrarCarrito();
        CargarHistorial();
    }

    /// <summary>Solo se ofrecen productos activos con existencias.</summary>
    private void CargarProductos()
    {
        var resultado = _productos.Listar(string.Empty, soloActivos: true);
        _vista.CargarProductos((resultado.Dato ?? []).Where(p => p.Stock > 0).ToList());
        MostrarInfoProducto();
    }

    private void MostrarInfoProducto()
    {
        var producto = _vista.ProductoSeleccionado;
        _vista.MostrarInfoProducto(producto is null
            ? string.Empty
            : $"Precio: {Formato.Dinero(producto.Precio)}   |   Disponible: {producto.Stock}");
    }

    private void Agregar()
    {
        var resultado = N_Venta.AgregarAlCarrito(_carrito, _vista.ProductoSeleccionado, _vista.Cantidad);
        _vista.MostrarMensaje(resultado.Mensaje, resultado.Exito);
        if (resultado.Exito)
            MostrarCarrito();
    }

    private void Quitar()
    {
        if (_vista.IndiceLineaSeleccionada is not int indice || indice < 0 || indice >= _carrito.Count)
        {
            _vista.MostrarMensaje("Seleccione una línea del carrito.", false);
            return;
        }
        _carrito.RemoveAt(indice);
        MostrarCarrito();
    }

    private void Registrar()
    {
        var resultado = _ventas.Registrar(Soporte.Actor, _vista.ClienteSeleccionado, _carrito);
        if (resultado.Exito)
        {
            _carrito.Clear();
            MostrarCarrito();
            CargarProductos();   // el stock cambió
            CargarHistorial();
        }
        _vista.MostrarMensaje(resultado.Mensaje, resultado.Exito);
    }

    private void MostrarCarrito() =>
        _vista.MostrarCarrito([.. _carrito], N_Venta.CalcularTotales(_carrito));

    private void CargarHistorial()
    {
        var resultado = _ventas.Historial(Soporte.Actor, _vista.Desde, _vista.Hasta);
        if (!resultado.Exito || resultado.Dato is null)
        {
            _vista.MostrarMensajeHistorial(resultado.Mensaje, false);
            return;
        }
        _vista.MostrarHistorial(resultado.Dato, resultado.Dato.Sum(v => v.Total));
        _vista.MostrarDetalle([]);
        _vista.MostrarMensajeHistorial(string.Empty, true);
    }

    private void MostrarDetalle()
    {
        if (_vista.VentaSeleccionada is not int idVenta)
        {
            _vista.MostrarDetalle([]);
            return;
        }
        _vista.MostrarDetalle(_ventas.Detalle(idVenta).Dato ?? []);
    }

    private void Ejecutar(Action accion) => Soporte.Ejecutar(accion, m => _vista.MostrarMensaje(m, false));
}
