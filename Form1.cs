using System;
using System.Collections;
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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int randomNumber;
            Random r = new Random();
            while (dataGridView1.RowCount < 10)
            {
                dataGridView1.Rows.Add();
            }
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach(DataGridViewCell cell in row.Cells)
                {
                    randomNumber = r.Next(0, 9);
                    cell.Value = randomNumber;
                }
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            timer1.Start();
            timer1.Enabled = true;
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            int colIndex = dataGridView1.CurrentCell.ColumnIndex;
            IncrValueRaw(rowIndex);
            IncrValueCol(colIndex);
        }
        public void IncrValueRaw(int r)
        {
            Hashtable FibonacciList = new Hashtable();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Index == r)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {

                        cell.Value = Convert.ToInt32(cell.Value) + 1;
                        cell.Style.BackColor = Color.Yellow;
                        if (isFibonacci(Convert.ToInt32(cell.Value)) == true)
                        {
                            FibonacciList.Add(cell.ColumnIndex, cell.Value);
                        }
                        else
                        {
                            FibonacciList.Clear();
                        }
                    }
                }
            }
            if (FibonacciList.Count == 5)
            {
                foreach (object i in FibonacciList.Keys)
                {
                    dataGridView1[Convert.ToInt32(i), r].Style.BackColor = Color.LimeGreen;
                }
            }
        }
        public void IncrValueCol(int c)
        {
            for (int i=0;i<dataGridView1.RowCount;i++)
            {
                dataGridView1[c, i].Value = Convert.ToInt32(dataGridView1[c, i].Value) + 1;
                dataGridView1[c, i].Style.BackColor = Color.LightBlue;
            }
        }
        public bool isFibonacci(int x)
        {
            int first = 0;
            int second = 1;
            Boolean status = false;

            while (first <= x)
            {

                if (first == x)
                {
                    status = true;
                    break;
                }
                //This is next result
                second += first;

                first = second - first;

            }

            return status;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    cell.Style.BackColor = Color.White;
                }
            }
            timer1.Stop();
        }
    }
}
