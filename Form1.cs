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

                }
            }
        }
    }
}
