using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _14520404_Paint
{
    public partial class Setting : Form
    {
        public Setting()
        {
            InitializeComponent();

            txtSetWidth.Text = Properties.Settings.Default.panel_width.ToString();
            txtSetHeigh.Text = Properties.Settings.Default.panel_heigh.ToString();
        }
        

        private void txt_OnlyNumber(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;

            if (System.Text.RegularExpressions.Regex.IsMatch(txt.Text, "[^0-9]"))
            {
                txt.Text = txt.Text.Remove(txt.Text.Length - 1);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Enter))
            {
                return OnOK();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void btnSetOK_Click(object sender, EventArgs e)
        {
            OnOK();
        }

        bool OnOK()
        {
            try
            {
                Properties.Settings.Default.panel_width = int.Parse(txtSetWidth.Text);
                Properties.Settings.Default.panel_heigh = int.Parse(txtSetHeigh.Text);
            }
            catch (Exception ex)
            {
                return false;
            }
            DialogResult = DialogResult.OK;
            return true;
        }

        private void btnTexture_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openDialog = new OpenFileDialog();
                openDialog.Filter = "image file|*.bmp;*.jpg;*.jpeg;*.png";

                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    btnTexture.BackgroundImage = new Bitmap(openDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Image!", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
