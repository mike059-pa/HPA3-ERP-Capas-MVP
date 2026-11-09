namespace CapaEntidades
{
    /// <summary>Producto del inventario (tabla <c>productos</c>).</summary>
    public class E_Producto
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        /// <summary>Cantidad a partir de la cual el producto se considera "bajo stock".</summary>
        public int StockMinimo { get; set; }

        public bool Estado { get; set; } = true;

        /// <summary>Texto mostrado en listas desplegables.</summary>
        public override string ToString() => $"{Codigo} - {Nombre}";
    }
}
