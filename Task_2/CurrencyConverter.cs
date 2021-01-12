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
        static List<Currency> list = new List<Currency>();
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
                    list = FileWork.Read();
                    source = EnterCurrency("Source");
                    desired = EnterCurrency("Desired");
                    decimal sum = EnterSum();
                    Currency sourceCurrency = FindCurrency(source);
                    Currency desiredCurrency = FindCurrency(desired); 
                    decimal result = sum * (decimal)sourceCurrency.Rate / (decimal)desiredCurrency.Rate;
                    string date = "";
                    if (sourceCurrency.Exchangedate != "always")
                        date = sourceCurrency.Exchangedate;
                    else
                        date = desiredCurrency.Exchangedate;
                     decimal cof = (decimal)sourceCurrency.Rate / (decimal)desiredCurrency.Rate;
                     Console.WriteLine($"{sum} {sourceCurrency.Cc} * {string.Format("{0:0.00}", cof)} = {string.Format("{0:0.00}", result)} {desiredCurrency.Cc} (from {date})");

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
        static Currency FindCurrency(string currency)
        {
            if (currency == "UAH")
               return new Currency(0, "UAH", 1, "UAH", "always");
            else
            {
               return list.Find(f => f.Cc == currency) ?? throw new CurrencyException();
            }
        }
        static string EnterCurrency(string name)
        {
            while (true)
            {
                Console.Write($"Enter {name} currency(not an empty string, 3 characters[A-Z]): ");
                string input = Console.ReadLine();
                input = input.Trim(' ');
                input = input.ToUpper();
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
                input = input.Trim(' ');
                if (decimal.TryParse(input, out decimal sum) && (sum >= 0))
                    return sum;
                Console.WriteLine("Error Input. Please try again.");
            }
        }
    }
}
