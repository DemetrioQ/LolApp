using LolApp.Models;
using LolApp.Services;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;

namespace LolApp.ViewModels
{
    public class SummonerDetailViewModel : BaseViewModel, IInitialize
    {
        public Summoner Summoner { get; set; }

        public List<SummonerLeagueDetail> SummonerDetailList { get; set; }

        public MatchList SummonerMatches { get; set; }

        public ObservableCollection<Match> SummonerDetailedMatches { get; set; }

        private ISummonerLeagueApiService _summonerLeagueApiServie;
        private IMatchApiService _matchApiService;
        private INavigationService _navigation;

        public ICommand Refresh { get; }

        public ObservableCollection<Participant> ParticipationsOfCurrentSummoner { get; set; }

        public ICommand OnOpenGameCommand { get; }

        private List<int> participantIdByMatch;
        public SummonerDetailViewModel(IPageDialogService pageDialogService, ISummonerLeagueApiService summonerLeagueApiService, IMatchApiService matchApiService, INavigationService navigation) : base(pageDialogService)
        {
            OnOpenGameCommand = new DelegateCommand<Participant>(GetMatchDetails);
            Refresh = new DelegateCommand(GetSummonerMatches);
            _summonerLeagueApiServie = summonerLeagueApiService;
            _matchApiService = matchApiService;
            _navigation = navigation;
        }

        public void GetMatchDetails(Participant participant)
        {
            _navigation.NavigateAsync($"{NavigationConstant.MatchTabbedPage}", new NavigationParameters()
            {
                {NavigationConstant.MatchParam, SummonerDetailedMatches.First(element => element.GameId == participant.GameId) },
                {NavigationConstant.SummonerParam, Summoner }

            });
            
        }

        public void Initialize(INavigationParameters parameters)
        {
            if(parameters.TryGetValue(NavigationConstant.SummonerParam, out Summoner _summoner))
            {
                Summoner = _summoner;
            }

            GetSummonerLeague();
            GetSummonerMatches();
        }

        private async void GetSummonerLeague()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                var summonerDetail = await _summonerLeagueApiServie.GetSummonerLeagueAsync(Summoner.Id);

                SummonerDetailList = summonerDetail;
            }
            else
            {
                await AlertService.DisplayAlertAsync("No internet connection", "No internet connection detected", "ok");
            }
        }

        private async void GetSummonerMatches()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                var summonerMatches = await _matchApiService.GetMatchesByAccountIdAsync(Summoner.AccountId);

                SummonerMatches = summonerMatches;

                SummonerDetailedMatches = new ObservableCollection<Match>();

                participantIdByMatch = new List<int>();

                foreach (MatchElement element in SummonerMatches.Matches)
                {
                    Match matchWholeElement = await _matchApiService.GetMatchByIdAsync(element.GameId.ToString());

                    SummonerDetailedMatches.Add(matchWholeElement);

                    foreach (ParticipantIdentity participantId in matchWholeElement.ParticipantIdentities)
                    {
                        if(participantId.Player.SummonerId == Summoner.Id)
                        {
                            participantIdByMatch.Add(participantId.ParticipantId);
                        }
                    }

                }

                ParticipationsOfCurrentSummoner = new ObservableCollection<Participant>();

                int counter = 0;

                foreach (Match match in SummonerDetailedMatches)
                {
                    
                    ParticipationsOfCurrentSummoner.Add(match.Participants.First(element => element.ParticipantId == participantIdByMatch[counter]));
                    ParticipationsOfCurrentSummoner[counter].GameId = match.GameId;
                    counter++;
                }



                

               // var participantId = SummonerDetailedMatches.First((p)=> p.ParticipantIdentities.Pla == "")


            }
            else
            {
                await AlertService.DisplayAlertAsync("No internet connection", "No internet connection detected", "ok");
            }

        }
    }
}
