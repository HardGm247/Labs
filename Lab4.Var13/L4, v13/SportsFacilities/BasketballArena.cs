using System;

namespace SportsFacilities
{
    /// <summary>
    /// Баскетбольная арена
    /// </summary>
    public class BasketballArena : Stadium
    {
        public BasketballArena(int capacity) : base(capacity) { }

        public void HostMatch()
        {
            Console.WriteLine("Матч на баскетбольной арене");
        }
    }
}
