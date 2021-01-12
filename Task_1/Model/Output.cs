using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Task_1.Model
{
    [Serializable]
    public class Output
    {
        [JsonPropertyName("success")]
        public bool Success { get;  set; }
        [JsonPropertyName("error")]
        public string Error { get;  set; }
        [JsonPropertyName("duration")]
        public string Duration { get;  set; }
        [JsonPropertyName("primes")]
        public List<int> Primes { get;  set; }

        public Output(bool success, string error, string duration, List<int> primes)
        {
            Success = success;
            Error = error;
            Duration = duration;
            Primes = primes;
        }

        public Output()
        {
        }
    }
}
