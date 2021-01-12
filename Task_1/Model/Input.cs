using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Task_1.Model
{
    [Serializable]
    public class Input
    {
        [JsonPropertyName("primesFrom")]
        public int PrimesFrom { get; set; }
        [JsonPropertyName("primesTo")]
        public int PrimesTo { get;  set; }

        public Input(int primesFrom, int primesTo)
        {
            PrimesFrom = primesFrom;
            PrimesTo = primesTo;
        }

        public Input()
        {
        }
    }
}
