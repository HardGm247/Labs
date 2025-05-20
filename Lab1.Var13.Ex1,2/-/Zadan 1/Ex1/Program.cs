using System;
using System.Linq;
using System.Collections.Generic;

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
}using System;
using System.Linq;
using System.Collections.Generic;

/// <summary>
/// Основной класс программы
/// </summary>
class Program
{
    static void Main()
    {
        try
        {
            // Создание двух пользовательских массивов A и B
            MyArray A = new MyArray();
            MyArray B = new MyArray();

            // Ввод данных с консоли для массивов A и B
            A.InputFromConsole("A");
            B.InputFromConsole("B");

            // Вариант по заданию, используется для генерации индексов
            int variant = 13;
            int indexA = variant;
            int indexB = variant * 2;
            int indexC = variant / 2;

            // Формируем список индексов и убираем повторы
            List<int> indices = new List<int>();
            indices.Add(indexA);
            indices.Add(indexB);
            indices.Add(indexC);
            indices = indices.Distinct().ToList();

            // Убеждаемся, что в списке три уникальных значения
            while (indices.Count < 3)
            {
                int nextIndex = indices.Max() + 1;
                indices.Add(nextIndex);
            }

            // Приводим индексы к допустимому диапазону по длине массивов
            indexA = indices[0] % A.Length;
            indexB = indices[1] % B.Length;
            indexC = indices[2] % A.Length;

            // Создаём массив C
            MyArray C = new MyArray();
            List<int> cData = new List<int>();

            // --- Заполнение массива C ---

            // 1. Добавляем все элементы массива B после первого (левого) минимального элемента
            int minB = B.GetData().Min();
            int leftMinIndexB = B.GetData().IndexOf(minB);
            if (leftMinIndexB < B.Length - 1)
            {
                List<int> tailB = B.GetData().Skip(leftMinIndexB + 1).ToList();
                cData.AddRange(tailB);
            }

            // 2. Добавляем элементы из массива A от правого минимального элемента до indexC
            int minA = A.GetData().Min();
            int rightMinIndexA = A.GetData().LastIndexOf(minA);

            // Определяем границы диапазона
            int start = Math.Min(rightMinIndexA + 1, indexC - 1);
            int end = Math.Max(rightMinIndexA + 1, indexC);

            // Убеждаемся, что границы допустимы
            if (start >= 0 && end <= A.Length && end > start)
            {
                List<int> rangeA = A.GetData().GetRange(start, end - start);
                cData.AddRange(rangeA);
            }

            // Устанавливаем сформированные данные в массив C
            C.SetData(cData);

            // Выводим массив C
            C.Print("C");

            // --- Вычисление суммы положительных чисел после последнего отрицательного ---

            int lastNegativeIndex = C.GetData().FindLastIndex(x => x < 0);
            int sum = 0;

            if (lastNegativeIndex != -1 && lastNegativeIndex < C.Length - 1)
            {
                IEnumerable<int> positiveAfterNegative = C.GetData()
                .Skip(lastNegativeIndex + 1)
                .Where(x => x > 0);
                sum = positiveAfterNegative.Sum();
            }

            Console.WriteLine($"Сумма положительных элементов после последнего отрицательного: {sum}");
        }
        catch (Exception ex)
        {
            // Обработка возможных ошибок
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}
