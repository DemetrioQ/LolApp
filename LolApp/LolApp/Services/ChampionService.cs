using LolApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace LolApp.Services
{
    public class ChampionService : IChampionService
    {
        private static ChampionService championService = new ChampionService();

        /*public static ChampionService GetChampionService()
        {
            if(championService == null)
            {
                championService = new ChampionService();
            }
            return championService;
        }*/
       
        public ChampionRoot GetChampions()
        {
            var url = Config.ChampionsApiUrl;
            WebClient client = new WebClient();

            var download = client.DownloadString(url);
            return JsonConvert.DeserializeObject<ChampionRoot>(download);
        }

        public Champion GetChampion(int championid)
        {
            var champion = championService.GetChampions().Data.First(x => x.Value.Key == championid).Value;
            champion.ChampionIcon = $"{Config.ChampionIconUrl}{champion.Id}.png";
            return champion;
        }
    }
}
