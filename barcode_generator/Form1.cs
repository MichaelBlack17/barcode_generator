using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BarcodeLib;

namespace barcode_generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_generate_Click(object sender, EventArgs e)
        {
            List<string> barcodes = new List<string>();
            List<Image> barimages = new List<Image>();
            int i = 0;
            string temp;
            for (i = 0; i < txt_codes.Lines.Length - 1; i++ )
            {
                temp = txt_codes.Lines[i].Trim();
                foreach (char let in temp)
                {
                    if  (!(Char.IsDigit(let)))
                    {
                        MessageBox.Show("Ошибка в " + (i + 1).ToString() + " строке. Присутствуют недопустимые символы.", "Ошибка входных данных", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        break;
                    }
                }

                if (!(temp.Length == 13))
                {
                    MessageBox.Show("Ошибка в " + (i+1).ToString() + " строке, недостаточное количество цифр.", "Ошибка входных данных", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }

                String folder = txt_folder.Text;
                BarcodeLib.Barcode barcode = new BarcodeLib.Barcode()
                {
                    IncludeLabel = true,
                    Alignment = AlignmentPositions.CENTER,
                    Width = 300,
                    Height = 100,
                    RotateFlipType = RotateFlipType.RotateNoneFlipNone,
                    BackColor = Color.White,
                    ForeColor = Color.Black,
                };

                Image img = barcode.Encode(TYPE.EAN13, temp);
                img.Save(folder + "/" + temp +".png",System.Drawing.Imaging.ImageFormat.Png);

            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folder_browser.ShowDialog() == DialogResult.OK)
            {
                txt_folder.Text = folder_browser.SelectedPath;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
