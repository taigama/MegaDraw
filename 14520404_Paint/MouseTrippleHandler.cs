using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _14520404_Paint
{
    public class MouseTrippleHandler
    {
        protected PanelDrawing host;
        protected MyPen penCustom;

        private Bitmap drawLayer;
        protected Graphics gDraw;

        public MouseTrippleHandler(PanelDrawing _Host)
        {
            host = _Host;
            penCustom = host.penCustom;

            drawLayer = null;
        }

        public virtual void Paint (PaintEventArgs e)
        {
            if(drawLayer != null)
                e.Graphics.DrawImage(drawLayer, Point.Empty);
        }

        // call base.Down at head of "The overrided"
        public virtual void Down(MouseEventArgs e)
        {
            if (drawLayer != null)
            {
                drawLayer.Dispose();
            }

            drawLayer = new Bitmap(host.image.Width, host.image.Height);
            gDraw = Graphics.FromImage(drawLayer);
        }

        public virtual void Move(MouseEventArgs e)
        {

        }

        // call base.Up at bottom of "The overrided"
        public virtual void Up(MouseEventArgs e)
        {
            host.imageCustom.Push();

            Graphics gImage = Graphics.FromImage(host.image);
            gImage.DrawImage(drawLayer, Point.Empty);

            drawLayer.Dispose();
            // Paint() error without this
            drawLayer = null;

            gDraw.Dispose();
        }
    }
}
