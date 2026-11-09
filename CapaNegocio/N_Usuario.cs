using CapaDatos;
using CapaEntidades;
using CapaNegocio.Contratos;

namespace CapaNegocio
{
    /// <summary>
    /// Reglas de negocio de usuarios: inicio de sesión, auto‑registro de clientes,
    /// administración (CRUD) y cambio de contraseña.
    /// Depende de los contratos (interfaces), no de una implementación concreta de hash.
    /// </summary>
    public class N_Usuario
    {
        private readonly D_Usuario _datos = new();
        private readonly IHashService _hashService;
        private readonly IVerificarHashService _verificarService;

        /// <param name="hashService">Servicio que genera hashes (registro y cambio de contraseña).</param>
        /// <param name="verificarService">Servicio que verifica hashes (login y cambio de contraseña).</param>
        public N_Usuario(IHashService hashService, IVerificarHashService verificarService)
        {
            _hashService = hashService;
            _verificarService = verificarService;
        }

        /// <summary>Valida las credenciales y devuelve el usuario si son correctas.</summary>
        public Resultado<E_Usuario> Login(string usuario, string password)
        {
            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrEmpty(password))
                return Resultado<E_Usuario>.Error("Debe ingresar usuario y contraseña.");

            var encontrado = _datos.ObtenerPorUsuario(usuario.Trim());
            // Mismo mensaje para usuario inexistente o contraseña errónea: no revela qué usuarios existen
            if (encontrado is null || !_verificarService.Verificar(password, encontrado.PasswordHash, encontrado.Salt))
                return Resultado<E_Usuario>.Error("Usuario o contraseña incorrectos.");

            if (!encontrado.Estado)
                return Resultado<E_Usuario>.Error("El usuario está inactivo. Contacte al administrador.");

            return new(true, $"Bienvenido, {encontrado.Nombre}.", encontrado);
        }

        /// <summary>Auto‑registro desde el login: crea una cuenta con rol Cliente.</summary>
        public Resultado<int> RegistrarCliente(string usuario, string nombre, string correo, string telefono,
                                               string password, string confirmacion)
        {
            var nuevo = new E_Usuario
            {
                Usuario = usuario,
                Nombre = nombre,
                Correo = correo,
                Telefono = telefono,
                Rol = Rol.Cliente,
                Estado = true,
                UsuarioCreacion = "Autoregistro"
            };
            return Insertar(nuevo, password, confirmacion, "Cuenta creada correctamente. Ya puede iniciar sesión.");
        }

        /// <summary>Lista los usuarios (solo Administrador).</summary>
        public Resultado<List<E_Usuario>> Listar(E_Usuario actor, string buscar)
        {
            if (!Permisos.PuedeVer(actor.Rol, Modulo.Usuarios))
                return Resultado<List<E_Usuario>>.SinPermiso();
            return Operacion.Ejecutar(() => _datos.Listar(buscar));
        }

        /// <summary>
        /// Crea (Id = 0) o actualiza un usuario. Al crear, la contraseña es obligatoria;
        /// al editar, solo se cambia si se escribe una nueva.
        /// </summary>
        public Resultado<int> Guardar(E_Usuario actor, E_Usuario usuario, string password, string confirmacion)
        {
            if (!Permisos.PuedeEditar(actor.Rol, Modulo.Usuarios))
                return Resultado<int>.SinPermiso();

            if (usuario.Id == 0)
            {
                usuario.UsuarioCreacion = actor.Usuario;
                return Insertar(usuario, password, confirmacion, "Usuario registrado correctamente.");
            }

            var error = ValidarDatos(usuario);
            if (error is not null)
                return Resultado<int>.Error(error);

            if (usuario.Id == actor.Id && (usuario.Rol != actor.Rol || !usuario.Estado))
                return Resultado<int>.Error("No puede cambiar su propio rol ni desactivar su propia cuenta.");

            bool cambiarPassword = !string.IsNullOrEmpty(password);
            if (cambiarPassword && Validar.Password(password, confirmacion) is { } errorPassword)
                return Resultado<int>.Error(errorPassword);

            return Operacion.Ejecutar(() =>
            {
                _datos.Actualizar(usuario);
                if (cambiarPassword)
                    GuardarNuevoPassword(usuario.Id, password);
                return usuario.Id;
            }, cambiarPassword ? "Usuario y contraseña actualizados." : "Usuario actualizado.");
        }

        /// <summary>Elimina un usuario (no se permite eliminar la cuenta propia).</summary>
        public Resultado<bool> Eliminar(E_Usuario actor, int idUsuario)
        {
            if (!Permisos.PuedeEditar(actor.Rol, Modulo.Usuarios))
                return Resultado<bool>.SinPermiso();
            if (idUsuario == actor.Id)
                return Resultado<bool>.Error("No puede eliminar su propia cuenta.");

            return Operacion.Ejecutar(() => { _datos.Eliminar(idUsuario); return true; }, "Usuario eliminado.");
        }

        /// <summary>
        /// Cambia la contraseña del usuario en sesión: primero VERIFICA la actual
        /// (<see cref="IVerificarHashService"/>) y luego GENERA el hash de la nueva (<see cref="IHashService"/>).
        /// </summary>
        public Resultado<bool> CambiarPassword(E_Usuario actor, string actual, string nueva, string confirmacion)
        {
            if (string.IsNullOrEmpty(actual))
                return Resultado<bool>.Error("Ingrese su contraseña actual.");
            if (Validar.Password(nueva, confirmacion) is { } error)
                return Resultado<bool>.Error(error);
            if (actual == nueva)
                return Resultado<bool>.Error("La nueva contraseña debe ser distinta de la actual.");

            var guardado = _datos.ObtenerPorUsuario(actor.Usuario);
            if (guardado is null || !_verificarService.Verificar(actual, guardado.PasswordHash, guardado.Salt))
                return Resultado<bool>.Error("La contraseña actual no es correcta.");

            return Operacion.Ejecutar(() => { GuardarNuevoPassword(actor.Id, nueva); return true; },
                "Contraseña actualizada correctamente.");
        }

        private Resultado<int> Insertar(E_Usuario usuario, string password, string confirmacion, string mensajeExito)
        {
            var error = ValidarDatos(usuario) ?? Validar.Password(password, confirmacion);
            if (error is not null)
                return Resultado<int>.Error(error);

            usuario.Usuario = usuario.Usuario.Trim();
            usuario.Nombre = usuario.Nombre.Trim();
            usuario.Salt = _hashService.GenerarSalt();
            usuario.PasswordHash = _hashService.GenerarHash(password, usuario.Salt);

            return Operacion.Ejecutar(() => _datos.Insertar(usuario), mensajeExito);
        }

        private void GuardarNuevoPassword(int idUsuario, string password)
        {
            var salt = _hashService.GenerarSalt();
            _datos.CambiarPassword(idUsuario, _hashService.GenerarHash(password, salt), salt);
        }

        private static string? ValidarDatos(E_Usuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.Usuario) || string.IsNullOrWhiteSpace(usuario.Nombre))
                return "El usuario y el nombre son obligatorios.";
            if (usuario.Usuario.Trim().Contains(' '))
                return "El nombre de usuario no puede contener espacios.";
            if (!Enum.IsDefined(usuario.Rol))
                return "Seleccione un rol válido.";
            if (!Validar.CorreoOpcional(usuario.Correo))
                return "El correo no tiene un formato válido.";
            return null;
        }
    }
}
