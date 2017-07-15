using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _14520404_Paint
{

    public enum MOUSE_STATE
    {
        Left,
        Right,
        Middle
    }

    public class MouseTrippleHandler
    {
        protected Point pointTranslate;

        protected PanelDrawing host;
        protected MyPen penCustom;

        protected Bitmap drawLayer;
        protected Graphics gDraw;

        protected Vector2 grabPoint;

        public MouseTrippleHandler(PanelDrawing _Host)
        {
            host = _Host;
            penCustom = host.penCustom;

            drawLayer = null;
            grabPoint = null;

            pointTranslate = Point.Empty;
        }

        public virtual void Paint (PaintEventArgs e)
        {
            if (drawLayer != null)
                e.Graphics.DrawImage(drawLayer, pointTranslate);
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
            End();
        }

        public virtual void End()
        {
            if(drawLayer == null)
            {
                return;
            }

            host.imageCustom.Push();

            Graphics gImage = Graphics.FromImage(host.image);
            gImage.DrawImage(drawLayer, pointTranslate);

            drawLayer.Dispose();
            // Paint() error without this
            drawLayer = null;

            if (gDraw != null)
            {
                gDraw.Dispose();
                gDraw = null;
            }

            host.Invalidate();
        }
    }
}
