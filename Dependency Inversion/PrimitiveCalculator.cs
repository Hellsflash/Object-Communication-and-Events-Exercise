using System.Collections.Generic;

public class PrimitiveCalculator
{
    private IStrategy strategy;

    private Dictionary<char, IStrategy> strategies = new Dictionary<char, IStrategy>()
    {
        {'+',new AdditionStrategy()},
        {'-',new SubtractionStrategy()},
        {'*',new MultyplicationStrategy()},
        {'/',new DivisionStrategy()}
    };

    public PrimitiveCalculator()
    {
        this.strategy = this.strategies['+'];
    }

    public void ChangeStrategy(char @operator)
    {
        this.strategy = strategies[@operator];
    }

    public int performCalculation(int firstOperand, int secondOperand)
    {
        return this.strategy.Calculate(firstOperand, secondOperand);
    }
}