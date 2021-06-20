namespace ResponsiveDesign.Reports
{
    partial class StockReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockReport));
            this.gunaGradient2Panel1 = new Guna.UI.WinForms.GunaGradient2Panel();
            this.bunifuImageButton1 = new ns1.BunifuImageButton();
            this.bunifuCustomLabel8 = new ns1.BunifuCustomLabel();
            this.bunifuImageButton2 = new ns1.BunifuImageButton();
            this.stockcrystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.gunaGradient2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton2)).BeginInit();
            this.SuspendLayout();
            // 
            // gunaGradient2Panel1
            // 
            this.gunaGradient2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.gunaGradient2Panel1.Controls.Add(this.bunifuImageButton1);
            this.gunaGradient2Panel1.Controls.Add(this.bunifuCustomLabel8);
            this.gunaGradient2Panel1.Controls.Add(this.bunifuImageButton2);
            this.gunaGradient2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gunaGradient2Panel1.GradientColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(206)))), ((int)(((byte)(68)))));
            this.gunaGradient2Panel1.GradientColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(183)))), ((int)(((byte)(41)))));
            this.gunaGradient2Panel1.Location = new System.Drawing.Point(0, 0);
            this.gunaGradient2Panel1.Name = "gunaGradient2Panel1";
            this.gunaGradient2Panel1.Size = new System.Drawing.Size(914, 48);
            this.gunaGradient2Panel1.TabIndex = 23;
            this.gunaGradient2Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gunaGradient2Panel1_MouseDown);
            // 
            // bunifuImageButton1
            // 
            this.bunifuImageButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuImageButton1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuImageButton1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.bunifuImageButton1.Image = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton1.Image")));
            this.bunifuImageButton1.ImageActive = null;
            this.bunifuImageButton1.Location = new System.Drawing.Point(823, 1);
            this.bunifuImageButton1.Name = "bunifuImageButton1";
            this.bunifuImageButton1.Size = new System.Drawing.Size(44, 47);
            this.bunifuImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton1.TabIndex = 39;
            this.bunifuImageButton1.TabStop = false;
            this.bunifuImageButton1.Zoom = 10;
            this.bunifuImageButton1.Click += new System.EventHandler(this.bunifuImageButton1_Click);
            // 
            // bunifuCustomLabel8
            // 
            this.bunifuCustomLabel8.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel8.ForeColor = System.Drawing.Color.White;
            this.bunifuCustomLabel8.Location = new System.Drawing.Point(7, 4);
            this.bunifuCustomLabel8.Name = "bunifuCustomLabel8";
            this.bunifuCustomLabel8.Size = new System.Drawing.Size(321, 37);
            this.bunifuCustomLabel8.TabIndex = 37;
            this.bunifuCustomLabel8.Text = "STOCK REPORT";
            // 
            // bunifuImageButton2
            // 
            this.bunifuImageButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuImageButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(183)))), ((int)(((byte)(41)))));
            this.bunifuImageButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuImageButton2.Image = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton2.Image")));
            this.bunifuImageButton2.ImageActive = null;
            this.bunifuImageButton2.Location = new System.Drawing.Point(867, 3);
            this.bunifuImageButton2.Name = "bunifuImageButton2";
            this.bunifuImageButton2.Size = new System.Drawing.Size(44, 45);
            this.bunifuImageButton2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton2.TabIndex = 10;
            this.bunifuImageButton2.TabStop = false;
            this.bunifuImageButton2.Zoom = 10;
            this.bunifuImageButton2.Click += new System.EventHandler(this.bunifuImageButton2_Click);
            // 
            // stockcrystalReportViewer1
            // 
            this.stockcrystalReportViewer1.ActiveViewIndex = -1;
            this.stockcrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.stockcrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.stockcrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stockcrystalReportViewer1.Location = new System.Drawing.Point(0, 48);
            this.stockcrystalReportViewer1.Name = "stockcrystalReportViewer1";
            this.stockcrystalReportViewer1.ShowCloseButton = false;
            this.stockcrystalReportViewer1.ShowGroupTreeButton = false;
            this.stockcrystalReportViewer1.ShowLogo = false;
            this.stockcrystalReportViewer1.ShowParameterPanelButton = false;
            this.stockcrystalReportViewer1.ShowRefreshButton = false;
            this.stockcrystalReportViewer1.Size = new System.Drawing.Size(914, 616);
            this.stockcrystalReportViewer1.TabIndex = 24;
            this.stockcrystalReportViewer1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // StockReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 664);
            this.Controls.Add(this.stockcrystalReportViewer1);
            this.Controls.Add(this.gunaGradient2Panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "StockReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StockReport";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StockReport_FormClosing);
            this.Load += new System.EventHandler(this.StockReport_Load);
            this.gunaGradient2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaGradient2Panel gunaGradient2Panel1;
        private ns1.BunifuImageButton bunifuImageButton1;
        private ns1.BunifuCustomLabel bunifuCustomLabel8;
        private ns1.BunifuImageButton bunifuImageButton2;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer stockcrystalReportViewer1;
    }
}