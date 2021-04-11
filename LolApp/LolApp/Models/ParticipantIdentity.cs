using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace LolApp.Models
{
    public class ParticipantIdentity 
    {
        [JsonPropertyName("participantId")]
        public int ParticipantId { get; set; }

        [JsonPropertyName("player")]
        public Player Player { get; set; }
    }
}
