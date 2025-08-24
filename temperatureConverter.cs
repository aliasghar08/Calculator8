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
    public partial class temperatureConverter : Form
    {
        double temperature = 0;
        double degreeC;
        double degreeF;
        public temperatureConverter()
        {
            InitializeComponent();
        }

        private void nbutton_Click(object sender, EventArgs e)
        {
            Button nbutton = (Button)sender;

            if (textBox1.Text == "0")
            {
                textBox1.Clear();
                textBox1.Text = nbutton.Text;

            }
            else if (textBox1.Text != "0")
            {


                textBox1.Text = textBox1.Text + nbutton.Text;
            } else if(textBox1.Text == "0" && nbutton.Text == ".")
            {
                textBox1.Text = textBox1.Text + nbutton.Text;

            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            temperature = Convert.ToDouble(textBox1.Text);

            degreeC = 5.0 / 9.0 * (temperature - 32);

            textBox1.Text = degreeC.ToString();
        }

        private void temperatureConverter_Load(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            temperature = Convert.ToDouble(textBox1.Text);

            degreeF = 9.0 / 5.0 * temperature + 32;

            textBox1.Text = degreeF.ToString();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            temperature = 0;
            degreeC = 0;
            degreeF = 0;

        }

        private void button16_Click(object sender, EventArgs e)
        {

            if (textBox1.Text.Length > 0)
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);

                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    temperature = Convert.ToDouble(textBox1.Text);

                } else if (string.IsNullOrEmpty(textBox1.Text))
                {
                    temperature = 0;
                }

            }
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Clear();
        }
    }
}
