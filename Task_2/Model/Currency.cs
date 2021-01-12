using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Task_2.Model
{
    public class Currency
    {
        public Currency(int r030, string txt, double rate, string cc, string exchangedate)
        {
            R030 = r030;
            Txt = txt;
            Rate = rate;
            Cc = cc;
            Exchangedate = exchangedate;
        }

        [JsonProperty("r030")]
        public int R030 { get; set; }

        [JsonProperty("txt")]
        public string Txt { get; set; }

        [JsonProperty("rate")]
        public double Rate { get; set; }

        [JsonProperty("cc")]
        public string Cc { get; set; }

        [JsonProperty("exchangedate")]
        public string Exchangedate { get; set; }
    }
}
