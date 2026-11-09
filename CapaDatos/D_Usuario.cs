using System.Data;
using CapaEntidades;
using Microsoft.Data.SqlClient;

namespace CapaDatos
{
    /// <summary>
    /// Acceso a datos de la tabla <c>usuarios</c>.
    /// Solo ejecuta procedimientos almacenados con parámetros (evita inyección SQL).
    /// </summary>
    public class D_Usuario
    {
        /// <summary>
        /// Busca un usuario por su nombre de usuario (incluye hash y salt para verificar el login).
        /// </summary>
        /// <returns>El usuario encontrado o <c>null</c> si no existe.</returns>
        public E_Usuario? ObtenerPorUsuario(string usuario) => Conexion.Ejecutar(() =>
        {
            using var conexion = Conexion.ObtenerConexion();
            using var comando = Conexion.CrearComando("sp_ObtenerUsuario", conexion);
            comando.Parameters.Add("@dsUsuario", SqlDbType.VarChar, 50).Value = usuario;

            conexion.Open();
            using var lector = comando.ExecuteReader();
            if (!lector.Read())
                return null;

            var encontrado = LeerUsuario(lector);
            encontrado.PasswordHash = lector.Bytes("dsPassword");
            encontrado.Salt = lector.Bytes("dsSalt");
            encontrado.IdCliente = lector.EnteroNulo("idCliente");
            return encontrado;
        });

        /// <summary>Lista los usuarios (sin hash ni salt) filtrando por usuario o nombre.</summary>
        public List<E_Usuario> Listar(string buscar) => Conexion.Ejecutar(() =>
        {
            using var conexion = Conexion.ObtenerConexion();
            using var comando = Conexion.CrearComando("sp_ListarUsuarios", conexion);
            comando.Parameters.Add("@buscar", SqlDbType.VarChar, 100).Value = buscar.Trim();

            conexion.Open();
            using var lector = comando.ExecuteReader();
            var lista = new List<E_Usuario>();
            while (lector.Read())
                lista.Add(LeerUsuario(lector));
            return lista;
        });

        /// <summary>
        /// Inserta un usuario nuevo. El hash y el salt ya deben venir generados por la capa de Negocio.
        /// Si el rol es Cliente, el procedimiento crea también su ficha de cliente.
        /// </summary>
        /// <returns>El Id generado.</returns>
        public int Insertar(E_Usuario usuario) => Conexion.Ejecutar(() =>
        {
            using var conexion = Conexion.ObtenerConexion();
            using var comando = Conexion.CrearComando("sp_InsertarUsuario", conexion);
            comando.Parameters.Add("@dsUsuario", SqlDbType.VarChar, 50).Value = usuario.Usuario;
            comando.Parameters.Add("@dsPassword", SqlDbType.VarBinary, 64).Value = usuario.PasswordHash;
            comando.Parameters.Add("@dsSalt", SqlDbType.VarBinary, 16).Value = usuario.Salt;
            AgregarDatosGenerales(comando, usuario);
            comando.Parameters.Add("@dsUsuarioCreacion", SqlDbType.VarChar, 50).Value = usuario.UsuarioCreacion;

            conexion.Open();
            return Convert.ToInt32(comando.ExecuteScalar());
        });

        /// <summary>Actualiza nombre, contacto, rol y estado (no la contraseña).</summary>
        public void Actualizar(E_Usuario usuario) => Conexion.Ejecutar(() =>
        {
            using var conexion = Conexion.ObtenerConexion();
            using var comando = Conexion.CrearComando("sp_ActualizarUsuario", conexion);
            comando.Parameters.Add("@id", SqlDbType.Int).Value = usuario.Id;
            AgregarDatosGenerales(comando, usuario);

            conexion.Open();
            comando.ExecuteNonQuery();
        });

        /// <summary>Reemplaza el hash y el salt de la contraseña del usuario.</summary>
        public void CambiarPassword(int idUsuario, byte[] hash, byte[] salt) => Conexion.Ejecutar(() =>
        {
            using var conexion = Conexion.ObtenerConexion();
            using var comando = Conexion.CrearComando("sp_CambiarPassword", conexion);
            comando.Parameters.Add("@id", SqlDbType.Int).Value = idUsuario;
            comando.Parameters.Add("@dsPassword", SqlDbType.VarBinary, 64).Value = hash;
            comando.Parameters.Add("@dsSalt", SqlDbType.VarBinary, 16).Value = salt;

            conexion.Open();
            comando.ExecuteNonQuery();
        });

        /// <summary>Elimina el usuario (falla con <see cref="DatosException"/> si tiene ventas).</summary>
        public void Eliminar(int idUsuario) => Conexion.Ejecutar(() =>
        {
            using var conexion = Conexion.ObtenerConexion();
            using var comando = Conexion.CrearComando("sp_EliminarUsuario", conexion);
            comando.Parameters.Add("@id", SqlDbType.Int).Value = idUsuario;

            conexion.Open();
            comando.ExecuteNonQuery();
        });

        private static void AgregarDatosGenerales(SqlCommand comando, E_Usuario usuario)
        {
            comando.Parameters.Add("@dsNombre", SqlDbType.VarChar, 100).Value = usuario.Nombre;
            comando.Parameters.Add("@dsCorreo", SqlDbType.VarChar, 100).Value = LectorExtensiones.NuloSiVacio(usuario.Correo);
            comando.Parameters.Add("@dsTelefono", SqlDbType.VarChar, 20).Value = LectorExtensiones.NuloSiVacio(usuario.Telefono);
            comando.Parameters.Add("@idRol", SqlDbType.TinyInt).Value = (byte)usuario.Rol;
            comando.Parameters.Add("@dsEstado", SqlDbType.Bit).Value = usuario.Estado;
        }

        private static E_Usuario LeerUsuario(SqlDataReader lector) => new()
        {
            Id = lector.Entero("id"),
            Usuario = lector.Texto("dsUsuario"),
            Nombre = lector.Texto("dsNombre"),
            Correo = lector.Texto("dsCorreo"),
            Telefono = lector.Texto("dsTelefono"),
            Rol = (Rol)lector.GetByte(lector.GetOrdinal("idRol")),
            Estado = lector.Booleano("dsEstado"),
            UsuarioCreacion = lector.Texto("dsUsuarioCreacion"),
            FechaCreacion = lector.Fecha("dsFechaCreacion")
        };
    }
}
