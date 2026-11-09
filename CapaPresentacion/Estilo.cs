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
    public static readonly Color AcentoClaro = Color.FromArgb(225, 221, 252);
    public static readonly Color TextoClaro = Color.Gainsboro;
    public static readonly Color TextoOscuro = Color.FromArgb(45, 52, 54);
    public static readonly Color Error = Color.FromArgb(214, 48, 49);
    public static readonly Color Exito = Color.FromArgb(0, 148, 50);
    public static readonly Color Gris = Color.FromArgb(99, 110, 114);

    /// <summary>Colores para los números de las tarjetas del dashboard.</summary>
    public static readonly Color[] ColoresTarjeta =
    [
        Color.FromArgb(108, 92, 231), Color.FromArgb(9, 132, 227), Color.FromArgb(0, 148, 50),
        Color.FromArgb(225, 112, 85), Color.FromArgb(214, 48, 49), Color.FromArgb(253, 150, 68),
        Color.FromArgb(0, 184, 148)
    ];

    // Glifos de la fuente "Segoe MDL2 Assets" (incluida en Windows 10/11)
    public const string IconoMenu = "";
    public const string IconoInicio = "";
    public const string IconoUsuarios = "";
    public const string IconoAgregarUsuario = "";
    public const string IconoProductos = "";
    public const string IconoClientes = "";
    public const string IconoVentas = "";
    public const string IconoComprar = "";
    public const string IconoMisCompras = "";
    public const string IconoReportes = "";
    public const string IconoPerfil = "";
    public const string IconoCerrarSesion = "";
    public const string IconoUsuario = "";
    public const string IconoAlerta = "";
    public const string IconoDinero = "";
    public const string IconoCalendario = "";

    /// <summary>Dibuja un glifo de Segoe MDL2 Assets como imagen para usar en botones y etiquetas.</summary>
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

    /// <summary>Aplica el estilo plano del sistema a un DataGridView de solo lectura.</summary>
    public static void EstilizarGrid(DataGridView grid)
    {
        grid.AllowUserToAddRows = false;
        grid.AllowUserToDeleteRows = false;
        grid.AllowUserToResizeRows = false;
        grid.ReadOnly = true;
        grid.MultiSelect = false;
        grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        grid.RowHeadersVisible = false;
        grid.BorderStyle = BorderStyle.None;
        grid.BackgroundColor = Color.White;
        grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
        grid.GridColor = Color.FromArgb(230, 230, 235);
        grid.EnableHeadersVisualStyles = false;
        grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        grid.ColumnHeadersHeight = 34;
        grid.ColumnHeadersDefaultCellStyle.BackColor = BarraTitulo;
        grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        grid.ColumnHeadersDefaultCellStyle.SelectionBackColor = BarraTitulo;
        grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        grid.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
        grid.DefaultCellStyle.SelectionBackColor = Acento;
        grid.DefaultCellStyle.SelectionForeColor = Color.White;
        grid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(248, 248, 252);
        grid.RowTemplate.Height = 28;
        grid.DataBindingComplete += (_, _) =>
        {
            AjustarAnchos(grid);
            grid.ClearSelection();   // que no aparezca una fila seleccionada sin que el usuario la elija
        };
    }

    private static readonly HashSet<string> ColumnasAngostas =
        ["ID", "N_º", "Activo", "Stock", "Mínimo"];

    private static readonly HashSet<string> ColumnasAnchas =
        ["Producto", "Nombre", "Correo", "Cliente", "Vendedor", "Descripción"];

    /// <summary>Da más ancho a las columnas de texto largo y menos a las numéricas.</summary>
    private static void AjustarAnchos(DataGridView grid)
    {
        foreach (DataGridViewColumn columna in grid.Columns)
        {
            if (ColumnasAngostas.Contains(columna.Name))
                columna.FillWeight = 55;
            else if (ColumnasAnchas.Contains(columna.Name))
                columna.FillWeight = 190;
        }
    }

    /// <summary>Alinea a la derecha las columnas numéricas o de montos de un grid enlazado.</summary>
    public static void AlinearDerecha(DataGridView grid, params string[] columnas)
    {
        foreach (var nombre in columnas)
            if (grid.Columns[nombre] is { } columna)
                columna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
    }

    /// <summary>Botón plano relleno con el color de acento.</summary>
    public static void BotonPrimario(Button boton) => BotonPlano(boton, Acento, Color.White);

    /// <summary>Botón plano gris para acciones secundarias.</summary>
    public static void BotonSecundario(Button boton) => BotonPlano(boton, Color.FromArgb(223, 230, 233), TextoOscuro);

    /// <summary>Botón plano rojo para acciones destructivas.</summary>
    public static void BotonPeligro(Button boton) => BotonPlano(boton, Error, Color.White);

    private static void BotonPlano(Button boton, Color fondo, Color texto)
    {
        boton.FlatStyle = FlatStyle.Flat;
        boton.FlatAppearance.BorderSize = 0;
        boton.BackColor = fondo;
        boton.ForeColor = texto;
        boton.Cursor = Cursors.Hand;
        boton.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
        boton.UseVisualStyleBackColor = false;
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
