using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using LolApp.Models;
using System.Threading.Tasks;

namespace LolApp.Services
{
    public interface IMatchApi
    {
        [Get("/matchlists/by-account/{accountId}?api_key={key}")]
        Task<HttpResponseMessage> GetMatches(string accountId, string key);

        [Get("/matches/{matchId}?api_key={key}")]
        Task<HttpResponseMessage> GetMatchByIdAsync(string matchId, string key);
    }
}
