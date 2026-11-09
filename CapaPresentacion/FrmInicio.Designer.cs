#nullable disable
namespace CapaPresentacion;

partial class FrmInicio
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
        lblBienvenida = new Label();
        lblDetalle = new Label();
        lblDescripcion = new Label();
        SuspendLayout();
        //
        // lblBienvenida
        //
        lblBienvenida.AutoSize = true;
        lblBienvenida.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
        lblBienvenida.ForeColor = Color.FromArgb(30, 30, 45);
        lblBienvenida.Location = new Point(40, 40);
        lblBienvenida.Name = "lblBienvenida";
        lblBienvenida.Size = new Size(197, 41);
        lblBienvenida.TabIndex = 0;
        lblBienvenida.Text = "¡Bienvenido!";
        //
        // lblDetalle
        //
        lblDetalle.AutoSize = true;
        lblDetalle.Font = new Font("Segoe UI", 11F);
        lblDetalle.ForeColor = Color.FromArgb(64, 64, 64);
        lblDetalle.Location = new Point(44, 100);
        lblDetalle.Name = "lblDetalle";
        lblDetalle.Size = new Size(0, 20);
        lblDetalle.TabIndex = 1;
        //
        // lblDescripcion
        //
        lblDescripcion.Font = new Font("Segoe UI", 10F);
        lblDescripcion.ForeColor = Color.Gray;
        lblDescripcion.Location = new Point(44, 200);
        lblDescripcion.Name = "lblDescripcion";
        lblDescripcion.Size = new Size(600, 80);
        lblDescripcion.TabIndex = 2;
        lblDescripcion.Text = "Aplicación de Login en capas (Entidades, Datos, Negocio y Presentación) con el patrón MVP. " +
            "Las contraseñas se almacenan como hash SHA-512 con salt y la aplicación se conecta a SQL Server " +
            "con una cuenta de privilegios mínimos.";
        //
        // FrmInicio
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(240, 242, 245);
        ClientSize = new Size(870, 600);
        Controls.Add(lblDescripcion);
        Controls.Add(lblDetalle);
        Controls.Add(lblBienvenida);
        FormBorderStyle = FormBorderStyle.None;
        Name = "FrmInicio";
        Text = "Inicio";
        Load += FrmInicio_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label lblBienvenida;
    private Label lblDetalle;
    private Label lblDescripcion;
}
