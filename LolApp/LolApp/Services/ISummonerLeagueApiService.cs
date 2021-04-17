using LolApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LolApp.Services
{
    public interface ISummonerLeagueApiService
    {
        Task<List<SummonerLeagueDetail>> GetSummonerLeagueAsync(string leagueId);
    }
}
