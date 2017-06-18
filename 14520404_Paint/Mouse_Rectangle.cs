using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _14520404_Paint
{
    class Mouse_Rectangle : MouseTrippleHandler
    {
        private bool isDraw = false;
        private bool isDrag = false;

        private Vector2 pointLast = null;
        TYPE_CONTROL typeControl;

        public Mouse_Rectangle(PanelDrawing _Host) : base(_Host) { }


        Vector2[] points;

        public override void Down(MouseEventArgs e)
        {
            if (isDraw)
            {
                typeControl = host.controlPoint.OnControl(new Vector2(e.X, e.Y), out grabPoint);
                if (typeControl == TYPE_CONTROL.None)
                {
                    End();
                }
                if (typeControl == TYPE_CONTROL.Move)
                {
                    //points = host.controlPoint.GetVectors();

                    //if (points[0] != grabPoint)
                    //{
                    //    pointLast = points[0];
                    //}
                    //else
                    //{
                    //    pointLast = points[1];
                    //}

                    isDrag = true;
                    return;
                }

            }

            base.Down(e);

            isDraw = true;
            //pointLast = new Vector2(e.X, e.Y);
            host.controlPoint.AddPoint(new Vector2(e.X, e.Y));

            isDrag = true;
            grabPoint = new Vector2(e.X, e.Y);
            host.controlPoint.AddPoint(grabPoint);

            penCustom.penMain = new Pen(penCustom.brushFront);
            penCustom.penMain.Width = penCustom.sizeBrush;

            //penCustom.ChooseBrush(BRUSH_TYPE.linearGradient);
            penCustom.CreateBack(e.X, e.Y, e.X + 15, e.Y + 15);
        }

        Vector2 foo;
        public override void Move(MouseEventArgs e)
        {            
            typeControl = host.controlPoint.OnControl(new Vector2(e.X, e.Y), out foo);

            if (isDrag)
            {
                gDraw.Clear(Color.Transparent);
                points = host.controlPoint.GetVectors();

                grabPoint.X = e.X;
                grabPoint.Y = e.Y;

                penCustom.NotifyMovePoint();

                gDraw.FillRectangle(penCustom.brushBack, host.RectValid(points[0].X, points[0].Y, points[1].X, points[1].Y));
                gDraw.DrawRectangle(penCustom.penMain, host.RectValid(points[0].X, points[0].Y, points[1].X, points[1].Y));

                host.Invalidate();
            }

            base.Move(e);
        }

        public override void Up(MouseEventArgs e)
        {
            if (isDrag)
            {
                points = host.controlPoint.GetVectors();

                //if ((pointLast.X == e.X) && (pointLast.Y == e.Y))
                if (points.Length != 2)
                {
                    End();
                    return;
                }

                if(points[0].Equal(points[1]))
                {
                    End();
                    return;
                }

                grabPoint = null;
                isDrag = false;
            }
        }

        public override void End()
        {
            isDraw = false;
            isDrag = false;

            pointLast = null;
            grabPoint = null;

            host.controlPoint.Clear();
            penCustom.ClearBack();

            base.End();
        }
    }
}
