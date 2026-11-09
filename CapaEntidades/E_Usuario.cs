namespace CapaEntidades
{
    /// <summary>
    /// Entidad que representa un registro de la tabla <c>usuarios</c>.
    /// Clase pura de datos: no contiene lógica de negocio ni de acceso a datos.
    /// </summary>
    public class E_Usuario
    {
        /// <summary>Identificador único (llave primaria).</summary>
        public int Id { get; set; }

        /// <summary>Nombre de usuario con el que se inicia sesión.</summary>
        public string Usuario { get; set; } = string.Empty;

        /// <summary>Hash SHA-512 de la contraseña (64 bytes).</summary>
        public byte[] PasswordHash { get; set; } = [];

        /// <summary>Salt aleatorio usado para generar el hash (16 bytes).</summary>
        public byte[] Salt { get; set; } = [];

        /// <summary>Nombre completo de la persona.</summary>
        public string Nombre { get; set; } = string.Empty;

        /// <summary>Indica si el usuario está activo (true) o inactivo (false).</summary>
        public bool Estado { get; set; }

        /// <summary>Usuario que creó el registro.</summary>
        public string UsuarioCreacion { get; set; } = string.Empty;

        /// <summary>Fecha y hora de creación del registro.</summary>
        public DateTime FechaCreacion { get; set; }
    }
}
