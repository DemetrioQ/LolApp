using System;
using System.Collections.Generic;
using System.Text;

namespace LolApp.Models
{
    public class SummonerLeagueDetail
    {
        public string LeagueId { get; set; }
        public string QueueType { get; set; }
        public string Tier { get; set; }

        public string TierImage
        {
            get
            {
                return Utils.GetRankedEmblemsByName(Tier);
            }
        }
        
        public string Rank { get; set; }
        public string SummonerId { get; set; }
        public string SummonerName { get; set; }
        public int LeaguePoints { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public bool Veteran { get; set; }

        public decimal WinRate
        {
            get
            {
                return Math.Round(((decimal)Wins / (decimal)(Losses + Wins)) * 100, 2);
            }
        }
        public bool Inactive { get; set; }
        public bool FreshBlood { get; set; }
        public bool HotStreak { get; set; }

    }
}
