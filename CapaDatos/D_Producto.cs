using System.Data;
using CapaEntidades;
using Microsoft.Data.SqlClient;

namespace CapaDatos
{
    /// <summary>Acceso a datos de la tabla <c>productos</c> mediante procedimientos almacenados.</summary>
    public class D_Producto
    {
        /// <summary>Lista productos filtrando por código o nombre.</summary>
        /// <param name="soloActivos">true para excluir los productos desactivados.</param>
        public List<E_Producto> Listar(string buscar, bool soloActivos) => Conexion.Ejecutar(() =>
        {
            using var conexion = Conexion.ObtenerConexion();
            using var comando = Conexion.CrearComando("sp_ListarProductos", conexion);
            comando.Parameters.Add("@buscar", SqlDbType.VarChar, 100).Value = buscar.Trim();
            comando.Parameters.Add("@soloActivos", SqlDbType.Bit).Value = soloActivos;
            conexion.Open();
            return LeerLista(comando);
        });

        /// <summary>Productos activos cuyo stock es menor o igual al stock mínimo.</summary>
        public List<E_Producto> BajoStock() => Conexion.Ejecutar(() =>
        {
            using var conexion = Conexion.ObtenerConexion();
            using var comando = Conexion.CrearComando("sp_ProductosBajoStock", conexion);
            conexion.Open();
            return LeerLista(comando);
        });

        /// <returns>El Id generado.</returns>
        public int Insertar(E_Producto producto) => Conexion.Ejecutar(() =>
        {
            using var conexion = Conexion.ObtenerConexion();
            using var comando = Conexion.CrearComando("sp_InsertarProducto", conexion);
            AgregarParametros(comando, producto);
            conexion.Open();
            return Convert.ToInt32(comando.ExecuteScalar());
        });

        public void Actualizar(E_Producto producto) => Conexion.Ejecutar(() =>
        {
            using var conexion = Conexion.ObtenerConexion();
            using var comando = Conexion.CrearComando("sp_ActualizarProducto", conexion);
            comando.Parameters.Add("@id", SqlDbType.Int).Value = producto.Id;
            AgregarParametros(comando, producto);
            conexion.Open();
            comando.ExecuteNonQuery();
        });

        /// <summary>Elimina el producto (falla con <see cref="DatosException"/> si tiene ventas).</summary>
        public void Eliminar(int idProducto) => Conexion.Ejecutar(() =>
        {
            using var conexion = Conexion.ObtenerConexion();
            using var comando = Conexion.CrearComando("sp_EliminarProducto", conexion);
            comando.Parameters.Add("@id", SqlDbType.Int).Value = idProducto;
            conexion.Open();
            comando.ExecuteNonQuery();
        });

        private static void AgregarParametros(SqlCommand comando, E_Producto producto)
        {
            comando.Parameters.Add("@codigo", SqlDbType.VarChar, 20).Value = producto.Codigo;
            comando.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Value = producto.Nombre;
            comando.Parameters.Add("@descripcion", SqlDbType.VarChar, 250).Value = LectorExtensiones.NuloSiVacio(producto.Descripcion);
            var precio = comando.Parameters.Add("@precio", SqlDbType.Decimal);
            precio.Precision = 10;
            precio.Scale = 2;
            precio.Value = producto.Precio;
            comando.Parameters.Add("@stock", SqlDbType.Int).Value = producto.Stock;
            comando.Parameters.Add("@stockMinimo", SqlDbType.Int).Value = producto.StockMinimo;
            comando.Parameters.Add("@estado", SqlDbType.Bit).Value = producto.Estado;
        }

        private static List<E_Producto> LeerLista(SqlCommand comando)
        {
            using var lector = comando.ExecuteReader();
            var lista = new List<E_Producto>();
            while (lector.Read())
            {
                lista.Add(new E_Producto
                {
                    Id = lector.Entero("id"),
                    Codigo = lector.Texto("codigo"),
                    Nombre = lector.Texto("nombre"),
                    Descripcion = lector.Texto("descripcion"),
                    Precio = lector.Decimal("precio"),
                    Stock = lector.Entero("stock"),
                    StockMinimo = lector.Entero("stockMinimo"),
                    Estado = lector.Booleano("estado")
                });
            }
            return lista;
        }
    }
}
