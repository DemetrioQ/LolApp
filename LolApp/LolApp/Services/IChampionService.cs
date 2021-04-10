using LolApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LolApp.Services
{
    public interface IChampionService
    {
        ChampionRoot GetChampions();
        Champion GetChampion(int championid);
    }
}
