using CapaDatos;
using CapaEntidades;

namespace CapaNegocio
{
    /// <summary>Reglas de negocio del inventario de productos.</summary>
    public class N_Producto
    {
        private readonly D_Producto _datos = new();

        /// <summary>
        /// Lista productos. Cualquier usuario autenticado puede consultarlos
        /// (el cliente los necesita para el catálogo de compra).
        /// </summary>
        public Resultado<List<E_Producto>> Listar(string buscar, bool soloActivos) =>
            Operacion.Ejecutar(() => _datos.Listar(buscar, soloActivos));

        /// <summary>Productos cuyo stock llegó al mínimo.</summary>
        public Resultado<List<E_Producto>> BajoStock() => Operacion.Ejecutar(_datos.BajoStock);

        /// <summary>Crea (Id = 0) o actualiza un producto (solo Administrador).</summary>
        public Resultado<int> Guardar(E_Usuario actor, E_Producto producto)
        {
            if (!Permisos.PuedeEditar(actor.Rol, Modulo.Productos))
                return Resultado<int>.SinPermiso();

            if (string.IsNullOrWhiteSpace(producto.Codigo) || string.IsNullOrWhiteSpace(producto.Nombre))
                return Resultado<int>.Error("El código y el nombre son obligatorios.");
            if (producto.Precio <= 0)
                return Resultado<int>.Error("El precio debe ser mayor que cero.");
            if (producto.Stock < 0 || producto.StockMinimo < 0)
                return Resultado<int>.Error("El stock y el stock mínimo no pueden ser negativos.");

            producto.Codigo = producto.Codigo.Trim().ToUpperInvariant();
            producto.Nombre = producto.Nombre.Trim();

            if (producto.Id == 0)
                return Operacion.Ejecutar(() => _datos.Insertar(producto), "Producto registrado.");

            return Operacion.Ejecutar(() => { _datos.Actualizar(producto); return producto.Id; }, "Producto actualizado.");
        }

        /// <summary>Elimina un producto sin ventas (solo Administrador).</summary>
        public Resultado<bool> Eliminar(E_Usuario actor, int idProducto)
        {
            if (!Permisos.PuedeEditar(actor.Rol, Modulo.Productos))
                return Resultado<bool>.SinPermiso();
            return Operacion.Ejecutar(() => { _datos.Eliminar(idProducto); return true; }, "Producto eliminado.");
        }
    }
}
