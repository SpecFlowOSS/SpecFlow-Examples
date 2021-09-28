namespace SpecFlowCalculator
{
    public class Calculator
    {
        public int Add(int number1, int number2)
        {
            return number1 + number2;
        }

        public int Subtract(int number1, int number2)
        {
            return number1 - number2;
        }

        public int Multiply(int number1, int number2)
        {
            return number1 * number2;
        }

        public int Divide(int number1, int number2)
        {
            if (number1 == 0 || number2 == 0)
            {
                return 0;
            }

            return number1 / number2;
        }
    }
}
