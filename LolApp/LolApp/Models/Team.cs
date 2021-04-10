using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace LolApp.Models
{
    public class Team
    {
        [JsonPropertyName("teamId")]
        public int TeamId { get; set; }

        public ObservableCollection<Participant> Participants { get; set; } = new ObservableCollection<Participant>();


        [JsonPropertyName("win")]
        public string Win { get; set; }

        [JsonPropertyName("firstBlood")]
        public bool FirstBlood { get; set; }

        [JsonPropertyName("firstTower")]
        public bool FirstTower { get; set; }

        [JsonPropertyName("firstInhibitor")]
        public bool FirstInhibitor { get; set; }

        [JsonPropertyName("firstBaron")]
        public bool FirstBaron { get; set; }

        [JsonPropertyName("firstDragon")]
        public bool FirstDragon { get; set; }

        [JsonPropertyName("firstRiftHerald")]
        public bool FirstRiftHerald { get; set; }

        [JsonPropertyName("towerKills")]
        public int TowerKills { get; set; }

        [JsonPropertyName("inhibitorKills")]
        public int InhibitorKills { get; set; }

        [JsonPropertyName("baronKills")]
        public int BaronKills { get; set; }

        [JsonPropertyName("dragonKills")]
        public int DragonKills { get; set; }

        [JsonPropertyName("vilemawKills")]
        public int VilemawKills { get; set; }

        [JsonPropertyName("riftHeraldKills")]
        public int RiftHeraldKills { get; set; }

        [JsonPropertyName("dominionVictoryScore")]
        public int DominionVictoryScore { get; set; }

        [JsonPropertyName("bans")]
        public List<object> Bans { get; set; }
        public int Kills { get; set; }
    }
}
