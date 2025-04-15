using System;
using System.Collections.Generic;
using System.Linq;

class Train
{
    // Поля
    private int trainNumber;
    private string fromCity;
    private string toCity;
    private int[] seats;

    //Конструктор
   public Train(int number, string from, string to, int[] seatsArray)
    {
        trainNumber = number;
        fromCity = from;
        toCity = to;
        seats = seatsArray;
    }

    //Свойства
    public int Number => trainNumber;
    public string From => fromCity;
    public string To => toCity;
    //Индексатор
    public int this[int index]
    {
        get => seats[index];
        set => seats[index] = value;
    }

    public int TotalSeats => seats.Sum();

    public bool HasSeatsInCar(int carIndex)
    {
        return carIndex >= 0 && carIndex < seats.Length && seats[carIndex] > 0;
    }

    public bool HasGroupSpace(int groupSize)
    {
        return seats.Any(s => s >= groupSize);
    }

    public void Print()
    {
        Console.WriteLine($"Поезд №{trainNumber}: {fromCity} → {toCity}, места: {string.Join(", ", seats)}");
    }
}

class Program
{
    static void Main()
    {
        List<Train> trains = new List<Train>();
        //Ввод поездов
        Console.Write("Сколько поездов хотите ввести? ");
        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"\nПоезд {i + 1}");

            Console.Write("Номер поезда: ");
            int number = int.Parse(Console.ReadLine());

            Console.Write("Город отправления: ");
            string from = Console.ReadLine();

            Console.Write("Город назначения: ");
            string to = Console.ReadLine();

            Console.Write("Свободные места в вагонах (через пробел): ");
            int[] seats = Console.ReadLine().Split().Select(int.Parse).ToArray();

            trains.Add(new Train(number, from, to, seats));
        }

        // Сортировка и вывод
        Console.Write("\nВведите номер вагона для проверки: ");
        int carIndex = int.Parse(Console.ReadLine());
        //Сортировка поездов
        var sorted = trains.OrderBy(t => t.Number).ToList();
        Console.WriteLine("\nПоезда с проверкой вагона:");
        foreach (var train in sorted)
        {
            train.Print();
            Console.WriteLine(train.HasSeatsInCar(carIndex)
                ? $" → В вагоне {carIndex} есть свободные места"
                : $" → В вагоне {carIndex} мест нет");
        }

        // Свободные места до заданной станции
        Console.Write("\nВведите пункт назначения: ");
        string destination = Console.ReadLine();

        int total = trains
            .Where(t => t.To.Equals(destination, StringComparison.OrdinalIgnoreCase))
            .Sum(t => t.TotalSeats);

        Console.WriteLine($"Общее число свободных мест до станции {destination}: {total}");

        // Поезда с местами для группы
        Console.Write("\nВведите город отправления: ");
        string fromCity = Console.ReadLine();

        Console.Write("Введите размер группы: ");
        int groupSize = int.Parse(Console.ReadLine());

        var suitable = trains
            .Where(t => t.From.Equals(fromCity, StringComparison.OrdinalIgnoreCase) && t.HasGroupSpace(groupSize))
            .ToList();

        if (suitable.Any())
        {
            Console.WriteLine("\nПоезда, подходящие для группы:");
            foreach (var t in suitable)
                t.Print();
        }
        else
        {
            Console.WriteLine("Нет подходящих поездов для группы.");
        }
    }
}
