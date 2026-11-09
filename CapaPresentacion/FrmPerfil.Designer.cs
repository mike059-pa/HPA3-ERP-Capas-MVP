#nullable disable
namespace CapaPresentacion;

partial class FrmPerfil
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
        panelDatos = new Panel();
        lblDatos = new Label();
        lblRol = new Label();
        lblNombre = new Label();
        lblAvatar = new Label();
        panelPassword = new Panel();
        lblMensaje = new Label();
        btnCambiar = new Button();
        txtConfirmacion = new TextBox();
        lblConfirmacion = new Label();
        txtNueva = new TextBox();
        lblNueva = new Label();
        txtActual = new TextBox();
        lblActual = new Label();
        lblTituloPassword = new Label();
        panelDatos.SuspendLayout();
        panelPassword.SuspendLayout();
        SuspendLayout();
        //
        // panelDatos
        //
        panelDatos.BackColor = Color.White;
        panelDatos.Controls.Add(lblDatos);
        panelDatos.Controls.Add(lblRol);
        panelDatos.Controls.Add(lblNombre);
        panelDatos.Controls.Add(lblAvatar);
        panelDatos.Location = new Point(30, 30);
        panelDatos.Name = "panelDatos";
        panelDatos.Size = new Size(420, 300);
        panelDatos.TabIndex = 0;
        //
        // lblDatos
        //
        lblDatos.Font = new Font("Consolas", 10F);
        lblDatos.ForeColor = Color.FromArgb(45, 52, 54);
        lblDatos.Location = new Point(25, 130);
        lblDatos.Name = "lblDatos";
        lblDatos.Size = new Size(380, 150);
        lblDatos.TabIndex = 3;
        //
        // lblRol
        //
        lblRol.AutoSize = true;
        lblRol.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblRol.ForeColor = Color.FromArgb(108, 92, 231);
        lblRol.Location = new Point(110, 70);
        lblRol.Name = "lblRol";
        lblRol.Size = new Size(29, 19);
        lblRol.TabIndex = 2;
        lblRol.Text = "Rol";
        //
        // lblNombre
        //
        lblNombre.AutoSize = true;
        lblNombre.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblNombre.ForeColor = Color.FromArgb(30, 30, 45);
        lblNombre.Location = new Point(105, 35);
        lblNombre.Name = "lblNombre";
        lblNombre.Size = new Size(97, 30);
        lblNombre.TabIndex = 1;
        lblNombre.Text = "Nombre";
        //
        // lblAvatar
        //
        lblAvatar.Location = new Point(20, 25);
        lblAvatar.Name = "lblAvatar";
        lblAvatar.Size = new Size(75, 75);
        lblAvatar.TabIndex = 0;
        //
        // panelPassword
        //
        panelPassword.BackColor = Color.White;
        panelPassword.Controls.Add(lblMensaje);
        panelPassword.Controls.Add(btnCambiar);
        panelPassword.Controls.Add(txtConfirmacion);
        panelPassword.Controls.Add(lblConfirmacion);
        panelPassword.Controls.Add(txtNueva);
        panelPassword.Controls.Add(lblNueva);
        panelPassword.Controls.Add(txtActual);
        panelPassword.Controls.Add(lblActual);
        panelPassword.Controls.Add(lblTituloPassword);
        panelPassword.Location = new Point(480, 30);
        panelPassword.Name = "panelPassword";
        panelPassword.Size = new Size(360, 340);
        panelPassword.TabIndex = 1;
        //
        // lblMensaje
        //
        lblMensaje.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblMensaje.Location = new Point(25, 270);
        lblMensaje.Name = "lblMensaje";
        lblMensaje.Size = new Size(310, 55);
        lblMensaje.TabIndex = 8;
        //
        // btnCambiar
        //
        btnCambiar.Location = new Point(25, 222);
        btnCambiar.Name = "btnCambiar";
        btnCambiar.Size = new Size(310, 38);
        btnCambiar.TabIndex = 7;
        btnCambiar.Text = "Cambiar contraseña";
        btnCambiar.Click += btnCambiar_Click;
        //
        // txtConfirmacion
        //
        txtConfirmacion.Font = new Font("Segoe UI", 10F);
        txtConfirmacion.Location = new Point(25, 182);
        txtConfirmacion.MaxLength = 100;
        txtConfirmacion.Name = "txtConfirmacion";
        txtConfirmacion.Size = new Size(310, 25);
        txtConfirmacion.TabIndex = 6;
        txtConfirmacion.UseSystemPasswordChar = true;
        //
        // lblConfirmacion
        //
        lblConfirmacion.AutoSize = true;
        lblConfirmacion.Location = new Point(25, 164);
        lblConfirmacion.Name = "lblConfirmacion";
        lblConfirmacion.Size = new Size(158, 15);
        lblConfirmacion.TabIndex = 5;
        lblConfirmacion.Text = "Confirmar nueva contraseña";
        //
        // txtNueva
        //
        txtNueva.Font = new Font("Segoe UI", 10F);
        txtNueva.Location = new Point(25, 130);
        txtNueva.MaxLength = 100;
        txtNueva.Name = "txtNueva";
        txtNueva.Size = new Size(310, 25);
        txtNueva.TabIndex = 4;
        txtNueva.UseSystemPasswordChar = true;
        //
        // lblNueva
        //
        lblNueva.AutoSize = true;
        lblNueva.Location = new Point(25, 112);
        lblNueva.Name = "lblNueva";
        lblNueva.Size = new Size(179, 15);
        lblNueva.TabIndex = 3;
        lblNueva.Text = "Nueva contraseña (mín. 6 caract.)";
        //
        // txtActual
        //
        txtActual.Font = new Font("Segoe UI", 10F);
        txtActual.Location = new Point(25, 78);
        txtActual.MaxLength = 100;
        txtActual.Name = "txtActual";
        txtActual.Size = new Size(310, 25);
        txtActual.TabIndex = 2;
        txtActual.UseSystemPasswordChar = true;
        //
        // lblActual
        //
        lblActual.AutoSize = true;
        lblActual.Location = new Point(25, 60);
        lblActual.Name = "lblActual";
        lblActual.Size = new Size(103, 15);
        lblActual.TabIndex = 1;
        lblActual.Text = "Contraseña actual";
        //
        // lblTituloPassword
        //
        lblTituloPassword.AutoSize = true;
        lblTituloPassword.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
        lblTituloPassword.ForeColor = Color.FromArgb(108, 92, 231);
        lblTituloPassword.Location = new Point(25, 20);
        lblTituloPassword.Name = "lblTituloPassword";
        lblTituloPassword.Size = new Size(160, 21);
        lblTituloPassword.TabIndex = 0;
        lblTituloPassword.Text = "Cambiar contraseña";
        //
        // FrmPerfil
        //
        AcceptButton = btnCambiar;
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(240, 242, 245);
        ClientSize = new Size(970, 650);
        Controls.Add(panelPassword);
        Controls.Add(panelDatos);
        FormBorderStyle = FormBorderStyle.None;
        Name = "FrmPerfil";
        Text = "Mi perfil";
        Load += FrmPerfil_Load;
        panelDatos.ResumeLayout(false);
        panelDatos.PerformLayout();
        panelPassword.ResumeLayout(false);
        panelPassword.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private Panel panelDatos;
    private Label lblDatos;
    private Label lblRol;
    private Label lblNombre;
    private Label lblAvatar;
    private Panel panelPassword;
    private Label lblMensaje;
    private Button btnCambiar;
    private TextBox txtConfirmacion;
    private Label lblConfirmacion;
    private TextBox txtNueva;
    private Label lblNueva;
    private TextBox txtActual;
    private Label lblActual;
    private Label lblTituloPassword;
}
