using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Data.SqlClient;
namespace SystemProject
{
    enum Form6NowFocus
    {
        comboBox1,  // 物品種別
        textBox1,   // 日付(From)
        textBox2,   // 日付(To)
        comboBox2,  // 分類
        button1,    // 表示

    }
    public partial class Form6 : Form
    {
        //初期値設定
        decimal BUPNGRP = 0;
        decimal BUPNKND = 1;
        string FromDay = "";
        string ToDay = "";
        String err_msg = "";
        string SQLText = "";
      

        Error error = new Error();

        //SQLの中身を取り出したデータテーブル
        DataTable dt = new DataTable();

        // 現在の日時を取得
        DateTime now = DateTime.Now;

        // ErrorProviderのインスタンスを生成
        ErrorProvider errorProvider = new ErrorProvider();

        Form6NowFocus form6NowFocus = new Form6NowFocus();

        CategoryCord categoryCord = new CategoryCord();
        SQL SQL = new SQL();

        CrystalReport3 CR = new CrystalReport3();


        public Form6()
        {
            InitializeComponent();
            comboBox1.Focus();
        }
        private void Form6_Load(object sender, EventArgs e)
        {

            //カラム数を指定
            dataGridView1.ColumnCount = 8;

            dataGridView1.Columns[0].HeaderText = "ボタン";
            dataGridView1.Columns[1].HeaderText = "貸出No";
            dataGridView1.Columns[2].HeaderText = "SEQ";
            dataGridView1.Columns[3].HeaderText = "物品名";
            dataGridView1.Columns[4].HeaderText = "貸出日";
            dataGridView1.Columns[5].HeaderText = "返却予定日";
            dataGridView1.Columns[6].HeaderText = "借受者名";
            dataGridView1.Columns[7].HeaderText = "利用者名";
           
            
            dataGridView1.Enabled = false;
            comboBox1.Focus();
            // アイコンを点滅なしに設定する
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        }
        public void PushDelete()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            comboBox1.Text = "1";
            comboBox2.Text = "0";
            dt.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //テーブルデータ初期化
            // PushDelete();

            //ロック解除
            dataGridView1.Enabled = true;


            errorProvider.Clear();

            //error.IsnullOrEmptyForm5Inquiry(errorProvider, err_msg, textBox3, comboBox1, textBox1, textBox2, comboBox2);


            if (comboBox2.Text == "0")
            {
               
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    SQLText = $"SELECT T001_RENT_DTL.T002_RENTSEQ," +
                           " M001_BUPPIN.M001_BUPNNM, " + 
                           " T001_RENT_HED.T001_RENTDATE, " +
                           " T001_RENT_DTL.T002_RETRNPLAN, " +
                           " T001_RENT_HED.T001_RENTCONT," +
                           " T001_RENT_HED.T001_RENTUSER," +
                           " T001_RENT_HED.T001_RENTNO" +
                           " FROM T001_RENT_DTL " +
                           " JOIN M001_BUPPIN ON T001_RENT_DTL.T002_BUPNCD = M001_BUPPIN.M001_BUPNCD" +
                           " JOIN T001_RENT_HED ON T001_RENT_DTL.T002_RENTNO = T001_RENT_HED.T001_RENTNO" +
                          $" WHERE M001_BUPNKND = {BUPNKND} AND M001_BUPNRENT = 9 AND T002_RETRNPLAN <= {ToDay} AND T002_RETRNDATE = '' ;";
                }

