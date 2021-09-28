namespace SpecFlowCalculatorAPI
{
    public class Calculator
    {
        public int Result { get; set; }

        public void Add(int firstNumber, int secondNumber)
        {
            Result = firstNumber + secondNumber;
        }

        public void Subtract(int firstNumber, int secondNumber)
        {
            Result = firstNumber - secondNumber;
        }

        public void Multiply(int firstNumber, int secondNumber)
        {
            Result = firstNumber * secondNumber;
        }

        public void Divide(int firstNumber, int secondNumber)
        {
            if (firstNumber== 0 || secondNumber== 0)
            {
                Result = 0;
            }
            else
            {
                Result = firstNumber / secondNumber;
            }
        }
    }
}