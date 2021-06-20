namespace ResponsiveDesign
{
    partial class BackupAndRestore
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackupAndRestore));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.textBox1 = new Guna.UI.WinForms.GunaTextBox();
            this.BackupButton = new Guna.UI.WinForms.GunaGradientButton();
            this.gunaGradientButton1 = new Guna.UI.WinForms.GunaGradientButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel1 = new ns1.BunifuCustomLabel();
            this.bunifuImageButton1 = new ns1.BunifuImageButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(682, 397);
            this.panel1.TabIndex = 12;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(11, 118);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(658, 159);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.textBox1);
            this.panel4.Controls.Add(this.BackupButton);
            this.panel4.Controls.Add(this.gunaGradientButton1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 278);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(682, 119);
            this.panel4.TabIndex = 24;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BaseColor = System.Drawing.Color.White;
            this.textBox1.BorderColor = System.Drawing.Color.Silver;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox1.Enabled = false;
            this.textBox1.FocusedBaseColor = System.Drawing.Color.White;
            this.textBox1.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.textBox1.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBox1.Location = new System.Drawing.Point(10, 10);
            this.textBox1.Name = "textBox1";
            this.textBox1.PasswordChar = '\0';
            this.textBox1.SelectedText = "";
            this.textBox1.Size = new System.Drawing.Size(658, 32);
            this.textBox1.TabIndex = 22;
            // 
            // BackupButton
            // 
            this.BackupButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BackupButton.AnimationHoverSpeed = 0.07F;
            this.BackupButton.AnimationSpeed = 0.03F;
            this.BackupButton.BackColor = System.Drawing.Color.Transparent;
            this.BackupButton.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(183)))), ((int)(((byte)(41)))));
            this.BackupButton.BaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(183)))), ((int)(((byte)(41)))));
            this.BackupButton.BorderColor = System.Drawing.Color.Black;
            this.BackupButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.BackupButton.Enabled = false;
            this.BackupButton.FocusedColor = System.Drawing.Color.Empty;
            this.BackupButton.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BackupButton.ForeColor = System.Drawing.Color.White;
            this.BackupButton.Image = ((System.Drawing.Image)(resources.GetObject("BackupButton.Image")));
            this.BackupButton.ImageSize = new System.Drawing.Size(20, 20);
            this.BackupButton.Location = new System.Drawing.Point(268, 57);
            this.BackupButton.Name = "BackupButton";
            this.BackupButton.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(183)))), ((int)(((byte)(41)))));
            this.BackupButton.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(183)))), ((int)(((byte)(41)))));
            this.BackupButton.OnHoverBorderColor = System.Drawing.Color.Black;
            this.BackupButton.OnHoverForeColor = System.Drawing.Color.White;
            this.BackupButton.OnHoverImage = null;
            this.BackupButton.OnPressedColor = System.Drawing.Color.Black;
            this.BackupButton.Radius = 5;
            this.BackupButton.Size = new System.Drawing.Size(197, 51);
            this.BackupButton.TabIndex = 23;
            this.BackupButton.Text = "BACKUP";
            this.BackupButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BackupButton.Click += new System.EventHandler(this.BackupButton_Click);
            // 
            // gunaGradientButton1
            // 
            this.gunaGradientButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaGradientButton1.AnimationHoverSpeed = 0.07F;
            this.gunaGradientButton1.AnimationSpeed = 0.03F;
            this.gunaGradientButton1.BackColor = System.Drawing.Color.Transparent;
            this.gunaGradientButton1.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(183)))), ((int)(((byte)(41)))));
            this.gunaGradientButton1.BaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(183)))), ((int)(((byte)(41)))));
            this.gunaGradientButton1.BorderColor = System.Drawing.Color.Black;
            this.gunaGradientButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaGradientButton1.FocusedColor = System.Drawing.Color.Empty;
            this.gunaGradientButton1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaGradientButton1.ForeColor = System.Drawing.Color.White;
            this.gunaGradientButton1.Image = ((System.Drawing.Image)(resources.GetObject("gunaGradientButton1.Image")));
            this.gunaGradientButton1.ImageSize = new System.Drawing.Size(20, 20);
            this.gunaGradientButton1.Location = new System.Drawing.Point(471, 57);
            this.gunaGradientButton1.Name = "gunaGradientButton1";
            this.gunaGradientButton1.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(183)))), ((int)(((byte)(41)))));
            this.gunaGradientButton1.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(183)))), ((int)(((byte)(41)))));
            this.gunaGradientButton1.OnHoverBorderColor = System.Drawing.Color.Black;
            this.gunaGradientButton1.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaGradientButton1.OnHoverImage = null;
            this.gunaGradientButton1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaGradientButton1.Radius = 5;
            this.gunaGradientButton1.Size = new System.Drawing.Size(197, 51);
            this.gunaGradientButton1.TabIndex = 21;
            this.gunaGradientButton1.Text = "BROWSE";
            this.gunaGradientButton1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.gunaGradientButton1.Click += new System.EventHandler(this.gunaGradientButton1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(183)))), ((int)(((byte)(41)))));
            this.panel2.Controls.Add(this.bunifuCustomLabel1);
            this.panel2.Controls.Add(this.bunifuImageButton1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 55);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(682, 48);
            this.panel2.TabIndex = 13;
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold);
            this.bunifuCustomLabel1.ForeColor = System.Drawing.Color.White;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(3, 6);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(333, 37);
            this.bunifuCustomLabel1.TabIndex = 12;
            this.bunifuCustomLabel1.Text = "BACKUP";
            // 
            // bunifuImageButton1
            // 
            this.bunifuImageButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuImageButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(183)))), ((int)(((byte)(41)))));
            this.bunifuImageButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuImageButton1.Image = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton1.Image")));
            this.bunifuImageButton1.ImageActive = null;
            this.bunifuImageButton1.Location = new System.Drawing.Point(633, 1);
            this.bunifuImageButton1.Name = "bunifuImageButton1";
            this.bunifuImageButton1.Size = new System.Drawing.Size(44, 47);
            this.bunifuImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton1.TabIndex = 10;
            this.bunifuImageButton1.TabStop = false;
            this.bunifuImageButton1.Zoom = 10;
            this.bunifuImageButton1.Click += new System.EventHandler(this.bunifuImageButton1_Click_1);
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(682, 55);
            this.panel3.TabIndex = 12;
            // 
            // BackupAndRestore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 397);
            this.Controls.Add(this.panel1);
            this.Name = "BackupAndRestore";
            this.Text = "BackupAndRestore";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private ns1.BunifuCustomLabel bunifuCustomLabel1;
        private ns1.BunifuImageButton bunifuImageButton1;
        private System.Windows.Forms.Panel panel3;
        private Guna.UI.WinForms.GunaGradientButton BackupButton;
        private Guna.UI.WinForms.GunaTextBox textBox1;
        private Guna.UI.WinForms.GunaGradientButton gunaGradientButton1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}