using System.Data;
using CapaEntidades;

namespace CapaDatos
{
    /// <summary>Consultas del dashboard y de los reportes.</summary>
    public class D_Reporte
    {
        /// <summary>Cifras del "Sumario del sistema" filtradas según el rol del usuario.</summary>
        public E_ResumenDashboard Resumen(int idUsuario, Rol rol) => Conexion.Ejecutar(() =>
        {
            using var conexion = Conexion.ObtenerConexion();
            using var comando = Conexion.CrearComando("sp_ResumenDashboard", conexion);
            comando.Parameters.Add("@idUsuario", SqlDbType.Int).Value = idUsuario;
            comando.Parameters.Add("@idRol", SqlDbType.TinyInt).Value = (byte)rol;

            conexion.Open();
            using var lector = comando.ExecuteReader();
            lector.Read();
            return new E_ResumenDashboard
            {
                TotalUsuarios = lector.Entero("totalUsuarios"),
                TotalClientes = lector.Entero("totalClientes"),
                TotalProductos = lector.Entero("totalProductos"),
                ProductosBajoStock = lector.Entero("productosBajoStock"),
                NumVentas = lector.Entero("numVentas"),
                MontoVentas = lector.Decimal("montoVentas"),
                VentasHoy = lector.Entero("ventasHoy"),
                MontoHoy = lector.Decimal("montoHoy"),
                MontoMes = lector.Decimal("montoMes")
            };
        });

        /// <summary>Unidades vendidas y total por producto en el rango de fechas.</summary>
        public List<E_FilaReporte> VentasPorProducto(DateTime desde, DateTime hasta) =>
            Reporte("sp_ReporteVentasPorProducto", desde, hasta);

        /// <summary>Número de ventas y total por vendedor en el rango de fechas.</summary>
        public List<E_FilaReporte> VentasPorVendedor(DateTime desde, DateTime hasta) =>
            Reporte("sp_ReporteVentasPorVendedor", desde, hasta);

        private static List<E_FilaReporte> Reporte(string procedimiento, DateTime desde, DateTime hasta) => Conexion.Ejecutar(() =>
        {
            using var conexion = Conexion.ObtenerConexion();
            using var comando = Conexion.CrearComando(procedimiento, conexion);
            comando.Parameters.Add("@desde", SqlDbType.Date).Value = desde.Date;
            comando.Parameters.Add("@hasta", SqlDbType.Date).Value = hasta.Date;

            conexion.Open();
            using var lector = comando.ExecuteReader();
            var lista = new List<E_FilaReporte>();
            while (lector.Read())
            {
                lista.Add(new E_FilaReporte
                {
                    Descripcion = lector.Texto("descripcion"),
                    Cantidad = lector.Entero("cantidad"),
                    Total = lector.Decimal("total")
                });
            }
            return lista;
        });
    }
}
