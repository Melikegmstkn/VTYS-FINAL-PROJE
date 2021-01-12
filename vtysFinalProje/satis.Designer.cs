
namespace finalProje
{
    partial class satis
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox2 = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(372, 616);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tutar :";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(38, 92);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(532, 498);
            this.dataGridView1.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(467, 616);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(545, 616);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "TL";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(37, 40);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(129, 22);
            this.textBox1.TabIndex = 5;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(486, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 38);
            this.button1.TabIndex = 6;
            this.button1.Text = "SİL";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnSİL_Click_1);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(375, 687);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(195, 24);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.TextChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "BARKOD :";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(485, 731);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 38);
            this.button2.TabIndex = 9;
            this.button2.Text = "SATIŞ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnSatis_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(372, 667);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "ÖDEME YÖNTEMİ :";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(384, 32);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(85, 38);
            this.button3.TabIndex = 11;
            this.button3.Text = "EKLE";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnEKLE_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 596);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 17);
            this.label8.TabIndex = 61;
            this.label8.Text = "MUSTERİ ADI :";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(192, 616);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(119, 22);
            this.button4.TabIndex = 62;
            this.button4.Text = "YENİ MÜŞTERİ EKLE";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(493, -22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 17);
            this.label7.TabIndex = 63;
            this.label7.Text = "LİSTE";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(37, 616);
            this.maskedTextBox1.Mask = "AAAAAAAAAAAAAAAAAAAAAAAA";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(129, 22);
            this.maskedTextBox1.TabIndex = 64;
            // 
            // maskedTextBox2
            // 
            this.maskedTextBox2.Location = new System.Drawing.Point(219, 40);
            this.maskedTextBox2.Mask = "00000";
            this.maskedTextBox2.Name = "maskedTextBox2";
            this.maskedTextBox2.Size = new System.Drawing.Size(129, 22);
            this.maskedTextBox2.TabIndex = 65;
            this.maskedTextBox2.ValidatingType = typeof(int);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(216, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 17);
            this.label9.TabIndex = 66;
            this.label9.Text = "ADET :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(35, 714);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 17);
            this.label12.TabIndex = 69;
            this.label12.Text = "Satıcı :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(103, 717);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 17);
            this.label13.TabIndex = 72;
            this.label13.Text = "asdf12";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(35, 687);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(123, 17);
            this.label14.TabIndex = 71;
            this.label14.Text = "AKTİF KULLANICI ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(102, 746);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(16, 17);
            this.label11.TabIndex = 74;
            this.label11.Text = "1";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(35, 741);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(34, 17);
            this.label15.TabIndex = 73;
            this.label15.Text = "No :";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(396, 779);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(84, 55);
            this.button6.TabIndex = 76;
            this.button6.Text = "SATİS TAKİP";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(486, 775);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(85, 59);
            this.button5.TabIndex = 55;
            this.button5.Text = "ANA SAYFA";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // satis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 837);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.maskedTextBox2);
            this.Controls.Add(this.maskedTextBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "satis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SATIŞ";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
    }
}