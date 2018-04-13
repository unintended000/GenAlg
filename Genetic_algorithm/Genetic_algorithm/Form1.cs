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
            //Сделать норм форму
            //нормально присваивать гены
            //ну и полюбас еще что-нибудь вылезет
            int MaxPrice = (int) numericUpDown1.Value;
            int[] Weight = new int[dataGridView1.Rows.Count-1];
            int[] Price =  new int[dataGridView1.Rows.Count - 1];

            for (int i = 1; i <= 2; i++)
                for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
                {
                    if (i == 1)
                        Weight[j] =Convert.ToInt32(dataGridView1.Rows[j].Cells[i].Value);
                    else
                        Price[j] = Convert.ToInt32(dataGridView1.Rows[j].Cells[i].Value);
                }
                    

             
             cGenAlg eGenAlg = new cGenAlg((int)numericUpDown2.Value, (int)numericUpDown3.Value, Weight,Price,MaxPrice, (int)numericUpDown3.Value,(int)numericUpDown4.Value);

            
                for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
                {
                dataGridView1.Rows[j].Cells[3].Value = eGenAlg.ResultChild.Gene[j];
                }

        }

      
    }
}
