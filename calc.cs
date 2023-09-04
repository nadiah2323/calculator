using System;
using System.Windows.Forms;

namespace AppKalkulator
{
    public partial class Form1 : Form
    {
        private float storedValue = 0;
        private string operation = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void AppendDigit(string digit)
        {
            tbDisplay.Text += digit;
        }

        private void PerformOperation(string op)
        {
            if (!string.IsNullOrEmpty(tbDisplay.Text))
            {
                storedValue = float.Parse(tbDisplay.Text);
                operation = op;
                tbDisplay.Text = "";
            }
        }

        private void btnDigit_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            AppendDigit(button.Text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            PerformOperation("+");
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            PerformOperation("-");
        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            PerformOperation("x");
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            PerformOperation("/");
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbDisplay.Text))
            {
                float currentValue = float.Parse(tbDisplay.Text);
                float result = 0;

                switch (operation)
                {
                    case "+":
                        result = storedValue + currentValue;
                        break;
                    case "-":
                        result = storedValue - currentValue;
                        break;
                    case "x":
                        result = storedValue * currentValue;
                        break;
                    case "/":
                        if (currentValue != 0)
                            result = storedValue / currentValue;
                        else
                            tbDisplay.Text = "Error";
                        break;
                }

                tbDisplay.Text = result.ToString();
                storedValue = result;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbDisplay.Text = "";
            storedValue = 0;
            operation = "";
        }
    }
}
