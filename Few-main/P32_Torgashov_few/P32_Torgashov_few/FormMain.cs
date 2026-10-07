using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace P32_Torgashov_few
{
    public partial class FormMain : Form
    {
        private double[] input;
        public FormMain()
        {
            InitializeComponent();


            input = new double[15];


        }

        private void change_color(object sender, EventArgs e)
        {
            if (((Button)sender).BackColor == Color.White)
            {
                ((Button)sender).BackColor = Color.Black;
                input[((Button)sender).TabIndex] = 1d;
            }
            else
            {
                ((Button)sender).BackColor = Color.White;
                input[((Button)sender).TabIndex] = 0d;
            }
        }
        private void train_button(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "train.txt";
            string tempStr = button_output.Value.ToString();

            for (int i = 0; i < input.Length; i++)
            {
                tempStr += " " + input[i].ToString();
            }
            tempStr += "\n";

            File.AppendAllText(path, tempStr);
        }
        private void learn_button(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "learn.txt";
            string tempStr = button_output.Value.ToString();

            for (int i = 0; i < input.Length; i++)
            {
                tempStr += " " + input[i].ToString();
            }
            tempStr += "\n";

            File.AppendAllText(path, tempStr);
        }


    }
}
