using System;

public class Calculator<T>
{
    public delegate T OperationDelegate(T a, T b);

    public OperationDelegate Add { get; set; }
    public OperationDelegate Subtract { get; set; }
    public OperationDelegate Multiply { get; set; }
    public OperationDelegate Divide { get; set; }

    public Calculator()
    {
        // Додавання
        Add = (a, b) => (dynamic)a + b;
        // Віднімання
        Subtract = (a, b) => (dynamic)a - b;
        // Множення
        Multiply = (a, b) => (dynamic)a * b;
        // Ділення
        Divide = (a, b) => (dynamic)a / b;
    }

    public T PerformOperation(T a, T b, OperationDelegate operation)
    {
        if (operation != null)
            return operation(a, b);
        else
            throw new InvalidOperationException("Operation is not defined.");
    }
}
