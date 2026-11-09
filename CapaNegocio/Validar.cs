using System.Text.RegularExpressions;

namespace CapaNegocio
{
    /// <summary>Validaciones de formato reutilizadas por las clases de negocio.</summary>
    public static partial class Validar
    {
        /// <summary>Longitud mínima permitida para una contraseña.</summary>
        public const int LongitudMinimaPassword = 6;

        /// <summary>Devuelve un mensaje de error si la contraseña no es válida, o <c>null</c>.</summary>
        public static string? Password(string password, string confirmacion)
        {
            if (string.IsNullOrEmpty(password))
                return "Ingrese la contraseña.";
            if (password.Length < LongitudMinimaPassword)
                return $"La contraseña debe tener al menos {LongitudMinimaPassword} caracteres.";
            if (password != confirmacion)
                return "Las contraseñas no coinciden.";
            return null;
        }

        /// <summary>true si el correo está vacío (opcional) o tiene un formato válido.</summary>
        public static bool CorreoOpcional(string? correo) =>
            string.IsNullOrWhiteSpace(correo) || RegexCorreo().IsMatch(correo.Trim());

        [GeneratedRegex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")]
        private static partial Regex RegexCorreo();
    }
}
