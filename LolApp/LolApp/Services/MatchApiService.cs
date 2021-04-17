using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LolApp.Services
{
    public class MatchApiService : IMatchApi
    {
        ILolIconsApiService LolIconsApiService;
        public MatchApiService(ILolIconsApiService lolIconsApiService)
        {
            LolIconsApiService = lolIconsApiService;
        }

        public Task<HttpResponseMessage> GetMatchById(string matchId, string key)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> GetMatches(string puuid, string key)
        {
            throw new NotImplementedException();
        }
    }
}
