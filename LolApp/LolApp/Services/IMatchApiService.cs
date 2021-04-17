using LolApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace LolApp.Services
{
    interface IMatchApiService
    {
        Task<ObservableCollection<Match>> GetMatches(string accountId, string key);
        Task<Match> GetMatchByIdAsync(string matchId, string key);
    }
}
