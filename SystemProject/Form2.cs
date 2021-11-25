using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.Windows.Input;
using System.Data.SqlClient;
using System.Windows.Data;

namespace SystemProject
{
    //  enumの定義
    enum NowFocus
    {
        textBox1,   //  物品コード
        textBox2,   //  物品名称
        comboBox1,  //  物品種別
        comboBox2,  //  分類コード
        textBox5,   //  基本保管場所
        textBox6,   //  最終保管場所
        comboBox3,  //  貸出フラグ
        textBox9,   //  状態(付属品)
        comboBox4,  //  削除フラグ
        textBox10,  //  削除理由
        button10,   //  更新
        button12,   //  取消
        button13,   //  終了
        button14    //  削除
    }
    public partial class Form2 : Form
    {
        //初期化
       
        String bupncd = "";
        String BUPNNM = "";
        String BUPNCND = "";
        String BUPNLCAT1 = "";
        String BUPNLCAT2 = "";
        String BUPNRENT = "0";
        String BUPNDEL = "0";
        String BUPNRESN = "";
        String err_msg = "";
        
        decimal BUPNKND=1;
        decimal BUPNGRP=1;
        decimal BUPNCD ;

        bool check_flg = false;
        bool Search_flg = false;
    
        // 現在の日時を取得
        DateTime now = DateTime.Now;

        NowFocus nowfocus = new NowFocus();
        SQL SQL = new SQL();
        Error error = new Error();

        // ErrorProviderのインスタンスを生成
        ErrorProvider errorProvider = new ErrorProvider();
        
        public Form2()
        {
            InitializeComponent();
            textBox1.Focus();
            comboBox1.MaxLength = 1;
            comboBox2.MaxLength = 1;
            comboBox3.MaxLength = 1;

            textBox3.Text="物品コードを数字13桁以内で入力して下さい。";
        }

        public Form2(String ReceiveBupncd)
        {
            InitializeComponent();
            textBox1.Focus();
            Lock();

            BUPNCD = decimal.Parse(ReceiveBupncd);
            SQL.BuppinGetData(SQL, BUPNCD, textBox1, textBox2, textBox5, textBox6, textBox9, textBox10, comboBox1, comboBox2, comboBox3, comboBox4);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Lock();
           
            // アイコンを点滅なしに設定する
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
         
            label16.Text = "";
        }
        
        public void Lock()
        {
            //　物品コードと取消・終了以外の機能をロックする処理

            textBox1.Enabled = true;    // 物品コードのテキストボックス

            textBox2.Enabled = false;   // 物品名称のテキストボックス

            textBox3.Enabled = false;   // 補足説明のテキストボックス

            textBox5.Enabled = false;   // 基本保管場所のテキストボックス

            textBox6.Enabled = false;   // 最終保管場所のテキストボックス

            textBox9.Enabled = false;   // 状態(付属品)のテキストボックス

            textBox10.Enabled = false;  // 削除理由のテキストボックス

            ///////////////////////////////////////////////////////////

            comboBox1.Enabled = false;  // 物品種別のコンボボックス

            comboBox2.Enabled = false;  // 分類コードのコンボボックス

            comboBox3.Enabled = false;  // 貸出フラグのコンボボックス

            comboBox4.Enabled = false;  // 削除フラグのコンボボックス

            //////////////////////////////////////////////////////////

            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
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
            button16.Enabled = false;
        }

        public void Unlock()
        {
            //　物品コードと取消・終了以外の機能をロック解除する処理

            textBox1.Enabled = false;  // 物品コードのテキストボックス

            textBox2.Enabled = true;   // 物品名称のテキストボックス

            textBox5.Enabled = true;   // 基本保管場所のテキストボックス

            textBox6.Enabled = true;   // 最終保管場所のテキストボックス

            textBox9.Enabled = true;   // 状態(付属品)のテキストボックス

            textBox10.Enabled = true;  // 削除理由のテキストボックス

            ///////////////////////////////////////////////////////////

            comboBox1.Enabled = true;  // 物品種別のコンボボックス

            comboBox2.Enabled = true;  // 分類コードのコンボボックス

            comboBox3.Enabled = true;  // 貸出フラグのコンボボックス

            comboBox4.Enabled = true;  // 削除フラグのコンボボックス

            //////////////////////////////////////////////////////////

            button1.Enabled = true;
            button2.Enabled = true;
           // button3.Enabled = true;
           // button4.Enabled = true;
           // button5.Enabled = true;
           // button6.Enabled = true;
           //button7.Enabled = true;
           // button8.Enabled = true;
           // button9.Enabled = true;
            button10.Enabled = true;
           // button11.Enabled = true;
            button12.Enabled = true;
            button13.Enabled = true;
            button14.Enabled = true;
            button15.Enabled = true;
            button16.Enabled = true;
        }

