using System;
using System.Collections.Generic;

namespace Calculator.BL
{
    public class ContextOperation
    {
        public IMultipleArgsOperationStrategy MultipleArgsOperationStrategy { get; set; }
        public IBinaryOperationStrategy BinaryOperationStrategy { get; set; }
        public IUnaryOperationStrategy UnaryOperationStrategy { get; set; }


        public double Sum(List<double> argumentList)
        {
            this.MultipleArgsOperationStrategy = new SumOperationStrategy();
            return this.MultipleArgsOperationStrategy.Calculate(argumentList);
        }

        public double Diff(double argument1, double argument2)
        {
            this.BinaryOperationStrategy = new DiffOperationStrategy();
            return this.BinaryOperationStrategy.Calculate(argument1, argument2, out argument2);
        }

        public double Multiply(List<double> argumentList)
        {
            this.MultipleArgsOperationStrategy = new MultiplyOperationStrategy();
            return this.MultipleArgsOperationStrategy.Calculate(argumentList);
        }

        public double Division(double argument1, double argument2, out double argument3)
        {
            this.BinaryOperationStrategy = new DivisionOperationStrategy();
            return this.BinaryOperationStrategy.Calculate(argument1, argument2, out argument3);
        }

        public double Square(double argument)
        {
            this.UnaryOperationStrategy = new SquareOperationStrategy();
            return this.UnaryOperationStrategy.Calculate(argument);
        }

    }
}
