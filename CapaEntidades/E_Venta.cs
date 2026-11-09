namespace CapaEntidades
{
    /// <summary>Encabezado de una venta (tabla <c>ventas</c>).</summary>
    public class E_Venta
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int IdCliente { get; set; }
        public string Cliente { get; set; } = string.Empty;

        /// <summary>Usuario vendedor; <c>null</c> cuando el cliente compró en línea.</summary>
        public int? IdVendedor { get; set; }

        public string Vendedor { get; set; } = string.Empty;
        public int Articulos { get; set; }
        public decimal Subtotal { get; set; }

        /// <summary>Impuesto ITBMS (7 %).</summary>
        public decimal Itbms { get; set; }

        public decimal Total { get; set; }
    }
}
