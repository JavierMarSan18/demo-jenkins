

namespace Api.Services;

public class MathService
{
    public int Add(int a, int b) => a + b;

    public int Subtract(int a, int b) => a - b;

    public bool IsEven(int number) => number % 2 == 0;

    public int Multiply(int a, int b) => a * b;

    public int Divide(int a, int b) => a / b;
}
