using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace SentenceFilterApp
{
    /// <summary>
    /// Класс для обработки текста и фильтрации предложений
    /// </summary>
    public class SentenceProcessor
    {
        /// <summary>
        /// Поддерживаемые форматы даты
        /// </summary>
        private readonly string[] _dateFormats = { "dd.MM.yyyy", "dd.MM.yy", "dd/MM/yy" };

        /// <summary>
        /// Возвращает предложения, содержащие дату в диапазоне и минимум N слов
        /// </summary>
        public List<string> GetSentencesWithDatesInRange(string text, int minWordCount, DateTime from, DateTime to)
        {
            var sentences = SplitIntoSentences(text);
            var result = new List<string>();

            foreach (var sentence in sentences)
            {
                if (CountWords(sentence) < minWordCount)
                    continue;

                var datesInSentence = FindDates(sentence);

                if (datesInSentence.Any(date => date >= from && date <= to))
                {
                    result.Add(sentence.Trim());
                }
            }

            return result;
        }

        /// <summary>
        /// Делит текст на предложения по '.', '?', '!'
        /// </summary>
        private List<string> SplitIntoSentences(string text)
        {
            return Regex.Split(text, @"(?<=[.!?])\s+").ToList();
        }

        /// <summary>
        /// Считает количество слов в предложении
        /// </summary>
        private int CountWords(string sentence)
        {
            return sentence.Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        /// <summary>
        /// Извлекает даты из предложения, используя поддерживаемые форматы
        /// </summary>
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
                        if (parsedDate.Year < 100)
                        {
                            parsedDate = parsedDate.Year >= 30
                                ? parsedDate.AddYears(1900 - parsedDate.Year)
                                : parsedDate.AddYears(2000 - parsedDate.Year);
                        }

                        dates.Add(parsedDate);
                        break;
                    }
                }
            }

            return dates;
        }
    }
}