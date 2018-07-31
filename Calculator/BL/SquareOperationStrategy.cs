using System;

namespace Calculator.BL
{
    public class SquareOperationStrategy : IUnaryOperationStrategy
    {
        public string Name => "Sqrt";
        public string OperatorCode => "√";

        public double Calculate(double argument)
        {
            return Math.Sqrt(argument);
        }
    }
}