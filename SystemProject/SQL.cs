using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
namespace SystemProject
{
    class SQL
    {
        // データベースの接続文字列の作成
        public SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();

        public void SQLBuilder()
        {
            builder.DataSource = @"DESKTOP-8Q2DL1F\SQLEXPRESS";     //サーバー名
            builder.UserID = "sa";                                    //ログイン名
            builder.Password = "hal";                              //パスワード
            builder.InitialCatalog = "rentalDB";                      //データベース名
        }

        // 現在の日時を取得
        DateTime now = DateTime.Now;



        ///// 物品マスタ /////

        //追加SQL
        public void BuppinInsert(SQL SQL, decimal BUPNCD, string BUPNNM, decimal BUPNKND, decimal BUPNGRP, string BUPNCND, string BUPNLCAT1, string BUPNLCAT2, string BUPNRENT, string BUPNDEL)
        {
            {

                SQL.SQLBuilder();
                //検索文作成
                string SqlInsert = "INSERT INTO M001_BUPPIN (" +
                                    "M001_BUPNCD," +
                                    "M001_BUPNNM," +
                                    "M001_BUPNKND," +
                                    "M001_BUPNGRP," +
                                    "M001_BUPNCND," +
                                    "M001_BUPNLCAT1," +
                                    "M001_BUPNLCAT2," +
                                    "M001_BUPNRENT," +
                                    "M001_BUPNDEL," +
                                    "M001_INSDATE," +
                                    "M001_INSTIME)" +
                                 "VALUES (" +
                                    "@M001_BUPNCD," +
                                    "@M001_BUPNNM," +
                                    "@M001_BUPNKND," +
                                    "@M001_BUPNGRP," +
                                    "@M001_BUPNCND," +
                                    "@M001_BUPNLCAT1," +
                                    "@M001_BUPNLCAT2," +
                                    "@M001_BUPNRENT," +
                                    "@M001_BUPNDEL," +
                                    "@M001_INSDATE," +
                                    "@M001_INSTIME);";

                try
                {
                    using (var connection = new SqlConnection(SQL.builder.ConnectionString))
                    {
                        using (SqlCommand command = new SqlCommand(SqlInsert, connection))
                        {
                            //データベース接続開始
                            connection.Open();

                            Console.WriteLine("接続成功");

                            //SQLインジェクション対策
                            command.Parameters.AddWithValue("@M001_BUPNCD", BUPNCD);
                            command.Parameters.AddWithValue("@M001_BUPNNM", BUPNNM);
                            command.Parameters.AddWithValue("@M001_BUPNKND", BUPNKND);
                            command.Parameters.AddWithValue("@M001_BUPNGRP", BUPNGRP);
                            command.Parameters.AddWithValue("@M001_BUPNCND", BUPNCND);
                            command.Parameters.AddWithValue("@M001_BUPNLCAT1", BUPNLCAT1);
                            command.Parameters.AddWithValue("@M001_BUPNLCAT2", BUPNLCAT1);
                            command.Parameters.AddWithValue("@M001_BUPNRENT", BUPNRENT);
                            command.Parameters.AddWithValue("@M001_BUPNDEL", BUPNDEL);
                            command.Parameters.AddWithValue("@M001_INSDATE", now.ToString("yyyyMMdd"));
                            command.Parameters.AddWithValue("@M001_INSTIME", now.ToString("HHmmss"));

                            //SQL実行
                            command.ExecuteNonQuery();
                        }
                    }
                }
                //例外処理
                catch
                {
                    Console.WriteLine("接続失敗");
                }
            }
        }

        //削除SQL
        public void BuppinDelete(SQL SQL, decimal BUPNCD, ComboBox comboBox4)
        {
            SQL.SQLBuilder();

            //検索文作成
            string SqlUpdate = $"UPDATE M001_BUPPIN SET M001_BUPNDEL = @M001_BUPNDEL WHERE M001_BUPNCD = {BUPNCD};";

            //DB接続
            try
            {
                using (var connection = new SqlConnection(SQL.builder.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(SqlUpdate, connection))
                    {
                        //データベース接続開始
                        connection.Open();

                        //SQLインジェクション対策
                        command.Parameters.AddWithValue("@M001_BUPNDEL", 9);
                        command.Parameters.AddWithValue("@M001_UPDDATE", now.ToString("yyyyMMdd"));
                        command.Parameters.AddWithValue("@M001_UPDTIME", now.ToString("HHmmss"));

                        //SQL実行
                        command.ExecuteNonQuery();
                    }
                }
            }
            //例外処理
            catch
            {
                Console.WriteLine("接続失敗");
            }
        }

        //貸出SQL(貸出中)
        public void BuppinRent(SQL SQL, decimal BUPNCD)
        {
            SQL.SQLBuilder();

            //検索文作成
            string SqlUpdate = $"UPDATE M001_BUPPIN SET M001_BUPNRENT = @M001_BUPNRENT WHERE M001_BUPNCD = {BUPNCD};";

            //DB接続
            try
            {
                using (var connection = new SqlConnection(SQL.builder.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(SqlUpdate, connection))
                    {
                        //データベース接続開始
                        connection.Open();

                        //SQLインジェクション対策
                        command.Parameters.AddWithValue("@M001_BUPNRENT", 9);
                        command.Parameters.AddWithValue("@M001_UPDDATE", now.ToString("yyyyMMdd"));
                        command.Parameters.AddWithValue("@M001_UPDTIME", now.ToString("HHmmss"));

                        //SQL実行
                        command.ExecuteNonQuery();
                    }
                }
            }
            //例外処理
            catch
            {
                Console.WriteLine("接続失敗");
            }
        }

