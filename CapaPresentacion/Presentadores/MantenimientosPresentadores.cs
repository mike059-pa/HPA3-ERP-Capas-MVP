using CapaEntidades;
using CapaNegocio;
using CapaPresentacion.Vistas;

namespace CapaPresentacion.Presentadores;

/// <summary>Presentador del mantenimiento de usuarios (solo Administrador).</summary>
public class UsuariosPresentador(IVistaUsuarios vista, N_Usuario negocio) : CrudPresentador<E_Usuario>(vista)
{
    protected override Resultado<List<E_Usuario>> Listar(string buscar) => negocio.Listar(Soporte.Actor, buscar);

    // La contraseña se envía a Negocio, que genera el hash con IHashService
    protected override Resultado<int> GuardarElemento(E_Usuario elemento) =>
        negocio.Guardar(Soporte.Actor, elemento, vista.Password, vista.Confirmacion);

    protected override Resultado<bool> EliminarElemento(E_Usuario elemento) => negocio.Eliminar(Soporte.Actor, elemento.Id);

    protected override string Describir(E_Usuario elemento) => $"al usuario \"{elemento.Usuario}\"";
}

/// <summary>Presentador del mantenimiento de productos (Admin edita, Vendedor consulta).</summary>
public class ProductosPresentador(IVistaProductos vista, N_Producto negocio) : CrudPresentador<E_Producto>(vista)
{
    protected override void AlCargar() =>
        vista.PermitirEdicion = Permisos.PuedeEditar(Soporte.Actor.Rol, Modulo.Productos);

    protected override Resultado<List<E_Producto>> Listar(string buscar) => negocio.Listar(buscar, soloActivos: false);

    protected override Resultado<int> GuardarElemento(E_Producto elemento) => negocio.Guardar(Soporte.Actor, elemento);

    protected override Resultado<bool> EliminarElemento(E_Producto elemento) => negocio.Eliminar(Soporte.Actor, elemento.Id);

    protected override string Describir(E_Producto elemento) => $"el producto \"{elemento.Nombre}\"";
}

/// <summary>Presentador del mantenimiento de clientes (Admin y Vendedor).</summary>
public class ClientesPresentador(IVistaClientes vista, N_Cliente negocio) : CrudPresentador<E_Cliente>(vista)
{
    protected override Resultado<List<E_Cliente>> Listar(string buscar) => negocio.Listar(Soporte.Actor, buscar, soloActivos: false);

    protected override Resultado<int> GuardarElemento(E_Cliente elemento) => negocio.Guardar(Soporte.Actor, elemento);

    protected override Resultado<bool> EliminarElemento(E_Cliente elemento) => negocio.Eliminar(Soporte.Actor, elemento.Id);

    protected override string Describir(E_Cliente elemento) => $"al cliente \"{elemento.Nombre}\"";
}
