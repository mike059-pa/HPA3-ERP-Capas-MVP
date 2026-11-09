using CapaDatos;
using CapaEntidades;

namespace CapaNegocio
{
    /// <summary>Totales de una venta.</summary>
    public record TotalesVenta(decimal Subtotal, decimal Itbms, decimal Total);

    /// <summary>
    /// Reglas de negocio de ventas: carrito, cálculo de impuestos, registro e historial.
    /// Admin y Vendedor venden a un cliente; el Cliente compra para sí mismo (venta en línea).
    /// </summary>
    public class N_Venta
    {
        /// <summary>Tasa del ITBMS (impuesto de Panamá): 7 %. Debe coincidir con <c>sp_InsertarVenta</c>.</summary>
        public const decimal TasaItbms = 0.07m;

        private readonly D_Venta _datos = new();

        /// <summary>Calcula subtotal, ITBMS (redondeado a 2 decimales) y total del carrito.</summary>
        public static TotalesVenta CalcularTotales(IEnumerable<E_DetalleVenta> carrito)
        {
            decimal subtotal = carrito.Sum(l => l.Subtotal);
            decimal itbms = Math.Round(subtotal * TasaItbms, 2, MidpointRounding.AwayFromZero);
            return new TotalesVenta(subtotal, itbms, subtotal + itbms);
        }

        /// <summary>
        /// Agrega un producto al carrito (o suma la cantidad si ya estaba),
        /// validando que la cantidad sea positiva y no supere el stock disponible.
        /// </summary>
        public static Resultado<bool> AgregarAlCarrito(List<E_DetalleVenta> carrito, E_Producto? producto, int cantidad)
        {
            if (producto is null)
                return Resultado<bool>.Error("Seleccione un producto.");
            if (cantidad <= 0)
                return Resultado<bool>.Error("La cantidad debe ser mayor que cero.");

            var linea = carrito.FirstOrDefault(l => l.IdProducto == producto.Id);
            int cantidadTotal = (linea?.Cantidad ?? 0) + cantidad;
            if (cantidadTotal > producto.Stock)
                return Resultado<bool>.Error($"Stock insuficiente: solo hay {producto.Stock} unidad(es) de {producto.Nombre}.");

            if (linea is null)
            {
                carrito.Add(new E_DetalleVenta
                {
                    IdProducto = producto.Id,
                    Codigo = producto.Codigo,
                    Producto = producto.Nombre,
                    Cantidad = cantidad,
                    PrecioUnitario = producto.Precio
                });
            }
            else
            {
                linea.Cantidad = cantidadTotal;
            }
            return new(true, $"{producto.Nombre} agregado al carrito.", true);
        }

        /// <summary>
        /// Registra la venta. Para Admin/Vendedor se usa el cliente seleccionado y el actor como vendedor;
        /// para el rol Cliente se usa su propia ficha y la venta queda "en línea" (sin vendedor).
        /// </summary>
        public Resultado<int> Registrar(E_Usuario actor, int? idClienteSeleccionado, IReadOnlyCollection<E_DetalleVenta> carrito)
        {
            bool esCompraCliente = actor.Rol == Rol.Cliente;
            if (!Permisos.PuedeEditar(actor.Rol, esCompraCliente ? Modulo.Comprar : Modulo.Ventas))
                return Resultado<int>.SinPermiso();

            int? idCliente = esCompraCliente ? actor.IdCliente : idClienteSeleccionado;
            if (idCliente is null)
                return Resultado<int>.Error(esCompraCliente
                    ? "Su cuenta no tiene una ficha de cliente asociada."
                    : "Seleccione un cliente.");
            if (carrito.Count == 0)
                return Resultado<int>.Error("Agregue al menos un producto al carrito.");
            if (carrito.Any(l => l.Cantidad <= 0))
                return Resultado<int>.Error("Las cantidades deben ser mayores que cero.");

            int? idVendedor = esCompraCliente ? null : actor.Id;
            var totales = CalcularTotales(carrito);
            return Operacion.Ejecutar(() => _datos.Insertar(idCliente.Value, idVendedor, carrito),
                $"{(esCompraCliente ? "Compra" : "Venta")} registrada. Total: {Formato.Dinero(totales.Total)}");
        }

        /// <summary>
        /// Historial según el rol: Admin ve todas las ventas, Vendedor las suyas y Cliente sus compras.
        /// </summary>
        public Resultado<List<E_Venta>> Historial(E_Usuario actor, DateTime desde, DateTime hasta)
        {
            if (desde.Date > hasta.Date)
                return Resultado<List<E_Venta>>.Error("La fecha inicial no puede ser mayor que la final.");

            return actor.Rol switch
            {
                Rol.Administrador => Operacion.Ejecutar(() => _datos.Listar(desde, hasta, null, null)),
                Rol.Vendedor => Operacion.Ejecutar(() => _datos.Listar(desde, hasta, null, actor.Id)),
                Rol.Cliente when actor.IdCliente is int idCliente =>
                    Operacion.Ejecutar(() => _datos.Listar(desde, hasta, idCliente, null)),
                _ => Resultado<List<E_Venta>>.SinPermiso()
            };
        }

        /// <summary>Líneas de una venta del historial.</summary>
        public Resultado<List<E_DetalleVenta>> Detalle(int idVenta) =>
            Operacion.Ejecutar(() => _datos.Detalle(idVenta));
    }
}
