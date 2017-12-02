namespace barcode_generator
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_generate = new System.Windows.Forms.Button();
            this.txt_codes = new System.Windows.Forms.TextBox();
            this.folder_browser = new System.Windows.Forms.FolderBrowserDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_folder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.check_save = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btn_generate
            // 
            this.btn_generate.Location = new System.Drawing.Point(201, 191);
            this.btn_generate.Name = "btn_generate";
            this.btn_generate.Size = new System.Drawing.Size(204, 55);
            this.btn_generate.TabIndex = 1;
            this.btn_generate.Text = "Generate";
            this.btn_generate.UseVisualStyleBackColor = true;
            this.btn_generate.Click += new System.EventHandler(this.btn_generate_Click);
            // 
            // txt_codes
            // 
            this.txt_codes.Location = new System.Drawing.Point(12, 73);
            this.txt_codes.Multiline = true;
            this.txt_codes.Name = "txt_codes";
            this.txt_codes.Size = new System.Drawing.Size(183, 173);
            this.txt_codes.TabIndex = 2;
            this.txt_codes.Text = "2002500023891";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(290, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Выбрать...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_folder
            // 
            this.txt_folder.Location = new System.Drawing.Point(12, 25);
            this.txt_folder.Name = "txt_folder";
            this.txt_folder.Size = new System.Drawing.Size(272, 20);
            this.txt_folder.TabIndex = 4;
            this.txt_folder.Text = "C:\\temp";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Директория сохранения файлов";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Введите баркоды";
            // 
            // check_save
            // 
            this.check_save.AutoSize = true;
            this.check_save.Location = new System.Drawing.Point(201, 75);
            this.check_save.Name = "check_save";
            this.check_save.Size = new System.Drawing.Size(201, 17);
            this.check_save.TabIndex = 7;
            this.check_save.Text = "Сохранить изображения баркодов";
            this.check_save.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 258);
            this.Controls.Add(this.check_save);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_folder);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_codes);
            this.Controls.Add(this.btn_generate);
            this.Name = "Form1";
            this.Text = "BarCode Generator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_generate;
        private System.Windows.Forms.TextBox txt_codes;
        private System.Windows.Forms.FolderBrowserDialog folder_browser;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt_folder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox check_save;
    }
}

