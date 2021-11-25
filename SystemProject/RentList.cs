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
    public partial class RentList : Form
    {

        SQL SQL = new SQL();

        //SQLの中身を取り出したデータテーブル
        DataTable dt = new DataTable();

        public RentList()
        {
            InitializeComponent();

            SQL.SQLBuilder();

            using (var connection = new SqlConnection(SQL.builder.ConnectionString))
            {
                var cmd = connection.CreateCommand();

                cmd.CommandText = "SELECT M001_BUPNCD, M001_BUPNNM, M001_BUPNKND, M001_BUPNCND FROM M001_BUPPIN WHERE M001_BUPNRENT = 0;";

                var sda = new SqlDataAdapter(cmd);

                //DataTableにデータを読み込ませる。
                sda.Fill(dt);
            }

            dataGridView1.DataSource = dt;
        }

        private void RentList_Load(object sender, EventArgs e)
        {
            dataGridView1.Enabled = false;

            //カラム数を指定
            dataGridView1.ColumnCount = 7;

            // カラム名を指定
            dataGridView1.Columns[0].HeaderText = "物品コード";
            dataGridView1.Columns[1].HeaderText = "物品名";
            dataGridView1.Columns[2].HeaderText = "物品種別";
            dataGridView1.Columns[3].HeaderText = "状態(付属品)";
        }
    }
}
