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
            this.Enabled = false;
             
            int MaxPrice = (int) numericUpDown1.Value;
            int[] Weight = new int[dataGridView1.Rows.Count-1];
            int[] Price =  new int[dataGridView1.Rows.Count - 1];

            //Считываем данные
            for (int i = 1; i <= 2; i++)
                for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
                {
                    if (Convert.ToString(dataGridView1.Rows[j].Cells[i].Value).Equals(""))
                        dataGridView1.Rows[j].Cells[i].Value = 0;
                    if (i == 1)
                        Weight[j] =Convert.ToInt32(dataGridView1.Rows[j].Cells[i].Value);
                    else
                        Price[j] = Convert.ToInt32(dataGridView1.Rows[j].Cells[i].Value);
                }
                    

             //Запускаем алгоритм
             cGenAlg eGenAlg = new cGenAlg((int)numericUpDown2.Value, dataGridView1.Rows.Count - 1, Weight,Price,MaxPrice, (int)numericUpDown4.Value,(int)numericUpDown5.Value);

            //Вывод результатов
                for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
                {
                dataGridView1.Rows[j].Cells[3].Value = (eGenAlg.ResultChild.Gene[j])? "Покупаем" :  "Не покупаем";
                }

            label6.Text = "Важность: " + eGenAlg.ResultChild.Weight;
            label7.Text = "Общая стоимость: " + eGenAlg.ResultChild.Price;
            this.Enabled = true;

        }


        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

           if ((dataGridView1.CurrentCell.ColumnIndex == 1)|| (dataGridView1.CurrentCell.ColumnIndex == 2))
            {
                TextBox tb = (TextBox)e.Control;
                tb.KeyPress += new KeyPressEventHandler(tb_KeyPress);
                 
            }
            else
            {
                TextBox tb = (TextBox)e.Control;
                tb.KeyPress -= tb_KeyPress;
            }
        }

        void tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsNumber(e.KeyChar))
            {
                if ((e.KeyChar != (char)Keys.Back) || (e.KeyChar != (char)Keys.Delete))
                { e.Handled = true; }
            }

        }
       

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if ((e.ColumnIndex == 1)&&(e.FormattedValue.ToString()!=""))
            {
                
                if ((Convert.ToInt32(e.FormattedValue) > 10) || (Convert.ToInt32(e.FormattedValue) < 0))
                {
                    dataGridView1.Rows[e.RowIndex].Cells[1].Value = 0;
                    MessageBox.Show("Невеные данные! Оцените важность покупки по шкале от 0 до 10.");
                }
            }
        }
    }
}
