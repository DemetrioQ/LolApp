using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LolApp.Services
{
    public interface ISummonerLeagueDetail
    {

        [Get("/by-summoner/{leagueId}?api_key={key}")]
        Task<HttpResponseMessage> GetSummonerLeagueDetailByIdAsync(string leagueId, string key);
    }
}
