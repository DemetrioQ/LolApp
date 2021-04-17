using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public int GameId { get; set; }

        public string Spell2Icon { get; set; }
        public ObservableCollection<string> Items { get; set; }
        public RuneRoot MainRuneRoot { get; set; }
        public RuneRoot SecondaryRuneRoot { get; set; }
        public ObservableCollection<Rune> MainRunes { get; set; }
        public ObservableCollection<Rune> SecondaryRunes { get; set; }


        public bool IsPlayer { get; set; } = false;


    }


}
