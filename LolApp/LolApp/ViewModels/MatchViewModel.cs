using Android.App;
using LolApp.Models;
using LolApp.Services;
using Newtonsoft.Json;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;

namespace LolApp.ViewModels
{
    public class MatchViewModel : BaseViewModel, IInitialize
    {
        public Match Match { get; set; }
        public Team WinningTeam { get; set; }
        public Team LosingTeam { get; set; }
        public int MostKills { get; set; }
        public string ParticipantTeamColor { get; set; }
        IChampionService ChampionService { get; }
        
        public MatchViewModel(IPageDialogService alertService, IChampionService championService) : base(alertService)
        {
            ChampionService = championService;
            
        }

        public void Initialize(INavigationParameters parameters)
        {
            if (parameters.TryGetValue(Config.MatchParam, out Match match))
            {
                WinningTeam = new Team();
                LosingTeam = new Team();
                Match = match;
                MostKills = 0;

                foreach (var participant in Match.Participants)
                {
                    participant.SummonerName = Match.ParticipantIdentities.Find(x => x.ParticipantId == participant.ParticipantId).Player.SummonerName;
                    participant.Champion = ChampionService.GetChampion(participant.ChampionId);
                    participant.Spell1Icon = Utilis.GetSpell(participant.Spell1Id);
                    participant.Spell2Icon = Utilis.GetSpell(participant.Spell2Id);

                    if(participant.Stats.Kills > MostKills)
                    {
                        MostKills = participant.Stats.Kills;
                    }

                    if (participant.Stats.Win)
                    {
                        WinningTeam.Participants.Add(participant);
                        WinningTeam.Kills += participant.Stats.Kills;
                    }
                    else
                    {
                        LosingTeam.Participants.Add(participant);
                        LosingTeam.Kills += participant.Stats.Kills;
                    }
                }

            }
        }
    }
}
