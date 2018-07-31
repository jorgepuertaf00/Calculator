namespace Calculator.BL
{
    public class DivisionOperationStrategy : IBinaryOperationStrategy
    {
        public string Name => "diff";

        public string OperatorCode => "/";

        public double Calculate(double argument1, double argument2, out double argument3)
        {
            if (argument2 == 0)
            {
                argument3 = -1;
                return -1;
            }
            argument3 = argument1 % argument2;
            return argument1 / argument2;
        }
    }
}