        //貸出SQL（未貸出）
        public void BuppinUnRent(SQL SQL, decimal BUPNCD)
        {
            SQL.SQLBuilder();

            //検索文作成
            string SqlUpdate = $"UPDATE M001_BUPPIN SET M001_BUPNRENT = @M001_BUPNRENT WHERE M001_BUPNCD = {BUPNCD};";

            //DB接続
            try
            {
                using (var connection = new SqlConnection(SQL.builder.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(SqlUpdate, connection))
                    {
                        //データベース接続開始
                        connection.Open();

                        //SQLインジェクション対策
                        command.Parameters.AddWithValue("@M001_BUPNRENT", 0);
                        command.Parameters.AddWithValue("@M001_UPDDATE", now.ToString("yyyyMMdd"));
                        command.Parameters.AddWithValue("@M001_UPDTIME", now.ToString("HHmmss"));

                        //SQL実行
                        command.ExecuteNonQuery();
                    }
                }
            }
            //例外処理
            catch
            {
                Console.WriteLine("接続失敗");
            }
        }

        //保管場所(入)SQL
        public void BuppinLCAT2(SQL SQL, decimal BUPNCD, TextBox textBox7)
        {
            SQL.SQLBuilder();

            //検索文作成
            string SqlUpdate = $"UPDATE M001_BUPPIN SET M001_BUPNLCAT2 = @M001_BUPNLCAT2 WHERE M001_BUPNCD = {BUPNCD};";

            //DB接続
            try
            {
                using (var connection = new SqlConnection(SQL.builder.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(SqlUpdate, connection))
                    {
                        //データベース接続開始
                        connection.Open();

                        //SQLインジェクション対策
                        command.Parameters.AddWithValue("@M001_BUPNLCAT2", textBox7.Text);
                        command.Parameters.AddWithValue("@M001_UPDDATE", now.ToString("yyyyMMdd"));
                        command.Parameters.AddWithValue("@M001_UPDTIME", now.ToString("HHmmss"));

                        //SQL実行
                        command.ExecuteNonQuery();
                    }
                }
            }
            //例外処理
            catch
            {
                Console.WriteLine("接続失敗");
            }
        }

        //更新SQL
        public void BuppinUpdata(SQL SQL, decimal BUPNCD, TextBox textBox2, TextBox textBox5, TextBox textBox6, TextBox textBox9, TextBox textBox10, ComboBox comboBox1, ComboBox comboBox2, ComboBox comboBox3, ComboBox comboBox4)
        {
            SQL.SQLBuilder();

            //検索文作成
            string SqlUpdate = "UPDATE M001_BUPPIN SET " +
                                "M001_BUPNNM = @M001_BUPNNM," +
                                "M001_BUPNKND = @M001_BUPNKND," +
                                "M001_BUPNGRP = @M001_BUPNGRP," +
                                "M001_BUPNCND = @M001_BUPNCND," +
                                "M001_BUPNLCAT1 = @M001_BUPNLCAT1," +
                                "M001_BUPNLCAT2 = @M001_BUPNLCAT2," +
                                "M001_BUPNRENT = @M001_BUPNRENT," +
                                "M001_BUPNDEL = @M001_BUPNDEL," +
                                "M001_BUPNRESN = @M001_BUPNRESN," +
                                "M001_UPDDATE = @M001_UPDDATE," +
                                "M001_UPDTIME = @M001_UPDTIME" +
                               $" WHERE M001_BUPNCD = {BUPNCD};";

            //DB接続
            try
            {
                using (var connection = new SqlConnection(SQL.builder.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(SqlUpdate, connection))
                    {
                        //データベース接続開始
                        connection.Open();

                        //SQLインジェクション対策
                        command.Parameters.AddWithValue("@M001_BUPNNM", textBox2.Text);
                        command.Parameters.AddWithValue("@M001_BUPNKND", comboBox1.Text);
                        command.Parameters.AddWithValue("@M001_BUPNGRP", comboBox2.Text);
                        command.Parameters.AddWithValue("@M001_BUPNCND", textBox9.Text);
                        command.Parameters.AddWithValue("@M001_BUPNLCAT1", textBox5.Text);
                        command.Parameters.AddWithValue("@M001_BUPNLCAT2", textBox6.Text);
                        command.Parameters.AddWithValue("@M001_BUPNRENT", comboBox3.Text);
                        command.Parameters.AddWithValue("@M001_BUPNDEL", comboBox4.Text);
                        command.Parameters.AddWithValue("@M001_BUPNRESN", textBox10.Text);
                        command.Parameters.AddWithValue("@M001_UPDDATE", now.ToString("yyyyMMdd"));
                        command.Parameters.AddWithValue("@M001_UPDTIME", now.ToString("HHmmss"));

                        //SQL実行
                        command.ExecuteNonQuery();
                    }
                }
            }
            //例外処理
            catch
            {
                Console.WriteLine("接続失敗");
            }

        }

