using System.Security.Cryptography;
using System.Text;
using CapaNegocio.Contratos;

namespace CapaNegocio.Servicios
{
    /// <summary>
    /// Implementación SHA-512 de ambos contratos.
    /// Hash = SHA512(salt ‖ UTF8(password)), el mismo cálculo que
    /// <c>HASHBYTES('SHA2_512', salt + CONVERT(VARBINARY, password))</c> en SQL Server.
    /// Si se cambia el algoritmo (BCrypt, Argon2...) solo se reemplaza esta clase.
    /// </summary>
    public class Sha512PasswordService : IHashService, IVerificarHashService
    {
        private const int TamanoSalt = 16;

        /// <inheritdoc />
        public byte[] GenerarSalt() => RandomNumberGenerator.GetBytes(TamanoSalt);

        /// <inheritdoc />
        public byte[] GenerarHash(string password, byte[] salt)
        {
            byte[] datos = [.. salt, .. Encoding.UTF8.GetBytes(password)];
            return SHA512.HashData(datos);
        }

        /// <inheritdoc />
        public bool Verificar(string password, byte[] hashGuardado, byte[] salt)
        {
            var hashCalculado = GenerarHash(password, salt);
            // Comparación en tiempo constante para evitar ataques de temporización
            return CryptographicOperations.FixedTimeEquals(hashCalculado, hashGuardado);
        }
    }
}
