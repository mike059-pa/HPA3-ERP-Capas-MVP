#nullable disable
namespace CapaPresentacion;

partial class FrmVentas
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
        tabVentas = new TabControl();
        tabNueva = new TabPage();
        gridCarrito = new DataGridView();
        panelTotales = new Panel();
        btnRegistrar = new Button();
        lblTotal = new Label();
        lblItbms = new Label();
        lblSubtotal = new Label();
        btnLimpiar = new Button();
        btnQuitar = new Button();
        panelCabecera = new Panel();
        lblMensaje = new Label();
        btnAgregar = new Button();
        nudCantidad = new NumericUpDown();
        lblCantidad = new Label();
        lblInfoProducto = new Label();
        cboProducto = new ComboBox();
        lblProducto = new Label();
        lblClienteFijo = new Label();
        cboCliente = new ComboBox();
        lblCliente = new Label();
        tabHistorial = new TabPage();
        gridVentas = new DataGridView();
        panelDetalle = new Panel();
        gridDetalle = new DataGridView();
        lblDetalle = new Label();
        panelFiltro = new Panel();
        lblTotalPeriodo = new Label();
        lblMensajeHistorial = new Label();
        btnFiltrar = new Button();
        dtpHasta = new DateTimePicker();
        lblHasta = new Label();
        dtpDesde = new DateTimePicker();
        lblDesde = new Label();
        tabVentas.SuspendLayout();
        tabNueva.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridCarrito).BeginInit();
        panelTotales.SuspendLayout();
        panelCabecera.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)nudCantidad).BeginInit();
        tabHistorial.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridVentas).BeginInit();
        panelDetalle.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridDetalle).BeginInit();
        panelFiltro.SuspendLayout();
        SuspendLayout();
        //
        // tabVentas
        //
        tabVentas.Controls.Add(tabNueva);
        tabVentas.Controls.Add(tabHistorial);
        tabVentas.Dock = DockStyle.Fill;
        tabVentas.Font = new Font("Segoe UI", 10F);
        tabVentas.Location = new Point(15, 15);
        tabVentas.Name = "tabVentas";
        tabVentas.Padding = new Point(14, 6);
        tabVentas.SelectedIndex = 0;
        tabVentas.Size = new Size(940, 620);
        tabVentas.TabIndex = 0;
        //
        // tabNueva
        //
        tabNueva.BackColor = Color.FromArgb(240, 242, 245);
        tabNueva.Controls.Add(gridCarrito);
        tabNueva.Controls.Add(panelTotales);
        tabNueva.Controls.Add(panelCabecera);
        tabNueva.Location = new Point(4, 34);
        tabNueva.Name = "tabNueva";
        tabNueva.Padding = new Padding(8);
        tabNueva.Size = new Size(932, 582);
        tabNueva.TabIndex = 0;
        tabNueva.Text = "Nueva venta";
        //
        // gridCarrito
        //
        gridCarrito.Dock = DockStyle.Fill;
        gridCarrito.Location = new Point(8, 128);
        gridCarrito.Name = "gridCarrito";
        gridCarrito.Size = new Size(916, 376);
        gridCarrito.TabIndex = 1;
        //
        // panelTotales
        //
        panelTotales.BackColor = Color.White;
        panelTotales.Controls.Add(btnRegistrar);
        panelTotales.Controls.Add(lblTotal);
        panelTotales.Controls.Add(lblItbms);
        panelTotales.Controls.Add(lblSubtotal);
        panelTotales.Controls.Add(btnLimpiar);
        panelTotales.Controls.Add(btnQuitar);
        panelTotales.Dock = DockStyle.Bottom;
        panelTotales.Location = new Point(8, 504);
        panelTotales.Name = "panelTotales";
        panelTotales.Size = new Size(916, 70);
        panelTotales.TabIndex = 2;
        //
        // btnRegistrar
        //
        btnRegistrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnRegistrar.Location = new Point(756, 15);
        btnRegistrar.Name = "btnRegistrar";
        btnRegistrar.Size = new Size(150, 40);
        btnRegistrar.TabIndex = 5;
        btnRegistrar.Text = "Registrar venta";
        btnRegistrar.Click += btnRegistrar_Click;
        //
        // lblTotal
        //
        lblTotal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblTotal.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
        lblTotal.ForeColor = Color.FromArgb(108, 92, 231);
        lblTotal.Location = new Point(536, 18);
        lblTotal.Name = "lblTotal";
        lblTotal.Size = new Size(210, 32);
        lblTotal.TabIndex = 4;
        lblTotal.Text = "Total: $0.00";
        lblTotal.TextAlign = ContentAlignment.MiddleRight;
        //
        // lblItbms
        //
        lblItbms.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblItbms.Font = new Font("Segoe UI", 9F);
        lblItbms.Location = new Point(346, 36);
        lblItbms.Name = "lblItbms";
        lblItbms.Size = new Size(180, 20);
        lblItbms.TabIndex = 3;
        lblItbms.Text = "ITBMS (7 %): $0.00";
        lblItbms.TextAlign = ContentAlignment.MiddleRight;
        //
        // lblSubtotal
        //
        lblSubtotal.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblSubtotal.Font = new Font("Segoe UI", 9F);
        lblSubtotal.Location = new Point(346, 14);
        lblSubtotal.Name = "lblSubtotal";
        lblSubtotal.Size = new Size(180, 20);
        lblSubtotal.TabIndex = 2;
        lblSubtotal.Text = "Subtotal: $0.00";
        lblSubtotal.TextAlign = ContentAlignment.MiddleRight;
        //
        // btnLimpiar
        //
        btnLimpiar.Location = new Point(135, 18);
        btnLimpiar.Name = "btnLimpiar";
        btnLimpiar.Size = new Size(110, 34);
        btnLimpiar.TabIndex = 1;
        btnLimpiar.Text = "Vaciar carrito";
        btnLimpiar.Click += btnLimpiar_Click;
        //
        // btnQuitar
        //
        btnQuitar.Location = new Point(15, 18);
        btnQuitar.Name = "btnQuitar";
        btnQuitar.Size = new Size(110, 34);
        btnQuitar.TabIndex = 0;
        btnQuitar.Text = "Quitar línea";
        btnQuitar.Click += btnQuitar_Click;
        //
        // panelCabecera
        //
        panelCabecera.BackColor = Color.White;
        panelCabecera.Controls.Add(lblMensaje);
        panelCabecera.Controls.Add(btnAgregar);
        panelCabecera.Controls.Add(nudCantidad);
        panelCabecera.Controls.Add(lblCantidad);
        panelCabecera.Controls.Add(lblInfoProducto);
        panelCabecera.Controls.Add(cboProducto);
        panelCabecera.Controls.Add(lblProducto);
        panelCabecera.Controls.Add(lblClienteFijo);
        panelCabecera.Controls.Add(cboCliente);
        panelCabecera.Controls.Add(lblCliente);
        panelCabecera.Dock = DockStyle.Top;
        panelCabecera.Location = new Point(8, 8);
        panelCabecera.Name = "panelCabecera";
        panelCabecera.Size = new Size(916, 120);
        panelCabecera.TabIndex = 0;
        //
        // lblMensaje
        //
        lblMensaje.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblMensaje.Location = new Point(15, 88);
        lblMensaje.Name = "lblMensaje";
        lblMensaje.Size = new Size(880, 22);
        lblMensaje.TabIndex = 9;
        //
        // btnAgregar
        //
        btnAgregar.Location = new Point(775, 30);
        btnAgregar.Name = "btnAgregar";
        btnAgregar.Size = new Size(120, 30);
        btnAgregar.TabIndex = 8;
        btnAgregar.Text = "Agregar";
        btnAgregar.Click += btnAgregar_Click;
        //
        // nudCantidad
        //
        nudCantidad.Location = new Point(685, 32);
        nudCantidad.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
        nudCantidad.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        nudCantidad.Name = "nudCantidad";
        nudCantidad.Size = new Size(80, 25);
        nudCantidad.TabIndex = 7;
        nudCantidad.Value = new decimal(new int[] { 1, 0, 0, 0 });
        //
        // lblCantidad
        //
        lblCantidad.AutoSize = true;
        lblCantidad.Font = new Font("Segoe UI", 9F);
        lblCantidad.Location = new Point(685, 12);
        lblCantidad.Name = "lblCantidad";
        lblCantidad.Size = new Size(55, 15);
        lblCantidad.TabIndex = 6;
        lblCantidad.Text = "Cantidad";
        //
        // lblInfoProducto
        //
        lblInfoProducto.Font = new Font("Segoe UI", 9F);
        lblInfoProducto.ForeColor = Color.Gray;
        lblInfoProducto.Location = new Point(335, 62);
        lblInfoProducto.Name = "lblInfoProducto";
        lblInfoProducto.Size = new Size(430, 20);
        lblInfoProducto.TabIndex = 5;
        //
        // cboProducto
        //
        cboProducto.DropDownStyle = ComboBoxStyle.DropDownList;
        cboProducto.Location = new Point(335, 32);
        cboProducto.Name = "cboProducto";
        cboProducto.Size = new Size(340, 25);
        cboProducto.TabIndex = 4;
        cboProducto.SelectedIndexChanged += cboProducto_SelectedIndexChanged;
        //
        // lblProducto
        //
        lblProducto.AutoSize = true;
        lblProducto.Font = new Font("Segoe UI", 9F);
        lblProducto.Location = new Point(335, 12);
        lblProducto.Name = "lblProducto";
        lblProducto.Size = new Size(56, 15);
        lblProducto.TabIndex = 3;
        lblProducto.Text = "Producto";
        //
        // lblClienteFijo
        //
        lblClienteFijo.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        lblClienteFijo.ForeColor = Color.FromArgb(108, 92, 231);
        lblClienteFijo.Location = new Point(15, 32);
        lblClienteFijo.Name = "lblClienteFijo";
        lblClienteFijo.Size = new Size(305, 25);
        lblClienteFijo.TabIndex = 2;
        lblClienteFijo.Visible = false;
        //
        // cboCliente
        //
        cboCliente.DropDownStyle = ComboBoxStyle.DropDownList;
        cboCliente.Location = new Point(15, 32);
        cboCliente.Name = "cboCliente";
        cboCliente.Size = new Size(305, 25);
        cboCliente.TabIndex = 1;
        //
        // lblCliente
        //
        lblCliente.AutoSize = true;
        lblCliente.Font = new Font("Segoe UI", 9F);
        lblCliente.Location = new Point(15, 12);
        lblCliente.Name = "lblCliente";
        lblCliente.Size = new Size(44, 15);
        lblCliente.TabIndex = 0;
        lblCliente.Text = "Cliente";
        //
        // tabHistorial
        //
        tabHistorial.BackColor = Color.FromArgb(240, 242, 245);
        tabHistorial.Controls.Add(gridVentas);
        tabHistorial.Controls.Add(panelDetalle);
        tabHistorial.Controls.Add(panelFiltro);
        tabHistorial.Location = new Point(4, 34);
        tabHistorial.Name = "tabHistorial";
        tabHistorial.Padding = new Padding(8);
        tabHistorial.Size = new Size(932, 582);
        tabHistorial.TabIndex = 1;
        tabHistorial.Text = "Historial";
        //
        // gridVentas
        //
        gridVentas.Dock = DockStyle.Fill;
        gridVentas.Location = new Point(8, 63);
        gridVentas.Name = "gridVentas";
        gridVentas.Size = new Size(916, 311);
        gridVentas.TabIndex = 1;
        gridVentas.SelectionChanged += gridVentas_SelectionChanged;
        //
        // panelDetalle
        //
        panelDetalle.Controls.Add(gridDetalle);
        panelDetalle.Controls.Add(lblDetalle);
        panelDetalle.Dock = DockStyle.Bottom;
        panelDetalle.Location = new Point(8, 374);
        panelDetalle.Name = "panelDetalle";
        panelDetalle.Size = new Size(916, 200);
        panelDetalle.TabIndex = 2;
        //
        // gridDetalle
        //
        gridDetalle.Dock = DockStyle.Fill;
        gridDetalle.Location = new Point(0, 30);
        gridDetalle.Name = "gridDetalle";
        gridDetalle.Size = new Size(916, 170);
        gridDetalle.TabIndex = 1;
        //
        // lblDetalle
        //
        lblDetalle.Dock = DockStyle.Top;
        lblDetalle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblDetalle.Location = new Point(0, 0);
        lblDetalle.Name = "lblDetalle";
        lblDetalle.Size = new Size(916, 30);
        lblDetalle.TabIndex = 0;
        lblDetalle.Text = "Detalle de la venta seleccionada";
        lblDetalle.TextAlign = ContentAlignment.MiddleLeft;
        //
        // panelFiltro
        //
        panelFiltro.BackColor = Color.White;
        panelFiltro.Controls.Add(lblTotalPeriodo);
        panelFiltro.Controls.Add(lblMensajeHistorial);
        panelFiltro.Controls.Add(btnFiltrar);
        panelFiltro.Controls.Add(dtpHasta);
        panelFiltro.Controls.Add(lblHasta);
        panelFiltro.Controls.Add(dtpDesde);
        panelFiltro.Controls.Add(lblDesde);
        panelFiltro.Dock = DockStyle.Top;
        panelFiltro.Location = new Point(8, 8);
        panelFiltro.Name = "panelFiltro";
        panelFiltro.Size = new Size(916, 55);
        panelFiltro.TabIndex = 0;
        //
        // lblTotalPeriodo
        //
        lblTotalPeriodo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblTotalPeriodo.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
        lblTotalPeriodo.ForeColor = Color.FromArgb(108, 92, 231);
        lblTotalPeriodo.Location = new Point(616, 15);
        lblTotalPeriodo.Name = "lblTotalPeriodo";
        lblTotalPeriodo.Size = new Size(290, 25);
        lblTotalPeriodo.TabIndex = 6;
        lblTotalPeriodo.TextAlign = ContentAlignment.MiddleRight;
        //
        // lblMensajeHistorial
        //
        lblMensajeHistorial.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        lblMensajeHistorial.Location = new Point(510, 18);
        lblMensajeHistorial.Name = "lblMensajeHistorial";
        lblMensajeHistorial.Size = new Size(100, 20);
        lblMensajeHistorial.TabIndex = 5;
        //
        // btnFiltrar
        //
        btnFiltrar.Location = new Point(400, 12);
        btnFiltrar.Name = "btnFiltrar";
        btnFiltrar.Size = new Size(100, 30);
        btnFiltrar.TabIndex = 4;
        btnFiltrar.Text = "Filtrar";
        btnFiltrar.Click += btnFiltrar_Click;
        //
        // dtpHasta
        //
        dtpHasta.Format = DateTimePickerFormat.Short;
        dtpHasta.Location = new Point(260, 14);
        dtpHasta.Name = "dtpHasta";
        dtpHasta.Size = new Size(125, 25);
        dtpHasta.TabIndex = 3;
        //
        // lblHasta
        //
        lblHasta.AutoSize = true;
        lblHasta.Font = new Font("Segoe UI", 9F);
        lblHasta.Location = new Point(215, 19);
        lblHasta.Name = "lblHasta";
        lblHasta.Size = new Size(37, 15);
        lblHasta.TabIndex = 2;
        lblHasta.Text = "Hasta";
        //
        // dtpDesde
        //
        dtpDesde.Format = DateTimePickerFormat.Short;
        dtpDesde.Location = new Point(70, 14);
        dtpDesde.Name = "dtpDesde";
        dtpDesde.Size = new Size(125, 25);
        dtpDesde.TabIndex = 1;
        //
        // lblDesde
        //
        lblDesde.AutoSize = true;
        lblDesde.Font = new Font("Segoe UI", 9F);
        lblDesde.Location = new Point(15, 19);
        lblDesde.Name = "lblDesde";
        lblDesde.Size = new Size(39, 15);
        lblDesde.TabIndex = 0;
        lblDesde.Text = "Desde";
        //
        // FrmVentas
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(240, 242, 245);
        ClientSize = new Size(970, 650);
        Controls.Add(tabVentas);
        FormBorderStyle = FormBorderStyle.None;
        Name = "FrmVentas";
        Padding = new Padding(15);
        Text = "Ventas";
        Load += FrmVentas_Load;
        tabVentas.ResumeLayout(false);
        tabNueva.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridCarrito).EndInit();
        panelTotales.ResumeLayout(false);
        panelCabecera.ResumeLayout(false);
        panelCabecera.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)nudCantidad).EndInit();
        tabHistorial.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridVentas).EndInit();
        panelDetalle.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridDetalle).EndInit();
        panelFiltro.ResumeLayout(false);
        panelFiltro.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private TabControl tabVentas;
    private TabPage tabNueva;
    private DataGridView gridCarrito;
    private Panel panelTotales;
    private Button btnRegistrar;
    private Label lblTotal;
    private Label lblItbms;
    private Label lblSubtotal;
    private Button btnLimpiar;
    private Button btnQuitar;
    private Panel panelCabecera;
    private Label lblMensaje;
    private Button btnAgregar;
    private NumericUpDown nudCantidad;
    private Label lblCantidad;
    private Label lblInfoProducto;
    private ComboBox cboProducto;
    private Label lblProducto;
    private Label lblClienteFijo;
    private ComboBox cboCliente;
    private Label lblCliente;
    private TabPage tabHistorial;
    private DataGridView gridVentas;
    private Panel panelDetalle;
    private DataGridView gridDetalle;
    private Label lblDetalle;
    private Panel panelFiltro;
    private Label lblTotalPeriodo;
    private Label lblMensajeHistorial;
    private Button btnFiltrar;
    private DateTimePicker dtpHasta;
    private Label lblHasta;
    private DateTimePicker dtpDesde;
    private Label lblDesde;
}
