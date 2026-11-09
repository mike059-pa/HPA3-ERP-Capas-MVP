#nullable disable
namespace CapaPresentacion;

partial class FrmClientes
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
        txtDireccion = new TextBox();
        lblDireccion = new Label();
        txtCorreo = new TextBox();
        lblCorreo = new Label();
        txtTelefono = new TextBox();
        lblTelefono = new Label();
        txtCedula = new TextBox();
        lblCedula = new Label();
        txtNombre = new TextBox();
        lblNombre = new Label();
        lblEditor = new Label();
        gridDatos = new DataGridView();
        panelSuperior.SuspendLayout();
        panelEditor.SuspendLayout();
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
        txtBuscar.PlaceholderText = "Buscar por nombre o cédula...";
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
        lblTitulo.Size = new Size(98, 30);
        lblTitulo.TabIndex = 0;
        lblTitulo.Text = "Clientes";
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
        panelEditor.Controls.Add(txtDireccion);
        panelEditor.Controls.Add(lblDireccion);
        panelEditor.Controls.Add(txtCorreo);
        panelEditor.Controls.Add(lblCorreo);
        panelEditor.Controls.Add(txtTelefono);
        panelEditor.Controls.Add(lblTelefono);
        panelEditor.Controls.Add(txtCedula);
        panelEditor.Controls.Add(lblCedula);
        panelEditor.Controls.Add(txtNombre);
        panelEditor.Controls.Add(lblNombre);
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
        lblMensaje.Location = new Point(20, 365);
        lblMensaje.Name = "lblMensaje";
        lblMensaje.Size = new Size(280, 60);
        lblMensaje.TabIndex = 15;
        //
        // btnEliminar
        //
        btnEliminar.Location = new Point(216, 320);
        btnEliminar.Name = "btnEliminar";
        btnEliminar.Size = new Size(84, 34);
        btnEliminar.TabIndex = 14;
        btnEliminar.Text = "Eliminar";
        btnEliminar.Click += btnEliminar_Click;
        //
        // btnGuardar
        //
        btnGuardar.Location = new Point(113, 320);
        btnGuardar.Name = "btnGuardar";
        btnGuardar.Size = new Size(95, 34);
        btnGuardar.TabIndex = 13;
        btnGuardar.Text = "Guardar";
        btnGuardar.Click += btnGuardar_Click;
        //
        // btnNuevo
        //
        btnNuevo.Location = new Point(20, 320);
        btnNuevo.Name = "btnNuevo";
        btnNuevo.Size = new Size(85, 34);
        btnNuevo.TabIndex = 12;
        btnNuevo.Text = "Nuevo";
        btnNuevo.Click += btnNuevo_Click;
        //
        // chkActivo
        //
        chkActivo.AutoSize = true;
        chkActivo.Location = new Point(20, 285);
        chkActivo.Name = "chkActivo";
        chkActivo.Size = new Size(60, 19);
        chkActivo.TabIndex = 11;
        chkActivo.Text = "Activo";
        //
        // txtDireccion
        //
        txtDireccion.Font = new Font("Segoe UI", 10F);
        txtDireccion.Location = new Point(20, 218);
        txtDireccion.MaxLength = 200;
        txtDireccion.Multiline = true;
        txtDireccion.Name = "txtDireccion";
        txtDireccion.Size = new Size(280, 55);
        txtDireccion.TabIndex = 10;
        //
        // lblDireccion
        //
        lblDireccion.AutoSize = true;
        lblDireccion.Location = new Point(20, 200);
        lblDireccion.Name = "lblDireccion";
        lblDireccion.Size = new Size(57, 15);
        lblDireccion.TabIndex = 9;
        lblDireccion.Text = "Dirección";
        //
        // txtCorreo
        //
        txtCorreo.Font = new Font("Segoe UI", 10F);
        txtCorreo.Location = new Point(20, 168);
        txtCorreo.MaxLength = 100;
        txtCorreo.Name = "txtCorreo";
        txtCorreo.Size = new Size(280, 25);
        txtCorreo.TabIndex = 8;
        //
        // lblCorreo
        //
        lblCorreo.AutoSize = true;
        lblCorreo.Location = new Point(20, 150);
        lblCorreo.Name = "lblCorreo";
        lblCorreo.Size = new Size(43, 15);
        lblCorreo.TabIndex = 7;
        lblCorreo.Text = "Correo";
        //
        // txtTelefono
        //
        txtTelefono.Font = new Font("Segoe UI", 10F);
        txtTelefono.Location = new Point(170, 118);
        txtTelefono.MaxLength = 20;
        txtTelefono.Name = "txtTelefono";
        txtTelefono.Size = new Size(130, 25);
        txtTelefono.TabIndex = 6;
        //
        // lblTelefono
        //
        lblTelefono.AutoSize = true;
        lblTelefono.Location = new Point(170, 100);
        lblTelefono.Name = "lblTelefono";
        lblTelefono.Size = new Size(52, 15);
        lblTelefono.TabIndex = 5;
        lblTelefono.Text = "Teléfono";
        //
        // txtCedula
        //
        txtCedula.Font = new Font("Segoe UI", 10F);
        txtCedula.Location = new Point(20, 118);
        txtCedula.MaxLength = 20;
        txtCedula.Name = "txtCedula";
        txtCedula.Size = new Size(130, 25);
        txtCedula.TabIndex = 4;
        //
        // lblCedula
        //
        lblCedula.AutoSize = true;
        lblCedula.Location = new Point(20, 100);
        lblCedula.Name = "lblCedula";
        lblCedula.Size = new Size(77, 15);
        lblCedula.TabIndex = 3;
        lblCedula.Text = "Cédula / RUC";
        //
        // txtNombre
        //
        txtNombre.Font = new Font("Segoe UI", 10F);
        txtNombre.Location = new Point(20, 68);
        txtNombre.MaxLength = 100;
        txtNombre.Name = "txtNombre";
        txtNombre.Size = new Size(280, 25);
        txtNombre.TabIndex = 2;
        //
        // lblNombre
        //
        lblNombre.AutoSize = true;
        lblNombre.Location = new Point(20, 50);
        lblNombre.Name = "lblNombre";
        lblNombre.Size = new Size(51, 15);
        lblNombre.TabIndex = 1;
        lblNombre.Text = "Nombre";
        //
        // lblEditor
        //
        lblEditor.AutoSize = true;
        lblEditor.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblEditor.ForeColor = Color.FromArgb(108, 92, 231);
        lblEditor.Location = new Point(20, 15);
        lblEditor.Name = "lblEditor";
        lblEditor.Size = new Size(113, 21);
        lblEditor.TabIndex = 0;
        lblEditor.Text = "Nuevo cliente";
        //
        // gridDatos
        //
        gridDatos.Dock = DockStyle.Fill;
        gridDatos.Location = new Point(15, 70);
        gridDatos.Name = "gridDatos";
        gridDatos.Size = new Size(620, 565);
        gridDatos.TabIndex = 1;
        gridDatos.SelectionChanged += gridDatos_SelectionChanged;
        //
        // FrmClientes
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(240, 242, 245);
        ClientSize = new Size(970, 650);
        Controls.Add(gridDatos);
        Controls.Add(panelEditor);
        Controls.Add(panelSuperior);
        FormBorderStyle = FormBorderStyle.None;
        Name = "FrmClientes";
        Padding = new Padding(15);
        Text = "Clientes";
        Load += FrmClientes_Load;
        panelSuperior.ResumeLayout(false);
        panelSuperior.PerformLayout();
        panelEditor.ResumeLayout(false);
        panelEditor.PerformLayout();
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
    private TextBox txtDireccion;
    private Label lblDireccion;
    private TextBox txtCorreo;
    private Label lblCorreo;
    private TextBox txtTelefono;
    private Label lblTelefono;
    private TextBox txtCedula;
    private Label lblCedula;
    private TextBox txtNombre;
    private Label lblNombre;
    private Label lblEditor;
    private DataGridView gridDatos;
}
