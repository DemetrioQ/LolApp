using LolApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace LolApp.Services
{
    public interface IMatchApiService
    {
        Task<MatchList> GetMatchesByAccountIdAsync(string accountId);
        Task<Match> GetMatchByIdAsync(string matchId);
    }
}
