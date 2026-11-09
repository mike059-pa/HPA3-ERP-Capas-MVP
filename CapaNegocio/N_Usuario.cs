using CapaDatos;
using CapaEntidades;
using CapaNegocio.Contratos;

namespace CapaNegocio
{
    /// <summary>Resultado de una operación de negocio: éxito, mensaje y dato opcional.</summary>
    public record Resultado<T>(bool Exito, string Mensaje, T? Dato = default);

    /// <summary>
    /// Reglas de negocio de usuarios: inicio de sesión y registro.
    /// Depende de los contratos (interfaces), no de una implementación concreta de hash.
    /// </summary>
    public class N_Usuario
    {
        /// <summary>Longitud mínima permitida para una contraseña.</summary>
        public const int LongitudMinimaPassword = 6;

        private readonly D_Usuario _datos = new();
        private readonly IHashService _hashService;
        private readonly IVerificarHashService _verificarService;

        /// <param name="hashService">Servicio que genera hashes (registro).</param>
        /// <param name="verificarService">Servicio que verifica hashes (login).</param>
        public N_Usuario(IHashService hashService, IVerificarHashService verificarService)
        {
            _hashService = hashService;
            _verificarService = verificarService;
        }

        /// <summary>Valida las credenciales y devuelve el usuario si son correctas.</summary>
        public Resultado<E_Usuario> Login(string usuario, string password)
        {
            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrEmpty(password))
                return new(false, "Debe ingresar usuario y contraseña.");

            var encontrado = _datos.ObtenerPorUsuario(usuario.Trim());
            // Mismo mensaje para usuario inexistente o contraseña errónea: no revela qué usuarios existen
            if (encontrado is null || !_verificarService.Verificar(password, encontrado.PasswordHash, encontrado.Salt))
                return new(false, "Usuario o contraseña incorrectos.");

            if (!encontrado.Estado)
                return new(false, "El usuario está inactivo. Contacte al administrador.");

            return new(true, $"Bienvenido, {encontrado.Nombre}.", encontrado);
        }

        /// <summary>Registra un usuario nuevo generando su salt y hash.</summary>
        /// <param name="creadoPor">Usuario de la sesión que realiza el registro.</param>
        public Resultado<int> Registrar(string usuario, string nombre, string password, string confirmacion, string creadoPor)
        {
            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(nombre) || string.IsNullOrEmpty(password))
                return new(false, "Todos los campos son obligatorios.");

            if (password.Length < LongitudMinimaPassword)
                return new(false, $"La contraseña debe tener al menos {LongitudMinimaPassword} caracteres.");

            if (password != confirmacion)
                return new(false, "Las contraseñas no coinciden.");

            if (_datos.ObtenerPorUsuario(usuario.Trim()) is not null)
                return new(false, "El nombre de usuario ya existe.");

            var salt = _hashService.GenerarSalt();
            var nuevo = new E_Usuario
            {
                Usuario = usuario.Trim(),
                Nombre = nombre.Trim(),
                Salt = salt,
                PasswordHash = _hashService.GenerarHash(password, salt),
                Estado = true,
                UsuarioCreacion = creadoPor
            };

            var id = _datos.Insertar(nuevo);
            return new(true, "Usuario registrado correctamente.", id);
        }
    }
}
