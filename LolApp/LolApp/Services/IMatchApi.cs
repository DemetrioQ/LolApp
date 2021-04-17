using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LolApp.Services
{
    public interface IMatchApi
    {
        [Get("by-puuid/{puuid}/ids")]
        Task<HttpResponseMessage> GetMatches(string puuid, string key);

        [Get("{matchId}")]
        Task<HttpResponseMessage> GetMatchById(string matchId, string key);
    }
}
