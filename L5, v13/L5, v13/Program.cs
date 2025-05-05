using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace SentenceFilterApp
{
    class Program
    {
        static void Main()
        {
            var inputText = "Сегодня 21.02.99 прекрасный день. Завтра будет хуже. А помнишь 22/02/00? Или 12.02.08! Но 13.02.08 уже не входит. 01.01.01 это было круто.";

            var processor = new SentenceProcessor();

            var filteredSentences = processor.GetSentencesWithDatesInRange(inputText, 3, new DateTime(1999, 2, 21), new DateTime(2008, 2, 12));

            Console.WriteLine("Подходящие предложения:");
            foreach (var sentence in filteredSentences)
            {
                Console.WriteLine("- " + sentence);
            }
        }
    }

    public class SentenceProcessor
    {
        // Форматы, которые мы хотим распознавать
        private readonly string[] _dateFormats = { "dd.MM.yyyy", "dd.MM.yy", "dd/MM/yy" };

        // Основной метод — возвращает подходящие предложения
        public List<string> GetSentencesWithDatesInRange(string text, int minWordCount, DateTime from, DateTime to)
        {
            var sentences = SplitIntoSentences(text);
            var result = new List<string>();

            foreach (var sentence in sentences)
            {
                if (CountWords(sentence) < minWordCount)
                    continue;

                var datesInSentence = FindDates(sentence);

                // Оставляем только те предложения, где есть дата в нужном диапазоне
                if (datesInSentence.Any(date => date >= from && date <= to))
                {
                    result.Add(sentence.Trim());
                }
            }

            return result;
        }

        // Разделяем текст на предложения по точке, вопросительному и восклицательному знакам
        private List<string> SplitIntoSentences(string text)
        {
            return Regex.Split(text, @"(?<=[.!?])\s+").ToList();
        }

        // Считаем слова (грубо, но сойдёт)
        private int CountWords(string sentence)
        {
            return sentence.Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        // Находим все даты в предложении, учитывая нужные форматы
        private List<DateTime> FindDates(string sentence)
        {
            var dates = new List<DateTime>();

            var dateMatches = Regex.Matches(sentence, @"\b\d{2}[./]\d{2}[./]\d{2,4}\b");

            foreach (Match match in dateMatches)
            {
                string dateString = match.Value;

                foreach (var format in _dateFormats)
                {
                    if (DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out var parsedDate))
                    {
                        // Приводим двухзначные года к полным
                        if (parsedDate.Year < 100)
                        {
                            parsedDate = parsedDate.Year >= 30
                                ? parsedDate.AddYears(1900 - parsedDate.Year)
                                : parsedDate.AddYears(2000 - parsedDate.Year);
                        }

                        dates.Add(parsedDate);
                        break; // Успешно спарсили — не проверяем остальные форматы
                    }
                }
            }

            return dates;
        }
    }
}
