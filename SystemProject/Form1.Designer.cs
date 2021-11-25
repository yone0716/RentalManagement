
namespace SystemProject
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button9 = new System.Windows.Forms.Button();
            this.End_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.White;
            this.button4.Font = new System.Drawing.Font("Meiryo UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.Location = new System.Drawing.Point(18, 121);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(260, 59);
            this.button4.TabIndex = 3;
            this.button4.Text = "貸出中照会";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.White;
            this.button5.Font = new System.Drawing.Font("Meiryo UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button5.ForeColor = System.Drawing.Color.Black;
            this.button5.Location = new System.Drawing.Point(18, 199);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(260, 59);
            this.button5.TabIndex = 4;
            this.button5.Text = "未返却照会";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Location = new System.Drawing.Point(54, 191);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(664, 395);
            this.panel1.TabIndex = 56;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Font = new System.Drawing.Font("Meiryo UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Image = global::SystemProject.Properties.Resources.PCディスプレイのアイコン素材_2;
            this.button1.Location = new System.Drawing.Point(46, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(260, 311);
            this.button1.TabIndex = 1;
            this.button1.Text = "\r\n\r\n\r\n\r\n\r\n\r\n\r\n物品登録";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.BackgroundImage = global::SystemProject.Properties.Resources.本アイコン;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button3.Font = new System.Drawing.Font("Meiryo UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(363, 43);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(260, 311);
            this.button3.TabIndex = 2;
            this.button3.Text = "\r\n\r\n\r\n\r\n\r\n\r\n\r\n貸出登録";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightCoral;
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Location = new System.Drawing.Point(748, 191);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(300, 287);
            this.panel2.TabIndex = 57;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button2.Font = new System.Drawing.Font("Meiryo UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(18, 43);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(260, 59);
            this.button2.TabIndex = 2;
            this.button2.Text = "物品照会";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Pink;
            this.panel3.Controls.Add(this.button9);
            this.panel3.Location = new System.Drawing.Point(748, 507);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(300, 79);
            this.panel3.TabIndex = 60;
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.White;
            this.button9.Font = new System.Drawing.Font("Meiryo UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button9.ForeColor = System.Drawing.Color.Black;
            this.button9.Location = new System.Drawing.Point(18, 13);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(260, 52);
            this.button9.TabIndex = 50;
            this.button9.Text = "返却";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // End_Button
            // 
            this.End_Button.Font = new System.Drawing.Font("Meiryo UI", 12F);
            this.End_Button.ForeColor = System.Drawing.Color.Black;
            this.End_Button.Location = new System.Drawing.Point(936, 83);
            this.End_Button.Name = "End_Button";
            this.End_Button.Size = new System.Drawing.Size(112, 80);
            this.End_Button.TabIndex = 96;
            this.End_Button.Text = "終了\r\nF11\r\n";
            this.End_Button.UseVisualStyleBackColor = true;
            this.End_Button.Click += new System.EventHandler(this.End_Button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Meiryo UI", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.Location = new System.Drawing.Point(180, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(441, 61);
            this.label1.TabIndex = 97;
            this.label1.Text = "物品貸し出しシステム";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1104, 631);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.End_Button);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "メニュー画面";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button End_Button;
        private System.Windows.Forms.Label label1;
    }
}

