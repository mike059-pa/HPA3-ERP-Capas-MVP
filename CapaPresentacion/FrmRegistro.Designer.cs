#nullable disable
namespace CapaPresentacion;

partial class FrmRegistro
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
        lblTitulo = new Label();
        lblSubtitulo = new Label();
        lblUsuario = new Label();
        txtUsuario = new TextBox();
        lblNombre = new Label();
        txtNombre = new TextBox();
        lblCorreo = new Label();
        txtCorreo = new TextBox();
        lblTelefono = new Label();
        txtTelefono = new TextBox();
        lblPassword = new Label();
        txtPassword = new TextBox();
        lblConfirmacion = new Label();
        txtConfirmacion = new TextBox();
        btnRegistrar = new Button();
        lblMensaje = new Label();
        SuspendLayout();
        //
        // lblTitulo
        //
        lblTitulo.AutoSize = true;
        lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        lblTitulo.ForeColor = Color.FromArgb(30, 30, 45);
        lblTitulo.Location = new Point(36, 20);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Size = new Size(165, 32);
        lblTitulo.TabIndex = 0;
        lblTitulo.Text = "Crear cuenta";
        //
        // lblSubtitulo
        //
        lblSubtitulo.AutoSize = true;
        lblSubtitulo.ForeColor = Color.Gray;
        lblSubtitulo.Location = new Point(40, 55);
        lblSubtitulo.Name = "lblSubtitulo";
        lblSubtitulo.Size = new Size(262, 15);
        lblSubtitulo.TabIndex = 1;
        lblSubtitulo.Text = "Regístrese como cliente para comprar en línea.";
        //
        // lblUsuario
        //
        lblUsuario.AutoSize = true;
        lblUsuario.Location = new Point(40, 88);
        lblUsuario.Name = "lblUsuario";
        lblUsuario.Size = new Size(47, 15);
        lblUsuario.TabIndex = 2;
        lblUsuario.Text = "Usuario";
        //
        // txtUsuario
        //
        txtUsuario.Font = new Font("Segoe UI", 11F);
        txtUsuario.Location = new Point(40, 106);
        txtUsuario.MaxLength = 50;
        txtUsuario.Name = "txtUsuario";
        txtUsuario.Size = new Size(320, 27);
        txtUsuario.TabIndex = 3;
        //
        // lblNombre
        //
        lblNombre.AutoSize = true;
        lblNombre.Location = new Point(40, 142);
        lblNombre.Name = "lblNombre";
        lblNombre.Size = new Size(104, 15);
        lblNombre.TabIndex = 4;
        lblNombre.Text = "Nombre completo";
        //
        // txtNombre
        //
        txtNombre.Font = new Font("Segoe UI", 11F);
        txtNombre.Location = new Point(40, 160);
        txtNombre.MaxLength = 100;
        txtNombre.Name = "txtNombre";
        txtNombre.Size = new Size(320, 27);
        txtNombre.TabIndex = 5;
        //
        // lblCorreo
        //
        lblCorreo.AutoSize = true;
        lblCorreo.Location = new Point(40, 196);
        lblCorreo.Name = "lblCorreo";
        lblCorreo.Size = new Size(43, 15);
        lblCorreo.TabIndex = 6;
        lblCorreo.Text = "Correo";
        //
        // txtCorreo
        //
        txtCorreo.Font = new Font("Segoe UI", 11F);
        txtCorreo.Location = new Point(40, 214);
        txtCorreo.MaxLength = 100;
        txtCorreo.Name = "txtCorreo";
        txtCorreo.Size = new Size(320, 27);
        txtCorreo.TabIndex = 7;
        //
        // lblTelefono
        //
        lblTelefono.AutoSize = true;
        lblTelefono.Location = new Point(40, 250);
        lblTelefono.Name = "lblTelefono";
        lblTelefono.Size = new Size(52, 15);
        lblTelefono.TabIndex = 8;
        lblTelefono.Text = "Teléfono";
        //
        // txtTelefono
        //
        txtTelefono.Font = new Font("Segoe UI", 11F);
        txtTelefono.Location = new Point(40, 268);
        txtTelefono.MaxLength = 20;
        txtTelefono.Name = "txtTelefono";
        txtTelefono.Size = new Size(320, 27);
        txtTelefono.TabIndex = 9;
        //
        // lblPassword
        //
        lblPassword.AutoSize = true;
        lblPassword.Location = new Point(40, 304);
        lblPassword.Name = "lblPassword";
        lblPassword.Size = new Size(163, 15);
        lblPassword.TabIndex = 10;
        lblPassword.Text = "Contraseña (mín. 6 caracteres)";
        //
        // txtPassword
        //
        txtPassword.Font = new Font("Segoe UI", 11F);
        txtPassword.Location = new Point(40, 322);
        txtPassword.MaxLength = 100;
        txtPassword.Name = "txtPassword";
        txtPassword.Size = new Size(320, 27);
        txtPassword.TabIndex = 11;
        txtPassword.UseSystemPasswordChar = true;
        //
        // lblConfirmacion
        //
        lblConfirmacion.AutoSize = true;
        lblConfirmacion.Location = new Point(40, 358);
        lblConfirmacion.Name = "lblConfirmacion";
        lblConfirmacion.Size = new Size(122, 15);
        lblConfirmacion.TabIndex = 12;
        lblConfirmacion.Text = "Confirmar contraseña";
        //
        // txtConfirmacion
        //
        txtConfirmacion.Font = new Font("Segoe UI", 11F);
        txtConfirmacion.Location = new Point(40, 376);
        txtConfirmacion.MaxLength = 100;
        txtConfirmacion.Name = "txtConfirmacion";
        txtConfirmacion.Size = new Size(320, 27);
        txtConfirmacion.TabIndex = 13;
        txtConfirmacion.UseSystemPasswordChar = true;
        //
        // btnRegistrar
        //
        btnRegistrar.Location = new Point(40, 420);
        btnRegistrar.Name = "btnRegistrar";
        btnRegistrar.Size = new Size(320, 40);
        btnRegistrar.TabIndex = 14;
        btnRegistrar.Text = "CREAR CUENTA";
        btnRegistrar.Click += btnRegistrar_Click;
        //
        // lblMensaje
        //
        lblMensaje.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblMensaje.Location = new Point(40, 468);
        lblMensaje.Name = "lblMensaje";
        lblMensaje.Size = new Size(320, 45);
        lblMensaje.TabIndex = 15;
        //
        // FrmRegistro
        //
        AcceptButton = btnRegistrar;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(240, 242, 245);
        ClientSize = new Size(400, 525);
        Controls.Add(lblMensaje);
        Controls.Add(btnRegistrar);
        Controls.Add(txtConfirmacion);
        Controls.Add(lblConfirmacion);
        Controls.Add(txtPassword);
        Controls.Add(lblPassword);
        Controls.Add(txtTelefono);
        Controls.Add(lblTelefono);
        Controls.Add(txtCorreo);
        Controls.Add(lblCorreo);
        Controls.Add(txtNombre);
        Controls.Add(lblNombre);
        Controls.Add(txtUsuario);
        Controls.Add(lblUsuario);
        Controls.Add(lblSubtitulo);
        Controls.Add(lblTitulo);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "FrmRegistro";
        ShowInTaskbar = false;
        StartPosition = FormStartPosition.CenterParent;
        Text = "Crear cuenta de cliente";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblTitulo;
    private Label lblSubtitulo;
    private Label lblUsuario;
    private TextBox txtUsuario;
    private Label lblNombre;
    private TextBox txtNombre;
    private Label lblCorreo;
    private TextBox txtCorreo;
    private Label lblTelefono;
    private TextBox txtTelefono;
    private Label lblPassword;
    private TextBox txtPassword;
    private Label lblConfirmacion;
    private TextBox txtConfirmacion;
    private Button btnRegistrar;
    private Label lblMensaje;
}
