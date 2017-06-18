using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _14520404_Paint
{

    // Class này còn rất là rác


    class Mouse_Polygon: MouseTrippleHandler
    {
        private bool isDraw = false;
        private bool isDrag = false;

        private Vector2 firstPoint = null;

        GraphicsPath path = null;

        TYPE_CONTROL typeControl;

        ControlPoint pointController = null;

        ToolBoxOK toolBox = null;

        public Mouse_Polygon(PanelDrawing _Host) : base(_Host)
        {
            pointController = host.controlPoint;
        }

        


        public override void Down(MouseEventArgs e)
        {
            if (isDraw)
            {
                typeControl = host.controlPoint.OnControl(new Vector2(e.X, e.Y), out grabPoint);
                if (typeControl == TYPE_CONTROL.None)
                {
                    // -----------------------------------------


                    grabPoint = new Vector2(e.X, e.Y);
                    pointController.AddPoint(grabPoint);

                    gDraw.Clear(Color.Transparent);
                    path.Reset();
                    Point[] points = pointController.GetPoints();
                    path.AddLines(points);

                    using (Brush brushBack = new SolidBrush(penCustom.colorBack))
                    {
                        gDraw.FillPolygon(brushBack, pointController.GetPoints());
                    }
                    gDraw.DrawPath(penCustom.penMain, path);

                    isDrag = true;
                    return;


                    //End();
                    // --------------------------------------------
                }
                if (typeControl == TYPE_CONTROL.Move)
                {
                    isDrag = true;
                    return;
                }

            }

            base.Down(e);

            Start(e.X, e.Y);
        }

        void Start(int _X, int _Y)
        {
            isDraw = true;
            firstPoint = new Vector2(_X, _Y);
            pointController.AddPoint(firstPoint);

            isDrag = true;
            grabPoint = new Vector2(_X, _Y);
            pointController.AddPoint(grabPoint);

            penCustom.penMain = new Pen(penCustom.brushFront);
            penCustom.penMain.Width = penCustom.sizeBrush;

            path = new GraphicsPath(FillMode.Winding);

            toolBox = new ToolBoxOK();
            toolBox.btnOK.Click += BtnOK_Click;
            toolBox.btnCancel.Click += BtnCancel_Click;
            toolBox.Show();
        }
        
        private void BtnOK_Click(object sender, EventArgs e)
        {
            End();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            gDraw.Clear(Color.Transparent);
            End();
        }

        public override void Move(MouseEventArgs e)
        {
            Vector2 foo;
            typeControl = host.controlPoint.OnControl(new Vector2(e.X, e.Y), out foo);

            if (isDrag)
            {
                gDraw.Clear(Color.Transparent);

                grabPoint.X = e.X;
                grabPoint.Y = e.Y;

                
                path.Reset();
                path.FillMode = FillMode.Winding;

                Point[] points = pointController.GetPoints();
                path.AddLines(points);
                //for (int i = 0; i < points.Length; i++)
                //{

                //}

                using (Brush brushBack = new SolidBrush(penCustom.colorBack))
                {
                    gDraw.FillPolygon(brushBack, pointController.GetPoints());
                }
                gDraw.DrawPath(penCustom.penMain,path);

                host.Invalidate();
            }

            base.Move(e);
        }

       

        public override void Up(MouseEventArgs e)
        {
            if (isDrag)
            {
                grabPoint = null;
                isDrag = false;
            }
        }

        public override void End()
        {
            isDraw = false;
            isDrag = false;

            firstPoint = null;
            grabPoint = null;

            pointController.Clear();

            if (path != null)
            {
                path.Dispose();
                path = null;
            }


            if (toolBox != null)
            {
                toolBox.Close();
                toolBox = null;
            }

            host.Invalidate();

            base.End();
        }
    }
}
