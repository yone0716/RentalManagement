
namespace SystemProject
{
    partial class Form6
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button14 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button15 = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.ボタン = new System.Windows.Forms.DataGridViewButtonColumn();
            this.貸出Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SEQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.物品名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.貸出日 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.返却予定日 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.貸受者名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.利用者名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ボタン,
            this.貸出Number,
            this.SEQ,
            this.物品名,
            this.貸出日,
            this.返却予定日,
            this.貸受者名,
            this.利用者名});
            this.dataGridView1.Location = new System.Drawing.Point(56, 145);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(970, 394);
            this.dataGridView1.TabIndex = 152;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(870, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 57);
            this.button1.TabIndex = 4;
            this.button1.Text = "表示";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ControlKeyEvent);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("MS UI Gothic", 14F);
            this.textBox2.Location = new System.Drawing.Point(371, 62);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 26);
            this.textBox2.TabIndex = 2;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ControlKeyEvent);
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox2_KeyPress);
            this.textBox2.MouseEnter += new System.EventHandler(this.textBox2_MouseEnter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(321, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 19);
            this.label2.TabIndex = 149;
            this.label2.Text = "～";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(91, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 19);
            this.label1.TabIndex = 148;
            this.label1.Text = "日付";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("MS UI Gothic", 14F);
            this.textBox1.Location = new System.Drawing.Point(194, 62);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 26);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ControlKeyEvent);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            this.textBox1.MouseEnter += new System.EventHandler(this.textBox1_MouseEnter);
            // 
            // comboBox2
            // 
            this.comboBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.comboBox2.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7"});
            this.comboBox2.Location = new System.Drawing.Point(194, 112);
            this.comboBox2.MaxLength = 1;
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(41, 27);
            this.comboBox2.TabIndex = 3;
            this.comboBox2.Text = "0";
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            this.comboBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ControlKeyEvent);
            this.comboBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox2_KeyPress);
            this.comboBox2.MouseEnter += new System.EventHandler(this.comboBox2_MouseEnter);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.Location = new System.Drawing.Point(263, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(626, 19);
            this.label6.TabIndex = 145;
            this.label6.Text = "0 ; 全て 1 : 本体 2 : モニタ 3 : プリンター 4 : モデム  5 :ルーター 6 : ハブ 7 ; その他";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.Location = new System.Drawing.Point(92, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 21);
            this.label5.TabIndex = 144;
            this.label5.Text = "分類コード";
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBox1.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.comboBox1.Items.AddRange(new object[] {
            "1",
            "2"});
            this.comboBox1.Location = new System.Drawing.Point(193, 17);
            this.comboBox1.MaxLength = 1;
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(41, 27);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.Text = "1";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ControlKeyEvent);
            this.comboBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.comboBox1_KeyPress);
            this.comboBox1.MouseEnter += new System.EventHandler(this.comboBox1_MouseEnter);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MS UI Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label4.Location = new System.Drawing.Point(248, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 19);
            this.label4.TabIndex = 142;
            this.label4.Text = "1 : 書籍 2 : 機器";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(92, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 21);
            this.label3.TabIndex = 141;
            this.label3.Text = "物品種別";
            // 
            // button14
            // 
            this.button14.Enabled = false;
            this.button14.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.button14.Location = new System.Drawing.Point(959, 575);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(67, 58);
            this.button14.TabIndex = 140;
            this.button14.Text = "F12";
            this.button14.UseVisualStyleBackColor = true;
            // 
            // button13
            // 
            this.button13.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.button13.Location = new System.Drawing.Point(886, 575);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(67, 58);
            this.button13.TabIndex = 139;
            this.button13.Text = "終了\r\nF11\r\n";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            this.button13.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ControlKeyEvent);
            // 
            // button12
            // 
            this.button12.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.button12.Location = new System.Drawing.Point(813, 575);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(67, 58);
            this.button12.TabIndex = 138;
            this.button12.Text = "取消\r\nF10";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            this.button12.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ControlKeyEvent);
            // 
            // button11
            // 
            this.button11.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.button11.Location = new System.Drawing.Point(740, 575);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(67, 58);
            this.button11.TabIndex = 137;
            this.button11.Text = "印刷\r\nF9";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            this.button11.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ControlKeyEvent);
            // 
            // button10
            // 
            this.button10.Enabled = false;
            this.button10.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.button10.Location = new System.Drawing.Point(623, 575);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(67, 58);
            this.button10.TabIndex = 136;
            this.button10.Text = "F8\r\n";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button9
            // 
            this.button9.Enabled = false;
            this.button9.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.button9.Location = new System.Drawing.Point(550, 575);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(67, 58);
            this.button9.TabIndex = 135;
            this.button9.Text = "F7";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Enabled = false;
            this.button8.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.button8.Location = new System.Drawing.Point(477, 575);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(67, 58);
            this.button8.TabIndex = 134;
            this.button8.Text = "F6";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Enabled = false;
            this.button7.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.button7.Location = new System.Drawing.Point(404, 575);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(67, 58);
            this.button7.TabIndex = 133;
            this.button7.Text = "F5";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Enabled = false;
            this.button6.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.button6.Location = new System.Drawing.Point(275, 575);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(67, 58);
            this.button6.TabIndex = 132;
            this.button6.Text = "F4";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Enabled = false;
            this.button5.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.button5.Location = new System.Drawing.Point(202, 575);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(67, 58);
            this.button5.TabIndex = 131;
            this.button5.Text = "F3";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.button4.Location = new System.Drawing.Point(129, 575);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(67, 58);
            this.button4.TabIndex = 130;
            this.button4.Text = "F2";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button15
            // 
            this.button15.Enabled = false;
            this.button15.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.button15.Location = new System.Drawing.Point(56, 575);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(67, 58);
            this.button15.TabIndex = 129;
            this.button15.Text = "F1";
            this.button15.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            this.label18.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label18.ForeColor = System.Drawing.Color.Transparent;
            this.label18.Location = new System.Drawing.Point(15, 3);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(71, 12);
            this.label18.TabIndex = 41;
            this.label18.Text = "【補足説明】";
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel3.Controls.Add(this.label18);
            this.panel3.Location = new System.Drawing.Point(56, 545);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(99, 19);
            this.panel3.TabIndex = 155;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // textBox3
            // 
            this.textBox3.Enabled = false;
            this.textBox3.Location = new System.Drawing.Point(161, 545);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(865, 19);
            this.textBox3.TabIndex = 154;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // ボタン
            // 
            this.ボタン.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ボタン.HeaderText = "ボタン";
            this.ボタン.Name = "ボタン";
            this.ボタン.ReadOnly = true;
            this.ボタン.Text = "メンテ";
            this.ボタン.ToolTipText = "メンテ";
            this.ボタン.UseColumnTextForButtonValue = true;
            this.ボタン.Width = 40;
            // 
            // 貸出Number
            // 
            this.貸出Number.DataPropertyName = "T001_RENTNO";
            this.貸出Number.HeaderText = "貸出No.";
            this.貸出Number.Name = "貸出Number";
            this.貸出Number.ReadOnly = true;
            this.貸出Number.Width = 80;
            // 
            // SEQ
            // 
            this.SEQ.DataPropertyName = "T002_RENTSEQ";
            this.SEQ.HeaderText = "SEQ";
            this.SEQ.Name = "SEQ";
            this.SEQ.ReadOnly = true;
            this.SEQ.Width = 30;
            // 
            // 物品名
            // 
            this.物品名.DataPropertyName = "M001_BUPNNM";
            this.物品名.HeaderText = "物品名";
            this.物品名.Name = "物品名";
            this.物品名.ReadOnly = true;
            this.物品名.Width = 350;
            // 
            // 貸出日
            // 
            this.貸出日.DataPropertyName = "T001_RENTDATE";
            this.貸出日.HeaderText = "貸出し日";
            this.貸出日.Name = "貸出日";
            this.貸出日.ReadOnly = true;
            // 
            // 返却予定日
            // 
            this.返却予定日.DataPropertyName = "T002_RETRNPLAN";
            this.返却予定日.HeaderText = "返却予定日";
            this.返却予定日.Name = "返却予定日";
            this.返却予定日.ReadOnly = true;
            this.返却予定日.Width = 90;
            // 
            // 貸受者名
            // 
            this.貸受者名.DataPropertyName = "T001_RENTCONT";
            this.貸受者名.HeaderText = "貸受者名";
            this.貸受者名.Name = "貸受者名";
            this.貸受者名.ReadOnly = true;
            this.貸受者名.Width = 120;
            // 
            // 利用者名
            // 
            this.利用者名.DataPropertyName = "T001_RENTUSER";
            this.利用者名.HeaderText = "利用者名";
            this.利用者名.Name = "利用者名";
            this.利用者名.ReadOnly = true;
            this.利用者名.Width = 120;
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1104, 650);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button14);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button15);
            this.Name = "Form6";
            this.Text = "未返却照会";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form6_FormClosed);
            this.Load += new System.EventHandler(this.Form6_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.DataGridViewButtonColumn ボタン;
        private System.Windows.Forms.DataGridViewTextBoxColumn 貸出Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn SEQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn 物品名;
        private System.Windows.Forms.DataGridViewTextBoxColumn 貸出日;
        private System.Windows.Forms.DataGridViewTextBoxColumn 返却予定日;
        private System.Windows.Forms.DataGridViewTextBoxColumn 貸受者名;
        private System.Windows.Forms.DataGridViewTextBoxColumn 利用者名;
    }
}