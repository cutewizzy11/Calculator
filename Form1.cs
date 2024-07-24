using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCalculator
{
    public partial class Form1 : Form
    {
        private double _result = 0;
        private string _operation = string.Empty;
        private bool _isOperationPerformed = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void NumberButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if ((textBox_Result.Text == "0") || _isOperationPerformed)
                textBox_Result.Clear();

            _isOperationPerformed = false;
            textBox_Result.Text += button.Text;
        }
        private void OperatorButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (_result != 0)
            {
                buttonEquals.PerformClick();
                _operation = button.Text;
                _isOperationPerformed = true;
            }
            else
            {
                _operation = button.Text;
                _result = double.Parse(textBox_Result.Text);
                _isOperationPerformed = true;
            }
        }
        private void buttonEquals_Click(object sender, EventArgs e)
        {
            switch (_operation)
            {
                case "+":
                    textBox_Result.Text = (_result + double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "-":
                    textBox_Result.Text = (_result - double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "*":
                    textBox_Result.Text = (_result * double.Parse(textBox_Result.Text)).ToString();
                    break;
                case "/":
                    textBox_Result.Text = (_result / double.Parse(textBox_Result.Text)).ToString();
                    break;
                default:
                    break;
            }

            _result = double.Parse(textBox_Result.Text);
            _operation = string.Empty;
        }
        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBox_Result.Text = "0";
            _result = 0;
            _operation = string.Empty;
        }
    }
}
