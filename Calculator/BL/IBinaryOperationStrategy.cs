namespace Calculator.BL
{
    public interface IBinaryOperationStrategy : IOperationStrategy
    {
        double Calculate(double argument1, double argument2, out double argument3);
    }
}
