using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.InteropServices;

namespace CapaPresentacion;

/// <summary>Colores, iconos y utilidades visuales compartidas por los formularios.</summary>
internal static class Estilo
{
    public static readonly Color FondoMenu = Color.FromArgb(30, 30, 45);
    public static readonly Color FondoMenuHover = Color.FromArgb(45, 45, 68);
    public static readonly Color BarraTitulo = Color.FromArgb(43, 43, 64);
    public static readonly Color FondoContenido = Color.FromArgb(240, 242, 245);
    public static readonly Color Acento = Color.FromArgb(108, 92, 231);
    public static readonly Color TextoClaro = Color.Gainsboro;
    public static readonly Color Error = Color.FromArgb(214, 48, 49);
    public static readonly Color Exito = Color.FromArgb(0, 148, 50);

    // Glifos de la fuente "Segoe MDL2 Assets" (incluida en Windows 10/11)
    public const string IconoMenu = "";
    public const string IconoInicio = "";
    public const string IconoAgregarUsuario = "";
    public const string IconoCerrarSesion = "";
    public const string IconoUsuario = "";

    /// <summary>Dibuja un glifo de Segoe MDL2 Assets como imagen para usar en botones.</summary>
    public static Bitmap CrearIcono(string glifo, Color color, int tamano = 20)
    {
        var bmp = new Bitmap(tamano + 4, tamano + 4);
        using var g = Graphics.FromImage(bmp);
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
        using var fuente = new Font("Segoe MDL2 Assets", tamano * 0.75f, GraphicsUnit.Point);
        using var pincel = new SolidBrush(color);
        var formato = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
        g.DrawString(glifo, fuente, pincel, new RectangleF(0, 0, bmp.Width, bmp.Height), formato);
        return bmp;
    }

    [DllImport("user32.dll")]
    private static extern bool ReleaseCapture();

    [DllImport("user32.dll")]
    private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

    /// <summary>Permite arrastrar un formulario sin bordes desde cualquier control.</summary>
    public static void ArrastrarFormulario(Form formulario)
    {
        const int WM_SYSCOMMAND = 0x112;
        const int SC_MOVE_ARRASTRE = 0xF012;
        ReleaseCapture();
        SendMessage(formulario.Handle, WM_SYSCOMMAND, SC_MOVE_ARRASTRE, 0);
    }
}