        //入力値検索SQL
        public bool BuppinSearch(SQL SQL, decimal BUPNCD, bool check_flg)
        {
            SQL.SQLBuilder();

            //検索SQL
            string SqlAll = "SELECT * FROM M001_BUPPIN";

            using (var connection = new SqlConnection(SQL.builder.ConnectionString))
            {
                //接続を確立
                connection.Open();

                //SELECT文を作成
                SqlCommand all_command = new SqlCommand(SqlAll, connection);
                using (SqlDataReader all = all_command.ExecuteReader())
                {
                    while (all.Read())
                    {
                        String prim = all[0].ToString();
                        decimal PRIM = decimal.Parse(prim);

                        //重複チェック
                        if (PRIM == BUPNCD)
                        {
                            check_flg = true;
                        }
                    }
                }

            }
            return check_flg;
        }


        //一つ前のデータを取得
        public void BuppinBeforeData(SQL SQL, decimal BUPNCD, TextBox textBox1, TextBox textBox3)
        {
            SQL.SQLBuilder();


            string SqlBefore = $"SELECT MAX(M001_BUPNCD) FROM M001_BUPPIN WHERE M001_BUPNCD < {BUPNCD}";

            try
            {
                using (var connection = new SqlConnection(SQL.builder.ConnectionString))
                {
                    //接続を確立
                    connection.Open();

                    //SELECT文を作成
                    SqlCommand before_command = new SqlCommand(SqlBefore, connection);
                    using (SqlDataReader before = before_command.ExecuteReader())
                    {
                        while (before.Read())
                        {
                            textBox1.Text = before[0].ToString();
                            if (before[0].ToString() == "")
                            {
                                textBox3.Text = "先頭です。これ以上前は表示できません";
                            }

                        }

                        before.Close();

                    }
                }
            }
            //例外処理
            catch
            {
                Console.WriteLine("接続失敗");
            }
        }

        //次のデータを取得
        public void BuppinAfterData(SQL SQL, decimal BUPNCD, TextBox textBox1, TextBox textBox3)
        {
            SQL.SQLBuilder();

            string SqlBefore = $"SELECT MIN(M001_BUPNCD) FROM M001_BUPPIN WHERE M001_BUPNCD > {BUPNCD}";

            try
            {
                using (var connection = new SqlConnection(SQL.builder.ConnectionString))
                {
                    //接続を確立
                    connection.Open();

                    //SELECT文を作成
                    SqlCommand after_command = new SqlCommand(SqlBefore, connection);
                    using (SqlDataReader after = after_command.ExecuteReader())
                    {
                        while (after.Read())
                        {
                            textBox1.Text = after[0].ToString();

                            if (after[0].ToString() == "")
                            {
                                textBox3.Text = "最後です。これ以上後は表示できません";
                            }
                        }


                        after.Close();
                    }
                }
            }
            //例外処理
            catch
            {
                Console.WriteLine("接続失敗");
            }

        }

        //先頭のデータを取得
        public void BuppinMinData(SQL SQL, decimal BUPNCD, TextBox textBox1)
        {
            SQL.SQLBuilder();

            string SqlBefore = "SELECT MIN(M001_BUPNCD) FROM M001_BUPPIN";

            try
            {
                using (var connection = new SqlConnection(SQL.builder.ConnectionString))
                {
                    //接続を確立
                    connection.Open();

                    //SELECT文を作成
                    SqlCommand before_command = new SqlCommand(SqlBefore, connection);
                    using (SqlDataReader before = before_command.ExecuteReader())
                    {
                        while (before.Read())
                        {
                            textBox1.Text = before[0].ToString();
                        }
                        before.Close();
                    }
                }
            }
            //例外処理
            catch
            {
                Console.WriteLine("接続失敗");
            }
        }

        //最後のデータを取得
        public void BuppinMaxData(SQL SQL, decimal BUPNCD, TextBox textBox1)
        {
            SQL.SQLBuilder();

            string SqlBefore = "SELECT MAX(M001_BUPNCD) FROM M001_BUPPIN";

            try
            {
                using (var connection = new SqlConnection(SQL.builder.ConnectionString))
                {
                    //接続を確立
                    connection.Open();

                    //SELECT文を作成
                    SqlCommand before_command = new SqlCommand(SqlBefore, connection);
                    using (SqlDataReader before = before_command.ExecuteReader())
                    {
                        while (before.Read())
                        {
                            textBox1.Text = before[0].ToString();
                        }
                        before.Close();
                    }
                }
            }
            //例外処理
            catch
            {
                Console.WriteLine("接続失敗");
            }
        }

