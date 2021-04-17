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
        public Summoner MainSummoner { get; set; }
        public Participant MainParticipant { get; set; }
        public ObservableCollection<Participant> AnalysisKills { get; set; }
        public ObservableCollection<Participant> AnalysisGold { get; set; }
        public ObservableCollection<Participant> AnalysisDamage { get; set; }
        public Team WinningTeam { get; set; }
        public Team LosingTeam { get; set; }
        public int MostKills { get; set; }
        public int MostGold { get; set; }
        public int MostDamage { get; set; }
        public string ParticipantTeamColor { get; set; }
        IChampionService ChampionService { get; }
        IRuneService RuneService { get; }

        public MatchViewModel(IPageDialogService alertService, IChampionService championService, IRuneService runeService) : base(alertService)
        {
            ChampionService = championService;
            RuneService = runeService;
        }

        public void Initialize(INavigationParameters parameters)
        {
            if (parameters.TryGetValue(NavigationConstant.MatchParam, out Match match) && parameters.TryGetValue(NavigationConstant.SummonerParam, out Summoner summoner))
            {
                GetMatchData(match, summoner);
            }
        }
        public void GetMatchData(Match match, Summoner summoner)
        {
            Match = match;
            MainSummoner = summoner;
            WinningTeam = new Team();
            LosingTeam = new Team();
            AnalysisKills = new ObservableCollection<Participant>(Match.Participants.OrderByDescending((x => x.Stats.Kills)));
            AnalysisGold = new ObservableCollection<Participant>(Match.Participants.OrderByDescending((x => x.Stats.GoldEarned)));
            AnalysisDamage = new ObservableCollection<Participant>(Match.Participants.OrderByDescending((x => x.Stats.TotalDamageDealt)));

            MostKills = Match.Participants.Max(x => x.Stats.Kills);
            MostGold = Match.Participants.Max(x => x.Stats.GoldEarned);
            MostDamage = Match.Participants.Max(x => x.Stats.TotalDamageDealt);

            foreach (var participant in Match.Participants)
            {
                participant.Items = new ObservableCollection<string>();
                participant.Items.Add(participant.Stats.Item0Icon);
                participant.Items.Add(participant.Stats.Item1Icon);
                participant.Items.Add(participant.Stats.Item2Icon);
                participant.Items.Add(participant.Stats.Item3Icon);
                participant.Items.Add(participant.Stats.Item4Icon);
                participant.Items.Add(participant.Stats.Item5Icon);
                participant.Items.Add(participant.Stats.Item6Icon);

                if (participant.Stats.Win)
                {
                    WinningTeam.Participants.Add(participant);
                    WinningTeam.Kills += participant.Stats.Kills;
                    WinningTeam.Deaths += participant.Stats.Deaths;
                    WinningTeam.Assists += participant.Stats.Assists;
                    WinningTeam.Gold += participant.Stats.GoldEarned;
                    WinningTeam.Damage += participant.Stats.TotalDamageDealt;
                }
                else
                {
                    LosingTeam.Participants.Add(participant);
                    LosingTeam.Kills += participant.Stats.Kills;
                    LosingTeam.Deaths += participant.Stats.Deaths;
                    LosingTeam.Assists += participant.Stats.Assists;
                    LosingTeam.Gold += participant.Stats.GoldEarned;
                    LosingTeam.Damage += participant.Stats.TotalDamageDealt;
                }

                if (participant.SummonerName == summoner.Name)
                {
                    participant.IsPlayer = true;
                    MainParticipant = participant;
                    RuneService.GetSlots(MainParticipant);

                    if (WinningTeam.Participants.Contains(MainParticipant))
                    {
                        var tempWinning = Match.Teams.First(x => x.TeamId == MainParticipant.TeamId);
                        WinningTeam.TowerKills = tempWinning.TowerKills;
                        WinningTeam.BaronKills = tempWinning.BaronKills;
                        WinningTeam.DragonKills = tempWinning.DragonKills;

                        var tempLosing = Match.Teams.First(x => x.TeamId != tempWinning.TeamId);
                        LosingTeam.TowerKills = tempLosing.TowerKills;
                        LosingTeam.BaronKills = tempLosing.BaronKills;
                        LosingTeam.DragonKills = tempLosing.DragonKills;
                    }
                    else
                    {
                        var tempLosing = Match.Teams.First(x => x.TeamId == MainParticipant.TeamId);
                        LosingTeam.TowerKills = tempLosing.TowerKills;
                        LosingTeam.BaronKills = tempLosing.BaronKills;
                        LosingTeam.DragonKills = tempLosing.DragonKills;


                        var tempWinning = Match.Teams.First(x => x.TeamId != tempLosing.TeamId);
                        WinningTeam.TowerKills = tempWinning.TowerKills;
                        WinningTeam.BaronKills = tempWinning.BaronKills;
                        WinningTeam.DragonKills = tempWinning.DragonKills;
                    }
                    
                }

                participant.SummonerName = Match.ParticipantIdentities.Find(x => x.ParticipantId == participant.ParticipantId).Player.SummonerName;
                
                participant.Spell1Icon = Utils.GetSpell(participant.Spell1Id);
                participant.Spell2Icon = Utils.GetSpell(participant.Spell2Id);
                participant.Stats.TotalKillsProgress = (float)participant.Stats.Kills / (float)MostKills;
                participant.Stats.TotalGoldEarnedProgress = (float)participant.Stats.GoldEarned / (float)MostGold;
                participant.Stats.TotalDamageDealtProgress = (float)participant.Stats.TotalDamageDealt / (float)MostDamage;
            }

        }
    }
}

