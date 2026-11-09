using System.Data;
using CapaEntidades;
using Microsoft.Data.SqlClient;

namespace CapaDatos
{
    /// <summary>Acceso a datos de la tabla <c>clientes</c> mediante procedimientos almacenados.</summary>
    public class D_Cliente
    {
        /// <summary>Lista clientes filtrando por nombre o cédula.</summary>
        public List<E_Cliente> Listar(string buscar, bool soloActivos) => Conexion.Ejecutar(() =>
        {
            using var conexion = Conexion.ObtenerConexion();
            using var comando = Conexion.CrearComando("sp_ListarClientes", conexion);
            comando.Parameters.Add("@buscar", SqlDbType.VarChar, 100).Value = buscar.Trim();
            comando.Parameters.Add("@soloActivos", SqlDbType.Bit).Value = soloActivos;

            conexion.Open();
            using var lector = comando.ExecuteReader();
            var lista = new List<E_Cliente>();
            while (lector.Read())
            {
                lista.Add(new E_Cliente
                {
                    Id = lector.Entero("id"),
                    Nombre = lector.Texto("nombre"),
                    Cedula = lector.Texto("cedula"),
                    Telefono = lector.Texto("telefono"),
                    Correo = lector.Texto("correo"),
                    Direccion = lector.Texto("direccion"),
                    IdUsuario = lector.EnteroNulo("idUsuario"),
                    Usuario = lector.Texto("usuario"),
                    Estado = lector.Booleano("estado")
                });
            }
            return lista;
        });

        /// <returns>El Id generado.</returns>
        public int Insertar(E_Cliente cliente) => Conexion.Ejecutar(() =>
        {
            using var conexion = Conexion.ObtenerConexion();
            using var comando = Conexion.CrearComando("sp_InsertarCliente", conexion);
            AgregarParametros(comando, cliente);
            conexion.Open();
            return Convert.ToInt32(comando.ExecuteScalar());
        });

        public void Actualizar(E_Cliente cliente) => Conexion.Ejecutar(() =>
        {
            using var conexion = Conexion.ObtenerConexion();
            using var comando = Conexion.CrearComando("sp_ActualizarCliente", conexion);
            comando.Parameters.Add("@id", SqlDbType.Int).Value = cliente.Id;
            AgregarParametros(comando, cliente);
            conexion.Open();
            comando.ExecuteNonQuery();
        });

        /// <summary>Elimina el cliente (falla si tiene ventas o una cuenta de usuario).</summary>
        public void Eliminar(int idCliente) => Conexion.Ejecutar(() =>
        {
            using var conexion = Conexion.ObtenerConexion();
            using var comando = Conexion.CrearComando("sp_EliminarCliente", conexion);
            comando.Parameters.Add("@id", SqlDbType.Int).Value = idCliente;
            conexion.Open();
            comando.ExecuteNonQuery();
        });

        private static void AgregarParametros(SqlCommand comando, E_Cliente cliente)
        {
            comando.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Value = cliente.Nombre;
            comando.Parameters.Add("@cedula", SqlDbType.VarChar, 20).Value = LectorExtensiones.NuloSiVacio(cliente.Cedula);
            comando.Parameters.Add("@telefono", SqlDbType.VarChar, 20).Value = LectorExtensiones.NuloSiVacio(cliente.Telefono);
            comando.Parameters.Add("@correo", SqlDbType.VarChar, 100).Value = LectorExtensiones.NuloSiVacio(cliente.Correo);
            comando.Parameters.Add("@direccion", SqlDbType.VarChar, 200).Value = LectorExtensiones.NuloSiVacio(cliente.Direccion);
            comando.Parameters.Add("@estado", SqlDbType.Bit).Value = cliente.Estado;
        }
    }
}
