using CapaDatos;
using CapaEntidades;

namespace CapaNegocio
{
    /// <summary>Reglas de negocio de clientes (Administrador y Vendedor).</summary>
    public class N_Cliente
    {
        private readonly D_Cliente _datos = new();

        /// <summary>Lista clientes filtrando por nombre o cédula.</summary>
        public Resultado<List<E_Cliente>> Listar(E_Usuario actor, string buscar, bool soloActivos)
        {
            if (!Permisos.PuedeVer(actor.Rol, Modulo.Clientes))
                return Resultado<List<E_Cliente>>.SinPermiso();
            return Operacion.Ejecutar(() => _datos.Listar(buscar, soloActivos));
        }

        /// <summary>Crea (Id = 0) o actualiza un cliente.</summary>
        public Resultado<int> Guardar(E_Usuario actor, E_Cliente cliente)
        {
            if (!Permisos.PuedeEditar(actor.Rol, Modulo.Clientes))
                return Resultado<int>.SinPermiso();

            if (string.IsNullOrWhiteSpace(cliente.Nombre))
                return Resultado<int>.Error("El nombre del cliente es obligatorio.");
            if (!Validar.CorreoOpcional(cliente.Correo))
                return Resultado<int>.Error("El correo no tiene un formato válido.");

            cliente.Nombre = cliente.Nombre.Trim();

            if (cliente.Id == 0)
                return Operacion.Ejecutar(() => _datos.Insertar(cliente), "Cliente registrado.");

            return Operacion.Ejecutar(() => { _datos.Actualizar(cliente); return cliente.Id; }, "Cliente actualizado.");
        }

        /// <summary>Elimina un cliente sin ventas ni cuenta de usuario.</summary>
        public Resultado<bool> Eliminar(E_Usuario actor, int idCliente)
        {
            if (!Permisos.PuedeEditar(actor.Rol, Modulo.Clientes))
                return Resultado<bool>.SinPermiso();
            return Operacion.Ejecutar(() => { _datos.Eliminar(idCliente); return true; }, "Cliente eliminado.");
        }
    }
}
