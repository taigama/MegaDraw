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
        private bool isDrag = false;


        public Mouse_Line(PanelDrawing _Host) : base(_Host) { }


        
        private Vector2 pointLast = null;

        TYPE_CONTROL typeControl;

        public override void Down(MouseEventArgs e)
        {           

            if(isDraw)
            {
                typeControl = host.controlPoint.OnControl(new Vector2(e.X, e.Y), out grabPoint);
                if(typeControl == TYPE_CONTROL.None)
                {
                    End();        
                }
                if(typeControl == TYPE_CONTROL.Move)
                {
                    Vector2[] points = host.controlPoint.GetVectors();

                    if (points[0] != grabPoint)
                    {
                        pointLast = points[0];
                    }
                    else
                    {
                        pointLast = points[1];
                    }

                    isDrag = true;
                    return;
                }
                
            }

            base.Down(e);

            isDraw = true;
            pointLast = new Vector2(e.X, e.Y);
            host.controlPoint.AddPoint(pointLast);

            isDrag = true;
            grabPoint = new Vector2(e.X, e.Y);
            host.controlPoint.AddPoint(grabPoint);

            penCustom.penMain = new Pen(penCustom.brushFront);
            penCustom.penMain.Width = penCustom.sizeBrush;
        }

        public override void Move(MouseEventArgs e)
        {
            //if (isDraw)
            //{
            //    gDraw.Clear(Color.Transparent);
            //    gDraw.DrawLine(penCustom.penMain, pointLast.X, pointLast.Y, e.X, e.Y);
            //    host.Invalidate();            
            //}
            Vector2 foo;
            typeControl = host.controlPoint.OnControl(new Vector2(e.X, e.Y),out foo);

            if (isDrag)
            {
                gDraw.Clear(Color.Transparent);
                                
                grabPoint.X = e.X;
                grabPoint.Y = e.Y;

                gDraw.DrawLine(penCustom.penMain, pointLast.X, pointLast.Y, grabPoint.X, grabPoint.Y);
                host.Invalidate();
            }

            base.Move(e);
        }

        public override void Up(MouseEventArgs e)
        {
            //if (isDraw)
            //{
            //    isDraw = false;            
            //    //pointLast = pointInvalid;

            //    penCustom.penMain.Dispose();
            //    isDraw = false;

            //    base.Up(e);
            //}
            if(isDrag)
            {
                if((pointLast.X == e.X) && (pointLast.Y == e.Y))
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

            base.End();
        }
    }
}
