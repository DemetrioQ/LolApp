using LolApp.Models;
using LolApp.Services;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace LolApp.ViewModels
{
    public class SummonerDetailViewModel : BaseViewModel, IInitialize
    {
        public Summoner Summoner { get; set; }

        public List<SummonerLeagueDetail> SummonerDetailList {get;set;}

        public MatchList SummonerMatches { get; set; }

        private ISummonerLeagueApiService _summonerLeagueApiServie;
        private IMatchApiService _matchApiService;
        public SummonerDetailViewModel(IPageDialogService pageDialogService, ISummonerLeagueApiService summonerLeagueApiService, IMatchApiService matchApiService) : base(pageDialogService)
        {
            //GetSummonerCommand = new DelegateCommand(GetSummonerAsync);
            _summonerLeagueApiServie = summonerLeagueApiService;
            _matchApiService = matchApiService;
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
            }
            else
            {
                await AlertService.DisplayAlertAsync("No internet connection", "No internet connection detected", "ok");
            }
        }
    }
}
