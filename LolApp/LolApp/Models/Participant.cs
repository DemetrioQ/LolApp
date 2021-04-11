using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.Json.Serialization;

namespace LolApp.Models
{
    public class Participant : BaseModel
    {
        [JsonPropertyName("participantId")]
        public int ParticipantId { get; set; }

        public string SummonerName { get; set; }

        [JsonPropertyName("teamId")]
        public int TeamId { get; set; }

        [JsonPropertyName("championId")]
        public int ChampionId { get; set; }

        public Champion Champion { get; set; }

        [JsonPropertyName("spell1Id")]
        public int Spell1Id { get; set; }


        [JsonPropertyName("spell2Id")]
        public int Spell2Id { get; set; }


        [JsonPropertyName("stats")]
        public Stats Stats { get; set; }

        [JsonPropertyName("timeline")]
        public Timeline Timeline { get; set; }
        public string Spell1Icon { get; set; }

        public string Spell2Icon { get; set; }

    }


}
