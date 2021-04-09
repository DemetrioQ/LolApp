using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace LolApp.Models
{
    public class Match
    {
        [JsonPropertyName("platformId")]
        public string PlatformId { get; set; }

        [JsonPropertyName("gameId")]
        public int GameId { get; set; }

        [JsonPropertyName("champion")]
        public int Champion { get; set; }

        [JsonPropertyName("queue")]
        public int Queue { get; set; }

        [JsonPropertyName("season")]
        public int Season { get; set; }

        [JsonPropertyName("timestamp")]
        public object Timestamp { get; set; }

        [JsonPropertyName("role")]
        public string Role { get; set; }

        [JsonPropertyName("lane")]
        public string Lane { get; set; }

        [JsonPropertyName("gameCreation")]
        public long GameCreation { get; set; }

        [JsonPropertyName("gameDuration")]
        public int GameDuration { get; set; }

        [JsonPropertyName("queueId")]
        public int QueueId { get; set; }

        [JsonPropertyName("mapId")]
        public int MapId { get; set; }

        [JsonPropertyName("seasonId")]
        public int SeasonId { get; set; }

        [JsonPropertyName("gameVersion")]
        public string GameVersion { get; set; }

        [JsonPropertyName("gameMode")]
        public string GameMode { get; set; }

        [JsonPropertyName("gameType")]
        public string GameType { get; set; }

        [JsonPropertyName("teams")]
        public List<Team> Teams { get; set; }

        [JsonPropertyName("participants")]
        public List<Participant> Participants { get; set; }

        [JsonPropertyName("participantIdentities")]
        public List<ParticipantIdentity> ParticipantIdentities { get; set; }
    }
}
