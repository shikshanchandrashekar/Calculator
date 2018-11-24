using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace MyCalci
{
    public partial class SimpleCalculator : Form
    {
        bool decPoint = false, opClick = false, equClick = false, numclick=false;
        static string op,op1="=";
        double memVal = 0;
        double resultVal = 0, intVal=0;
        public SimpleCalculator()
        {
            InitializeComponent();
        }
        private void num_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (display.Text == "0" || opClick || equClick)
            {
                display.Clear();
                if (b.Text == "00")
                    display.Text = "0";
                else
                {
                    display.Text = b.Text;
                    numclick = true;
                    equClick = false;
                    opClick = false;
                }
            }
            else
            {
                numclick = true;
                display.Text += b.Text;
            }
            resultVal = Double.Parse(display.Text);
        }
        private void MemSub_Click(object sender, EventArgs e)
        {
            memVal -= double.Parse(display.Text);
            display.Text = "0";
            MemLabel.Text = "M";

        }
        private void MemAdd_Click(object sender, EventArgs e)
        {
            memVal += double.Parse(display.Text);
            display.Text="0";
            MemLabel.Text = "M";
        }
        private void Op_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            op = b.Text;
            opClick = true;
            decPoint = false;
            if (numclick)
            {
                switch (op1)
                {
                    case "+":
                        intVal += Double.Parse(display.Text);
                        break;
                    case "-":
                        intVal -= Double.Parse(display.Text);
                        break;
                    case "×":
                        intVal *= Double.Parse(display.Text);
                        break;
                    case "/":
                        intVal /= Double.Parse(display.Text);
                        break;
                    case "=":
                        intVal = Double.Parse(display.Text);
                        break;
                    default: break;
                }
            }
            numclick = false;
            display.Text = resultVal.ToString();
            op1 = op;
            if(op=="=")
            {
                equClick = true;
                opClick = false;
                resultVal = intVal;
                display.Text = resultVal.ToString();
            }
        }
        private void DecPoint_Click(object sender, EventArgs e)
        {
            if (!decPoint)
            {
                display.Text += ".";
                decPoint=true;
            }

        }
        private void Del_Click(object sender, EventArgs e)
        {
            if (display.TextLength > 0)
            {
                display.Text = display.Text.Remove(display.TextLength - 1, 1);
                if (!display.Text.Contains("."))
                    decPoint = false;
                if (display.TextLength == 0)
                    display.Text = "0";
            }
        }
        private void MR_Click(object sender, EventArgs e)
        {
            display.Text = memVal.ToString();
                   }
        private void CE_Click(object sender, EventArgs e)
        {
            display.Text = "0";
            decPoint = opClick = false;
            resultVal = 0;
        }
        private void Sqrt_Click(object sender, EventArgs e)
        {
            display.Text = Math.Sqrt(Double.Parse(display.Text)).ToString();
        }
        private void MemClear_Click(object sender, EventArgs e)
        {
            memVal = 0;
            MemLabel.Clear();
        }
    }
}
