using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _14520404_Paint
{
    public partial class Main : Form
    {
        

        //static SolidBrush brush = new SolidBrush(Color.Black);

        //static int sizeBrush = 1;

        public Main()
        {
            InitializeComponent();
            this.pnPaint.host = this;

            //bitmap = new Bitmap(pnPaint.Width, pnPaint.Height);
        }

        private void toolItemBtnNew_Click(object sender, EventArgs e)
        {
            InitDrawPanel();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            //pointLast = new Point(e.X, e.Y);

            //isPaint = true;


            //LoadSizeBrush();
            

            //// chấm 1 cái
            //Graphics g1 = pnPaint.CreateGraphics();
            //g1.FillEllipse(brush, e.X - (sizeBrush / 2), e.Y - (sizeBrush / 2), sizeBrush, sizeBrush);
            //g1.Dispose();

            //pnPaint.Invalidate();
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            //isPaint = false;
            //isResize = false;

            //pointLast = pointInvalid;
        }

        

        //System.Drawing.Pen myPen;
        //Graphics g1;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            



            //if (isPaint)
            //{
            //    using (g1 = Graphics.FromImage(bitmap))
            //    {

            //        myPen = new Pen(brush);

            //        g1.FillEllipse(brush, e.X - (sizeBrush / 2), e.Y - (sizeBrush / 2), sizeBrush, sizeBrush);

            //        //myPen = new System.Drawing.Pen(System.Drawing.Color.Red);

            //        myPen.Width = sizeBrush;
            //        g1.DrawLine(myPen, pointLast.X, pointLast.Y, e.X, e.Y);

            //        //myPen.Dispose();
            //        //g1.Dispose();

                    
            //        pointLast = new Point(e.X, e.Y);
            //    }
            //    pnPaint.Invalidate();
            //}
            //statusItemMousePost.Text = MousePost(e.X, e.Y);
        }

        #region Hàm hỗ trợ
        public ToolStripStatusLabel GetStatusItemMousePost()
        {
            return statusItemMousePost;
        }

        public string MousePost(int X, int Y)
        {
            return "Mouse  X: " + X + "  Y: " + Y;
        }

        void InitDrawPanel()
        {
            //Graphics g1 = Graphics.FromImage(bitmap);
            //g1.Clear(Color.White);
            //pnPaint.Invalidate();
        }

        #endregion

        private void pnPaint_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.DrawImage(bitmap, Point.Empty);
            //InitDrawPanel();
        }

        private void toolItemColor_Click(object sender, EventArgs e)
        {
            // mở dialog chọn màu ---

            //  khởi tạo
            ColorDialog colorDialog = new ColorDialog();
            //  lấy màu hiện tại làm màu đang được chọn trong dialog
            colorDialog.Color = pnPaint.brushMain.Color;
            // mở dialog
            colorDialog.ShowDialog();

            // sau khi đóng dialog, màu của brush sẽ thành màu được chọn
            pnPaint.brushMain.Color = colorDialog.Color;



            // vẽ hình vào button chọn màu ---

            // tại bitmap
            Bitmap imgBtn = new Bitmap(32, 32);

            // load hình ảnh từ bitmap
            Graphics flagGraphics = Graphics.FromImage(imgBtn);          

            // vẽ vào bitmap
            flagGraphics.FillRectangle(Brushes.Black, 0, 0, 32, 32);
            flagGraphics.FillRectangle(pnPaint.brushMain, 2, 2, 28, 28);

            // đổi hình của cái button
            toolItemColor.Image = imgBtn;
        }

        private void toolItemBtnSave_Click(object sender, EventArgs e)
        {
            

            //SaveFileDialog saveDialog = new SaveFileDialog();
            //saveDialog.FileName = "myImage";
            //saveDialog.DefaultExt = "png";
            //saveDialog.Filter = "PNG image (*.png)|*.png";

            //if (saveDialog.ShowDialog() == DialogResult.OK)
            //{                
            //    bitmap.Save(saveDialog.FileName, ImageFormat.Png);
            //}
        }

        private void toolItemBtnOpen_Click(object sender, EventArgs e)
        {
            //OpenFileDialog openDialog = new OpenFileDialog();
            //openDialog.Filter = "JPG image (*.jpg)|*.jpg|PNG image (*.png)|*.png";

            //if(openDialog.ShowDialog() == DialogResult.OK)
            //{
            //    bitmap = new Bitmap(openDialog.FileName);


            //    Graphics hostGraphic = this.CreateGraphics();

            //    // WARNING!!! Không có cái này: với các máy có DPI bình thường sẽ không sao hết
            //    // với các máy sử dụng scaled DPI sẽ gặp rắc rối rất lớn
            //    //  (vd: hình load vào nhỏ hơn khung, brush bị lệch toạ độ)
            //    bitmap.SetResolution(hostGraphic.DpiX, hostGraphic.DpiY);
                
            //    pnPaint.Size = bitmap.Size;
            //    pnPaint.Invalidate();
            //}

        }

        void LoadSizeBrush()
        {
            // load size brush
            try
            {
                pnPaint.sizeBrush = int.Parse(toolItemCbSize.Text);
            }
            catch (Exception ex)
            {
                pnPaint.sizeBrush = 1;
            }
        }

        //bool dropDownHandler = true;

        private void toolItemCbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSizeBrush();
        }
    }
}
