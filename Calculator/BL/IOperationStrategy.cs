namespace Calculator.BL
{
    public interface IOperationStrategy
    {
        string Name { get; }
        string OperatorCode { get; }
    }
}
