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
        public Match MatchAnalysisKill { get; set; }
        public Match MatchAnalysisGold { get; set; }
        public Team WinningTeam { get; set; }
        public Team LosingTeam { get; set; }
        public int MostKills { get; set; }
        public int MostGold { get; set; }
        public int MostDamage { get; set; }
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
                MostGold = 0;

                foreach (var participant in Match.Participants)
                {
                    if (participant.Stats.Win)
                    {
                        WinningTeam.Participants.Add(participant);
                        WinningTeam.Kills += participant.Stats.Kills;
                        WinningTeam.Gold += participant.Stats.GoldEarned;
                        WinningTeam.Damage += participant.Stats.TotalDamageDealt;
                    }
                    else
                    {
                        LosingTeam.Participants.Add(participant);
                        LosingTeam.Kills += participant.Stats.Kills;
                        LosingTeam.Gold += participant.Stats.GoldEarned;
                        LosingTeam.Damage += participant.Stats.TotalDamageDealt;
                    }

                    participant.SummonerName = Match.ParticipantIdentities.Find(x => x.ParticipantId == participant.ParticipantId).Player.SummonerName;
                    participant.Champion = ChampionService.GetChampion(participant.ChampionId);
                    participant.Spell1Icon = Utilis.GetSpell(participant.Spell1Id);
                    participant.Spell2Icon = Utilis.GetSpell(participant.Spell2Id);

                    MostKills = participant.Stats.Kills > MostKills ? participant.Stats.Kills : MostKills;
                    MostGold = participant.Stats.GoldEarned > MostGold ? participant.Stats.GoldEarned : MostGold;
                    MostDamage = participant.Stats.TotalDamageDealt > MostDamage ? participant.Stats.TotalDamageDealt : MostDamage;
                }

                Match.Participants = new ObservableCollection<Participant>(Match.Participants.OrderByDescending(x => x.Stats.TotalDamageDealt));
                MatchAnalysisGold = match;
                MatchAnalysisGold.Participants = new ObservableCollection<Participant>(MatchAnalysisGold.Participants.OrderByDescending(x => x.Stats.GoldEarned));
                MatchAnalysisKill = match;
                MatchAnalysisKill.Participants = new ObservableCollection<Participant>(MatchAnalysisKill.Participants.OrderByDescending(x => x.Stats.Kills));
            }
        }
    }
}
