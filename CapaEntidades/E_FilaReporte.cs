namespace CapaEntidades
{
    /// <summary>Fila genérica de reporte: descripción, cantidad y total.</summary>
    public class E_FilaReporte
    {
        public string Descripcion { get; set; } = string.Empty;
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
    }
}
