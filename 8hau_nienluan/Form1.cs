using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8hau_nienluan
{
    public partial class Form1 : Form
    {
        private int count = 0;
        private static int sttBanCo = 0;
        public int cellWidth = 60;

        public int[,,] ketqua;

        SolidBrush fillBrush;
        public Form1()
        {
            InitializeComponent();
            fillBrush = new SolidBrush(Color.Red);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label13.Text = "Trường hợp thứ:" + count;
            //btnNext.Enabled = false;
            //btnReset.Enabled = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if ((i + j) % 2 == 0)
                        e.Graphics.FillRectangle(Brushes.Black, j * cellWidth, i * cellWidth, cellWidth, cellWidth);
                    else
                        e.Graphics.FillRectangle(Brushes.White, j * cellWidth, i * cellWidth, cellWidth, cellWidth);
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            count = 1;
            label13.Text = "Trường hợp thứ: " + count;
            btnNext.Enabled = true;
            btnReset.Enabled = true;
            ketqua = Giai8QuanHau.giaiBaiToan();
            int[,] ketqua1 = new int[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    ketqua1[i, j] = ketqua[sttBanCo, i, j];
                }
            }
            sttBanCo++;
            Graphics g = panelBanCo.CreateGraphics();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (ketqua1[i, j] == 1)
                    {
                        g.DrawImage(Properties.Resources.hau, i * cellWidth, j * cellWidth, cellWidth, cellWidth);
                    }
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int[,] ketqua1 = new int[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    ketqua1[i, j] = ketqua[sttBanCo, i, j];
                }
            }
            sttBanCo++;

            this.Refresh();
            Graphics g = panelBanCo.CreateGraphics();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (ketqua1[i, j] == 1)
                    {
                        g.DrawImage(Properties.Resources.hau, i * cellWidth, j * cellWidth, cellWidth, cellWidth);
                    }
                }
            }
            ++count;
            if (count == 92)
            {
                btnNext.Enabled = false;
                MessageBox.Show("Đã hoàn thành!");
                label13.Text = "Trường hợp thứ: ";
            }
            Form1_Load(sender, e);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            sttBanCo = 0;
            Giai8QuanHau.reset();
            this.Refresh();
            count = 0;
            label13.Text = "Trường hợp thứ: " + count;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
