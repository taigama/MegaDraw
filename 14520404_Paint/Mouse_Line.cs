using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _14520404_Paint
{
    class Mouse_Line : MouseTrippleHandler
    {
        private bool isDraw = false;


        public Mouse_Line(PanelDrawing _Host) : base(_Host) { }


        static Point pointInvalid = new Point(-1, -1);
        private Point pointLast = pointInvalid;



        public override void Down(MouseEventArgs e)
        {
            base.Down(e);

            isDraw = true;
            pointLast = new Point(e.X, e.Y);            
           
            penCustom.penMain = new Pen(penCustom.brush);
            penCustom.penMain.Width = penCustom.sizeBrush;
        }

        public override void Move(MouseEventArgs e)
        {
            if (isDraw)
            {
                gDraw.Clear(Color.Transparent);
                gDraw.DrawLine(penCustom.penMain, pointLast.X, pointLast.Y, e.X, e.Y);
                host.Invalidate();            
            }

            base.Move(e);
        }

        public override void Up(MouseEventArgs e)
        {
            if (isDraw)
            {
                isDraw = false;                
                pointLast = pointInvalid;

                penCustom.penMain.Dispose();
                isDraw = false;

                base.Up(e);
            }
        }
    }
}
