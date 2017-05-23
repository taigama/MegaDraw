namespace _14520404_Paint
{
    partial class DrawingControl
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



        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DrawingControl));
            this.pnPaint = new _14520404_Paint.PanelK();
            this.SuspendLayout();
            // 
            // pnPaint
            // 
            this.pnPaint.BackColor = System.Drawing.Color.Transparent;
            this.pnPaint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnPaint.BackgroundImage")));
            this.pnPaint.Cursor = System.Windows.Forms.Cursors.Cross;
            this.pnPaint.Location = new System.Drawing.Point(0, 0);
            this.pnPaint.Name = "pnPaint";
            this.pnPaint.Size = new System.Drawing.Size(300, 300);
            this.pnPaint.TabIndex = 1;
            // 
            // DrawingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Black;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.pnPaint);
            this.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.Name = "DrawingControl";
            this.Size = new System.Drawing.Size(555, 429);
            this.ResumeLayout(false);

        }

        #endregion

        public PanelK pnPaint;
    }
}
