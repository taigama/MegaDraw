
using System.Drawing;

namespace _14520404_Paint
{
    internal class PanelDrawing : System.Windows.Forms.Panel
    {
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

        public PanelDrawing()
        {
            this.DoubleBuffered = true;
        }
    }
}