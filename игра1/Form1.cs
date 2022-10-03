using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace игра1
{
    public partial class Form1 : Form
    {
        public static int n;
        const int MaxN = 10;
        public static Button[,] Matr1 = new Button[MaxN, MaxN];
        public Form1()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            textBox1.Text = " ";
        }

        public void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") return;
            n = int.Parse(textBox1.Text);
            int celNr = 1;
            Controls.Clear();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Random res = new Random();
                    String randomstring = "";
                    int x = res.Next(0, 1000);
                    if (x < 500)
                        randomstring = "|";
                    else
                        randomstring = "-";
                    Matr1[i, j] = new Button()
                    {
                        Width = 100,
                        Height = 100,
                        Text = randomstring,
                        Location = new Point(i * 100 + 10, j * 100 + 10),
                    };
                    this.Controls.Add(Matr1[i, j]);
                    Matr1[i, j].Tag = celNr++;
                    Matr1[i, j].Click += MatrixButtonClick;
                }
                
            }
        }
        public void MatrixButtonClick(object sender, EventArgs e)
        {
            int i, j;
            Button b = (Button)sender;
            i = ((int)b.Tag-1) / n;//столбец
            j = ((int)b.Tag-1) % n;//строка
            for (int k = 0; k < n; k++)
            {
                if (Matr1[i, k].Text == "|")
                    Matr1[i, k].Text = "-";
                else
                    Matr1[i, k].Text = "|";

            }
            for (int l = 0; l < n; l++)
            {
                if (Matr1[l, j].Text == "|")
                    Matr1[l, j].Text = "-";
                else
                    Matr1[l, j].Text = "|";
            }
            if (Matr1[i, j].Text == "|")
                Matr1[i, j].Text = "-";
            else
                Matr1[i, j].Text = "|";
            string str = Matr1[0, 0].Text;
            int m = 0;
            for (int k = 0; k < n; k++)
                for (int l = 0; l < n; l++)
                {
                    if (Matr1[k,l].Text==str)
                    {
                        m++;
                    }
                }
            if (m==n*n)
            {
                MessageBox.Show("You WIN!");
                Close();
            }
        } 
    }
}
