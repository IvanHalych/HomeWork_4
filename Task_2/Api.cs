using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Task_2
{
    public static class Api
    {
        public static async Task<string> GET()
        {
            HttpClient httpClient = new HttpClient
            {
                Timeout = new TimeSpan(0, 0, 10)
            };
            string body;
            try
            {
                var responce = await httpClient.GetAsync("https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?json");
                responce.EnsureSuccessStatusCode();
                body = await responce.Content.ReadAsStringAsync();
                return body;
            }
            catch (HttpRequestException)
            {
                Console.WriteLine("Failed to update courses");
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }
    }
}
