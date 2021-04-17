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

        private ISummonerLeagueApiService _summonerLeagueApiServie;
        public SummonerDetailViewModel(IPageDialogService pageDialogService, ISummonerLeagueApiService summonerLeagueApiService) : base(pageDialogService)
        {
            //GetSummonerCommand = new DelegateCommand(GetSummonerAsync);
            _summonerLeagueApiServie = summonerLeagueApiService;
            
        }

        public void Initialize(INavigationParameters parameters)
        {
            if(parameters.TryGetValue(NavigationConstant.SummonerParam, out Summoner _summoner))
            {
                Summoner = _summoner;
            }

            GetSummonerLeague();
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
    }
}
