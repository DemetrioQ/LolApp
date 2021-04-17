using LolApp.Models;
using LolApp.Services;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace LolApp.ViewModels
{
    class SummonerViewModel : BaseViewModel
    {
        public string Title { get; } = "League of Legends App";
        public Summoner Summoner { get; set; }
        public bool Show { get; set; } = false;
        public string SummonerName { get; set; }
        public bool IsBusy { get;set; }


        private ISummonerApiService _summonerApiService;

        private INavigationService _navigationService;
        public ICommand GetSummonerCommand { get; }

        public ICommand SummonerDetailCommand { get; }



        public SummonerViewModel(ISummonerApiService summonerService, IPageDialogService alertService, INavigationService navigationService) : base(alertService)
        {
            GetSummonerCommand = new DelegateCommand(GetSummonerAsync);
            SummonerDetailCommand = new Command(async () => await OnSummonerDetailTapped() );
            _summonerApiService = summonerService;
            _navigationService = navigationService;
        }

        private async Task OnSummonerDetailTapped()
        {
            var navigationParams = new NavigationParameters
            {
                { NavigationConstant.SummonerParam, Summoner}
            };



            await _navigationService.NavigateAsync($"{NavigationConstant.SummonerDetailPage}", navigationParams);
        }

        private async void GetSummonerAsync()
        {
            
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                IsBusy = true;
                var summoner = await _summonerApiService.GetSummonerAsync(SummonerName);

                if (summoner == null)
                {
                    await AlertService.DisplayAlertAsync(AlertConstant.SummonerNotFoundTitle,AlertConstant.SummonerNotFoundDescription,AlertConstant.SummonerNotFoundConfirm);
                    Show = false;
                }
                else
                {
                    Show = true;
                }

                Summoner = summoner;
                IsBusy = false;
            }
            else
            {
                await AlertService.DisplayAlertAsync(AlertConstant.NoInternetConnectionTitle, AlertConstant.NoInternetConnectionDescription, AlertConstant.NoInternetConnectionConfirm);
            }


        }

    }
}
