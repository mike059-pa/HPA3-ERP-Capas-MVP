namespace CapaPresentacion.Vistas;

/// <summary>
/// Contrato común de las vistas de mantenimiento (CRUD): buscar, listar, seleccionar,
/// crear, guardar y eliminar. Cada módulo lo especializa con su entidad.
/// </summary>
/// <typeparam name="T">Entidad que se administra.</typeparam>
public interface IVistaCrud<T>
{
    /// <summary>Texto del buscador.</summary>
    string TextoBusqueda { get; }

    /// <summary>Elemento seleccionado en la lista, o <c>null</c>.</summary>
    T? Seleccionado { get; }

    event EventHandler Cargar;
    event EventHandler Buscar;
    event EventHandler SeleccionCambiada;
    event EventHandler Nuevo;
    event EventHandler Guardar;
    event EventHandler Eliminar;

    /// <summary>Muestra la lista de elementos.</summary>
    void MostrarLista(List<T> elementos);

    /// <summary>Carga un elemento en el formulario de edición (<c>null</c> = formulario vacío).</summary>
    void CargarFormulario(T? elemento);

    /// <summary>Devuelve los datos escritos en el formulario de edición.</summary>
    T LeerFormulario();

    /// <summary>Muestra un mensaje de éxito o error.</summary>
    void MostrarMensaje(string mensaje, bool exito);

    /// <summary>Pide confirmación antes de una acción destructiva.</summary>
    bool Confirmar(string pregunta);
}
