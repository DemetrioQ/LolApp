using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.Json.Serialization;

namespace LolApp.Models
{
    public class Slot : BaseModel
    {
        [JsonPropertyName("runes")]
        public List<Rune> Runes { get; set; }
    }
}
