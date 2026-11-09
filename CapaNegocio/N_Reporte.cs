using CapaDatos;
using CapaEntidades;

namespace CapaNegocio
{
    /// <summary>Tipos de reporte disponibles.</summary>
    public enum TipoReporte { VentasPorProducto, VentasPorVendedor }

    /// <summary>Dashboard y reportes.</summary>
    public class N_Reporte
    {
        private readonly D_Reporte _datos = new();

        /// <summary>Cifras del dashboard filtradas según el rol del usuario en sesión.</summary>
        public Resultado<E_ResumenDashboard> Resumen(E_Usuario actor) =>
            Operacion.Ejecutar(() => _datos.Resumen(actor.Id, actor.Rol));

        /// <summary>Genera un reporte en el rango de fechas (solo Administrador).</summary>
        public Resultado<List<E_FilaReporte>> Generar(E_Usuario actor, TipoReporte tipo, DateTime desde, DateTime hasta)
        {
            if (!Permisos.PuedeVer(actor.Rol, Modulo.Reportes))
                return Resultado<List<E_FilaReporte>>.SinPermiso();
            if (desde.Date > hasta.Date)
                return Resultado<List<E_FilaReporte>>.Error("La fecha inicial no puede ser mayor que la final.");

            return tipo == TipoReporte.VentasPorProducto
                ? Operacion.Ejecutar(() => _datos.VentasPorProducto(desde, hasta))
                : Operacion.Ejecutar(() => _datos.VentasPorVendedor(desde, hasta));
        }
    }
}
