#nullable disable
namespace CapaPresentacion;

partial class FrmPrincipal
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
        panelMenu = new Panel();
        btnRegistrar = new Button();
        btnInicio = new Button();
        panelLogo = new Panel();
        lblLogoSub = new Label();
        lblLogo = new Label();
        btnCerrarSesion = new Button();
        panelSesion = new Panel();
        lblNombreSesion = new Label();
        lblUsuarioSesion = new Label();
        lblIconoSesion = new Label();
        lblTituloSesion = new Label();
        panelBarraTitulo = new Panel();
        lblFecha = new Label();
        lblHora = new Label();
        btnMinimizar = new Button();
        btnMaximizar = new Button();
        btnCerrar = new Button();
        lblTituloBarra = new Label();
        btnMenu = new Button();
        panelContenedor = new Panel();
        timerMenu = new System.Windows.Forms.Timer(components);
        timerReloj = new System.Windows.Forms.Timer(components);
        panelMenu.SuspendLayout();
        panelLogo.SuspendLayout();
        panelSesion.SuspendLayout();
        panelBarraTitulo.SuspendLayout();
        SuspendLayout();
        //
        // panelMenu
        //
        panelMenu.BackColor = Color.FromArgb(30, 30, 45);
        panelMenu.Controls.Add(btnRegistrar);
        panelMenu.Controls.Add(btnInicio);
        panelMenu.Controls.Add(panelLogo);
        panelMenu.Controls.Add(btnCerrarSesion);
        panelMenu.Controls.Add(panelSesion);
        panelMenu.Dock = DockStyle.Left;
        panelMenu.Location = new Point(0, 0);
        panelMenu.Name = "panelMenu";
        panelMenu.Size = new Size(230, 650);
        panelMenu.TabIndex = 0;
        //
        // btnRegistrar
        //
        btnRegistrar.Cursor = Cursors.Hand;
        btnRegistrar.Dock = DockStyle.Top;
        btnRegistrar.FlatAppearance.BorderSize = 0;
        btnRegistrar.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 45, 68);
        btnRegistrar.FlatStyle = FlatStyle.Flat;
        btnRegistrar.Font = new Font("Segoe UI", 11F);
        btnRegistrar.ForeColor = Color.Gainsboro;
        btnRegistrar.ImageAlign = ContentAlignment.MiddleLeft;
        btnRegistrar.Location = new Point(0, 140);
        btnRegistrar.Name = "btnRegistrar";
        btnRegistrar.Padding = new Padding(14, 0, 0, 0);
        btnRegistrar.Size = new Size(230, 50);
        btnRegistrar.TabIndex = 2;
        btnRegistrar.Text = "   Registrar usuario";
        btnRegistrar.TextAlign = ContentAlignment.MiddleLeft;
        btnRegistrar.TextImageRelation = TextImageRelation.ImageBeforeText;
        btnRegistrar.UseVisualStyleBackColor = true;
        btnRegistrar.Click += btnRegistrar_Click;
        //
        // btnInicio
        //
        btnInicio.Cursor = Cursors.Hand;
        btnInicio.Dock = DockStyle.Top;
        btnInicio.FlatAppearance.BorderSize = 0;
        btnInicio.FlatAppearance.MouseOverBackColor = Color.FromArgb(45, 45, 68);
        btnInicio.FlatStyle = FlatStyle.Flat;
        btnInicio.Font = new Font("Segoe UI", 11F);
        btnInicio.ForeColor = Color.Gainsboro;
        btnInicio.ImageAlign = ContentAlignment.MiddleLeft;
        btnInicio.Location = new Point(0, 90);
        btnInicio.Name = "btnInicio";
        btnInicio.Padding = new Padding(14, 0, 0, 0);
        btnInicio.Size = new Size(230, 50);
        btnInicio.TabIndex = 1;
        btnInicio.Text = "   Inicio";
        btnInicio.TextAlign = ContentAlignment.MiddleLeft;
        btnInicio.TextImageRelation = TextImageRelation.ImageBeforeText;
        btnInicio.UseVisualStyleBackColor = true;
        btnInicio.Click += btnInicio_Click;
        //
        // panelLogo
        //
        panelLogo.Controls.Add(lblLogoSub);
        panelLogo.Controls.Add(lblLogo);
        panelLogo.Dock = DockStyle.Top;
        panelLogo.Location = new Point(0, 0);
        panelLogo.Name = "panelLogo";
        panelLogo.Size = new Size(230, 90);
        panelLogo.TabIndex = 0;
        //
        // lblLogoSub
        //
        lblLogoSub.AutoSize = true;
        lblLogoSub.ForeColor = Color.DarkGray;
        lblLogoSub.Location = new Point(18, 55);
        lblLogoSub.Name = "lblLogoSub";
        lblLogoSub.Size = new Size(97, 15);
        lblLogoSub.TabIndex = 1;
        lblLogoSub.Text = "Parcial Práctico";
        //
        // lblLogo
        //
        lblLogo.AutoSize = true;
        lblLogo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
        lblLogo.ForeColor = Color.FromArgb(108, 92, 231);
        lblLogo.Location = new Point(14, 20);
        lblLogo.Name = "lblLogo";
        lblLogo.Size = new Size(94, 32);
        lblLogo.TabIndex = 0;
        lblLogo.Text = "HPA III";
        //
        // btnCerrarSesion
        //
        btnCerrarSesion.Cursor = Cursors.Hand;
        btnCerrarSesion.Dock = DockStyle.Bottom;
        btnCerrarSesion.FlatAppearance.BorderSize = 0;
        btnCerrarSesion.FlatAppearance.MouseOverBackColor = Color.FromArgb(214, 48, 49);
        btnCerrarSesion.FlatStyle = FlatStyle.Flat;
        btnCerrarSesion.Font = new Font("Segoe UI", 11F);
        btnCerrarSesion.ForeColor = Color.Gainsboro;
        btnCerrarSesion.ImageAlign = ContentAlignment.MiddleLeft;
        btnCerrarSesion.Location = new Point(0, 528);
        btnCerrarSesion.Name = "btnCerrarSesion";
        btnCerrarSesion.Padding = new Padding(14, 0, 0, 0);
        btnCerrarSesion.Size = new Size(230, 50);
        btnCerrarSesion.TabIndex = 3;
        btnCerrarSesion.Text = "   Cerrar sesión";
        btnCerrarSesion.TextAlign = ContentAlignment.MiddleLeft;
        btnCerrarSesion.TextImageRelation = TextImageRelation.ImageBeforeText;
        btnCerrarSesion.UseVisualStyleBackColor = true;
        btnCerrarSesion.Click += btnCerrarSesion_Click;
        //
        // panelSesion
        //
        panelSesion.BackColor = Color.FromArgb(24, 24, 36);
        panelSesion.Controls.Add(lblNombreSesion);
        panelSesion.Controls.Add(lblUsuarioSesion);
        panelSesion.Controls.Add(lblIconoSesion);
        panelSesion.Controls.Add(lblTituloSesion);
        panelSesion.Dock = DockStyle.Bottom;
        panelSesion.Location = new Point(0, 578);
        panelSesion.Name = "panelSesion";
        panelSesion.Size = new Size(230, 72);
        panelSesion.TabIndex = 4;
        //
        // lblNombreSesion
        //
        lblNombreSesion.AutoSize = true;
        lblNombreSesion.ForeColor = Color.DarkGray;
        lblNombreSesion.Location = new Point(54, 46);
        lblNombreSesion.Name = "lblNombreSesion";
        lblNombreSesion.Size = new Size(50, 15);
        lblNombreSesion.TabIndex = 3;
        lblNombreSesion.Text = "Nombre";
        //
        // lblUsuarioSesion
        //
        lblUsuarioSesion.AutoSize = true;
        lblUsuarioSesion.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblUsuarioSesion.ForeColor = Color.White;
        lblUsuarioSesion.Location = new Point(54, 26);
        lblUsuarioSesion.Name = "lblUsuarioSesion";
        lblUsuarioSesion.Size = new Size(58, 19);
        lblUsuarioSesion.TabIndex = 2;
        lblUsuarioSesion.Text = "usuario";
        //
        // lblIconoSesion
        //
        lblIconoSesion.Location = new Point(12, 28);
        lblIconoSesion.Name = "lblIconoSesion";
        lblIconoSesion.Size = new Size(32, 32);
        lblIconoSesion.TabIndex = 1;
        //
        // lblTituloSesion
        //
        lblTituloSesion.AutoSize = true;
        lblTituloSesion.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
        lblTituloSesion.ForeColor = Color.FromArgb(108, 92, 231);
        lblTituloSesion.Location = new Point(12, 6);
        lblTituloSesion.Name = "lblTituloSesion";
        lblTituloSesion.Size = new Size(79, 12);
        lblTituloSesion.TabIndex = 0;
        lblTituloSesion.Text = "SESIÓN ACTIVA";
        //
        // panelBarraTitulo
        //
        panelBarraTitulo.BackColor = Color.FromArgb(43, 43, 64);
        panelBarraTitulo.Controls.Add(lblFecha);
        panelBarraTitulo.Controls.Add(lblHora);
        panelBarraTitulo.Controls.Add(btnMinimizar);
        panelBarraTitulo.Controls.Add(btnMaximizar);
        panelBarraTitulo.Controls.Add(btnCerrar);
        panelBarraTitulo.Controls.Add(lblTituloBarra);
        panelBarraTitulo.Controls.Add(btnMenu);
        panelBarraTitulo.Dock = DockStyle.Top;
        panelBarraTitulo.Location = new Point(230, 0);
        panelBarraTitulo.Name = "panelBarraTitulo";
        panelBarraTitulo.Size = new Size(870, 50);
        panelBarraTitulo.TabIndex = 1;
        panelBarraTitulo.MouseDown += panelBarraTitulo_MouseDown;
        //
        // lblFecha
        //
        lblFecha.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblFecha.Font = new Font("Segoe UI", 8.5F);
        lblFecha.ForeColor = Color.DarkGray;
        lblFecha.Location = new Point(440, 28);
        lblFecha.Name = "lblFecha";
        lblFecha.Size = new Size(290, 17);
        lblFecha.TabIndex = 6;
        lblFecha.Text = "fecha";
        lblFecha.TextAlign = ContentAlignment.MiddleRight;
        lblFecha.MouseDown += panelBarraTitulo_MouseDown;
        //
        // lblHora
        //
        lblHora.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblHora.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
        lblHora.ForeColor = Color.White;
        lblHora.Location = new Point(540, 3);
        lblHora.Name = "lblHora";
        lblHora.Size = new Size(190, 25);
        lblHora.TabIndex = 5;
        lblHora.Text = "00:00:00";
        lblHora.TextAlign = ContentAlignment.MiddleRight;
        lblHora.MouseDown += panelBarraTitulo_MouseDown;
        //
        // btnMinimizar
        //
        btnMinimizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnMinimizar.Cursor = Cursors.Hand;
        btnMinimizar.FlatAppearance.BorderSize = 0;
        btnMinimizar.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 60, 90);
        btnMinimizar.FlatStyle = FlatStyle.Flat;
        btnMinimizar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnMinimizar.ForeColor = Color.White;
        btnMinimizar.Location = new Point(740, 0);
        btnMinimizar.Name = "btnMinimizar";
        btnMinimizar.Size = new Size(40, 30);
        btnMinimizar.TabIndex = 4;
        btnMinimizar.TabStop = false;
        btnMinimizar.Text = "—";
        btnMinimizar.UseVisualStyleBackColor = true;
        btnMinimizar.Click += btnMinimizar_Click;
        //
        // btnMaximizar
        //
        btnMaximizar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnMaximizar.Cursor = Cursors.Hand;
        btnMaximizar.FlatAppearance.BorderSize = 0;
        btnMaximizar.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 60, 90);
        btnMaximizar.FlatStyle = FlatStyle.Flat;
        btnMaximizar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnMaximizar.ForeColor = Color.White;
        btnMaximizar.Location = new Point(780, 0);
        btnMaximizar.Name = "btnMaximizar";
        btnMaximizar.Size = new Size(40, 30);
        btnMaximizar.TabIndex = 3;
        btnMaximizar.TabStop = false;
        btnMaximizar.Text = "□";
        btnMaximizar.UseVisualStyleBackColor = true;
        btnMaximizar.Click += btnMaximizar_Click;
        //
        // btnCerrar
        //
        btnCerrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        btnCerrar.Cursor = Cursors.Hand;
        btnCerrar.FlatAppearance.BorderSize = 0;
        btnCerrar.FlatAppearance.MouseOverBackColor = Color.FromArgb(214, 48, 49);
        btnCerrar.FlatStyle = FlatStyle.Flat;
        btnCerrar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        btnCerrar.ForeColor = Color.White;
        btnCerrar.Location = new Point(820, 0);
        btnCerrar.Name = "btnCerrar";
        btnCerrar.Size = new Size(50, 30);
        btnCerrar.TabIndex = 2;
        btnCerrar.TabStop = false;
        btnCerrar.Text = "X";
        btnCerrar.UseVisualStyleBackColor = true;
        btnCerrar.Click += btnCerrar_Click;
        //
        // lblTituloBarra
        //
        lblTituloBarra.AutoSize = true;
        lblTituloBarra.Font = new Font("Segoe UI", 11F);
        lblTituloBarra.ForeColor = Color.White;
        lblTituloBarra.Location = new Point(55, 15);
        lblTituloBarra.Name = "lblTituloBarra";
        lblTituloBarra.Size = new Size(205, 20);
        lblTituloBarra.TabIndex = 1;
        lblTituloBarra.Text = "Sistema de Login en Capas";
        lblTituloBarra.MouseDown += panelBarraTitulo_MouseDown;
        //
        // btnMenu
        //
        btnMenu.Cursor = Cursors.Hand;
        btnMenu.FlatAppearance.BorderSize = 0;
        btnMenu.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 60, 90);
        btnMenu.FlatStyle = FlatStyle.Flat;
        btnMenu.Location = new Point(8, 8);
        btnMenu.Name = "btnMenu";
        btnMenu.Size = new Size(38, 34);
        btnMenu.TabIndex = 0;
        btnMenu.TabStop = false;
        btnMenu.UseVisualStyleBackColor = true;
        btnMenu.Click += btnMenu_Click;
        //
        // panelContenedor
        //
        panelContenedor.BackColor = Color.FromArgb(240, 242, 245);
        panelContenedor.Dock = DockStyle.Fill;
        panelContenedor.Location = new Point(230, 50);
        panelContenedor.Name = "panelContenedor";
        panelContenedor.Size = new Size(870, 600);
        panelContenedor.TabIndex = 2;
        //
        // timerMenu
        //
        timerMenu.Interval = 10;
        timerMenu.Tick += timerMenu_Tick;
        //
        // timerReloj
        //
        timerReloj.Interval = 1000;
        timerReloj.Tick += timerReloj_Tick;
        //
        // FrmPrincipal
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1100, 650);
        Controls.Add(panelContenedor);
        Controls.Add(panelBarraTitulo);
        Controls.Add(panelMenu);
        FormBorderStyle = FormBorderStyle.None;
        MinimumSize = new Size(800, 500);
        Name = "FrmPrincipal";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Sistema de Login en Capas";
        Load += FrmPrincipal_Load;
        panelMenu.ResumeLayout(false);
        panelLogo.ResumeLayout(false);
        panelLogo.PerformLayout();
        panelSesion.ResumeLayout(false);
        panelSesion.PerformLayout();
        panelBarraTitulo.ResumeLayout(false);
        panelBarraTitulo.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private Panel panelMenu;
    private Button btnRegistrar;
    private Button btnInicio;
    private Panel panelLogo;
    private Label lblLogoSub;
    private Label lblLogo;
    private Button btnCerrarSesion;
    private Panel panelSesion;
    private Label lblNombreSesion;
    private Label lblUsuarioSesion;
    private Label lblIconoSesion;
    private Label lblTituloSesion;
    private Panel panelBarraTitulo;
    private Label lblFecha;
    private Label lblHora;
    private Button btnMinimizar;
    private Button btnMaximizar;
    private Button btnCerrar;
    private Label lblTituloBarra;
    private Button btnMenu;
    private Panel panelContenedor;
    private System.Windows.Forms.Timer timerMenu;
    private System.Windows.Forms.Timer timerReloj;
}
