using LolApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LolApp.Services
{
    public interface IMatchApiService
    {
        Task<MatchList> GetMatchesByAccountIdAsync(string accountId);
        
    }
}