        public void PushDelete()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox9.Clear();
            textBox10.Clear();

            comboBox1.Text = "1";
            comboBox2.Text = "1";
            comboBox3.Text = "0";
            comboBox4.Text = "0";
           
            label16.Text = "";
            label18.Text = "";
            check_flg = false;
            
            errorProvider.Clear();
            Lock();
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
            if ((e.KeyChar < 0x31) || (e.KeyChar > 0x37))
            {
                if (e.KeyChar != '\b')
                {
                    e.Handled = true;
                }
            }
        }

        private void comboBox3_KeyPress(object sender, KeyPressEventArgs e)
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
                if (e.KeyChar==0x30||e.KeyChar==0x39)
                {
                    e.Handled = false;
                    return;
                }
            }
            e.Handled = true;
        }

        private void comboBox4_KeyPress(object sender, KeyPressEventArgs e)
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
                if (e.KeyChar == 0x30 || e.KeyChar == 0x39)
                {
                    e.Handled = false;
                    return;
                }
            }
            e.Handled = true;
        }
      
        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            BUPNRESN  = textBox10.Text;
        }

        //物品コード入力form
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            ///型チェック（数値のみ）
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "^[0-9]"))
            {
                bupncd = textBox1.Text;
                BUPNCD = decimal.Parse(bupncd);
            }
        }

        //物品名称入力form
        private void textBox2_TextChanged(object sender, EventArgs e)
        {        
                BUPNNM = textBox2.Text;          
        }

      
        //物品種別入力form
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bupnknd = comboBox1.Text;
            BUPNKND = decimal.Parse(bupnknd); 
        }

        //分類コード入力form
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string bupngrp = comboBox2.Text;
            BUPNGRP = decimal.Parse(bupngrp);
        }

        //状態（付属品）入力form
        private void textBox9_TextChanged(object sender, EventArgs e)
        {
           
            BUPNCND = textBox9.Text;
        }

        //基本保管場所入力form
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            BUPNLCAT1 = textBox5.Text;
        }

        //最終保管場所入力form
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            BUPNLCAT2 = textBox6.Text;
        }

        //貸出フラグ入力form
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            BUPNRENT = comboBox3.Text;
        }

        //削除フラグ入力form
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            BUPNDEL = comboBox4.Text;
        }

        //  ←ボタンをクリックしたとき
        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            errorProvider.Clear();
            SQL.BuppinBeforeData(SQL, BUPNCD, textBox1, textBox3);  
           
            if (check_flg == true)
            {
                
                SQL.BuppinGetData(SQL, BUPNCD, textBox1, textBox2, textBox5, textBox6, textBox9, textBox10, comboBox1, comboBox2, comboBox3, comboBox4);
                label18.Text = "";
                if (comboBox4.Text == "9")
                {
                    label18.Text = "削除済み";
                    label18.ForeColor = Color.Red;
                }
            }
            
        }

        //  <<ボタンをクリックしたとき
        private void button15_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            errorProvider.Clear();
            SQL.BuppinMinData(SQL, BUPNCD, textBox1);

            if (check_flg == true)
            {

                SQL.BuppinGetData(SQL, BUPNCD, textBox1, textBox2, textBox5, textBox6, textBox9, textBox10, comboBox1, comboBox2, comboBox3, comboBox4);
                label18.Text = "";
                if (comboBox4.Text == "9")
                {
                    label18.Text = "削除済み";
                    label18.ForeColor = Color.Red;
                }
            }

        }

        //  →ボタンをクリックしたとき
        private void button2_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            errorProvider.Clear();
            SQL.BuppinAfterData(SQL, BUPNCD, textBox1, textBox3);

            if (check_flg == true)
            {
                SQL.BuppinGetData(SQL, BUPNCD, textBox1, textBox2, textBox5, textBox6, textBox9, textBox10, comboBox1, comboBox2, comboBox3, comboBox4);
                label18.Text = "";
                if (comboBox4.Text == "9")
                {
                    label18.Text = "削除済み";
                    label18.ForeColor = Color.Red;
                }
            }
           
        }

        //  >>ボタンをクリックしたとき
        private void button16_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            errorProvider.Clear();
            SQL.BuppinMaxData(SQL, BUPNCD, textBox1);

            if (check_flg == true)
            {

                SQL.BuppinGetData(SQL, BUPNCD, textBox1, textBox2, textBox5, textBox6, textBox9, textBox10, comboBox1, comboBox2, comboBox3, comboBox4);
                label18.Text = "";
                if (comboBox4.Text == "9")
                {
                    label18.Text = "削除済み";
                    label18.ForeColor = Color.Red;
                }
            }
        }
   
        //  F8(更新)ボタンをクリックしたとき
        private void button10_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            if (check_flg == true)
            {
                error.IsNullOrEmpty(BUPNNM, BUPNLCAT1, errorProvider, err_msg, textBox2, textBox3, textBox5, comboBox1, comboBox2);
                if (error.IsNullOrEmptyCheck(BUPNNM, BUPNLCAT1 ,comboBox1, comboBox2))
                {
                    errorProvider.Clear();
                    DialogResult result = MessageBox.Show("データを更新しますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                    //何が選択されたか調べる
                    if (result == DialogResult.OK)
                    {
                        DialogResult result2 = MessageBox.Show("データが登録できました！", "確認", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        //「OK」が選択された時
                        SQL.BuppinUpdata(SQL, BUPNCD, textBox2, textBox5, textBox6, textBox9, textBox10, comboBox1, comboBox2, comboBox3, comboBox4);
                        PushDelete();
                    }
                }
            }
            else
            {
                error.IsNullOrEmpty(BUPNNM, BUPNLCAT1, errorProvider, err_msg, textBox2, textBox3, textBox5, comboBox1, comboBox2);
                if (error.IsNullOrEmptyCheck(BUPNNM, BUPNLCAT1 ,comboBox1, comboBox2))
                {
                    errorProvider.Clear();
                    DialogResult result = MessageBox.Show("データを追加しますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                    //何が選択されたか調べる
                    if (result == DialogResult.OK)
                    {
                        DialogResult result2 = MessageBox.Show("データが登録できました！", "確認", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        //「OK」が選択された時
                        SQL.BuppinInsert(SQL, BUPNCD, BUPNNM, BUPNKND, BUPNGRP, BUPNCND, BUPNLCAT1, BUPNLCAT2, BUPNRENT, BUPNDEL);
                        PushDelete();

                    }
                }
            }
            textBox1.Focus();
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

        //  F10(削除)ボタンをクリックしたとき
        private void button14_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("データを削除しますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

            //何が選択されたか調べる
            if (result == DialogResult.OK)
            {
                //「OK」が選択された時
                SQL.BuppinDelete(SQL, BUPNCD, comboBox4);
                PushDelete();
            }
            textBox1.Focus();
        }

        #region コントロール上でキーを押下処理
        private void ControlKeyEvent(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            keyTest(e);
        }

        private void keyTest(System.Windows.Forms.KeyEventArgs e)
        {

            if (e.KeyData == Keys.Enter)
            {
                string Focus = this.ActiveControl.Name;
                if (Enum.TryParse(Focus, out nowfocus))
                {
                    switch (nowfocus)
                    {
                        case NowFocus.textBox1:
                            if (textBox1.Text=="")
                            {
                                break;
                            }
                            textBox3.Clear();
                            Unlock();
                            
                            check_flg = SQL.BuppinSearch(SQL, BUPNCD, Search_flg);
                            //データが存在する時（編集へ）
                            if (check_flg == true)
                            {
                                SQL.BuppinGetData(SQL, BUPNCD, textBox1, textBox2, textBox5, textBox6, textBox9, textBox10, comboBox1, comboBox2, comboBox3, comboBox4);
                                if (comboBox4.Text=="9")
                                {
                                    label18.Text = "削除済み";
                                    label18.ForeColor = Color.Red;
                                }
                                label16.Text = "編集画面";
                            }

                            //データが存在しない時（登録へ）
                            else
                            {
                                Unlock();
                                textBox1.Text = BUPNCD.ToString();
                                comboBox3.Enabled = false;
                                comboBox4.Enabled = false;
                                textBox6.Enabled = false;
                                textBox10.Enabled = false;
                                button1.Enabled = false;
                                button2.Enabled = false;
                                button15.Enabled = false;
                                button16.Enabled = false;
                                label16.Text = "登録画面";
                            }

                            errorProvider.Clear();
                            textBox2.Focus();
                            textBox3.Text = "物品名称を20文字以内で入力してください。";
                            break;
                        case NowFocus.textBox2:
                            comboBox1.Focus();
                            textBox3.Text = "物品種別を選択してください。";
                            break;
                        case NowFocus.comboBox1:
                            comboBox2.Focus();
                            textBox3.Text = "分類コードを選択してください。";
                            break;
                        case NowFocus.comboBox2:
                            textBox5.Focus();
                            textBox3.Text = "基本保管場所を入力してください。例：2F 奥";
                            break;
                        case NowFocus.textBox5:
                            if (check_flg==true)
                            {
                                textBox6.Focus();
                                textBox3.Text = "最終保管場所を入力してください。例：2F 奥";
                            }
                            else
                            {
                                textBox9.Focus();
                                textBox3.Text = "状態（付属品）を入力してください。例：【状態】美品 【付属品】LANケーブル";
                            }
                            break;
                        case NowFocus.textBox6:
                            comboBox3.Focus();
                            textBox3.Text = "貸出フラグを選択してください。";
                            break;
                        case NowFocus.comboBox3:
                            textBox9.Focus();
                            textBox3.Text = "状態や付属品などを入力してください。例：[状態]美品　[付属品]LANケーブル、マウス";
                            break;
                        //case NowFocus.textBox9:
                        //    comboBox4.Focus();
                        //    break;
                        case NowFocus.comboBox4:
                            textBox10.Focus();
                            textBox3.Text = "削除理由を入力してください。例：[状態]故障";
                            break;
                        //case NowFocus.textBox10:
                        //    button10.Focus();
                        //    break;
                        case NowFocus.button10:
                            button12.Focus();
                            break;
                        case NowFocus.button12:
                            button13.Focus();
                            break;
                        case NowFocus.button13:
                            button14.Focus();
                            break;
                        case NowFocus.button14:
                            textBox1.Focus();
                            break;
                        default:
                            break;
                    }
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
                    ////Form1を表示
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
                    SQL.BuppinDelete(SQL, BUPNCD, comboBox4);
                    PushDelete();
                }
                textBox1.Focus();
            }

            // F8キー(更新)をキー入力したとき
            if (e.KeyData == Keys.F8 && check_flg == false)
            {
                 error.IsNullOrEmpty(BUPNNM, BUPNLCAT1, errorProvider, err_msg, textBox2, textBox3, textBox5, comboBox1,comboBox2);
                if (this.ActiveControl==textBox1)
                {
                    errorProvider.Clear();
                }
                if (error.IsNullOrEmptyCheck(BUPNNM, BUPNLCAT1, comboBox1, comboBox2))
                {
                    errorProvider.Clear();
                    DialogResult result = MessageBox.Show("データを追加しますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                    //何が選択されたか調べる
                    if (result == DialogResult.OK)
                    {
                        DialogResult result2 = MessageBox.Show("データが登録できました！", "確認", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        //「OK」が選択された時
                        SQL.BuppinInsert(SQL, BUPNCD, BUPNNM, BUPNKND, BUPNGRP, BUPNCND, BUPNLCAT1, BUPNLCAT2, BUPNRENT, BUPNDEL);
                        PushDelete();
                    }
                    textBox1.Focus();
                }
            }

            // F8キー(更新)をキー入力したとき
            if (e.KeyData == Keys.F8&&check_flg == true)
            {
                errorProvider.Clear();
                error.IsNullOrEmpty(BUPNNM, BUPNLCAT1, errorProvider, err_msg, textBox2, textBox3, textBox5, comboBox1, comboBox2);
                if (this.ActiveControl == textBox1)
                {
                    errorProvider.Clear();
                }
                if (error.IsNullOrEmptyCheck(BUPNNM, BUPNLCAT1, comboBox1, comboBox2))
                {
                    errorProvider.Clear();
                    DialogResult result = MessageBox.Show("データを更新しますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                    //何が選択されたか調べる
                    if (result == DialogResult.OK)
                    {
                        DialogResult result2 = MessageBox.Show("データが登録できました！", "確認", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        //「OK」が選択された時
                        SQL.BuppinUpdata(SQL, BUPNCD, textBox2, textBox5, textBox6, textBox9, textBox10, comboBox1, comboBox2, comboBox3, comboBox4);
                        PushDelete();
                    }
                    textBox1.Focus();
                }
            }    
        }

        #endregion

        private void textBox9_Enter(object sender, EventArgs e)
        {
            this.textBox9.Select(this.textBox9.Text.Length, 0);
        }

        private void textBox10_Enter(object sender, EventArgs e)
        {
            this.textBox10.Select(this.textBox10.Text.Length, 0);
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            this.textBox2.Select(this.textBox2.Text.Length, 0);
        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {
            this.comboBox1.Select(this.comboBox1.Text.Length, 0);
        }

        private void comboBox2_Enter(object sender, EventArgs e)
        {
            this.comboBox2.Select(this.comboBox2.Text.Length, 0);
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            this.textBox5.Select(this.textBox5.Text.Length, 0);
        }

        private void textBox6_Enter(object sender, EventArgs e)
        {
            this.textBox6.Select(this.textBox6.Text.Length, 0);
        }

        private void comboBox3_Enter(object sender, EventArgs e)
        {
            this.comboBox3.Select(this.comboBox3.Text.Length, 0);
        }

        private void comboBox4_Enter(object sender, EventArgs e)
        {
            this.comboBox4.Select(this.comboBox4.Text.Length, 0);
        }


        // マウスポインタが入力formと重なった時
        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            textBox3.Text = "物品コードを数字13桁以内で入力して下さい。";
        }

        private void textBox2_MouseEnter(object sender, EventArgs e)
        {
            textBox3.Text = "物品名称を20文字以内で入力してください。";
        }

        private void comboBox1_MouseEnter(object sender, EventArgs e)
        {
            textBox3.Text = "物品種別を選択してください。";
        }

        private void comboBox2_MouseEnter(object sender, EventArgs e)
        {
            textBox3.Text = "分類コードを選択してください。";
        }

        private void textBox5_MouseEnter(object sender, EventArgs e)
        {
            textBox3.Text = "基本保管場所を入力してください。例：2F 奥";
        }

        private void comboBox3_MouseEnter(object sender, EventArgs e)
        {
            textBox3.Text = "貸出フラグを選択してください。";
        }

        private void textBox9_MouseEnter(object sender, EventArgs e)
        {
            textBox3.Text = "状態や付属品などを入力してください。例：[状態]美品　[付属品]LANケーブル、マウス";
        }

        private void textBox6_MouseEnter(object sender, EventArgs e)
        {
            textBox3.Text = "最終保管場所を入力してください。例：2F 奥";
        }

        private void comboBox4_MouseEnter(object sender, EventArgs e)
        {
            textBox3.Text = "削除フラグを選択してください。";
        }

        private void textBox10_MouseEnter(object sender, EventArgs e)
        {
            textBox3.Text = "削除理由を入力してください。例：[状態]故障";
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            textBox3.Text = "一つ前の情報を参照することができます";
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            textBox3.Text = "一つ先の情報を参照することができます";
        }

        private void button15_MouseEnter(object sender, EventArgs e)
        {
            textBox3.Text = "先頭の情報を参照することができます";
        }

        private void button16_MouseEnter(object sender, EventArgs e)
        {
            textBox3.Text = "一番後ろの情報を参照することができます";
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}


    
