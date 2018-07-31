using System.Collections.Generic;

namespace Calculator.BL
{
    public class MultiplyOperationStrategy : IMultipleArgsOperationStrategy
    {
        public string Name => "Mul";

        public string OperatorCode => "*";

        public double Calculate(List<double> argumentList)
        {
            double totalValue = 1;

            foreach (double number in argumentList)
            {
                totalValue *= number;
            }
            return totalValue;
        }
    }
}
