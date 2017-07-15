using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _14520404_Paint
{
    public class Mouse_Region : MouseTrippleHandler
    {
        
        private bool isDraw = false;
        private bool isDrag = false;

        public Mouse_Region(PanelDrawing _Host) : base(_Host) { }



        private Vector2 pointLast = null;

        TYPE_CONTROL typeControl;

        public override void Down(MouseEventArgs e)
        {
            typeControl = host.controlPoint.OnControl(new Vector2(e.X, e.Y), out grabPoint);
            if (typeControl == TYPE_CONTROL.None)
            {
                End();
            }
            if (typeControl == TYPE_CONTROL.Area)
            {
                grabPoint = new Vector2(e.X, e.Y);

                isDrag = true;
                return;
            }
                

            base.Down(e);



            Start(e.X, e.Y);
        }

        // help "Down()"
        private void Start(int _X, int _Y)
        {
            isDraw = true;
            pointLast = new Vector2(_X, _Y);
            host.controlPoint.AddPoint(pointLast);

            
            grabPoint = new Vector2(_X, _Y);
            host.controlPoint.AddPoint(grabPoint);

            penCustom.penMain = new Pen(Color.DarkGray, 3);
            penCustom.penMain.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
        }

        int deltaX;
        int deltaY;
        public override void Move(MouseEventArgs e)
        {
            if (isDraw)
            {
                gDraw.Clear(Color.Transparent);
                gDraw.DrawRectangle(penCustom.penMain, host.RectValid(pointLast.X, pointLast.Y, e.X, e.Y));
                host.Invalidate();
                return;
            }

            Vector2 foo;
            typeControl = host.controlPoint.OnControl(new Vector2(e.X, e.Y), out foo);

            if (isDrag)
            {
                //gDraw.Clear(Color.Transparent);

                deltaX = e.X - grabPoint.X;
                deltaY = e.Y - grabPoint.Y;

                grabPoint.X = e.X;
                grabPoint.Y = e.Y;

                host.controlPoint.MoveRegion(deltaX, deltaY);

                //pointLast.X += deltaX;
                //pointLast.Y += deltaY;

                pointTranslate.X += deltaX; //pointLast.X;
                pointTranslate.Y += deltaY;//pointLast.Y;
                //gDraw.DrawRectangle(penCustom.penMain, pointLast.X, pointLast.Y, grabPoint.X, grabPoint.Y);
                host.Invalidate();
            }

            base.Move(e);
        }

        public override void Up(MouseEventArgs e)
        {
            if (isDraw)
            {
                isDraw = false;

                if ((pointLast.X == e.X) && (pointLast.Y == e.Y))
                {
                    End();
                    host.controlPoint.ClearPoint();
                    return;
                }

                penCustom.penMain.Dispose();
                penCustom.penMain = null;

                host.controlPoint.Clear();

                // get region từ main

                // tạo region
                Rectangle tempRect = host.RectValid(pointLast.X, pointLast.Y, e.X, e.Y);
                host.controlPoint.CreateRegion(tempRect);
                pointLast.X = tempRect.X;
                pointLast.Y = tempRect.Y;


                CloneByRect();


                using (Graphics gMain = Graphics.FromImage(host.image))
                using (SolidBrush brushTemp = new SolidBrush(Color.FromArgb(255, host.penCustom.colorBack)))
                {
                    // clear vùng đó = color2
                    gMain.FillRectangle(brushTemp, host.controlPoint.Region);
                }

            }


            if (isDrag)
            {
                if ((pointLast.X == e.X) && (pointLast.Y == e.Y))
                {
                    End();
                    return;
                }

                grabPoint = null;
                isDrag = false;
            }
        }

        // help "Up()"
        private void CloneByRect()
        {
            gDraw.Clear(Color.Transparent);
            //gDraw.DrawImage(host.image, pointLast.X, pointLast.Y, host.controlPoint.Region.Width, host.controlPoint.Region.Height);
            
            gDraw.DrawImage(host.image, pointLast.X, pointLast.Y, host.controlPoint.Region, GraphicsUnit.Pixel);
        }
       


        public override void End()
        {
            isDraw = false;
            isDrag = false;

            host.controlPoint.Clear();

            base.End();

            pointTranslate = Point.Empty;
        }

        #region method
        public bool Copy()
        {
            try
            {
                Bitmap bmp = new Bitmap(host.controlPoint.Region.Width, host.controlPoint.Region.Height);
                Graphics g = Graphics.FromImage(bmp);
                g.Clear(Color.White);

                //g.DrawImage(drawLayer, 0, 0, host.controlPoint.Region, GraphicsUnit.Pixel);
                g.DrawImage(drawLayer, 0, 0, new Rectangle(pointLast.X, pointLast.Y, host.controlPoint.Region.Width, host.controlPoint.Region.Height), GraphicsUnit.Pixel);


                Clipboard.SetImage(bmp);

                bmp.Dispose();
                g.Dispose();
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        public bool Paste()
        {
            if (Clipboard.ContainsImage())
            {
                Bitmap bitmap = (Bitmap)Clipboard.GetImage();
                //bitmap.MakeTransparent();

                drawLayer = bitmap;
                // tạo gdraw chống null
                gDraw = Graphics.FromImage(drawLayer);

                host.controlPoint.CreateRegion(new Rectangle(0, 0, bitmap.Width, bitmap.Height));

                pointLast = new Vector2();

                host.Invalidate();
                return true;
            }
            return false;
        }

        public bool Delete()
        {
            if(host.controlPoint.HaveRegion())
            {
                gDraw.Clear(Color.Transparent);
                End();
                return true;
            }

            return false;
        }
        #endregion
    }
}
