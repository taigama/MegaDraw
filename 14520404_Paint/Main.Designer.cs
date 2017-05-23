﻿using System;
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
            this.toolItemSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolItemBtnOpen = new System.Windows.Forms.ToolStripButton();
            this.toolItemBtnNew = new System.Windows.Forms.ToolStripButton();
            this.toolItemBtnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolItemCbSize = new System.Windows.Forms.ToolStripComboBox();
            this.toolItemDrawType = new System.Windows.Forms.ToolStripDropDownButton();
            this.itemDotSquare = new System.Windows.Forms.ToolStripMenuItem();
            this.itemDotCircle = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.itemLine = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.itemRectangle = new System.Windows.Forms.ToolStripMenuItem();
            this.itemEclipse = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolItemColorLine = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolItemColorFill = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolItemFill = new System.Windows.Forms.ToolStripDropDownButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusItemMousePost = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnBackGround = new System.Windows.Forms.Panel();
            this.pnDrawing = new _14520404_Paint.PanelDrawing();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.pnBackGround.SuspendLayout();
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
            this.menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolItemSetting});
            this.menuItemFile.Name = "menuItemFile";
            this.menuItemFile.Size = new System.Drawing.Size(44, 24);
            this.menuItemFile.Text = "File";
            // 
            // toolItemSetting
            // 
            this.toolItemSetting.Image = ((System.Drawing.Image)(resources.GetObject("toolItemSetting.Image")));
            this.toolItemSetting.Name = "toolItemSetting";
            this.toolItemSetting.Size = new System.Drawing.Size(131, 26);
            this.toolItemSetting.Text = "Setting";
            this.toolItemSetting.Click += new System.EventHandler(this.toolItemSetting_Click);
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
            this.toolItemDrawType,
            this.toolStripSeparator3,
            this.toolItemColorLine,
            this.toolStripSeparator6,
            this.toolItemFill,
            this.toolItemColorFill,
            this.toolStripSeparator2});
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
            // toolItemDrawType
            // 
            this.toolItemDrawType.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolItemDrawType.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemDotSquare,
            this.itemDotCircle,
            this.toolStripSeparator4,
            this.itemLine,
            this.toolStripSeparator5,
            this.itemRectangle,
            this.itemEclipse});
            this.toolItemDrawType.Image = ((System.Drawing.Image)(resources.GetObject("toolItemDrawType.Image")));
            this.toolItemDrawType.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolItemDrawType.Name = "toolItemDrawType";
            this.toolItemDrawType.Size = new System.Drawing.Size(42, 32);
            this.toolItemDrawType.ToolTipText = "Choose draw type";
            // 
            // itemDotSquare
            // 
            this.itemDotSquare.Image = ((System.Drawing.Image)(resources.GetObject("itemDotSquare.Image")));
            this.itemDotSquare.Name = "itemDotSquare";
            this.itemDotSquare.Size = new System.Drawing.Size(159, 26);
            this.itemDotSquare.Text = "Dot Square";
            this.itemDotSquare.Click += new System.EventHandler(this.itemDotSquare_Click);
            // 
            // itemDotCircle
            // 
            this.itemDotCircle.Image = ((System.Drawing.Image)(resources.GetObject("itemDotCircle.Image")));
            this.itemDotCircle.Name = "itemDotCircle";
            this.itemDotCircle.Size = new System.Drawing.Size(159, 26);
            this.itemDotCircle.Text = "Dot";
            this.itemDotCircle.Click += new System.EventHandler(this.itemDotCircle_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(156, 6);
            // 
            // itemLine
            // 
            this.itemLine.Image = ((System.Drawing.Image)(resources.GetObject("itemLine.Image")));
            this.itemLine.Name = "itemLine";
            this.itemLine.Size = new System.Drawing.Size(159, 26);
            this.itemLine.Text = "Line";
            this.itemLine.Click += new System.EventHandler(this.itemLine_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(156, 6);
            // 
            // itemRectangle
            // 
            this.itemRectangle.Image = ((System.Drawing.Image)(resources.GetObject("itemRectangle.Image")));
            this.itemRectangle.Name = "itemRectangle";
            this.itemRectangle.Size = new System.Drawing.Size(159, 26);
            this.itemRectangle.Text = "Rectangle";
            this.itemRectangle.Click += new System.EventHandler(this.itemRectangle_Click);
            // 
            // itemEclipse
            // 
            this.itemEclipse.Image = ((System.Drawing.Image)(resources.GetObject("itemEclipse.Image")));
            this.itemEclipse.Name = "itemEclipse";
            this.itemEclipse.Size = new System.Drawing.Size(159, 26);
            this.itemEclipse.Text = "Eclipse";
            this.itemEclipse.Click += new System.EventHandler(this.itemEclipse_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 35);
            // 
            // toolItemColorLine
            // 
            this.toolItemColorLine.BackColor = System.Drawing.Color.White;
            this.toolItemColorLine.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("toolItemColorLine.BackgroundImage")));
            this.toolItemColorLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolItemColorLine.ForeColor = System.Drawing.Color.Black;
            this.toolItemColorLine.Image = ((System.Drawing.Image)(resources.GetObject("toolItemColorLine.Image")));
            this.toolItemColorLine.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.toolItemColorLine.Name = "toolItemColorLine";
            this.toolItemColorLine.Size = new System.Drawing.Size(32, 32);
            this.toolItemColorLine.Text = "Pick color for brush";
            this.toolItemColorLine.Click += new System.EventHandler(this.toolItemColor_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 35);
            // 
            // toolItemColorFill
            // 
            this.toolItemColorFill.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolItemColorFill.Image = ((System.Drawing.Image)(resources.GetObject("toolItemColorFill.Image")));
            this.toolItemColorFill.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolItemColorFill.Name = "toolItemColorFill";
            this.toolItemColorFill.Size = new System.Drawing.Size(32, 32);
            this.toolItemColorFill.Text = "Pick color for filling";
            this.toolItemColorFill.Click += new System.EventHandler(this.toolItemColor_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 35);
            // 
            // toolItemFill
            // 
            this.toolItemFill.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolItemFill.Image = ((System.Drawing.Image)(resources.GetObject("toolItemFill.Image")));
            this.toolItemFill.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolItemFill.Name = "toolItemFill";
            this.toolItemFill.Size = new System.Drawing.Size(42, 32);
            this.toolItemFill.Text = "Choose Filling";
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
            this.pnBackGround.Controls.Add(this.pnDrawing);
            this.pnBackGround.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnBackGround.ForeColor = System.Drawing.Color.Black;
            this.pnBackGround.Location = new System.Drawing.Point(0, 63);
            this.pnBackGround.Name = "pnBackGround";
            this.pnBackGround.Size = new System.Drawing.Size(853, 513);
            this.pnBackGround.TabIndex = 4;
            // 
            // pnDrawing
            // 
            this.pnDrawing.BackColor = System.Drawing.Color.Transparent;
            this.pnDrawing.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnDrawing.BackgroundImage")));
            this.pnDrawing.Location = new System.Drawing.Point(3, 3);
            this.pnDrawing.Name = "pnDrawing";
            this.pnDrawing.Size = new System.Drawing.Size(713, 100);
            this.pnDrawing.TabIndex = 5;
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
        private System.Windows.Forms.ToolStripStatusLabel statusItemMousePost;
        private ToolStripButton toolItemBtnOpen;
        private ToolStripButton toolItemBtnSave;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripComboBox toolItemCbSize;
        private ToolStripButton toolItemColorLine;
        private ToolStripSeparator toolStripSeparator2;
        public Panel pnBackGround;
        private PanelDrawing pnDrawing;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem toolItemSetting;
        private ToolStripButton toolItemColorFill;
        private ToolStripDropDownButton toolItemDrawType;
        private ToolStripMenuItem itemDotSquare;
        private ToolStripMenuItem itemDotCircle;
        private ToolStripMenuItem itemLine;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripMenuItem itemRectangle;
        private ToolStripMenuItem itemEclipse;
        private ToolStripDropDownButton toolItemFill;
    }
    

}

