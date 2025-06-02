using System;

namespace SportsFacilities
{
    /// <summary>
    /// Теннисный корт
    /// </summary>
    public class TennisCourt : Stadium
    {
        public TennisCourt(int capacity) : base(capacity) { }

        public void HostMatch()
        {
            Console.WriteLine("Матч на теннисном корте");
        }
    }
}
