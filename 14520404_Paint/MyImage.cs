using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _14520404_Paint
{
    public class MyImage
    {
        public Image image;

        private int width;
        private int heigh;

        public MyImage(int _Width, int _Heigh)
        {
            image = new Bitmap(_Width, _Heigh);
            width = _Width;
            heigh = _Heigh;
        }

        private void New()
        {
            Bitmap newBitmap = new Bitmap(width, heigh);

            newBitmap = (Bitmap)image.Clone();
            image = newBitmap;
        }
        

        public void Resize(int _Width, int _Heigh)
        {           
            // tạo ra bitmap mới với size mới
            Bitmap newBitmap = new Bitmap(_Width, _Heigh);

            // tạo ra cái vùng để copy
            Rectangle rect = new Rectangle(0, 0, _Width, _Heigh);
            if (width < _Width)
            {
                rect.Width = width;
            }
            if (heigh < _Heigh)
            {
                rect.Height = heigh;
            }

            // tiến hành copy từ bitmap cũ sang bitmap mới
            Graphics newGraph = Graphics.FromImage(newBitmap);
            newGraph.DrawImage(image, rect, rect, GraphicsUnit.Pixel);

            // dọn dẹp
            newGraph.Dispose();
            image.Dispose();

            // cập nhật các giá trị
            image = newBitmap;
            width = _Width;
            heigh = _Heigh;
        }

        public void GetImage(Image _Image, PanelDrawing _Host)
        {
            if(image != null)
            {
                image.Dispose();
            }
            image = new Bitmap(_Image);

            //Graphics hostGraphic = _Host.CreateGraphics();

            // WARNING!!! Không có cái này: với các máy có DPI bình thường sẽ không sao hết
            // với các máy sử dụng scaled DPI sẽ gặp rắc rối rất lớn
            //  (vd: hình load vào nhỏ hơn khung, brush bị lệch toạ độ)
            //((Bitmap)(image)).SetResolution(hostGraphic.DpiX, hostGraphic.DpiY);
            //hostGraphic.Dispose();

            width = image.Width;
            heigh = image.Height;
        }




        // =========================   ============================

        private Stack<Image> _undoStack = new Stack<Image>();
        private Stack<Image> _redoStack = new Stack<Image>();

        private readonly object _undoRedoLocker = new object();

        public bool Undo()
        {
            lock (_undoRedoLocker)
            {
                if (_undoStack.Count > 0)
                {
                    _redoStack.Push(image);

                    //OnUndo();
                    image = _undoStack.Pop();
                    return true;
                }

                return false;
            }
        }

        public bool Push()
        {
            _undoStack.Push(image);
            New();
            _redoStack.Clear();

            return true;
        }

        public bool Redo()
        {
            lock (_undoRedoLocker)
            {
                if (_redoStack.Count > 0)
                {
                    _undoStack.Push(image);

                    //OnRedo();
                    image = _redoStack.Pop();
                    return true;
                }

                return false;
            }
        }

    }
}
