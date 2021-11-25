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
    enum Form4NowForce
    {
        textBox1,
        comboBox1,
        textBox2,
        textBox3,
        textBox4,
        textBox5,
        textBox6,
        textBox7,
        textBox8,
        textBox9,
        textBox10,
        textBox11,
        textBox12,
        textbox13,

    }
    public partial class Form4 : Form
    {
        //初期化
        String bupncd = "";                       //物品コード
        String rentseq = "";                      //SEQ
        String RENTDATE = ""; 　　　　　　　　　　//貸出日
        String RENTCONT = "";                     //借受者
        String RENTUSER = "";　　　　　　　　　　 //利用者
        String RENTCMNT = "";                     //備考
        String RETRNPLAN = "";                    //返却予定日
        String RENTLCAT1 = "";                    //保管場所(出)
        String BUPNCND = "";                      //状態（付属品
        String RETRNDATE = "";                    //返却日
        String RETRNNM = "";                      //返却者名
        String RENTLCAT2 = "";                    //保管場所(入)
        String RENTCMNT2 = "";                    //返却備考
        String err_msg = "";
        


        decimal BUPNCD ;                          //物品コード
        decimal BUPNKND = 1;                      //物品種別
        decimal RENTSEQ = 1;                      //SEQ
        decimal RENTNO = 1;                       //貸出No.

        int NoCount = 1;                          //SEQ数

        bool check_flg = false;
        bool Search_flg = false;
        bool RentCheck_flg = false;
        bool return_flg = false;

        // 現在の日時を取得
        DateTime now = DateTime.Now;
        Form4NowForce form4nowfocus = new Form4NowForce();

        SQL SQL = new SQL();

        Error error = new Error();
        // ErrorProviderのインスタンスを生成
        ErrorProvider errorProvider = new ErrorProvider();

        //SQLの中身を取り出したデータテーブル
        DataTable dt = new DataTable();

        CrystalReport2 CR = new CrystalReport2();

        public Form4()
        {
            InitializeComponent();
            textBox1.Focus();
        }

        public Form4(string ReceiveRentno, decimal SEQ)
        {
            InitializeComponent();
            textBox1.Text = ReceiveRentno;
            RENTSEQ = SEQ;
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            Lock();

            dataGridView1.Enabled = false;
            //カラム数を指定
            dataGridView1.ColumnCount = 12;

            // カラム名を指定
            dataGridView1.Columns[0].HeaderText = "ボタン";
            dataGridView1.Columns[1].HeaderText = "No.";
            dataGridView1.Columns[2].HeaderText = "物品名";
            dataGridView1.Columns[3].HeaderText = "返却予定日";
            dataGridView1.Columns[4].HeaderText = "返却日";
            dataGridView1.Columns[5].HeaderText = "返却者名";
            dataGridView1.Columns[6].HeaderText = "保管場所(入)";

            
            // アイコンを点滅なしに設定する
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            textBox14.Enabled = false;
            textBox14.Text = "【新規登録】Enterキー 【編集】貸出Noを入力";
        }

        public void Lock()
        {
            textBox1.Enabled = true;    
            textBox2.Enabled = false;   
            textBox3.Enabled = false;   
            textBox4.Enabled = false;   
            textBox5.Enabled = false;   
            textBox6.Enabled = false;  
            textBox7.Enabled = false;
            textBox8.Enabled = false;
            textBox9.Enabled = false;   
            textBox10.Enabled = false;
            textBox11.Enabled = false;
            textBox12.Enabled = false;
            textBox13.Enabled = false;
            textBox15.Enabled = false;

            comboBox1.Enabled = false;

            button1.Enabled = false;
            button2.Enabled = false;
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
            button14.Enabled = false;
            button15.Enabled = false;

            dataGridView1.Enabled = false;
        }

        public void Unlock()
        {
            textBox1.Enabled = false;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;         
            textBox10.Enabled = true;
            textBox11.Enabled = true;      

            comboBox1.Enabled = true;

            button1.Enabled = true;
            button2.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;
            button11.Enabled = true;
            button14.Enabled = true;
            button15.Enabled = true;

            dataGridView1.Enabled = true;
        }

        public void PushDelete()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Text = "1";
            comboBox1.Text = "1";
            label19.Text = "";
            check_flg = false;
            errorProvider.Clear();
            dt.Clear();
            Lock();
        }

    
        private void label1_Click(object sender, EventArgs e)
        {

        }
      

        private void button15_Click(object sender, EventArgs e)
        {
            //Form1を表示
            RentList RL = new RentList();
            RL.Show();
        }

        //  ←ボタンをクリックしたとき
        private void button1_Click(object sender, EventArgs e)
        {
            dt.Clear();
            textBox14.Clear();
            errorProvider.Clear();
            SQL.RentBeforeData(SQL, RENTNO, textBox1, textBox14);
            string SQLText= $"SELECT T001_RENT_DTL.T002_RENTSEQ, M001_BUPPIN.M001_BUPNNM, T001_RENT_DTL.T002_RETRNPLAN, T001_RENT_DTL.T002_RETRNDATE , T001_RENT_DTL.T002_RETRNNM , T001_RENT_DTL.T002_RENTLCAT2 FROM M001_BUPPIN JOIN T001_RENT_DTL ON M001_BUPPIN.M001_BUPNCD = T001_RENT_DTL.T002_BUPNCD WHERE T001_RENT_DTL.T002_RENTNO = {RENTNO};";
            dataGridView1.DataSource = SQL.RentList(SQL, SQLText, dt);

            if (check_flg == true)
            {
                SQL.RentGetData(SQL, RENTNO, comboBox1, textBox1, textBox2, textBox3, textBox11, textBox12);
                SQL.RentDtlSEQGetData(SQL, RENTNO, textBox15, textBox5, textBox10, textBox4, textBox6, textBox9, textBox8, textBox13, textBox7,1);
            }
        }

        //  →ボタンをクリックしたとき
        private void button2_Click(object sender, EventArgs e)
        {
            dt.Clear();
            textBox14.Clear();
            errorProvider.Clear();
            SQL.RentAfterData(SQL, RENTNO, textBox1, textBox14);
            string SQLText = $"SELECT T001_RENT_DTL.T002_RENTSEQ, M001_BUPPIN.M001_BUPNNM, T001_RENT_DTL.T002_RETRNPLAN, T001_RENT_DTL.T002_RETRNDATE , T001_RENT_DTL.T002_RETRNNM , T001_RENT_DTL.T002_RENTLCAT2 FROM M001_BUPPIN JOIN T001_RENT_DTL ON M001_BUPPIN.M001_BUPNCD = T001_RENT_DTL.T002_BUPNCD WHERE T001_RENT_DTL.T002_RENTNO = {RENTNO};";
            dataGridView1.DataSource = SQL.RentList(SQL, SQLText, dt);

            if (check_flg == true)
            {
                SQL.RentGetData(SQL, RENTNO, comboBox1, textBox1, textBox2, textBox3, textBox11, textBox12);
                SQL.RentDtlSEQGetData(SQL, RENTNO, textBox15, textBox5, textBox10, textBox4, textBox6, textBox9, textBox8, textBox13, textBox7,1);
            }

        }


        //  F8(更新)ボタンをクリックしたとき
        private void button10_Click(object sender, EventArgs e)
        {
            if (check_flg == true)
            {
                if (return_flg == true)
                {
                    errorProvider.Clear();
                    error.IsNullOrEmptyReturn(errorProvider, err_msg, textBox7, textBox8, textBox9, textBox14);
                    if (error.IsNullOrEmptyReturnCheck(textBox7, textBox8, textBox9))
                    {
                        DialogResult result = MessageBox.Show("データを更新しますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                        //何が選択されたか調べる
                        if (result == DialogResult.OK)
                        {
                            //「OK」が選択された時
                            SQL.RentUpdata(SQL, RENTNO, comboBox1, textBox12, textBox3, textBox2, textBox11);
                            SQL.RentDtlUpdata(SQL, RENTNO, RENTSEQ, textBox5, textBox10, textBox4, textBox6, textBox9, textBox8, textBox13, textBox7);
                            DialogResult result2 = MessageBox.Show("データが登録できました！", "確認", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            //返却入力時(返却日の入力有り)
                            if (!string.IsNullOrEmpty(RETRNDATE))
                            {
                                SQL.BuppinUnRent(SQL, BUPNCD);
                            }

                            //現在保管場所を保管場所(入)で更新
                            if (!string.IsNullOrEmpty(RENTLCAT2))
                            {
                                SQL.BuppinLCAT2(SQL, BUPNCD, textBox7);
                            }

                            PushDelete();
                        }
                    }
                }
                else
                {
                    errorProvider.Clear();
                    error.IsNullOrEmptyForm4Update(errorProvider, err_msg, textBox14, comboBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox12);
                    if (error.IsNullOrEmptyForm4UpdateCheck(comboBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox12))
                    {
                        DialogResult result = MessageBox.Show("データを更新しますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                        //何が選択されたか調べる
                        if (result == DialogResult.OK)
                        {
                            //「OK」が選択された時
                            SQL.RentUpdata(SQL, RENTNO, comboBox1, textBox12, textBox3, textBox2, textBox11);
                            SQL.RentDtlUpdata(SQL, RENTNO, RENTSEQ, textBox5, textBox10, textBox4, textBox6, textBox9, textBox8, textBox13, textBox7);
                            DialogResult result2 = MessageBox.Show("データが登録できました！", "確認", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            //返却入力時(返却日の入力有り)
                            if (!string.IsNullOrEmpty(RETRNDATE))
                            {
                                SQL.BuppinUnRent(SQL, BUPNCD);
                            }

                            //現在保管場所を保管場所(入)で更新
                            if (!string.IsNullOrEmpty(RENTLCAT2))
                            {
                                SQL.BuppinLCAT2(SQL, BUPNCD, textBox7);
                            }

                            PushDelete();
                        }
                    }

                }


            }
            else
            {
                errorProvider.Clear();
                error.IsNullOrEmptyRegister(errorProvider, err_msg, comboBox1, textBox2, textBox4, textBox5, textBox6, textBox14);

                if (SQL.RentOK(SQL, textBox4, comboBox1,RentCheck_flg))
                {
                    if (error.IsNullOrEmptyRegisterCheck(comboBox1, textBox2, textBox4, textBox5, textBox6))
                    {
                        DialogResult result = MessageBox.Show("データを追加しますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                        //何が選択されたか調べる
                        if (result == DialogResult.OK)
                        {
                            //「OK」が選択された時
                            DialogResult result2 = MessageBox.Show("データが登録できました！", "確認",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                            SQL.RentInsert(SQL, RENTNO, BUPNKND, RENTCONT, RENTCMNT);
                            SQL.RentDtlInsert(SQL, RENTNO, RENTSEQ, BUPNCD, BUPNCND, RETRNPLAN, RENTLCAT1, RETRNDATE, RETRNNM, RENTCMNT2, RENTLCAT2);
                            SQL.BuppinRent(SQL, BUPNCD);
                            PushDelete();

                            //追加でデータを登録するとき
                            DialogResult add = MessageBox.Show("さらにデータを追加しますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                            //何が選択されたか調べる
                            if (add == DialogResult.OK)
                            {
                                //ロック処理
                                Unlock();
                                textBox14.Clear();
                                button1.Enabled = false;
                                button2.Enabled = false;
                                textBox3.Enabled = false;
                                string SQLText = $"SELECT T001_RENT_DTL.T002_RENTSEQ, M001_BUPPIN.M001_BUPNNM, T001_RENT_DTL.T002_RETRNPLAN, T001_RENT_DTL.T002_RETRNDATE , T001_RENT_DTL.T002_RETRNNM , T001_RENT_DTL.T002_RENTLCAT2 FROM M001_BUPPIN JOIN T001_RENT_DTL ON M001_BUPPIN.M001_BUPNCD = T001_RENT_DTL.T002_BUPNCD WHERE T001_RENT_DTL.T002_RENTNO = {RENTNO};";
                                dataGridView1.DataSource = SQL.RentList(SQL, SQLText, dt);

                                //SEQ数更新
                                NoCount++;

                                SQL.RentGetData(SQL, RENTNO, comboBox1, textBox1, textBox2, textBox3, textBox11, textBox12);
                                SQL.RentDtlGetData(SQL, RENTNO, textBox15, textBox5, textBox10, textBox4, textBox6, textBox9, textBox8, textBox13, textBox7);

                                //クリア
                                textBox4.Clear();
                                textBox5.Clear();
                                textBox6.Clear();
                                textBox10.Clear();
                                textBox11.Clear();

                                textBox15.Text = Convert.ToString(NoCount);
                                label19.Text = "編集画面";
                            }
                            if (add == DialogResult.Cancel)
                            {
                                NoCount = 1;
                            }
                        }

                    }
                }
                else
                {
                    error.RentError(errorProvider, err_msg, textBox4, textBox14);
                }
                
                
            }
           
            textBox1.Focus();
        }

        //  F9(印刷)ボタンをクリックしたとき
        private void button11_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("印刷しますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

            //何が選択されたか調べる
            if (result == DialogResult.OK)
            {
                if (comboBox1.Text == "1")
                {
                    CR.SetParameterValue("種別", "書籍");
                }
                if (comboBox1.Text == "2")
                {
                    CR.SetParameterValue("種別", "機器");
                }
                // プリンタに印刷
                CR.PrintToPrinter(0, false, 0, 0);
            }
        }

        //  F10(取消)ボタンをクリックしたとき
        private void button12_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("データを取り消しますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

            //何が選択されたか調べる
            if (result == DialogResult.OK)
            {
                //「OK」が選択された時
                PushDelete();
                textBox1.Focus();
            }
        }

        //  F11(終了)ボタンをクリックしたとき
        private void button13_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("終了しますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

            //何が選択されたか調べる
            if (result == DialogResult.OK)
            {
                //次画面を非表示
                this.Visible = false;
                ////Form1を表示
                //Form1 f1 = new Form1();
                //f1.Show();
            }
        }

        //  F13(削除)ボタンをクリックしたとき
        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        //貸出No入力form
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ///型チェック（数値のみ）
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "^[0-9]"))
            {
                String rentno = textBox1.Text;
                RENTNO = decimal.Parse(rentno);
            }
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

        private void button4_Click(object sender, EventArgs e)
        {

        }

        //物品種別コンボボックス入力form
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(comboBox1.Text, "^[1-2]"))
            {
                string bupnknd = comboBox1.Text;
                BUPNKND = int.Parse(bupnknd);
            }
        }

        //借受者名入力form
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            RENTCONT = textBox2.Text;
        }

        //利用者名入力form
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            RENTUSER = textBox3.Text;
        }

        //返却予定日入力form
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            ///型チェック（数値のみ）
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox4.Text, "^[0-9]"))
            {
                bupncd = textBox4.Text;
                BUPNCD = decimal.Parse(bupncd);

                label20.Text = "";
                textBox6.Text = "";
                textBox10.Text = "";

                SQL.SQLBuilder();

                string SqlSearch = $"SELECT * FROM M001_BUPPIN WHERE M001_BUPNCD = {BUPNCD} AND M001_BUPNKND = {BUPNKND}";

                using (var connection = new SqlConnection(SQL.builder.ConnectionString))
                {
                    //接続を確立
                    connection.Open();

                    //SELECT文を作成
                    SqlCommand command_s = new SqlCommand(SqlSearch, connection);

                    using (SqlDataReader reader = command_s.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            label20.Text = reader[2].ToString();
                            textBox6.Text = reader[7].ToString();
                            textBox10.Text = reader[5].ToString();
                        }
                        reader.Close();
                    }
                }
            }
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                textBox6.Text = "";
                textBox10.Text = "";
                label20.Text = "";
            }
        }

        //物品コード入力form
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            RETRNPLAN = textBox5.Text;
        }

        //保管場所(出)入力form
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            RENTLCAT1 = textBox6.Text;
        }

        //保管場所(入)入力form
        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            RENTLCAT2 = textBox7.Text;
        }

        //返却者名入力form
        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            RETRNNM = textBox8.Text;
        }

        //返却日入力form
        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            RETRNDATE = textBox9.Text;
        }

        //状態(付属品)入力form
        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            BUPNCND = textBox10.Text;
        }

        //備考欄入力form
        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            RENTCMNT = textBox11.Text;
        }

        //貸出日入力form
        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            RENTDATE = textBox12.Text;
        }

        //返却備考入力form
        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            RENTCMNT2 = textBox13.Text;
        }

        //補足説明欄
        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        //SEQ入力form
        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            ///型チェック（数値のみ）
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox15.Text, "^[0-9]"))
            {
                rentseq = textBox15.Text;
                RENTSEQ = decimal.Parse(rentseq);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

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
                if (Enum.TryParse(Focus, out form4nowfocus))
                {
                    switch (form4nowfocus)
                    {
                        case Form4NowForce.textBox1:

                            //未入力（新規登録）
                            if (textBox1.Text == "")
                            {
                                Unlock();
                                textBox14.Clear();
                                button1.Enabled = false;
                                button2.Enabled = false;
                                textBox3.Enabled = false;
                                button9.Enabled = false;
                                SQL.RentMaxData(SQL, RENTNO, textBox1, textBox3);
                                label19.Text = "貸出登録";
                            }
                            //入力（参照・編集）
                            else
                            {
                                check_flg = SQL.RentSearch(SQL, RENTNO, Search_flg);
                                label19.Text = "編集画面";
                                //データが存在する時（編集）
                                if (check_flg == true)
                                {
                                    Unlock();
                                    textBox14.Clear();
                                    // textBox7.Enabled = true;
                                    // textBox8.Enabled = true;
                                    // textBox9.Enabled = true;
                                    // textBox12.Enabled = true;
                                    textBox13.Enabled = false;

                                    SQL.RentGetData(SQL, RENTNO, comboBox1, textBox1, textBox2, textBox3, textBox11, textBox12);
                                    SQL.RentDtlSEQGetData(SQL, RENTNO, textBox15, textBox5, textBox10, textBox4, textBox6, textBox9, textBox8, textBox13, textBox7,RENTSEQ);
                                    string SQLText = $"SELECT T001_RENT_DTL.T002_RENTNO, T001_RENT_HED.T001_RENTCONT, T001_RENT_HED.T001_RENTUSER, T001_RENT_HED.T001_RENTDATE, T001_RENT_DTL.T002_RENTSEQ, M001_BUPPIN.M001_BUPNNM, T001_RENT_DTL.T002_BUPNCND, T001_RENT_DTL.T002_RETRNPLAN, T001_RENT_DTL.T002_RETRNDATE , T001_RENT_DTL.T002_RETRNNM , T001_RENT_DTL.T002_RENTLCAT2 FROM T001_RENT_DTL LEFT JOIN M001_BUPPIN ON T001_RENT_DTL.T002_BUPNCD = M001_BUPPIN.M001_BUPNCD LEFT JOIN T001_RENT_HED ON T001_RENT_DTL.T002_RENTNO = T001_RENT_HED.T001_RENTNO WHERE T001_RENT_DTL.T002_RENTNO = {RENTNO};";
                                    dataGridView1.DataSource = SQL.RentList(SQL, SQLText, dt);
                                    // 印字データをセット

                                    //  CR.SetDatabaseLogon("sa", "intern");
                                    CR.SetDataSource(dt);
                                    CR.Refresh();

                                }

                                //データが存在しない時
                                else
                                {
                                    textBox14.Text = "データが見つかりません";
                                }
                            }
                            comboBox1.Focus();
                            break;

                            // forceが物品種別にあるとき
                        case Form4NowForce.comboBox1:
                            textBox2.Focus();
                            break;

                        // forceが借受者名にあるとき
                        case Form4NowForce.textBox2:
                            if (check_flg==false)
                            {
                                textBox11.Focus();
                            }
                            else
                            {
                                textBox3.Focus();
                            }
                            break;

                        // forceが利用者名にあるとき
                        case Form4NowForce.textBox3:
                            textBox11.Focus();
                            break;


                        case Form4NowForce.textBox4:
                            textBox5.Focus();
                            break;

                        case Form4NowForce.textBox5:
                            textBox6.Focus();
                            break;


                        case Form4NowForce.textBox6:
                            textBox10.Focus();
                            break;

                        case Form4NowForce.textBox7:
                            textBox13.Focus();
                            break;

                        case Form4NowForce.textBox8:
                            textBox7.Focus();
                            break;
                        
                        case Form4NowForce.textBox9:
                            textBox8.Focus();
                            break;

                        case Form4NowForce.textBox12:
                            textBox11.Focus();
                            break;

                        default:
                            break;
                    }

                }
            }

            //  F1キー(検索)を入力したとき
            if (e.KeyData == Keys.F1)
            {
                //Form1を表示
                RentList RL = new RentList();
                RL.Show();
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
                    textBox1.Focus();
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

            //  F12キー(削除)を入力したとき
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
                textBox1.Focus();
            }

            // F8キー(更新)をキー入力したとき
            if (e.KeyData == Keys.F8 && check_flg == false)
            {
                errorProvider.Clear();
                error.IsNullOrEmptyRegister(errorProvider, err_msg, comboBox1, textBox2, textBox4, textBox5, textBox6, textBox14);
                if (error.IsNullOrEmptyRegisterCheck(comboBox1, textBox2, textBox4, textBox5, textBox6))
                {
                    DialogResult result = MessageBox.Show("データを追加しますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                    //何が選択されたか調べる
                    if (result == DialogResult.OK)
                    {
                        //「OK」が選択された時
                        DialogResult result2 = MessageBox.Show("データが登録できました！", "確認", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        SQL.RentInsert(SQL, RENTNO, BUPNKND, RENTCONT, RENTCMNT);
                        SQL.RentDtlInsert(SQL, RENTNO, RENTSEQ, BUPNCD, BUPNCND, RETRNPLAN, RENTLCAT1, RETRNDATE, RETRNNM, RENTCMNT2, RENTLCAT2);
                        SQL.BuppinRent(SQL, BUPNCD);
                        PushDelete();
                        //追加でデータを登録するとき
                        DialogResult add = MessageBox.Show("さらにデータを追加しますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                        //何が選択されたか調べる
                        if (add == DialogResult.OK)
                        {
                            //ロック処理
                            Unlock();
                            textBox14.Clear();
                            button1.Enabled = false;
                            button2.Enabled = false;
                            textBox3.Enabled = false;
                            string SQLText = $"SELECT T001_RENT_DTL.T002_RENTSEQ, M001_BUPPIN.M001_BUPNNM, T001_RENT_DTL.T002_RETRNPLAN, T001_RENT_DTL.T002_RETRNDATE , T001_RENT_DTL.T002_RETRNNM , T001_RENT_DTL.T002_RENTLCAT2 FROM M001_BUPPIN JOIN T001_RENT_DTL ON M001_BUPPIN.M001_BUPNCD = T001_RENT_DTL.T002_BUPNCD WHERE T001_RENT_DTL.T002_RENTNO = {RENTNO};";

                            dataGridView1.DataSource = SQL.RentList(SQL, SQLText, dt);

                            //SEQ数更新
                            NoCount++;

                            SQL.RentGetData(SQL, RENTNO, comboBox1, textBox1, textBox2, textBox3, textBox11, textBox12);
                            SQL.RentDtlGetData(SQL, RENTNO, textBox15, textBox5, textBox10, textBox4, textBox6, textBox9, textBox8, textBox13, textBox7);

                            //クリア
                            textBox4.Clear();
                            textBox5.Clear();
                            textBox6.Clear();
                            textBox10.Clear();
                            textBox11.Clear();

                            textBox15.Text = Convert.ToString(NoCount);
                        }

                        if (add == DialogResult.Cancel)
                        {
                            NoCount = 1;
                        }
                    }

                   

                }
                
                textBox1.Focus();
            }

            // F8キー(更新)をキー入力したとき
            if (e.KeyData == Keys.F8 && check_flg == true)
            {
                // 返却時
                if (return_flg == true)
                {
                    errorProvider.Clear();
                    error.IsNullOrEmptyReturn(errorProvider, err_msg, textBox7, textBox8, textBox9, textBox14);
                    if (error.IsNullOrEmptyReturnCheck(textBox7, textBox8, textBox9))
                    {
                        DialogResult result = MessageBox.Show("データを更新しますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                        //何が選択されたか調べる
                        if (result == DialogResult.OK)
                        {
                            //「OK」が選択された時
                            SQL.RentUpdata(SQL, RENTNO, comboBox1, textBox12, textBox3, textBox2, textBox11);
                            SQL.RentDtlUpdata(SQL, RENTNO, RENTSEQ, textBox5, textBox10, textBox4, textBox6, textBox9, textBox8, textBox13, textBox7);
                            DialogResult result2 = MessageBox.Show("データが登録できました！", "確認", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            //返却入力時(返却日の入力有り)
                            if (!string.IsNullOrEmpty(RETRNDATE))
                            {
                                SQL.BuppinUnRent(SQL, BUPNCD);
                            }

                            //現在保管場所を保管場所(入)で更新
                            if (!string.IsNullOrEmpty(RENTLCAT2))
                            {
                                SQL.BuppinLCAT2(SQL, BUPNCD, textBox7);
                            }

                            PushDelete();
                        }
                        
                    }
                    
                }
                // 更新時
                else
                {
                    errorProvider.Clear();
                    error.IsNullOrEmptyForm4Update(errorProvider, err_msg, textBox14, comboBox1, textBox2, textBox3, textBox4, textBox5, textBox6,  textBox12);
                    if (error.IsNullOrEmptyForm4UpdateCheck(comboBox1, textBox2, textBox3, textBox4, textBox5, textBox6,  textBox12))
                    {
                        DialogResult result = MessageBox.Show("データを更新しますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                        //何が選択されたか調べる
                        if (result == DialogResult.OK)
                        {
                            //「OK」が選択された時
                            SQL.RentUpdata(SQL, RENTNO, comboBox1, textBox12, textBox3, textBox2, textBox11);
                            SQL.RentDtlUpdata(SQL, RENTNO, RENTSEQ, textBox5, textBox10, textBox4, textBox6, textBox9, textBox8, textBox13, textBox7);
                            DialogResult result2 = MessageBox.Show("データが登録できました！", "確認", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                            //返却入力時(返却日の入力有り)
                            if (!string.IsNullOrEmpty(RETRNDATE))
                            {
                                SQL.BuppinUnRent(SQL, BUPNCD);
                            }

                            //現在保管場所を保管場所(入)で更新
                            if (!string.IsNullOrEmpty(RENTLCAT2))
                            {
                                SQL.BuppinLCAT2(SQL, BUPNCD, textBox7);
                            }

                            PushDelete();
                        }
                        
                    }
                }
               

                textBox1.Focus();
            }

            // F7キー(更新)をキー入力したとき
            if (e.KeyData==Keys.F7)
            {
                errorProvider.Clear();
                label19.Text = "返却画面";
                return_flg = true;

                Lock();
                textBox1.Enabled = false;
                textBox7.Enabled = true;
                textBox8.Enabled = true;
                textBox9.Enabled = true;
                textBox13.Enabled = true;
                button10.Enabled = true;
                button8.Enabled = true;
                textBox9.Focus();
            }
            // F6キーを入力したとき
            if (e.KeyData==Keys.F6)
            {
                errorProvider.Clear();
                label19.Text = "編集画面";
                return_flg = false;
                Unlock();
                textBox7.Enabled = false;
                textBox8.Enabled = false;
                textBox9.Enabled = false;
                textBox13.Enabled = false;
               // button10.Enabled = false;
                button8.Enabled = false;
            }
            // F9キーが押されたとき
            if (e.KeyData==Keys.F9)
            {
                DialogResult result = MessageBox.Show("印刷しますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
               
                if (comboBox1.Text == "1")
                {
                    CR.SetParameterValue("種別", "書籍");
                }
                if (comboBox1.Text == "2")
                {
                    CR.SetParameterValue("種別", "機器");
                }
                //何が選択されたか調べる
                if (result == DialogResult.OK)
                {
                    // プリンタに印刷
                    CR.PrintToPrinter(0, false, 0, 0);
                }
            }
        }
        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }
        // 物品種別の入力制限
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

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox12_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            //ボタンがクリックされた
            if (dgv.Columns[e.ColumnIndex].Name == "Button")
            {
                //Console.WriteLine(dt.Rows[e.RowIndex][0]);
                if (dt.Rows[e.RowIndex][1]!=null)
                {
                    RENTSEQ = decimal.Parse(dt.Rows[e.RowIndex][0].ToString());

                    SQL.SEQGetData(SQL, RENTNO, RENTSEQ, textBox15, textBox5, textBox10, textBox4, textBox6, textBox9, textBox8, textBox13, textBox7);

                }
            }
        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            textBox14.Text = "【新規登録】Enterキー 【編集】貸出Noを入力";
        }
        private void comboBox1_MouseEnter(object sender, EventArgs e)
        {
            textBox14.Text = "物品種別を入力して下さい。";
        }

        private void textBox2_MouseEnter(object sender, EventArgs e)
        {
            textBox14.Text = "借受者名を入力して下さい。";
        }

        private void textBox3_MouseEnter(object sender, EventArgs e)
        {
            textBox14.Text = "利用者名を入力して下さい。";
        }

        private void textBox4_MouseEnter(object sender, EventArgs e)
        {
            textBox14.Text = "物品コードを数字5文字以内で入力して下さい。";
        }

        private void textBox5_MouseEnter(object sender, EventArgs e)
        {
            textBox14.Text = "返却予定日を入力して下さい。 例：20211025)";
        }

        private void textBox6_MouseEnter(object sender, EventArgs e)
        {
            textBox14.Text = "保管されていた場所をを入力して下さい。";
        }

        private void textBox9_MouseEnter(object sender, EventArgs e)
        {
            textBox14.Text = "返却日を入力して下さい。 例：20211023)";
        }

        private void textBox8_MouseEnter(object sender, EventArgs e)
        {
            textBox14.Text = "返却者名を入力して下さい。";
        }

        private void textBox7_MouseEnter(object sender, EventArgs e)
        {
            textBox14.Text = "保管場所を入力して下さい。 例：3F 手前";
        }

        private void textBox12_MouseEnter(object sender, EventArgs e)
        {
            textBox14.Text = "貸出日を入力して下さい。 例：20211019)";
        }

        private void textBox11_MouseEnter(object sender, EventArgs e)
        {
            textBox14.Text = "備考欄を入力して下さい。 例：初期不良による代替え";
        }

        private void textBox10_MouseEnter(object sender, EventArgs e)
        {
            textBox14.Text = "状態や付属品を入力して下さい。 例：【状態】美品 【付属品】LANケーブル マウス";
        }

        private void textBox13_MouseEnter(object sender, EventArgs e)
        {
            textBox14.Text = "返却備考欄を入力して下さい。 例：初期不良による代替え";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox5_MouseEnter_1(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

            label19.Text = "返却画面";
            return_flg = true;

            Lock();
            textBox1.Enabled = false;
            textBox7.Enabled = true;
            textBox8.Enabled = true;
            textBox9.Enabled = true;
            textBox13.Enabled = true;
            button10.Enabled = true;
            button8.Enabled = true;
            textBox9.Focus();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            label19.Text = "編集画面";
            return_flg = false;
            Unlock();
            textBox7.Enabled = false;
            textBox8.Enabled = false;
            textBox9.Enabled = false;
            textBox13.Enabled = false;
            // button10.Enabled = false;
            button8.Enabled = false;
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void textBox11_Enter(object sender, EventArgs e)
        {
            this.textBox11.Select(this.textBox11.Text.Length, 0);
        }

        private void textBox10_Enter(object sender, EventArgs e)
        {
            this.textBox10.Select(this.textBox10.Text.Length, 0);
        }

        private void textBox13_Enter(object sender, EventArgs e)
        {
            this.textBox13.Select(this.textBox13.Text.Length, 0);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click_1(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}

