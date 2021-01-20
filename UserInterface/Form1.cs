using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleCalculator;
using System.Runtime.InteropServices;

namespace UserInterface
{
    public partial class Form1 : Form
    {
        Calculator calculator;

        public Form1()
        {
            InitializeComponent();
            calculator = new Calculator();
            AllocConsole();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private void button1_Click(object sender, EventArgs e)
        {
            TenBitInteger number = Convert.ToInt32(textBox1.Text);
            calculator.Push(number);
            label2.Text = calculator.GetCurrentStack();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            calculator.Add();
            label2.Text = calculator.GetCurrentStack();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            calculator.Pop();
            label2.Text = calculator.GetCurrentStack();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            calculator.Sub();
            label2.Text = calculator.GetCurrentStack();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
