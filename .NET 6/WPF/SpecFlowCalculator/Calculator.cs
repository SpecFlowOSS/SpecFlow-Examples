namespace SpecFlowCalculator
{
    public class Calculator
    {
        public int FirstNumber { get; set; }

        public int SecondNumber { get; set; }

        public int Result { get; set; }

        public void Add()
        {
            Result = FirstNumber + SecondNumber;
        }

        public void Subtract()
        {
            Result = FirstNumber - SecondNumber;
        }

        public void Multiply()
        {
            Result = FirstNumber * SecondNumber;
        }

        public void Divide()
        {
            if (FirstNumber == 0 || SecondNumber == 0)
            {
                Result = 0;
            }
            else
            {
                Result = FirstNumber / SecondNumber;
            }
        }
    }
}