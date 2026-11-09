using CapaNegocio.Contratos;
using CapaNegocio.Servicios;

namespace CapaNegocio.Tests;

/// <summary>Pruebas de los dos contratos de hash implementados por <see cref="Sha512PasswordService"/>.</summary>
public class Sha512PasswordServiceTests
{
    private readonly IHashService _hash = new Sha512PasswordService();
    private readonly IVerificarHashService _verificar = new Sha512PasswordService();

    [Fact]
    public void GenerarHash_ProduceSha512De64Bytes()
    {
        var salt = _hash.GenerarSalt();
        Assert.Equal(16, salt.Length);
        Assert.Equal(64, _hash.GenerarHash("Admin123", salt).Length);
    }

    [Fact]
    public void Verificar_PasswordCorrecta_DevuelveTrue()
    {
        var salt = _hash.GenerarSalt();
        var hash = _hash.GenerarHash("Admin123", salt);
        Assert.True(_verificar.Verificar("Admin123", hash, salt));
    }

    [Fact]
    public void Verificar_PasswordIncorrecta_DevuelveFalse()
    {
        var salt = _hash.GenerarSalt();
        var hash = _hash.GenerarHash("Admin123", salt);
        Assert.False(_verificar.Verificar("admin123", hash, salt));
    }

    [Fact]
    public void GenerarHash_MismaPasswordConDistintoSalt_DaHashesDistintos()
    {
        var hash1 = _hash.GenerarHash("Admin123", _hash.GenerarSalt());
        var hash2 = _hash.GenerarHash("Admin123", _hash.GenerarSalt());
        Assert.NotEqual(hash1, hash2);
    }

    /// <summary>
    /// Hash generado en SQL Server con HASHBYTES('SHA2_512', salt + CAST('123456' AS VARBINARY)):
    /// demuestra que el usuario semilla creado en el script puede iniciar sesión desde C#.
    /// </summary>
    [Fact]
    public void Verificar_HashGeneradoEnSqlServer_EsCompatible()
    {
        var salt = Convert.FromHexString("D7D1BEDCD4BFF583E1E8DD82348B4C88");
        var hashSql = Convert.FromHexString(
            "233EBB4D305583816114B75F8A3505C7BCB96E476554142212762B1CD70215889E5B95060A2AE78DF6B231CC824DAF585FF627A336439836CE388FAF5A28CC5E");

        Assert.True(_verificar.Verificar("123456", hashSql, salt));
    }
}
