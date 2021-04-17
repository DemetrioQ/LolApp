using LolApp.Models;
using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LolApp.Services
{
    public class MatchApiService : IMatchApiService
    {
        ILolIconsApiService LolIconsApiService;
        public MatchApiService(ILolIconsApiService lolIconsApiService)
        {
            LolIconsApiService = lolIconsApiService;
        }

        public async Task<Match> GetMatchByIdAsync(string matchId, string key)
        {
            Match match = null;
            var refitClient = RestService.For<IMatchApi>(Config.LatinAmericaNorthMatchesApiUrl);

            var rankingResponse = await refitClient.GetMatchByIdAsync(matchId, Config.ApiKey);

            if (rankingResponse.IsSuccessStatusCode)
            {
                var jsonRanking = await rankingResponse.Content.ReadAsStringAsync();
                match = JsonConvert.DeserializeObject<Match>(jsonRanking);
                
            }
            return match;
        }

        public Task<ObservableCollection<Match>> GetMatches(string accountId, string key)
        {
            throw new NotImplementedException();
        }
    }
}
