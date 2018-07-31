namespace Calculator.BL
{
    public class DiffOperationStrategy : IBinaryOperationStrategy
    {
        public string Name => "diff";

        public string OperatorCode => "-";

        public double Calculate(double argument1, double argument2, out double argument3)
        {
            argument3 = 0;
            return argument1 - argument2;
        }
    }
}
