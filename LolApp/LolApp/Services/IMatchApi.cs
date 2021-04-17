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
        [Get("matchlists/by-account/{accountId}")]
        Task<HttpResponseMessage> GetMatches(string accountId, string key);

        [Get("matches/{matchId}")]
        Task<HttpResponseMessage> GetMatchById(string matchId, string key);
    }
}
