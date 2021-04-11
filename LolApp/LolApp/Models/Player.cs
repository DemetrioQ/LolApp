using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace LolApp.Models
{
    public class Player : BaseModel
    {
        [JsonPropertyName("platformId")]
        public string PlatformId { get; set; }

        [JsonPropertyName("accountId")]
        public string AccountId { get; set; }

        [JsonPropertyName("summonerName")]
        public string SummonerName { get; set; }

        [JsonPropertyName("summonerId")]
        public string SummonerId { get; set; }

        [JsonPropertyName("currentPlatformId")]
        public string CurrentPlatformId { get; set; }

        [JsonPropertyName("currentAccountId")]
        public string CurrentAccountId { get; set; }

        [JsonPropertyName("matchHistoryUri")]
        public string MatchHistoryUri { get; set; }

        [JsonPropertyName("profileIcon")]
        public int ProfileIcon { get; set; }
    }

}
