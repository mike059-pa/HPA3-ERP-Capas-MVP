namespace CapaEntidades
{
    /// <summary>
    /// Cifras del "Sumario del sistema". Las de ventas vienen filtradas según el rol:
    /// Admin = todas, Vendedor = las suyas, Cliente = sus compras.
    /// </summary>
    public class E_ResumenDashboard
    {
        public int TotalUsuarios { get; set; }
        public int TotalClientes { get; set; }
        public int TotalProductos { get; set; }
        public int ProductosBajoStock { get; set; }
        public int NumVentas { get; set; }
        public decimal MontoVentas { get; set; }
        public int VentasHoy { get; set; }
        public decimal MontoHoy { get; set; }
        public decimal MontoMes { get; set; }
    }
}
