using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace LolApp.Models
{
    public class ChampionRoot
    {

        [JsonPropertyName("data")]
        public Dictionary<string, Champion> Data { get; set; }
    }
}
