using System;
using System.Collections;
using System.IO;

public class VowelProcessor : IEnumerable, IComparer, ICloneable
{
    private ArrayList vowels = new ArrayList();
    private static readonly char[] vowelChars = { 'a', 'e', 'i', 'o', 'u', 'y', 'A', 'E', 'I', 'O', 'U', 'Y' };

    public void Add(char c)
    {
        if (Array.IndexOf(vowelChars, c) != -1)
            vowels.Add(c);
    }

    public IEnumerator GetEnumerator()
    {
        return vowels.GetEnumerator();
    }

    public int Compare(object? x, object? y)
    {
        if (x is char cx && y is char cy)
            return cx.CompareTo(cy);
        throw new ArgumentException("Invalid comparison objects.");
    }

    public object Clone()
    {
        VowelProcessor clone = new VowelProcessor();
        foreach (char c in vowels)
            clone.vowels.Add(c);
        return clone;
    }

    public void PrintReversed()
    {
        for (int i = vowels.Count - 1; i >= 0; i--)
            Console.Write(vowels[i]);
        Console.WriteLine();
    }
}

class ex3
{
    public static void Process()
    {
        string path = "input.txt";
        if (!File.Exists(path))
        {
            Console.WriteLine("Файл не знайдено!");
            return;
        }

        string content = File.ReadAllText(path);
        VowelProcessor processor = new VowelProcessor();

        foreach (char c in content)
        {
            processor.Add(c);
        }

        Console.WriteLine("Голосні у зворотному порядку:");
        processor.PrintReversed();
    }
}
