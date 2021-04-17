using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace LolApp.Models
{
    public class Rune : BaseModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("icon")]
        public string IconUrlPath { get; set; }
        public string RuneIcon
        {
            get
            {
                return $"{Config.RuneIconUrl}{IconUrlPath}";
            }
        }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("shortDesc")]
        public string ShortDesc { get; set; }

        [JsonPropertyName("longDesc")]
        public string LongDesc { get; set; }
    }
}
