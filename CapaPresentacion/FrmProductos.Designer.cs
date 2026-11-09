#nullable disable
namespace CapaPresentacion;

partial class FrmProductos
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        panelSuperior = new Panel();
        btnBuscar = new Button();
        txtBuscar = new TextBox();
        lblTitulo = new Label();
        panelEditor = new Panel();
        lblMensaje = new Label();
        btnEliminar = new Button();
        btnGuardar = new Button();
        btnNuevo = new Button();
        chkActivo = new CheckBox();
        nudStockMinimo = new NumericUpDown();
        lblStockMinimo = new Label();
        nudStock = new NumericUpDown();
        lblStock = new Label();
        nudPrecio = new NumericUpDown();
        lblPrecio = new Label();
        txtDescripcion = new TextBox();
        lblDescripcion = new Label();
        txtNombre = new TextBox();
        lblNombre = new Label();
        txtCodigo = new TextBox();
        lblCodigo = new Label();
        lblEditor = new Label();
        gridDatos = new DataGridView();
        panelSuperior.SuspendLayout();
        panelEditor.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)nudStockMinimo).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudStock).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudPrecio).BeginInit();
        ((System.ComponentModel.ISupportInitialize)gridDatos).BeginInit();
        SuspendLayout();
        //
        // panelSuperior
        //
        panelSuperior.Controls.Add(btnBuscar);
        panelSuperior.Controls.Add(txtBuscar);
        panelSuperior.Controls.Add(lblTitulo);
        panelSuperior.Dock = DockStyle.Top;
        panelSuperior.Location = new Point(15, 15);
        panelSuperior.Name = "panelSuperior";
        panelSuperior.Size = new Size(940, 55);
        panelSuperior.TabIndex = 0;
        //
        // btnBuscar
        //
        btnBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnBuscar.Location = new Point(830, 10);
        btnBuscar.Name = "btnBuscar";
        btnBuscar.Size = new Size(100, 30);
        btnBuscar.TabIndex = 2;
        btnBuscar.Text = "Buscar";
        btnBuscar.Click += btnBuscar_Click;
        //
        // txtBuscar
        //
        txtBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        txtBuscar.Font = new Font("Segoe UI", 10.5F);
        txtBuscar.Location = new Point(560, 12);
        txtBuscar.Name = "txtBuscar";
        txtBuscar.PlaceholderText = "Buscar por código o nombre...";
        txtBuscar.Size = new Size(260, 26);
        txtBuscar.TabIndex = 1;
        txtBuscar.KeyDown += txtBuscar_KeyDown;
        //
        // lblTitulo
        //
        lblTitulo.AutoSize = true;
        lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblTitulo.ForeColor = Color.FromArgb(30, 30, 45);
        lblTitulo.Location = new Point(0, 8);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Size = new Size(118, 30);
        lblTitulo.TabIndex = 0;
        lblTitulo.Text = "Productos";
        //
        // panelEditor
        //
        panelEditor.AutoScroll = true;
        panelEditor.BackColor = Color.White;
        panelEditor.Controls.Add(lblMensaje);
        panelEditor.Controls.Add(btnEliminar);
        panelEditor.Controls.Add(btnGuardar);
        panelEditor.Controls.Add(btnNuevo);
        panelEditor.Controls.Add(chkActivo);
        panelEditor.Controls.Add(nudStockMinimo);
        panelEditor.Controls.Add(lblStockMinimo);
        panelEditor.Controls.Add(nudStock);
        panelEditor.Controls.Add(lblStock);
        panelEditor.Controls.Add(nudPrecio);
        panelEditor.Controls.Add(lblPrecio);
        panelEditor.Controls.Add(txtDescripcion);
        panelEditor.Controls.Add(lblDescripcion);
        panelEditor.Controls.Add(txtNombre);
        panelEditor.Controls.Add(lblNombre);
        panelEditor.Controls.Add(txtCodigo);
        panelEditor.Controls.Add(lblCodigo);
        panelEditor.Controls.Add(lblEditor);
        panelEditor.Dock = DockStyle.Right;
        panelEditor.Location = new Point(635, 70);
        panelEditor.Name = "panelEditor";
        panelEditor.Size = new Size(320, 565);
        panelEditor.TabIndex = 2;
        //
        // lblMensaje
        //
        lblMensaje.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblMensaje.Location = new Point(20, 415);
        lblMensaje.Name = "lblMensaje";
        lblMensaje.Size = new Size(280, 60);
        lblMensaje.TabIndex = 17;
        //
        // btnEliminar
        //
        btnEliminar.Location = new Point(216, 370);
        btnEliminar.Name = "btnEliminar";
        btnEliminar.Size = new Size(84, 34);
        btnEliminar.TabIndex = 16;
        btnEliminar.Text = "Eliminar";
        btnEliminar.Click += btnEliminar_Click;
        //
        // btnGuardar
        //
        btnGuardar.Location = new Point(113, 370);
        btnGuardar.Name = "btnGuardar";
        btnGuardar.Size = new Size(95, 34);
        btnGuardar.TabIndex = 15;
        btnGuardar.Text = "Guardar";
        btnGuardar.Click += btnGuardar_Click;
        //
        // btnNuevo
        //
        btnNuevo.Location = new Point(20, 370);
        btnNuevo.Name = "btnNuevo";
        btnNuevo.Size = new Size(85, 34);
        btnNuevo.TabIndex = 14;
        btnNuevo.Text = "Nuevo";
        btnNuevo.Click += btnNuevo_Click;
        //
        // chkActivo
        //
        chkActivo.AutoSize = true;
        chkActivo.Location = new Point(20, 334);
        chkActivo.Name = "chkActivo";
        chkActivo.Size = new Size(60, 19);
        chkActivo.TabIndex = 13;
        chkActivo.Text = "Activo";
        //
        // nudStockMinimo
        //
        nudStockMinimo.Font = new Font("Segoe UI", 10F);
        nudStockMinimo.Location = new Point(170, 296);
        nudStockMinimo.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
        nudStockMinimo.Name = "nudStockMinimo";
        nudStockMinimo.Size = new Size(130, 25);
        nudStockMinimo.TabIndex = 12;
        //
        // lblStockMinimo
        //
        lblStockMinimo.AutoSize = true;
        lblStockMinimo.Location = new Point(170, 278);
        lblStockMinimo.Name = "lblStockMinimo";
        lblStockMinimo.Size = new Size(80, 15);
        lblStockMinimo.TabIndex = 11;
        lblStockMinimo.Text = "Stock mínimo";
        //
        // nudStock
        //
        nudStock.Font = new Font("Segoe UI", 10F);
        nudStock.Location = new Point(20, 296);
        nudStock.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
        nudStock.Name = "nudStock";
        nudStock.Size = new Size(130, 25);
        nudStock.TabIndex = 10;
        //
        // lblStock
        //
        lblStock.AutoSize = true;
        lblStock.Location = new Point(20, 278);
        lblStock.Name = "lblStock";
        lblStock.Size = new Size(36, 15);
        lblStock.TabIndex = 9;
        lblStock.Text = "Stock";
        //
        // nudPrecio
        //
        nudPrecio.DecimalPlaces = 2;
        nudPrecio.Font = new Font("Segoe UI", 10F);
        nudPrecio.Increment = new decimal(new int[] { 50, 0, 0, 131072 });
        nudPrecio.Location = new Point(20, 246);
        nudPrecio.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
        nudPrecio.Name = "nudPrecio";
        nudPrecio.Size = new Size(280, 25);
        nudPrecio.TabIndex = 8;
        nudPrecio.ThousandsSeparator = true;
        //
        // lblPrecio
        //
        lblPrecio.AutoSize = true;
        lblPrecio.Location = new Point(20, 228);
        lblPrecio.Name = "lblPrecio";
        lblPrecio.Size = new Size(84, 15);
        lblPrecio.TabIndex = 7;
        lblPrecio.Text = "Precio (USD $)";
        //
        // txtDescripcion
        //
        txtDescripcion.Font = new Font("Segoe UI", 10F);
        txtDescripcion.Location = new Point(20, 168);
        txtDescripcion.MaxLength = 250;
        txtDescripcion.Multiline = true;
        txtDescripcion.Name = "txtDescripcion";
        txtDescripcion.Size = new Size(280, 50);
        txtDescripcion.TabIndex = 6;
        //
        // lblDescripcion
        //
        lblDescripcion.AutoSize = true;
        lblDescripcion.Location = new Point(20, 150);
        lblDescripcion.Name = "lblDescripcion";
        lblDescripcion.Size = new Size(69, 15);
        lblDescripcion.TabIndex = 5;
        lblDescripcion.Text = "Descripción";
        //
        // txtNombre
        //
        txtNombre.Font = new Font("Segoe UI", 10F);
        txtNombre.Location = new Point(20, 118);
        txtNombre.MaxLength = 100;
        txtNombre.Name = "txtNombre";
        txtNombre.Size = new Size(280, 25);
        txtNombre.TabIndex = 4;
        //
        // lblNombre
        //
        lblNombre.AutoSize = true;
        lblNombre.Location = new Point(20, 100);
        lblNombre.Name = "lblNombre";
        lblNombre.Size = new Size(51, 15);
        lblNombre.TabIndex = 3;
        lblNombre.Text = "Nombre";
        //
        // txtCodigo
        //
        txtCodigo.CharacterCasing = CharacterCasing.Upper;
        txtCodigo.Font = new Font("Segoe UI", 10F);
        txtCodigo.Location = new Point(20, 68);
        txtCodigo.MaxLength = 20;
        txtCodigo.Name = "txtCodigo";
        txtCodigo.Size = new Size(280, 25);
        txtCodigo.TabIndex = 2;
        //
        // lblCodigo
        //
        lblCodigo.AutoSize = true;
        lblCodigo.Location = new Point(20, 50);
        lblCodigo.Name = "lblCodigo";
        lblCodigo.Size = new Size(46, 15);
        lblCodigo.TabIndex = 1;
        lblCodigo.Text = "Código";
        //
        // lblEditor
        //
        lblEditor.AutoSize = true;
        lblEditor.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblEditor.ForeColor = Color.FromArgb(108, 92, 231);
        lblEditor.Location = new Point(20, 15);
        lblEditor.Name = "lblEditor";
        lblEditor.Size = new Size(131, 21);
        lblEditor.TabIndex = 0;
        lblEditor.Text = "Nuevo producto";
        //
        // gridDatos
        //
        gridDatos.Dock = DockStyle.Fill;
        gridDatos.Location = new Point(15, 70);
        gridDatos.Name = "gridDatos";
        gridDatos.Size = new Size(620, 565);
        gridDatos.TabIndex = 1;
        gridDatos.CellFormatting += gridDatos_CellFormatting;
        gridDatos.SelectionChanged += gridDatos_SelectionChanged;
        //
        // FrmProductos
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(240, 242, 245);
        ClientSize = new Size(970, 650);
        Controls.Add(gridDatos);
        Controls.Add(panelEditor);
        Controls.Add(panelSuperior);
        FormBorderStyle = FormBorderStyle.None;
        Name = "FrmProductos";
        Padding = new Padding(15);
        Text = "Productos";
        Load += FrmProductos_Load;
        panelSuperior.ResumeLayout(false);
        panelSuperior.PerformLayout();
        panelEditor.ResumeLayout(false);
        panelEditor.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)nudStockMinimo).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudStock).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudPrecio).EndInit();
        ((System.ComponentModel.ISupportInitialize)gridDatos).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private Panel panelSuperior;
    private Button btnBuscar;
    private TextBox txtBuscar;
    private Label lblTitulo;
    private Panel panelEditor;
    private Label lblMensaje;
    private Button btnEliminar;
    private Button btnGuardar;
    private Button btnNuevo;
    private CheckBox chkActivo;
    private NumericUpDown nudStockMinimo;
    private Label lblStockMinimo;
    private NumericUpDown nudStock;
    private Label lblStock;
    private NumericUpDown nudPrecio;
    private Label lblPrecio;
    private TextBox txtDescripcion;
    private Label lblDescripcion;
    private TextBox txtNombre;
    private Label lblNombre;
    private TextBox txtCodigo;
    private Label lblCodigo;
    private Label lblEditor;
    private DataGridView gridDatos;
}
