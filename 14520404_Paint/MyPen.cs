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
        public BRUSH_TYPE typeBrushFill = BRUSH_TYPE.none;


        public Color colorFront
        {
            get
            {
                return brushSolid.Color;
            }
            set 
            {
                brushSolid.Color = value;
            }
        }

        public Color colorBack
        {
            get;
            set;
        }

        public Point[] points;
        public float tension;

        private Bitmap texture;

        // --------- brushes
        public int sizeBrush = 5;
        public Brush brush;

        public SolidBrush brushSolid;
        private LinearGradientBrush brushLinear;
        private TextureBrush brushTexture;
        private HatchBrush brushHatch;

        public Pen penMain;
        public int sizePen = 1;

        public Region regionMain;

        public MyPen(PanelDrawing _Host)
        {
            host = _Host;

            // brushes - - - - - -
            brushSolid = new SolidBrush(Color.Black);

            brush = brushSolid;

            // brush linear được sinh ra trong lúc vẽ.
            //brushLinear = new LinearGradientBrush(Point.Empty, Point.Empty, Color.Black, Color.Black);


            // brush texture được sinh ra trong lúc chọn texture
            brushTexture = new TextureBrush(host.BackgroundImage);

            brushHatch = new HatchBrush(HatchStyle.BackwardDiagonal, Color.Black);
        }

        

    }
}
