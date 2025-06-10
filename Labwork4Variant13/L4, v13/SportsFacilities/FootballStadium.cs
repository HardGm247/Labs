using System;

namespace SportsFacilities
{
    /// <summary>
    /// Футбольный стадион
    /// </summary>
    public class FootballStadium : Stadium
    {
        public FootballStadium(int capacity) : base(capacity) { }

        public void HostMatch()
        {
            Console.WriteLine("Матч на футбольном стадионе");
        }
    }
}
