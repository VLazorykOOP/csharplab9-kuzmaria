using System;
using System.Collections;
using System.IO;

public class NumberProcessor : IEnumerable, IComparer, ICloneable
//IEnumerable — дозволяє перебирати числа через foreach
//IComparer — для можливого сортування
//ICloneable — створення копії об’єкта
{
    private ArrayList inRange = new ArrayList();
    private ArrayList lessThanA = new ArrayList();
    private ArrayList greaterThanB = new ArrayList();
    private int a, b;

    public NumberProcessor(int a, int b)
    {
        this.a = a;
        this.b = b;
    }

    public void Add(int number)
    {
        if (number >= a && number <= b)
            inRange.Add(number);
        else if (number < a)
            lessThanA.Add(number);
        else
            greaterThanB.Add(number);
    }

    public IEnumerator GetEnumerator()
    {
        foreach (var n in inRange) yield return n;
        foreach (var n in lessThanA) yield return n;
        foreach (var n in greaterThanB) yield return n;
    }

    public int Compare(object? x, object? y)
    {
        if (x is int nx && y is int ny)
            return nx.CompareTo(ny);
        throw new ArgumentException("Invalid comparison objects.");
    }

    public object Clone()
    {
        NumberProcessor clone = new NumberProcessor(a, b);
        foreach (int n in inRange) clone.inRange.Add(n);
        foreach (int n in lessThanA) clone.lessThanA.Add(n);
        foreach (int n in greaterThanB) clone.greaterThanB.Add(n);
        return clone;
    }

    public void Print()
    {
        Console.WriteLine($"Числа в інтервалі [{a},{b}]:");
        foreach (int n in inRange) Console.Write(n + " ");
        Console.WriteLine();

        Console.WriteLine($"Числа менші за {a}:");
        foreach (int n in lessThanA) Console.Write(n + " ");
        Console.WriteLine();

        Console.WriteLine($"Числа більші за {b}:");
        foreach (int n in greaterThanB) Console.Write(n + " ");
        Console.WriteLine();
    }
}

class ex4
{
    public static void Process()
    {
        int a = 5, b = 20;
        string path = "numbers.txt";

        if (!File.Exists(path))
        {
            Console.WriteLine("Файл не знайдено!");
            return;
        }

        string[] tokens = File.ReadAllText(path)
            .Split(new char[] { ' ', '\n', '\r', ',' }, StringSplitOptions.RemoveEmptyEntries);

        NumberProcessor processor = new NumberProcessor(a, b);

        foreach (string token in tokens)
        {
            if (int.TryParse(token, out int number))
            {
                processor.Add(number);
            }
        }

        processor.Print();
    }
}
