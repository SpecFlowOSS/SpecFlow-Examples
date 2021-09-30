using System.Windows;

namespace SpecFlowCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Calculator _calculator;

        public MainWindow()
        {
            InitializeComponent();

            _calculator = new Calculator();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            _calculator.FirstNumber = int.Parse(FirstNumber.Text);
            _calculator.SecondNumber = int.Parse(SecondNumber.Text);
            _calculator.Add();
            Result.Text = _calculator.Result.ToString();
        }

        private void Subtract_Click(object sender, RoutedEventArgs e)
        {
            _calculator.FirstNumber = int.Parse(FirstNumber.Text);
            _calculator.SecondNumber = int.Parse(SecondNumber.Text);
            _calculator.Subtract();
            Result.Text = _calculator.Result.ToString();
        }

        private void Multiply_Click(object sender, RoutedEventArgs e)
        {
            _calculator.FirstNumber = int.Parse(FirstNumber.Text);
            _calculator.SecondNumber = int.Parse(SecondNumber.Text);
            _calculator.Multiply();
            Result.Text = _calculator.Result.ToString();
        }

        private void Divide_Click(object sender, RoutedEventArgs e)
        {
            _calculator.FirstNumber = int.Parse(FirstNumber.Text);
            _calculator.SecondNumber = int.Parse(SecondNumber.Text);
            _calculator.Divide();
            Result.Text = _calculator.Result.ToString();
        }
    }
}