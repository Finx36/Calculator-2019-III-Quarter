using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        double num1 = 0, num2 = 0, num3 = 0; //Для арифметических действий
        public bool equals, size; //Запрет двойного нажатия на кнопку и изменение размера
        char znak = '+'; //Для оператора выбора

        //запуск формы
        public Form1()
        {
            InitializeComponent();
            groupBox1.Enabled = false;
            panel1.Enabled = false;
            size = true;
        }

        //Кнопка =
        private void Button20_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Введите второе число");
            }
            else
            {
                if (equals == true)
                {
                    try
                    {
                        num2 = Convert.ToDouble(textBox1.Text);
                        switch (znak)
                        {
                            case ('+'):
                                num3 = num1 + num2;
                                break;
                            case ('-'):
                                num3 = num1 - num2;
                                break;
                            case ('*'):
                                num3 = num1 * num2;
                                break;
                            case ('/'):
                                if (num2 == 0)
                                {
                                    MessageBox.Show("Нельзя делить на ноль");
                                    textBox1.Text = "";
                                }
                                else
                                    num3 = num1 / num2;
                                break;
                            case ('^'):
                                num3 = Math.Pow(num1, num2);
                                break;
                        }

                        textBox1.Text = num3.ToString();
                    }
                    catch
                    {
                    }
                    equals = false;
                    button20.Enabled = false;
                }
            }
        }

        //+/-
        public void Button19_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.IndexOf("-") == -1)
                textBox1.Text = "-" + textBox1.Text;
            else
                textBox1.Text = textBox1.Text.Remove(0, 1);
        }


        //%
        private void Button17_Click(object sender, EventArgs e)
        {
            try
            {
              num2 = Convert.ToDouble(textBox1.Text);
              switch (znak)
              {
                case ('+'):
                  num3 = num1 + (num1 * num2 / 100);
                break;
                case ('-'):
                  num3 = num1 - (num1 * num2 / 100);
                break;
                case ('*'):
                  num3 = num1 * (num1 * num2 / 100);
                break;
                case ('/'):
                  num3 = num1 / (num1 * num2 / 100);
                break;
              }
              textBox1.Text = num3.ToString();
             } 
            catch
            {
            }
        }

        //Запятая
        public void Button10_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                textBox1.Text = "0,";
            if (textBox1.Text.IndexOf(",") == -1)
                if (textBox1.Text == "" || textBox1.Text == "-")
                    textBox1.Text += "0,";
                else
                    textBox1.Text += ',';
        }

        //Удаление символа
        private void Button18_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox1.Text != "0,")
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
        }

        //Кнопка C
        private void Button9_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            num1 = 0;
            num2 = 0;
            num3 = 0;
        }

        //Sin(x)
        private void Button23_Click(object sender, EventArgs e)
        {
           textBox1.Text = Convert.ToString(Math.Sin(Convert.ToDouble(textBox1.Text)));
        }

        //Cos(x)
        private void Button27_Click(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(Math.Cos(Convert.ToDouble(textBox1.Text)));
        }

        //Tn(x)
        private void Button28_Click(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(Math.Tan(Convert.ToDouble(textBox1.Text)));
        }

        //Ctg(x)
        private void Button24_Click(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(1/Math.Tan(Convert.ToDouble(textBox1.Text)));
        }

        //|X|
        private void Button30_Click(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(Math.Abs(Convert.ToDouble(textBox1.Text))); 
        }

        //Ln(x)
        private void Button29_Click(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(Math.Log(Convert.ToDouble(textBox1.Text)));
        }

        //Exp(x)
        private void Button25_Click(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(Math.Exp(Convert.ToDouble(textBox1.Text)));
        }

        //Sqrt(x)
        private void Button31_Click(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(Math.Sqrt(Convert.ToDouble(textBox1.Text)));
        }

        //X^2
        private void Button26_Click(object sender, EventArgs e)
        {
            num1 = Convert.ToDouble(textBox1.Text);
            textBox1.Text = Convert.ToString(num1 * num1);
        }

        //1/N
        private void Button32_Click(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(1/Convert.ToDouble(textBox1.Text));
        }

        //Расчет факториала
        private double Factorial(double b)
        {
            int res = 1;
            for (int a = 1; a <= b; a++)
            {
                res *= a;
            }
            return res;
        }

        //Кнопка N!
        private void Button35_Click(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(Factorial(Convert.ToDouble(textBox1.Text)));
        }

        //Запрет использования алгоритмических функция до ввода значений
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Select(textBox1.Text.Length, 0);

            if (size == true)
                textBox1.MaxLength = 25;
            else
                textBox1.MaxLength = 57;

            if (textBox1.Text == "" || textBox1.Text == "-" || textBox1.Text == "0,")
            {
                groupBox1.Enabled = false;
                panel1.Enabled = false;
            }
            else
            {
                groupBox1.Enabled = true;
                panel1.Enabled = true;
            }
        }

        //Кнопка скрытия/раскрытия доп функций
        private void Button22_Click(object sender, EventArgs e)
        {
            if (size == true)
            {
                button22.Text = "←";
                size = false;
                timer1.Enabled = true;
            }
            else
            {
                button22.Text = "→";
                size = true;
                timer1.Enabled = true;
            }
        }

        //Анимация скрытия/раскрытия доп функций
        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (button22.Text == "←")
            {
                ActiveForm.Width += 10;
                textBox1.Width = 705;
                if (ActiveForm.Width >= 740)
                {
                    timer1.Enabled = false;
                }
            }
            else
            {
                ActiveForm.Width -= 10;
                textBox1.Width = 405;
                if (ActiveForm.Width <= 450)
                {
                    timer1.Enabled = false;
                }
            }
        } 

        //Ограничения для введения символов
        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44 && number !=45)
            {
                textBox1.Focus();
                e.Handled = true;
            }

            if (e.KeyChar == 44)
                Button10_Click(sender, e);

            if (e.KeyChar == 48)
            {
                if ((textBox1.TextLength == 1) && (textBox1.Text == "0"))
                    textBox1.Text = "";
            }

            if (!(Char.IsDigit(e.KeyChar)) && !((e.KeyChar == ',') && (textBox1.Text.IndexOf(",") == -1) && (textBox1.Text.Length != 0)))
            {
                if (e.KeyChar != (char)Keys.Back)
                {
                    textBox1.Focus();
                    e.Handled = true;
                }
            }

        }

        //Ввод чисел
        private void Button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.TextLength == 1) && (textBox1.Text == "0"))
                textBox1.Text = "";
            textBox1.Text += (sender as Button).Text;
        }

        //Кнопки ариметических функций
        private void Button16_Click(object sender, EventArgs e)
        {
            try
            {
                znak = (sender as Button).Text[0];
                if (textBox1.Text == "" || textBox1.Text == "-")
                {
                    if (znak == '-') Button19_Click(sender, e);
                }
               else
                {
                    switch (znak)
                    {
                        case ('+'):
                            button15.Focus();
                            break;
                        case ('-'):
                            button16.Focus();
                            break;
                        case ('*'):
                            button14.Focus();
                            break;
                        case ('/'):
                            button13.Focus();
                            break;
                        case ('^'):
                            button21.Focus();
                            break;
                    }
                    num1 = Convert.ToDouble(textBox1.Text);
                    textBox1.Clear();
                    equals = true;
                    button20.Enabled = true;
                }
            }
            catch
            {
            }
        }
    }
}
