using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Task_2.Model;
using Task_2.MyException;
using System.IO;

namespace Task_2
{
    public class CurrencyConverter
    {
        static readonly Regex regex = new Regex(@"^[A-Z]{3}$");
        public static void Run()
        {
            Console.WriteLine("Name program: Task 2. Currency converter");
            Console.WriteLine("Author: Halych Ivan");
            string json;
            json = Api.GET().Result;
            if (json != null)
                FileWork.Write(json);
            while (true)
            {
                string source=null;
                string desired=null;
                try
                {
                    var list = FileWork.Read();
                    source = EnterCurrency("Source");
                    desired = EnterCurrency("Desired");
                    decimal sum = EnterSum();
                    Currency sourceCurrency;
                    if (source == "UAH")
                        sourceCurrency = new Currency(0, "UAH", 1, "UAH", "always");
                    else
                    {
                        sourceCurrency = list.Find(f => f.Cc == source) ?? throw new CurrencyException(source);
                    }
                    Currency desiredCurrency;
                    if (desired == "UAH")
                        desiredCurrency = new Currency(0, "UAH", 1, "UAH", "always");
                    else
                    {
                        desiredCurrency = list.Find(f => f.Cc == desired) ?? throw new CurrencyException(source);
                    }   
                    decimal result = sum * (decimal)sourceCurrency.Rate / (decimal)desiredCurrency.Rate;
                    Console.WriteLine($"{sum} {sourceCurrency.Cc} * {string.Format("{0:0.00}", (decimal)sourceCurrency.Rate /(decimal)desiredCurrency.Rate)} = {string.Format("{0:0.00}", result)} {desiredCurrency.Cc} (from {sourceCurrency.Exchangedate})");

                    break;
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("Error: could not find cache.json");
                }
                catch (CurrencyException)
                {
                    Console.WriteLine($"Error: could not find couple {source},{desired}");
                }
            }
        }
        static string EnterCurrency(string name)
        {
            while (true)
            {
                Console.Write($"Enter {name} currency(not an empty string, 3 characters[A-Z]): ");
                string input = Console.ReadLine();
                if (regex.IsMatch(input))
                    return input;
                Console.WriteLine("Error Input. Please try again.");
            }
        }
        static decimal EnterSum()
        {
            while (true)
            {
                Console.Write("Enter Sum(non-negative decima number): ");
                string input = Console.ReadLine();
                if (decimal.TryParse(input, out decimal sum) && (sum >= 0))
                    return sum;
                Console.WriteLine("Error Input. Please try again.");
            }
        }
    }
}
