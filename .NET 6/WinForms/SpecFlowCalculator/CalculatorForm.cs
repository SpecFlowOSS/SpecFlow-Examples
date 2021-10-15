using System;
using System.Windows.Forms;

namespace SpecFlowCalculator
{
    public partial class CalculatorForm : Form
    {
        private readonly Calculator _calculator;

        public CalculatorForm()
        {
            InitializeComponent();

            _calculator = new Calculator();
        }

        private void button_add_Click(object sender, EventArgs e)
        {
            _calculator.FirstNumber = int.Parse(textBox_firstNumber.Text);
            _calculator.SecondNumber = int.Parse(textBox_secondNumber.Text);
            _calculator.Add();
            textBox_result.Text = _calculator.Result.ToString();
        }

        private void button_subtract_Click(object sender, EventArgs e)
        {
            _calculator.FirstNumber = int.Parse(textBox_firstNumber.Text);
            _calculator.SecondNumber = int.Parse(textBox_secondNumber.Text);
            _calculator.Subtract();
            textBox_result.Text = _calculator.Result.ToString();
        }

        private void button_multiply_Click(object sender, EventArgs e)
        {
            _calculator.FirstNumber = int.Parse(textBox_firstNumber.Text);
            _calculator.SecondNumber = int.Parse(textBox_secondNumber.Text);
            _calculator.Multiply();
            textBox_result.Text = _calculator.Result.ToString();
        }

        private void button_divide_Click(object sender, EventArgs e)
        {
            _calculator.FirstNumber = int.Parse(textBox_firstNumber.Text);
            _calculator.SecondNumber = int.Parse(textBox_secondNumber.Text);
            _calculator.Divide();
            textBox_result.Text = _calculator.Result.ToString();
        }
    }
}