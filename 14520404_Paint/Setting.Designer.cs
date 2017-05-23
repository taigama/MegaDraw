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
            this.gbSize.SuspendLayout();
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
            this.gbSize.Size = new System.Drawing.Size(135, 100);
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
            this.btnSetOK.Location = new System.Drawing.Point(90, 248);
            this.btnSetOK.Name = "btnSetOK";
            this.btnSetOK.Size = new System.Drawing.Size(75, 23);
            this.btnSetOK.TabIndex = 20;
            this.btnSetOK.Text = "OK";
            this.btnSetOK.UseVisualStyleBackColor = true;
            this.btnSetOK.Click += new System.EventHandler(this.btnSetOK_Click);
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 283);
            this.Controls.Add(this.btnSetOK);
            this.Controls.Add(this.gbSize);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Setting";
            this.Text = "Setting";
            this.gbSize.ResumeLayout(false);
            this.gbSize.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbSetWidth;
        private System.Windows.Forms.GroupBox gbSize;
        private System.Windows.Forms.TextBox txtSetHeigh;
        private System.Windows.Forms.TextBox txtSetWidth;
        private System.Windows.Forms.Label lbSetHeigh;
        private System.Windows.Forms.Button btnSetOK;
    }
}