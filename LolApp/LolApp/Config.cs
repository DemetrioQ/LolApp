using System;
using System.Collections.Generic;
using System.Text;

namespace LolApp
{
    public static class Config
    {
        public const string ApiKey = "Api Key Here";

        public const string SummonerPage = "Summoner";
        public const string RankingPage = "Ranking";
        public const string MainTabbedPage = "Main"; 
        public const string GrandMasterPage = "GrandMaster";

        public const string NaRankingApiUrl = "https://na1.api.riotgames.com/lol/league-exp/v4/entries";

        public const string LanStatusApiUrl = "https://la1.api.riotgames.com/lol/league/v4/grandmasterleagues/by-queue";
        public const string LanSummonerApiUrl = "https://la1.api.riotgames.com";

    }
}
