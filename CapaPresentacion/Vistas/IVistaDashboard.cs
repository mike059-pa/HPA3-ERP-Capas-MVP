using System.Data;

namespace CapaPresentacion.Vistas;

/// <summary>Datos de una tarjeta del "Sumario del sistema".</summary>
/// <param name="Titulo">Texto del encabezado.</param>
/// <param name="Valor">Cifra a mostrar.</param>
/// <param name="Icono">Glifo de Segoe MDL2 Assets.</param>
public record TarjetaResumen(string Titulo, string Valor, string Icono);

/// <summary>Contrato de la Vista del dashboard (MVP).</summary>
public interface IVistaDashboard
{
    /// <summary>Hora del reloj grande.</summary>
    string Hora { set; }

    /// <summary>Fecha bajo el reloj.</summary>
    string Fecha { set; }

    /// <summary>Se dispara al cargar la vista.</summary>
    event EventHandler Cargar;

    /// <summary>Se dispara cada segundo para refrescar el reloj.</summary>
    event EventHandler TickReloj;

    /// <summary>Dibuja las tarjetas de resumen.</summary>
    void MostrarTarjetas(IReadOnlyList<TarjetaResumen> tarjetas);

    /// <summary>Muestra la lista inferior (bajo stock o compras recientes).</summary>
    void MostrarLista(string titulo, DataTable datos);

    /// <summary>Muestra un error de carga.</summary>
    void MostrarError(string mensaje);
}
