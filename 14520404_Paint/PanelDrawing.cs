
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace _14520404_Paint
{
    public class PanelDrawing : System.Windows.Forms.Panel
    {
        private Main host;

        public MyImage imageCustom;
        public MyPen penCustom;
        public ControlPoint controlPoint;

        public Image image
        {
            get
            {
                return imageCustom.image;
            }
            set
            {
                imageCustom.image = value;
            }
        }

        //BufferedGraphicsContext currentContext;
        //BufferedGraphics myBuffer;



        //--------- 
        MOUSE_STATE state_mouse;

        public MouseTrippleHandler m_MouseHandler;

        private Mouse_Dot m_MouseDot;
        private Mouse_Line m_MouseLine;
        private Mouse_Rectangle m_MouseRect;
        private Mouse_Eclipse m_MouseEclipse;
        private Mouse_Polygon m_MousePolygon;

        public Mouse_Region m_MouseRegion;






        public PanelDrawing()
        {

            //SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;

            //InitCustomComponent();
            BackgroundImage = new Bitmap(10, 10);
            //image = new Bitmap(this.Width, this.Height);


            imageCustom = new MyImage(Properties.Settings.Default.panel_width, Properties.Settings.Default.panel_heigh);
            //image = new Bitmap(Properties.Settings.Default.panel_width, Properties.Settings.Default.panel_heigh);


            penCustom = new MyPen(this);
            penCustom.sizeBrush = Properties.Settings.Default.pen_witdh;


            controlPoint = new ControlPoint(7);



            m_MouseDot = new Mouse_Dot(this);
            m_MouseLine = new Mouse_Line(this);
            m_MouseRect = new Mouse_Rectangle(this);
            m_MouseEclipse = new Mouse_Eclipse(this);
            m_MousePolygon = new Mouse_Polygon(this);

            m_MouseRegion = new Mouse_Region(this);


            m_MouseHandler = m_MouseDot;

            
                
        }

        

        public void Init(Main _Host)
        {
            host = _Host;
            //pnBase.Paint += new PaintEventHandler(PnBase_Paint);
            this.Width = Properties.Settings.Default.panel_width;
            this.Height = Properties.Settings.Default.panel_heigh;

            if(image != null)
            {
                image.Dispose();
            }
            imageCustom = new MyImage(Properties.Settings.Default.panel_width, Properties.Settings.Default.panel_heigh);
            // image = new Bitmap(Properties.Settings.Default.panel_width, Properties.Settings.Default.panel_heigh);

            Invalidate();
        }
    

        public void SetSharp(DRAW_TYPE type)
        {
            switch (type)
            {
                case DRAW_TYPE.dotSquare:
                    m_MouseHandler.End();
                    m_MouseHandler = m_MouseDot;
                    m_MouseDot.isSquare = true;
                    break;

                case DRAW_TYPE.dotCircle:
                    m_MouseHandler.End();
                    m_MouseHandler = m_MouseDot;
                    m_MouseDot.isSquare = false;
                    break;

                case DRAW_TYPE.line:
                    m_MouseHandler.End();
                    m_MouseHandler = m_MouseLine;
                    break;
                case DRAW_TYPE.rectangle:
                    m_MouseHandler.End();
                    m_MouseHandler = m_MouseRect;
                    break;

                case DRAW_TYPE.eclipse:
                    m_MouseHandler.End();
                    m_MouseHandler = m_MouseEclipse;
                    break;
                case DRAW_TYPE.polygon:
                    m_MouseHandler.End();
                    m_MouseHandler = m_MousePolygon;
                    break;

                case DRAW_TYPE.region:
                    m_MouseHandler.End();
                    m_MouseHandler = m_MouseRegion;
                    break;

                default:
                    break;
            }
            Invalidate();
        }

        public void SetLine(BRUSH_TYPE type)
        {

        }

        public void SetFill(BRUSH_TYPE type)
        {

        }

        public Rectangle RectValid(int x1, int y1, int x2, int y2)
        {
            Rectangle temp = new Rectangle();

            if(x1 <= x2)
            {
                temp.X = x1;
                temp.Width = x2 - x1;
            }
            else
            {
                temp.X = x2;
                temp.Width = x1 - x2;
            }

            if(y1 <= y2)
            {
                temp.Y = y1;
                temp.Height = y2 - y1;
            }
            else
            {
                temp.Y = y2;
                temp.Height = y1 - y2;
            }

            return temp;
        }        


        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawImage(image, Point.Empty);

            m_MouseHandler.Paint(e);

            controlPoint.DrawControl(e);

            base.OnPaint(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            //imageCustom.Push();
            switch(e.Button)
            {
                case MouseButtons.Left:
                    state_mouse = MOUSE_STATE.Left;
                    break;
                case MouseButtons.Middle:
                    state_mouse = MOUSE_STATE.Middle;
                    break;
                case MouseButtons.Right:
                    state_mouse = MOUSE_STATE.Right;
                    break;
            }

            switch (state_mouse)
            {
                case MOUSE_STATE.Right:
                    return;
            }

            m_MouseHandler.Down(e);

            base.OnMouseDown(e);
        }


        protected override void OnMouseMove(MouseEventArgs e)
        {
            switch (state_mouse)
            {
                case MOUSE_STATE.Right:
                    return;
            }

            m_MouseHandler.Move(e);

            host.ShowMousePost(e.X, e.Y);

            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            switch (state_mouse)
            {
                case MOUSE_STATE.Right:
                    return;
            }

            m_MouseHandler.Up(e);
            

            Invalidate();

            base.OnMouseUp(e);
        }
    }
}