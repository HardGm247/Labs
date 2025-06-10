using System;

namespace SportsFacilities
{
    /// <summary>
    /// Базовый класс стадиона
    /// </summary>
    public class Stadium
    {
        private int _capacity;

        public int Capacity
        {
            get => _capacity;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Вместимость не может быть отрицательной");
                }

                _capacity = value;
            }
        }

        public Stadium(int capacity)
        {
            Capacity = capacity;
        }

        public void ChangeCapacity(double coefficient)
        {
            if (coefficient <= 0)
            {
                Console.WriteLine("Коэффициент должен быть положительным.");
                return;
            }

            int newCapacity = (int)(Capacity * coefficient);
            Capacity = newCapacity;
        }
    }
}
