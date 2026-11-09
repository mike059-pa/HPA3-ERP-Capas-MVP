using CapaEntidades;

namespace CapaNegocio
{
    /// <summary>Módulos (opciones del menú) del ERP.</summary>
    public enum Modulo
    {
        Dashboard,
        Usuarios,
        Productos,
        Clientes,
        Ventas,
        Comprar,
        MisCompras,
        Reportes,
        Perfil
    }

    /// <summary>
    /// Matriz de permisos por rol. Es la regla de autorización del sistema:
    /// la capa de Negocio la valida en cada operación y la Presentación la usa
    /// para mostrar solo las opciones permitidas en el menú.
    /// </summary>
    public static class Permisos
    {
        private static readonly Dictionary<Rol, Modulo[]> Visibles = new()
        {
            [Rol.Administrador] = [Modulo.Dashboard, Modulo.Usuarios, Modulo.Productos, Modulo.Clientes,
                                   Modulo.Ventas, Modulo.Reportes, Modulo.Perfil],
            [Rol.Vendedor] = [Modulo.Dashboard, Modulo.Productos, Modulo.Clientes, Modulo.Ventas, Modulo.Perfil],
            [Rol.Cliente] = [Modulo.Dashboard, Modulo.Comprar, Modulo.MisCompras, Modulo.Perfil]
        };

        private static readonly Dictionary<Rol, Modulo[]> Editables = new()
        {
            [Rol.Administrador] = [Modulo.Usuarios, Modulo.Productos, Modulo.Clientes, Modulo.Ventas, Modulo.Perfil],
            [Rol.Vendedor] = [Modulo.Clientes, Modulo.Ventas, Modulo.Perfil],
            [Rol.Cliente] = [Modulo.Comprar, Modulo.Perfil]
        };

        /// <summary>Módulos que el rol puede ver, en el orden del menú.</summary>
        public static IReadOnlyList<Modulo> ModulosVisibles(Rol rol) =>
            Visibles.TryGetValue(rol, out var modulos) ? modulos : [];

        /// <summary>Indica si el rol puede abrir el módulo.</summary>
        public static bool PuedeVer(Rol rol, Modulo modulo) => ModulosVisibles(rol).Contains(modulo);

        /// <summary>Indica si el rol puede crear, modificar o eliminar en el módulo.</summary>
        public static bool PuedeEditar(Rol rol, Modulo modulo) =>
            Editables.TryGetValue(rol, out var modulos) && modulos.Contains(modulo);
    }
}
