using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Класс представляет собой пользовательский массив с удобными методами работы.
/// </summary>
public class MyArray
{
    // Закрытое поле для хранения элементов массива
    private List<int> _data = new List<int>();

    /// <summary>
    /// Индексатор для получения или установки элемента по индексу
    /// </summary>
    public int this[int index]
    {
        get
        {
            return _data[index];
        }
        set
        {
            _data[index] = value;
        }
    }

    /// <summary>
    /// Свойство для получения длины массива
    /// </summary>
    public int Length
    {
        get
        {
            return _data.Count;
        }
    }

    /// <summary>
    /// Метод ввода элементов массива с консоли
    /// </summary>
    /// <param name="arrayName">Имя массива для вывода в приглашении</param>
    public void InputFromConsole(string arrayName)
    {
        Console.WriteLine($"Введите элементы массива {arrayName}, разделённые пробелами:");
        try
        {
            string input = Console.ReadLine();
            string[] parts = input.Split(); // Разделение строки на подстроки
            List<int> values = parts.Select(int.Parse).ToList(); // Преобразование в список целых чисел
            _data = values; // Присваиваем полученные значения внутреннему полю
        }
        catch (Exception)
        {
            throw new FormatException("Ошибка ввода массива. Убедитесь, что все элементы - целые числа.");
        }
    }

    /// <summary>
    /// Метод для вывода массива на экран
    /// </summary>
    /// <param name="name">Имя массива для подписи</param>
    public void Print(string name)
    {
        string output = string.Join(", ", _data);
        Console.WriteLine($"Массив {name}: {output}");
    }

    /// <summary>
    /// Возвращает список элементов массива
    /// </summary>
    public List<int> GetData()
    {
        return _data;
    }

    /// <summary>
    /// Устанавливает элементы массива из переданной коллекции
    /// </summary>
    /// <param name="values">Коллекция целых чисел</param>
    public void SetData(IEnumerable<int> values)
    {
        List<int> copy = new List<int>(values);
        _data = copy;
    }

    /// <summary>
    /// Возвращает сумму положительных чисел после последнего отрицательного элемента
    /// </summary>
    public int SumPositiveAfterLastNegative()
    {
        int lastNegativeIndex = _data.FindLastIndex(x => x < 0);

        // Проверка, что отрицательный элемент найден и не является последним
        if (lastNegativeIndex != -1 && lastNegativeIndex < _data.Count - 1)
        {
            IEnumerable<int> tail = _data.Skip(lastNegativeIndex + 1);
            IEnumerable<int> positives = tail.Where(x => x > 0);
            int sum = positives.Sum();
            return sum;
        }

        // Если отрицательных элементов нет или они в конце — возвращаем 0
        return 0;
    }
}