                else if (string.IsNullOrEmpty(textBox2.Text))
                {
                    SQLText = $"SELECT T001_RENT_DTL.T002_RENTSEQ," +
                           " M001_BUPPIN.M001_BUPNNM, " +
                           " T001_RENT_HED.T001_RENTDATE, " +
                           " T001_RENT_DTL.T002_RETRNPLAN, " +
                           " T001_RENT_HED.T001_RENTCONT," +
                           " T001_RENT_HED.T001_RENTUSER," +
                           " T001_RENT_HED.T001_RENTNO" +
                           " FROM T001_RENT_DTL " +
                           " JOIN M001_BUPPIN ON T001_RENT_DTL.T002_BUPNCD = M001_BUPPIN.M001_BUPNCD" +
                           " JOIN T001_RENT_HED ON T001_RENT_DTL.T002_RENTNO = T001_RENT_HED.T001_RENTNO" +
                          $" WHERE M001_BUPNKND = {BUPNKND} AND M001_BUPNRENT = 9 AND {FromDay} <= T002_RETRNPLAN AND T002_RETRNDATE = '' ;";
                }
                else
                {
                    SQLText = $"SELECT T001_RENT_DTL.T002_RENTSEQ," +
                           " M001_BUPPIN.M001_BUPNNM, " +
                           " T001_RENT_HED.T001_RENTDATE, " +
                           " T001_RENT_DTL.T002_RETRNPLAN, " +
                           " T001_RENT_HED.T001_RENTCONT," +
                           " T001_RENT_HED.T001_RENTUSER," +
                           " T001_RENT_HED.T001_RENTNO" +
                           " FROM T001_RENT_DTL " +
                           " JOIN M001_BUPPIN ON T001_RENT_DTL.T002_BUPNCD = M001_BUPPIN.M001_BUPNCD" +
                           " JOIN T001_RENT_HED ON T001_RENT_DTL.T002_RENTNO = T001_RENT_HED.T001_RENTNO" +
                          $" WHERE M001_BUPNKND = {BUPNKND} AND M001_BUPNRENT = 9 AND {FromDay} <= T002_RETRNPLAN AND T002_RETRNPLAN <= {ToDay} AND T002_RETRNDATE = '' ;";
                }
                
            }
            else
            {
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    SQLText = $"SELECT T001_RENT_DTL.T002_RENTSEQ," +
                          " M001_BUPPIN.M001_BUPNNM," +
                          " T001_RENT_HED.T001_RENTDATE, " +
                          " T001_RENT_DTL.T002_RETRNPLAN," +
                          " T001_RENT_HED.T001_RENTCONT," +
                          " T001_RENT_HED.T001_RENTUSER," +
                          " T001_RENT_HED.T001_RENTNO " +
                          " FROM T001_RENT_DTL" +
                          " JOIN M001_BUPPIN ON T001_RENT_DTL.T002_BUPNCD = M001_BUPPIN.M001_BUPNCD" +
                          " JOIN T001_RENT_HED ON T001_RENT_DTL.T002_RENTNO = T001_RENT_HED.T001_RENTNO" +
                          $" WHERE M001_BUPNGRP = {BUPNGRP} " +
                          $" AND M001_BUPNKND = {BUPNKND}" +
                          $" AND T002_RETRNPLAN <= {ToDay} " +
                           " AND T002_RETRNDATE = '' "+
                           " AND M001_BUPNRENT = 9;";
                }
                else if (string.IsNullOrEmpty(textBox2.Text))
                {
                    SQLText = $"SELECT T001_RENT_DTL.T002_RENTSEQ, "+
                          " M001_BUPPIN.M001_BUPNNM," +
                          " T001_RENT_HED.T001_RENTDATE, " +
                          " T001_RENT_DTL.T002_RETRNPLAN," +
                          " T001_RENT_HED.T001_RENTCONT," +
                          " T001_RENT_HED.T001_RENTUSER," +
                          " T001_RENT_HED.T001_RENTNO " +
                          " FROM T001_RENT_DTL" +
                          " JOIN M001_BUPPIN ON T001_RENT_DTL.T002_BUPNCD = M001_BUPPIN.M001_BUPNCD" +
                          " JOIN T001_RENT_HED ON T001_RENT_DTL.T002_RENTNO = T001_RENT_HED.T001_RENTNO" +
                         $" WHERE M001_BUPNGRP = {BUPNGRP} " +
                         $" AND M001_BUPNKND = {BUPNKND}" +
                         $" AND {FromDay} <= T002_RETRNPLAN " +
                          " AND T002_RETRNDATE = '' " +
                          " AND M001_BUPNRENT = 9;";
                }
                else
                {
                    SQLText = $"SELECT T001_RENT_DTL.T002_RENTSEQ," +
                          " M001_BUPPIN.M001_BUPNNM," +
                          " T001_RENT_HED.T001_RENTDATE, " +
                          " T001_RENT_DTL.T002_RETRNPLAN," +
                          " T001_RENT_HED.T001_RENTCONT," +
                          " T001_RENT_HED.T001_RENTUSER," +
                          " T001_RENT_HED.T001_RENTNO " +
                          " FROM T001_RENT_DTL" +
                          " JOIN M001_BUPPIN ON T001_RENT_DTL.T002_BUPNCD = M001_BUPPIN.M001_BUPNCD" +
                          " JOIN T001_RENT_HED ON T001_RENT_DTL.T002_RENTNO = T001_RENT_HED.T001_RENTNO" +
                         $" WHERE M001_BUPNGRP = {BUPNGRP} " +
                         $" AND M001_BUPNKND = {BUPNKND}" +
                         $" AND {FromDay} <= T002_RETRNPLAN AND T002_RETRNPLAN <= {ToDay} " +
                          " AND T002_RETRNDATE = '' " +
                          " AND M001_BUPNRENT = 9;";
                }
                
            }
            error.IsNullOrEmptyForm6Inquiry(errorProvider, err_msg, textBox3, textBox1, textBox2);
            if (error.IsNullOrEmptyForm6InquiryCheck(textBox1,textBox2))
            {
               
                dataGridView1.DataSource = SQL.RentList(SQL, SQLText, dt);

                CR.SetDataSource(dt);
                CR.Refresh();
            }
            

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
                if (Enum.TryParse(Focus, out form6NowFocus))
                {
                    switch (form6NowFocus)
                    {
                        case Form6NowFocus.comboBox1:
                            textBox1.Focus();
                            break;
                        case Form6NowFocus.textBox1:
                            textBox2.Focus();
                            break;
                        case Form6NowFocus.textBox2:
                            comboBox2.Focus();
                            break;
                        case Form6NowFocus.comboBox2:
                            button1.Focus();
                            break;
                        case Form6NowFocus.button1:
                            comboBox1.Focus();
                            break;

                    }
                }
            }

            // F9キーが押されたとき
            if (e.KeyData == Keys.F9)
            {
                // 印刷
                DialogResult result = MessageBox.Show("印刷しますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                //何が選択されたか調べる
                if (result == DialogResult.OK)
                {
                    if (comboBox1.Text == "1")
                    {
                        CR.SetParameterValue("物品種別", "書籍");
                    }
                    else
                    {
                        CR.SetParameterValue("物品種別", "機器");
                    }

                    string Cord = comboBox2.Text;
                    if (Enum.TryParse(Cord, out categoryCord))
                    {
                        switch (categoryCord)
                        {
                            case CategoryCord.全て:
                                CR.SetParameterValue("分類", "全て");
                                break;

                            case CategoryCord.本体:
                                CR.SetParameterValue("分類", "本体");
                                break;

                            case CategoryCord.モニタ:
                                CR.SetParameterValue("分類", "モニタ");
                                break;

                            case CategoryCord.プリンター:
                                CR.SetParameterValue("分類", "プリンター");
                                break;

                            case CategoryCord.モデム:
                                CR.SetParameterValue("分類", "モデム");
                                break;

                            case CategoryCord.ルーター:
                                CR.SetParameterValue("分類", "ルーター");
                                break;
                            case CategoryCord.ハブ:
                                CR.SetParameterValue("分類", "ハブ");
                                break;
                            case CategoryCord.その他:
                                CR.SetParameterValue("分類", "その他");
                                break;
                        }
                    }

                    if (string.IsNullOrEmpty(textBox1.Text))
                    {
                        string format = "yyyyMMdd";
                        DateTime Time;
                        Time = DateTime.ParseExact(textBox2.Text, format, null);
                        CR.SetParameterValue("日付", "");
                        CR.SetParameterValue("後日付", Time.ToShortDateString());
                    }

                    else if (string.IsNullOrEmpty(textBox2.Text))
                    {
                        string format = "yyyyMMdd";
                        DateTime Time;
                        Time = DateTime.ParseExact(textBox1.Text, format, null);
                        CR.SetParameterValue("日付", Time.ToShortDateString());
                        CR.SetParameterValue("後日付", now.ToShortDateString());
                    }

                    else
                    {
                        string format = "yyyyMMdd";
                        DateTime BeforeTime, AfterTime;
                        BeforeTime = DateTime.ParseExact(textBox1.Text, format, null);
                        AfterTime = DateTime.ParseExact(textBox2.Text, format, null);
                        CR.SetParameterValue("日付", BeforeTime.ToShortDateString());
                        CR.SetParameterValue("後日付", AfterTime.ToShortDateString());
                    }

                    // プリンタに印刷
                    CR.PrintToPrinter(0, false, 0, 0);
                }
            }

            // F10キーが押されたとき
            if (e.KeyData == Keys.F10)
            {
                DialogResult result = MessageBox.Show("データを取り消しますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                //何が選択されたか調べる
                if (result == DialogResult.OK)
                {
                    //「OK」が選択された時

                    PushDelete();
                    comboBox1.Focus();
                }
            }

            // F11キーが押されたとき
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

            // F12キーが押されたとき
            if (e.KeyData == Keys.F12)
            {
                DialogResult result = MessageBox.Show("データを削除しますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                //何が選択されたか調べる
                if (result == DialogResult.OK)
                {
                    //「OK」が選択された時
                    //QL.BuppinDelete(SQL, BUPNCD, textBox2, textBox5, textBox6, textBox9, textBox10, comboBox1, comboBox2, comboBox3, comboBox4);
                    PushDelete();
                }
                comboBox1.Focus();
            }
        }



       


        //F11の入力
        private void button13_Click(object sender, EventArgs e)
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bupnknd = comboBox1.Text;
            BUPNKND = decimal.Parse(bupnknd);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string del = comboBox2.Text;
           
            BUPNGRP = decimal.Parse(del);

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
            if ((e.KeyChar < 0x30) || (e.KeyChar > 0x37))
            {
                if (e.KeyChar != '\b')
                {
                    e.Handled = true;
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            FromDay = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            ToDay = textBox2.Text;
        }

        private void comboBox1_MouseEnter(object sender, EventArgs e)
        {
            textBox3.Text = "物品種別を入力してください";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 制御文字は入力可
            if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                return;
            }
            // 数字(0-9)は入力可
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
                return;
            }
            e.Handled = true;
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 制御文字は入力可
            if (char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                return;
            }
            // 数字(0-9)は入力可
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
                return;
            }
            e.Handled = true;
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            textBox3.Text = "絞り込みたい日付を入力してください";
        }

        private void textBox2_MouseEnter(object sender, EventArgs e)
        {
            textBox3.Text = "絞り込みたい日付を入力してください";
        }

        private void comboBox2_MouseEnter(object sender, EventArgs e)
        {
            textBox3.Text = "分類コードを入力してください";
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }
        // 印刷ボタンをクリックしたとき
        private void button10_Click(object sender, EventArgs e)
        {
           
            
        }
        // 取消ボタンをクリックしたとき
        private void button11_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("印刷しますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

            //何が選択されたか調べる
            if (result == DialogResult.OK)
            {
                if (comboBox1.Text == "1")
                {
                    CR.SetParameterValue("物品種別", "書籍");
                }
                else
                {
                    CR.SetParameterValue("物品種別", "機器");
                }

                string Cord = comboBox2.Text;
                if (Enum.TryParse(Cord, out categoryCord))
                {
                    switch (categoryCord)
                    {
                        case CategoryCord.全て:
                            CR.SetParameterValue("分類", "全て");
                            break;

                        case CategoryCord.本体:
                            CR.SetParameterValue("分類", "本体");
                            break;

                        case CategoryCord.モニタ:
                            CR.SetParameterValue("分類", "モニタ");
                            break;

                        case CategoryCord.プリンター:
                            CR.SetParameterValue("分類", "プリンター");
                            break;

                        case CategoryCord.モデム:
                            CR.SetParameterValue("分類", "モデム");
                            break;

                        case CategoryCord.ルーター:
                            CR.SetParameterValue("分類", "ルーター");
                            break;
                        case CategoryCord.ハブ:
                            CR.SetParameterValue("分類", "ハブ");
                            break;
                        case CategoryCord.その他:
                            CR.SetParameterValue("分類", "その他");
                            break;
                    }
                }

                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    string format = "yyyyMMdd";
                    DateTime Time;
                    Time = DateTime.ParseExact(textBox2.Text, format, null);
                    CR.SetParameterValue("日付", "");
                    CR.SetParameterValue("後日付", Time.ToShortDateString());
                }

                else if (string.IsNullOrEmpty(textBox2.Text))
                {
                    string format = "yyyyMMdd";
                    DateTime Time;
                    Time = DateTime.ParseExact(textBox1.Text, format, null);
                    CR.SetParameterValue("日付", Time.ToShortDateString());
                    CR.SetParameterValue("後日付", now.ToShortDateString());
                }

                else
                {
                    string format = "yyyyMMdd";
                    DateTime BeforeTime, AfterTime;
                    BeforeTime = DateTime.ParseExact(textBox1.Text, format, null);
                    AfterTime = DateTime.ParseExact(textBox2.Text, format, null);
                    CR.SetParameterValue("日付", BeforeTime.ToShortDateString());
                    CR.SetParameterValue("後日付", AfterTime.ToShortDateString());
                }

                // プリンタに印刷
                CR.PrintToPrinter(0, false, 0, 0);
            }
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("データを削除しますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

            //何が選択されたか調べる
            if (result == DialogResult.OK)
            {
                //「OK」が選択された時
                //QL.BuppinDelete(SQL, BUPNCD, textBox2, textBox5, textBox6, textBox9, textBox10, comboBox1, comboBox2, comboBox3, comboBox4);
                PushDelete();
            }
            comboBox1.Focus();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            
            //ボタンがクリックされた
            if (dgv.Columns[e.ColumnIndex].Name == "ボタン")
            {
                Console.Write(dt.Rows[e.RowIndex][6]);
                Console.Write(dt.Rows[e.RowIndex][0]);


                string ReceiveRentno = dt.Rows[e.RowIndex][6].ToString();
                decimal SEQ = decimal.Parse(dt.Rows[e.RowIndex][0].ToString());
                //Form1を表示
                Form4 f4 = new Form4(ReceiveRentno, SEQ);
                f4.Show();
            }
        }
       

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form6_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("データを取り消しますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

            //何が選択されたか調べる
            if (result == DialogResult.OK)
            {
                //「OK」が選択された時

                PushDelete();
                comboBox1.Focus();
            }
            comboBox1.Focus();
        }
    }
}
