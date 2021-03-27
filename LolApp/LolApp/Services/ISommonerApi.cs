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

        [Get("/lol/summoner/v4/summoners/by-name/{summonerName}?api_key={key}")]
        Task<HttpResponseMessage> GetSummonerAsync(string summonerName, string key);
    }
}
