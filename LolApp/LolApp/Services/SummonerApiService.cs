using LolApp.Helpers;
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
        public const string ApiKey = Secrets.ApiKey;
        ISerializerService serializerService = new SerializerService();

        public async Task<Summoner> GetSummonerAsync(string summonerName)
        {
            Summoner summ = null;


            var refitClient = RestService.For<ISummonerApi>("https://la1.api.riotgames.com");



            var response = await refitClient.GetSummonerAsync(summonerName, ApiKey);

            if (response.IsSuccessStatusCode)
            {
                var jsonSummoner = await response.Content.ReadAsStringAsync();

                summ = JsonConvert.DeserializeObject<Summoner>(jsonSummoner);
            }

            return summ;
        }
    }
}
