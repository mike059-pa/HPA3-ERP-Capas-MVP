namespace CapaPresentacion.Vistas;

/// <summary>Contrato de la Vista de auto‑registro de clientes (MVP).</summary>
public interface IVistaRegistro
{
    /// <summary>Nombre de usuario a registrar.</summary>
    string Usuario { get; }

    /// <summary>Nombre completo de la persona.</summary>
    string Nombre { get; }

    /// <summary>Correo electrónico (opcional).</summary>
    string Correo { get; }

    /// <summary>Teléfono (opcional).</summary>
    string Telefono { get; }

    /// <summary>Contraseña en texto plano.</summary>
    string Password { get; }

    /// <summary>Confirmación de la contraseña.</summary>
    string Confirmacion { get; }

    /// <summary>Se dispara cuando el usuario presiona "Crear cuenta".</summary>
    event EventHandler Registrar;

    /// <summary>Muestra el resultado de la operación.</summary>
    /// <param name="mensaje">Texto a mostrar.</param>
    /// <param name="exito">true para estilo de éxito, false para error.</param>
    void MostrarMensaje(string mensaje, bool exito);

    /// <summary>Limpia los campos del formulario.</summary>
    void Limpiar();
}