        //検索データを取得
        public void BuppinGetData(SQL SQL, decimal BUPNCD, TextBox textBox1, TextBox textBox2, TextBox textBox5, TextBox textBox6, TextBox textBox9, TextBox textBox10, ComboBox comboBox1, ComboBox comboBox2, ComboBox comboBox3, ComboBox comboBox4)
        {
            SQL.SQLBuilder();

            string SqlSearch = $"SELECT * FROM M001_BUPPIN WHERE M001_BUPNCD = {BUPNCD}";

            try
            {
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
                            textBox1.Text = reader[0].ToString();
                            textBox2.Text = reader[2].ToString();
                            comboBox1.Text = reader[3].ToString();
                            comboBox2.Text = reader[4].ToString();
                            textBox9.Text = reader[5].ToString();
                            textBox5.Text = reader[6].ToString();
                            textBox6.Text = reader[7].ToString();
                            comboBox3.Text = reader[8].ToString();
                            comboBox4.Text = reader[9].ToString();
                            textBox10.Text = reader[10].ToString();
                        }
                        reader.Close();
                    }
                }
            }
            //例外処理
            catch
            {
                Console.WriteLine("接続失敗");
            }
        }

        ///// 物品照会 /////

        //ソート
        public void BuppinSearchData(decimal BUPNRENT, decimal BUPNDEL, decimal BUPNKND, DataTable dt, DataGridView dataGridView1)
        {
            //SQL
            SQLBuilder();
            using (var connection = new SqlConnection(builder.ConnectionString))
            {
                var cmd = connection.CreateCommand();

                //すべての貸出かつ
                if (BUPNRENT == 1)
                {
                    //削除を含まない（削除フラグ0）
                    if (BUPNDEL == 0)
                    {
                        cmd.CommandText = $"SELECT M001_BUPNLCAT2,M001_BUPNGRP,M001_BUPNCD,M001_BUPNNM,M001_BUPNRENT,M001_BUPNCND,M001_BUPNDEL FROM M001_BUPPIN WHERE M001_BUPNKND = {BUPNKND} AND M001_BUPNDEL = {BUPNDEL};";
                    }
                    //削除を含む（削除フラグ9）
                    else
                    {
                        cmd.CommandText = $"SELECT M001_BUPNLCAT2,M001_BUPNGRP,M001_BUPNCD,M001_BUPNNM,M001_BUPNRENT,M001_BUPNCND,M001_BUPNDEL FROM M001_BUPPIN WHERE M001_BUPNKND = {BUPNKND};";
                    }

                }
                //貸出中のみかつ
                else
                {
                    //削除を含まない（削除フラグ0）
                    if (BUPNDEL == 0)
                    {
                        cmd.CommandText = $"SELECT M001_BUPNLCAT2,M001_BUPNGRP,M001_BUPNCD,M001_BUPNNM,M001_BUPNRENT,M001_BUPNCND,M001_BUPNDEL FROM M001_BUPPIN WHERE M001_BUPNKND = {BUPNKND} AND M001_BUPNRENT = {BUPNRENT} AND M001_BUPNDEL = {BUPNDEL};";
                    }
                    //削除を含む（削除フラグ1）
                    else
                    {
                        cmd.CommandText = $"SELECT M001_BUPNLCAT2,M001_BUPNGRP,M001_BUPNCD,M001_BUPNNM,M001_BUPNRENT,M001_BUPNCND,M001_BUPNDEL FROM M001_BUPPIN WHERE M001_BUPNKND = {BUPNKND} AND M001_BUPNRENT = {BUPNRENT};";
                    }
                }

                var sda = new SqlDataAdapter(cmd);

                //DataTableにデータを読み込ませる。
                sda.Fill(dt);
            }

            //一定の条件を満たす行の列値を一括置換する
            dt.AsEnumerable().Where(r => r["M001_BUPNRENT"].ToString() == "0").Select(r => r["M001_BUPNRENT"] = "未").ToList();
            dt.AsEnumerable().Where(r => r["M001_BUPNRENT"].ToString() == "9").Select(r => r["M001_BUPNRENT"] = "貸").ToList();
            dt.AsEnumerable().Where(r => r["M001_BUPNDEL"].ToString() == "0").Select(r => r["M001_BUPNDEL"] = "").ToList();
            dt.AsEnumerable().Where(r => r["M001_BUPNDEL"].ToString() == "9").Select(r => r["M001_BUPNDEL"] = "削").ToList();

            dataGridView1.DataSource = dt;

        }

        ///// 貸出記録登録 /////

        //入力値検索SQL
        public bool RentSearch(SQL SQL, decimal RENTNO, bool check_flg)
        {
            SQL.SQLBuilder();

            //検索SQL
            string SqlAll = "SELECT * FROM T001_RENT_HED";

            using (var connection = new SqlConnection(SQL.builder.ConnectionString))
            {
                //接続を確立
                connection.Open();

                //SELECT文を作成
                SqlCommand all_command = new SqlCommand(SqlAll, connection);
                using (SqlDataReader all = all_command.ExecuteReader())
                {
                    while (all.Read())
                    {
                        String prim = all[0].ToString();
                        decimal PRIM = decimal.Parse(prim);

                        //重複チェック
                        if (PRIM == RENTNO)
                        {
                            check_flg = true;
                        }
                    }
                }

            }
            return check_flg;
        }

        //検索データを取得
        public void RentGetData(SQL SQL, decimal RENTNO, ComboBox comboBox1, TextBox textBox1, TextBox textBox2, TextBox textBox3, TextBox textBox11, TextBox textBox12)
        {
            SQL.SQLBuilder();

            string SqlSearch = $"SELECT * FROM T001_RENT_HED WHERE T001_RENTNO = {RENTNO}";

            try
            {
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
                            textBox1.Text = reader[0].ToString();
                            comboBox1.Text = reader[1].ToString();
                            textBox12.Text = reader[2].ToString();
                            textBox3.Text = reader[3].ToString();
                            textBox2.Text = reader[4].ToString();
                            textBox11.Text = reader[5].ToString();
                        }
                        reader.Close();
                    }
                }
            }
            //例外処理
            catch
            {
                Console.WriteLine("接続失敗");
            }
        }

        //追加SQL
        public void RentInsert(SQL SQL, decimal RENTNO, decimal BUPNKND, String RENTCONT, String RENTCMNT)
        {
            {
                SQL.SQLBuilder();
                //検索文作成
                string SqlInsert = "INSERT INTO T001_RENT_HED (" +
                                    "T001_RENTNO," +
                                    "T001_BUPNKND," +
                                    "T001_RENTDATE," +
                                    "T001_RENTCONT," +
                                    "T001_RENTUSER," +
                                    "T001_RENTCMNT," +
                                    "T001_INSDATE," +
                                    "T001_INSTIME)" +
                                 "VALUES (" +
                                    "@T001_RENTNO," +
                                    "@T001_BUPNKND," +
                                    "@T001_RENTDATE," +
                                    "@T001_RENTCONT," +
                                    "@T001_RENTUSER," +
                                    "@T001_RENTCMNT," +
                                    "@T001_INSDATE," +
                                    "@T001_INSTIME);";

                try
                {
                    using (var connection = new SqlConnection(SQL.builder.ConnectionString))
                    {
                        using (SqlCommand command = new SqlCommand(SqlInsert, connection))
                        {
                            //データベース接続開始
                            connection.Open();

                            Console.WriteLine("接続成功");

                            //SQLインジェクション対策
                            command.Parameters.AddWithValue("@T001_RENTNO", RENTNO);
                            command.Parameters.AddWithValue("@T001_BUPNKND", BUPNKND);
                            command.Parameters.AddWithValue("@T001_RENTDATE", now.ToString("yyyyMMdd"));
                            command.Parameters.AddWithValue("@T001_RENTCONT", RENTCONT);
                            command.Parameters.AddWithValue("@T001_RENTUSER", RENTCONT);
                            command.Parameters.AddWithValue("@T001_RENTCMNT", RENTCMNT);
                            command.Parameters.AddWithValue("@T001_INSDATE", now.ToString("yyyyMMdd"));
                            command.Parameters.AddWithValue("@T001_INSTIME", now.ToString("HHmmss"));

                            //SQL実行
                            command.ExecuteNonQuery();
                        }
                    }
                }
                //例外処理
                catch
                {
                    Console.WriteLine("接続失敗");
                }
            }
        }

        //更新SQL
        public void RentUpdata(SQL SQL, decimal RENTNO, ComboBox comboBox1, TextBox textBox12, TextBox textBox3, TextBox textBox2, TextBox textBox11)
        {
            SQL.SQLBuilder();

            //検索文作成
            string SqlUpdate = "UPDATE T001_RENT_HED SET " +
                                "T001_BUPNKND = @T001_BUPNKND," +
                                "T001_RENTDATE = @T001_RENTDATE," +
                                "T001_RENTCONT = @T001_RENTCONT," +
                                "T001_RENTUSER = @T001_RENTUSER," +
                                "T001_RENTCMNT = @T001_RENTCMNT," +
                                "T001_UPDDATE = @T001_UPDDATE," +
                                "T001_UPDTIME = @T001_UPDTIME" +
                               $" WHERE T001_RENTNO = {RENTNO};";

            //DB接続
            try
            {
                using (var connection = new SqlConnection(SQL.builder.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(SqlUpdate, connection))
                    {
                        //データベース接続開始
                        connection.Open();

                        //SQLインジェクション対策                
                        command.Parameters.AddWithValue("@T001_BUPNKND", comboBox1.Text);
                        command.Parameters.AddWithValue("@T001_RENTDATE", textBox12.Text);
                        command.Parameters.AddWithValue("@T001_RENTCONT", textBox3.Text);
                        command.Parameters.AddWithValue("@T001_RENTUSER", textBox2.Text);
                        command.Parameters.AddWithValue("@T001_RENTCMNT", textBox11.Text);
                        command.Parameters.AddWithValue("@T001_UPDDATE", now.ToString("yyyyMMdd"));
                        command.Parameters.AddWithValue("@T001_UPDTIME", now.ToString("HHmmss"));

                        //SQL実行
                        command.ExecuteNonQuery();
                    }
                }
            }
            //例外処理
            catch
            {
                Console.WriteLine("接続失敗");
            }
        }

        //最後のデータを取得
        public void RentMaxData(SQL SQL, decimal RENTNO, TextBox textBox1, TextBox textBox3)
        {
            SQL.SQLBuilder();

            string SqlBefore = $"SELECT MAX(T001_RENTNO) FROM T001_RENT_HED";

            try
            {
                using (var connection = new SqlConnection(SQL.builder.ConnectionString))
                {
                    //接続を確立
                    connection.Open();

                    //SELECT文を作成
                    SqlCommand max_command = new SqlCommand(SqlBefore, connection);
                    using (SqlDataReader max = max_command.ExecuteReader())
                    {
                        while (max.Read())
                        {
                            int tmp = int.Parse(max[0].ToString());

                            textBox1.Text = (tmp + 1).ToString();

                            if (max[0].ToString() == "")
                            {
                                textBox3.Text = "最後です。これ以上後は表示できません";
                            }
                        }
                        max.Close();
                    }
                }
            }
            //例外処理
            catch
            {
                Console.WriteLine("接続失敗");
            }

        }

        //一つ前のデータを取得
        public void RentBeforeData(SQL SQL, decimal RENTNO, TextBox textBox1, TextBox textBox14)
        {
            SQL.SQLBuilder();


            string SqlBefore = $"SELECT MAX(T001_RENTNO) FROM T001_RENT_HED WHERE T001_RENTNO < {RENTNO}";

            try
            {
                using (var connection = new SqlConnection(SQL.builder.ConnectionString))
                {
                    //接続を確立
                    connection.Open();

                    //SELECT文を作成
                    SqlCommand before_command = new SqlCommand(SqlBefore, connection);
                    using (SqlDataReader before = before_command.ExecuteReader())
                    {
                        while (before.Read())
                        {
                            textBox1.Text = before[0].ToString();
                            if (before[0].ToString() == "")
                            {
                                textBox14.Text = "先頭です。これ以上前は表示できません";
                            }

                        }

                        before.Close();

                    }
                }
            }
            //例外処理
            catch
            {
                Console.WriteLine("接続失敗");
            }
        }

        //次のデータを取得
        public void RentAfterData(SQL SQL, decimal RENTNO, TextBox textBox1, TextBox textBox14)
        {
            SQL.SQLBuilder();

            string SqlBefore = $"SELECT MIN(T001_RENTNO) FROM T001_RENT_HED WHERE T001_RENTNO > {RENTNO}";

            try
            {
                using (var connection = new SqlConnection(SQL.builder.ConnectionString))
                {
                    //接続を確立
                    connection.Open();

                    //SELECT文を作成
                    SqlCommand after_command = new SqlCommand(SqlBefore, connection);
                    using (SqlDataReader after = after_command.ExecuteReader())
                    {
                        while (after.Read())
                        {
                            textBox1.Text = after[0].ToString();

                            if (after[0].ToString() == "")
                            {
                                textBox14.Text = "最後です。これ以上後は表示できません";
                            }
                        }
                        after.Close();
                    }
                }
            }
            //例外処理
            catch
            {
                Console.WriteLine("接続失敗");
            }

        }

        //追加SQL
        public void RentDtlInsert(SQL SQL, decimal RENTNO, decimal RENTSEQ, decimal BUPNCD, String BUPNCND, String RETRNPLAN, String RENTLCAT1, String RETRNDATE, String RETRNNM, String RENTCMNT2, String RENTLCAT2)
        {
            {
                SQL.SQLBuilder();
                //検索文作成
                string SqlInsert = "INSERT INTO T001_RENT_DTL (" +
                                    "T002_RENTNO," +
                                    "T002_RENTSEQ," +
                                    "T002_BUPNCD," +
                                    "T002_BUPNCND," +
                                    "T002_RETRNPLAN," +
                                    "T002_RENTLCAT1," +
                                    "T002_RETRNDATE," +
                                    "T002_RETRNNM," +
                                    "T002_RENTCMNT," +
                                    "T002_RENTLCAT2," +
                                    "T002_INSDATE," +
                                    "T002_INSTIME)" +
                                 "VALUES (" +
                                    "@T002_RENTNO," +
                                    "@T002_RENTSEQ," +
                                    "@T002_BUPNCD," +
                                    "@T002_BUPNCND," +
                                    "@T002_RETRNPLAN," +
                                    "@T002_RENTLCAT1," +
                                    "@T002_RETRNDATE," +
                                    "@T002_RETRNNM," +
                                    "@T002_RENTCMNT," +
                                    "@T002_RENTLCAT2," +
                                    "@T002_INSDATE," +
                                    "@T002_INSTIME);";

                try
                {
                    using (var connection = new SqlConnection(SQL.builder.ConnectionString))
                    {
                        using (SqlCommand command = new SqlCommand(SqlInsert, connection))
                        {
                            //データベース接続開始
                            connection.Open();

                            Console.WriteLine("接続成功");

                            //SQLインジェクション対策
                            command.Parameters.AddWithValue("@T002_RENTNO", RENTNO);
                            command.Parameters.AddWithValue("@T002_RENTSEQ", RENTSEQ);
                            command.Parameters.AddWithValue("@T002_BUPNCD", BUPNCD);
                            command.Parameters.AddWithValue("@T002_BUPNCND", BUPNCND);
                            command.Parameters.AddWithValue("@T002_RETRNPLAN", RETRNPLAN);
                            command.Parameters.AddWithValue("@T002_RENTLCAT1", RENTLCAT1);
                            command.Parameters.AddWithValue("@T002_RETRNDATE", RETRNDATE);
                            command.Parameters.AddWithValue("@T002_RETRNNM", RETRNNM);
                            command.Parameters.AddWithValue("@T002_RENTCMNT", RENTCMNT2);
                            command.Parameters.AddWithValue("@T002_RENTLCAT2", RENTLCAT2);
                            command.Parameters.AddWithValue("@T002_INSDATE", now.ToString("yyyyMMdd"));
                            command.Parameters.AddWithValue("@T002_INSTIME", now.ToString("HHmmss"));

                            //SQL実行
                            command.ExecuteNonQuery();
                        }
                    }
                }
                //例外処理
                catch
                {
                    Console.WriteLine("接続失敗");
                }
            }
        }

        //検索データを取得
        public void RentDtlGetData(SQL SQL, decimal RENTNO, TextBox textBox15, TextBox textBox5, TextBox textBox10, TextBox textBox4, TextBox textBox6, TextBox textBox9, TextBox textBox8, TextBox textBox13, TextBox textBox7)
        {
            SQL.SQLBuilder();

            string SqlSearch = $"SELECT * FROM T001_RENT_DTL WHERE T002_RENTNO = {RENTNO} ";

            try
            {
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
                            textBox15.Text = reader[1].ToString();
                            textBox4.Text = reader[2].ToString();
                            textBox10.Text = reader[3].ToString();
                            textBox5.Text = reader[4].ToString();
                            textBox6.Text = reader[5].ToString();
                            textBox9.Text = reader[6].ToString();
                            textBox8.Text = reader[7].ToString();
                            textBox13.Text = reader[8].ToString();
                            textBox7.Text = reader[9].ToString();
                        }
                        reader.Close();
                    }
                }
            }
            //例外処理
            catch
            {
                Console.WriteLine("接続失敗");
            }
        }

        public void RentDtlSEQGetData(SQL SQL, decimal RENTNO, TextBox textBox15, TextBox textBox5, TextBox textBox10, TextBox textBox4, TextBox textBox6, TextBox textBox9, TextBox textBox8, TextBox textBox13, TextBox textBox7, decimal SEQ)
        {
            SQL.SQLBuilder();

            string SqlSearch = $"SELECT * FROM T001_RENT_DTL WHERE T002_RENTNO = {RENTNO} AND T002_RENTSEQ = {SEQ} ";

            try
            {
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
                            textBox15.Text = reader[1].ToString();
                            textBox4.Text = reader[2].ToString();
                            textBox10.Text = reader[3].ToString();
                            textBox5.Text = reader[4].ToString();
                            textBox6.Text = reader[5].ToString();
                            textBox9.Text = reader[6].ToString();
                            textBox8.Text = reader[7].ToString();
                            textBox13.Text = reader[8].ToString();
                            textBox7.Text = reader[9].ToString();
                        }
                        reader.Close();
                    }
                }
            }
            //例外処理
            catch
            {
                Console.WriteLine("接続失敗");
            }
        }

        //SEQデータ取得
        public void SEQGetData(SQL SQL, decimal RENTNO, decimal RENTSEQ, TextBox textBox15, TextBox textBox5, TextBox textBox10, TextBox textBox4, TextBox textBox6, TextBox textBox9, TextBox textBox8, TextBox textBox13, TextBox textBox7)
        {
            SQL.SQLBuilder();

            string SqlSearch = $"SELECT * FROM T001_RENT_DTL WHERE T002_RENTNO = {RENTNO} AND T002_RENTSEQ = {RENTSEQ};";

            try
            {
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
                            textBox15.Text = reader[1].ToString();
                            textBox4.Text = reader[2].ToString();
                            textBox10.Text = reader[3].ToString();
                            textBox5.Text = reader[4].ToString();
                            textBox6.Text = reader[5].ToString();
                            textBox9.Text = reader[6].ToString();
                            textBox8.Text = reader[7].ToString();
                            textBox13.Text = reader[8].ToString();
                            textBox7.Text = reader[9].ToString();
                        }
                        reader.Close();
                    }
                }
            }
            //例外処理
            catch
            {
                Console.WriteLine("接続失敗");
            }
        }

        //更新SQL
        public void RentDtlUpdata(SQL SQL, decimal RENTNO, decimal RENTSEQ, TextBox textBox5, TextBox textBox10, TextBox textBox4, TextBox textBox6, TextBox textBox9, TextBox textBox8, TextBox textBox13, TextBox textBox7)
        {
            SQL.SQLBuilder();

            //検索文作成
            string SqlUpdate = "UPDATE T001_RENT_DTL SET " +
                                "T002_BUPNCD = @T002_BUPNCD," +
                                "T002_BUPNCND = @T002_BUPNCND," +
                                "T002_RETRNPLAN = @T002_RETRNPLAN," +
                                "T002_RENTLCAT1 = @T002_RENTLCAT1," +
                                "T002_RETRNDATE = @T002_RETRNDATE," +
                                "T002_RETRNNM = @T002_RETRNNM," +
                                "T002_RENTCMNT = @T002_RENTCMNT," +
                                "T002_RENTLCAT2 = @T002_RENTLCAT2," +
                                "T002_UPDDATE = @T002_UPDDATE," +
                                "T002_UPDTIME = @T002_UPDTIME" +
                               $" WHERE T002_RENTNO = {RENTNO} AND T002_RENTSEQ = {RENTSEQ};";

            //DB接続
            try
            {
                using (var connection = new SqlConnection(SQL.builder.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(SqlUpdate, connection))
                    {
                        //データベース接続開始
                        connection.Open();

                        //SQLインジェクション対策                
                        command.Parameters.AddWithValue("@T002_BUPNCD", textBox4.Text);
                        command.Parameters.AddWithValue("@T002_BUPNCND", textBox10.Text);
                        command.Parameters.AddWithValue("@T002_RETRNPLAN", textBox5.Text);
                        command.Parameters.AddWithValue("@T002_RENTLCAT1", textBox6.Text);
                        command.Parameters.AddWithValue("@T002_RETRNDATE", textBox9.Text);
                        command.Parameters.AddWithValue("@T002_RETRNNM", textBox8.Text);
                        command.Parameters.AddWithValue("@T002_RENTCMNT", textBox13.Text);
                        command.Parameters.AddWithValue("@T002_RENTLCAT2", textBox7.Text);
                        command.Parameters.AddWithValue("@T002_UPDDATE", now.ToString("yyyyMMdd"));
                        command.Parameters.AddWithValue("@T002_UPDTIME", now.ToString("HHmmss"));

                        //SQL実行
                        command.ExecuteNonQuery();
                    }
                }
            }
            //例外処理
            catch
            {
                Console.WriteLine("接続失敗");
            }
        }

        public DataTable RentList(SQL SQL, string SQLText, DataTable dt)
        {
            dt.Clear();
            //SQL.RentalList(SQL, RENTNO, dataGridView1);

            SQL.SQLBuilder();

            using (var connection = new SqlConnection(SQL.builder.ConnectionString))
            {
                var cmd = connection.CreateCommand();

                cmd.CommandText = SQLText;

                var sda = new SqlDataAdapter(cmd);

                //DataTableにデータを読み込ませる。
                sda.Fill(dt);
            }

            return dt;
        }

        public DataTable TestRentList(SQL SQL, string SQLText, DataTable dt)
        {
            dt.Clear();
            //SQL.RentalList(SQL, RENTNO, dataGridView1);

            SQL.SQLBuilder();

            using (var connection = new SqlConnection(SQL.builder.ConnectionString))
            {
                var cmd = connection.CreateCommand();

                cmd.CommandText = SQLText;

                var sda = new SqlDataAdapter(cmd);

                //DataTableにデータを読み込ませる。
                sda.Fill(dt);
            }

            return dt;
        }


        public bool RentOK(SQL SQL, TextBox textBox4, ComboBox comboBox1, bool RentCheck_flg)
        {
            SQL.SQLBuilder();

            decimal BUPNCD = decimal.Parse(textBox4.Text);
            decimal BUPNKND = decimal.Parse(comboBox1.Text);

            string SqlAll = "SELECT * FROM M001_BUPPIN " +
                            $"WHERE M001_BUPNCD = {BUPNCD} AND M001_BUPNKND = {BUPNKND};";

            using (var connection = new SqlConnection(SQL.builder.ConnectionString))
            {
                //接続を確立
                connection.Open();

                //SELECT文を作成
                SqlCommand all_command = new SqlCommand(SqlAll, connection);
                using (SqlDataReader all = all_command.ExecuteReader())
                {
                    while (all.Read())
                    {
                        String prim = all[8].ToString();
                        decimal PRIM = decimal.Parse(prim);

                        //重複チェック
                        if (PRIM != 9)
                        {
                            RentCheck_flg = true;
                        }
                    }
                }

            }
            return RentCheck_flg;
        }
        ///////// 返却 ////////////

        //更新SQL
        public void ReturnUpdata(SQL SQL , String RETRNNM , String RENTLCAT2, decimal RENTNO, decimal RENTSEQ)
        {
            SQL.SQLBuilder();

            //検索文作成
            string SqlUpdate = "UPDATE T001_RENT_DTL SET " +
                                "T002_RETRNNM = @T002_RETRNNM," +
                                "T002_RETRNDATE = @T002_RETRNDATE," +
                                "T002_RENTLCAT2 = @T002_RENTLCAT2," +
                                "T002_UPDDATE = @T002_UPDDATE," +
                                "T002_UPDTIME = @T002_UPDTIME " +
                               $"WHERE T002_RENTNO {RENTNO} AND T002_RENTSEQ {RENTSEQ}";
                              
            //DB接続
            try
            {
                using (var connection = new SqlConnection(SQL.builder.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(SqlUpdate, connection))
                    {
                        //データベース接続開始
                        connection.Open();

                        //SQLインジェクション対策
                        command.Parameters.AddWithValue("@T002_RETRNNM", RETRNNM);
                        command.Parameters.AddWithValue("@T002_RETRNDATE", now.ToString("yyyyMMdd"));
                        command.Parameters.AddWithValue("@T002_RENTLCAT2", RENTLCAT2);                  
                        command.Parameters.AddWithValue("@T002_UPDDATE", now.ToString("yyyyMMdd"));
                        command.Parameters.AddWithValue("@T002_UPDTIME", now.ToString("HHmmss"));

                        //SQL実行
                        command.ExecuteNonQuery();
                    }
                }
            }
            //例外処理
            catch
            {
                Console.WriteLine("接続失敗");
            }
        }

    }
}
