using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Task_1.Model;
using Task_1.MyExceptions;

namespace Task_1
{
    public static class Search_for_prime_numbers
    {
        public static void Run()
        {
            Stopwatch stopwatch = new Stopwatch();
            var listNumber = new List<int>();
            try
            {
                var input = FileAll.Read("settings.json");
                stopwatch.Start();
                for (int i = input.PrimesFrom; i < input.PrimesTo; i++)
                {
                    if (IsPrimeNumber(i))
                    {
                        listNumber.Add(i);
                    }
                }
                stopwatch.Stop();
                FileAll.Write("result.json", new Output(true, "null", stopwatch.Elapsed.ToString(), listNumber));
            }
            catch (FileException)
            {
                stopwatch.Stop();
                FileAll.Write("result.json", new Output(false, "settings.json are missing or corrupte", stopwatch.Elapsed.ToString(), listNumber));
            }
            catch (MyExceptions.JsonException)
            {
                stopwatch.Stop();
                FileAll.Write("result.json", new Output(false, "JSON is not valid", stopwatch.Elapsed.ToString(), listNumber));
            }
            catch(Exception ex)
            {
                FileAll.Write("result.json", new Output(false, ex.Message, stopwatch.Elapsed.ToString(), listNumber));
            }
        
        }
        
        static bool IsPrimeNumber(int n)
        {
            var result = true;

            if (n > 1)
            {
                var max = (uint)Math.Sqrt(n);
                for (var i = 2u; i <= max; i++)
                {
                    if (n % i == 0)
                    {
                        result = false;
                        break;
                    }
                }
            }
            else
            {
                result = false;
            }

            return result;
        }
    }
}
