namespace CapaNegocio.Contratos
{
    /// <summary>
    /// Contrato cuya única responsabilidad es GENERAR el hash de una contraseña.
    /// Se usa cuando el usuario se registra o cambia su contraseña.
    /// </summary>
    public interface IHashService
    {
        /// <summary>Genera un salt aleatorio criptográficamente seguro.</summary>
        byte[] GenerarSalt();

        /// <summary>Genera el hash de la contraseña en texto plano combinada con el salt.</summary>
        /// <param name="password">Contraseña en texto plano.</param>
        /// <param name="salt">Salt del usuario.</param>
        byte[] GenerarHash(string password, byte[] salt);
    }
}
