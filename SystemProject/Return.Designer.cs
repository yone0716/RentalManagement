
namespace SystemProject
{
    partial class Return
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
            this.ボタン = new System.Windows.Forms.DataGridViewButtonColumn();
            this.貸出No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SEQ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.物品名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.返却者 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.返却日予定日 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.保管場所入 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
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
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ボタン,
            this.貸出No,
            this.SEQ,
            this.物品名,
            this.返却者,
            this.返却日予定日,
            this.保管場所入});
            this.dataGridView1.Location = new System.Drawing.Point(157, 220);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(623, 82);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // ボタン
            // 
            this.ボタン.HeaderText = "ボタン";
            this.ボタン.Name = "ボタン";
            this.ボタン.ReadOnly = true;
            this.ボタン.Text = "メンテ";
            this.ボタン.ToolTipText = "ボタン";
            this.ボタン.Width = 50;
            // 
            // 貸出No
            // 
            this.貸出No.DataPropertyName = "T002_RENTNO";
            this.貸出No.HeaderText = "貸出No.";
            this.貸出No.Name = "貸出No";
            this.貸出No.ReadOnly = true;
            this.貸出No.Width = 80;
            // 
            // SEQ
            // 
            this.SEQ.DataPropertyName = "T002_RENTSEQ";
            this.SEQ.HeaderText = "SEQ";
            this.SEQ.Name = "SEQ";
            this.SEQ.ReadOnly = true;
            this.SEQ.Width = 50;
            // 
            // 物品名
            // 
            this.物品名.DataPropertyName = "M001_BUPNNM";
            this.物品名.HeaderText = "物品名";
            this.物品名.Name = "物品名";
            this.物品名.ReadOnly = true;
            // 
            // 返却者
            // 
            this.返却者.DataPropertyName = "T001_RENTCONT";
            this.返却者.HeaderText = "返却者";
            this.返却者.Name = "返却者";
            this.返却者.ReadOnly = true;
            // 
            // 返却日予定日
            // 
            this.返却日予定日.DataPropertyName = "T002_RETRNPLAN";
            this.返却日予定日.HeaderText = "返却日予定日";
            this.返却日予定日.Name = "返却日予定日";
            this.返却日予定日.ReadOnly = true;
            // 
            // 保管場所入
            // 
            this.保管場所入.DataPropertyName = "T002_RENTLCAT1";
            this.保管場所入.HeaderText = "保管場所(入)";
            this.保管場所入.Name = "保管場所入";
            this.保管場所入.ReadOnly = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("MS UI Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(405, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 33);
            this.label2.TabIndex = 6;
            this.label2.Text = "返却画面";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(249, 146);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(353, 19);
            this.textBox1.TabIndex = 5;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(153, 146);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "物品コード";
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.BackColor = System.Drawing.Color.DodgerBlue;
            this.panel1.Controls.Add(this.label15);
            this.panel1.Location = new System.Drawing.Point(43, 344);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(108, 19);
            this.panel1.TabIndex = 56;
            // 
            // label15
            // 
            this.label15.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label15.ForeColor = System.Drawing.Color.Transparent;
            this.label15.Location = new System.Drawing.Point(15, 3);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(71, 12);
            this.label15.TabIndex = 41;
            this.label15.Text = "【補足説明】";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Window;
            this.textBox3.Enabled = false;
            this.textBox3.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.textBox3.ForeColor = System.Drawing.Color.Black;
            this.textBox3.Location = new System.Drawing.Point(157, 344);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(756, 19);
            this.textBox3.TabIndex = 43;
            this.textBox3.Text = "物品コードを入力してください";
            // 
            // button14
            // 
            this.button14.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button14.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button14.Location = new System.Drawing.Point(846, 380);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(67, 58);
            this.button14.TabIndex = 47;
            this.button14.Text = "F12";
            this.button14.UseVisualStyleBackColor = true;
            // 
            // button13
            // 
            this.button13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button13.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button13.Location = new System.Drawing.Point(773, 380);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(67, 58);
            this.button13.TabIndex = 46;
            this.button13.Text = "終了\r\nF11\r\n";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button12
            // 
            this.button12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button12.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button12.Location = new System.Drawing.Point(700, 380);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(67, 58);
            this.button12.TabIndex = 45;
            this.button12.Text = "取消\r\nF10";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button11
            // 
            this.button11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button11.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button11.Location = new System.Drawing.Point(627, 380);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(67, 58);
            this.button11.TabIndex = 55;
            this.button11.Text = "F9";
            this.button11.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button10.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button10.Location = new System.Drawing.Point(554, 380);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(67, 58);
            this.button10.TabIndex = 44;
            this.button10.Text = "更新\r\nF8\r\n";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            this.button10.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // button9
            // 
            this.button9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button9.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button9.Location = new System.Drawing.Point(481, 380);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(67, 58);
            this.button9.TabIndex = 54;
            this.button9.Text = "F7";
            this.button9.UseVisualStyleBackColor = true;
            // 
            // button8
            // 
            this.button8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button8.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button8.Location = new System.Drawing.Point(408, 380);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(67, 58);
            this.button8.TabIndex = 53;
            this.button8.Text = "F6";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            this.button7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button7.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button7.Location = new System.Drawing.Point(335, 380);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(67, 58);
            this.button7.TabIndex = 52;
            this.button7.Text = "F5";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button6.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button6.Location = new System.Drawing.Point(262, 380);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(67, 58);
            this.button6.TabIndex = 51;
            this.button6.Text = "F4";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button5.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button5.Location = new System.Drawing.Point(189, 380);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(67, 58);
            this.button5.TabIndex = 50;
            this.button5.Text = "F3";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button4.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button4.Location = new System.Drawing.Point(116, 380);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(67, 58);
            this.button4.TabIndex = 49;
            this.button4.Text = "F2";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button3.Font = new System.Drawing.Font("Meiryo UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button3.Location = new System.Drawing.Point(43, 380);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(67, 58);
            this.button3.TabIndex = 48;
            this.button3.Text = "F1";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Meiryo UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.Location = new System.Drawing.Point(246, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(356, 17);
            this.label3.TabIndex = 57;
            this.label3.Text = "返却された物品のコードを入力またはバーコードを読み込んでください";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // Return
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(939, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox3);
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
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "Return";
            this.Text = "Return";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBox3;
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
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewButtonColumn ボタン;
        private System.Windows.Forms.DataGridViewTextBoxColumn 貸出No;
        private System.Windows.Forms.DataGridViewTextBoxColumn SEQ;
        private System.Windows.Forms.DataGridViewTextBoxColumn 物品名;
        private System.Windows.Forms.DataGridViewTextBoxColumn 返却者;
        private System.Windows.Forms.DataGridViewTextBoxColumn 返却日予定日;
        private System.Windows.Forms.DataGridViewTextBoxColumn 保管場所入;
        private System.Windows.Forms.Label label3;
    }
}