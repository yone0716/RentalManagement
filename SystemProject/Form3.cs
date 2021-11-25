using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
namespace SystemProject
{
    //  enumの定義
    enum Form3NowFocus
    {
        comboBox1,    //  物品名称
        comboBox2,    //  削除
        comboBox3,    //  貸出
        button3,      //  表示
       // button11,   //  印刷
       // button12,   //  取消
       // button13,   //  終了
        
    }
    public partial class Form3 : Form
    {
        //初期値設定
        decimal BUPNDEL = 0;
        decimal BUPNKND = 1;
        decimal BUPNRENT = 1;
        String err_msg = "";

        Error error = new Error();

        //SQLの中身を取り出したデータテーブル
        DataTable dt = new DataTable();

        // 現在の日時を取得
        DateTime now = DateTime.Now;

        // ErrorProviderのインスタンスを生成
        ErrorProvider errorProvider = new ErrorProvider();

        // 列挙型のインスタンスを生成
        Form3NowFocus form3NowFocus = new Form3NowFocus();

        SQL SQL = new SQL();

        CrystalReport CR = new CrystalReport();

        public Form3()
        {
            InitializeComponent();
            comboBox1.Focus();

        }

        private void Form3_Load(object sender, EventArgs e)
        {
           
            Lock();
          
            dataGridView1.Enabled = false;

            //カラム数を指定
            dataGridView1.ColumnCount = 8;

            // カラム名を指定
            dataGridView1.Columns[0].HeaderText = "ボタン";
            dataGridView1.Columns[1].HeaderText = "保管場所";
            dataGridView1.Columns[2].HeaderText = "類";
            dataGridView1.Columns[3].HeaderText = "物品コード";
            dataGridView1.Columns[4].HeaderText = "物品名";
            dataGridView1.Columns[5].HeaderText = "貸出";
            dataGridView1.Columns[6].HeaderText = "状態(付属品)";
            dataGridView1.Columns[7].HeaderText = "削除";

            comboBox1.MaxLength = 1;
            comboBox2.MaxLength = 1;
            comboBox3.MaxLength = 1;

            // アイコンを点滅なしに設定する
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        }

        public void Lock()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = true;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;
            button9.Enabled = false;
            button10.Enabled = false;
            button11.Enabled = false;
            button12.Enabled = true;
            button13.Enabled = true;
        }

        public void Unlock()
        {
            button11.Enabled = true;
            button12.Enabled = true;
            button13.Enabled = true;
        }

        public void PushDelete()
        {
            dt.Clear();
        }
        private void ControlKeyEvent(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            keyTest(e);
        }

        private void keyTest(System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                
                string Focus = this.ActiveControl.Name;
                if (Enum.TryParse(Focus, out form3NowFocus))
                {
                    switch (form3NowFocus)
                    {
                        case Form3NowFocus.comboBox1:
                            comboBox3.Focus();
                            break;
                        case Form3NowFocus.comboBox2:
                            button3.Focus();
                            break;
                        case Form3NowFocus.comboBox3:
                            comboBox2.Focus();
                            break;
                        case Form3NowFocus.button3:
                            comboBox1.Focus();
                            break;

                    }
                }
            }

