using System;
using System.Collections;
using System.IO;

public class VowelProcessor : IEnumerable, IComparer, ICloneable
//IEnumerable — дозволяє перебирати об'єкти в foreach
//IComparer — порівнює об'єкти (використовується для сортування)
//ICloneable — дозволяє створити копію об'єкта
{
    private ArrayList vowels = new ArrayList(); //список, у якому зберігаються знайдені голосні.
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

    public int Compare(object? x, object? y) //Порівнює два символи, якщо вони обидва char.
    {
        if (x is char cx && y is char cy)
            return cx.CompareTo(cy);
        throw new ArgumentException("Invalid comparison objects.");
    }

    public object Clone() //Створює глибоку копію поточного об'єкта.
    {
        VowelProcessor clone = new VowelProcessor();
        foreach (char c in vowels)
            clone.vowels.Add(c);
        return clone;
    }

    public void PrintReversed() //Виводить всі голосні у зворотному порядку (від останньої до першої).

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

        try
        {
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
        catch (IOException ex)
        {
            Console.WriteLine("Помилка при роботі з файлом: " + ex.Message);
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine("Немає прав доступу до файлу: " + ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Невідома помилка: " + ex.Message);
        }
    }
}