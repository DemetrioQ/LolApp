using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace LolApp.Models
{
    public class RuneRoot : BaseModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("icon")]
        public string IconPath { get; set; }
        public string Icon 
        {
            get
            {
                return $"{Config.RuneIconUrl}{IconPath}";
            }
         }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("slots")]
        public List<Slot> Slots { get; set; }
    }

}
