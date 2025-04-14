using System;
using System.Linq;
using System.Collections.Generic;

class MyArray
{
    private List<int> data = new List<int>();

    public int this[int index]
    {
        get => data[index];
        set => data[index] = value;
    }

    public int Length => data.Count;

    public void InputFromConsole(string arrayName)
    {
        Console.WriteLine($"Введите элементы массива {arrayName}, разделённые пробелами:");
        try
        {
            string input = Console.ReadLine();
            data = input.Split().Select(int.Parse).ToList();
        }
        catch (Exception)
        {
            throw new FormatException("Ошибка ввода массива. Убедитесь, что все элементы - целые числа.");
        }
    }

    public void Print(string name)
    {
        Console.WriteLine($"Массив {name}: {string.Join(", ", data)}");
    }

    public List<int> GetData() => data;

    public void SetData(IEnumerable<int> values)
    {
        data = new List<int>(values);
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Ввод массива A и B
            MyArray A = new MyArray();
            MyArray B = new MyArray();
            A.InputFromConsole("A");
            B.InputFromConsole("B");

            int variant = 13;
            int a = variant;
            int b = variant * 2;
            int c = variant / 2;

            // Получаем индексы, избегая совпадений
            List<int> indices = new List<int> { a, b, c };
            indices = indices.Distinct().ToList();
            while (indices.Count < 3)
            {
                int next = indices.Max() + 1;
                indices.Add(next);
            }

            a = indices[0] % A.Length;
            b = indices[1] % B.Length;
            c = indices[2] % A.Length;

            // Формируем массив C
            MyArray C = new MyArray();
            List<int> cData = new List<int>();

            // Добавляем элементы после левого минимального элемента массива B
            int minB = B.GetData().Min();
            int leftMinIndexB = B.GetData().IndexOf(minB);
            if (leftMinIndexB < B.Length - 1)
                cData.AddRange(B.GetData().Skip(leftMinIndexB + 1));

            // Добавляем элементы из A между правым минимальным и элементом c
            int minA = A.GetData().Min();
            int rightMinIndexA = A.GetData().LastIndexOf(minA);
            int start = Math.Min(rightMinIndexA + 1, c - 1);
            int end = Math.Max(rightMinIndexA + 1, c);

            if (start >= 0 && end <= A.Length && end > start)
                cData.AddRange(A.GetData().GetRange(start, end - start));

            C.SetData(cData);
            C.Print("C");

            // Считаем сумму положительных после последнего отрицательного
            int lastNegativeIndex = C.GetData().FindLastIndex(x => x < 0);
            int sum = 0;

            if (lastNegativeIndex != -1 && lastNegativeIndex < C.Length - 1)
                sum = C.GetData().Skip(lastNegativeIndex + 1).Where(x => x > 0).Sum();

            Console.WriteLine($"Сумма положительных элементов после последнего отрицательного: {sum}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}