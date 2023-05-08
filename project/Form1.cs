using com.calitha.goldparser;
using System;
using System.Windows.Forms;

namespace project
{
    public partial class Form1 : Form
    {
        MyParser p;

        public Form1()
        {
            InitializeComponent();
            p = new MyParser("grammer.cgt", listBox1);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            p.Parse(textBox1.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