            // F9キー(印刷)を入力したとき
            if (e.KeyData==Keys.F9)
            {
                DialogResult result = MessageBox.Show("印刷しますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                //何が選択されたか調べる
                if (result == DialogResult.OK)
                {
                   
                }
            }


            //  F10キー(取消)を入力したとき
            if (e.KeyData == Keys.F10)
            {
                DialogResult result = MessageBox.Show("データを取り消しますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                //何が選択されたか調べる
                if (result == DialogResult.OK)
                {
                    //「OK」が選択された時

                    PushDelete();
                    Lock();
                }
            }

            //  F11キー(終了)を入力したとき
            if (e.KeyData == Keys.F11)
            {
                DialogResult result = MessageBox.Show("終了しますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                //何が選択されたか調べる
                if (result == DialogResult.OK)
                {
                    //次画面を非表示
                    this.Visible = false;
                    //Form1を表示
                    //Form1 f1 = new Form1();
                    //f1.Show();
                }
            }
        }

 
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            //ボタンがクリックされた
            if (dgv.Columns[e.ColumnIndex].Name == "ボタン")
            {
                //Console.WriteLine(dt.Rows[e.RowIndex][2]);

                //次画面を非表示
              //  this.Visible = false;

                string ReceiveBupncd = dt.Rows[e.RowIndex][2].ToString();

                //Form1を表示
                Form2 f2 = new Form2(ReceiveBupncd);
                f2.Show();
            }
        }

        // 印刷ボタンをクリックしたとき
        private void button11_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("印刷しますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

            //何が選択されたか調べる
            if (result == DialogResult.OK)
            {
                // プリンタに印刷
               CR.PrintToPrinter(0, false, 0, 0);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("データを取り消しますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

            //何が選択されたか調べる
            if (result == DialogResult.OK)
            {
                //「OK」が選択された時

                PushDelete();
                Lock();
            }
        }

        // F11キーをクリックしたとき
        private void button13_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("終了しますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

            //何が選択されたか調べる
            if (result == DialogResult.OK)
            {
                //次画面を非表示
                this.Visible = false;
            //    //Form1を表示
            //    Form1 f1 = new Form1();
            //    f1.Show();
            }
        }

        // 表示ボタンをクリックしたとき
        private void button3_Click(object sender, EventArgs e)
        {
            Unlock();

            errorProvider.Clear();

            textBox3.Text = "";
            //テーブルデータ初期化
            PushDelete();

            //ロック解除
            dataGridView1.Enabled = true;

            error.IsnullOrEmptyInquiry(errorProvider, err_msg, textBox3, comboBox1, comboBox2, comboBox3);

            if (error.IsnullOrEmptyInquiryCheck(comboBox1, comboBox2, comboBox3))
            {
                SQL.BuppinSearchData(BUPNRENT, BUPNDEL, BUPNKND, dt, dataGridView1);

                // 印字データをセット
                
                CR.SetDataSource(dt);
                CR.Refresh();
                // 物品種別の表示内容の分岐
                if (comboBox1.Text=="1")
                {
                    CR.SetParameterValue("物品種別", "書籍");
                }
                else
                {
                    CR.SetParameterValue("物品種別", "機器");
                }

                // 貸出の表示内容の分岐
                if (comboBox3.Text == "1")
                {
                    CR.SetParameterValue("貸出", "全て");
                }
                
                else if (comboBox3.Text == "2")
                {
                    CR.SetParameterValue("貸出", "貸出中");
                }
                
                else if(comboBox3.Text=="3") 
                {
                    CR.SetParameterValue("貸出", "未貸出");
                }
                // 削除の表示内容の分岐

                if (comboBox2.Text == "1")
                {
                    CR.SetParameterValue("削除", "含まない");
                }
                else
                {
                    CR.SetParameterValue("削除", "含む");
                }
            }          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bupnknd = comboBox1.Text;
            BUPNKND = decimal.Parse(bupnknd);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string del = comboBox2.Text;
            BUPNDEL = decimal.Parse(del);

            //削除含まない場合
            if (BUPNDEL == 1)
            {
                //削除フラグ1（削除を含む）
                BUPNDEL = 0;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string rent = comboBox3.Text;
            BUPNRENT = decimal.Parse(rent);

            if(BUPNRENT == 2)
            {
                //貸出フラグ0（貸出中のみ）
                BUPNRENT = 9;
            }

            if (BUPNRENT == 3)
            {
                //貸出フラグ1（未貸出のみ）
                BUPNRENT = 0;
            }
        }

        
        
        

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 0x31) || (e.KeyChar > 0x32))
            {
                if (e.KeyChar != '\b')
                {
                    e.Handled = true;
                }
            }
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 0x31) || (e.KeyChar > 0x32))
            {
                if (e.KeyChar != '\b')
                {
                    e.Handled = true;
                }
            }
        }

        private void comboBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 0x31) || (e.KeyChar > 0x33))
            {
                if (e.KeyChar != '\b')
                {
                    e.Handled = true;
                }
            }
        }

        

        private void comboBox1_MouseEnter(object sender, EventArgs e)
        {
            textBox3.Text = "物品種別を選択してください。";
        }

        private void comboBox3_MouseEnter(object sender, EventArgs e)
        {
            textBox3.Text = "貸出状況をを選択してください。";
        }

        private void comboBox2_MouseEnter(object sender, EventArgs e)
        {
            textBox3.Text = "削除状況を選択してください。";
        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
