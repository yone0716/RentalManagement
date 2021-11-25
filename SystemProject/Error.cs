using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace SystemProject
{
    
    class Error
    {
        public void IsNullOrEmpty(string BUPNNM, string BUPNLCAT1, ErrorProvider errorProvider, string err_msg, TextBox textBox2, TextBox textBox3, TextBox textBox5,ComboBox comboBox1,ComboBox comboBox2)
        {
            if (string.IsNullOrEmpty(BUPNNM))
            {
                err_msg = "物品名称を入力して下さい。";
                errorProvider.SetError(textBox2, err_msg);
                textBox3.ForeColor = Color.Red;
                textBox3.Text = "必須項目を入力して下さい。";
            }

            if (string.IsNullOrEmpty(BUPNLCAT1))
            {
                err_msg = "基本保管場所を入力して下さい。";
                errorProvider.SetError(textBox5, err_msg);
                textBox3.ForeColor = Color.Red;
                textBox3.Text = "必須項目を入力して下さい。";
            }

            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                err_msg = "物品種別を入力して下さい。";
                errorProvider.SetError(comboBox1, err_msg);
                textBox3.ForeColor = Color.Red;
                textBox3.Text = "必須項目を入力して下さい。";
            }

            if (string.IsNullOrEmpty(comboBox2.Text))
            {
                err_msg = "分類コードを入力して下さい。";
                errorProvider.SetError(comboBox2, err_msg);
                textBox3.ForeColor = Color.Red;
                textBox3.Text = "必須項目を入力して下さい。";
            }

            /*if (string.IsNullOrEmpty(BUPNNM) && string.IsNullOrEmpty(BUPNLCAT1))
            //{
            //    textBox3.ForeColor = Color.Red;
            //    textBox3.Text = "物品名称と基本保管場所を入力して下さい。";
            //}

            //if (string.IsNullOrEmpty(BUPNNM) && string.IsNullOrEmpty(comboBox1.Text))
            //{
            //    textBox3.ForeColor = Color.Red;
            //    textBox3.Text = "物品名称と物品種別を入力して下さい。";
            //}

            //if (string.IsNullOrEmpty(BUPNNM) && string.IsNullOrEmpty(comboBox2.Text))
            //{
            //    textBox3.ForeColor = Color.Red;
            //    textBox3.Text = "物品名称と分類コードを入力して下さい。";
            //}

            //if (string.IsNullOrEmpty(BUPNLCAT1) && string.IsNullOrEmpty(comboBox1.Text))
            //{
            //    textBox3.ForeColor = Color.Red;
            //    textBox3.Text = "基本保管場所と物品種別を入力して下さい。";
            //}

            //if (string.IsNullOrEmpty(BUPNLCAT1) && string.IsNullOrEmpty(comboBox2.Text))
            //{
            //    textBox3.ForeColor = Color.Red;
            //    textBox3.Text = "基本保管場所と分類コードを入力して下さい。";
            //}

            //if (string.IsNullOrEmpty(comboBox1.Text) && string.IsNullOrEmpty(comboBox2.Text))
            //{
            //    textBox3.ForeColor = Color.Red;
            //    textBox3.Text = "物品種別と分類コードを入力して下さい。";
            //}

            //if (string.IsNullOrEmpty(BUPNNM) && string.IsNullOrEmpty(BUPNLCAT1)&& string.IsNullOrEmpty(comboBox1.Text))
            //{
            //    textBox3.ForeColor = Color.Red;
            //    textBox3.Text = "物品名称と物品種別と基本保管場所を入力して下さい。";
            //}

            //if (string.IsNullOrEmpty(BUPNNM) && string.IsNullOrEmpty(BUPNLCAT1) && string.IsNullOrEmpty(comboBox2.Text))
            //{
            //    textBox3.ForeColor = Color.Red;
            //    textBox3.Text = "物品名称と分類コードと基本保管場所を入力して下さい。";
            //}

            //if (string.IsNullOrEmpty(BUPNNM) && string.IsNullOrEmpty(comboBox1.Text) && string.IsNullOrEmpty(comboBox2.Text))
            //{
            //    textBox3.ForeColor = Color.Red;
            //    textBox3.Text = "物品名称と物品種別と分類コードを入力して下さい。";
            //}

            //if (string.IsNullOrEmpty(BUPNLCAT1) && string.IsNullOrEmpty(comboBox1.Text) && string.IsNullOrEmpty(comboBox2.Text))
            //{
            //    textBox3.ForeColor = Color.Red;
            //    textBox3.Text = "物品種別と分類コードと基本保管場所を入力して下さい。";
            //}*/

            //if (string.IsNullOrEmpty(BUPNNM) && string.IsNullOrEmpty(BUPNLCAT1) && string.IsNullOrEmpty(comboBox1.Text)&& string.IsNullOrEmpty(comboBox2.Text))
            //{
            //    textBox3.ForeColor = Color.Red;
            //    textBox3.Text = "必須項目を入力して下さい。";
            //}
        }

        public bool IsNullOrEmptyCheck(string BUPNNM, string BUPNLCAT1, ComboBox comboBox1, ComboBox comboBox2)
        {
            if (!string.IsNullOrEmpty(BUPNNM) && !string.IsNullOrEmpty(BUPNLCAT1)&&!string.IsNullOrEmpty(comboBox1.Text) && !string.IsNullOrEmpty(comboBox2.Text))
            {
                return true;
            }
            else
            {
                return false;
                
            }
        }

        public void IsnullOrEmptyInquiry(ErrorProvider errorProvider, string err_msg, TextBox textBox3, ComboBox comboBox1, ComboBox comboBox2, ComboBox comboBox3)
        {
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                err_msg = "物品種別を入力して下さい。";
                errorProvider.SetError(comboBox1, err_msg);
                textBox3.ForeColor = Color.Red;
                textBox3.Text = "必須項目を入力して下さい。";
            }

            if (string.IsNullOrEmpty(comboBox2.Text))
            {
                err_msg = "削除項目を入力して下さい。";
                errorProvider.SetError(comboBox2, err_msg);
                textBox3.ForeColor = Color.Red;
                textBox3.Text = "必須項目を入力して下さい。";
            }

            if (string.IsNullOrEmpty(comboBox3.Text))
            {
                err_msg = "貸出項目を入力して下さい。";
                errorProvider.SetError(comboBox3, err_msg);
                textBox3.ForeColor = Color.Red;
                textBox3.Text = "必須項目を入力して下さい。";
            }
        }
         
        public bool IsnullOrEmptyInquiryCheck(ComboBox comboBox1, ComboBox comboBox2, ComboBox comboBox3)
        {
            if (!string.IsNullOrEmpty(comboBox1.Text) && !string.IsNullOrEmpty(comboBox2.Text) && !string.IsNullOrEmpty(comboBox3.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void IsNullOrEmptyRegister(ErrorProvider errorProvider, string err_msg, ComboBox comboBox1, TextBox textBox2, TextBox textBox4, TextBox textBox5, TextBox textBox6, TextBox textBox14)
        {
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                err_msg = "物品種別を入力して下さい。";
                errorProvider.SetError(comboBox1, err_msg);
                textBox14.ForeColor = Color.Red;
                textBox14.Text = "必須項目を入力して下さい。";
            }

            if (string.IsNullOrEmpty(textBox2.Text))
            {
                err_msg = "借受者名を入力して下さい。";
                errorProvider.SetError(textBox2, err_msg);
                textBox14.ForeColor = Color.Red;
                textBox14.Text = "必須項目を入力して下さい。";
            }
            
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                err_msg = "物品コードを入力して下さい。";
                errorProvider.SetError(textBox4, err_msg);
                textBox14.ForeColor = Color.Red;
                textBox14.Text = "必須項目を入力して下さい。";
            }

            if (string.IsNullOrEmpty(textBox5.Text))
            {
                err_msg = "返却予定日を入力して下さい。";
                errorProvider.SetError(textBox5, err_msg);
                textBox14.ForeColor = Color.Red;
                textBox14.Text = "必須項目を入力して下さい。";
            }

            if (string.IsNullOrEmpty(textBox6.Text))
            {
                err_msg = "保管場所を入力して下さい。";
                errorProvider.SetError(textBox6, err_msg);
                textBox14.ForeColor = Color.Red;
                textBox14.Text = "必須項目を入力して下さい。";
            }

        }

        public bool IsNullOrEmptyRegisterCheck(ComboBox comboBox1, TextBox textBox2, TextBox textBox4, TextBox textBox5, TextBox textBox6)
        {
            if (!string.IsNullOrEmpty(comboBox1.Text)&&!string.IsNullOrEmpty(textBox2.Text)&&!string.IsNullOrEmpty(textBox4.Text)&&!string.IsNullOrEmpty(textBox5.Text)&&!string.IsNullOrEmpty(textBox6.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void IsNullOrEmptyForm4Update(ErrorProvider errorProvider, string err_msg, TextBox textBox14 ,ComboBox comboBox1, TextBox textBox2, TextBox textBox3,TextBox textBox4, TextBox textBox5, TextBox textBox6,  TextBox textBox12)
        {
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                err_msg = "物品種別を入力して下さい。";
                errorProvider.SetError(comboBox1, err_msg);
                textBox14.ForeColor = Color.Red;
                textBox14.Text = "必須項目を入力して下さい。";
            }

            if (string.IsNullOrEmpty(textBox2.Text))
            {
                err_msg = "借受者名を入力して下さい。";
                errorProvider.SetError(textBox2, err_msg);
                textBox14.ForeColor = Color.Red;
                textBox14.Text = "必須項目を入力して下さい。";
            }

            if (string.IsNullOrEmpty(textBox3.Text))
            {
                err_msg = "利用者名を入力して下さい。";
                errorProvider.SetError(textBox3, err_msg);
                textBox14.ForeColor = Color.Red;
                textBox14.Text = "必須項目を入力して下さい。";
            }

            if (string.IsNullOrEmpty(textBox4.Text))
            {
                err_msg = "物品コードを入力して下さい。";
                errorProvider.SetError(textBox4, err_msg);
                textBox14.ForeColor = Color.Red;
                textBox14.Text = "必須項目を入力して下さい。";
            }

            if (string.IsNullOrEmpty(textBox5.Text))
            {
                err_msg = "返却予定日を入力して下さい。";
                errorProvider.SetError(textBox5, err_msg);
                textBox14.ForeColor = Color.Red;
                textBox14.Text = "必須項目を入力して下さい。";
            }

            if (string.IsNullOrEmpty(textBox6.Text))
            {
                err_msg = "保管場所を入力して下さい。";
                errorProvider.SetError(textBox6, err_msg);
                textBox14.ForeColor = Color.Red;
                textBox14.Text = "必須項目を入力して下さい。";
            }

            //if (string.IsNullOrEmpty(textBox7.Text))
            //{
            //    err_msg = "保管場所を入力して下さい。";
            //    errorProvider.SetError(textBox7, err_msg);
            //    textBox14.ForeColor = Color.Red;
            //    textBox14.Text = "必須項目を入力して下さい。";
            //}

            //if (string.IsNullOrEmpty(textBox8.Text))
            //{
            //    err_msg = "返却者を入力して下さい。";
            //    errorProvider.SetError(textBox8, err_msg);
            //    textBox14.ForeColor = Color.Red;
            //    textBox14.Text = "必須項目を入力して下さい。";
            //}

            //if (string.IsNullOrEmpty(textBox9.Text))
            //{
            //    err_msg = "返却日を入力して下さい。";
            //    errorProvider.SetError(textBox9, err_msg);
            //    textBox14.ForeColor = Color.Red;
            //    textBox14.Text = "必須項目を入力して下さい。";
            //}

            if (string.IsNullOrEmpty(textBox12.Text))
            {
                err_msg = "貸出日を入力して下さい。";
                errorProvider.SetError(textBox12, err_msg);
                textBox14.ForeColor = Color.Red;
                textBox14.Text = "必須項目を入力して下さい。";
            }
        }

        public bool IsNullOrEmptyForm4UpdateCheck(ComboBox comboBox1, TextBox textBox2, TextBox textBox3, TextBox textBox4, TextBox textBox5, TextBox textBox6,  TextBox textBox12)
        {
            if (!string.IsNullOrEmpty(comboBox1.Text) && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrEmpty(textBox6.Text)&& !string.IsNullOrEmpty(textBox12.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void IsnullOrEmptyForm5Inquiry(ErrorProvider errorProvider, string err_msg, TextBox textBox3, ComboBox comboBox1, TextBox textBox1, TextBox textBox2, ComboBox comboBox2)
        {
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                err_msg = "物品種別を入力して下さい。";
                errorProvider.SetError(comboBox1, err_msg);
                textBox3.ForeColor = Color.Red;
                textBox3.Text = "必須項目を入力して下さい。";
            }

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                err_msg = "貸出日時を入力して下さい。";
                errorProvider.SetError(textBox1, err_msg);
                textBox3.ForeColor = Color.Red;
                textBox3.Text = "必須項目を入力して下さい。";
            }

            if (string.IsNullOrEmpty(textBox2.Text))
            {
                err_msg = "貸出日時を入力して下さい。";
                errorProvider.SetError(textBox2, err_msg);
                textBox3.ForeColor = Color.Red;
                textBox3.Text = "必須項目を入力して下さい。";
            }
            if (string.IsNullOrEmpty(comboBox2.Text))
            {
                err_msg = "分類コードを入力して下さい。";
                errorProvider.SetError(comboBox2, err_msg);
                textBox3.ForeColor = Color.Red;
                textBox3.Text = "必須項目を入力して下さい。";
            }
        }

        public bool IsNullOrEmptyForm5InquiryCheck(ComboBox comboBox1, TextBox textBox1,TextBox textBox2,ComboBox comboBox2)
        {
            if (!string.IsNullOrEmpty(comboBox1.Text) && !string.IsNullOrEmpty(textBox1.Text)&&!string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrEmpty(comboBox1.Text) && !string.IsNullOrEmpty(comboBox2.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void IsNullOrEmptyForm6Inquiry(ErrorProvider errorProvider, string err_msg, TextBox textBox3, TextBox textBox1, TextBox textBox2)
        {
            if (string.IsNullOrEmpty(textBox1.Text)&&string.IsNullOrEmpty(textBox2.Text))
            {
                err_msg = "日付を入力して下さい。";
                errorProvider.SetError(textBox1, err_msg);
                errorProvider.SetError(textBox2, err_msg);
                textBox3.ForeColor = Color.Red;
                textBox3.Text = "必須項目を入力して下さい。";
            }
        }

        public bool IsNullOrEmptyForm6InquiryCheck(TextBox textBox1, TextBox textBox2)
        {
            if (string.IsNullOrEmpty(textBox1.Text)&&string.IsNullOrEmpty(textBox2.Text))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void RentError(ErrorProvider errorProvider, string err_msg, TextBox textBox4, TextBox textBox14)
        {

            err_msg = "この物品コードは使用できません";
            errorProvider.SetError(textBox4, err_msg);
            textBox14.ForeColor = Color.Red;
            textBox14.Text = "この物品コードは使用できません";
        }

        public void IsNullOrEmptyReturn(ErrorProvider errorProvider, string err_msg, TextBox textBox7, TextBox textBox8, TextBox textBox9, TextBox textBox14)
        {
            if (string.IsNullOrEmpty(textBox7.Text))
            {
                err_msg = "返却日を入力して下さい。";
                errorProvider.SetError(textBox7, err_msg);
                textBox14.ForeColor = Color.Red;
                textBox14.Text = "必須項目を入力して下さい。";
            }

            if (string.IsNullOrEmpty(textBox8.Text))
            {
                err_msg = "返却者名を入力して下さい。";
                errorProvider.SetError(textBox8, err_msg);
                textBox14.ForeColor = Color.Red;
                textBox14.Text = "必須項目を入力して下さい。";
            }

            if (string.IsNullOrEmpty(textBox9.Text))
            {
                err_msg = "保管場所を入力して下さい。";
                errorProvider.SetError(textBox9, err_msg);
                textBox14.ForeColor = Color.Red;
                textBox14.Text = "必須項目を入力して下さい。";
            }

        }

        public bool IsNullOrEmptyReturnCheck(TextBox textBox7, TextBox textBox8, TextBox textBox9)
        {
            if (!string.IsNullOrEmpty(textBox7.Text) && !string.IsNullOrEmpty(textBox8.Text) && !string.IsNullOrEmpty(textBox9.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
