namespace ResponsiveDesign
{
    partial class AddBrand
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddBrand));
            this.panel1 = new System.Windows.Forms.Panel();
            this.bunifuCustomLabel1 = new ns1.BunifuCustomLabel();
            this.bunifuImageButton1 = new ns1.BunifuImageButton();
            this.texBoXBrandName = new ns1.BunifuMaterialTextbox();
            this.bunifuSaveBtn = new ns1.BunifuFlatButton();
            this.txtBoxBrandDesc = new ns1.BunifuMaterialTextbox();
            this.bunifuFlatButton2 = new ns1.BunifuFlatButton();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.bunifuCustomLabel2 = new ns1.BunifuCustomLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(183)))), ((int)(((byte)(41)))));
            this.panel1.Controls.Add(this.bunifuCustomLabel1);
            this.panel1.Controls.Add(this.bunifuImageButton1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(848, 52);
            this.panel1.TabIndex = 8;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // bunifuCustomLabel1
            // 
            this.bunifuCustomLabel1.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold);
            this.bunifuCustomLabel1.ForeColor = System.Drawing.Color.White;
            this.bunifuCustomLabel1.Location = new System.Drawing.Point(7, 8);
            this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
            this.bunifuCustomLabel1.Size = new System.Drawing.Size(155, 37);
            this.bunifuCustomLabel1.TabIndex = 13;
            this.bunifuCustomLabel1.Text = "BRANDS";
            // 
            // bunifuImageButton1
            // 
            this.bunifuImageButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuImageButton1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuImageButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuImageButton1.Image = ((System.Drawing.Image)(resources.GetObject("bunifuImageButton1.Image")));
            this.bunifuImageButton1.ImageActive = null;
            this.bunifuImageButton1.Location = new System.Drawing.Point(801, 3);
            this.bunifuImageButton1.Name = "bunifuImageButton1";
            this.bunifuImageButton1.Size = new System.Drawing.Size(44, 47);
            this.bunifuImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton1.TabIndex = 5;
            this.bunifuImageButton1.TabStop = false;
            this.bunifuImageButton1.Zoom = 10;
            this.bunifuImageButton1.Click += new System.EventHandler(this.bunifuImageButton1_Click);
            // 
            // texBoXBrandName
            // 
            this.texBoXBrandName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.texBoXBrandName.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.texBoXBrandName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(183)))), ((int)(((byte)(41)))));
            this.texBoXBrandName.HintForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(183)))), ((int)(((byte)(41)))));
            this.texBoXBrandName.HintText = "Brand Name";
            this.texBoXBrandName.isPassword = false;
            this.texBoXBrandName.LineFocusedColor = System.Drawing.Color.White;
            this.texBoXBrandName.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(183)))), ((int)(((byte)(41)))));
            this.texBoXBrandName.LineMouseHoverColor = System.Drawing.Color.White;
            this.texBoXBrandName.LineThickness = 4;
            this.texBoXBrandName.Location = new System.Drawing.Point(23, 23);
            this.texBoXBrandName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.texBoXBrandName.Name = "texBoXBrandName";
            this.texBoXBrandName.Size = new System.Drawing.Size(292, 59);
            this.texBoXBrandName.TabIndex = 2;
            this.texBoXBrandName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.texBoXBrandName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.texBoXBrandName_KeyPress);
            // 
            // bunifuSaveBtn
            // 
            this.bunifuSaveBtn.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(183)))), ((int)(((byte)(41)))));
            this.bunifuSaveBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(183)))), ((int)(((byte)(41)))));
            this.bunifuSaveBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuSaveBtn.BorderRadius = 7;
            this.bunifuSaveBtn.ButtonText = "SAVE";
            this.bunifuSaveBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuSaveBtn.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuSaveBtn.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuSaveBtn.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuSaveBtn.Iconimage = null;
            this.bunifuSaveBtn.Iconimage_right = null;
            this.bunifuSaveBtn.Iconimage_right_Selected = null;
            this.bunifuSaveBtn.Iconimage_Selected = null;
            this.bunifuSaveBtn.IconMarginLeft = 0;
            this.bunifuSaveBtn.IconMarginRight = 0;
            this.bunifuSaveBtn.IconRightVisible = false;
            this.bunifuSaveBtn.IconRightZoom = 0D;
            this.bunifuSaveBtn.IconVisible = false;
            this.bunifuSaveBtn.IconZoom = 90D;
            this.bunifuSaveBtn.IsTab = false;
            this.bunifuSaveBtn.Location = new System.Drawing.Point(572, 319);
            this.bunifuSaveBtn.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.bunifuSaveBtn.Name = "bunifuSaveBtn";
            this.bunifuSaveBtn.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(183)))), ((int)(((byte)(41)))));
            this.bunifuSaveBtn.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.bunifuSaveBtn.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuSaveBtn.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuSaveBtn.selected = false;
            this.bunifuSaveBtn.Size = new System.Drawing.Size(184, 51);
            this.bunifuSaveBtn.TabIndex = 7;
            this.bunifuSaveBtn.Text = "SAVE";
            this.bunifuSaveBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuSaveBtn.Textcolor = System.Drawing.Color.White;
            this.bunifuSaveBtn.TextFont = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuSaveBtn.Click += new System.EventHandler(this.bunifuSaveBtn_Click);
            // 
            // txtBoxBrandDesc
            // 
            this.txtBoxBrandDesc.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBoxBrandDesc.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxBrandDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(183)))), ((int)(((byte)(41)))));
            this.txtBoxBrandDesc.HintForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(183)))), ((int)(((byte)(41)))));
            this.txtBoxBrandDesc.HintText = "Description";
            this.txtBoxBrandDesc.isPassword = false;
            this.txtBoxBrandDesc.LineFocusedColor = System.Drawing.Color.White;
            this.txtBoxBrandDesc.LineIdleColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(183)))), ((int)(((byte)(41)))));
            this.txtBoxBrandDesc.LineMouseHoverColor = System.Drawing.Color.White;
            this.txtBoxBrandDesc.LineThickness = 4;
            this.txtBoxBrandDesc.Location = new System.Drawing.Point(23, 119);
            this.txtBoxBrandDesc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtBoxBrandDesc.Name = "txtBoxBrandDesc";
            this.txtBoxBrandDesc.Size = new System.Drawing.Size(733, 59);
            this.txtBoxBrandDesc.TabIndex = 9;
            this.txtBoxBrandDesc.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // bunifuFlatButton2
            // 
            this.bunifuFlatButton2.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(183)))), ((int)(((byte)(41)))));
            this.bunifuFlatButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(183)))), ((int)(((byte)(41)))));
            this.bunifuFlatButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton2.BorderRadius = 7;
            this.bunifuFlatButton2.ButtonText = "UPDATE";
            this.bunifuFlatButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bunifuFlatButton2.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuFlatButton2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuFlatButton2.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton2.Iconimage = null;
            this.bunifuFlatButton2.Iconimage_right = null;
            this.bunifuFlatButton2.Iconimage_right_Selected = null;
            this.bunifuFlatButton2.Iconimage_Selected = null;
            this.bunifuFlatButton2.IconMarginLeft = 0;
            this.bunifuFlatButton2.IconMarginRight = 0;
            this.bunifuFlatButton2.IconRightVisible = false;
            this.bunifuFlatButton2.IconRightZoom = 0D;
            this.bunifuFlatButton2.IconVisible = false;
            this.bunifuFlatButton2.IconZoom = 90D;
            this.bunifuFlatButton2.IsTab = false;
            this.bunifuFlatButton2.Location = new System.Drawing.Point(347, 319);
            this.bunifuFlatButton2.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.bunifuFlatButton2.Name = "bunifuFlatButton2";
            this.bunifuFlatButton2.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(183)))), ((int)(((byte)(41)))));
            this.bunifuFlatButton2.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(59)))), ((int)(((byte)(59)))));
            this.bunifuFlatButton2.OnHoverTextColor = System.Drawing.Color.White;
            this.bunifuFlatButton2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuFlatButton2.selected = false;
            this.bunifuFlatButton2.Size = new System.Drawing.Size(184, 51);
            this.bunifuFlatButton2.TabIndex = 10;
            this.bunifuFlatButton2.Text = "UPDATE";
            this.bunifuFlatButton2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuFlatButton2.Textcolor = System.Drawing.Color.White;
            this.bunifuFlatButton2.TextFont = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuFlatButton2.Click += new System.EventHandler(this.bunifuFlatButton2_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(183)))), ((int)(((byte)(41)))));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox1.ForeColor = System.Drawing.Color.White;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(194, 220);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(249, 36);
            this.comboBox1.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.bunifuCustomLabel2);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.bunifuFlatButton2);
            this.panel2.Controls.Add(this.txtBoxBrandDesc);
            this.panel2.Controls.Add(this.bunifuSaveBtn);
            this.panel2.Controls.Add(this.texBoXBrandName);
            this.panel2.Location = new System.Drawing.Point(26, 94);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(791, 400);
            this.panel2.TabIndex = 9;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(140, 353);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "asas";
            this.label1.Visible = false;
            // 
            // bunifuCustomLabel2
            // 
            this.bunifuCustomLabel2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuCustomLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(183)))), ((int)(((byte)(41)))));
            this.bunifuCustomLabel2.Location = new System.Drawing.Point(18, 226);
            this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
            this.bunifuCustomLabel2.Size = new System.Drawing.Size(160, 37);
            this.bunifuCustomLabel2.TabIndex = 14;
            this.bunifuCustomLabel2.Text = "Company Name";
            // 
            // AddBrand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(30)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(848, 506);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddBrand";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddBrand";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddBrand_FormClosing);
            this.Load += new System.EventHandler(this.AddBrand_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AddBrand_MouseDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private ns1.BunifuCustomLabel bunifuCustomLabel1;
        private ns1.BunifuImageButton bunifuImageButton1;
        public ns1.BunifuMaterialTextbox texBoXBrandName;
        public ns1.BunifuFlatButton bunifuSaveBtn;
        public ns1.BunifuMaterialTextbox txtBoxBrandDesc;
        public ns1.BunifuFlatButton bunifuFlatButton2;
        private System.Windows.Forms.Panel panel2;
        private ns1.BunifuCustomLabel bunifuCustomLabel2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox comboBox1;
    }
}