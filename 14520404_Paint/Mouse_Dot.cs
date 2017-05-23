using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _14520404_Paint
{
    public class Mouse_Dot : MouseTrippleHandler
    {
        private bool isDraw = false;

        public bool isSquare = false;

        public Mouse_Dot(PanelDrawing _Host) : base(_Host) { }


        static Point pointInvalid = new Point(-1, -1);
        private Point pointLast = pointInvalid;

        public override void Down(MouseEventArgs e)
        {
            base.Down(e);

            isDraw = true;
            
            pointLast = new Point(e.X, e.Y);

            // chấm 1 cái

            if (isSquare)
            {                
                gDraw.FillRectangle(penCustom.brush, e.X - (penCustom.sizeBrush / 2), e.Y - (penCustom.sizeBrush / 2), penCustom.sizeBrush, penCustom.sizeBrush);
            }
            else
            {             
                gDraw.FillEllipse(penCustom.brush, e.X - (penCustom.sizeBrush / 2), e.Y - (penCustom.sizeBrush / 2), penCustom.sizeBrush, penCustom.sizeBrush);
            }

            penCustom.penMain = new Pen(penCustom.brush);
            penCustom.penMain.Width = penCustom.sizeBrush;
        }

        public override void Move(MouseEventArgs e)
        {
            if (isDraw)
            {
                if (isSquare)
                {
                    gDraw.FillRectangle(penCustom.brush, e.X - (penCustom.sizeBrush / 2), e.Y - (penCustom.sizeBrush / 2), penCustom.sizeBrush, penCustom.sizeBrush);
                }
                else
                {
                    gDraw.FillEllipse(penCustom.brush, e.X - (penCustom.sizeBrush / 2), e.Y - (penCustom.sizeBrush / 2), penCustom.sizeBrush, penCustom.sizeBrush);
                }

                // vẽ cái đường này giúp tạo thành 1 nét thẳng
                gDraw.DrawLine(penCustom.penMain, pointLast.X, pointLast.Y, e.X, e.Y);

                pointLast = new Point(e.X, e.Y);
            }
            host.Invalidate();

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
