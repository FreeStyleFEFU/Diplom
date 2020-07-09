using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom_final
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int a = Int32.Parse(textBox1.Text);
            int b = Int32.Parse(textBox2.Text);
            int c = Int32.Parse(textBox3.Text);

            Form1.set.Add(new List<int> { a, b, c });

            Close();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }
}
