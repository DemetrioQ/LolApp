using LolApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace LolApp
{
    public static class Config
    {
        //Api Key
        public const string ApiKey = "RGAPI-cddd1495-e859-4851-90ec-7b7275c039f9";

        public const string NaRankingApiUrl = "https://na1.api.riotgames.com/lol/league-exp/v4/entries";

        public const string LanStatusApiUrl = "https://la1.api.riotgames.com/lol/league/v4/grandmasterleagues/by-queue";

        //Summoner data endpoints of all regions
        public const string LatinAmericaNorthLeagueApiUrl = "https://la1.api.riotgames.com/lol/league/v4/entries";
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
        public const string SummonerSpellsIconUrl = "https://ddragon.leagueoflegends.com/cdn/11.7.1/img/spell/";


        //Match Api Endpoint
        public const string MatchApiUrl = "https://la1.api.riotgames.com/lol/match/v4";


        //Champion Api
        public const string ChampionsApiUrl = "http://ddragon.leagueoflegends.com/cdn/11.7.1/data/en_US/champion.json";

    }
}

