using System;

public class Example
{
    private static TestClass test = new TestClass(3);

    public static void Main()
    {
        Example ex = new Example();
        Console.WriteLine(test.Value);
    }
}

public class TestClass
{
    public readonly int Value;

    public TestClass(int value)
    {
        if (value < 0 || value > 1) throw new ArgumentOutOfRangeException();
        Value = value;
    }
}