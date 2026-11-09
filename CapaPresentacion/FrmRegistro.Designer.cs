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
        lblUsuario = new Label();
        txtUsuario = new TextBox();
        lblNombre = new Label();
        txtNombre = new TextBox();
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
        lblTitulo.Location = new Point(40, 30);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Size = new Size(236, 32);
        lblTitulo.TabIndex = 0;
        lblTitulo.Text = "Registrar usuario";
        //
        // lblUsuario
        //
        lblUsuario.AutoSize = true;
        lblUsuario.Location = new Point(44, 85);
        lblUsuario.Name = "lblUsuario";
        lblUsuario.Size = new Size(47, 15);
        lblUsuario.TabIndex = 1;
        lblUsuario.Text = "Usuario";
        //
        // txtUsuario
        //
        txtUsuario.Font = new Font("Segoe UI", 11F);
        txtUsuario.Location = new Point(44, 105);
        txtUsuario.MaxLength = 50;
        txtUsuario.Name = "txtUsuario";
        txtUsuario.Size = new Size(320, 27);
        txtUsuario.TabIndex = 2;
        //
        // lblNombre
        //
        lblNombre.AutoSize = true;
        lblNombre.Location = new Point(44, 145);
        lblNombre.Name = "lblNombre";
        lblNombre.Size = new Size(104, 15);
        lblNombre.TabIndex = 3;
        lblNombre.Text = "Nombre completo";
        //
        // txtNombre
        //
        txtNombre.Font = new Font("Segoe UI", 11F);
        txtNombre.Location = new Point(44, 165);
        txtNombre.MaxLength = 100;
        txtNombre.Name = "txtNombre";
        txtNombre.Size = new Size(320, 27);
        txtNombre.TabIndex = 4;
        //
        // lblPassword
        //
        lblPassword.AutoSize = true;
        lblPassword.Location = new Point(44, 205);
        lblPassword.Name = "lblPassword";
        lblPassword.Size = new Size(163, 15);
        lblPassword.TabIndex = 5;
        lblPassword.Text = "Contraseña (mín. 6 caracteres)";
        //
        // txtPassword
        //
        txtPassword.Font = new Font("Segoe UI", 11F);
        txtPassword.Location = new Point(44, 225);
        txtPassword.MaxLength = 100;
        txtPassword.Name = "txtPassword";
        txtPassword.Size = new Size(320, 27);
        txtPassword.TabIndex = 6;
        txtPassword.UseSystemPasswordChar = true;
        //
        // lblConfirmacion
        //
        lblConfirmacion.AutoSize = true;
        lblConfirmacion.Location = new Point(44, 265);
        lblConfirmacion.Name = "lblConfirmacion";
        lblConfirmacion.Size = new Size(122, 15);
        lblConfirmacion.TabIndex = 7;
        lblConfirmacion.Text = "Confirmar contraseña";
        //
        // txtConfirmacion
        //
        txtConfirmacion.Font = new Font("Segoe UI", 11F);
        txtConfirmacion.Location = new Point(44, 285);
        txtConfirmacion.MaxLength = 100;
        txtConfirmacion.Name = "txtConfirmacion";
        txtConfirmacion.Size = new Size(320, 27);
        txtConfirmacion.TabIndex = 8;
        txtConfirmacion.UseSystemPasswordChar = true;
        //
        // btnRegistrar
        //
        btnRegistrar.BackColor = Color.FromArgb(108, 92, 231);
        btnRegistrar.Cursor = Cursors.Hand;
        btnRegistrar.FlatAppearance.BorderSize = 0;
        btnRegistrar.FlatStyle = FlatStyle.Flat;
        btnRegistrar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        btnRegistrar.ForeColor = Color.White;
        btnRegistrar.Location = new Point(44, 330);
        btnRegistrar.Name = "btnRegistrar";
        btnRegistrar.Size = new Size(320, 40);
        btnRegistrar.TabIndex = 9;
        btnRegistrar.Text = "REGISTRAR";
        btnRegistrar.UseVisualStyleBackColor = false;
        btnRegistrar.Click += btnRegistrar_Click;
        //
        // lblMensaje
        //
        lblMensaje.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblMensaje.Location = new Point(44, 380);
        lblMensaje.Name = "lblMensaje";
        lblMensaje.Size = new Size(500, 45);
        lblMensaje.TabIndex = 10;
        //
        // FrmRegistro
        //
        AcceptButton = btnRegistrar;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(240, 242, 245);
        ClientSize = new Size(870, 600);
        Controls.Add(lblMensaje);
        Controls.Add(btnRegistrar);
        Controls.Add(txtConfirmacion);
        Controls.Add(lblConfirmacion);
        Controls.Add(txtPassword);
        Controls.Add(lblPassword);
        Controls.Add(txtNombre);
        Controls.Add(lblNombre);
        Controls.Add(txtUsuario);
        Controls.Add(lblUsuario);
        Controls.Add(lblTitulo);
        FormBorderStyle = FormBorderStyle.None;
        Name = "FrmRegistro";
        Text = "Registrar usuario";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblTitulo;
    private Label lblUsuario;
    private TextBox txtUsuario;
    private Label lblNombre;
    private TextBox txtNombre;
    private Label lblPassword;
    private TextBox txtPassword;
    private Label lblConfirmacion;
    private TextBox txtConfirmacion;
    private Button btnRegistrar;
    private Label lblMensaje;
}
