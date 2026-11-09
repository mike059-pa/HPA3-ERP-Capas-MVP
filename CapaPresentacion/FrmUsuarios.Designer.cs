#nullable disable
namespace CapaPresentacion;

partial class FrmUsuarios
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
        lblAyudaPassword = new Label();
        txtConfirmacion = new TextBox();
        lblConfirmacion = new Label();
        txtPassword = new TextBox();
        lblPassword = new Label();
        chkActivo = new CheckBox();
        cboRol = new ComboBox();
        lblRol = new Label();
        txtTelefono = new TextBox();
        lblTelefono = new Label();
        txtCorreo = new TextBox();
        lblCorreo = new Label();
        txtNombre = new TextBox();
        lblNombre = new Label();
        txtUsuario = new TextBox();
        lblUsuario = new Label();
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
        txtBuscar.PlaceholderText = "Buscar por usuario o nombre...";
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
        lblTitulo.Size = new Size(104, 30);
        lblTitulo.TabIndex = 0;
        lblTitulo.Text = "Usuarios";
        //
        // panelEditor
        //
        panelEditor.AutoScroll = true;
        panelEditor.BackColor = Color.White;
        panelEditor.Controls.Add(lblMensaje);
        panelEditor.Controls.Add(btnEliminar);
        panelEditor.Controls.Add(btnGuardar);
        panelEditor.Controls.Add(btnNuevo);
        panelEditor.Controls.Add(lblAyudaPassword);
        panelEditor.Controls.Add(txtConfirmacion);
        panelEditor.Controls.Add(lblConfirmacion);
        panelEditor.Controls.Add(txtPassword);
        panelEditor.Controls.Add(lblPassword);
        panelEditor.Controls.Add(chkActivo);
        panelEditor.Controls.Add(cboRol);
        panelEditor.Controls.Add(lblRol);
        panelEditor.Controls.Add(txtTelefono);
        panelEditor.Controls.Add(lblTelefono);
        panelEditor.Controls.Add(txtCorreo);
        panelEditor.Controls.Add(lblCorreo);
        panelEditor.Controls.Add(txtNombre);
        panelEditor.Controls.Add(lblNombre);
        panelEditor.Controls.Add(txtUsuario);
        panelEditor.Controls.Add(lblUsuario);
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
        lblMensaje.Location = new Point(20, 500);
        lblMensaje.Name = "lblMensaje";
        lblMensaje.Size = new Size(280, 55);
        lblMensaje.TabIndex = 20;
        //
        // btnEliminar
        //
        btnEliminar.Location = new Point(216, 455);
        btnEliminar.Name = "btnEliminar";
        btnEliminar.Size = new Size(84, 34);
        btnEliminar.TabIndex = 19;
        btnEliminar.Text = "Eliminar";
        btnEliminar.Click += btnEliminar_Click;
        //
        // btnGuardar
        //
        btnGuardar.Location = new Point(113, 455);
        btnGuardar.Name = "btnGuardar";
        btnGuardar.Size = new Size(95, 34);
        btnGuardar.TabIndex = 18;
        btnGuardar.Text = "Guardar";
        btnGuardar.Click += btnGuardar_Click;
        //
        // btnNuevo
        //
        btnNuevo.Location = new Point(20, 455);
        btnNuevo.Name = "btnNuevo";
        btnNuevo.Size = new Size(85, 34);
        btnNuevo.TabIndex = 17;
        btnNuevo.Text = "Nuevo";
        btnNuevo.Click += btnNuevo_Click;
        //
        // lblAyudaPassword
        //
        lblAyudaPassword.Font = new Font("Segoe UI", 8.25F, FontStyle.Italic);
        lblAyudaPassword.ForeColor = Color.Gray;
        lblAyudaPassword.Location = new Point(20, 426);
        lblAyudaPassword.Name = "lblAyudaPassword";
        lblAyudaPassword.Size = new Size(280, 18);
        lblAyudaPassword.TabIndex = 16;
        //
        // txtConfirmacion
        //
        txtConfirmacion.Font = new Font("Segoe UI", 10F);
        txtConfirmacion.Location = new Point(20, 398);
        txtConfirmacion.MaxLength = 100;
        txtConfirmacion.Name = "txtConfirmacion";
        txtConfirmacion.Size = new Size(280, 25);
        txtConfirmacion.TabIndex = 15;
        txtConfirmacion.UseSystemPasswordChar = true;
        //
        // lblConfirmacion
        //
        lblConfirmacion.AutoSize = true;
        lblConfirmacion.Location = new Point(20, 380);
        lblConfirmacion.Name = "lblConfirmacion";
        lblConfirmacion.Size = new Size(122, 15);
        lblConfirmacion.TabIndex = 14;
        lblConfirmacion.Text = "Confirmar contraseña";
        //
        // txtPassword
        //
        txtPassword.Font = new Font("Segoe UI", 10F);
        txtPassword.Location = new Point(20, 348);
        txtPassword.MaxLength = 100;
        txtPassword.Name = "txtPassword";
        txtPassword.Size = new Size(280, 25);
        txtPassword.TabIndex = 13;
        txtPassword.UseSystemPasswordChar = true;
        //
        // lblPassword
        //
        lblPassword.AutoSize = true;
        lblPassword.Location = new Point(20, 330);
        lblPassword.Name = "lblPassword";
        lblPassword.Size = new Size(67, 15);
        lblPassword.TabIndex = 12;
        lblPassword.Text = "Contraseña";
        //
        // chkActivo
        //
        chkActivo.AutoSize = true;
        chkActivo.Location = new Point(20, 302);
        chkActivo.Name = "chkActivo";
        chkActivo.Size = new Size(60, 19);
        chkActivo.TabIndex = 11;
        chkActivo.Text = "Activo";
        //
        // cboRol
        //
        cboRol.DropDownStyle = ComboBoxStyle.DropDownList;
        cboRol.Font = new Font("Segoe UI", 10F);
        cboRol.Location = new Point(20, 268);
        cboRol.Name = "cboRol";
        cboRol.Size = new Size(280, 25);
        cboRol.TabIndex = 10;
        //
        // lblRol
        //
        lblRol.AutoSize = true;
        lblRol.Location = new Point(20, 250);
        lblRol.Name = "lblRol";
        lblRol.Size = new Size(24, 15);
        lblRol.TabIndex = 9;
        lblRol.Text = "Rol";
        //
        // txtTelefono
        //
        txtTelefono.Font = new Font("Segoe UI", 10F);
        txtTelefono.Location = new Point(20, 218);
        txtTelefono.MaxLength = 20;
        txtTelefono.Name = "txtTelefono";
        txtTelefono.Size = new Size(280, 25);
        txtTelefono.TabIndex = 8;
        //
        // lblTelefono
        //
        lblTelefono.AutoSize = true;
        lblTelefono.Location = new Point(20, 200);
        lblTelefono.Name = "lblTelefono";
        lblTelefono.Size = new Size(52, 15);
        lblTelefono.TabIndex = 7;
        lblTelefono.Text = "Teléfono";
        //
        // txtCorreo
        //
        txtCorreo.Font = new Font("Segoe UI", 10F);
        txtCorreo.Location = new Point(20, 168);
        txtCorreo.MaxLength = 100;
        txtCorreo.Name = "txtCorreo";
        txtCorreo.Size = new Size(280, 25);
        txtCorreo.TabIndex = 6;
        //
        // lblCorreo
        //
        lblCorreo.AutoSize = true;
        lblCorreo.Location = new Point(20, 150);
        lblCorreo.Name = "lblCorreo";
        lblCorreo.Size = new Size(43, 15);
        lblCorreo.TabIndex = 5;
        lblCorreo.Text = "Correo";
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
        lblNombre.Size = new Size(104, 15);
        lblNombre.TabIndex = 3;
        lblNombre.Text = "Nombre completo";
        //
        // txtUsuario
        //
        txtUsuario.Font = new Font("Segoe UI", 10F);
        txtUsuario.Location = new Point(20, 68);
        txtUsuario.MaxLength = 50;
        txtUsuario.Name = "txtUsuario";
        txtUsuario.Size = new Size(280, 25);
        txtUsuario.TabIndex = 2;
        //
        // lblUsuario
        //
        lblUsuario.AutoSize = true;
        lblUsuario.Location = new Point(20, 50);
        lblUsuario.Name = "lblUsuario";
        lblUsuario.Size = new Size(47, 15);
        lblUsuario.TabIndex = 1;
        lblUsuario.Text = "Usuario";
        //
        // lblEditor
        //
        lblEditor.AutoSize = true;
        lblEditor.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblEditor.ForeColor = Color.FromArgb(108, 92, 231);
        lblEditor.Location = new Point(20, 15);
        lblEditor.Name = "lblEditor";
        lblEditor.Size = new Size(118, 21);
        lblEditor.TabIndex = 0;
        lblEditor.Text = "Nuevo usuario";
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
        // FrmUsuarios
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(240, 242, 245);
        ClientSize = new Size(970, 650);
        Controls.Add(gridDatos);
        Controls.Add(panelEditor);
        Controls.Add(panelSuperior);
        FormBorderStyle = FormBorderStyle.None;
        Name = "FrmUsuarios";
        Padding = new Padding(15);
        Text = "Usuarios";
        Load += FrmUsuarios_Load;
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
    private Label lblAyudaPassword;
    private TextBox txtConfirmacion;
    private Label lblConfirmacion;
    private TextBox txtPassword;
    private Label lblPassword;
    private CheckBox chkActivo;
    private ComboBox cboRol;
    private Label lblRol;
    private TextBox txtTelefono;
    private Label lblTelefono;
    private TextBox txtCorreo;
    private Label lblCorreo;
    private TextBox txtNombre;
    private Label lblNombre;
    private TextBox txtUsuario;
    private Label lblUsuario;
    private Label lblEditor;
    private DataGridView gridDatos;
}
