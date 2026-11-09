using CapaEntidades;

namespace CapaNegocio.Tests;

/// <summary>Pruebas de la matriz de permisos por rol.</summary>
public class PermisosTests
{
    [Theory]
    [InlineData(Modulo.Usuarios)]
    [InlineData(Modulo.Productos)]
    [InlineData(Modulo.Clientes)]
    [InlineData(Modulo.Ventas)]
    [InlineData(Modulo.Reportes)]
    public void Administrador_VeLosModulosDeGestion(Modulo modulo) =>
        Assert.True(Permisos.PuedeVer(Rol.Administrador, modulo));

    [Fact]
    public void Vendedor_ConsultaProductosPeroNoLosEdita()
    {
        Assert.True(Permisos.PuedeVer(Rol.Vendedor, Modulo.Productos));
        Assert.False(Permisos.PuedeEditar(Rol.Vendedor, Modulo.Productos));
    }

    [Fact]
    public void Vendedor_NoVeUsuariosNiReportes()
    {
        Assert.False(Permisos.PuedeVer(Rol.Vendedor, Modulo.Usuarios));
        Assert.False(Permisos.PuedeVer(Rol.Vendedor, Modulo.Reportes));
    }

    [Fact]
    public void Cliente_SoloCompraYVeSusCompras()
    {
        Assert.Equal(
            [Modulo.Dashboard, Modulo.Comprar, Modulo.MisCompras, Modulo.Perfil],
            Permisos.ModulosVisibles(Rol.Cliente));
        Assert.False(Permisos.PuedeVer(Rol.Cliente, Modulo.Ventas));
        Assert.False(Permisos.PuedeEditar(Rol.Cliente, Modulo.Clientes));
    }

    [Theory]
    [InlineData(Rol.Administrador)]
    [InlineData(Rol.Vendedor)]
    [InlineData(Rol.Cliente)]
    public void TodosLosRoles_TienenDashboardYPerfil(Rol rol)
    {
        Assert.True(Permisos.PuedeVer(rol, Modulo.Dashboard));
        Assert.True(Permisos.PuedeEditar(rol, Modulo.Perfil));
    }
}
