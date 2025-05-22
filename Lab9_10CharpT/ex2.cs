using System;
using System.Collections.Generic;
using System.IO;

class ex2
{
    public static void Process()
    {
        string filePath = "numbers.txt";

        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "10 3 25 7 12 30 5 18 1 22");
            Console.WriteLine("Файл 'numbers.txt' створено з прикладом чисел.");
            //Якщо файл не знайдено, створюється новий з прикладом чисел.
        }

        int a = 5, b = 20;
        Queue<int> inRange = new Queue<int>(); //Queue<T> — це черга, тобто структура даних, яка працює за принципом:
//FIFO — First In, First Out(перший доданий елемент — перший, що буде видалений)
        Queue<int> lessThanA = new Queue<int>();
        Queue<int> greaterThanB = new Queue<int>();

        string[] tokens = File.ReadAllText(filePath)
            .Split(new char[] { ' ', '\n', '\r', ',' }, StringSplitOptions.RemoveEmptyEntries);//розділення тексту на окремі числа за пробілами, комами, новими рядками.

        foreach (string token in tokens)
        {
            if (int.TryParse(token, out int number))//безпечне перетворення рядка на число.
            {
                if (number >= a && number <= b)
                    inRange.Enqueue(number);
                else if (number < a)
                    lessThanA.Enqueue(number);
                else
                    greaterThanB.Enqueue(number);
            }
        }

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
