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
using System.Drawing.Drawing2D;

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

            pnDrawing.penCustom.texture = (Bitmap)pnDrawing.BackgroundImage;
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

        

        private void toolItemBtnSave_Click(object sender, EventArgs e)
        {
            SaveImage();
        }

        private bool SaveImage()
        {
            pnDrawing.m_MouseHandler.End();

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
            pnDrawing.m_MouseHandler.End();

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

        private void ChangeIconToolStripMenu(ToolStripMenuItem source, ToolStripDropDownItem target)
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

            ChangeIconToolStripMenu((ToolStripMenuItem)sender, toolItemDrawType);
        }

        private void itemDotCircle_Click(object sender, EventArgs e)
        {
            pnDrawing.SetSharp(DRAW_TYPE.dotCircle);

            ChangeIconToolStripMenu((ToolStripMenuItem)sender, toolItemDrawType);
        }


        private void itemLine_Click(object sender, EventArgs e)
        {
            pnDrawing.SetSharp(DRAW_TYPE.line);

            ChangeIconToolStripMenu((ToolStripMenuItem)sender, toolItemDrawType);
        }

        private void itemRectangle_Click(object sender, EventArgs e)
        {
            pnDrawing.SetSharp(DRAW_TYPE.rectangle);

            ChangeIconToolStripMenu((ToolStripMenuItem)sender, toolItemDrawType);
        }

        private void itemEclipse_Click(object sender, EventArgs e)
        {
            pnDrawing.SetSharp(DRAW_TYPE.eclipse);

            ChangeIconToolStripMenu((ToolStripMenuItem)sender, toolItemDrawType);
        }

        private void itemPolygon_Click(object sender, EventArgs e)
        {
            pnDrawing.SetSharp(DRAW_TYPE.polygon);

            ChangeIconToolStripMenu((ToolStripMenuItem)sender, toolItemDrawType);
        }

        #endregion

        private void toolItemSetting_Click(object sender, EventArgs e)
        {
            Setting setting = new Setting();

            // gán sẵn 1 số thứ -----
            setting.txtSetWidth.Text = pnDrawing.image.Width.ToString();
            setting.txtSetHeigh.Text = pnDrawing.image.Height.ToString();

            setting.btnTexture.BackgroundImage = pnDrawing.penCustom.texture;

            setting.cbHatchStyle.DataSource = Enum.GetValues(typeof(HatchStyle));
            setting.cbHatchStyle.Text = pnDrawing.penCustom.styleHatch.ToString();

            // ---------

            if (setting.ShowDialog() == DialogResult.OK)
            {
                // chỉnh lại size
                pnDrawing.imageCustom.Resize(Properties.Settings.Default.panel_width, Properties.Settings.Default.panel_heigh);
                pnDrawing.Size = pnDrawing.image.Size;

                // chỉnh lại texture
                pnDrawing.penCustom.texture = (Bitmap)setting.btnTexture.BackgroundImage;

                // chỉnh lại hatch style
                Enum.TryParse(setting.cbHatchStyle.SelectedValue.ToString(), out pnDrawing.penCustom.styleHatch);

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
                case (Keys.Control | Keys.C):
                    return CopyImg();
                case (Keys.Control | Keys.V):
                    return PasteImg();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

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
                Color lineColor = Color.FromArgb(sliderAlphaLine.Value, colorDialog.Color);

                // sau khi đóng dialog, màu của brush sẽ thành màu được chọn
                this.pnDrawing.penCustom.colorFront = lineColor;
            }
            else
            {
                colorDialog.Color = pnDrawing.penCustom.colorBack;

                colorDialog.ShowDialog();
                Color fillColor = Color.FromArgb(sliderAlphaFill.Value, colorDialog.Color);


                this.pnDrawing.penCustom.colorBack = fillColor;
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
            ((ToolStripItem)sender).Image = imgBtn;
        }

        private void sliderAlphaLine_ValueChanged(object sender, EventArgs e)
        {
            this.pnDrawing.penCustom.colorFront = Color.FromArgb(sliderAlphaLine.Value, pnDrawing.penCustom.colorFront);
        }

        private void sliderAlphaFill_ValueChanged(object sender, EventArgs e)
        {
            this.pnDrawing.penCustom.colorBack = Color.FromArgb(sliderAlphaFill.Value, pnDrawing.penCustom.colorBack);
        }

        private void toolMenuItemUndo_Click(object sender, EventArgs e)
        {
            pnDrawing.imageCustom.Undo();
            pnDrawing.Invalidate();
        }

        private void toolMenuItemRedo_Click(object sender, EventArgs e)
        {
            pnDrawing.imageCustom.Redo();
            pnDrawing.Invalidate();
        }

        private void toolMenuItemClear_Click(object sender, EventArgs e)
        {
            pnDrawing.m_MouseHandler.End();

            pnDrawing.Init(this);
            pnDrawing.Invalidate();
        }

        private bool CopyImg()
        {
            try
            {
                Bitmap bmp = new Bitmap(pnDrawing.Width, pnDrawing.Height);
                Graphics g = Graphics.FromImage(bmp);
                g.Clear(Color.White);
                g.DrawImage(pnDrawing.image, Point.Empty);

                Clipboard.SetImage(bmp);

                bmp.Dispose();
                g.Dispose();
            }
            catch (Exception e)
            {
                return false;
            }

            return true;


            //MemoryStream stream = new MemoryStream();
            //pnDrawing.image.Save(stream, ImageFormat.Png);
            //DataObject data = new DataObject("PNG", stream);
            //Clipboard.SetDataObject(data, true);

            //return true;


        }

        private bool PasteImg()
        {
            if (Clipboard.ContainsImage())
            {
                Bitmap bitmap = (Bitmap)Clipboard.GetImage();
                //bitmap.MakeTransparent();

                pnDrawing.image = bitmap;
                pnDrawing.Invalidate();
                return true;
            }
            return false;
            


            //MemoryStream stream = new MemoryStream();

            //IDataObject data = new DataObject("PNG", stream);

            //if(Clipboard.ContainsImage())
            //    data = Clipboard.GetDataObject();

            //pnDrawing.image = Image.FromStream(stream);
            //pnDrawing.Invalidate();

            //return true;
        }

        private void itemFillSolid_Click(object sender, EventArgs e)
        {
            pnDrawing.penCustom.ChooseBrush(BRUSH_TYPE.solid);
            toolItemFillMode.Image = ((ToolStripItem)sender).Image;
        }

        private void itemFillGradient_Click(object sender, EventArgs e)
        {
            pnDrawing.penCustom.ChooseBrush(BRUSH_TYPE.linearGradient);
            toolItemFillMode.Image = ((ToolStripItem)sender).Image;
        }

        private void itemFillHatch_Click(object sender, EventArgs e)
        {
            pnDrawing.penCustom.ChooseBrush(BRUSH_TYPE.hatch);
            toolItemFillMode.Image = ((ToolStripItem)sender).Image;
        }

        private void itemFillTexture_Click(object sender, EventArgs e)
        {
            pnDrawing.penCustom.ChooseBrush(BRUSH_TYPE.texture);
            toolItemFillMode.Image = ((ToolStripItem)sender).Image;
        }
    }
}
