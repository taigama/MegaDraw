﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _14520404_Paint
{
    public partial class DrawingControl : UserControl
    {
        public Main host;

        public DrawingControl()
        {
            InitializeComponent();
            //pnPaint.Width = this.Width - 10;
            //pnPaint.Height = this.Height - 10;
        }

        //protected override void OnMouseDown(MouseEventArgs e)
        //{
        //    base.OnMouseDown(e);

        //    if (e.Button == MouseButtons.Left)
        //    {
        //        bIsResizing = true;
        //        Cursor = Cursors.SizeAll;
        //        oldPoint = e.Location;
        //        oldSize = Size;

        //        //////////////////
        //        //host.pnBackGround.HorizontalScroll.Enabled = false;
        //        //host.pnBackGround.VerticalScroll.Enabled = false;

        //    }
        //}

        //protected override void OnMouseMove(MouseEventArgs e)
        //{
        //    base.OnMouseMove(e);

        //    if (bIsResizing)
        //    {
        //        Height = oldSize.Height + (e.Location.Y - oldPoint.Y);
        //        Width = oldSize.Width + (e.Location.X - oldPoint.X);
        //    }
        //}

        //protected override void OnMouseUp(MouseEventArgs e)
        //{
        //    base.OnMouseUp(e);

        //    if (e.Button == MouseButtons.Left)
        //    {
        //        bIsResizing = false;

        //        ///////////////////
        //        //host.pnBackGround.HorizontalScroll.Enabled = true;
        //        //host.pnBackGround.VerticalScroll.Enabled = true;
        //    }
        //}

        private bool bIsResizing;
        private Vector2 oldPoint;
        private Size oldSize;

        //protected override void OnResize(EventArgs e)
        //{
        //    base.OnResize(e);

        //    pnPaint.Width = this.Width - 10;
        //    pnPaint.Height = this.Height - 10;

        //}
    }

}
