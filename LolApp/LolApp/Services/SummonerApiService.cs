using LolApp.Models;
using Microsoft.AspNetCore.DataProtection;
using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LolApp.Services
{
    public class SummonerApiService : ISummonerApiService
    {
        ILolIconsApiService LolIconsApiService;
        public SummonerApiService(ILolIconsApiService lolIconsApiService)
        {
            LolIconsApiService = lolIconsApiService;
        }

        public async Task<Summoner> GetSummonerAsync(string summonerName)
        {
            Summoner summoner = null;


            var refitClient = RestService.For<ISummonerApi>(Config.LatinAmericaNorthSummonerApiUrl);

            var response = await refitClient.GetSummonerByNameAsync(summonerName, Config.ApiKey);

            if (response.IsSuccessStatusCode)
            {
                var jsonSummoner = await response.Content.ReadAsStringAsync();

                summoner = JsonConvert.DeserializeObject<Summoner>(jsonSummoner);
            }

            return summoner;
        }
    }
}
