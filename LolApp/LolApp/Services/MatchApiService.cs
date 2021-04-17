﻿using LolApp.Models;
using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
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

        public Task<HttpResponseMessage> GetMatchById(string matchId, string key)
        {
            throw new NotImplementedException();
        }


        public async Task<MatchList> GetMatchesByAccountIdAsync(string accountId)
        {
            MatchList listOfMatches = null;

            var refitClient = RestService.For<IMatchApi>(Config.LatinAmericaNorthMatchesApiUrl);

            var response = await refitClient.GetMatches(accountId, Config.ApiKey);

            if (response.IsSuccessStatusCode)
            {
                listOfMatches = JsonConvert.DeserializeObject<MatchList>(await response.Content.ReadAsStringAsync());
            }

            return listOfMatches;
        }

    }
}
