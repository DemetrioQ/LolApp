using LolApp.Helpers;
using LolApp.Models;
using LolApp.Services;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LolApp.Services
{
    public class StatusApiService : IStatusApiService
    {
        public async Task<Status> GetStatusAsync()
        {
            string apiKey = Secrets.ApiKey;
            Status status = null;

            var refitClient = RestService.For<IStatusApi>("https://la1.api.riotgames.com/lol/league/v4/grandmasterleagues/by-queue");

            var statusResponse = await refitClient.GetStatusAsync(apiKey);
            if (statusResponse.IsSuccessStatusCode)
            {
                status = JsonSerializer.Deserialize<Status>(await statusResponse.Content.ReadAsStringAsync());
            }

            return status;
        }
    }
}
