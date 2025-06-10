using System;

namespace SportsFacilities
{
    class Program
    {
        private const int FootballDefaultCapacity = 60000;
        private const int BasketballDefaultCapacity = 15000;
        private const int TennisDefaultCapacity = 5000;
        private const double ReducedCapacityFactor = 0.8;

        static void Main()
        {
            Console.WriteLine("=== Добро пожаловать в менеджер спортивных арен ===");

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\nВыберите опцию:");
                Console.WriteLine("1. Создать футбольный стадион");
                Console.WriteLine("2. Создать баскетбольную арену");
                Console.WriteLine("3. Создать теннисный корт");
                Console.WriteLine("0. Выйти");
                Console.Write("Ваш выбор: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        HandleFootball();
                        break;
                    case "2":
                        HandleBasketball();
                        break;
                    case "3":
                        HandleTennis();
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }

            Console.WriteLine("Программа завершена.");
        }

        private static void HandleFootball()
        {
            var stadium = new FootballStadium(FootballDefaultCapacity);
            stadium.HostMatch();
            Console.WriteLine($"Вместимость: {stadium.Capacity}");
            stadium.ChangeCapacity(ReducedCapacityFactor);
            Console.WriteLine($"Обновлённая вместимость: {stadium.Capacity}");
        }

        private static void HandleBasketball()
        {
            var arena = new BasketballArena(BasketballDefaultCapacity);
            arena.HostMatch();
            Console.WriteLine($"Вместимость: {arena.Capacity}");
        }

        private static void HandleTennis()
        {
            var court = new TennisCourt(TennisDefaultCapacity);
            court.HostMatch();
            Console.WriteLine($"Вместимость: {court.Capacity}");
        }
    }
}
