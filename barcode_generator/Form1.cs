﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            int i = 0;
            string temp;
            for (i = 0; i < txt_codes.Lines.Length; i++ )
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
            
                


                if (temp.Length == 13)
                {
                    continue;
                }
                else
                {
                    MessageBox.Show("Ошибка в " + (i+1).ToString() + " строке, недостаточное количество цифр.", "Ошибка входных данных", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    break;
                }
                    
            }
           
        }
    }
}