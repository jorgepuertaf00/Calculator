using System.Collections.Generic;

namespace Calculator.BL
{
   public interface IMultipleArgsOperationStrategy :IOperationStrategy
    {
        double Calculate(List<double> argumentList);
    }
}
