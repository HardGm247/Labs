using System;
using System.Linq;

/// <summary>
/// Класс, описывающий поезд и количество свободных мест в вагонах.
/// </summary>
public class Train
{
    // Поля класса
    private int trainNumber;
    private string fromCity;
    private string toCity;
    private int[] seats;

    /// <summary>
    /// Конструктор поезда
    /// </summary>
    public Train(int number, string from, string to, int[] seatsArray)
    {
        trainNumber = number;
        fromCity = from;
        toCity = to;
        seats = seatsArray;
    }

    /// <summary>
    /// Номер поезда
    /// </summary>
    public int Number
    {
        get { return trainNumber; }
    }

    /// <summary>
    /// Город отправления
    /// </summary>
    public string From
    {
        get { return fromCity; }
    }

    /// <summary>
    /// Город назначения
    /// </summary>
    public string To
    {
        get { return toCity; }
    }

    /// <summary>
    /// Индексатор для доступа к местам в вагонах
    /// </summary>
    public int this[int index]
    {
        get { return seats[index]; }
        set { seats[index] = value; }
    }

    /// <summary>
    /// Общее количество мест во всех вагонах
    /// </summary>
    public int TotalSeats
    {
        get { return seats.Sum(); }
    }

    /// <summary>
    /// Проверка наличия свободных мест в конкретном вагоне
    /// </summary>
    public bool HasSeatsInCar(int carIndex)
    {
        return carIndex >= 0 &&
               carIndex < seats.Length &&
               seats[carIndex] > 0;
    }

    /// <summary>
    /// Проверка, достаточно ли мест в каком-либо вагоне для всей группы
    /// </summary>
    public bool HasGroupSpace(int groupSize)
    {
        return seats.Any(s => s >= groupSize);
    }

    /// <summary>
    /// Вывод информации о поезде
    /// </summary>
    public void Print()
    {
        string seatInfo = string.Join(", ", seats);
        Console.WriteLine($"Поезд №{trainNumber}: {fromCity} → {toCity}, места: {seatInfo}");
    }
}
