namespace ResponsiveDesign
{
    partial class RestoreAndBackUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RestoreAndBackUp));
            this.panel2 = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel1 = new ns1.BunifuCustomLabel();
            this.bunifuImageButton1 = new ns1.BunifuImageButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.restoreButton = new Guna.UI.WinForms.GunaGradientButton();
            this.textBox2 = new Guna.UI.WinForms.GunaTextBox();
            this.gunaGradientButton4 = new Guna.UI.WinForms.GunaGradientButton();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
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
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(147, 37);
            this.bunifuCustomLabel1.TabIndex = 12;
            this.bunifuCustomLabel1.Text = "RESTORE";
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
            this.bunifuImageButton1.Click += new System.EventHandler(this.bunifuImageButton1_Click);
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(682, 55);
            this.panel3.TabIndex = 12;
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
            this.panel1.TabIndex = 13;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 116);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(658, 159);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.restoreButton);
            this.panel4.Controls.Add(this.textBox2);
            this.panel4.Controls.Add(this.gunaGradientButton4);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 275);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(682, 122);
            this.panel4.TabIndex = 24;
            // 
            // restoreButton
            // 
            this.restoreButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.restoreButton.AnimationHoverSpeed = 0.07F;
            this.restoreButton.AnimationSpeed = 0.03F;
            this.restoreButton.BackColor = System.Drawing.Color.Transparent;
            this.restoreButton.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(183)))), ((int)(((byte)(41)))));
            this.restoreButton.BaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(183)))), ((int)(((byte)(41)))));
            this.restoreButton.BorderColor = System.Drawing.Color.Black;
            this.restoreButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.restoreButton.Enabled = false;
            this.restoreButton.FocusedColor = System.Drawing.Color.Empty;
            this.restoreButton.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.restoreButton.ForeColor = System.Drawing.Color.White;
            this.restoreButton.Image = ((System.Drawing.Image)(resources.GetObject("restoreButton.Image")));
            this.restoreButton.ImageSize = new System.Drawing.Size(20, 20);
            this.restoreButton.Location = new System.Drawing.Point(270, 58);
            this.restoreButton.Name = "restoreButton";
            this.restoreButton.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(183)))), ((int)(((byte)(41)))));
            this.restoreButton.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(183)))), ((int)(((byte)(41)))));
            this.restoreButton.OnHoverBorderColor = System.Drawing.Color.Black;
            this.restoreButton.OnHoverForeColor = System.Drawing.Color.White;
            this.restoreButton.OnHoverImage = null;
            this.restoreButton.OnPressedColor = System.Drawing.Color.Black;
            this.restoreButton.Radius = 5;
            this.restoreButton.Size = new System.Drawing.Size(197, 51);
            this.restoreButton.TabIndex = 26;
            this.restoreButton.Text = "RESTORE";
            this.restoreButton.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.restoreButton.Click += new System.EventHandler(this.restoreButton_Click);
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.BaseColor = System.Drawing.Color.White;
            this.textBox2.BorderColor = System.Drawing.Color.Silver;
            this.textBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox2.Enabled = false;
            this.textBox2.FocusedBaseColor = System.Drawing.Color.White;
            this.textBox2.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(88)))), ((int)(((byte)(255)))));
            this.textBox2.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textBox2.Location = new System.Drawing.Point(12, 11);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '\0';
            this.textBox2.SelectedText = "";
            this.textBox2.Size = new System.Drawing.Size(658, 32);
            this.textBox2.TabIndex = 25;
            // 
            // gunaGradientButton4
            // 
            this.gunaGradientButton4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gunaGradientButton4.AnimationHoverSpeed = 0.07F;
            this.gunaGradientButton4.AnimationSpeed = 0.03F;
            this.gunaGradientButton4.BackColor = System.Drawing.Color.Transparent;
            this.gunaGradientButton4.BaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(183)))), ((int)(((byte)(41)))));
            this.gunaGradientButton4.BaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(183)))), ((int)(((byte)(41)))));
            this.gunaGradientButton4.BorderColor = System.Drawing.Color.Black;
            this.gunaGradientButton4.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaGradientButton4.FocusedColor = System.Drawing.Color.Empty;
            this.gunaGradientButton4.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaGradientButton4.ForeColor = System.Drawing.Color.White;
            this.gunaGradientButton4.Image = ((System.Drawing.Image)(resources.GetObject("gunaGradientButton4.Image")));
            this.gunaGradientButton4.ImageSize = new System.Drawing.Size(20, 20);
            this.gunaGradientButton4.Location = new System.Drawing.Point(473, 58);
            this.gunaGradientButton4.Name = "gunaGradientButton4";
            this.gunaGradientButton4.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(183)))), ((int)(((byte)(41)))));
            this.gunaGradientButton4.OnHoverBaseColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(183)))), ((int)(((byte)(41)))));
            this.gunaGradientButton4.OnHoverBorderColor = System.Drawing.Color.Black;
            this.gunaGradientButton4.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaGradientButton4.OnHoverImage = null;
            this.gunaGradientButton4.OnPressedColor = System.Drawing.Color.Black;
            this.gunaGradientButton4.Radius = 5;
            this.gunaGradientButton4.Size = new System.Drawing.Size(197, 51);
            this.gunaGradientButton4.TabIndex = 24;
            this.gunaGradientButton4.Text = "BROWSE";
            this.gunaGradientButton4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.gunaGradientButton4.Click += new System.EventHandler(this.gunaGradientButton4_Click);
            // 
            // RestoreAndBackUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 397);
            this.Controls.Add(this.panel1);
            this.Name = "RestoreAndBackUp";
            this.Text = "RestoreAndBackUp";
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private ns1.BunifuImageButton bunifuImageButton1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private Guna.UI.WinForms.GunaGradientButton restoreButton;
        private Guna.UI.WinForms.GunaTextBox textBox2;
        private Guna.UI.WinForms.GunaGradientButton gunaGradientButton4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private ns1.BunifuCustomLabel bunifuCustomLabel1;
    }
}