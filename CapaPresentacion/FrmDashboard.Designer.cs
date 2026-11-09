#nullable disable
namespace CapaPresentacion;

partial class FrmDashboard
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
        lblSumario = new Label();
        flowTarjetas = new FlowLayoutPanel();
        panelInferior = new Panel();
        panelLista = new Panel();
        gridLista = new DataGridView();
        lblLista = new Label();
        panelReloj = new Panel();
        lblFechaGrande = new Label();
        lblHoraGrande = new Label();
        timerReloj = new System.Windows.Forms.Timer(components);
        panelInferior.SuspendLayout();
        panelLista.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)gridLista).BeginInit();
        panelReloj.SuspendLayout();
        SuspendLayout();
        //
        // lblSumario
        //
        lblSumario.Dock = DockStyle.Top;
        lblSumario.Font = new Font("Segoe UI", 12F);
        lblSumario.ForeColor = Color.FromArgb(45, 52, 54);
        lblSumario.Location = new Point(20, 15);
        lblSumario.Name = "lblSumario";
        lblSumario.Size = new Size(930, 32);
        lblSumario.TabIndex = 0;
        lblSumario.Text = "Sumario del sistema:";
        lblSumario.TextAlign = ContentAlignment.MiddleLeft;
        //
        // flowTarjetas
        //
        flowTarjetas.AutoScroll = true;
        flowTarjetas.Dock = DockStyle.Top;
        flowTarjetas.Location = new Point(20, 47);
        flowTarjetas.Name = "flowTarjetas";
        flowTarjetas.Size = new Size(930, 160);
        flowTarjetas.TabIndex = 1;
        //
        // panelInferior
        //
        panelInferior.Controls.Add(panelLista);
        panelInferior.Controls.Add(panelReloj);
        panelInferior.Dock = DockStyle.Fill;
        panelInferior.Location = new Point(20, 207);
        panelInferior.Name = "panelInferior";
        panelInferior.Size = new Size(930, 428);
        panelInferior.TabIndex = 2;
        //
        // panelLista
        //
        panelLista.Controls.Add(gridLista);
        panelLista.Controls.Add(lblLista);
        panelLista.Dock = DockStyle.Fill;
        panelLista.Location = new Point(0, 0);
        panelLista.Name = "panelLista";
        panelLista.Size = new Size(520, 428);
        panelLista.TabIndex = 0;
        //
        // gridLista
        //
        gridLista.Dock = DockStyle.Fill;
        gridLista.Location = new Point(0, 32);
        gridLista.Name = "gridLista";
        gridLista.Size = new Size(520, 396);
        gridLista.TabIndex = 1;
        //
        // lblLista
        //
        lblLista.Dock = DockStyle.Top;
        lblLista.Font = new Font("Segoe UI", 12F);
        lblLista.ForeColor = Color.FromArgb(45, 52, 54);
        lblLista.Location = new Point(0, 0);
        lblLista.Name = "lblLista";
        lblLista.Size = new Size(520, 32);
        lblLista.TabIndex = 0;
        lblLista.Text = "Productos bajo stock:";
        lblLista.TextAlign = ContentAlignment.MiddleLeft;
        //
        // panelReloj
        //
        panelReloj.Controls.Add(lblFechaGrande);
        panelReloj.Controls.Add(lblHoraGrande);
        panelReloj.Dock = DockStyle.Right;
        panelReloj.Location = new Point(520, 0);
        panelReloj.Name = "panelReloj";
        panelReloj.Padding = new Padding(0, 90, 0, 0);
        panelReloj.Size = new Size(410, 428);
        panelReloj.TabIndex = 1;
        //
        // lblFechaGrande
        //
        lblFechaGrande.Dock = DockStyle.Top;
        lblFechaGrande.Font = new Font("Segoe UI", 15F);
        lblFechaGrande.ForeColor = Color.FromArgb(108, 92, 231);
        lblFechaGrande.Location = new Point(0, 200);
        lblFechaGrande.Name = "lblFechaGrande";
        lblFechaGrande.Size = new Size(410, 40);
        lblFechaGrande.TabIndex = 1;
        lblFechaGrande.Text = "fecha";
        lblFechaGrande.TextAlign = ContentAlignment.MiddleCenter;
        //
        // lblHoraGrande
        //
        lblHoraGrande.Dock = DockStyle.Top;
        lblHoraGrande.Font = new Font("Segoe UI Light", 54F);
        lblHoraGrande.ForeColor = Color.FromArgb(45, 52, 54);
        lblHoraGrande.Location = new Point(0, 90);
        lblHoraGrande.Name = "lblHoraGrande";
        lblHoraGrande.Size = new Size(410, 110);
        lblHoraGrande.TabIndex = 0;
        lblHoraGrande.Text = "00:00:00";
        lblHoraGrande.TextAlign = ContentAlignment.MiddleCenter;
        //
        // timerReloj
        //
        timerReloj.Interval = 1000;
        timerReloj.Tick += timerReloj_Tick;
        //
        // FrmDashboard
        //
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(240, 242, 245);
        ClientSize = new Size(970, 650);
        Controls.Add(panelInferior);
        Controls.Add(flowTarjetas);
        Controls.Add(lblSumario);
        FormBorderStyle = FormBorderStyle.None;
        Name = "FrmDashboard";
        Padding = new Padding(20, 15, 20, 15);
        Text = "Dashboard";
        Load += FrmDashboard_Load;
        panelInferior.ResumeLayout(false);
        panelLista.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)gridLista).EndInit();
        panelReloj.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private Label lblSumario;
    private FlowLayoutPanel flowTarjetas;
    private Panel panelInferior;
    private Panel panelLista;
    private DataGridView gridLista;
    private Label lblLista;
    private Panel panelReloj;
    private Label lblFechaGrande;
    private Label lblHoraGrande;
    private System.Windows.Forms.Timer timerReloj;
}
