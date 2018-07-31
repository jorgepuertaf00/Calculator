namespace Calculator.BL
{
   public interface IUnaryOperationStrategy : IOperationStrategy
    {
        double Calculate(double argument);
    }
}
