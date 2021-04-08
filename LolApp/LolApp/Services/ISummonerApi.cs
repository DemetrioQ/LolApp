using LolApp.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LolApp.Services
{
    public interface ISummonerApi
    {

        [Get("/by-name/{summonerName}?api_key={key}")]
        Task<HttpResponseMessage> GetSummonerByNameAsync(string summonerName, string key);
    }
}
