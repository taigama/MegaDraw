using System;
using System.Drawing;
using System.Windows.Forms;
namespace _14520404_Paint
{
    

    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolItemBtnOpen = new System.Windows.Forms.ToolStripButton();
            this.toolItemBtnNew = new System.Windows.Forms.ToolStripButton();
            this.toolItemBtnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolItemCbSize = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolItemColor = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusItemMousePost = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnBackGround = new System.Windows.Forms.Panel();
            this.ucDrawing2 = new _14520404_Paint.ucDrawing();
            this.ucDrawing1 = new _14520404_Paint.ucDrawing();
            this.pnPaint = new _14520404_Paint.PanelK();
            this.pnDrawing = new _14520404_Paint.PanelDrawing();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.pnBackGround.SuspendLayout();
            this.pnPaint.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFile,
            this.menuItemAbout});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(853, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuItemFile
            // 
            this.menuItemFile.Name = "menuItemFile";
            this.menuItemFile.Size = new System.Drawing.Size(44, 24);
            this.menuItemFile.Text = "File";
            // 
            // menuItemAbout
            // 
            this.menuItemAbout.Name = "menuItemAbout";
            this.menuItemAbout.Size = new System.Drawing.Size(62, 24);
            this.menuItemAbout.Text = "About";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolItemBtnOpen,
            this.toolItemBtnNew,
            this.toolItemBtnSave,
            this.toolStripSeparator1,
            this.toolItemCbSize,
            this.toolStripSeparator2,
            this.toolItemColor});
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(853, 35);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolItemBtnOpen
            // 
            this.toolItemBtnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolItemBtnOpen.Image = ((System.Drawing.Image)(resources.GetObject("toolItemBtnOpen.Image")));
            this.toolItemBtnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolItemBtnOpen.Name = "toolItemBtnOpen";
            this.toolItemBtnOpen.Size = new System.Drawing.Size(32, 32);
            this.toolItemBtnOpen.Text = "Open a image";
            this.toolItemBtnOpen.Click += new System.EventHandler(this.toolItemBtnOpen_Click);
            // 
            // toolItemBtnNew
            // 
            this.toolItemBtnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolItemBtnNew.Image = ((System.Drawing.Image)(resources.GetObject("toolItemBtnNew.Image")));
            this.toolItemBtnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolItemBtnNew.Name = "toolItemBtnNew";
            this.toolItemBtnNew.Size = new System.Drawing.Size(32, 32);
            this.toolItemBtnNew.Text = "New image";
            this.toolItemBtnNew.Click += new System.EventHandler(this.toolItemBtnNew_Click);
            // 
            // toolItemBtnSave
            // 
            this.toolItemBtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolItemBtnSave.Image = ((System.Drawing.Image)(resources.GetObject("toolItemBtnSave.Image")));
            this.toolItemBtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolItemBtnSave.Name = "toolItemBtnSave";
            this.toolItemBtnSave.Size = new System.Drawing.Size(32, 32);
            this.toolItemBtnSave.Text = "Save this image";
            this.toolItemBtnSave.Click += new System.EventHandler(this.toolItemBtnSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 35);
            // 
            // toolItemCbSize
            // 
            this.toolItemCbSize.AutoSize = false;
            this.toolItemCbSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolItemCbSize.DropDownWidth = 50;
            this.toolItemCbSize.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15"});
            this.toolItemCbSize.Name = "toolItemCbSize";
            this.toolItemCbSize.Size = new System.Drawing.Size(50, 28);
            this.toolItemCbSize.ToolTipText = "Size of brush";
            this.toolItemCbSize.SelectedIndexChanged += new System.EventHandler(this.toolItemCbSize_SelectedIndexChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 35);
            // 
            // toolItemColor
            // 
            this.toolItemColor.BackColor = System.Drawing.Color.White;
            this.toolItemColor.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toolItemColor.BackgroundImage")));
            this.toolItemColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolItemColor.ForeColor = System.Drawing.Color.Black;
            this.toolItemColor.Image = ((System.Drawing.Image)(resources.GetObject("toolItemColor.Image")));
            this.toolItemColor.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.toolItemColor.Name = "toolItemColor";
            this.toolItemColor.Size = new System.Drawing.Size(32, 32);
            this.toolItemColor.Text = "Pick a color for brush";
            this.toolItemColor.Click += new System.EventHandler(this.toolItemColor_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusItemMousePost});
            this.statusStrip1.Location = new System.Drawing.Point(0, 576);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(853, 25);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusItemMousePost
            // 
            this.statusItemMousePost.Name = "statusItemMousePost";
            this.statusItemMousePost.Size = new System.Drawing.Size(105, 20);
            this.statusItemMousePost.Text = "Mouse Postion";
            this.statusItemMousePost.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnBackGround
            // 
            this.pnBackGround.AutoScroll = true;
            this.pnBackGround.BackColor = System.Drawing.Color.Silver;
            this.pnBackGround.Controls.Add(this.ucDrawing2);
            this.pnBackGround.Controls.Add(this.ucDrawing1);
            this.pnBackGround.Controls.Add(this.pnPaint);
            this.pnBackGround.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnBackGround.ForeColor = System.Drawing.Color.Black;
            this.pnBackGround.Location = new System.Drawing.Point(0, 63);
            this.pnBackGround.Name = "pnBackGround";
            this.pnBackGround.Size = new System.Drawing.Size(853, 513);
            this.pnBackGround.TabIndex = 4;
            // 
            // ucDrawing2
            // 
            this.ucDrawing2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ucDrawing2.BackColor = System.Drawing.Color.Black;
            this.ucDrawing2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ucDrawing2.Location = new System.Drawing.Point(344, 32);
            this.ucDrawing2.Name = "ucDrawing2";
            this.ucDrawing2.Size = new System.Drawing.Size(462, 401);
            this.ucDrawing2.TabIndex = 4;
            // 
            // ucDrawing1
            // 
            this.ucDrawing1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ucDrawing1.BackColor = System.Drawing.Color.Transparent;
            this.ucDrawing1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ucDrawing1.Location = new System.Drawing.Point(309, 5);
            this.ucDrawing1.Name = "ucDrawing1";
            this.ucDrawing1.Size = new System.Drawing.Size(532, 467);
            this.ucDrawing1.TabIndex = 0;
            // 
            // pnPaint
            // 
            this.pnPaint.BackColor = System.Drawing.Color.Transparent;
            this.pnPaint.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnPaint.Controls.Add(this.pnDrawing);
            this.pnPaint.Location = new System.Drawing.Point(3, 3);
            this.pnPaint.Name = "pnPaint";
            this.pnPaint.Size = new System.Drawing.Size(300, 300);
            this.pnPaint.TabIndex = 3;
            // 
            // pnDrawing
            // 
            this.pnDrawing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnDrawing.Location = new System.Drawing.Point(0, 0);
            this.pnDrawing.Name = "pnDrawing";
            this.pnDrawing.Size = new System.Drawing.Size(296, 296);
            this.pnDrawing.TabIndex = 4;
            // 
            // Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(853, 601);
            this.Controls.Add(this.pnBackGround);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "IT008.H21_14520404_Paint";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.pnBackGround.ResumeLayout(false);
            this.pnPaint.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuItemFile;
        private System.Windows.Forms.ToolStripMenuItem menuItemAbout;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolItemBtnNew;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private _14520404_Paint.PanelK pnPaint;
        private System.Windows.Forms.ToolStripStatusLabel statusItemMousePost;
        private System.Windows.Forms.Panel pnBackGround;
        private ToolStripButton toolItemBtnOpen;
        private ToolStripButton toolItemBtnSave;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripComboBox toolItemCbSize;
        private ToolStripButton toolItemColor;
        private ToolStripSeparator toolStripSeparator2;
        private _14520404_Paint.PanelDrawing pnDrawing;
        private ucDrawing ucDrawing1;
        private ucDrawing ucDrawing2;
    }
    

}

