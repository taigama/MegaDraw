using System;
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
    public partial class ucDrawing : UserControl
    {
        public ucDrawing()
        {
            InitializeComponent();
            panel1.Width = this.Width - 5;
            panel1.Height = this.Height - 5;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button == MouseButtons.Left)
            {
                bIsResizing = true;
                Cursor = Cursors.SizeAll;
                oldPoint = e.Location;
                oldSize = Size;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (bIsResizing)
            {
                Height = oldSize.Height + (e.Location.Y - oldPoint.Y);
                Width = oldSize.Width + (e.Location.X - oldPoint.X);
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (e.Button == MouseButtons.Left)
            {
                bIsResizing = false;
            }
        }

        private bool bIsResizing;
        private Point oldPoint;
        private Size oldSize;

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            panel1.Width = this.Width - 10;
            panel1.Height = this.Height - 10;

        }
    }

}
