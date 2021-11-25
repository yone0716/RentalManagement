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
namespace SystemProject
{
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.ActiveControl = button1;
          
        }

        // キーボード入力処理
        private void Form1_Load(object sender, EventArgs e)
        {
            Application.Idle += new EventHandler(Application_Idle);
           
        }

        private void Application_Idle(object sender, EventArgs e)
        {
            if (Keyboard.IsKeyDown(Key.F11) == true)
            {
                this.Visible = false;

                Application.Exit();
            }
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();

            f4.Show();
            f4.AutoScroll = true;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            Application.Exit();
        }

        //F7(返却)ボタンがクリックされたとき
        private void button9_Click(object sender, EventArgs e)
        {
            Return re = new Return();
            re.Show();
        }

        //終了ボタンがクリックされたとき
        private void End_Button_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("終了しますか？", "確認", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

            //何が選択されたか調べる
            if (result == DialogResult.OK)
            {
                //次画面を非表示
                this.Visible = false;
            }
        }
 
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }   
    }
}
