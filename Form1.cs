using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PicturesViewer
{
    public partial class Form1 : Form
    {
        private int k = 0;
        private int N = 0;
        private List<string> names;
        private List<string> pathes;

        public Form1()
        {
            InitializeComponent();
            names = new List<string>();
            pathes = new List<string>();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void programToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string info = $"{Application.ProductName}{Environment.NewLine}{Application.ProductVersion}";
            MessageBox.Show(info);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFile = new OpenFileDialog())
            {
                openFile.Multiselect = true;
                openFile.Filter = "PNG(*.png)|*.png|GPEG(*.jpg)|*.jpg|GIF(*gif)|*.gif|All Files(*.*)|*.*||";

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    names.AddRange(openFile.SafeFileNames);
                    pathes.AddRange(openFile.FileNames);
                    listBox1.Items.Clear();
                    foreach (var n in names)
                    {
                        listBox1.Items.Add(n);
                    }
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            k = listBox1.SelectedIndex;
            pictureBox1.Image = Image.FromFile(pathes[k]);
        }

        private void Forward()
        {
            k = listBox1.SelectedIndex;
            if (k == -1)
            {
                MessageBox.Show("Изображение не выбрано", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                N = listBox1.Items.Count;
                if (k == N - 1)
                {
                    k = 0;
                }
                else
                {
                    k++;
                }

                listBox1.SelectedIndex = k;
            }
        }

        private void Backward()
        {
            k = listBox1.SelectedIndex;
            if (k == -1)
            {
                MessageBox.Show("Изображение не выбрано", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                N = listBox1.Items.Count;
                if (k == 0)
                {
                    k = N-1;
                }
                else
                {
                    k--;
                }

                listBox1.SelectedIndex = k;
            }
        }

        private void ForwButton_Click(object sender, EventArgs e)
        {
            Forward();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Forward();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex == -1)
                MessageBox.Show("Изображение не выбрано", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                timer1.Interval = (int)intervalSlideShow.Value;
                timer1.Start();
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            listBox1.SelectedIndex = 0;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Stop();
            }

            listBox1.Items.Clear();
            names.Clear();
            pathes.Clear();
            pictureBox1.Image = Image.FromFile(@"..\..\Images\logo.png");
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Backward();
        }

    }
}
