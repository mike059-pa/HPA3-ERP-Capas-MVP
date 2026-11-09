using CapaEntidades;
using CapaNegocio.Servicios;

namespace CapaNegocio.Tests;

/// <summary>
/// Pruebas de reglas de negocio que se validan antes de llegar a la base de datos
/// (no requieren SQL Server).
/// </summary>
public class ReglasNegocioTests
{
    private static readonly E_Producto Laptop = new() { Id = 1, Codigo = "LAP-001", Nombre = "Laptop", Precio = 10.00m, Stock = 3 };
    private static readonly E_Producto Mouse = new() { Id = 2, Codigo = "MOU-001", Nombre = "Mouse", Precio = 5.55m, Stock = 10 };

    [Fact]
    public void CalcularTotales_AplicaItbmsDel7PorCientoRedondeado()
    {
        var carrito = new List<E_DetalleVenta>();
        N_Venta.AgregarAlCarrito(carrito, Laptop, 2);
        N_Venta.AgregarAlCarrito(carrito, Mouse, 1);

        var totales = N_Venta.CalcularTotales(carrito);

        Assert.Equal(25.55m, totales.Subtotal);
        Assert.Equal(1.79m, totales.Itbms);    // 25.55 × 0.07 = 1.7885
        Assert.Equal(27.34m, totales.Total);
    }

    [Fact]
    public void AgregarAlCarrito_MismoProducto_SumaCantidades()
    {
        var carrito = new List<E_DetalleVenta>();
        N_Venta.AgregarAlCarrito(carrito, Laptop, 1);
        N_Venta.AgregarAlCarrito(carrito, Laptop, 2);

        var linea = Assert.Single(carrito);
        Assert.Equal(3, linea.Cantidad);
    }

    [Fact]
    public void AgregarAlCarrito_SuperaElStock_Falla()
    {
        var carrito = new List<E_DetalleVenta>();
        N_Venta.AgregarAlCarrito(carrito, Laptop, 2);

        var resultado = N_Venta.AgregarAlCarrito(carrito, Laptop, 2);

        Assert.False(resultado.Exito);
        Assert.Contains("Stock insuficiente", resultado.Mensaje);
        Assert.Equal(2, carrito[0].Cantidad);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void AgregarAlCarrito_CantidadNoPositiva_Falla(int cantidad) =>
        Assert.False(N_Venta.AgregarAlCarrito([], Mouse, cantidad).Exito);

    [Fact]
    public void RegistrarVenta_CarritoVacio_Falla()
    {
        var vendedor = new E_Usuario { Id = 2, Rol = Rol.Vendedor };
        var resultado = new N_Venta().Registrar(vendedor, idClienteSeleccionado: 1, []);
        Assert.False(resultado.Exito);
    }

    [Fact]
    public void RegistrarVenta_SinCliente_Falla()
    {
        var vendedor = new E_Usuario { Id = 2, Rol = Rol.Vendedor };
        var carrito = new List<E_DetalleVenta>();
        N_Venta.AgregarAlCarrito(carrito, Mouse, 1);

        var resultado = new N_Venta().Registrar(vendedor, idClienteSeleccionado: null, carrito);

        Assert.False(resultado.Exito);
        Assert.Equal("Seleccione un cliente.", resultado.Mensaje);
    }

    [Fact]
    public void GuardarUsuario_ConRolVendedor_NoTienePermiso()
    {
        var servicio = new Sha512PasswordService();
        var negocio = new N_Usuario(servicio, servicio);
        var vendedor = new E_Usuario { Id = 2, Rol = Rol.Vendedor };

        var resultado = negocio.Guardar(vendedor, new E_Usuario { Usuario = "nuevo", Nombre = "Nuevo" }, "Clave123", "Clave123");

        Assert.False(resultado.Exito);
        Assert.Equal("No tiene permiso para realizar esta acción.", resultado.Mensaje);
    }

    [Fact]
    public void EliminarUsuario_PropiaCuenta_NoSePermite()
    {
        var servicio = new Sha512PasswordService();
        var admin = new E_Usuario { Id = 1, Rol = Rol.Administrador };

        var resultado = new N_Usuario(servicio, servicio).Eliminar(admin, 1);

        Assert.False(resultado.Exito);
    }

    [Theory]
    [InlineData("", "", "Ingrese la contraseña.")]
    [InlineData("abc", "abc", "La contraseña debe tener al menos 6 caracteres.")]
    [InlineData("Clave123", "Clave124", "Las contraseñas no coinciden.")]
    public void ValidarPassword_DetectaErrores(string password, string confirmacion, string esperado) =>
        Assert.Equal(esperado, Validar.Password(password, confirmacion));

    [Fact]
    public void ValidarPassword_Valida_DevuelveNull() => Assert.Null(Validar.Password("Clave123", "Clave123"));

    [Theory]
    [InlineData("", true)]
    [InlineData("ana@correo.com", true)]
    [InlineData("ana@correo", false)]
    [InlineData("ana correo.com", false)]
    public void ValidarCorreo(string correo, bool esperado) => Assert.Equal(esperado, Validar.CorreoOpcional(correo));
}
