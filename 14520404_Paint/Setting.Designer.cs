namespace _14520404_Paint
{
    partial class Setting
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
            this.lbSetWidth = new System.Windows.Forms.Label();
            this.gbSize = new System.Windows.Forms.GroupBox();
            this.txtSetHeigh = new System.Windows.Forms.TextBox();
            this.txtSetWidth = new System.Windows.Forms.TextBox();
            this.lbSetHeigh = new System.Windows.Forms.Label();
            this.btnSetOK = new System.Windows.Forms.Button();
            this.gbImage = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnTexture = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbHatchStyle = new System.Windows.Forms.ComboBox();
            this.gbSize.SuspendLayout();
            this.gbImage.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbSetWidth
            // 
            this.lbSetWidth.AutoSize = true;
            this.lbSetWidth.Location = new System.Drawing.Point(6, 33);
            this.lbSetWidth.Name = "lbSetWidth";
            this.lbSetWidth.Size = new System.Drawing.Size(48, 17);
            this.lbSetWidth.TabIndex = 1;
            this.lbSetWidth.Text = "Width:";
            // 
            // gbSize
            // 
            this.gbSize.Controls.Add(this.txtSetHeigh);
            this.gbSize.Controls.Add(this.txtSetWidth);
            this.gbSize.Controls.Add(this.lbSetHeigh);
            this.gbSize.Controls.Add(this.lbSetWidth);
            this.gbSize.Location = new System.Drawing.Point(12, 12);
            this.gbSize.Name = "gbSize";
            this.gbSize.Size = new System.Drawing.Size(135, 96);
            this.gbSize.TabIndex = 2;
            this.gbSize.TabStop = false;
            this.gbSize.Text = "Panel size:";
            // 
            // txtSetHeigh
            // 
            this.txtSetHeigh.Location = new System.Drawing.Point(60, 59);
            this.txtSetHeigh.Name = "txtSetHeigh";
            this.txtSetHeigh.Size = new System.Drawing.Size(61, 22);
            this.txtSetHeigh.TabIndex = 2;
            this.txtSetHeigh.TextChanged += new System.EventHandler(this.txt_OnlyNumber);
            // 
            // txtSetWidth
            // 
            this.txtSetWidth.Location = new System.Drawing.Point(60, 30);
            this.txtSetWidth.Name = "txtSetWidth";
            this.txtSetWidth.Size = new System.Drawing.Size(61, 22);
            this.txtSetWidth.TabIndex = 1;
            this.txtSetWidth.TextChanged += new System.EventHandler(this.txt_OnlyNumber);
            // 
            // lbSetHeigh
            // 
            this.lbSetHeigh.AutoSize = true;
            this.lbSetHeigh.Location = new System.Drawing.Point(6, 62);
            this.lbSetHeigh.Name = "lbSetHeigh";
            this.lbSetHeigh.Size = new System.Drawing.Size(49, 17);
            this.lbSetHeigh.TabIndex = 1;
            this.lbSetHeigh.Text = "Heigh:";
            // 
            // btnSetOK
            // 
            this.btnSetOK.Location = new System.Drawing.Point(113, 210);
            this.btnSetOK.Name = "btnSetOK";
            this.btnSetOK.Size = new System.Drawing.Size(75, 23);
            this.btnSetOK.TabIndex = 20;
            this.btnSetOK.Text = "OK";
            this.btnSetOK.UseVisualStyleBackColor = true;
            this.btnSetOK.Click += new System.EventHandler(this.btnSetOK_Click);
            // 
            // gbImage
            // 
            this.gbImage.Controls.Add(this.btnTexture);
            this.gbImage.Controls.Add(this.label1);
            this.gbImage.Location = new System.Drawing.Point(153, 12);
            this.gbImage.Name = "gbImage";
            this.gbImage.Size = new System.Drawing.Size(135, 96);
            this.gbImage.TabIndex = 2;
            this.gbImage.TabStop = false;
            this.gbImage.Text = "Image:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Texture:";
            // 
            // btnTexture
            // 
            this.btnTexture.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.btnTexture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTexture.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTexture.Location = new System.Drawing.Point(72, 17);
            this.btnTexture.Name = "btnTexture";
            this.btnTexture.Size = new System.Drawing.Size(48, 48);
            this.btnTexture.TabIndex = 2;
            this.btnTexture.UseVisualStyleBackColor = true;
            this.btnTexture.Click += new System.EventHandler(this.btnTexture_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hatch style:";
            // 
            // cbHatchStyle
            // 
            this.cbHatchStyle.FormattingEnabled = true;
            this.cbHatchStyle.Location = new System.Drawing.Point(106, 117);
            this.cbHatchStyle.Name = "cbHatchStyle";
            this.cbHatchStyle.Size = new System.Drawing.Size(182, 24);
            this.cbHatchStyle.TabIndex = 3;
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 245);
            this.Controls.Add(this.cbHatchStyle);
            this.Controls.Add(this.btnSetOK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gbImage);
            this.Controls.Add(this.gbSize);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Setting";
            this.Text = "Setting";
            this.gbSize.ResumeLayout(false);
            this.gbSize.PerformLayout();
            this.gbImage.ResumeLayout(false);
            this.gbImage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbSetWidth;
        private System.Windows.Forms.GroupBox gbSize;
        private System.Windows.Forms.Label lbSetHeigh;
        private System.Windows.Forms.Button btnSetOK;
        private System.Windows.Forms.GroupBox gbImage;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnTexture;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cbHatchStyle;
        public System.Windows.Forms.TextBox txtSetHeigh;
        public System.Windows.Forms.TextBox txtSetWidth;
    }
}