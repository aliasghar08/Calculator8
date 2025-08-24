using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator8
{
    public partial class Form1 : Form
    {
        public bool operationSelected = false;
        public double operand1 = 0;
        public double operand2 = 0;
        public double result = 0;
        public string operatiotype;
        double input = 0;
        bool trignometrySelected = false;
        double factorial = 1;
        public Form1()
        {
            InitializeComponent();
        }

        private void nbutton_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (textBox1.Text.Contains("."))
            {
                e.Handled = true;
            } else
            {
                e.Handled = false;
            }


        }
          
        private void nbutton_Click(object sender, EventArgs e)
        {
            
            Button button = (Button)sender;

            

            // for handling cases where textbox contains only zero and if there is any decimal point


                if (textBox1.Text == "0" || !textBox1.Text.Contains("."))
                {

                // if decimal button is pressed and textbox contains only zero like 0.5
                    if (button.Text == "." && textBox1.Text == "0")
                    {

                        textBox1.Text = "0" + button.Text;
                    }
                    // if decimal button is pressed and textbox is not empty like 4.3
                    else if (button.Text == "." && !(string.IsNullOrEmpty(textBox1.Text)))
                    {

                        textBox1.Text = textBox1.Text + button.Text;
                    }

                    // if button other than the decimal button is pressed
                    else if (button.Text != ".")
                    {

                        textBox1.Text = textBox1.Text + button.Text;
                    }
                    // for any other non defined case
                    else
                    {
                        textBox1.Clear();
                        textBox1.Text = textBox1.Text + button.Text;
                    }
                }

                // for any other non defined case like if there is no zero and decimal point in textbox
                else
                {
                    textBox1.Text = textBox1.Text + button.Text;
                }
            


            if (operationSelected == false)
            {
                operand1 = Convert.ToDouble(textBox1.Text);
                label1.Text = textBox1.Text;
                
               
            } else if(operationSelected == true)
            {
                
                operand2 = Convert.ToDouble(textBox1.Text);
                
            }

            label2.Text = operand1.ToString();

            label3.Text = operand2.ToString();

            label1.Text = result.ToString();
        }
           
        
        private void obutton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

           // textBox1.Text = textBox1.Text + button.Text;

            operationSelected = true;

            if(button.Text == "+")
            {
                operatiotype = "addition";
                textBox1.Clear();
            } else if(button.Text == "-")
            {
                operatiotype = "substraction";
                textBox1.Clear();

            }
            else if(button.Text == "*")
            {
                operatiotype = "multiplication";
                textBox1.Clear();

            }
            else if(button.Text == "/")
            {
                operatiotype = "division";
                textBox1.Clear();

            } else if(button.Text == "%")
            {
                operatiotype = "reminder";
                textBox1.Clear();
            }
            label4.Text = operatiotype;
            
        }

        void Calculation1()
        {
            if (operationSelected)
            {
                if(operatiotype == "addition")
                {
                    result = operand1 + operand2;
                } else if(operatiotype == "substraction")
                {
                    result = operand1 - operand2;
                  

                }
                else if(operatiotype == "multiplication")
                {
                    result = operand1 * operand2;
                    
                } else if(operatiotype == "division")
                {
                    result = operand1 / operand2;
                } else if(operatiotype == "reminder")
                {
                    result = operand1 % operand2;
                }

                textBox1.Text = result.ToString();
            }

            operand1 = result;

            operand2 = Convert.ToDouble(textBox1.Text);

            label2.Text = operand1.ToString();

            label3.Text = operand2.ToString();

            label1.Text = result.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!trignometrySelected)
            {
                Calculation1();
            } else if (trignometrySelected)
            {
                tbutton_Click(sender, e);
            }

           // NextCalculation();
        }


        private void tbutton_Click(object sender, EventArgs e)
        {
            trignometrySelected = true;
            double input = 0;
            input = Convert.ToDouble(textBox1.Text);
            Button button = (Button)sender;
            


           // textBox1.Text = button.Text;

            if(button.Text == "Sin")
            {
                operatiotype = "Sin";
                result = Math.Sin(input);
                textBox1.Text = result.ToString();
               
            }

            if (button.Text == "Cos")
            {

                result = Math.Cos(input);
                textBox1.Text = result.ToString();
            }

            if (button.Text == "Tan")
            {

                result = Math.Tan(input);
                textBox1.Text = result.ToString();
            }
            label4.Text = operatiotype.ToString();
            trignometrySelected = true;
        }

        private void itbutton_Click(object sender, EventArgs e)
        {
            double input = 0;

            input = Convert.ToDouble(textBox1.Text);


            Button button = (Button)sender;

            if (input >= -1 || input <= 1)
            {



                if (button.Text == "Sin^-1")
                {

                    result = Math.Asin(input);
                    textBox1.Text = result.ToString();
                }

                if (button.Text == "Cos^-1")
                {

                    result = Math.Acos(input);
                    textBox1.Text = result.ToString();
                }

                if (button.Text == "Tan^-1")
                {

                    result = Math.Atan(input);
                    textBox1.Text = result.ToString();
                }

            } else
            {
                MessageBox.Show("Please input a valid value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        void calculation2()
        {
            if (operationSelected)
            {
                if (operatiotype == "addition")
                {
                    result = result + operand2;
                }
                else if (operatiotype == "substraction")
                {
                    result = result - operand2;


                }
                else if (operatiotype == "multiplication")
                {
                    result = result * operand2;

                }
                else if (operatiotype == "division")
                {
                    result = result / operand2;
                }

                textBox1.Text = result.ToString();
            }
        }

        void NextCalculation()
        {
            operand1 = operand2;

            operand2 = Convert.ToDouble(textBox1.Text);

            label2.Text = operand1.ToString();

            label3.Text = operand2.ToString();

            label1.Text = result.ToString();
        }

        void FindSin()
        {   

            input = Convert.ToDouble(textBox1.Text);
            textBox1.Text = "Sin" + "(" + input.ToString() + ")";

            


        }

        void Reciprocal()
        {
            result = 1 / operand1;
            textBox1.Text = result.ToString();
            label1.Text = result.ToString();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            Reciprocal();
            

        }

        void Square()
        {
            result = operand1 * operand1;
            textBox1.Text = result.ToString();
            label1.Text = result.ToString();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            Square();
        }

        void Reminder()
        {
            result = operand1 % operand2;
            textBox1.Text = result.ToString();
            label1.Text = result.ToString();
        }

        void SquareRoot()
        {
            result = Math.Sqrt(operand1);
        }

        private void button28_Click(object sender, EventArgs e)
        {
            SquareRoot();
            textBox1.Text = result.ToString();
            label1.Text = result.ToString();
        }

        void ClearAll()
        {
            operand1 = 0;
            operand2 = 0;
            result = 0;
            factorial = 1;

            operationSelected = false;
            operatiotype = string.Empty;

            label1.Text = result.ToString();
            label2.Text = operand1.ToString();
            label3.Text = operand2.ToString();

            textBox1.Text = result.ToString();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length > 0)
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);



                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    if (operationSelected == false)
                    {
                        operand1 = Convert.ToDouble(textBox1.Text);

                    }
                    else if (operationSelected == true)
                    {
                        operand2 = Convert.ToDouble(textBox1.Text);
                    } 
                } else if (string.IsNullOrEmpty(textBox1.Text))
                {
                    operand1 = 0;
                    operand2 = 0;
                }
            }

            label1.Text = operand1.ToString();

            label2.Text = operand2.ToString();

            label3.Text = result.ToString();
        }

        void Factorial(double n)
        {
            
            
            for(int i = 1; i <= n; i++)
            {
                factorial = factorial * i;
            }

           // operand1 = factorial;

            textBox1.Text = factorial.ToString();

            label1.Text = operand1.ToString();

            label2.Text = operand2.ToString();

            label3.Text = result.ToString();
        }

        private void button29_Click(object sender, EventArgs e)
        {
             Factorial(operand1);
            
        }

        private void temperatureConverterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            temperatureConverter tc = new temperatureConverter();
            tc.Show();
        }

        private void kmsToMsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void kmsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Speed1 s1 = new Speed1();
            s1.Show();
            
        }

        private void msToKmhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            speed2 s2 = new speed2();
            s2.Show();
        }

        private void angularSpeedToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void revsToRevmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            As1 as1 = new As1();
            as1.Show();
        }

        private void revmToRevsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            As2 as2 = new As2();
            as2.Show();
        }

        private void revsToRadsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            As3 as3 = new As3();
            as3.Show();
        }

        private void radsToRevsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            As4 as4 = new As4();
            as4.Show();
        }

        private void radianToDegreeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ad1 ad1 = new Ad1();
            ad1.Show();
        }

        private void degreesToRadiansToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ad2 ad2 = new Ad2();
            ad2.Show();
        }

        private void massConversionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void kgToPoundsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mc1 mc1 = new Mc1();
            mc1.Show();
        }

        private void poundsToKgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mc2 mc2 = new Mc2();
            mc2.Show();
        }

        private void cmToInchesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lc1 lc1 = new Lc1();
            lc1.Show();
        }

        private void inchesToCmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lc2 lc2 = new Lc2();
            lc2.Show();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
                errorProvider1.SetError(textBox1, "Invalid Input");
            } else if (char.IsDigit(e.KeyChar))
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
