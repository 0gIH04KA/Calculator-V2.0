using System;
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
    public partial class Form2 : Form
    {
        const int WIDTH = 300;
        const int HEIGHT = 250;



        public Form2()
        {
            InitializeComponent();

            this.Width = WIDTH;
            this.Height = HEIGHT;

            string str = "Спасибо за ваш отзыв (:";
            labelForm2.Text = str;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
