namespace CapaEntidades
{
    /// <summary>Línea de una venta o del carrito (tabla <c>detalle_venta</c>).</summary>
    public class E_DetalleVenta
    {
        public int IdProducto { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Producto { get; set; } = string.Empty;
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal => Cantidad * PrecioUnitario;
    }
}
