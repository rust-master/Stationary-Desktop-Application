namespace ResponsiveDesign
{
    partial class StockViewChart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockViewChart));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.gunaGradient2Panel1 = new Guna.UI.WinForms.GunaGradient2Panel();
            this.bunifuCustomLabel8 = new ns1.BunifuCustomLabel();
            this.bunifuImageButton2 = new ns1.BunifuImageButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SaleByYearChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.gunaGradient2Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton2)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SaleByYearChart)).BeginInit();
            this.SuspendLayout();
            // 
            // gunaGradient2Panel1
            // 
            this.gunaGradient2Panel1.BackColor = System.Drawing.Color.Transparent;
            this.gunaGradient2Panel1.Controls.Add(this.bunifuCustomLabel8);
            this.gunaGradient2Panel1.Controls.Add(this.bunifuImageButton2);
            this.gunaGradient2Panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gunaGradient2Panel1.GradientColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(206)))), ((int)(((byte)(68)))));
            this.gunaGradient2Panel1.GradientColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(183)))), ((int)(((byte)(41)))));
            this.gunaGradient2Panel1.Location = new System.Drawing.Point(0, 0);
            this.gunaGradient2Panel1.Name = "gunaGradient2Panel1";
            this.gunaGradient2Panel1.Size = new System.Drawing.Size(1373, 48);
            this.gunaGradient2Panel1.TabIndex = 22;
            this.gunaGradient2Panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gunaGradient2Panel1_MouseDown);
            // 
            // bunifuCustomLabel8
            // 
            this.bunifuCustomLabel8.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel8.ForeColor = System.Drawing.Color.White;
            this.bunifuCustomLabel8.Location = new System.Drawing.Point(7, 4);
            this.bunifuCustomLabel8.Name = "bunifuCustomLabel8";
            this.bunifuCustomLabel8.Size = new System.Drawing.Size(311, 37);
            this.bunifuCustomLabel8.TabIndex = 37;
            this.bunifuCustomLabel8.Text = "STOCK VIEW CHART";
            // 
            // bunifuImageButton2
            // 
            this.bunifuImageButton2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuImageButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(183)))), ((int)(((byte)(41)))));
            this.bunifuImageButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuImageButton2.Image = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton2.Image")));
            this.bunifuImageButton2.ImageActive = null;
            this.bunifuImageButton2.Location = new System.Drawing.Point(1326, 2);
            this.bunifuImageButton2.Name = "bunifuImageButton2";
            this.bunifuImageButton2.Size = new System.Drawing.Size(44, 45);
            this.bunifuImageButton2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton2.TabIndex = 10;
            this.bunifuImageButton2.TabStop = false;
            this.bunifuImageButton2.Zoom = 10;
            this.bunifuImageButton2.Click += new System.EventHandler(this.bunifuImageButton2_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.SaleByYearChart);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1373, 822);
            this.panel2.TabIndex = 21;
            // 
            // SaleByYearChart
            // 
            this.SaleByYearChart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(206)))), ((int)(((byte)(68)))));
            this.SaleByYearChart.BorderSkin.BorderColor = System.Drawing.Color.White;
            chartArea1.BackColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.SaleByYearChart.ChartAreas.Add(chartArea1);
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend1.ForeColor = System.Drawing.Color.White;
            legend1.HeaderSeparatorColor = System.Drawing.Color.White;
            legend1.IsTextAutoFit = false;
            legend1.ItemColumnSeparatorColor = System.Drawing.Color.White;
            legend1.Name = "Legend1";
            legend1.Title = "STOCK CHART";
            legend1.TitleBackColor = System.Drawing.Color.Transparent;
            legend1.TitleFont = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend1.TitleForeColor = System.Drawing.Color.White;
            legend1.TitleSeparatorColor = System.Drawing.Color.White;
            this.SaleByYearChart.Legends.Add(legend1);
            this.SaleByYearChart.Location = new System.Drawing.Point(0, 48);
            this.SaleByYearChart.Name = "SaleByYearChart";
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(183)))), ((int)(((byte)(41)))));
            series1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            series1.IsValueShownAsLabel = true;
            series1.LabelBackColor = System.Drawing.Color.Transparent;
            series1.LabelForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            series1.Legend = "Legend1";
            series1.MarkerColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(183)))), ((int)(((byte)(41)))));
            series1.Name = "Products";
            this.SaleByYearChart.Series.Add(series1);
            this.SaleByYearChart.Size = new System.Drawing.Size(1373, 774);
            this.SaleByYearChart.TabIndex = 1;
            this.SaleByYearChart.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SaleByYearChart_MouseDown);
            // 
            // StockViewChart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(1373, 822);
            this.Controls.Add(this.gunaGradient2Panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StockViewChart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StockViewChart";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StockViewChart_FormClosing);
            this.Load += new System.EventHandler(this.StockViewChart_Load);
            this.gunaGradient2Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton2)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SaleByYearChart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaGradient2Panel gunaGradient2Panel1;
        private ns1.BunifuCustomLabel bunifuCustomLabel8;
        private ns1.BunifuImageButton bunifuImageButton2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataVisualization.Charting.Chart SaleByYearChart;
    }
}