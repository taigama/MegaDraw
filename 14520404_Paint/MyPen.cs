using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14520404_Paint
{

    public enum DRAW_TYPE
    {
        dotSquare,
        dotCircle,
        line,
        rectangle,
        eclipse,
        polygon,
        curve,
        bezier,
        word,
        region
    }


    public enum BRUSH_TYPE
    {
        none,
        solid,
        linearGradient,
        texture,
        hatch
    }

    public class MyPen
    {
        private PanelDrawing host;

        public DRAW_TYPE typeDraw;
        public BRUSH_TYPE typeBrushFill = BRUSH_TYPE.solid;

        public HatchStyle styleHatch = HatchStyle.Cross;

        public Color colorFront
        {
            get
            {
                return brushFront.Color;
            }
            set 
            {
                brushFront.Color = value;
            }
        }

        public Color colorBack
        {
            get;
            set;
        }

       

        public float tension;

        public Bitmap texture
        {
            get;
            set;
        }


        // --------- brushes
        public int sizeBrush = 5;
        public Brush brushBack;

        public SolidBrush brushFront;

        private LinearGradientBrush brushLinear;
        private TextureBrush brushTexture;
        private HatchBrush brushHatch;

        public Pen penMain;
        public int sizePen = 1;

        public Region regionMain;

        public MyPen(PanelDrawing _Host)
        {
            host = _Host;

            colorBack = Color.Transparent;

            // brushes - - - - - -
            brushFront = new SolidBrush(Color.Black);

            //brush = brushFront;

            // brush linear được sinh ra trong lúc vẽ.
            //brushLinear = new LinearGradientBrush(Point.Empty, Point.Empty, Color.Black, Color.Black);


            // brush texture được sinh ra trong lúc chọn texture
            brushTexture = new TextureBrush(host.BackgroundImage);

            brushHatch = new HatchBrush(HatchStyle.BackwardDiagonal, Color.Black);
        }

        public void ChooseBrush(BRUSH_TYPE typeBrush)
        {
            host.m_MouseHandler.End();

            typeBrushFill = typeBrush;

            //switch (typeBrush)
            //{
            //    case BRUSH_TYPE.solid:
            //        break;
            //    case BRUSH_TYPE.linearGradient:
            //        break;
            //    case BRUSH_TYPE.hatch:
            //        break;
            //    case BRUSH_TYPE.texture:
            //        break;
            //}
        }

        // tạo brush back với các loại brush khác nhau
        public Brush CreateBack(params int[] ints)
        {
            if (brushBack != null)
            {
                brushBack.Dispose();
            }

            switch (typeBrushFill)
            {
                case BRUSH_TYPE.solid:
                    brushBack = new SolidBrush(colorBack);
                    break;
                case BRUSH_TYPE.linearGradient:
                    {
                        Point[] points = host.controlPoint.GetSubPoints();

                        if(points.Length != 2)
                        {
                            host.controlPoint.ClearSub();
                            // phải tryền vào 4 đối số ints
                            host.controlPoint.AddSubPoint(new Vector2(ints[0], ints[1]), new Vector2(ints[2], ints[3]));
                        }

                        points = host.controlPoint.GetSubPoints();
                        brushBack = new LinearGradientBrush(points[0], points[1], colorFront, colorBack);

                    }
                    break;

                case BRUSH_TYPE.hatch:
                    {
                        brushBack = new HatchBrush(styleHatch, colorFront, colorBack);
                    }
                    break;
                case BRUSH_TYPE.texture:
                    {
                        brushBack = new TextureBrush(texture);
                    }
                    break;

                // chống lỗi
                default:
                    brushBack = new SolidBrush(colorBack);
                    break;
            }

            return brushBack;
        }

        public void ClearBack()
        {
            if (brushBack != null)
            {
                brushBack.Dispose();
                brushBack = null;
            }
        }

        

        public void NotifyMovePoint()
        {
            Point[] points = host.controlPoint.GetSubPoints();
            if((points.Length == 2) && (typeBrushFill == BRUSH_TYPE.linearGradient))
            {
                if(brushBack != null)
                {
                    brushBack.Dispose();                    
                }

                brushBack = new LinearGradientBrush(points[0], points[1], colorFront, colorBack);
            }
        }
    }
}
