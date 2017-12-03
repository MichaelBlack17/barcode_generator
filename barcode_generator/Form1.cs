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

        private bool check_values()
        {
            int i = 0;
            string temp;
            int range = txt_codes.Lines.Length;         //колличество введеных баркодов

            //проверка введеных баркодов
            for (i = 0; i < range; i++)
            {
                temp = txt_codes.Lines[i].Trim();
                foreach (char let in temp)
                {
                    if (!(Char.IsDigit(let)))
                    {
                        MessageBox.Show("Ошибка в " + (i + 1).ToString() + " строке. Присутствуют недопустимые символы.", "Ошибка входных данных", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        return false;
                    }
                }

                if (!(temp.Length == 13))
                {
                    MessageBox.Show("Ошибка в " + (i + 1).ToString() + " строке, недостаточное количество цифр.", "Ошибка входных данных", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return false;
                }

                

                
            }
            return true;
        }

        private void btn_generate_Click(object sender, EventArgs e)
        {
            btn_generate.Enabled = false;
            progressbar.Value = 0;

            List<string> barcodes = new List<string>(); // cписок введенных баркодов
            List<string> art = new List<string>();      // список артиклов на основе баркодов
            List<Image> barimages = new List<Image>();  // список сгенерированных изображений баркодов
            int i = 0;
            string temp;
            int height = Convert.ToInt32(txt_height.Text);
            int width = Convert.ToInt32(txt_width.Text);
            String folder = txt_folder.Text;
            int range = txt_codes.Lines.Length;         //колличество введеных баркодов

            if (check_values())
            {
                for (i = 0; i < range; i++)
                {
                    temp = txt_codes.Lines[i].Trim();
                    art.Add(temp.Substring(8, 4));          // формирование списка артикулов
                    barcodes.Add(temp);

                    //параметры изображения баркода
                    BarcodeLib.Barcode barcode = new BarcodeLib.Barcode()
                    {
                        IncludeLabel = true,
                        Alignment = AlignmentPositions.CENTER,
                        Width = width,
                        Height = height,
                        RotateFlipType = RotateFlipType.RotateNoneFlipNone,
                        BackColor = Color.White,
                        ForeColor = Color.Black,
                    };

                    //генерация изображения баркода и запись в список
                    Image img = barcode.Encode(TYPE.EAN13, temp);
                    barimages.Add(img);

                    //сохранение изображений баркодов

                    img.Save(folder + "/" + temp + ".png", System.Drawing.Imaging.ImageFormat.Png);
                    progressbar.Value += 50 / range;
                }
                //создание и формирование excel файлов на основе 
                //списков баркодов и изображений
                for (i = 0; i < range; i++)
                {
                    Microsoft.Office.Interop.Excel.Application ExcelAppR = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel.Workbook ObjWorkBook;

                    ObjWorkBook = ExcelAppR.Workbooks.Open(Application.StartupPath + "/Res/ex.xls");
                    Microsoft.Office.Interop.Excel.Worksheet m_workSheet = null;
                    m_workSheet = ExcelAppR.ActiveSheet;

                    int j = 0;
                    for (j = 2; j < 8; j++)
                    {
                        //добавление подписей Артикул под каждый бар код в файле excel
                        m_workSheet.Cells[j * 2 - 1, 1] = "Артикул: " + art[i];
                        m_workSheet.Cells[j * 2 - 1, 2] = "Артикул: " + art[i];
                        m_workSheet.Cells[j * 2 - 1, 3] = "Артикул: " + art[i];

                        //добавление изображений баркода в файл excel
                        int top = Convert.ToInt32(m_workSheet.Cells[j * 2 - 2, 1].Top);
                        int left = Convert.ToInt32(m_workSheet.Cells[j * 2 - 2, 1].Left);
                        m_workSheet.Shapes.AddPicture(folder + "/" + barcodes[i] + ".png", Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, left, top, -1, -1);
                        top = Convert.ToInt32(m_workSheet.Cells[j * 2 - 2, 2].Top);
                        left = Convert.ToInt32(m_workSheet.Cells[j * 2 - 2, 2].Left);
                        m_workSheet.Shapes.AddPicture(folder + "/" + barcodes[i] + ".png", Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, left, top, -1, -1);
                        top = Convert.ToInt32(m_workSheet.Cells[j * 2 - 2, 3].Top);
                        left = Convert.ToInt32(m_workSheet.Cells[j * 2 - 2, 3].Left);
                        m_workSheet.Shapes.AddPicture(folder + "/" + barcodes[i] + ".png", Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, left, top, -1, -1);

                    }


                    ObjWorkBook.SaveAs(folder + "/art-" + art[i] + ".xls",
                        Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal, null, null, null, null,
                        Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, null, null, null, null, null);
                    ObjWorkBook.Close(false, null, null);

                    progressbar.Value += 50 / range;
                }

                progressbar.Value = 100;
            }
            btn_generate.Enabled = true;

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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа генерации excel файлов для печати баркодов.\nАвтор: Черняк Михаил.", "О программе", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
    }
}
