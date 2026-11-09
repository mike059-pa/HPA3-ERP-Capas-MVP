using System.Data;
using CapaEntidades;

namespace CapaDatos
{
    /// <summary>Acceso a datos de ventas y su detalle.</summary>
    public class D_Venta
    {
        /// <summary>
        /// Registra una venta completa en una sola llamada: el carrito se envía como
        /// parámetro con valor de tabla (<c>dbo.DetalleVentaTipo</c>). El procedimiento valida
        /// stock, toma los precios de la base de datos y descuenta inventario en una transacción.
        /// </summary>
        /// <param name="idVendedor"><c>null</c> cuando es una compra en línea del cliente.</param>
        /// <returns>El Id de la venta.</returns>
        public int Insertar(int idCliente, int? idVendedor, IEnumerable<E_DetalleVenta> detalle) => Conexion.Ejecutar(() =>
        {
            var tabla = new DataTable();
            tabla.Columns.Add("idProducto", typeof(int));
            tabla.Columns.Add("cantidad", typeof(int));
            foreach (var linea in detalle)
                tabla.Rows.Add(linea.IdProducto, linea.Cantidad);

            using var conexion = Conexion.ObtenerConexion();
            using var comando = Conexion.CrearComando("sp_InsertarVenta", conexion);
            comando.Parameters.Add("@idCliente", SqlDbType.Int).Value = idCliente;
            comando.Parameters.Add("@idVendedor", SqlDbType.Int).Value = (object?)idVendedor ?? DBNull.Value;
            var parametroDetalle = comando.Parameters.Add("@detalle", SqlDbType.Structured);
            parametroDetalle.TypeName = "dbo.DetalleVentaTipo";
            parametroDetalle.Value = tabla;

            conexion.Open();
            return Convert.ToInt32(comando.ExecuteScalar());
        });

        /// <summary>Lista ventas en un rango de fechas, opcionalmente de un cliente o vendedor.</summary>
        public List<E_Venta> Listar(DateTime desde, DateTime hasta, int? idCliente, int? idVendedor) => Conexion.Ejecutar(() =>
        {
            using var conexion = Conexion.ObtenerConexion();
            using var comando = Conexion.CrearComando("sp_ListarVentas", conexion);
            comando.Parameters.Add("@desde", SqlDbType.Date).Value = desde.Date;
            comando.Parameters.Add("@hasta", SqlDbType.Date).Value = hasta.Date;
            comando.Parameters.Add("@idCliente", SqlDbType.Int).Value = (object?)idCliente ?? DBNull.Value;
            comando.Parameters.Add("@idVendedor", SqlDbType.Int).Value = (object?)idVendedor ?? DBNull.Value;

            conexion.Open();
            using var lector = comando.ExecuteReader();
            var lista = new List<E_Venta>();
            while (lector.Read())
            {
                lista.Add(new E_Venta
                {
                    Id = lector.Entero("id"),
                    Fecha = lector.Fecha("fecha"),
                    IdCliente = lector.Entero("idCliente"),
                    Cliente = lector.Texto("cliente"),
                    IdVendedor = lector.EnteroNulo("idVendedor"),
                    Vendedor = lector.Texto("vendedor"),
                    Articulos = lector.EnteroNulo("articulos") ?? 0,
                    Subtotal = lector.Decimal("subtotal"),
                    Itbms = lector.Decimal("itbms"),
                    Total = lector.Decimal("total")
                });
            }
            return lista;
        });

        /// <summary>Líneas de una venta.</summary>
        public List<E_DetalleVenta> Detalle(int idVenta) => Conexion.Ejecutar(() =>
        {
            using var conexion = Conexion.ObtenerConexion();
            using var comando = Conexion.CrearComando("sp_DetalleVenta", conexion);
            comando.Parameters.Add("@idVenta", SqlDbType.Int).Value = idVenta;

            conexion.Open();
            using var lector = comando.ExecuteReader();
            var lista = new List<E_DetalleVenta>();
            while (lector.Read())
            {
                lista.Add(new E_DetalleVenta
                {
                    IdProducto = lector.Entero("idProducto"),
                    Codigo = lector.Texto("codigo"),
                    Producto = lector.Texto("producto"),
                    Cantidad = lector.Entero("cantidad"),
                    PrecioUnitario = lector.Decimal("precioUnitario")
                });
            }
            return lista;
        });
    }
}
