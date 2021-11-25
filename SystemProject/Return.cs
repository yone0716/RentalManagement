using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SystemProject
{
    public partial class Return : Form
    {
        String bupncd;
        String RETRNNM;
        String RENTLCAT2;

        decimal BUPNCD;
        decimal RENTNO;
        decimal RENTSEQ;

        //SQLの中身を取り出したデータテーブル
        DataTable dt = new DataTable();

        SQL SQL = new SQL();

        public Return()
        {
            InitializeComponent();
        }

        public void PushDelete()
        {
            textBox1.Clear();
            dt.Clear();
        }

        private void Return_Load(object sender, EventArgs e)
        {

            // カラム数を指定
            dataGridView1.ColumnCount = 7;

            // カラム名を指定
            dataGridView1.Columns[0].HeaderText = "ボタン";
            dataGridView1.Columns[1].HeaderText = "貸出No.";
            dataGridView1.Columns[2].HeaderText = "SEQ";
            dataGridView1.Columns[3].HeaderText = "物品名";
            dataGridView1.Columns[4].HeaderText = "返却者";
            dataGridView1.Columns[5].HeaderText = "返却日";
            dataGridView1.Columns[6].HeaderText = "保管場所(入)";

            textBox3.Text = ("物品コードを入力してください。");
                  
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ///型チェック（数値のみ）
            if (System.Text.RegularExpressions.Regex.IsMatch(textBox1.Text, "^[0-9]"))
            {
                bupncd = textBox1.Text;
                BUPNCD = decimal.Parse(bupncd);
            }

            SQL.SQLBuilder();

            string SqlSearch = "SELECT T001_RENT_DTL.T002_RENTNO," +
                               "T001_RENT_DTL.T002_RENTSEQ," +
                               "M001_BUPPIN.M001_BUPNNM," +
                               "T001_RENT_HED.T001_RENTCONT," +
                               "T001_RENT_DTL.T002_RETRNPLAN, " +
                               "T001_RENT_DTL.T002_RENTLCAT1 " +
                               "FROM T001_RENT_DTL " +
                               "LEFT JOIN M001_BUPPIN ON T001_RENT_DTL.T002_BUPNCD = M001_BUPPIN.M001_BUPNCD " +
                               "LEFT JOIN T001_RENT_HED ON T001_RENT_DTL.T002_RENTNO = T001_RENT_HED.T001_RENTNO " +
                              $"WHERE M001_BUPPIN.M001_BUPNCD = {BUPNCD} AND M001_BUPPIN.M001_BUPNRENT = 9 AND T001_RENT_DTL.T002_RETRNDATE = ''";

            dataGridView1.DataSource = SQL.RentList(SQL, SqlSearch, dt);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        //F8(更新)ボタンをクリックしたとき
        private void button10_Click(object sender, EventArgs e)
        {
            RENTNO = decimal.Parse(dt.Rows[0][0].ToString());
            RENTSEQ = decimal.Parse(dt.Rows[0][1].ToString());
            RETRNNM = dt.Rows[0][3].ToString();
            RENTLCAT2 = dt.Rows[0][5].ToString();

            DialogResult result = MessageBox.Show("返却しますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

            //何が選択されたか調べる
            if (result == DialogResult.OK)
            {
                //「OK」が選択された時「
                
                SQL.ReturnUpdata(SQL, RETRNNM, RENTLCAT2, RENTNO, RENTSEQ);
                DialogResult result2 = MessageBox.Show("返却できました！", "確認", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                //貸出フラグを0に(未貸出に)
                SQL.BuppinUnRent(SQL, BUPNCD);
  
                PushDelete();
            }
        }

        //F10(取消)ボタンをクリックしたとき
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

        //F11(終了)ボタンをクリックしたとき
        private void button13_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("終了しますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

            //何が選択されたか調べる
            if (result == DialogResult.OK)
            {
                //次画面を非表示
                this.Visible = false;           
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            //ボタンがクリックされた
            if (dgv.Columns[e.ColumnIndex].Name == "ボタン")
            {           
                string ReceiveRentno = dt.Rows[e.RowIndex][0].ToString();
                decimal SEQ = decimal.Parse(dt.Rows[e.RowIndex][1].ToString());
                //Form1を表示
                Form4 f4 = new Form4(ReceiveRentno, SEQ);
                f4.Show();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
