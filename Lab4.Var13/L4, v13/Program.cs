using System;

namespace SportsFacilities
{
    class Program
    {
        static void Main()
        {
            // Примеры создания объектов и вызова методов
            var footballStadium = new FootballStadium(60000);
            footballStadium.HostMatch();
            Console.WriteLine($"Вместимость: {footballStadium.Capacity}");

            // Например, временно закрыли сектор
            footballStadium.ChangeCapacity(0.8);
            Console.WriteLine($"Обновлённая вместимость: {footballStadium.Capacity}");

            var basketballArena = new BasketballArena(15000);
            basketballArena.HostMatch();

            var tennisCourt = new TennisCourt(5000);
            tennisCourt.HostMatch();
        }
    }

    // Базовый класс стадиона
    public class Stadium
    {
        private int _capacity;

        // Публичное свойство для доступа к вместимости
        public int Capacity
        {
            get => _capacity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Вместимость не может быть отрицательной");
                }

                _capacity = value;
            }
        }

        // Конструктор
        public Stadium(int capacity)
        {
            Capacity = capacity;
        }

        // Метод для изменения вместимости, например, при изменении конфигурации зала
        public void ChangeCapacity(double coefficient)
        {
            if (coefficient <= 0)
            {
                Console.WriteLine("Коэффициент должен быть положительным.");
                return;
            }

            Capacity = (int)(Capacity * coefficient);
        }
    }

    // Класс футбольного стадиона
    public class FootballStadium : Stadium
    {
        public FootballStadium(int capacity) : base(capacity) { }

        public void HostMatch()
        {
            Console.WriteLine("Матч на футбольном стадионе");
        }
    }

    // Класс баскетбольной арены
    public class BasketballArena : Stadium
    {
        public BasketballArena(int capacity) : base(capacity) { }

        public void HostMatch()
        {
            Console.WriteLine("Матч на баскетбольной арене");
        }
    }

    // Класс теннисного корта
    public class TennisCourt : Stadium
    {
        public TennisCourt(int capacity) : base(capacity) { }

        public void HostMatch()
        {
            Console.WriteLine("Матч на теннисном корте");
        }
    }
}
