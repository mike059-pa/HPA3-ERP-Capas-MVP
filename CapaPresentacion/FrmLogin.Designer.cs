#nullable disable
namespace CapaPresentacion;

partial class FrmLogin
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
        components = new System.ComponentModel.Container();
        lblIcono = new Label();
        lblTitulo = new Label();
        lblSubtitulo = new Label();
        lblUsuario = new Label();
        txtUsuario = new TextBox();
        lblPassword = new Label();
        txtPassword = new TextBox();
        chkMostrar = new CheckBox();
        btnIngresar = new Button();
        lblError = new Label();
        btnCerrar = new Button();
        lnkCrearCuenta = new LinkLabel();
        errorProvider = new ErrorProvider(components);
        ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
        SuspendLayout();
        //
        // lblIcono
        //
        lblIcono.Location = new Point(155, 35);
        lblIcono.Name = "lblIcono";
        lblIcono.Size = new Size(70, 60);
        lblIcono.TabIndex = 0;
        //
        // lblTitulo
        //
        lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        lblTitulo.ForeColor = Color.White;
        lblTitulo.Location = new Point(20, 100);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Size = new Size(340, 40);
        lblTitulo.TabIndex = 1;
        lblTitulo.Text = "INICIAR SESIÓN";
        lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
        //
        // lblSubtitulo
        //
        lblSubtitulo.ForeColor = Color.DarkGray;
        lblSubtitulo.Location = new Point(20, 140);
        lblSubtitulo.Name = "lblSubtitulo";
        lblSubtitulo.Size = new Size(340, 20);
        lblSubtitulo.TabIndex = 2;
        lblSubtitulo.Text = "HPA3 ERP · Capas con MVP";
        lblSubtitulo.TextAlign = ContentAlignment.MiddleCenter;
        //
        // lblUsuario
        //
        lblUsuario.AutoSize = true;
        lblUsuario.ForeColor = Color.Gainsboro;
        lblUsuario.Location = new Point(50, 180);
        lblUsuario.Name = "lblUsuario";
        lblUsuario.Size = new Size(47, 15);
        lblUsuario.TabIndex = 3;
        lblUsuario.Text = "Usuario";
        //
        // txtUsuario
        //
        txtUsuario.BackColor = Color.FromArgb(45, 45, 68);
        txtUsuario.BorderStyle = BorderStyle.FixedSingle;
        txtUsuario.Font = new Font("Segoe UI", 11F);
        txtUsuario.ForeColor = Color.White;
        txtUsuario.Location = new Point(50, 200);
        txtUsuario.MaxLength = 50;
        txtUsuario.Name = "txtUsuario";
        txtUsuario.Size = new Size(280, 27);
        txtUsuario.TabIndex = 4;
        //
        // lblPassword
        //
        lblPassword.AutoSize = true;
        lblPassword.ForeColor = Color.Gainsboro;
        lblPassword.Location = new Point(50, 240);
        lblPassword.Name = "lblPassword";
        lblPassword.Size = new Size(67, 15);
        lblPassword.TabIndex = 5;
        lblPassword.Text = "Contraseña";
        //
        // txtPassword
        //
        txtPassword.BackColor = Color.FromArgb(45, 45, 68);
        txtPassword.BorderStyle = BorderStyle.FixedSingle;
        txtPassword.Font = new Font("Segoe UI", 11F);
        txtPassword.ForeColor = Color.White;
        txtPassword.Location = new Point(50, 260);
        txtPassword.MaxLength = 100;
        txtPassword.Name = "txtPassword";
        txtPassword.Size = new Size(280, 27);
        txtPassword.TabIndex = 6;
        txtPassword.UseSystemPasswordChar = true;
        //
        // chkMostrar
        //
        chkMostrar.AutoSize = true;
        chkMostrar.ForeColor = Color.DarkGray;
        chkMostrar.Location = new Point(50, 295);
        chkMostrar.Name = "chkMostrar";
        chkMostrar.Size = new Size(129, 19);
        chkMostrar.TabIndex = 7;
        chkMostrar.Text = "Mostrar contraseña";
        chkMostrar.CheckedChanged += chkMostrar_CheckedChanged;
        //
        // btnIngresar
        //
        btnIngresar.BackColor = Color.FromArgb(108, 92, 231);
        btnIngresar.Cursor = Cursors.Hand;
        btnIngresar.FlatAppearance.BorderSize = 0;
        btnIngresar.FlatStyle = FlatStyle.Flat;
        btnIngresar.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        btnIngresar.ForeColor = Color.White;
        btnIngresar.Location = new Point(50, 330);
        btnIngresar.Name = "btnIngresar";
        btnIngresar.Size = new Size(280, 40);
        btnIngresar.TabIndex = 8;
        btnIngresar.Text = "INGRESAR";
        btnIngresar.UseVisualStyleBackColor = false;
        btnIngresar.Click += btnIngresar_Click;
        //
        // lblError
        //
        lblError.ForeColor = Color.FromArgb(255, 118, 117);
        lblError.Location = new Point(20, 376);
        lblError.Name = "lblError";
        lblError.Size = new Size(340, 34);
        lblError.TabIndex = 9;
        lblError.TextAlign = ContentAlignment.TopCenter;
        //
        // lnkCrearCuenta
        //
        lnkCrearCuenta.ActiveLinkColor = Color.White;
        lnkCrearCuenta.LinkBehavior = LinkBehavior.HoverUnderline;
        lnkCrearCuenta.LinkColor = Color.FromArgb(162, 155, 254);
        lnkCrearCuenta.Location = new Point(20, 414);
        lnkCrearCuenta.Name = "lnkCrearCuenta";
        lnkCrearCuenta.Size = new Size(340, 20);
        lnkCrearCuenta.TabIndex = 11;
        lnkCrearCuenta.TabStop = true;
        lnkCrearCuenta.Text = "¿No tienes cuenta? Crear cuenta de cliente";
        lnkCrearCuenta.TextAlign = ContentAlignment.MiddleCenter;
        lnkCrearCuenta.LinkClicked += lnkCrearCuenta_LinkClicked;
        //
        // btnCerrar
        //
        btnCerrar.Cursor = Cursors.Hand;
        btnCerrar.FlatAppearance.BorderSize = 0;
        btnCerrar.FlatAppearance.MouseOverBackColor = Color.FromArgb(214, 48, 49);
        btnCerrar.FlatStyle = FlatStyle.Flat;
        btnCerrar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnCerrar.ForeColor = Color.White;
        btnCerrar.Location = new Point(345, 0);
        btnCerrar.Name = "btnCerrar";
        btnCerrar.Size = new Size(35, 30);
        btnCerrar.TabIndex = 10;
        btnCerrar.TabStop = false;
        btnCerrar.Text = "X";
        btnCerrar.UseVisualStyleBackColor = true;
        btnCerrar.Click += btnCerrar_Click;
        //
        // errorProvider
        //
        errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        errorProvider.ContainerControl = this;
        //
        // FrmLogin
        //
        AcceptButton = btnIngresar;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(30, 30, 45);
        ClientSize = new Size(380, 450);
        Controls.Add(lnkCrearCuenta);
        Controls.Add(btnCerrar);
        Controls.Add(lblError);
        Controls.Add(btnIngresar);
        Controls.Add(chkMostrar);
        Controls.Add(txtPassword);
        Controls.Add(lblPassword);
        Controls.Add(txtUsuario);
        Controls.Add(lblUsuario);
        Controls.Add(lblSubtitulo);
        Controls.Add(lblTitulo);
        Controls.Add(lblIcono);
        FormBorderStyle = FormBorderStyle.None;
        Name = "FrmLogin";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Iniciar sesión";
        MouseDown += FrmLogin_MouseDown;
        ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblIcono;
    private Label lblTitulo;
    private Label lblSubtitulo;
    private Label lblUsuario;
    private TextBox txtUsuario;
    private Label lblPassword;
    private TextBox txtPassword;
    private CheckBox chkMostrar;
    private Button btnIngresar;
    private Label lblError;
    private Button btnCerrar;
    private LinkLabel lnkCrearCuenta;
    private ErrorProvider errorProvider;
}
