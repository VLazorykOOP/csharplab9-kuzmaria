using System;
using System.Collections.Generic;
using System.IO;

class ex1
{
    public static void Process()
    {
        string filePath = "input.txt";

        if (!File.Exists(filePath))
        {
            File.WriteAllText(filePath, "Hello, this is a sample text file.");
            Console.WriteLine("Файл 'input.txt' створено з прикладом тексту.");
        }

        char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'y', 'A', 'E', 'I', 'O', 'U', 'Y' };
        Stack<char> stack = new Stack<char>();

        foreach (char c in File.ReadAllText(filePath))
        {
            if (Array.IndexOf(vowels, c) != -1)
            {
                stack.Push(c);
            }
        }

        Console.WriteLine("Голосні у зворотному порядку:");
        while (stack.Count > 0)
        {
            Console.Write(stack.Pop());
        }
        Console.WriteLine();
    }
}
