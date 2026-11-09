namespace CapaNegocio.Contratos
{
    /// <summary>
    /// Contrato cuya única responsabilidad es VERIFICAR si una contraseña en texto plano
    /// coincide con el hash almacenado. Se usa cuando el usuario intenta iniciar sesión.
    /// </summary>
    public interface IVerificarHashService
    {
        /// <summary>Verifica la contraseña contra el hash guardado.</summary>
        /// <param name="password">Contraseña en texto plano ingresada por el usuario.</param>
        /// <param name="hashGuardado">Hash almacenado en la base de datos.</param>
        /// <param name="salt">Salt almacenado en la base de datos.</param>
        /// <returns><c>true</c> si la contraseña es correcta.</returns>
        bool Verificar(string password, byte[] hashGuardado, byte[] salt);
    }
}
