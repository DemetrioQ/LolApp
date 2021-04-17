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
    public class SummonerLeagueApiService : ISummonerLeagueApiService
    {
        ILolIconsApiService LolIconsApiService;
        public SummonerLeagueApiService(ILolIconsApiService lolIconsApiService)
        {
            LolIconsApiService = lolIconsApiService;
        }

        public async Task<List<SummonerLeagueDetail>> GetSummonerLeagueAsync(string leagueId)
        {
            List<SummonerLeagueDetail> summonerLeagueDetail = null;

            var refitClient = RestService.For<ISummonerLeagueDetail>(Config.LatinAmericaNorthLeagueApiUrl);

            var response = await refitClient.GetSummonerLeagueDetailByIdAsync(leagueId, Config.ApiKey);

            if (response.IsSuccessStatusCode)
            {
                var jsonSummoner = await response.Content.ReadAsStringAsync();

                summonerLeagueDetail = JsonConvert.DeserializeObject<List<SummonerLeagueDetail>>(jsonSummoner);
                
            }

            return summonerLeagueDetail;
        }
    }
}
