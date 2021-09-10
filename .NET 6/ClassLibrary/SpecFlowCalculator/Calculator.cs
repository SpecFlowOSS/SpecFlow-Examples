namespace SpecFlowCalculator
{
    public class Calculator
    {
        public int FirstNumber { get; set; }

        public int SecondNumber { get; set; }

        public int Add()
        {
            return FirstNumber + SecondNumber;
        }

        public int Subtract()
        {
            return FirstNumber - SecondNumber;
        }

        public int Divide()
        {
            if (FirstNumber == 0 || SecondNumber == 0)
            {
                return 0;
            }
            else
            {
                return FirstNumber / SecondNumber;
            }
        }

        public int Multiply()
        {
            return FirstNumber * SecondNumber;
        }
    }
}