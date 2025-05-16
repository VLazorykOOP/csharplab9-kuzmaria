using System;

class MainProgram
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n=== Меню завдань ===");
            Console.WriteLine("1. Обробка голосних (Stack)");
            Console.WriteLine("2. Розподіл чисел на черги");
            Console.WriteLine("3. Обробка голосних з інтерфейсами");
            Console.WriteLine("4. Розподіл чисел з інтерфейсами");
            Console.WriteLine("5. Каталог музичних дисків");
            Console.WriteLine("0. Вихід");
            Console.Write("Виберіть завдання: ");

            string? choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1": ex1.Process(); break;
                case "2": ex2.Process(); break;
                case "3": ex3.Process(); break;
                case "4": ex4.Process(); break;
                case "5": ex5.Process(); break;
                case "0": return;
                default: Console.WriteLine("❌ Невірний вибір. Спробуйте ще раз."); break;
            }
        }
    }
}
