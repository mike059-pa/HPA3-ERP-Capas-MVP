namespace CapaEntidades
{
    /// <summary>Cliente al que se le registran ventas (tabla <c>clientes</c>).</summary>
    public class E_Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Cedula { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;

        /// <summary>Usuario de acceso asociado (solo clientes que compran en línea).</summary>
        public int? IdUsuario { get; set; }

        /// <summary>Nombre del usuario asociado, si existe.</summary>
        public string Usuario { get; set; } = string.Empty;

        public bool Estado { get; set; } = true;

        /// <summary>Texto mostrado en listas desplegables.</summary>
        public override string ToString() =>
            string.IsNullOrEmpty(Cedula) ? Nombre : $"{Nombre} ({Cedula})";
    }
}
