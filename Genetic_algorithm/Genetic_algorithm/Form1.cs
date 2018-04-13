using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GenAldLibrary;



namespace Genetic_algorithm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int MaxPrice = (int) numericUpDown1.Value;

             int[] Weight = { 1,1, 2, 3, 4,5,6,7,8,9 };
             int[] Price = { 1, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
             cGenAlg eGenAlg = new cGenAlg((int)numericUpDown2.Value, (int)numericUpDown3.Value, Weight,Price,MaxPrice, (int)numericUpDown3.Value);
        }
    }
}
