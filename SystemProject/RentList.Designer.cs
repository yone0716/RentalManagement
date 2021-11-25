
namespace SystemProject
{
    partial class RentList
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
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.物品名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.返却予定日 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.返却日 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Number,
            this.物品名,
            this.返却予定日,
            this.返却日});
            this.dataGridView1.Location = new System.Drawing.Point(22, 130);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 21;
            this.dataGridView1.Size = new System.Drawing.Size(679, 258);
            this.dataGridView1.TabIndex = 129;
            // 
            // Number
            // 
            this.Number.DataPropertyName = "M001_BUPNCD";
            this.Number.HeaderText = "物品コード";
            this.Number.MaxInputLength = 5;
            this.Number.Name = "Number";
            this.Number.ReadOnly = true;
            // 
            // 物品名
            // 
            this.物品名.DataPropertyName = "M001_BUPNNM";
            this.物品名.HeaderText = "物品名";
            this.物品名.MaxInputLength = 20;
            this.物品名.Name = "物品名";
            this.物品名.ReadOnly = true;
            this.物品名.Width = 240;
            // 
            // 返却予定日
            // 
            this.返却予定日.DataPropertyName = "M001_BUPNKND";
            this.返却予定日.HeaderText = "物品種別";
            this.返却予定日.MaxInputLength = 1;
            this.返却予定日.Name = "返却予定日";
            this.返却予定日.ReadOnly = true;
            // 
            // 返却日
            // 
            this.返却日.DataPropertyName = "M001_BUPNCND";
            this.返却日.HeaderText = "状態（付属品）";
            this.返却日.MaxInputLength = 50;
            this.返却日.Name = "返却日";
            this.返却日.ReadOnly = true;
            this.返却日.Width = 200;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS UI Gothic", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(244, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(241, 37);
            this.label1.TabIndex = 130;
            this.label1.Text = "貸出可能リスト";
            // 
            // RentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(727, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "RentList";
            this.Text = "RentList";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn 物品名;
        private System.Windows.Forms.DataGridViewTextBoxColumn 返却予定日;
        private System.Windows.Forms.DataGridViewTextBoxColumn 返却日;
    }
}