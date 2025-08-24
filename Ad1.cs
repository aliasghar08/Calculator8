using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator8
{
    public partial class Ad1 : Form
    {
        double value;
        double result;
        public Ad1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Ad1_Load(object sender, EventArgs e)
        {

        }

        private void nbutton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (textBox1.Text == "0")
            {
                textBox1.Clear();
                textBox1.Text = button.Text;

            }
            else if (textBox1.Text != "0")
            {
                textBox1.Text = textBox1.Text + button.Text;


            }

            label3.Text = value.ToString();
            label4.Text = result.ToString();
        }

        void ClearAll()
        {
            textBox1.Text = "0";
            value = 0;
            result = 0;
            label3.Text = value.ToString();
            label4.Text = result.ToString();
            textBox2.Text = "0";
        }

        void Erase()
        {
            if (textBox1.Text.Length > 0)
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);

                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    value = Convert.ToDouble(textBox1.Text);
                }
                else if (string.IsNullOrEmpty(textBox1.Text))
                {
                    textBox1.Text = "0";
                    value = 0;

                }
                label3.Text = value.ToString();
                label4.Text = result.ToString();

            }
        }

        void Calculation()
        {
            if (!string.IsNullOrEmpty(textBox1.Text))
            {


                value = Convert.ToDouble(textBox1.Text);
                result = value * (180 / Math.PI);
                textBox2.Text = result.ToString();
            }
            else if (string.IsNullOrEmpty(textBox1.Text))
            {
                value = 0;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            Calculation();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Erase();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(textBox1, "Invalid Input");
            }
            else if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(textBox1, "Keyboard not allowed");
            }
        }
    }
}
