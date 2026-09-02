using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace P32_Torgashov_few
{
    public partial class Form1 : Form
    {
        double[] input;
        public Form1()
        {
            InitializeComponent();
        }

        private void change_color(object sender, EventArgs e)
        {
            if (((Button)sender).BackColor == Color.White)
            {
                ((Button)sender).BackColor = Color.Black;
            }
            else
            {
                ((Button)sender).BackColor = Color.White;
            }
        }

        
    }
}
