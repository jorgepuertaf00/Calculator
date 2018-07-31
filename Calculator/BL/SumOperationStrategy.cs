using System.Collections.Generic;

namespace Calculator.BL
{
    public class SumOperationStrategy : IMultipleArgsOperationStrategy
    {
        public string Name => "Sum";
        public string OperatorCode => "+";

        public double Calculate(List<double> argumentList)
        {
            double totalValue = 0;

            foreach (double number in argumentList)
            {
                totalValue += number;
            }
            return totalValue;
        }
    }
}
