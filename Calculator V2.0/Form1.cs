using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator_V2._0
{
    public partial class Form1 : Form
    {
        double resultS = 0;
        double resultE = 0;

        string operationS = "";
        string operationE = "";

        bool isOperationS = false;
        bool isOperationE = false;

        const int POIN_X = 12;
        const int POIN_Y = 27;
        const int WIDTH_STANDART = 380;
        const int WIDTH_ENGINEER = 795;
        const int HEIGHT = 490;

        const int MAX_FACTORIAL = 170;

        public Form1()
        {
           InitializeComponent();

            this.Width = WIDTH_STANDART;
            this.Height = HEIGHT;
            groupBox1.Visible = false;
            groupBoxEngineering.Visible = false;
            screenStandart.Text = "0";
            screenEngeneer.Text = "0";
        }

        private void Standart_Click(object sender, EventArgs e) //s windowStandart
        {
            this.Width = WIDTH_STANDART;
            this.Height = HEIGHT;
   
            groupBoxStandart.Location = new Point(POIN_X, POIN_Y);
            groupBoxStandart.Visible = true;
            groupBoxEngineering.Visible = false;
            groupBox1.Visible = false;
        }

        private void buttonClick(object sender, EventArgs e)    //s
        {
            if ((screenStandart.Text == "0") || (isOperationS))
            {
                screenStandart.Text = "";
            }
           
            isOperationS = false;

            Button num = (Button)sender;

            if (num.Text == ",")
            {
                if ((screenStandart.Text == "") && (!screenStandart.Text.Contains(",")))
                {
                    screenStandart.Text += "0,";
                }

                if (!screenStandart.Text.Contains(",") )
                {
                    screenStandart.Text = screenStandart.Text + num.Text;
                }
            }
            else
            {
                screenStandart.Text += num.Text;
            }
        }

        private void Button2_Click(object sender, EventArgs e) //s CE
        {
            screenStandart.Text = "0";
            isOperationS = true;
        }

        private void Button3_Click(object sender, EventArgs e)//s C
        {
            screenStandart.Text = "0";
            labelShowOperation.Text = "";
            resultS = 0;
            isOperationS = false;
        }

        private void Button1_Click(object sender, EventArgs e) //s <-
        {
            if (screenStandart.Text.Length > 0)
            {
                screenStandart.Text = screenStandart.Text.Remove(screenStandart.Text.Length - 1, 1);
            }

            if (screenStandart.Text == "")
            {
                screenStandart.Text = "0";
            }
        }

        private void ArithmeticOperator(object sender, EventArgs e) //s ArithmeticOperator
        {
            Button num = (Button)sender;

            if ((screenStandart.Text !="") && (screenStandart.Text != "Err"))
            {
                if (resultS != 0)
                {
                    button15.PerformClick();
                    operationS = num.Text;
                    
                    isOperationS = double.TryParse(screenStandart.Text, out resultS); 
                    labelShowOperation.Text = resultS + " " + operationS;
                    screenStandart.Text = "0";
                }
                else if ( (operationS == "*") && (operationS == "/"))
                {
                    operationS = num.Text;
                    isOperationS = double.TryParse(screenStandart.Text, out resultS);
                    labelShowOperation.Text = resultS + " " + operationS;

                    screenStandart.Text = "";
                }
                else
                {
                    operationS = num.Text;
                    isOperationS = double.TryParse(screenStandart.Text, out resultS);
                    labelShowOperation.Text = resultS + " " + operationS;

                    screenStandart.Text = "0";
                }
            }
            else
            {
                isOperationS = false;
                operationS = "";
            }
 
        }

        private void Button15_Click(object sender, EventArgs e) //s =
        {
            labelShowOperation.Text = "";
            switch (operationS)
            {
                case "+":
                    screenStandart.Text = (resultS + double.Parse(screenStandart.Text)).ToString();
                break;

                case "-":
                    screenStandart.Text = (resultS - double.Parse(screenStandart.Text)).ToString();
                    break;

                case "*":
                    screenStandart.Text = (resultS * double.Parse(screenStandart.Text)).ToString();
                    break;

                case "/":
                    screenStandart.Text = (resultS / double.Parse(screenStandart.Text)).ToString();
                    break;
            }

            resultS = double.Parse(screenStandart.Text);
            operationS = "";
        }

        private void Button4_Click(object sender, EventArgs e) // s  +/-
        {
            if (screenStandart.Text != "")
            {
                if (screenStandart.Text[0] == '-')
                {
                    screenStandart.Text = screenStandart.Text.Remove(0, 1);
                }
                else
                {
                    screenStandart.Text = '-' + screenStandart.Text;
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void ClickHereToolStripMenuItem_Click(object sender, EventArgs e) // О программе 
        {
            this.Width = WIDTH_STANDART;
            this.Height = HEIGHT;
            groupBox1.Location = new Point(POIN_X, POIN_Y);

            groupBox1.Visible = true;
            groupBoxStandart.Visible = false;
            groupBoxEngineering.Visible = false;
        }

        private void Button66_Click(object sender, EventArgs e)
        {
            FileStream file = new FileStream(@"C:\Users\Vitaliy\Desktop\ReviewsAndComment.txt", FileMode.Create); //создаем файловый поток
            StreamWriter writerPasswordEncrypt = new StreamWriter(file); //создаем «потоковый писатель» и связываем его с файловым потоком
            writerPasswordEncrypt.Write($"{textBox1.Text}"); //записываем в файл
            writerPasswordEncrypt.Close();

            textBox1.Clear();
            textBox1.Text = "Спасибо за ваш отзыв (:";
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void engineeringClick(object sender, EventArgs e) //e Windows Enginer
        {
            this.Width = WIDTH_ENGINEER;
            this.Height = HEIGHT;
            groupBoxEngineering.Location = new Point(POIN_X, POIN_Y);
            groupBoxEngineering.Visible = true;
            groupBoxStandart.Visible = false;
            groupBox1.Visible = false;
        }

        private void Button27_Click(object sender, EventArgs e)// E +-
        {
            if (screenEngeneer.Text != "")
            {
                if (screenEngeneer.Text[0] == '-')
                {
                    screenEngeneer.Text = screenEngeneer.Text.Remove(0, 1);
                }
                else
                {
                    screenEngeneer.Text = '-' + screenEngeneer.Text;
                }
            }
        }

        private void Button34_Click(object sender, EventArgs e) // e C
        {
            screenEngeneer.Text = "0";
            label2ShowOperation.Text = "";
            resultE = 0;
            isOperationE = false;
        }

        private void Button35_Click(object sender, EventArgs e) // e CE
        {
            screenEngeneer.Text = "0";
            isOperationE = true;
        }

        private void ButtonClickE(object sender, EventArgs e)
        {
            if ((screenEngeneer.Text == "0") || (isOperationE))
            {
                screenEngeneer.Text = "";
            }

            isOperationE = false;

            Button num = (Button)sender;

            if (num.Text == ",")
            {
                if ((screenEngeneer.Text == "") && (!screenEngeneer.Text.Contains(",")))
                {
                    screenEngeneer.Text += "0,";
                }

                if (!screenEngeneer.Text.Contains(","))
                {
                    screenEngeneer.Text +=  num.Text;
                }
            }
            else
            {
                screenEngeneer.Text += num.Text;
            }
        }

        private void Button26_Click(object sender, EventArgs e) // e <-
        {
            if (screenEngeneer.Text.Length > 0)
            {
                screenEngeneer.Text = screenEngeneer.Text.Remove(screenStandart.Text.Length - 1, 1);
            }

            if (screenEngeneer.Text == "")
            {
                screenEngeneer.Text = "0";
            }
        }

        private void Button41_Click(object sender, EventArgs e) //e π(Pi)
        {
            if ((screenEngeneer.Text == "0") && (screenEngeneer.Text != ""))
            {
                if (screenEngeneer.Text.Contains(","))
                {
                    screenEngeneer.Text = "";
                }
                else
                {
                    screenEngeneer.Text = screenEngeneer.Text.Remove(0, 1);
                    screenEngeneer.Text += Math.PI;
                }
            }
        }

        private void Button64_Click(object sender, EventArgs e)
        {
            if ((screenEngeneer.Text == "0") && (screenEngeneer.Text != "") )
            {
                if (screenEngeneer.Text.Contains(","))
                {
                    screenEngeneer.Text = "";
                }
                else
                {
                    screenEngeneer.Text = screenEngeneer.Text.Remove(0, 1);
                    screenEngeneer.Text += Math.E;
                }
            }
        }

        private void EngOperation(object sender, EventArgs e) //e Operation
        {
            Button num = (Button)sender;

            if ((screenEngeneer.Text != "") && (screenEngeneer.Text != "Err"))
            {
                if (resultE != 0)
                {
                    button36.PerformClick();
                    operationE = num.Text;

                    isOperationE = double.TryParse(screenEngeneer.Text, out resultE);
                    label2ShowOperation.Text = resultE + " " + operationE;
                    screenEngeneer.Text = "0";
                }
                else if ((operationS == "×") && (operationS == "÷"))
                {
                    operationS = num.Text;
                    isOperationS = double.TryParse(screenStandart.Text, out resultS);
                    labelShowOperation.Text = resultS + " " + operationS;

                    screenStandart.Text = "";
                }
                else
                {
                    operationE = num.Text;
                    isOperationE = double.TryParse(screenEngeneer.Text, out resultE);
                    label2ShowOperation.Text = resultE + " " + operationE;

                    screenEngeneer.Text = "0";
                }
            }
            else
            {
                isOperationE = false;
                operationE = "";
            }
        }

        private void Button36_Click(object sender, EventArgs e) // e =
        {
            label2ShowOperation.Text = "";
            switch (operationE)
            {
                case "+":
                    screenEngeneer.Text = (resultE + double.Parse(screenEngeneer.Text)).ToString();
                    break;

                case "-":
                    screenEngeneer.Text = (resultE - double.Parse(screenEngeneer.Text)).ToString();
                    break;

                case "×":
                    screenEngeneer.Text = (resultE * double.Parse(screenEngeneer.Text)).ToString();
                    break;

                case "÷":
                    screenEngeneer.Text = (resultE / double.Parse(screenEngeneer.Text)).ToString();
                    break;

                case "^":
                    screenEngeneer.Text = Convert.ToString(Math.Pow(resultE, double.Parse(screenEngeneer.Text)));
                    break;

                case "²":
                    screenEngeneer.Text = Convert.ToString(Math.Pow(resultE, 2));
                    break;

                case "√":
                    screenEngeneer.Text = Convert.ToString(Math.Sqrt(resultE));
                    break;

                case "Exp":
                    screenEngeneer.Text = Convert.ToString(Math.Exp(resultE));
                    break;
            }

            resultE = double.Parse(screenEngeneer.Text);
            operationE = "";
        }

        private void Button65_Click(object sender, EventArgs e) //e 1/x
        {
            resultE = double.Parse(screenEngeneer.Text);
            label2ShowOperation.Text = "1/ (" + resultE + ")";
            screenEngeneer.Text = Convert.ToString((double)(1 / resultE));
        }

        private void Button42_Click(object sender, EventArgs e) //e Factorial
        {
            resultE = double.Parse(screenEngeneer.Text);
            label2ShowOperation.Text = resultE + "  !";

            button36.PerformClick();                            //СДЕЛАТЬ КЛИК на '='  !!!!!

            double result =  GetFactorial(resultE);

            if (result > 0)
            {
                screenEngeneer.Text = Convert.ToString(result);

            }
            else
            {
                screenEngeneer.Text = "Выход за предели диапазона!";
            } 
        }

        static double GetFactorial(double number)   // Factorial
        {
            if (number >= 0 && number <= MAX_FACTORIAL)
            {
                if (number == 1 || number == 0)
                {
                    return 1;
                }
                else
                {
                    return number * GetFactorial(number - 1);
                }
            }
            else
            {
                return -1;
            }
        }

        private void Button53_Click(object sender, EventArgs e) //e log
        {
            resultE = double.Parse(screenEngeneer.Text);
            label2ShowOperation.Text = "log (" + resultE + ")";
            screenEngeneer.Text = Convert.ToString(Math.Log10(resultE));
        }

        private void Button49_Click(object sender, EventArgs e) //e ln
        {
            resultE = double.Parse(screenEngeneer.Text);
            label2ShowOperation.Text = "ln (" + resultE + ")";
            screenEngeneer.Text = Convert.ToString(Math.Log(resultE));
        }

        private void Button46_Click(object sender, EventArgs e) //e exp
        {
            resultE = double.Parse(screenEngeneer.Text);
            label2ShowOperation.Text = "Exp (" + resultE + ")";
            screenEngeneer.Text = Convert.ToString(Math.Exp(resultE));
        }

        private void Button54_Click(object sender, EventArgs e) //e Acos  ( in (-1 -- 1) out (0 -- pi) )
        {
            resultE = double.Parse(screenEngeneer.Text);
            label2ShowOperation.Text = "Acos (" + resultE + ")";
            screenEngeneer.Text = Convert.ToString(Math.Acos(resultE));
        }

        private void Button50_Click(object sender, EventArgs e) //e cos
        {
            resultE = double.Parse(screenEngeneer.Text);
            label2ShowOperation.Text = "cos (" + resultE + ")";
            screenEngeneer.Text = Convert.ToString(Math.Cos(resultE));
        }

        private void Button55_Click(object sender, EventArgs e) //e cosh
        {
            resultE = double.Parse(screenEngeneer.Text);
            label2ShowOperation.Text = "cosh (" + resultE + ")";
            screenEngeneer.Text = Convert.ToString(Math.Cosh(resultE));

        }

        private void Button56_Click(object sender, EventArgs e) //e Asin
        {
            resultE = double.Parse(screenEngeneer.Text);
            label2ShowOperation.Text = "Asin (" + resultE + ")";
            screenEngeneer.Text = Convert.ToString(Math.Asin(resultE));
        }

        private void Button51_Click(object sender, EventArgs e) //e sin
        {
            resultE = double.Parse(screenEngeneer.Text);
            label2ShowOperation.Text = "sin (" + resultE + ")";
            screenEngeneer.Text = Convert.ToString(Math.Sin(resultE));
        }

        private void Button57_Click(object sender, EventArgs e) //e sinh
        {
            resultE = double.Parse(screenEngeneer.Text);
            label2ShowOperation.Text = "sinh (" + resultE + ")";
            screenEngeneer.Text = Convert.ToString(Math.Sinh(resultE));
        }

        private void Button58_Click(object sender, EventArgs e) //e Atan
        {
            resultE = double.Parse(screenEngeneer.Text);
            label2ShowOperation.Text = "Atan (" + resultE + ")";
            screenEngeneer.Text = Convert.ToString(Math.Atan(resultE));
        }

        private void Button52_Click(object sender, EventArgs e) //e tan
        {
            resultE = double.Parse(screenEngeneer.Text);
            label2ShowOperation.Text = "tan (" + resultE + ")";
            screenEngeneer.Text = Convert.ToString(Math.Tan(resultE));
        }

        private void Button59_Click(object sender, EventArgs e) //e  tanh
        {
            resultE = double.Parse(screenEngeneer.Text);
            label2ShowOperation.Text = "tanh (" + resultE + ")";
            screenEngeneer.Text = Convert.ToString(Math.Tanh(resultE));
        }

        private void Button60_Click(object sender, EventArgs e) //e hex
        {
            int i = int.Parse(screenEngeneer.Text);
            screenEngeneer.Text = Convert.ToString(i,16); 
        }

        private void Button61_Click(object sender, EventArgs e) //e dex
        {
            int i = int.Parse(screenEngeneer.Text);
            screenEngeneer.Text = Convert.ToString(i, 10);
        }

        private void Button62_Click(object sender, EventArgs e) //e oct
        {
            int i = int.Parse(screenEngeneer.Text);
            screenEngeneer.Text = Convert.ToString(i, 8);
        }

        private void Button63_Click(object sender, EventArgs e) //e bin
        {
            int i = int.Parse(screenEngeneer.Text);
            screenEngeneer.Text = Convert.ToString(i, 2);
        }

        



    }





}
