using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LolApp.Services
{
    public class LolIconsApiService : ILolIconsApiService
    {
        public async Task<string> GetChampionIconAsync(string championId)
        {
            return $"{Config.ChampionIconUrl}/{championId}.png";
        }

        public async Task<string> GetItemIconAsync(int itemId)
        {
            return $"{Config.ItemIconUrl}/{itemId}.png"; ;
        }

        public async Task<string> GetProfileIconAsync(int profileIconId)
        {
            return $"{Config.ProfileIconUrl}/{profileIconId}.png"; ;
        }
    }
}
