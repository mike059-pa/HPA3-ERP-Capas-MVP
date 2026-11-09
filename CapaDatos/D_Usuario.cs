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
        /// Busca un usuario por su nombre de usuario mediante <c>sp_ObtenerUsuario</c>.
        /// </summary>
        /// <param name="usuario">Nombre de usuario.</param>
        /// <returns>El usuario encontrado o <c>null</c> si no existe.</returns>
        public E_Usuario? ObtenerPorUsuario(string usuario)
        {
            using var conexion = Conexion.ObtenerConexion();
            using var comando = new SqlCommand("sp_ObtenerUsuario", conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            comando.Parameters.Add("@dsUsuario", SqlDbType.VarChar, 50).Value = usuario;

            conexion.Open();
            using var lector = comando.ExecuteReader();
            if (!lector.Read())
                return null;

            return new E_Usuario
            {
                // GetInt32/GetString: lectura tipada y directa (columnas NOT NULL)
                Id = lector.GetInt32(lector.GetOrdinal("id")),
                Usuario = lector.GetString(lector.GetOrdinal("dsUsuario")),
                PasswordHash = (byte[])lector["dsPassword"],
                Salt = (byte[])lector["dsSalt"],
                Nombre = lector.GetString(lector.GetOrdinal("dsNombre")),
                Estado = lector.GetBoolean(lector.GetOrdinal("dsEstado")),
                // Columnas que podrían ser NULL: se valida con IsDBNull
                UsuarioCreacion = lector.IsDBNull(lector.GetOrdinal("dsUsuarioCreacion"))
                    ? string.Empty
                    : lector.GetString(lector.GetOrdinal("dsUsuarioCreacion")),
                FechaCreacion = lector.GetDateTime(lector.GetOrdinal("dsFechaCreacion"))
            };
        }

        /// <summary>
        /// Inserta un usuario nuevo mediante <c>sp_InsertarUsuario</c>.
        /// El hash y el salt ya deben venir generados por la capa de Negocio.
        /// </summary>
        /// <returns>El Id generado para el nuevo usuario.</returns>
        public int Insertar(E_Usuario usuario)
        {
            using var conexion = Conexion.ObtenerConexion();
            using var comando = new SqlCommand("sp_InsertarUsuario", conexion)
            {
                CommandType = CommandType.StoredProcedure
            };
            comando.Parameters.Add("@dsUsuario", SqlDbType.VarChar, 50).Value = usuario.Usuario;
            comando.Parameters.Add("@dsPassword", SqlDbType.VarBinary, 64).Value = usuario.PasswordHash;
            comando.Parameters.Add("@dsSalt", SqlDbType.VarBinary, 16).Value = usuario.Salt;
            comando.Parameters.Add("@dsNombre", SqlDbType.VarChar, 100).Value = usuario.Nombre;
            comando.Parameters.Add("@dsEstado", SqlDbType.Bit).Value = usuario.Estado;
            comando.Parameters.Add("@dsUsuarioCreacion", SqlDbType.VarChar, 50).Value = usuario.UsuarioCreacion;

            conexion.Open();
            return Convert.ToInt32(comando.ExecuteScalar());
        }
    }
}
