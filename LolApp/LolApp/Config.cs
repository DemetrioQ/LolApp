using System;
using System.Collections.Generic;
using System.Text;

namespace LolApp
{
    public static class Config
    {
        //Api Key
        public const string ApiKey = "RGAPI-bd9eb916-44c6-4f71-bcbf-8236b3b24b0f";

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




        public static string GetSpell(int id)
        {
            string spell = "https://ddragon.leagueoflegends.com/cdn/11.7.1/img/spell/";
            switch (id)
            {
                case 1:
                    spell += "SummonerBoost.png";
                    break;
                case 21:
                    spell += "SummonerBarrier.png";
                    break;
                case 14:
                    spell += "SummonerDot.png";
                    break;
                case 3:
                    spell += "SummonerExhaust.png";
                    break;
                case 4:
                    spell += "SummonerFlash.png";
                    break;
                case 6:
                    spell += "SummonerHaste.png";
                    break;
                case 7:
                    spell += "SummonerHeal.png";
                    break;
                case 13:
                    spell += "SummonerMana.png";
                    break;
                case 30:
                    spell += "SummonerPoroRecall.png";
                    break;
                case 31:
                    spell += "SummonerPoroThrow.png";
                    break;
                case 11:
                    spell += "SummonerSmite.png";
                    break;
                case 39:
                    spell += "SummonerSnowURFSnowball_Mark.png";
                    break;
                case 32:
                    spell += "SummonerSnowball.png";
                    break;
                case 12:
                    spell += "SummonerTeleport.png";
                    break;
                default:
                    break;
            }


            return spell;
        }


    }
}
