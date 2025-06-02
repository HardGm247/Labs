using System;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace SentenceFilterApp
{
    class Program
    {
        private static readonly DateTime StartDate = new DateTime(1999, 2, 21);
        private static readonly DateTime EndDate = new DateTime(2008, 2, 12);
        private const int MinWordCount = 3;

        static void Main()
        {
            var inputText = "Сегодня 21.02.99 прекрасный день. Завтра будет хуже. А помнишь 22/02/00? Или 12.02.08! Но 13.02.08 уже не входит. 01.01.01 это было круто.";

            var processor = new SentenceProcessor();

            var filteredSentences = processor.GetSentencesWithDatesInRange(inputText, MinWordCount, StartDate, EndDate);

            Console.WriteLine("Подходящие предложения:");
            foreach (var sentence in filteredSentences)
            {
                Console.WriteLine("- " + sentence);
            }
        }
    }
}