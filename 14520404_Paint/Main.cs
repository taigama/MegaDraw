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
using System.Reflection;

namespace _14520404_Paint
{
    public partial class Main : Form
    {
        

        //static SolidBrush brush = new SolidBrush(Color.Black);

        //static int sizeBrush = 1;

        public Main()
        {
            InitializeComponent();
            
            pnDrawing.Init(this);

            LoadSetting();
        }

        private void LoadSetting()
        {
            toolItemCbSize.SelectedIndex = 10;
            
        }

        private void toolItemBtnNew_Click(object sender, EventArgs e)
        {
            pnDrawing.Init(this);
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

        public void ShowMousePost(int X, int Y)
        {
            statusItemMousePost.Text = MousePost(X, Y);
        }

        #endregion

        private void toolItemColor_Click(object sender, EventArgs e)
        {
            bool isFill = (sender == toolItemColorFill);
            // mở dialog chọn màu ---

            //  khởi tạo
            ColorDialog colorDialog = new ColorDialog();
            //  lấy màu hiện tại làm màu đang được chọn trong dialog
            //colorDialog.Color = ucDrawing.pnPaint.brushMain.Color;

            //colorDialog.Color = pnDrawing.penCustom.brushSolid.Color;

            if (!isFill)
            {
                colorDialog.Color = pnDrawing.penCustom.colorFront;

                // mở dialog
                colorDialog.ShowDialog();

                // sau khi đóng dialog, màu của brush sẽ thành màu được chọn
                this.pnDrawing.penCustom.colorFront = colorDialog.Color;
            }
            else
            {
                colorDialog.Color = pnDrawing.penCustom.colorBack;
                
                colorDialog.ShowDialog();
                this.pnDrawing.penCustom.colorBack = colorDialog.Color;
            }

            // vẽ hình vào button chọn màu ---

            // tại bitmap
            Bitmap imgBtn = new Bitmap(32, 32);

            // load hình ảnh từ bitmap
            Graphics flagGraphics = Graphics.FromImage(imgBtn);          

            // vẽ vào bitmap
            flagGraphics.FillRectangle(Brushes.Black, 0, 0, 32, 32);
            flagGraphics.FillRectangle(new SolidBrush(colorDialog.Color), 2, 2, 28, 28);

            // đổi hình của cái button
            ((ToolStripButton)sender).Image = imgBtn;
        }

        private void toolItemBtnSave_Click(object sender, EventArgs e)
        {
            SaveImage();
        }

        private bool SaveImage()
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.FileName = "myImage";
                saveDialog.DefaultExt = "png";
                saveDialog.Filter = "PNG image (*.png)|*.png";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    pnDrawing.image.Save(saveDialog.FileName, ImageFormat.Png);
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        private void toolItemBtnOpen_Click(object sender, EventArgs e)
        {
            OpenImage();
        }

        private bool OpenImage()
        {
            try
            {
                OpenFileDialog openDialog = new OpenFileDialog();
                openDialog.Filter = "image file|*.bmp;*.jpg;*.jpeg;*.png";

                if (openDialog.ShowDialog() == DialogResult.OK)
                {                    
                    pnDrawing.imageCustom.GetImage(new Bitmap(openDialog.FileName), pnDrawing);                    

                    pnDrawing.Size = pnDrawing.image.Size;
                    pnDrawing.Invalidate();
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        void LoadSizeBrush()
        {
            // load size brush
            try
            {
                pnDrawing.penCustom.sizeBrush = int.Parse(toolItemCbSize.Text);
                // ucDrawing.pnPaint.sizeBrush = int.Parse(toolItemCbSize.Text);
            }
            catch (Exception ex)
            {
                pnDrawing.penCustom.sizeBrush = 5;
                // ucDrawing.pnPaint.sizeBrush = 1;
            }
        }

        //bool dropDownHandler = true;

        private void ChangeIconSplitButton(ToolStripMenuItem source, ToolStripDropDownItem target)
        {
            target.Image = source.Image;
        }

        private void toolItemCbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSizeBrush();
        }

        #region draw type
        private void itemDotSquare_Click(object sender, EventArgs e)
        {
            pnDrawing.SetSharp(DRAW_TYPE.dotSquare);

            ChangeIconSplitButton((ToolStripMenuItem)sender, toolItemDrawType);
        }

        private void itemDotCircle_Click(object sender, EventArgs e)
        {
            pnDrawing.SetSharp(DRAW_TYPE.dotCircle);

            ChangeIconSplitButton((ToolStripMenuItem)sender, toolItemDrawType);
        }


        private void itemLine_Click(object sender, EventArgs e)
        {
            pnDrawing.SetSharp(DRAW_TYPE.line);

            ChangeIconSplitButton((ToolStripMenuItem)sender, toolItemDrawType);
        }

        private void itemRectangle_Click(object sender, EventArgs e)
        {
            pnDrawing.SetSharp(DRAW_TYPE.rectangle);

            ChangeIconSplitButton((ToolStripMenuItem)sender, toolItemDrawType);
        }

        private void itemEclipse_Click(object sender, EventArgs e)
        {
            pnDrawing.SetSharp(DRAW_TYPE.eclipse);

            ChangeIconSplitButton((ToolStripMenuItem)sender, toolItemDrawType);
        }
        #endregion

        private void toolItemSetting_Click(object sender, EventArgs e)
        {
            Setting setting = new Setting();

            if (setting.ShowDialog() == DialogResult.OK)
            {
                pnDrawing.imageCustom.Resize(Properties.Settings.Default.panel_width, Properties.Settings.Default.panel_heigh);
                pnDrawing.Size = pnDrawing.image.Size;

                pnDrawing.Invalidate();
            }
        }


        // Key handler
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case (Keys.Control | Keys.O):
                    return OpenImage();
                case (Keys.Control | Keys.S):
                    return SaveImage();
                case (Keys.Control | Keys.N):
                    pnDrawing.Init(this);
                    return true;
                case (Keys.Control | Keys.Z):
                    {
                        bool returner = pnDrawing.imageCustom.Undo();
                        pnDrawing.Invalidate();
                        return returner;
                    }
                case (Keys.Control | Keys.Y):
                    {
                        bool returner = pnDrawing.imageCustom.Redo();
                        pnDrawing.Invalidate();
                        return returner;
                    }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
