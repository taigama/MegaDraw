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

        public void Clear()
        {
            if(image == null)
            {
                image = new Bitmap(width, heigh);
                return;
            }

            Graphics g = Graphics.FromImage(image);
            g.Clear(Color.Transparent);
            g.Dispose();
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
            image = _Image;

            Graphics hostGraphic = _Host.CreateGraphics();

            // WARNING!!! Không có cái này: với các máy có DPI bình thường sẽ không sao hết
            // với các máy sử dụng scaled DPI sẽ gặp rắc rối rất lớn
            //  (vd: hình load vào nhỏ hơn khung, brush bị lệch toạ độ)
            ((Bitmap)(image)).SetResolution(hostGraphic.DpiX, hostGraphic.DpiY);
            hostGraphic.Dispose();
        }




        // ========================= TEST AREA ============================

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

        ////And whenever image need to be modified, add it to the undo stack first and then modify it
        //private void UpdateImageData(Action updateImage)
        //{
        //    lock (_undoRedoLocker)
        //    {
        //        _undoStack.Push(image);//image);

        //        try
        //        {
        //            //manipulate the image here.
        //            updateImage();
        //        }
        //        catch
        //        {
        //            _undoStack.Pop();//because of exception remove the last added frame from stack
        //            throw;
        //        }
        //    }
        //}

        //private void pictureBox1_MouseClick(object sender, EventArgs e)
        //{
        //    UpdateImageData(delegate ()
        //    {
        //        rect.Width = 0;
        //        rect.Height = 0;
        //        pictureBox1.Invalidate();

        //        int radius = 10; //Set the number of pixel you want to use here
        //                         //Calculate the numbers based on radius
        //        int x0 = Math.Max(e.X - (radius / 2), 0),
        //            y0 = Math.Max(e.Y - (radius / 2), 0),
        //            x1 = Math.Min(e.X + (radius / 2), pictureBox1.Width),
        //            y1 = Math.Min(e.Y + (radius / 2), pictureBox1.Height);
        //        Bitmap bm = pictureBox1.Image as Bitmap; //Get the bitmap (assuming it is stored that way)
        //        for (int ix = x0; ix < x1; ix++)
        //        {
        //            for (int iy = y0; iy < y1; iy++)
        //            {
        //                bm.SetPixel(ix, iy, Color.Black); //Change the pixel color, maybe should be relative to bitmap
        //            }
        //        }
        //        pictureBox1.Refresh(); //Force refresh
        //    }
        //}

    }
}
