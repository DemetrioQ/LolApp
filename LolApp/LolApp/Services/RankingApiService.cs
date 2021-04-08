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
        ISerializerService SerializerService;
        public RankingApiService(ISerializerService serializerService)
        {
            SerializerService = serializerService;
        }

        public async Task<ObservableCollection<Ranking>> GetRankingAync(string queue, string tier, string division)
        {

            if (tier == "CHALLENGER" || tier == "GRANDMASTER" || tier == "MASTER")
            {
                division = "I";
            }

            ObservableCollection<Ranking> ranking = null;

            var refitClient = RestService.For<IRankingApi>(Config.NaRankingApiUrl);

            var rankingResponse = await refitClient.GetRankingAync(queue, tier, division, Config.ApiKey);

            if (rankingResponse.IsSuccessStatusCode)
            {
                var jsonRanking = await rankingResponse.Content.ReadAsStringAsync();
                ranking = SerializerService.Deserialize<ObservableCollection<Ranking>>(jsonRanking);
                ranking = new ObservableCollection<Ranking>(ranking.OrderByDescending(x => x.LeaguePoints));
            }

            return ranking;
        }
    }
}
