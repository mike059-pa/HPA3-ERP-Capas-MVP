#nullable disable
namespace CapaPresentacion;

partial class FrmReportes
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
        panelFiltro = new Panel();
        lblMensaje = new Label();
        btnGenerar = new Button();
        dtpHasta = new DateTimePicker();
        lblHasta = new Label();
        dtpDesde = new DateTimePicker();
        lblDesde = new Label();
        cboTipo = new ComboBox();
        lblTipo = new Label();
        lblTitulo = new Label();
        panelGrafico = new Panel();
        gridReporte = new DataGridView();
        lblTotal = new Label();
        panelFiltro.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridReporte).BeginInit();
        SuspendLayout();
        //
        // panelFiltro
        //
        panelFiltro.BackColor = Color.White;
        panelFiltro.Controls.Add(lblMensaje);
        panelFiltro.Controls.Add(btnGenerar);
        panelFiltro.Controls.Add(dtpHasta);
        panelFiltro.Controls.Add(lblHasta);
        panelFiltro.Controls.Add(dtpDesde);
        panelFiltro.Controls.Add(lblDesde);
        panelFiltro.Controls.Add(cboTipo);
        panelFiltro.Controls.Add(lblTipo);
        panelFiltro.Controls.Add(lblTitulo);
        panelFiltro.Dock = DockStyle.Top;
        panelFiltro.Location = new Point(15, 15);
        panelFiltro.Name = "panelFiltro";
        panelFiltro.Size = new Size(940, 110);
        panelFiltro.TabIndex = 0;
        //
        // lblMensaje
        //
        lblMensaje.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        lblMensaje.Location = new Point(15, 84);
        lblMensaje.Name = "lblMensaje";
        lblMensaje.Size = new Size(700, 20);
        lblMensaje.TabIndex = 8;
        //
        // btnGenerar
        //
        btnGenerar.Location = new Point(625, 50);
        btnGenerar.Name = "btnGenerar";
        btnGenerar.Size = new Size(110, 30);
        btnGenerar.TabIndex = 7;
        btnGenerar.Text = "Generar";
        btnGenerar.Click += btnGenerar_Click;
        //
        // dtpHasta
        //
        dtpHasta.Font = new Font("Segoe UI", 10F);
        dtpHasta.Format = DateTimePickerFormat.Short;
        dtpHasta.Location = new Point(485, 52);
        dtpHasta.Name = "dtpHasta";
        dtpHasta.Size = new Size(125, 25);
        dtpHasta.TabIndex = 6;
        //
        // lblHasta
        //
        lblHasta.AutoSize = true;
        lblHasta.Location = new Point(440, 57);
        lblHasta.Name = "lblHasta";
        lblHasta.Size = new Size(37, 15);
        lblHasta.TabIndex = 5;
        lblHasta.Text = "Hasta";
        //
        // dtpDesde
        //
        dtpDesde.Font = new Font("Segoe UI", 10F);
        dtpDesde.Format = DateTimePickerFormat.Short;
        dtpDesde.Location = new Point(300, 52);
        dtpDesde.Name = "dtpDesde";
        dtpDesde.Size = new Size(125, 25);
        dtpDesde.TabIndex = 4;
        //
        // lblDesde
        //
        lblDesde.AutoSize = true;
        lblDesde.Location = new Point(255, 57);
        lblDesde.Name = "lblDesde";
        lblDesde.Size = new Size(39, 15);
        lblDesde.TabIndex = 3;
        lblDesde.Text = "Desde";
        //
        // cboTipo
        //
        cboTipo.DropDownStyle = ComboBoxStyle.DropDownList;
        cboTipo.Font = new Font("Segoe UI", 10F);
        cboTipo.Location = new Point(55, 52);
        cboTipo.Name = "cboTipo";
        cboTipo.Size = new Size(185, 25);
        cboTipo.TabIndex = 2;
        //
        // lblTipo
        //
        lblTipo.AutoSize = true;
        lblTipo.Location = new Point(15, 57);
        lblTipo.Name = "lblTipo";
        lblTipo.Size = new Size(31, 15);
        lblTipo.TabIndex = 1;
        lblTipo.Text = "Tipo";
        //
        // lblTitulo
        //
        lblTitulo.AutoSize = true;
        lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblTitulo.ForeColor = Color.FromArgb(30, 30, 45);
        lblTitulo.Location = new Point(10, 8);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Size = new Size(102, 30);
        lblTitulo.TabIndex = 0;
        lblTitulo.Text = "Reportes";
        //
        // panelGrafico
        //
        panelGrafico.BackColor = Color.White;
        panelGrafico.Dock = DockStyle.Right;
        panelGrafico.Location = new Point(555, 125);
        panelGrafico.Name = "panelGrafico";
        panelGrafico.Size = new Size(400, 470);
        panelGrafico.TabIndex = 2;
        panelGrafico.Paint += panelGrafico_Paint;
        panelGrafico.Resize += panelGrafico_Resize;
        //
        // gridReporte
        //
        gridReporte.Dock = DockStyle.Fill;
        gridReporte.Location = new Point(15, 125);
        gridReporte.Name = "gridReporte";
        gridReporte.Size = new Size(540, 470);
        gridReporte.TabIndex = 1;
        //
        // lblTotal
        //
        lblTotal.Dock = DockStyle.Bottom;
        lblTotal.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
        lblTotal.ForeColor = Color.FromArgb(108, 92, 231);
        lblTotal.Location = new Point(15, 595);
        lblTotal.Name = "lblTotal";
        lblTotal.Size = new Size(940, 40);
        lblTotal.TabIndex = 3;
        lblTotal.Text = "Total general: $0.00";
        lblTotal.TextAlign = ContentAlignment.MiddleRight;
        //
        // FrmReportes
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(240, 242, 245);
        ClientSize = new Size(970, 650);
        Controls.Add(gridReporte);
        Controls.Add(panelGrafico);
        Controls.Add(lblTotal);
        Controls.Add(panelFiltro);
        FormBorderStyle = FormBorderStyle.None;
        Name = "FrmReportes";
        Padding = new Padding(15);
        Text = "Reportes";
        Load += FrmReportes_Load;
        panelFiltro.ResumeLayout(false);
        panelFiltro.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)gridReporte).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private Panel panelFiltro;
    private Label lblMensaje;
    private Button btnGenerar;
    private DateTimePicker dtpHasta;
    private Label lblHasta;
    private DateTimePicker dtpDesde;
    private Label lblDesde;
    private ComboBox cboTipo;
    private Label lblTipo;
    private Label lblTitulo;
    private Panel panelGrafico;
    private DataGridView gridReporte;
    private Label lblTotal;
}
