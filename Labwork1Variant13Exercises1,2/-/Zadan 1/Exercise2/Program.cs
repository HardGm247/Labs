using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Точка входа в программу, управление данными поездов и вывод информации
/// </summary>
class Program
{
    static void Main()
    {
        List<Train> trains = new List<Train>();

        // Ввод количества поездов
        Console.Write("Сколько поездов хотите ввести? ");
        int count = int.Parse(Console.ReadLine());

        // Ввод информации по каждому поезду
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
            int[] seats = Console.ReadLine()
                                .Split()
                                .Select(int.Parse)
                                .ToArray();

            Train train = new Train(number, from, to, seats);
            trains.Add(train);
        }

        // --- Проверка наличия мест в указанном вагоне ---
        Console.Write("\nВведите номер вагона для проверки: ");
        int carIndex = int.Parse(Console.ReadLine());

        List<Train> sorted = trains.OrderBy(t => t.Number).ToList();

        Console.WriteLine("\nПоезда с проверкой вагона:");
        foreach (Train train in sorted)
        {
            train.Print();

            string message = train.HasSeatsInCar(carIndex)
                ? $" → В вагоне {carIndex} есть свободные места"
                : $" → В вагоне {carIndex} мест нет";

            Console.WriteLine(message);
        }

        // --- Сумма свободных мест до заданного города назначения ---
        Console.Write("\nВведите пункт назначения: ");
        string destination = Console.ReadLine();

        int totalSeats = trains
            .Where(t => t.To.Equals(destination, StringComparison.OrdinalIgnoreCase))
            .Sum(t => t.TotalSeats);

        Console.WriteLine($"Общее число свободных мест до станции {destination}: {totalSeats}");

        // --- Поиск поездов, подходящих для группы ---
        Console.Write("\nВведите город отправления: ");
        string fromCity = Console.ReadLine();

        Console.Write("Введите размер группы: ");
        int groupSize = int.Parse(Console.ReadLine());

        List<Train> suitable = trains
            .Where(t => t.From.Equals(fromCity, StringComparison.OrdinalIgnoreCase)
                     && t.HasGroupSpace(groupSize))
            .ToList();

        if (suitable.Any())
        {
            Console.WriteLine("\nПоезда, подходящие для группы:");
            foreach (Train train in suitable)
            {
                train.Print();
            }
        }
        else
        {
            Console.WriteLine("Нет подходящих поездов для группы.");
        }
    }
}
