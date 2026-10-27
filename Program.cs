using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Day_01_G03
{
    internal class Program
    {
        static void Main()
        {
            var products = ListGenerator.ProductsList;
            var customers = ListGenerator.CustomersList;
            string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };
            string[] caseWords = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };

            void Section(string title) => Console.WriteLine("\n===== " + title + " =====");
            void Show<T>(IEnumerable<T> items) { foreach (var item in items) Console.WriteLine(item); }

            Section("Restriction Operators");
            Show(products.Where(p => p.UnitsInStock == 0));
            Show(products.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3.00m));
            Show(digits.Where((name, value) => name.Length < value));

            Section("Element Operators");
            Console.WriteLine(products.FirstOrDefault(p => p.UnitsInStock == 0));
            Console.WriteLine(products.FirstOrDefault(p => p.UnitPrice > 1000m));
            Console.WriteLine(numbers.Where(n => n > 5).Skip(1).FirstOrDefault());

            Section("Aggregate Operators");
            Console.WriteLine("Odd count: " + numbers.Count(n => n % 2 != 0));
            Show(customers.Select(c => $"{c.CustomerName}: {c.Orders.Length} orders"));
            Show(products.GroupBy(p => p.Category).Select(g => $"{g.Key}: {g.Count()} products"));
            Console.WriteLine("Sum: " + numbers.Sum());
            string[] dictionary = File.ReadAllLines("dictionary_english.txt");
            Console.WriteLine("Total characters: " + dictionary.Sum(w => w.Length));
            Console.WriteLine("Shortest word length: " + dictionary.Min(w => w.Length));
            Console.WriteLine("Longest word length: " + dictionary.Max(w => w.Length));
            Console.WriteLine("Average word length: " + dictionary.Average(w => w.Length));

            Section("Ordering Operators");
            Show(products.OrderBy(p => p.ProductName));
            Show(caseWords.OrderBy(w => w, StringComparer.OrdinalIgnoreCase));
            Show(products.OrderByDescending(p => p.UnitsInStock));
            Show(digits.OrderBy(w => w.Length).ThenBy(w => w));
            Show(caseWords.OrderBy(w => w.Length).ThenBy(w => w, StringComparer.OrdinalIgnoreCase));
            Show(products.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice));
            Show(caseWords.OrderBy(w => w.Length).ThenByDescending(w => w, StringComparer.OrdinalIgnoreCase));
            Show(digits.Where(w => w.Length > 1 && w[1] == 'i').Reverse());

            Section("Transformation Operators");
            Show(products.Select(p => p.ProductName));
            Show(words.Select(w => new { Upper = w.ToUpper(), Lower = w.ToLower() })
                      .Select(x => $"Upper: {x.Upper}, Lower: {x.Lower}"));
            Show(products.Select(p => new { p.ProductName, p.Category, Price = p.UnitPrice }));
            Show(numbers.Select((value, index) => $"{value} at position {index}: {value == index}"));
            Show(numbersA.SelectMany(a => numbersB.Where(b => a < b), (a, b) => $"({a}, {b})"));
            Show(customers.SelectMany(c => c.Orders.Where(o => o.Total < 500m)
                .Select(o => $"{c.CustomerName} | {o}")));
            Show(customers.SelectMany(c => c.Orders.Where(o => o.OrderDate.Year >= 1998)
                .Select(o => $"{c.CustomerName} | {o}")));
        }
    }
}
