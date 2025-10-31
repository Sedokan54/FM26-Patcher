using System.Drawing;
using System.Windows.Forms;

namespace FM26Patcher
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel headerPanel;
        private Label titleLabel;
        private Label subtitleLabel;
        private RichTextBox txtLog;
        private ProgressBar progressBar;
        private Button btnStart;
        private Button btnExit;
        private Panel footerPanel;
        private Panel optionsPanel;
        private CheckBox chkLisansYamasi;
        private CheckBox chkArayuzHizlandirma;
        private Label lblOptions;
        private Label lblLisansDesc;
        private Label lblArayuzDesc;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.headerPanel = new Panel();
            this.subtitleLabel = new Label();
            this.titleLabel = new Label();
            this.txtLog = new RichTextBox();
            this.progressBar = new ProgressBar();
            this.btnStart = new Button();
            this.btnExit = new Button();
            this.footerPanel = new Panel();
            this.optionsPanel = new Panel();
            this.lblOptions = new Label();
            this.chkLisansYamasi = new CheckBox();
            this.chkArayuzHizlandirma = new CheckBox();
            this.lblLisansDesc = new Label();
            this.lblArayuzDesc = new Label();
            
            this.headerPanel.SuspendLayout();
            this.footerPanel.SuspendLayout();
            this.optionsPanel.SuspendLayout();
            this.SuspendLayout();
            
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = Color.FromArgb(44, 62, 80);
            this.headerPanel.Controls.Add(this.subtitleLabel);
            this.headerPanel.Controls.Add(this.titleLabel);
            this.headerPanel.Dock = DockStyle.Top;
            this.headerPanel.Location = new Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new Size(900, 90);
            this.headerPanel.TabIndex = 0;
            
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            this.titleLabel.ForeColor = Color.FromArgb(236, 240, 241);
            this.titleLabel.Location = new Point(20, 15);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new Size(500, 42);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "⚽ FM26 Patch Fixer";
            
            // 
            // subtitleLabel
            // 
            this.subtitleLabel.AutoSize = true;
            this.subtitleLabel.Font = new Font("Segoe UI", 10F);
            this.subtitleLabel.ForeColor = Color.FromArgb(189, 195, 199);
            this.subtitleLabel.Location = new Point(25, 60);
            this.subtitleLabel.Name = "subtitleLabel";
            this.subtitleLabel.Size = new Size(450, 19);
            this.subtitleLabel.TabIndex = 1;
            this.subtitleLabel.Text = "Football Manager 2026 - Lisans düzeltme ve arayüz hızlandırma";
            
            // 
            // optionsPanel
            // 
            this.optionsPanel.BackColor = Color.FromArgb(52, 73, 94);
            this.optionsPanel.Controls.Add(this.lblArayuzDesc);
            this.optionsPanel.Controls.Add(this.lblLisansDesc);
            this.optionsPanel.Controls.Add(this.chkArayuzHizlandirma);
            this.optionsPanel.Controls.Add(this.chkLisansYamasi);
            this.optionsPanel.Controls.Add(this.lblOptions);
            this.optionsPanel.Location = new Point(20, 105);
            this.optionsPanel.Name = "optionsPanel";
            this.optionsPanel.Size = new Size(860, 140);
            this.optionsPanel.TabIndex = 1;
            
            // 
            // lblOptions
            // 
            this.lblOptions.AutoSize = true;
            this.lblOptions.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            this.lblOptions.ForeColor = Color.FromArgb(236, 240, 241);
            this.lblOptions.Location = new Point(15, 12);
            this.lblOptions.Name = "lblOptions";
            this.lblOptions.Size = new Size(250, 21);
            this.lblOptions.TabIndex = 0;
            this.lblOptions.Text = "🔧 Uygulanacak İşlemler:";
            
            // 
            // chkLisansYamasi
            // 
            this.chkLisansYamasi.AutoSize = true;
            this.chkLisansYamasi.Checked = true;
            this.chkLisansYamasi.CheckState = CheckState.Checked;
            this.chkLisansYamasi.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.chkLisansYamasi.ForeColor = Color.FromArgb(39, 174, 96);
            this.chkLisansYamasi.Location = new Point(35, 50);
            this.chkLisansYamasi.Name = "chkLisansYamasi";
            this.chkLisansYamasi.Size = new Size(200, 24);
            this.chkLisansYamasi.TabIndex = 1;
            this.chkLisansYamasi.Text = "✓ Lisans Yaması";
            this.chkLisansYamasi.UseVisualStyleBackColor = true;
            
            // 
            // lblLisansDesc
            // 
            this.lblLisansDesc.AutoSize = true;
            this.lblLisansDesc.Font = new Font("Segoe UI", 9F);
            this.lblLisansDesc.ForeColor = Color.FromArgb(189, 195, 199);
            this.lblLisansDesc.Location = new Point(55, 75);
            this.lblLisansDesc.Name = "lblLisansDesc";
            this.lblLisansDesc.Size = new Size(300, 15);
            this.lblLisansDesc.TabIndex = 2;
            this.lblLisansDesc.Text = "Takım ve oyuncu isimleri düzeltilir (29 dosya işlenir)";
            
            // 
            // chkArayuzHizlandirma
            // 
            this.chkArayuzHizlandirma.AutoSize = true;
            this.chkArayuzHizlandirma.Checked = true;
            this.chkArayuzHizlandirma.CheckState = CheckState.Checked;
            this.chkArayuzHizlandirma.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            this.chkArayuzHizlandirma.ForeColor = Color.FromArgb(230, 126, 34);
            this.chkArayuzHizlandirma.Location = new Point(450, 50);
            this.chkArayuzHizlandirma.Name = "chkArayuzHizlandirma";
            this.chkArayuzHizlandirma.Size = new Size(230, 24);
            this.chkArayuzHizlandirma.TabIndex = 3;
            this.chkArayuzHizlandirma.Text = "⚡ Arayüz Hızlandırma";
            this.chkArayuzHizlandirma.UseVisualStyleBackColor = true;
            
            // 
            // lblArayuzDesc
            // 
            this.lblArayuzDesc.AutoSize = true;
            this.lblArayuzDesc.Font = new Font("Segoe UI", 9F);
            this.lblArayuzDesc.ForeColor = Color.FromArgb(189, 195, 199);
            this.lblArayuzDesc.Location = new Point(470, 75);
            this.lblArayuzDesc.Name = "lblArayuzDesc";
            this.lblArayuzDesc.Size = new Size(320, 15);
            this.lblArayuzDesc.TabIndex = 4;
            this.lblArayuzDesc.Text = "Oyun arayüzü optimize edilir (UI performans artırma)";
            
            // 
            // txtLog
            // 
            this.txtLog.BackColor = Color.FromArgb(39, 55, 70);
            this.txtLog.BorderStyle = BorderStyle.None;
            this.txtLog.Font = new Font("Consolas", 9.5F);
            this.txtLog.ForeColor = Color.FromArgb(236, 240, 241);
            this.txtLog.Location = new Point(20, 260);
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.Size = new Size(860, 280);
            this.txtLog.TabIndex = 2;
            this.txtLog.Text = "";
            
            // 
            // progressBar
            // 
            this.progressBar.BackColor = Color.FromArgb(52, 73, 94);
            this.progressBar.ForeColor = Color.FromArgb(39, 174, 96);
            this.progressBar.Location = new Point(20, 555);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new Size(860, 28);
            this.progressBar.Style = ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 3;
            
            // 
            // footerPanel
            // 
            this.footerPanel.BackColor = Color.FromArgb(44, 62, 80);
            this.footerPanel.Controls.Add(this.btnExit);
            this.footerPanel.Controls.Add(this.btnStart);
            this.footerPanel.Dock = DockStyle.Bottom;
            this.footerPanel.Location = new Point(0, 598);
            this.footerPanel.Name = "footerPanel";
            this.footerPanel.Size = new Size(900, 75);
            this.footerPanel.TabIndex = 4;
            
            // 
            // btnStart
            // 
            this.btnStart.BackColor = Color.FromArgb(39, 174, 96);
            this.btnStart.Cursor = Cursors.Hand;
            this.btnStart.FlatAppearance.BorderSize = 0;
            this.btnStart.FlatStyle = FlatStyle.Flat;
            this.btnStart.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            this.btnStart.ForeColor = Color.White;
            this.btnStart.Location = new Point(300, 13);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new Size(230, 50);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "▶ İşlemleri Başlat";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            this.btnStart.MouseEnter += delegate { this.btnStart.BackColor = Color.FromArgb(46, 204, 113); };
            this.btnStart.MouseLeave += delegate { this.btnStart.BackColor = Color.FromArgb(39, 174, 96); };
            
            // 
            // btnExit
            // 
            this.btnExit.BackColor = Color.FromArgb(192, 57, 43);
            this.btnExit.Cursor = Cursors.Hand;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = FlatStyle.Flat;
            this.btnExit.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            this.btnExit.ForeColor = Color.White;
            this.btnExit.Location = new Point(550, 13);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new Size(130, 50);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "✖ Çıkış";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            this.btnExit.MouseEnter += delegate { this.btnExit.BackColor = Color.FromArgb(231, 76, 60); };
            this.btnExit.MouseLeave += delegate { this.btnExit.BackColor = Color.FromArgb(192, 57, 43); };
            
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(52, 73, 94);
            this.ClientSize = new Size(900, 673);
            this.Controls.Add(this.footerPanel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.optionsPanel);
            this.Controls.Add(this.headerPanel);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "FM26 Patch Fixer v1.0";
            
            // Gömülü ikonu yükle
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            var iconStream = assembly.GetManifestResourceStream("FM26Patcher.fm26fixer.ico");
            if (iconStream != null)
            {
                this.Icon = new System.Drawing.Icon(iconStream);
            }
            
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.footerPanel.ResumeLayout(false);
            this.optionsPanel.ResumeLayout(false);
            this.optionsPanel.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}
