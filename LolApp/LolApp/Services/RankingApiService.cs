using LolApp.Helpers;
using LolApp.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LolApp.Services
{

    public class RankingApiService : IRankingApiService
    {
        public const string ApiKey = Secrets.ApiKey;
        ISerializerService serializerService = new SerializerService();

        public async Task<ObservableCollection<Ranking>> GetRankingAync(string queue, string tier, string division)
        {

            ObservableCollection<Ranking> ranking = null;

            var refitClient = RestService.For<IRankingApi>("https://na1.api.riotgames.com/lol/league-exp/v4/entries");

            var rankingResponse = await refitClient.GetRankingAync(queue, tier, division, ApiKey);

            if (rankingResponse.IsSuccessStatusCode)
            {
                var jsonRanking = await rankingResponse.Content.ReadAsStringAsync();
                ranking = serializerService.Deserialize<ObservableCollection<Ranking>>(jsonRanking);
                ranking = new ObservableCollection<Ranking>(ranking.OrderByDescending(x => x.LeaguePoints));
            }

            return ranking;
        }
    }
}
