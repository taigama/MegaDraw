using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace _14520404_Paint
{
    internal class PanelK: System.Windows.Forms.Panel
    {
        public Main host;

        private const int cGripSize = 20;
        private bool mDragging;
        private Point mDragPos;

        #region image
        //private Bitmap background;

        private Bitmap layerBase;
        private Graphics graphBase;

        private Bitmap[] layers;
        private int numLayer = 0;

        private int iUndoTimes = 0;

        private Bitmap drawing;
        #endregion

        #region draw tool

        private enum DRAW_TYPE
        {
            dotSquare,
            dotCircle,
            path,
            rectangle,
            eclipse,
            region
        }

        private DRAW_TYPE drawType;

        public SolidBrush brushMain;

        public int sizeBrush = 1;

        private TextureBrush brushTexture;

        //private void InitBackground()
        //{
        //    background = new Bitmap(this.Width, this.Height);

        //    /*Bitmap image =
        //        (Bitmap)Image.FromFile(Path.Combine(
        //            Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory),
        //            @"textures\background.png"));*/
        //    Bitmap image = (Bitmap)Image.FromFile(@"I:\ZZZ\VS2015\14520404_Paint\14520404_Paint\Resources\textures\background.png");



        //    brushTexture = new TextureBrush(image);
        //    brushTexture.WrapMode = System.Drawing.Drawing2D.WrapMode.Tile;

        //    Graphics graphBackground = Graphics.FromImage(background);
        //    graphBackground.FillRectangle(brushTexture, this.DisplayRectangle);

        //    Graphics graphPanel = this.CreateGraphics();
        //    graphPanel.DrawImage(background, 0, 0);
        //    graphPanel.Dispose();
        //}

        Rectangle rectTemp;

        #endregion

        #region state --------------------------
        private bool isDraw = false;
        #endregion

        #region point
        static Point pointInvalid = new Point(-1, -1);

        private Point pointLast = pointInvalid;
        private Point pointCurrent = pointInvalid;
        #endregion

        public void SetUndoTimes(int i)
        {
            if(i>0 &&  i < int.MaxValue)
            {
                iUndoTimes = i;
            }
            else
            {
                MessageBox.Show("Invalid undo times!");
                return;
            }

            if (layerBase != null)
            {
                // cấp phát lại số layer
                if (layers != null)
                {
                    for (int iter = 0; iter < layers.Length; iter++)
                    {
                        graphBase.DrawImage(layers[iter], 0, 0);
                    }                    
                }
            }
            else
            {
                layerBase = new Bitmap(this.Width, this.Height);
                graphBase = Graphics.FromImage(layerBase);
            }

            // vị trí layer dời về 0
            numLayer = 0;
            layers = new Bitmap[iUndoTimes];
        }

        public int GetUndoTimes()
        {
            return iUndoTimes;
        }

        public PanelK()
        {
            Width = Properties.Settings.Default.sizeInitWidth;
            Height = Properties.Settings.Default.sizeInitHeight;

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.BackColor = Color.White;

            drawing = new Bitmap(this.Width, this.Height);
            SetUndoTimes(Properties.Settings.Default.undoTimes);

            drawType = DRAW_TYPE.dotSquare;
            brushMain = new SolidBrush(Color.Black);

            rectTemp = new Rectangle();

            //InitBackground();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor,
              new Rectangle(this.ClientSize.Width - cGripSize, this.ClientSize.Height - cGripSize, cGripSize, cGripSize));

            //e.Graphics.DrawImage(drawing, Point.Empty);
            
            base.OnPaint(e);
        }

        private bool IsOnGrip(Point pos)
        {
            return pos.X >= this.ClientSize.Width - cGripSize &&
                   pos.Y >= this.ClientSize.Height - cGripSize;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            mDragging = IsOnGrip(e.Location);
            mDragPos = e.Location;

            // nếu như đang resize, thì không vẽ nữa
            if (mDragging)
                return;


            pointLast = new Point(e.X, e.Y);

            isDraw = true;

            // chấm 1 cái
            Graphics g3 = this.CreateGraphics();
            g3.FillEllipse(brushMain, e.X - (sizeBrush / 2), e.Y - (sizeBrush / 2), sizeBrush, sizeBrush);
            g3.Dispose();

            Graphics g2 = Graphics.FromImage(drawing);
            g2.FillEllipse(brushMain, e.X - (sizeBrush / 2), e.Y - (sizeBrush / 2), sizeBrush, sizeBrush);
            g2.Dispose();

            //this.Invalidate();            

            ////////////////////////////
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            if (mDragging)
            {
                mDragging = false;

                Bitmap newBitmap = new Bitmap(this.Size.Width, this.Size.Height);
                Rectangle rect = new Rectangle(0, 0, this.Size.Width, this.Size.Height);
                if(layerBase.Size.Width < this.Size.Width)
                {
                    rect.Width = layerBase.Size.Width;
                }
                if(layerBase.Size.Height < this.Size.Height)
                {
                    rect.Height = layerBase.Size.Height;
                }

                

                Graphics newGraph = Graphics.FromImage(newBitmap);

                newGraph.DrawImage(layerBase, rect, rect, GraphicsUnit.Pixel);

                //this.DrawToBitmap(newBitmap, new Rectangle(0, 0, this.Size.Width, this.Size.Height));

                //newBitmap = host.bitmap.Clone(rect, host.bitmap.PixelFormat);

                layerBase = newBitmap;
                
            }


            if (isDraw)
            {
                isDraw = false;
                pointLast = pointInvalid;

                MergeDrawing();
                RenderAll(this.CreateGraphics());
                //RenderAll(this.CreateGraphics());//, true);

                //g1.Dispose();
                //myPen.Dispose();
            }



            base.OnMouseUp(e);
        }

        System.Drawing.Pen myPen;
        Graphics g1;
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (mDragging)
            {
                this.Size = new Size(this.Width + e.X - mDragPos.X,
                  this.Height + e.Y - mDragPos.Y);
                mDragPos = e.Location;
            }
            else if (IsOnGrip(e.Location)) this.Cursor = Cursors.SizeNWSE;
            else this.Cursor = Cursors.Default;

            if (isDraw)
            {
                using (g1 = Graphics.FromImage(drawing))
                {
                    Graphics g3 = this.CreateGraphics();

                    myPen = new Pen(brushMain);

                    g1.FillEllipse(brushMain, e.X - (sizeBrush / 2), e.Y - (sizeBrush / 2), sizeBrush, sizeBrush);
                    g3.FillEllipse(brushMain, e.X - (sizeBrush / 2), e.Y - (sizeBrush / 2), sizeBrush, sizeBrush);

                    myPen.Width = sizeBrush;
                    g1.DrawLine(myPen, pointLast.X, pointLast.Y, e.X, e.Y);
                    g3.DrawLine(myPen, pointLast.X, pointLast.Y, e.X, e.Y);

                    //myPen.Dispose();
                    //g1.Dispose();


                    pointLast = new Point(e.X, e.Y);
                }
                //this.Invalidate();
            }
            host.GetStatusItemMousePost().Text = host.MousePost(e.X, e.Y);


            




            base.OnMouseMove(e);
        }


        private void RenderAll(Graphics graphDest)//, bool renderBackground)
        {
            //graphDest.Clear(this.BackgroundImageLayout);
            //this.Controls.Clear();
            //this.Controls.Add(PanelK);

            this.Refresh();

            rectTemp.X = 0;
            rectTemp.Y = 0;

            //// render background
            //if (renderBackground)
            //{
            //    if(background.Width < this.Width)
            //        rectTemp.Width = background.Width;
            //    else
            //        rectTemp.Width = this.Width;

            //    if (background.Height < this.Height)
            //        rectTemp.Height = background.Height;
            //    else
            //        rectTemp.Height = this.Height;

            //    graphDest.DrawImage(background, rectTemp, rectTemp, GraphicsUnit.Pixel);
            //}

            // render base layer
            if (layerBase.Width < this.Width)
                rectTemp.Width = layerBase.Width;
            else
                rectTemp.Width = this.Width;

            if (layerBase.Height < this.Height)
                rectTemp.Height = layerBase.Height;
            else
                rectTemp.Height = this.Height;

            graphDest.DrawImage(layerBase, rectTemp, rectTemp, GraphicsUnit.Pixel);

            // render layers upper
            for (int i = 0; i < numLayer; i++)
            {
                if (layers[i].Width < this.Width)
                    rectTemp.Width = layers[i].Width;
                else
                    rectTemp.Width = this.Width;

                if (layers[i].Height < this.Height)
                    rectTemp.Height = layers[i].Height;
                else
                    rectTemp.Height = this.Height;

                graphDest.DrawImage(layers[i], rectTemp, rectTemp, GraphicsUnit.Pixel);
            }
            graphDest.Dispose();
        }

        // hàm để gộp các layer ở trên xuống 1 bậc, và gộp drawing vào layer trên cùng
        private void MergeDrawing()
        {
            if (numLayer >= iUndoTimes)
            {
                graphBase.DrawImage(layers[0], 0, 0);

                for (int i = 0; i < (numLayer - 1); i++)
                {
                    layers[i] = layers[i + 1];
                }
            }
            else
            {
                numLayer++;
            }

            layers[numLayer - 1] = drawing;
            drawing = new Bitmap(this.Width, this.Height);
        }
    }
}