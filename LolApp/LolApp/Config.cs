﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LolApp
{
    public static class Config
    {
        //Api Key
        public const string ApiKey = "Api Key";

        //Pages constants
        public const string SummonerPage = "Summoner";
        public const string RankingPage = "Ranking";
        public const string MainTabbedPage = "Main"; 
        public const string GrandMasterPage = "GrandMaster";

        public const string MatchTotalPage = "MatchTotal";
        public const string MatchBuildPage = "MatchBuild";
        public const string MatchTabbedPage = "Match";

        public const string MatchAnalysisTabbedPage = "MatchAnalysis";
        public const string MatchAnalysisChampionKillsPage = "ChampionKills";
        public const string MatchAnalysisGoldPage = "Gold";
        public const string MatchAnalysisDamageDealtPage = "DamageDealt";


        //Navigation parameters variables
        public const string MatchParam = "MatchParameter";


        public const string NaRankingApiUrl = "https://na1.api.riotgames.com/lol/league-exp/v4/entries";

        public const string LanStatusApiUrl = "https://la1.api.riotgames.com/lol/league/v4/grandmasterleagues/by-queue";

        //Summoner data endpoints of all regions
        public const string LatinAmericaNorthSummonerApiUrl = "https://la1.api.riotgames.com/lol/summoner/v4/summoners";
        public const string LatinAmericaSouthSummonerApiUrl = "https://la2.api.riotgames.com/lol/summoner/v4/summoners";
        public const string NorthAmericaSummonerApiUrl = "https://na1.api.riotgames.com/lol/summoner/v4/summoners";
        public const string EuropaWestummonerApiUrl = "https://euw1.api.riotgames.com/lol/summoner/v4/summoners";
        public const string EuropaNodicSummonerApiUrl = "https://eun1.api.riotgames.com/lol/summoner/v4/summoners";
        public const string BrazilSummonerApiUrl = "https://br1.api.riotgames.com/lol/summoner/v4/summoners";
        public const string JapanSummonerApiUrl = "https://jp1.api.riotgames.com/lol/summoner/v4/summoners";
        public const string KoreaSummonerApiUrl = "https://kr1.api.riotgames.com/lol/summoner/v4/summoners";
        public const string OceaniaSummonerApiUrl = "https://oc1.api.riotgames.com/lol/summoner/v4/summoners";
        public const string RussiaSummonerApiUrl = "https://ru.api.riotgames.com/lol/summoner/v4/summoners";
        public const string TurkeySummonerApiUrl = "https://tr1.api.riotgames.com/lol/summoner/v4/summoners";


        //Images Api 
        public const string ProfileIconUrl = "https://ddragon.leagueoflegends.com/cdn/11.7.1/img/profileicon/";
        public const string ChampionIconUrl = "https://ddragon.leagueoflegends.com/cdn/11.7.1/img/champion/";
        public const string ItemIconUrl = "https://ddragon.leagueoflegends.com/cdn/11.7.1/img/item/";


        //Match Api Endpoint
        public const string MatchApiUrl = "https://la1.api.riotgames.com/lol/match/v4";


    }
}
