using CapaNegocio;
using CapaPresentacion.Vistas;

namespace CapaPresentacion.Presentadores;

/// <summary>
/// Lógica común de los mantenimientos (CRUD). Cada módulo solo indica cómo listar,
/// guardar y eliminar su entidad usando la capa de Negocio.
/// </summary>
/// <typeparam name="T">Entidad que se administra.</typeparam>
public abstract class CrudPresentador<T> where T : class
{
    private readonly IVistaCrud<T> _vista;

    protected CrudPresentador(IVistaCrud<T> vista)
    {
        _vista = vista;
        _vista.Cargar += (_, _) => Ejecutar(() => { AlCargar(); Refrescar(); });
        _vista.Buscar += (_, _) => Ejecutar(Refrescar);
        _vista.SeleccionCambiada += (_, _) => _vista.CargarFormulario(_vista.Seleccionado);
        _vista.Nuevo += (_, _) => { _vista.CargarFormulario(null); _vista.MostrarMensaje(string.Empty, true); };
        _vista.Guardar += (_, _) => Ejecutar(GuardarActual);
        _vista.Eliminar += (_, _) => Ejecutar(EliminarSeleccionado);
    }

    /// <summary>Consulta la lista filtrada.</summary>
    protected abstract Resultado<List<T>> Listar(string buscar);

    /// <summary>Crea o actualiza el elemento escrito en el formulario.</summary>
    protected abstract Resultado<int> GuardarElemento(T elemento);

    /// <summary>Elimina el elemento.</summary>
    protected abstract Resultado<bool> EliminarElemento(T elemento);

    /// <summary>Texto que identifica al elemento en la pregunta de confirmación.</summary>
    protected abstract string Describir(T elemento);

    /// <summary>Configuración adicional al abrir el módulo.</summary>
    protected virtual void AlCargar() { }

    private void Refrescar()
    {
        var resultado = Listar(_vista.TextoBusqueda);
        if (resultado.Exito && resultado.Dato is not null)
            _vista.MostrarLista(resultado.Dato);
        else
            _vista.MostrarMensaje(resultado.Mensaje, false);
    }

    private void GuardarActual()
    {
        var resultado = GuardarElemento(_vista.LeerFormulario());
        if (resultado.Exito)
        {
            Refrescar();
            _vista.CargarFormulario(null);
        }
        _vista.MostrarMensaje(resultado.Mensaje, resultado.Exito);
    }

    private void EliminarSeleccionado()
    {
        var seleccionado = _vista.Seleccionado;
        if (seleccionado is null)
        {
            _vista.MostrarMensaje("Seleccione un registro de la lista.", false);
            return;
        }
        if (!_vista.Confirmar($"¿Desea eliminar {Describir(seleccionado)}?"))
            return;

        var resultado = EliminarElemento(seleccionado);
        if (resultado.Exito)
        {
            Refrescar();
            _vista.CargarFormulario(null);
        }
        _vista.MostrarMensaje(resultado.Mensaje, resultado.Exito);
    }

    private void Ejecutar(Action accion) => Soporte.Ejecutar(accion, m => _vista.MostrarMensaje(m, false));
}
